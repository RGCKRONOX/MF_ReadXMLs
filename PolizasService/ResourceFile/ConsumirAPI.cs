using Newtonsoft.Json;
using PolizasService.DTO;
using ReadXMLPremium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PolizasService.ResourceFile
{
    public class ConsumirAPI
    {
        private readonly HttpClient _httpClient;

        public ConsumirAPI()
        {
            _httpClient = new HttpClient();
        }

        public async Task<(bool IsSuccess, ApiResponse Response)> PostCreateDocumentoAPI(JsonOutput jsonOutput, string apiUrl)
        {
            try
            {
                var jsonComprobanteArray = JsonConvert.SerializeObject(jsonOutput, Formatting.Indented);
                var content = new StringContent(jsonComprobanteArray, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);
                string responseContent = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseContent);
                    return (true, apiResponse);
                }
                else
                {
                    return (false, new ApiResponse { Success = false, Message = $"Error: {responseContent}" });
                }
            }
            catch (Exception ex)
            {
                return (false, new ApiResponse { Success = false, Message = $"Excepción: {ex.Message}" });
            }
        }

        public async Task<ApiResponse> PreparaConsumoAPIAsync(string pathFile, string nameFile, string endPoint)
        {
            App.logs.add($"----------- Inicia lectura de la API -------");
            string rutaCompleta = Path.Combine(pathFile, $"{nameFile}.json");
            if (!File.Exists(rutaCompleta))
            {
                App.logs.add($"Error el archivo CLI.json NO EXISTE");
                return null;
            }
            try
            {
                string contenidoJson = File.ReadAllText(rutaCompleta);
                JsonOutput datos = JsonConvert.DeserializeObject<JsonOutput>(contenidoJson);
                if (datos == null)
                {
                    App.logs.add($"Error de lectrua en JSON");
                    return null;
                }
                var (isSuccess, apiResponse) = await PostCreateDocumentoAPI(datos, endPoint);
                return apiResponse;
            }
            catch (Exception ex)
            {
                App.logs.add($"Error de lectrua en JSON : {ex.Message}");
                return null; // Retorna null si hay algún error
            }
        }
    }
}
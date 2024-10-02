using Newtonsoft.Json;
using PolizasService.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaXMLPremium.ResourceFile
{
    public class Helpers
    {
        public void createFile(string xmlDir)
        {
            string procesadoPath = Path.Combine(xmlDir, "Procesado");
            string erroresPath = Path.Combine(xmlDir, "Errores");

            if (!Directory.Exists(procesadoPath))
            {
                Directory.CreateDirectory(procesadoPath);
            }

            if (!Directory.Exists(erroresPath))
            {
                Directory.CreateDirectory(erroresPath);
            }
        }

        public string RemoveDashes(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Replace("-", "");
        }

        public int readDirXML(string xmlDir)
        {
            if (Directory.Exists(xmlDir))
            {
                string[] xmlFiles = Directory.GetFiles(xmlDir, "*.xml");
                if (xmlFiles.Length > 0)
                {
                    int totalXML = xmlFiles.Length;
                    return totalXML;
                }
            }
            return 0;
        }

        public void deleteFile(string filePath, string nameFile)
        {
            // Combina la ruta del archivo con el nombre del archivo
            string fullPath = Path.Combine(filePath, nameFile);

            if (File.Exists(fullPath))
            {
                try
                {
                    File.Delete(fullPath);
                    Console.WriteLine($"Archivo eliminado: {fullPath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al eliminar el archivo: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"El archivo no existe: {fullPath}");
            }
        }

        public void FileMoved(ApiResponse jsonFilePath, string path)
        {
            if (jsonFilePath.Success && jsonFilePath.Data != null)
            {
                foreach (var doc in jsonFilePath.Data)
                {
                    var fileName = doc.FileName;
                    var filePath = Path.GetDirectoryName(fileName);
                    var processedFolder = Path.Combine(filePath, "procesado");
                    if (!Directory.Exists(processedFolder))
                    {
                        Directory.CreateDirectory(processedFolder);
                    }
                    var newFilePath = Path.Combine(processedFolder, Path.GetFileName(fileName));
                    try
                    {
                        File.Move(fileName, newFilePath);
                        Console.WriteLine($"Archivo movido a: {newFilePath}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al mover el archivo {fileName}: {ex.Message}");
                    }
                }
                MoveRemainingFilesToErrorFolder(path);
            }
            else
            {
                Console.WriteLine("No se pudieron procesar los documentos.");
            }
        }

        private void MoveRemainingFilesToErrorFolder(string pathXML)
        {
            var errorFolder = Path.Combine(pathXML, "Errores"); // Cambia la ruta según tu estructura de directorios
            var xmlFiles = Directory.GetFiles(pathXML, "*.xml");

            foreach (var fileName in xmlFiles)
            {
                try
                {
                    var errorFilePath = Path.Combine(errorFolder, Path.GetFileName(fileName));
                    File.Move(fileName, errorFilePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al mover el archivo {fileName} a errores: {ex.Message}");
                }
            }
        }

    }
}

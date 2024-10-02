using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolizasService.DTO
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Type { get; set; }
        public object Origen { get; set; }
        public List<JsonCLIDocumentos> Data { get; set; }
    }
}

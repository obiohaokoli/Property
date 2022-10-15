using System.Diagnostics;
using System.Net;

namespace Obioha_VillaAPI.Models
{
    public class APIResponse
    {
        public Object Result { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessages { get; set; }
    }
}

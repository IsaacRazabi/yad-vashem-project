using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace WebApplicationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetJsonController : ControllerBase
    {
        private static JArray JsonArray;

        private readonly ILogger<GetJsonController> _logger;

        public GetJsonController(ILogger<GetJsonController> logger)
        {
            JsonArray = LoadJson();
            _logger = logger;
        }

        [HttpGet(Name = "GetJson")]
        public String Get()
        {
            var res = JsonConvert.SerializeObject(JsonArray, Formatting.Indented);
            return res;
        }

        [HttpGet]
        [Route("GetJsonBook")]
        public String GetBook()
        {
            var res = JsonArray[0]["language"].ToString();
            //var res = JsonConvert.SerializeObject(JsonArray, Formatting.Indented);
            return res;
        }

        public static JArray LoadJson()
        {
            try
            {
                var Json = @".\jsonStaticFile\מוסדות.json";
                using (StreamReader file = System.IO.File.OpenText(Json))
                {
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        JsonArray = (JArray)JToken.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return JsonArray;
        }

    }
}
using Newtonsoft.Json;

namespace Microsoft.Azure.Management.CognitiveServices.Models
{
    public class CognitiveServicesAccountApiProperties: ApiProperties
    {
        public static CognitiveServicesAccountApiProperties Parse(ApiProperties obj)
        {
            return JsonConvert.DeserializeObject<CognitiveServicesAccountApiProperties>(JsonConvert.SerializeObject(obj));
        }
    }
}

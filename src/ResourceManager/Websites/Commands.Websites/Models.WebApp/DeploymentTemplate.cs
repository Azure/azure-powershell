using Microsoft.Azure.Management.WebSites.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.Commands.WebApps.Models.WebApp
{
    internal class DeploymentTemplate
    {
        [JsonProperty("$schema")]
        public string Schema { get; set; }

        public string ContentVersion { get; set; }

        public Dictionary<string, ParameterType> Parameters { get; set; }

        public Dictionary<string, object> Variables { get; set; }

        public WebAppResource[] Resources { get; set; }

    }

    internal class ParameterType
    {
        public string Type { get; set; }

        public string AllowedValues { get; set; }
    }

    internal class WebAppResource
    {
        public string Name { get; set; }

        public string ApiVersion { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }

        public string[] DependsOn { get; set; }

        public CopyFunction Copy { get; set; }

        public WebAppProperties Properties { get; set; }
    }

    internal class CopyFunction
    {
        public string Name { get; set; }

        public string Count { get; set; }
    }

    internal class WebAppProperties
    {
        public string ServerFarmId { get; set; }

        public CloningInfo CloningInfo { get; set; }

        public HostingEnvironmentProfile HostingEnvironmentProfile { get; set; }
    }


    internal static class DeploymentTemplateHelper
    {
        private const string WebAppSlotName = "[concat(variables('webAppName'), '/', variables('slotNames')[copyIndex()])]";
        private const string SourceWebAppSlotId = "[concat(variables('sourceWebAppId'), '/slots/', variables('slotNames')[copyIndex()])]";
        private const string WebAppSlotResourceType = "Microsoft.Web/sites/slots";
        private const string WebAppSlotCount = "[length(variables('slotNames'))]";
        private const string ContentVersion = "1.0.0.0";

        internal static string ToJsonString(this DeploymentTemplate template)
        {
            var serializationSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var serializer = JsonSerializer.Create(serializationSettings);
            var textWriter = new StringWriter();
            serializer.Serialize(textWriter, template);
            return textWriter.ToString();
        }

        internal static string CreateSlotCloneDeploymentTemplate(string location, string serverFarmId, string destinationWebAppName, string sourceWebAppId, string[] slotNames, HostingEnvironmentProfile hostingProfile, string apiVersion)
        {
            var template = new DeploymentTemplate
            {
                ContentVersion = ContentVersion,
                Schema = "http://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#",
                Variables = new Dictionary<string, object>
                {
                    { "slotNames", slotNames },
                    { "webAppName", destinationWebAppName },
                    { "sourceWebAppId", sourceWebAppId }
                },
                Resources = new WebAppResource[]
                {
                   new WebAppResource
                   {
                       Type = WebAppSlotResourceType,
                       ApiVersion = apiVersion,
                       Location = location,
                       Name = WebAppSlotName,
                       Properties = new WebAppProperties
                       {
                           CloningInfo = new CloningInfo
                           {
                               SourceWebAppId = SourceWebAppSlotId
                           },
                           ServerFarmId = serverFarmId,
                           HostingEnvironmentProfile = hostingProfile
                       },
                       Copy = new CopyFunction
                       {
                           Name = "SlotCopy",
                           Count = WebAppSlotCount
                       }
                   }
                }
            };

            return template.ToJsonString();
        }
    }
}

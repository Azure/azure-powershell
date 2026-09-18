using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Get Cognitive Services Model
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CognitiveServicesModelCapacity", DefaultParameterSetName = DefaultParameterSet), OutputType(typeof(ModelSkuCapacityProperties))]
    public class GetAzureCognitiveServicesModelCapacityCommond : CognitiveServicesAccountBaseCmdlet
    {
        protected const string DefaultParameterSet = "DefaultParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Model Format.")]
        public string Format { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Model Name.")]
        public string Name { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Model Version.")]
        public string Version { get; set; }

        [Parameter(
            Position = 1,
            ParameterSetName = DefaultParameterSet,
            Mandatory = false,
            HelpMessage = "Cognitive Services Account Location.")]
        [LocationCompleter("Microsoft.CognitiveServices/accounts")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            RunCmdLet(() =>
            {
                if (string.IsNullOrEmpty(this.Location))
                {
                    var getResponse = ListAll(CognitiveServicesClient.ModelCapacities.List, Format, Name, Version, CognitiveServicesClient.ModelCapacities.ListNext);
                    WriteObject(getResponse);
                }
                else
                {
                    var getResponse = ListAll(CognitiveServicesClient.LocationBasedModelCapacities.List, Location, Format, Name, Version, CognitiveServicesClient.LocationBasedModelCapacities.ListNext);
                    WriteObject(getResponse);
                }
            });
        }
    }
}

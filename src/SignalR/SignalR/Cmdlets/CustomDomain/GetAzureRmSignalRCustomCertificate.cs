using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Commands.SignalR.Properties;
using Microsoft.Azure.Management.SignalR;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SignalR" + "CustomCertificate", DefaultParameterSetName = ResourceGroupParameterSet)]
    [OutputType(typeof(PSCustomCertificateResource))]
    public class GetAzureRmSignalRCustomCertificate : SignalRCmdletBase, ISignalRChildResource
    {
        [Parameter(
            Mandatory = false,
            ParameterSetName = ResourceGroupParameterSet,
            HelpMessage = "The resource group name. The default one will be used if not specified.")]
        [ValidateNotNullOrEmpty()]
        [ResourceGroupCompleter]
        public override string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ResourceGroupParameterSet,
            HelpMessage = "The SignalR service name.")]
        [ValidateNotNullOrEmpty()]
        [ResourceNameCompleter(Constants.SignalRResourceType, nameof(ResourceGroupName))]
        public string SignalRName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ResourceGroupParameterSet, HelpMessage = "The name of the custom certificate")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "The name of the custom certificate")]
        [Parameter(Mandatory = false, ParameterSetName = SignalRObjectParameterSet, HelpMessage = "The name of the custom certificate")]
        [ValidateNotNullOrEmpty()]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "The resource ID of a custom certificate", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty()]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SignalRObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The SignalR resource object.")]
        [ValidateNotNull]
        public PSSignalRResource SignalRObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run the cmdlet in background job.")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            RunCmdlet(() =>
            {
                switch (ParameterSetName)
                {
                    case ResourceGroupParameterSet:
                        ResolveResourceGroupName();
                        break;
                    case SignalRObjectParameterSet:
                        this.LoadFromSignalRResourceId(SignalRObject.Id);
                        break;
                    case ResourceIdParameterSet:
                        this.LoadFromChildResourceId(ResourceId, Constants.SignalRCustomCertificateResourceType);
                        break;
                    default:
                        throw new ArgumentException(Resources.ParameterSetError);
                }
                if (Name == null)
                {
                    var result = SignalRCustomCertificatesOperationsExtensions.List(Client.SignalRCustomCertificates, ResourceGroupName, SignalRName);
                    WriteObject(result.Select(c => new PSCustomCertificateResource(c)), true);
                }
                else
                {
                    var result = SignalRCustomCertificatesOperationsExtensions.Get(Client.SignalRCustomCertificates, ResourceGroupName, SignalRName, Name);
                    WriteObject(new PSCustomCertificateResource(result));
                }
            });
        }
    }
}
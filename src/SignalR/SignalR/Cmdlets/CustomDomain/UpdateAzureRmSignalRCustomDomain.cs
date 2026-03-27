using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Commands.SignalR.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.SignalR.Models;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SignalRCustomDomain", SupportsShouldProcess = true, DefaultParameterSetName = ResourceGroupParameterSet)]
    [OutputType(typeof(PSCustomDomainResource))]
    public class UpdateAzureRmSignalRCustomDomain : SignalRCmdletBase, ISignalRChildResource
    {
        [Parameter(Mandatory = false, ParameterSetName = ResourceGroupParameterSet, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceGroupParameterSet, HelpMessage = "The SignalR service name.")]
        [ResourceNameCompleter(Constants.SignalRResourceType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        public string SignalRName { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ResourceGroupParameterSet, HelpMessage = "The custom domain resource name.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = SignalRObjectParameterSet, HelpMessage = "The custom domain resource name.")]
        [ValidateNotNullOrEmpty()]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = InputObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The SignalR custom domain resource object.")]
        [ValidateNotNull]
        public PSCustomDomainResource InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SignalRObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The SignalR resource object.")]
        [ValidateNotNull]
        public PSSignalRResource SignalRResourceObject { get; set; }

        [Parameter(HelpMessage = "The custom domain name.")]
        public string DomainName { get; set; }

        [Parameter(HelpMessage = "The custom certificate resource ID.")]
        public string CustomCertificateId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run the cmdlet in background job.")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "The resource ID of the custom domain.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty()]
        public string ResourceId { get; set; }

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
                    case ResourceIdParameterSet:
                        this.LoadFromChildResourceId(ResourceId, Constants.SignalRCustomDomainResourceType);
                        break;
                    case SignalRObjectParameterSet:
                        var signalRResourceId = new ResourceIdentifier(SignalRResourceObject.Id);
                        ResourceGroupName = signalRResourceId.ResourceGroupName;
                        SignalRName = signalRResourceId.ResourceName;
                        break;
                    case InputObjectParameterSet:
                        this.LoadFromChildResourceId(InputObject.Id, Constants.SignalRCustomDomainResourceType);
                        break;
                    default:
                        throw new ArgumentException(Resources.ParameterSetError);
                }
                var existing = Microsoft.Azure.Management.SignalR.SignalRCustomDomainsOperationsExtensions.Get(Client.SignalRCustomDomains, ResourceGroupName, SignalRName, Name) ?? throw new AzPSInvalidOperationException($"SignalR custom domain {ResourceGroupName}/{SignalRName}/{Name}" + " doesn't exist.");
                if (ShouldProcess($"SignalR custom domain {ResourceGroupName}/{SignalRName}/{Name}", "update"))
                {
                    var domain = new CustomDomain(
                        DomainName ?? existing.DomainName,
                        string.IsNullOrEmpty(CustomCertificateId) ? existing.CustomCertificate : new ResourceReference(CustomCertificateId));
                    var result = Microsoft.Azure.Management.SignalR.SignalRCustomDomainsOperationsExtensions.CreateOrUpdate(Client.SignalRCustomDomains, ResourceGroupName, SignalRName, Name, domain);
                    WriteObject(new PSCustomDomainResource(result));
                }
            });
        }
    }
}
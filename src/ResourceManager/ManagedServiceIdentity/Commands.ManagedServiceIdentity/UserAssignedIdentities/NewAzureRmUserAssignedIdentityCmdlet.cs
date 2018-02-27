using System.Collections;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ManagedServiceIdentity.Common;
using Microsoft.Azure.Commands.ManagedServiceIdentity.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Identity = Microsoft.Azure.Management.ManagedServiceIdentity.Models.Identity;

namespace Microsoft.Azure.Commands.ManagedServiceIdentity.UserAssignedIdentities
{
    [Cmdlet(VerbsCommon.New, "AzureRmUserAssignedIdentity", SupportsShouldProcess = true)]
    [OutputType(typeof (PsUserAssignedIdentity))]
    public class NewAzureRmUserAssignedIdentityCmdlet : MsiBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            HelpMessage = "The resource group name.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            HelpMessage = "The Identity name.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Azure region name where the Identity should be created.",
            ValueFromPipelineByPropertyName = true)]
        [LocationCompleter()]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Azure Resource Manager tags associated with the identity.",
            ValueFromPipelineByPropertyName = true)] public Hashtable Tag;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.ShouldProcess(Name,
                string.Format(CultureInfo.CurrentCulture,
                    Properties.Resources.NewUserAssignedIdentity_ProcessMessage,
                    this.ResourceGroupName,
                    this.Name)))
            {
                var tagsDictionary = this.Tag?.Cast<DictionaryEntry>()
                    .ToDictionary(ht => (string) ht.Key, ht => (string) ht.Value);
                var location = GetLocation();
                Identity identityProperties = new Identity(location: location, tags: tagsDictionary);
                var result =
                    this.MsiClient.UserAssignedIdentities
                        .CreateOrUpdateWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.Name,
                            identityProperties).GetAwaiter().GetResult();

                WriteIdentity(result.Body);
            }
        }

        private string GetLocation()
        {
            return this.Location ?? GetResourceGroupLocation(this.ResourceGroupName);
        }

        private string GetResourceGroupLocation(string resourceGroupName)
        {
            ResourceGroup rg = ArmClient.ResourceGroups.Get(resourceGroupName);
            return rg?.Location;
        }
    }
}

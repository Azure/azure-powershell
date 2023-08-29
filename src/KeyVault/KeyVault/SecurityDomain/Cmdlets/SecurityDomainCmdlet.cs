using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;
using System.Threading;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Cmdlets
{
    [SupportsSubscriptionId]
    public abstract class SecurityDomainCmdlet : SecurityDomainCmdletClient
    {
        protected const string ByName = "ByName";
        protected const string ByInputObject = "ByInputObject";
        protected const string ByResourceId = "ByResourceID";

        [Parameter(HelpMessage = "Name of the managed HSM.", Mandatory = true, ParameterSetName = ByName)]
        [Alias("HsmName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(HelpMessage = "Object representing a managed HSM.", Mandatory = true, ParameterSetName = ByInputObject, ValueFromPipeline = true)]
        [ValidateNotNull]
        public PSKeyVaultIdentityItem InputObject { get; set; }

        /// <summary>
        /// Sub-classes should not override this method, but <see cref="SecurityDomainCmdletClient.DoExecuteCmdlet"/> instead.
        /// This is call-super pattern. See https://www.martinfowler.com/bliki/CallSuper.html
        /// </summary>
        public override void ExecuteCmdlet()
        {
            PreprocessParameterSets();
            DoExecuteCmdlet();
        }
        /// <summary>
        /// Unifies different parameter sets. Sub-classes need only to care about Name.
        /// </summary>
        private void PreprocessParameterSets()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                Name = InputObject.VaultName;
            }
        }
    }
}

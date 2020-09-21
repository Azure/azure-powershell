using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Cmdlets
{
    public class SecurityDomainCmdlet: AzureRMCmdlet
    {
        protected const string ByName = "By Name";
        protected const string ByInputObject = "By InputObject";
        protected const string ByResourceId = "By Resource ID";

        [Parameter(HelpMessage = "Name of the managed HSM.", Mandatory = true, ParameterSetName = ByName)]
        [Alias("HsmName")]
        public string Name { get; set; }

        [Parameter(HelpMessage = "Object representing a managed HSM.", Mandatory = true, ParameterSetName = ByInputObject, ValueFromPipeline = true)]
        public PSKeyVaultIdentityItem InputObject { get; set; }

        internal ISecurityDomainClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new SecurityDomainClient(AzureSession.Instance.AuthenticationFactory, DefaultContext);
                }
                return _client;
            }
            set => _client = value;
        }


        private ISecurityDomainClient _client;

        /// <summary>
        /// Sealed for common logic of parameter set handling. Please override <see cref="ExecuteCmdletCore"/> instead.
        /// </summary>
        public sealed override void ExecuteCmdlet()
        {
            PreprocessParameterSets();
            ExecuteCmdletCore();
        }

        private void PreprocessParameterSets()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                Name = InputObject.VaultName;
            }
        }

        public virtual void ExecuteCmdletCore() { }
    }
}

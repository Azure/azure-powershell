using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;


namespace Microsoft.Azure.Commands.WebApps.Models
{
    public abstract class WebAppBaseClientCmdLet : AzureRMCmdlet
    {
        private ResourceClient _resourcesClient;
        public ResourceClient ResourcesClient
        {
            get
            {
                if (_resourcesClient == null)
                {
                    _resourcesClient = new ResourceClient(DefaultProfile.DefaultContext);
                }

                this._resourcesClient.VerboseLogger = WriteVerboseWithTimestamp;
                this._resourcesClient.ErrorLogger = WriteErrorWithTimestamp;
                this._resourcesClient.WarningLogger = WriteWarningWithTimestamp;
                return _resourcesClient;
            }
            set { _resourcesClient = value; }
        }

        private WebsitesClient _websitesClient;
        public WebsitesClient WebsitesClient
        {
            get
            {
                if (_websitesClient == null)
                {
                    _websitesClient = new WebsitesClient(DefaultProfile.DefaultContext)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp,
                        WarningLogger = WriteWarningWithTimestamp
                    };
                }
                return _websitesClient;
            }
            set { _websitesClient = value; }
        }

        private KeyVaultClient _keyVaultClient { get; set; }
        public KeyVaultClient KeyvaultClient
        {
            get
            {
                if (_keyVaultClient == null)
                {
                    _keyVaultClient = new KeyVaultClient(DefaultProfile.DefaultContext)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp,
                        WarningLogger = WriteWarningWithTimestamp
                    };
                }
                return _keyVaultClient;
            }
            set { _keyVaultClient = value; }
        }

        private ActiveDirectoryClient _activeDirectoryClient;
        public ActiveDirectoryClient ActiveDirectoryClient
        {
            get
            {
                if (_activeDirectoryClient != null) return _activeDirectoryClient;
#if NETSTANDARD
                try
                {
                    _activeDirectoryClient = new ActiveDirectoryClient(DefaultProfile.DefaultContext);
                }
                catch
                {
                    _activeDirectoryClient = null;
                }
#else
                _activeDirectoryClient = new ActiveDirectoryClient(new Uri(string.Format("{0}/{1}",
                DefaultProfile.DefaultContext.Environment.GetEndpoint(AzureEnvironment.Endpoint.Graph), _dataServiceCredential.TenantId)),
                () => Task.FromResult(_dataServiceCredential.GetToken()));
#endif
                return _activeDirectoryClient;
            }

            set { _activeDirectoryClient = value; }
        }
    }
}

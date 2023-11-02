using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System.Threading;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Cmdlets
{
    [SupportsSubscriptionId]
    public abstract class SecurityDomainCmdlet : AzureRMCmdlet
    {
        private readonly CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();
        protected CancellationToken CancellationToken => CancellationTokenSource.Token;
        internal ISecurityDomainClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new SecurityDomainClient(AzureSession.Instance.AuthenticationFactory, DefaultContext, s => WriteDebug(s));
                }
                return _client;
            }
            set => _client = value;
        }


        private ISecurityDomainClient _client;

        /// <summary>
        /// Sub-classes should not override this method, but <see cref="DoExecuteCmdlet"/> instead.
        /// This is call-super pattern. See https://www.martinfowler.com/bliki/CallSuper.html
        /// </summary>
        public override void ExecuteCmdlet()
        {
            DoExecuteCmdlet();
        }

        public abstract void DoExecuteCmdlet();

        protected override void StopProcessing()
        {
            CancellationTokenSource.Cancel();
            base.StopProcessing();
        }
    }
}

using System;
using System.Linq;
using Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.Library;
using Microsoft.WindowsAzure.Commands.StorSimple.Encryption;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.StorSimple.Exceptions;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// this commandlet will set a particular resource to the current context
    /// </summary>
    [Cmdlet(VerbsCommon.Select, "AzureStorSimpleResource"),OutputType(typeof(StorSimpleResourceContext))]
    public class SelectAzureStorSimpleResource : StorSimpleCmdletBase
    {
        private string resourceName;
        /// <summary>
        /// Name of the resource that needs to be selected
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceName
        {
            get { return this.resourceName; }
            set { this.resourceName = value; }
        }

        private string registrationKey;

        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string RegistrationKey
        {
            get { return this.registrationKey; }
            set { this.registrationKey = value; }
        }

        protected override void BeginProcessing()
        {
            //we dont have to verify that resource is selected
            return;
        }

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                this.WriteVerbose(Resources.ResourceContextInitializeMessage);
                var resCred = StorSimpleClient.GetResourceDetails(resourceName);
                if (resCred == null)
                {
                    this.WriteVerbose(Resources.NotFoundMessageResource);
                    throw new StorSimpleResourceNotFoundException();
                }
                
                StorSimpleClient.SetResourceContext(resCred);
                var deviceInfos = StorSimpleClient.GetAllDevices();
                if (!deviceInfos.Any())
                {
                    StorSimpleClient.ResetResourceContext();
                    throw new NoDeviceRegisteredException();
                }

                //now check for the key
                if (string.IsNullOrEmpty(RegistrationKey))
                {
                    this.WriteVerbose(Resources.RegistrationKeyNotPassedMessage);
                }
                else
                {
                    this.WriteVerbose(Resources.RegistrationKeyPassedMessage);
                    EncryptionCmdLetHelper.PersistCIK(this, resCred.ResourceId, StorSimpleClient.ParseCIKFromRegistrationKey(RegistrationKey));
                }
                EncryptionCmdLetHelper.ValidatePersistedCIK(this, resCred.ResourceId);
                this.WriteVerbose(Resources.SecretsValidationCompleteMessage);

                this.WriteVerbose(Resources.SuccessMessageSetResourceContext);
                var currentContext = StorSimpleClient.GetResourceContext();
                this.WriteObject(currentContext);
            }
            catch(Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}

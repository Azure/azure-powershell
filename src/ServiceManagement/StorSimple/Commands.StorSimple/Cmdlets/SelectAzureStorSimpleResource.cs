using System;
using System.Linq;
using Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.Library;
using Microsoft.WindowsAzure.Commands.StorSimple.Encryption;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
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
                    return;
                }
                
                StorSimpleClient.SetResourceContext(resCred);
                var deviceInfos = StorSimpleClient.GetAllDevices();
                if (!deviceInfos.Any())
                {
                    WriteWarning(Resources.NoDeviceRegisteredMessage);
                    StorSimpleClient.ResetResourceContext();
                    return;
                }
                
                if (string.IsNullOrEmpty(RegistrationKey))
                {
                    this.WriteVerbose(Resources.RegistrationKeyNotPassedMessage);
                }
                else
                {
                    this.WriteVerbose(Resources.RegistrationKeyPassedMessage);
                    EncryptionCmdLetHelper.PersistCIK(this, resCred.ResourceId, ParseCIKFromRegistrationKey());
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

        private string ParseCIKFromRegistrationKey()
        {
            try
            {
                string[] parts = RegistrationKey.Split(new char[] {':'});
                this.WriteVerbose("RegistrationKey #parts:" + parts.Length);
                //this.WriteVerbose("Using part: " + parts[2]);
                return parts[2].Split(new char[] {'#'})[0];
            }
            catch (Exception ex)
            {
                throw new ArgumentException("RegistrationKey is not of the right format", "RegistrationKey", ex);
            }
        }
    }
}

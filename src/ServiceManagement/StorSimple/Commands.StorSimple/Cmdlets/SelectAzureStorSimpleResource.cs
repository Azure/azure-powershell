using System;
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
                this.WriteVerbose("Initializing resource context");
                StorSimpleResourceContext currentContext = null;
                var status = StorSimpleClient.SetResourceContext(resourceName);
                if (status.Equals(Resources.NotFoundMessageResource))
                {
                    this.WriteVerbose(status);
                    return;
                }
                else
                {
                    this.WriteVerbose(status);
                    currentContext = StorSimpleClient.GetResourceContext();
                    this.WriteObject(currentContext);
                }

                if (string.IsNullOrEmpty(RegistrationKey))
                {
                    this.WriteVerbose("Registrtion key not passed - validating that the secrets are already initialized.");
                }
                else
                {
                    this.WriteVerbose("Registration key passed - initializing secrets");
                    EncryptionCmdLetHelper.PersistCIK(this, currentContext.ResourceId, ParseCIKFromRegistrationKey());
                }
                EncryptionCmdLetHelper.ValidatePersistedCIK(this, currentContext.ResourceId);
                this.WriteVerbose("Secrets validation complete");
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

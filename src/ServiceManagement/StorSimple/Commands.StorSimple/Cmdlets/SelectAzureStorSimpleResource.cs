using System;
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
                StorSimpleResourceContext currentContext = null;
                var status = StorSimpleClient.SetResourceContext(resourceName);
                if (status.Equals(Resources.NotFoundMessageResource))
                {
                    throw new StorSimpleResourceNotFoundException();
                }
                else
                {
                    this.WriteVerbose(status);
                    currentContext = StorSimpleClient.GetResourceContext();
                    this.WriteObject(currentContext);
                }

                //now check for the key
                if (string.IsNullOrEmpty(RegistrationKey))
                {
                    this.WriteVerbose(Resources.NotProvidedWarningRegistrationKey);
                }
                else
                {
                    this.WriteVerbose(Resources.ProvidedRegistrationKey);
                    EncryptionCmdLetHelper.PersistCIK(this, currentContext.ResourceId, ParseCIKFromRegistrationKey());
                }
                EncryptionCmdLetHelper.ValidatePersistedCIK(this, currentContext.ResourceId);
                this.WriteVerbose(Resources.ValidationSuccessfulRegistrationKey);
                this.WriteVerbose(Resources.SuccessfulResourceSelection);
            }
            catch(Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// The CIK has to be parsed from the registration key
        /// </summary>
        /// <returns></returns>
        private string ParseCIKFromRegistrationKey()
        {
            try
            {
                string[] parts = RegistrationKey.Split(new char[] {':'});
                this.WriteVerbose("RegistrationKey #parts:" + parts.Length);
                return parts[2].Split(new char[] {'#'})[0];
            }
            catch (Exception ex)
            {
                throw new RegistrationKeyException(Resources.IncorrectFormatInRegistrationKey, ex);
            }
        }
    }
}

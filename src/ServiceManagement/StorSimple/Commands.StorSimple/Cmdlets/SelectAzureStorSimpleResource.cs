using System;
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

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                var status = StorSimpleClient.SetResourceContext(resourceName);
                if (status.Equals(Resources.NotFoundMessageResource))
                {
                    this.WriteVerbose(status);
                }
                else
                {
                    this.WriteVerbose(status);
                    var currentContext = StorSimpleClient.GetResourceContext();
                    this.WriteObject(currentContext);
                }
            }

            catch(Exception exception)
            {
                this.HandleException(exception);
            }
        }         
    }
}

using Microsoft.WindowsAzure.Commands.StorSimple.Exceptions;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using System;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// This commandlet will return the currently selected resource. If no resource is selected will throw a ResourceContextNotFoundException
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleResourceContext"),OutputType(typeof(StorSimpleResourceContext))]
    public class GetAzureStorSimpleResourceContext : StorSimpleCmdletBase
    {
        protected override void BeginProcessing()
        {
            //we expliclity override BeginProcessing() so that it doesnt verify resource selection as part of StorSimpleCmdletBase
            //class's BeginProcessing method
            return;
        }

        public override void ExecuteCmdlet()
        {
            try
            {
                var currentContext = StorSimpleClient.GetResourceContext();
                if(currentContext == null)
                {
                    ResourceContextNotFoundException notFoundEx = new ResourceContextNotFoundException();
                    throw notFoundEx;
                }

                this.WriteObject(currentContext);
                this.WriteVerbose(String.Format(Resources.ResourceContextFound,currentContext.ResourceName, currentContext.ResourceName));
            }

            catch(Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}

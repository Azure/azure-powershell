using System;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleResourceContext"),OutputType(typeof(StorSimpleResourceContext))]
    public class GetAzureStorSimpleResourceContext : StorSimpleCmdletBase
    {
        public override void ExecuteCmdlet()
        {
            try
            {
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

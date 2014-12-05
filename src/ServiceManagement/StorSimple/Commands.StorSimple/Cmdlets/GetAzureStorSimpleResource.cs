using System;
using System.Management.Automation;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleResource"), OutputType(typeof(IEnumerable<ResourceCredentials>))]
    public class GetAzureStorSimpleResource : StorSimpleCmdletBase
    {
        public override void ExecuteCmdlet()
        {
            try
            {
                var serviceList = StorSimpleClient.GetAllResources();
                this.WriteObject(serviceList, true);
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}

using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Reflection;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    public class VNetDeprecated : RdsCmdlet
    {
        protected override void ProcessRecord()
        {
            string message = String.Format("This cmdlet {0} has been deprecated. See x {1}",
                this.GetType().Name, "https://azure.microsoft.com/documentation/articles/remoteapp-migratevnet/");
            throw new RemoteAppServiceException(message, ErrorCategory.InvalidOperation);
        }
    }
}

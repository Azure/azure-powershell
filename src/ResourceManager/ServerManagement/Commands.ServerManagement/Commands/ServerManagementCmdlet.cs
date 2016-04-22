using System;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.ServerManagement;

namespace Microsoft.Azure.Commands.ServerManagement.Commands
{
    public class ServerManagementCmdlet : AzureRMCmdlet
    {

        private ServerManagementClient _client;

        internal ServerManagementClient Client
        {
            get
            {
               return _client ??
                (_client = AzureSession.ClientFactory.CreateArmClient<ServerManagementClient>(this.DefaultContext,
                    AzureEnvironment.Endpoint.ResourceManager));
            }
            set { _client = value; }
        }

        protected string ToPlainText( SecureString secureString)
        {
            if (secureString == null)
            {
                throw new ArgumentNullException(nameof(secureString));
            }

            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }
    }

   
}

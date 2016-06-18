// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// Helper cmdlet to construct instance of Storage settings class
    /// </summary>
    [Cmdlet(
         VerbsCommon.New,
        AzureRmVMSqlServerConnectivityConfigNoun),
     OutputType(
         typeof(ConnectivitySettings))]
    public class NewAzureRmVMSqlServerConnectivityConfig : PSCmdlet
    {
        protected const string AzureRmVMSqlServerConnectivityConfigNoun = "AzureRmVMSqlServerConnectivityConfig";

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The connectivity type which can be local, public or private.")]
        [ValidateNotNullOrEmpty]
        [ValidateSetAttribute(new string[] { "Local", "Public", "Private" })]
        public string Type { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 1,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The port number for connectivity.")]
        [ValidateRange(1024, 65535)]
        [ValidateNotNullOrEmpty]
        public int Port { get; set; }

        [Parameter(
           Mandatory = false,
           Position = 2,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "SQL authentication login username.")]
        [ValidateNotNullOrEmpty]
        public string SqlAuthenticationUsername { get; set; }

        [Parameter(
           Mandatory = false,
           Position = 3,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "SQL authentication login password.")]
        [ValidateNotNullOrEmpty]
        public SecureString SqlAuthenticationPassword { get; set; }

        /// <summary>
        /// Creates and returns <see cref="ConnectivitySettings"/> object.
        /// </summary>
        protected override void ProcessRecord()
        {
            ConnectivitySettings connectivitySettings = new ConnectivitySettings();
            connectivitySettings.Type = Type;
            connectivitySettings.Port = Port;
            connectivitySettings.SqlAuthenticationUsername = SqlAuthenticationUsername;
            if (SqlAuthenticationUsername == null && SqlAuthenticationPassword != null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "no username exists with this password"));
            }
            else
            {
                connectivitySettings.SqlAuthenticationPassword = SqlAuthenticationPassword;
            }
            WriteObject(connectivitySettings);
        }

        /// <summary>
        /// convert secure string to regular string
        /// $Issue -  for ARM cmdlets, check if there is a similair helper class library like Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers
        /// </summary>
        /// <param name="securePassword"></param>
        /// <returns></returns>
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private static string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
            {
                throw new ArgumentNullException("securePassword");
            }

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}

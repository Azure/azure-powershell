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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Management.StorSimple.Models;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// Create Storage Account Credential to be added inline during Volume Container creation
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureStorSimpleInlineStorageAccountCredential"),
     OutputType(typeof (StorageAccountCredentialResponse))]

    public class NewAzureStorSimpleInlineStorageAccountCredential : StorSimpleCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.StorageAccountName)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Alias("Key")]
        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.StorageAccountKey)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountKey { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.Endpoint)]
        [ValidateNotNullOrEmpty]
        public string Endpoint { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                string endpoint = string.IsNullOrEmpty(Endpoint) ? StorSimpleConstants.DefaultStorageAccountEndpoint : Endpoint;

                var sac = new StorageAccountCredentialResponse()
                {
                    CloudType = CloudType.Azure,
                    Hostname = GetHostnameFromEndpoint(endpoint),
                    Login = StorageAccountName,
                    Password = StorageAccountKey,
                    UseSSL = true,
                    Name = StorageAccountName
                };

                WriteObject(sac);
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}


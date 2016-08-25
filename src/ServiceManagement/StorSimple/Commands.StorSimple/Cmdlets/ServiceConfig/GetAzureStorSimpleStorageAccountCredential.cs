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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System.Linq;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// Get a list of Storage accounts from the StorSimple Service config or retrieves a specified Storage Account Cred
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleStorageAccountCredential"), OutputType(typeof(StorageAccountCredential), typeof(IList<StorageAccountCredential>))]
    public class GetAzureStorSimpleStorageAccountCredential : StorSimpleCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.StorageAccountName)]
        public string StorageAccountName { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                var allSACs = StorSimpleClient.GetAllStorageAccountCredentials();
                if (StorageAccountName == null)
                {
                    WriteObject(allSACs, true);
                    WriteVerbose(string.Format(Resources.SACGet_StatusMessage, allSACs.Count, allSACs.Count > 1 ? "s" : string.Empty));
                    return;
                }
                
                var sac = allSACs.Where(x => x.Name.Equals(StorageAccountName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                if (sac == null)
                {
                    throw new ArgumentException(string.Format(Resources.SACNotFoundWithName, StorageAccountName));
                }
                else
                {
                    WriteVerbose(string.Format(Resources.SACFoundWithName, StorageAccountName));
                    WriteObject(sac);
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}

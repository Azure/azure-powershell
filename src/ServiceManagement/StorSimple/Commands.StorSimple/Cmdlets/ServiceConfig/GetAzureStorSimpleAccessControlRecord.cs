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
    /// Get a list of Access Control Records present in the StorSimple Manager Service Configuration or retrieves a specific named ACR Object
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleAccessControlRecord"), OutputType(typeof(AccessControlRecord), typeof(IList<AccessControlRecord>))]
    public class GetAzureStorSimpleAccessControlRecord : StorSimpleCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.ACRName)]
        public string ACRName { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                var allACRs = StorSimpleClient.GetAllAccessControlRecords();
                if (ACRName == null)
                {
                    WriteObject(allACRs);
                    WriteVerbose(string.Format(Resources.ACRGet_StatusMessage, allACRs.Count, allACRs.Count > 1 ? "s" : string.Empty));
                    return;
                }
                
                var acr = allACRs.Where(x => x.Name.Equals(ACRName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                if (acr == null)
                {
                    throw new ArgumentException(string.Format(Resources.NotFoundMessageACR, ACRName));
                }
                else
                {
                    WriteObject(acr);
                    WriteVerbose(string.Format(Resources.FoundMessageACR, ACRName));
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}
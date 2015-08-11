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

using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureRemoteAppLocation"), OutputType(typeof(Region))]
    public class GetAzureRemoteAppLocation : RdsCmdlet
    {
        public override void ExecuteCmdlet()
        {
            RegionListResult response = null;

            response = CallClient(() => Client.Collections.RegionList(), Client.Collections);

            if (response != null && response.Regions.Count > 0)
            {
                WriteObject(response.Regions, true);
            }
            else
            {
                WriteVerboseWithTimestamp("No locations found.");
            }
        }
    }
}

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
using Microsoft.WindowsAzure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.New, "AzureIPTag"), OutputType(typeof(IPTag))]
    public class NewAzureIPTagCommand : Cmdlet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "IP Tag Type of desired IP address")]
        [ValidateSet(Management.Network.Models.IPTagType.IPAddressClassification, Management.Network.Models.IPTagType.FirstPartyUsage, Management.Network.Models.IPTagType.AvailabilityZone, IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string IPTagType
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Value of the IPTag")]
        [ValidateNotNullOrEmpty]
        public string Value
        {
            get;
            set;
        }

        public void ExecuteCommand()
        {
            if (string.Equals(Management.Network.Models.IPTagType.IPAddressClassification, IPTagType, StringComparison.OrdinalIgnoreCase))
            {
                WriteObject(new IPTag { IPTagType = Management.Network.Models.IPTagType.IPAddressClassification, Value = Value }, true);
            }
            else if (string.Equals(Management.Network.Models.IPTagType.FirstPartyUsage, IPTagType, StringComparison.OrdinalIgnoreCase))
            {
                WriteObject(new IPTag { IPTagType = Management.Network.Models.IPTagType.FirstPartyUsage, Value = Value }, true);
            }
            else if (string.Equals(Management.Network.Models.IPTagType.AvailabilityZone, IPTagType, StringComparison.OrdinalIgnoreCase))
            {
                WriteObject(new IPTag { IPTagType = Management.Network.Models.IPTagType.AvailabilityZone, Value = Value }, true);
            }
            else
            {
                throw new Exception(IPTagType + Resources.InvalidIPTagTypeException);
            }
        }

        protected override void ProcessRecord()
        {
            try
            {
                base.ProcessRecord();
                ExecuteCommand();
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, string.Empty, ErrorCategory.CloseError, null));
            }
        }
    }
}

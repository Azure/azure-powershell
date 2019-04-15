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

namespace Microsoft.Azure.Commands.PrivateDns.Records
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.PrivateDns.Models;
    using Microsoft.Azure.Management.PrivateDns.Models;
    using Microsoft.Azure.Commands.PrivateDns.Utilities;
    using ProjectResources = Microsoft.Azure.Commands.PrivateDns.Properties.Resources;

    /// <summary>
    /// Adds a record to a record set object.
    /// </summary>
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateDnsRecordConfig", DefaultParameterSetName = PrivateDnsUtils.ARecord), OutputType(typeof(PSPrivateDnsRecordSet))]
    public class AddAzurePrivateDnsRecordConfig : PrivateDnsBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The record set in which to add the record.")]
        [ValidateNotNullOrEmpty]
        public PSPrivateDnsRecordSet RecordSet { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The IPv4 address for the A record to add.", ParameterSetName = PrivateDnsUtils.ARecord)]
        [ValidateNotNullOrEmpty]
        public string Ipv4Address { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The IPv6 address for the AAAA record to add.", ParameterSetName = PrivateDnsUtils.AaaaRecord)]
        [ValidateNotNullOrEmpty]
        public string Ipv6Address { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The mail exchange host for the MX record to add. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = PrivateDnsUtils.MxRecord)]
        [ValidateNotNullOrEmpty]
        public string Exchange { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The preference value for the MX record to add.", ParameterSetName = PrivateDnsUtils.MxRecord)]
        [ValidateNotNullOrEmpty]
        public ushort Preference { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The target host for the PTR record to add. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = PrivateDnsUtils.PtrRecord)]
        [ValidateNotNullOrEmpty]
        public string Ptrdname { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The text value for the TXT record to add.", ParameterSetName = PrivateDnsUtils.TxtRecord)]
        [ValidateNotNullOrEmpty]
        [ValidateLength(PrivateDnsClient.TxtRecordMinLength, PrivateDnsClient.TxtRecordMaxLength)]
        public string Value { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The priority value SRV record to add.", ParameterSetName = PrivateDnsUtils.SrvRecord)]
        [ValidateNotNullOrEmpty]
        public ushort Priority { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The target host for the SRV record to add. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = PrivateDnsUtils.SrvRecord)]
        [ValidateNotNullOrEmpty]
        public string Target { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The port number for the SRV record to add.", ParameterSetName = PrivateDnsUtils.SrvRecord)]
        [ValidateNotNullOrEmpty]
        public ushort Port { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The weight value for the SRV record to add.", ParameterSetName = PrivateDnsUtils.SrvRecord)]
        [ValidateNotNullOrEmpty]
        public ushort Weight { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The canonical name for the CNAME record to add. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = PrivateDnsUtils.CnameRecord)]
        [ValidateNotNullOrEmpty]
        public string Cname { get; set; }

        public override void ExecuteCmdlet()
        {
            var result = this.RecordSet;
            if (!string.Equals(this.ParameterSetName, this.RecordSet.RecordType.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(string.Format(ProjectResources.Error_AddRecordTypeMismatch, this.ParameterSetName, this.RecordSet.RecordType));
            }

            if (result.Records == null)
            {
                result.Records = new List<PSPrivateDnsRecordBase>();
            }

            switch (result.RecordType)
            {
                case RecordType.A:
                    {
                        result.Records.Add(new Models.ARecord { Ipv4Address = this.Ipv4Address });
                        break;
                    }

                case RecordType.AAAA:
                    {
                        result.Records.Add(new Models.AaaaRecord { Ipv6Address = this.Ipv6Address });
                        break;
                    }

                case RecordType.MX:
                    {
                        result.Records.Add(new Models.MxRecord { Preference = this.Preference, Exchange = this.Exchange });
                        break;
                    }

                case RecordType.SRV:
                    {
                        result.Records.Add(new Models.SrvRecord { Priority = this.Priority, Port = this.Port, Target = this.Target, Weight = this.Weight });
                        break;
                    }
                case RecordType.TXT:
                    {
                        result.Records.Add(new Models.TxtRecord { Value = this.Value });
                        break;
                    }
                case RecordType.PTR:
                    {
                        result.Records.Add(new Models.PtrRecord { Ptrdname = this.Ptrdname });
                        break;
                    }
                case RecordType.CNAME:
                    {
                        if (result.Records.Count != 0)
                        {
                            if (!(result.Records[0] is Models.CnameRecord currentCNameRecord))
                            {
                                throw new ArgumentException(ProjectResources.Error_AddRecordTypeMismatch);
                            }

                            if (!string.IsNullOrEmpty(currentCNameRecord.Cname))
                            {
                                throw new ArgumentException(ProjectResources.Error_AddRecordMultipleCnames);
                            }

                            result.Records.Clear();
                        }

                        result.Records.Add(new Models.CnameRecord { Cname = this.Cname });
                        break;
                    }
            }

            WriteVerbose(ProjectResources.Success_RecordAdded);

            WriteObject(result);
        }
    }
}

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

using Microsoft.Azure.Commands.Dns.Models;
using Microsoft.Azure.Management.Dns.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.Dns.Properties.Resources;

namespace Microsoft.Azure.Commands.Dns
{
    /// <summary>
    /// Adds a record to a record set object.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureRmDnsRecordConfig"), OutputType(typeof(DnsRecordSet))]
    public class AddAzureDnsRecordConfig : DnsBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The record set in which to add the record.")]
        [ValidateNotNullOrEmpty]
        public DnsRecordSet RecordSet { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The IPv4 address for the A record to add.", ParameterSetName = "A")]
        [ValidateNotNullOrEmpty]
        public string Ipv4Address { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The IPv6 address for the AAAA record to add.", ParameterSetName = "AAAA")]
        [ValidateNotNullOrEmpty]
        public string Ipv6Address { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name server host for the NS record to add. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = "NS")]
        [ValidateNotNullOrEmpty]
        public string Nsdname { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The mail exchange host for the MX record to add. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = "MX")]
        [ValidateNotNullOrEmpty]
        public string Exchange { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The preference value for the MX record to add.", ParameterSetName = "MX")]
        [ValidateNotNullOrEmpty]
        public ushort Preference { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The target host for the PTR record to add. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = "PTR")]
        [ValidateNotNullOrEmpty]
        public string Ptrdname { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The text value for the TXT record to add.", ParameterSetName = "TXT")]
        [ValidateNotNullOrEmpty]
        [ValidateLength(DnsClient.TxtRecordMinLength, DnsClient.TxtRecordMaxLength)]
        public string Value { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The priority value SRV record to add.", ParameterSetName = "SRV")]
        [ValidateNotNullOrEmpty]
        public ushort Priority { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The target host for the SRV record to add. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = "SRV")]
        [ValidateNotNullOrEmpty]
        public string Target { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The port number for the SRV record to add.", ParameterSetName = "SRV")]
        [ValidateNotNullOrEmpty]
        public ushort Port { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The weight value for the SRV record to add.", ParameterSetName = "SRV")]
        [ValidateNotNullOrEmpty]
        public ushort Weight { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The canonical name for the CNAME record to add. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = "CNAME")]
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
                result.Records = new List<DnsRecordBase>();
            }

            switch (result.RecordType)
            {
                case RecordType.A:
                    {
                        result.Records.Add(new ARecord { Ipv4Address = this.Ipv4Address });
                        break;
                    }

                case RecordType.AAAA:
                    {
                        result.Records.Add(new AaaaRecord { Ipv6Address = this.Ipv6Address });
                        break;
                    }

                case RecordType.MX:
                    {
                        result.Records.Add(new MxRecord { Preference = this.Preference, Exchange = this.Exchange });
                        break;
                    }

                case RecordType.NS:
                    {
                        result.Records.Add(new NsRecord { Nsdname = this.Nsdname });
                        break;
                    }
                case RecordType.SRV:
                    {
                        result.Records.Add(new SrvRecord { Priority = this.Priority, Port = this.Port, Target = this.Target, Weight = this.Weight });
                        break;
                    }
                case RecordType.TXT:
                    {
                        result.Records.Add(new TxtRecord { Value = this.Value });
                        break;
                    }
                case RecordType.PTR:
                    {
                        result.Records.Add(new PtrRecord { Ptrdname = this.Ptrdname });
                        break;
                    }
                case RecordType.CNAME:
                    {
                        if (result.Records.Count != 0)
                        {
                            var currentCNameRecord = result.Records[0] as CnameRecord;
                            if (currentCNameRecord == null)
                            {
                                throw new ArgumentException(ProjectResources.Error_AddRecordTypeMismatch);
                            }

                            if (!string.IsNullOrEmpty(currentCNameRecord.Cname))
                            {
                                throw new ArgumentException(ProjectResources.Error_AddRecordMultipleCnames);
                            }

                            result.Records.Clear();
                        }

                        result.Records.Add(new CnameRecord { Cname = this.Cname });
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            WriteVerbose(ProjectResources.Success_RecordAdded);

            WriteObject(result);
        }
    }
}

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
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.Dns.Properties.Resources;

namespace Microsoft.Azure.Commands.Dns
{
    /// <summary>
    /// Removes a record from a record set object.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmDnsRecordConfig"), OutputType(typeof(DnsRecordSet))]
    public class RemoveAzureDnsRecordConfig : DnsBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The record set from which to remove the record.")]
        [ValidateNotNullOrEmpty]
        public DnsRecordSet RecordSet { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The IPv4 address of the A record to remove.", ParameterSetName = "A")]
        [ValidateNotNullOrEmpty]
        public string Ipv4Address { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The IPv6 address of the AAAA record to remove.", ParameterSetName = "AAAA")]
        [ValidateNotNullOrEmpty]
        public string Ipv6Address { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name server host of the NS record to remove. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = "NS")]
        [ValidateNotNullOrEmpty]
        public string Nsdname { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The mail exchange host of the MX record to remove. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = "MX")]
        [ValidateNotNullOrEmpty]
        public string Exchange { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The preference value of the MX record to remove.", ParameterSetName = "MX")]
        [ValidateNotNullOrEmpty]
        public ushort Preference { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The target host of the PTR record to remove. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = "PTR")]
        [ValidateNotNullOrEmpty]
        public string Ptrdname { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The text value of the TXT record to remove.", ParameterSetName = "TXT")]
        [ValidateNotNullOrEmpty]
        public string Value { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The priority value of the SRV record to remove.", ParameterSetName = "SRV")]
        [ValidateNotNullOrEmpty]
        public ushort Priority { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The target host of the SRV record to remove. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = "SRV")]
        [ValidateNotNullOrEmpty]
        public string Target { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The port number of the SRV record to remove.", ParameterSetName = "SRV")]
        [ValidateNotNullOrEmpty]
        public ushort Port { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The weight value of the SRV record to remove.", ParameterSetName = "SRV")]
        [ValidateNotNullOrEmpty]
        public ushort Weight { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The canonical name of the CNAME record to remove. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = "CNAME")]
        [ValidateNotNullOrEmpty]
        public string Cname { get; set; }

        public override void ExecuteCmdlet()
        {
            var result = this.RecordSet;
            if (!string.Equals(this.ParameterSetName, this.RecordSet.RecordType.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(string.Format(ProjectResources.Error_RemoveRecordTypeMismatch, this.ParameterSetName, this.RecordSet.RecordType));
            }

            int removedCount = 0;

            if (result.Records != null && result.Records.Count > 0)
            {
                switch (result.RecordType)
                {
                    case RecordType.A:
                        {
                            removedCount = result.Records.RemoveAll(record =>
                                record is ARecord
                                && ((ARecord)record).Ipv4Address == this.Ipv4Address);
                            break;
                        }

                    case RecordType.AAAA:
                        {
                            removedCount = result.Records.RemoveAll(record =>
                                record is AaaaRecord
                                && ((AaaaRecord)record).Ipv6Address == this.Ipv6Address);
                            break;
                        }

                    case RecordType.MX:
                        {
                            removedCount = result.Records.RemoveAll(record =>
                                record is MxRecord
                                && string.Equals(((MxRecord)record).Exchange, this.Exchange, System.StringComparison.OrdinalIgnoreCase)
                                && ((MxRecord)record).Preference == this.Preference);
                            break;
                        }

                    case RecordType.NS:
                        {
                            removedCount = result.Records.RemoveAll(record =>
                                record is NsRecord
                                && string.Equals(((NsRecord)record).Nsdname, this.Nsdname, System.StringComparison.OrdinalIgnoreCase));
                            break;
                        }
                    case RecordType.SRV:
                        {
                            removedCount = result.Records.RemoveAll(record =>
                                record is SrvRecord
                                && ((SrvRecord)record).Priority == this.Priority
                                && ((SrvRecord)record).Port == this.Port
                                && string.Equals(((SrvRecord)record).Target, this.Target, System.StringComparison.OrdinalIgnoreCase)
                                && ((SrvRecord)record).Weight == this.Weight);
                            break;
                        }
                    case RecordType.TXT:
                        {
                            removedCount = result.Records.RemoveAll(record =>
                                record is TxtRecord
                                && ((TxtRecord)record).Value == this.Value);
                            break;
                        }
                    case RecordType.PTR:
                        {
                            removedCount = result.Records.RemoveAll(record =>
                                record is PtrRecord
                                && ((PtrRecord)record).Ptrdname == this.Ptrdname);
                            break;
                        }
                    case RecordType.CNAME:
                        {
                            removedCount = result.Records.RemoveAll(record =>
                                record is CnameRecord
                                && string.Equals(((CnameRecord)record).Cname, this.Cname, System.StringComparison.OrdinalIgnoreCase));
                            break;
                        }
                }
            }

            WriteVerbose(ProjectResources.Success_RecordRemoved);

            WriteObject(result);
        }
    }
}

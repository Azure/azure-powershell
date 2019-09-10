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
    using System.Management.Automation;
    using Microsoft.Azure.Commands.PrivateDns.Models;
    using Microsoft.Azure.Management.PrivateDns.Models;
    using Microsoft.Azure.Commands.PrivateDns.Utilities;
    using ProjectResources = Microsoft.Azure.Commands.PrivateDns.Properties.Resources;

    /// <summary>
    /// Removes a record from a record set object.
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateDnsRecordConfig", DefaultParameterSetName = PrivateDnsUtils.ARecord), OutputType(typeof(PSPrivateDnsRecordSet))]
    public class RemoveAzurePrivateDnsRecordConfig : PrivateDnsBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The record set from which to remove the record.")]
        [ValidateNotNullOrEmpty]
        public PSPrivateDnsRecordSet RecordSet { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The IPv4 address of the A record to remove.", ParameterSetName = PrivateDnsUtils.ARecord)]
        [ValidateNotNullOrEmpty]
        public string Ipv4Address { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The IPv6 address of the AAAA record to remove.", ParameterSetName = PrivateDnsUtils.AaaaRecord)]
        [ValidateNotNullOrEmpty]
        public string Ipv6Address { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The mail exchange host of the MX record to remove. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = PrivateDnsUtils.MxRecord)]
        [ValidateNotNullOrEmpty]
        public string Exchange { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The preference value of the MX record to remove.", ParameterSetName = PrivateDnsUtils.MxRecord)]
        [ValidateNotNullOrEmpty]
        public ushort Preference { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The target host of the PTR record to remove. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = PrivateDnsUtils.PtrRecord)]
        [ValidateNotNullOrEmpty]
        public string Ptrdname { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The text value of the TXT record to remove.", ParameterSetName = PrivateDnsUtils.TxtRecord)]
        [ValidateNotNullOrEmpty]
        public string Value { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The priority value of the SRV record to remove.", ParameterSetName = PrivateDnsUtils.SrvRecord)]
        [ValidateNotNullOrEmpty]
        public ushort Priority { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The target host of the SRV record to remove. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = PrivateDnsUtils.SrvRecord)]
        [ValidateNotNullOrEmpty]
        public string Target { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The port number of the SRV record to remove.", ParameterSetName = PrivateDnsUtils.SrvRecord)]
        [ValidateNotNullOrEmpty]
        public ushort Port { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The weight value of the SRV record to remove.", ParameterSetName = PrivateDnsUtils.SrvRecord)]
        [ValidateNotNullOrEmpty]
        public ushort Weight { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The canonical name of the CNAME record to remove. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = PrivateDnsUtils.CnameRecord)]
        [ValidateNotNullOrEmpty]
        public string Cname { get; set; }

        public override void ExecuteCmdlet()
        {
            var result = this.RecordSet;
            if (!string.Equals(this.ParameterSetName, this.RecordSet.RecordType.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(string.Format(ProjectResources.Error_RemoveRecordTypeMismatch, this.ParameterSetName, this.RecordSet.RecordType));
            }

            if (result.Records != null && result.Records.Count > 0)
            {
                switch (result.RecordType)
                {
                    case RecordType.A:
                        {
                            result.Records.RemoveAll(record =>
                                record is Models.ARecord
                                && ((Models.ARecord)record).Ipv4Address == this.Ipv4Address);
                            break;
                        }

                    case RecordType.AAAA:
                        {
                            result.Records.RemoveAll(record =>
                                record is Models.AaaaRecord
                                && ((Models.AaaaRecord)record).Ipv6Address == this.Ipv6Address);
                            break;
                        }

                    case RecordType.MX:
                        {
                            result.Records.RemoveAll(record =>
                                record is Models.MxRecord
                                && string.Equals(((Models.MxRecord)record).Exchange, this.Exchange, System.StringComparison.OrdinalIgnoreCase)
                                && ((Models.MxRecord)record).Preference == this.Preference);
                            break;
                        }

                    case RecordType.SRV:
                        {
                            result.Records.RemoveAll(record =>
                                record is Models.SrvRecord
                                && ((Models.SrvRecord)record).Priority == this.Priority
                                && ((Models.SrvRecord)record).Port == this.Port
                                && string.Equals(((Models.SrvRecord)record).Target, this.Target, System.StringComparison.OrdinalIgnoreCase)
                                && ((Models.SrvRecord)record).Weight == this.Weight);
                            break;
                        }

                    case RecordType.TXT:
                        {
                            result.Records.RemoveAll(record =>
                                record is Models.TxtRecord
                                && ((Models.TxtRecord)record).Value == this.Value);
                            break;
                        }

                    case RecordType.PTR:
                        {
                            result.Records.RemoveAll(record =>
                                record is Models.PtrRecord
                                && ((Models.PtrRecord)record).Ptrdname == this.Ptrdname);
                            break;
                        }

                    case RecordType.CNAME:
                        {
                            result.Records.RemoveAll(record =>
                                record is Models.CnameRecord
                                && string.Equals(((Models.CnameRecord)record).Cname, this.Cname, System.StringComparison.OrdinalIgnoreCase));
                            break;
                        }

                    default:
                        {
                            throw new ArgumentException(string.Format(ProjectResources.Error_RemoveRecordTypeNotAllowed, this.ParameterSetName, this.RecordSet.RecordType));
                        }                      
                }
            }

            WriteVerbose(ProjectResources.Success_RecordRemoved);

            WriteObject(result);
        }
    }
}

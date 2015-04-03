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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Dns;
using Microsoft.Azure.Management.Dns.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure;
using Microsoft.Azure.Commands.Resources.Models;

namespace Microsoft.Azure.Commands.Dns.Models
{
    public class DnsClient
    {
        public const string DnsResourceLocation = "global";

        public DnsClient(AzureProfile profile)
            : this(AzureSession.ClientFactory.CreateClient<DnsManagementClient>(profile, AzureEnvironment.Endpoint.ResourceManager))
        {            
        }

        public DnsClient(IDnsManagementClient managementClient)
        {
            this.DnsManagementClient = managementClient;
        }

        public IDnsManagementClient DnsManagementClient { get; set; }

        public DnsZone CreateDnsZone(string name, string resourceGroupName, Hashtable[] tags)
        {
            ZoneCreateOrUpdateResponse response = this.DnsManagementClient.Zones.CreateOrUpdate(
                resourceGroupName, 
                name, 
                new ZoneCreateOrUpdateParameters
                {
                    IfNoneMatch = "*",
                    Zone = new Management.Dns.Models.Zone
                    {
                        Location = DnsResourceLocation,
                        Name = name,
                        Tags = TagsConversionHelper.CreateTagDictionary(tags, validate: true),
                        Properties = new ZoneProperties
                        {
                            ETag = null,
                        }
                    }
                });

            return new DnsZone
            {
                Name = response.Zone.Name,
                ResourceGroupName = resourceGroupName,
                Etag = response.Zone.Properties.ETag,
                Tags = TagsConversionHelper.CreateTagHashtable(response.Zone.Tags),
            };
        }

        public DnsZone UpdateDnsZone(DnsZone zone, bool ignoreEtag)
        {
            ZoneCreateOrUpdateResponse response = this.DnsManagementClient.Zones.CreateOrUpdate(
                zone.ResourceGroupName,
                zone.Name,
                new ZoneCreateOrUpdateParameters
                {
                    Zone = new Management.Dns.Models.Zone
                    {
                        Location = DnsResourceLocation,
                        Name = zone.Name,
                        Tags = TagsConversionHelper.CreateTagDictionary(zone.Tags, validate: true),
                        Properties = new ZoneProperties
                        {
                            ETag = ignoreEtag ? "*" : zone.Etag,
                        }
                    }
                });

            return new DnsZone
            {
                Name = response.Zone.Name,
                ResourceGroupName = zone.ResourceGroupName,
                Etag = response.Zone.Properties.ETag,
                Tags = TagsConversionHelper.CreateTagHashtable(response.Zone.Tags),
            };
        }

        public bool DeleteDnsZone(DnsZone zone, bool ignoreEtag)
        {
            AzureOperationResponse resp = this.DnsManagementClient.Zones.Delete(
                zone.ResourceGroupName,
                zone.Name,
                new ZoneDeleteParameters
                {
                    IfMatch = ignoreEtag ? null : zone.Etag,
                });

            return resp.StatusCode == System.Net.HttpStatusCode.NoContent || resp.StatusCode == System.Net.HttpStatusCode.OK ? true : false;
        }

        public DnsZone GetDnsZone(string name, string resourceGroupName)
        {
            ZoneGetResponse getResponse = this.DnsManagementClient.Zones.Get(resourceGroupName, name);
            return new DnsZone
            {
                Name = getResponse.Zone.Name,
                ResourceGroupName = resourceGroupName,
                Etag = getResponse.Zone.Properties.ETag,
                Tags = TagsConversionHelper.CreateTagHashtable(getResponse.Zone.Tags),
            };
        }

        public List<DnsZone> ListDnsZones(string resourceGroupName, string endsWith)
        {
            ZoneListParameters zoneListParameters = new ZoneListParameters
            {
                Filter = endsWith == null ? null : string.Format("endswith(Name,'{0}')", endsWith)
            };

            ZoneListResponse getResponse = this.DnsManagementClient.Zones.List(resourceGroupName, zoneListParameters);
            return getResponse.Zones.Select(zoneInResponse => new DnsZone
            {
                Name = zoneInResponse.Name,
                ResourceGroupName = resourceGroupName,
                Etag = zoneInResponse.Properties.ETag,
                Tags = TagsConversionHelper.CreateTagHashtable(zoneInResponse.Tags),
            })
            .ToList();
        }

        public DnsRecordSet CreateDnsRecordSet(string zoneName, string resourceGroupName, string relativeRecordName, uint ttl, RecordType recordType, Hashtable[] tags, bool overwrite)
        {
            RecordCreateOrUpdateResponse response = this.DnsManagementClient.Records.CreateOrUpdate(
                resourceGroupName,
                zoneName,
                relativeRecordName,
                recordType,
                new RecordCreateOrUpdateParameters
                {
                    IfNoneMatch = overwrite ? null : "*",
                    RecordSet = new RecordSet
                    {
                        Name = relativeRecordName,
                        Location = DnsResourceLocation,
                        Tags = TagsConversionHelper.CreateTagDictionary(tags, validate: true),
                        Properties = new RecordProperties
                        {
                            ETag = null,
                            Ttl = ttl,
                            AaaaRecords = recordType == RecordType.AAAA ? new List<Management.Dns.Models.AaaaRecord>() : null,
                            ARecords = recordType == RecordType.A ? new List<Management.Dns.Models.ARecord>() : null,
                            CnameRecord = null,
                            MxRecords = recordType == RecordType.MX ? new List<Management.Dns.Models.MxRecord>() : null,
                            NsRecords = recordType == RecordType.NS ? new List<Management.Dns.Models.NsRecord>() : null,
                            PtrRecords = recordType == RecordType.PTR ? new List<Management.Dns.Models.PtrRecord>() : null,
                            SoaRecord = null,
                            SrvRecords = recordType == RecordType.SRV ? new List<Management.Dns.Models.SrvRecord>() : null,
                            TxtRecords = recordType == RecordType.TXT ? new List<Management.Dns.Models.TxtRecord>() : null,
                        },
                    }
                });

            return GetPowerShellRecordSet(zoneName, resourceGroupName, response.RecordSet);
        }

        public DnsRecordSet UpdateDnsRecordSet(DnsRecordSet recordSet, bool ignoreEtag)
        {
            RecordCreateOrUpdateResponse response = this.DnsManagementClient.Records.CreateOrUpdate(
                recordSet.ResourceGroupName,
                recordSet.ZoneName,
                recordSet.Name,
                recordSet.RecordType,
                new RecordCreateOrUpdateParameters
                {
                    IfNoneMatch = null,
                    RecordSet = new RecordSet
                    {
                        Name = recordSet.Name,
                        Location = DnsResourceLocation,
                        Tags = TagsConversionHelper.CreateTagDictionary(recordSet.Tags, validate: true),
                        Properties = new RecordProperties
                        {
                            ETag = ignoreEtag ? "*" : recordSet.Etag,
                            Ttl = recordSet.Ttl,
                            AaaaRecords = recordSet.RecordType == RecordType.AAAA ? GetMamlRecords<AaaaRecord, Management.Dns.Models.AaaaRecord>(recordSet.Records) : null,
                            ARecords = recordSet.RecordType == RecordType.A ? GetMamlRecords<ARecord, Management.Dns.Models.ARecord>(recordSet.Records) : null,
                            MxRecords = recordSet.RecordType == RecordType.MX ? GetMamlRecords<MxRecord, Management.Dns.Models.MxRecord>(recordSet.Records) : null,
                            NsRecords = recordSet.RecordType == RecordType.NS ? GetMamlRecords<NsRecord, Management.Dns.Models.NsRecord>(recordSet.Records) : null,
                            SrvRecords = recordSet.RecordType == RecordType.SRV ? GetMamlRecords<SrvRecord, Management.Dns.Models.SrvRecord>(recordSet.Records) : null,
                            TxtRecords = recordSet.RecordType == RecordType.TXT ? GetMamlRecords<TxtRecord, Management.Dns.Models.TxtRecord>(recordSet.Records) : null,
                            SoaRecord = recordSet.RecordType == RecordType.SOA ? GetMamlRecords<SoaRecord, Management.Dns.Models.SoaRecord>(recordSet.Records).SingleOrDefault() : null,
                            CnameRecord = recordSet.RecordType == RecordType.CNAME ? GetMamlRecords<CnameRecord, Management.Dns.Models.CnameRecord>(recordSet.Records).SingleOrDefault() : null,
                        }
                    }
                });

            return GetPowerShellRecordSet(recordSet.ZoneName, recordSet.ResourceGroupName, response.RecordSet);
        }

        public bool DeleteDnsRecordSet(DnsRecordSet recordSet, bool ignoreEtag)
        {
            AzureOperationResponse response = this.DnsManagementClient.Records.Delete(
                recordSet.ResourceGroupName,
                recordSet.ZoneName,
                recordSet.Name,
                recordSet.RecordType,
                new RecordDeleteParameters
                {
                    IfMatch = ignoreEtag ? "*" : recordSet.Etag
                });

            return response.StatusCode == System.Net.HttpStatusCode.NoContent || response.StatusCode == System.Net.HttpStatusCode.OK ? true : false;
        }

        public DnsRecordSet GetDnsRecordSet(string name, string zoneName, string resourceGroupName, RecordType recordType)
        {
            RecordGetResponse getResponse = this.DnsManagementClient.Records.Get(resourceGroupName, zoneName, name, recordType);
            return GetPowerShellRecordSet(zoneName, resourceGroupName, getResponse.RecordSet);
        }

        public List<DnsRecordSet> ListRecordSets(string zoneName, string resourceGroupName, RecordType recordType, string endsWith)
        {
            RecordListParameters recordListParameters = new RecordListParameters
            {
                Filter = endsWith == null ? null : string.Format("endswith(Name,'{0}')", endsWith)
            };

            RecordListResponse listResponse = this.DnsManagementClient.Records.List(resourceGroupName, zoneName, recordType, recordListParameters);
            return listResponse
                .RecordSets
                .Select(recordSetInResponse => GetPowerShellRecordSet(zoneName, resourceGroupName, recordSetInResponse))
                .ToList();
        }

        public List<DnsRecordSet> ListRecordSets(string zoneName, string resourceGroupName, string endsWith)
        {
            RecordListParameters recordListParameters = new RecordListParameters
            {
                Filter = endsWith == null ? null : string.Format("endswith(Name,'{0}')", endsWith)
            };

            RecordListResponse listResponse = this.DnsManagementClient.Records.ListAll(resourceGroupName, zoneName, recordListParameters);
            return listResponse
                .RecordSets
                .Select(recordSetInResponse => GetPowerShellRecordSet(zoneName, resourceGroupName, recordSetInResponse))
                .ToList();
        }

        private static DnsRecordSet GetPowerShellRecordSet(string zoneName, string resourceGroupName, Management.Dns.Models.RecordSet mamlRecordSet)
        {
            // e.g. "/subscriptions/<guid>/resourceGroups/<rg>/providers/microsoft.dns/dnszones/<zone>/A/<record>"
            string recordTypeAsString = mamlRecordSet.Id.Split('/').Reverse().Skip(1).First();

            RecordType recordType = (RecordType)Enum.Parse(typeof(RecordType), recordTypeAsString, ignoreCase: true);

            return new DnsRecordSet
            {
                Etag = mamlRecordSet.Properties.ETag,
                Name = mamlRecordSet.Name,
                RecordType = recordType,
                Records = GetPowerShellRecords(mamlRecordSet),
                Tags = TagsConversionHelper.CreateTagHashtable(mamlRecordSet.Tags),
                ResourceGroupName = resourceGroupName,
                Ttl = mamlRecordSet.Properties.Ttl,
                ZoneName = zoneName,
            };
        }

        private static List<DnsRecordBase> GetPowerShellRecords(Management.Dns.Models.RecordSet recordSet)
        {
            var result = new List<DnsRecordBase>();
            result.AddRange(GetPowerShellRecords(recordSet.Properties.AaaaRecords));
            result.AddRange(GetPowerShellRecords(recordSet.Properties.ARecords));
            result.AddRange(GetPowerShellRecords(recordSet.Properties.MxRecords));
            result.AddRange(GetPowerShellRecords(recordSet.Properties.NsRecords));
            result.AddRange(GetPowerShellRecords(recordSet.Properties.SrvRecords));
            result.AddRange(GetPowerShellRecords(recordSet.Properties.TxtRecords));
            if (recordSet.Properties.CnameRecord != null)
            {
                result.Add(DnsRecordBase.FromMamlRecord(recordSet.Properties.CnameRecord));
            }
            if (recordSet.Properties.SoaRecord != null)
            {
                result.Add(DnsRecordBase.FromMamlRecord(recordSet.Properties.SoaRecord));
            }

            return result;
        }

        private static List<DnsRecordBase> GetPowerShellRecords<T>(IList<T> mamlObjects) where T : class
        {
            var result = new List<DnsRecordBase>();
            if (mamlObjects == null || mamlObjects.Count == 0)
            {
                return result;
            }

            return mamlObjects.Select(mamlObject => DnsRecordBase.FromMamlRecord(mamlObject)).ToList();
        }

        private List<MamlRecordType> GetMamlRecords<PSRecordType, MamlRecordType>(List<DnsRecordBase> powerShellRecords) where PSRecordType : DnsRecordBase
        {
            return powerShellRecords
                .Where(record => record is PSRecordType)
                .Cast<PSRecordType>()
                .Select(record => record.ToMamlRecord())
                .Cast<MamlRecordType>()
                .ToList();
        }
    }
}

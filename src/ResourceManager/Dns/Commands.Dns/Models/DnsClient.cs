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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.Dns;
using Microsoft.Azure.Management.Dns.Models;
using Microsoft.Azure.Commands.Tags.Model;

namespace Microsoft.Azure.Commands.Dns.Models
{
    using System.Threading;
    using System.Threading.Tasks;

    public class DnsClient
    {
        public const string DnsResourceLocation = "global";

        public DnsClient(AzureContext context)
            : this(AzureSession.ClientFactory.CreateClient<DnsManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        public DnsClient(IDnsManagementClient managementClient)
        {
            this.DnsManagementClient = managementClient;
        }

        public IDnsManagementClient DnsManagementClient { get; set; }

        public DnsZone CreateDnsZone(string name, string resourceGroupName, Hashtable[] tags)
        {
            //ZoneCreateOrUpdateResponse response = Task.Factory.StartNew((object s) => ((IZoneOperations)s).CreateOrUpdateAsync(
            //    resourceGroupName,
            //    name,
            //    new ZoneCreateOrUpdateParameters
            //    {
            //        Zone = new Management.Dns.Models.Zone
            //        {
            //            Location = DnsResourceLocation,
            //            Name = name,
            //            Tags = TagsConversionHelper.CreateTagDictionary(tags, validate: true),
            //            ETag = null,
            //            Properties = new ZoneProperties
            //            {
            //                NumberOfRecordSets = null,
            //                MaxNumberOfRecordSets = null,
            //            }
            //        }
            //    },
            //    ifMatch: null,
            //    ifNoneMatch: "*"), this.DnsManagementClient.Zones, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();

            ZoneCreateOrUpdateResponse response = this.DnsManagementClient.Zones.CreateOrUpdate(
                resourceGroupName,
                name,
                new ZoneCreateOrUpdateParameters
                {
                    Zone = new Management.Dns.Models.Zone
                    {
                        Location = DnsResourceLocation,
                        Name = name,
                        Tags = TagsConversionHelper.CreateTagDictionary(tags, validate: true),
                        ETag = null,
                        Properties = new ZoneProperties
                        {
                            NumberOfRecordSets = null,
                            MaxNumberOfRecordSets = null,
                        }
                    }
                },
                ifMatch: null,
                ifNoneMatch: "*");

            return ToDnsZone(response.Zone);
        }

        public DnsZone UpdateDnsZone(DnsZone zone, bool overwrite)
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
                        ETag = overwrite ? "*" : zone.Etag,
                        Properties = new ZoneProperties
                        {
                        }
                    }
                },
                ifMatch: overwrite ? "*" : zone.Etag,
                ifNoneMatch: null);

            return ToDnsZone(response.Zone);
        }

        public bool DeleteDnsZone(DnsZone zone, bool overwrite)
        {
            AzureOperationResponse resp = this.DnsManagementClient.Zones.Delete(
                zone.ResourceGroupName,
                zone.Name,
                ifMatch: overwrite ? null : zone.Etag,
                ifNoneMatch: null);

            return resp.StatusCode == System.Net.HttpStatusCode.NoContent || resp.StatusCode == System.Net.HttpStatusCode.OK ? true : false;
        }

        public DnsZone GetDnsZone(string name, string resourceGroupName)
        {
            ZoneGetResponse getResponse = this.DnsManagementClient.Zones.Get(resourceGroupName, name);
            return ToDnsZone(getResponse.Zone);
        }

        public List<DnsZone> ListDnsZonesInResourceGroup(string resourceGroupName)
        {
            ZoneListResponse getResponse = this.DnsManagementClient.Zones.ListZonesInResourceGroup(resourceGroupName, new ZoneListParameters());
            return getResponse.Zones.Select(ToDnsZone).ToList();
        }

        public List<DnsZone> ListDnsZonesInSubscription()
        {
            ZoneListResponse getResponse = this.DnsManagementClient.Zones.ListZonesInSubscription(new ZoneListParameters());
            return getResponse.Zones.Select(ToDnsZone).ToList();
        }


        public DnsRecordSet CreateDnsRecordSet(
            string zoneName,
            string resourceGroupName,
            string relativeRecordSetName,
            uint ttl,
            RecordType recordType,
            Hashtable[] tags,
            bool overwrite)
        {
            RecordSetCreateOrUpdateResponse response = this.DnsManagementClient.RecordSets.CreateOrUpdate(
                resourceGroupName,
                zoneName,
                relativeRecordSetName,
                recordType,
                new RecordSetCreateOrUpdateParameters
                {
                    RecordSet = new RecordSet
                    {
                        Name = relativeRecordSetName,
                        Location = DnsResourceLocation,
                        ETag = null,
                        Properties = new RecordSetProperties
                        {
                            Ttl = ttl,
                            Metadata = TagsConversionHelper.CreateTagDictionary(tags, validate: true),
                            AaaaRecords = recordType == RecordType.AAAA ? new List<Management.Dns.Models.AaaaRecord>() : null,
                            ARecords = recordType == RecordType.A ? new List<Management.Dns.Models.ARecord>() : null,
                            CnameRecord = recordType == RecordType.CNAME ? new Management.Dns.Models.CnameRecord(String.Empty) : null,
                            MxRecords = recordType == RecordType.MX ? new List<Management.Dns.Models.MxRecord>() : null,
                            NsRecords = recordType == RecordType.NS ? new List<Management.Dns.Models.NsRecord>() : null,
                            PtrRecords = recordType == RecordType.PTR ? new List<Management.Dns.Models.PtrRecord>() : null,
                            SoaRecord = null,
                            SrvRecords = recordType == RecordType.SRV ? new List<Management.Dns.Models.SrvRecord>() : null,
                            TxtRecords = recordType == RecordType.TXT ? new List<Management.Dns.Models.TxtRecord>() : null,
                        },
                    }
                },
                null,
                overwrite ? null : "*");

            return GetPowerShellRecordSet(zoneName, resourceGroupName, response.RecordSet);
        }

        public DnsRecordSet UpdateDnsRecordSet(DnsRecordSet recordSet, bool overwrite)
        {
            RecordSetCreateOrUpdateResponse response = this.DnsManagementClient.RecordSets.CreateOrUpdate(
                recordSet.ResourceGroupName,
                recordSet.ZoneName,
                recordSet.Name,
                recordSet.RecordType,
                new RecordSetCreateOrUpdateParameters
                {
                    RecordSet = new RecordSet
                    {
                        Name = recordSet.Name,
                        Location = DnsResourceLocation,
                        ETag = overwrite ? "*" : recordSet.Etag,
                        Properties = new RecordSetProperties
                        {
                            Ttl = recordSet.Ttl,
                            Metadata = TagsConversionHelper.CreateTagDictionary(recordSet.Tags, validate: true),
                            AaaaRecords =
                                recordSet.RecordType == RecordType.AAAA
                                    ? GetMamlRecords<AaaaRecord, Management.Dns.Models.AaaaRecord>(recordSet.Records)
                                    : null,
                            ARecords =
                                recordSet.RecordType == RecordType.A
                                    ? GetMamlRecords<ARecord, Management.Dns.Models.ARecord>(recordSet.Records)
                                    : null,
                            MxRecords =
                                recordSet.RecordType == RecordType.MX
                                    ? GetMamlRecords<MxRecord, Management.Dns.Models.MxRecord>(recordSet.Records)
                                    : null,
                            NsRecords =
                                recordSet.RecordType == RecordType.NS
                                    ? GetMamlRecords<NsRecord, Management.Dns.Models.NsRecord>(recordSet.Records)
                                    : null,
                            SrvRecords =
                                recordSet.RecordType == RecordType.SRV
                                    ? GetMamlRecords<SrvRecord, Management.Dns.Models.SrvRecord>(recordSet.Records)
                                    : null,
                            TxtRecords =
                                recordSet.RecordType == RecordType.TXT
                                    ? GetMamlRecords<TxtRecord, Management.Dns.Models.TxtRecord>(recordSet.Records)
                                    : null,
                            SoaRecord =
                                recordSet.RecordType == RecordType.SOA
                                    ? GetMamlRecords<SoaRecord, Management.Dns.Models.SoaRecord>(recordSet.Records).SingleOrDefault()
                                    : null,
                            CnameRecord =
                                recordSet.RecordType == RecordType.CNAME
                                    ? GetMamlRecords<CnameRecord, Management.Dns.Models.CnameRecord>(recordSet.Records).SingleOrDefault()
                                    : null,
                        }
                    }
                },
                ifMatch: overwrite ? "*" : recordSet.Etag,
                ifNoneMatch: null);

            return GetPowerShellRecordSet(recordSet.ZoneName, recordSet.ResourceGroupName, response.RecordSet);
        }

        public bool DeleteDnsRecordSet(DnsRecordSet recordSet, bool overwrite)
        {
            AzureOperationResponse response = this.DnsManagementClient.RecordSets.Delete(
                recordSet.ResourceGroupName,
                recordSet.ZoneName,
                recordSet.Name,
                recordSet.RecordType,
                ifMatch: overwrite ? "*" : recordSet.Etag,
                ifNoneMatch: null);

            return response.StatusCode == System.Net.HttpStatusCode.NoContent || response.StatusCode == System.Net.HttpStatusCode.OK ? true : false;
        }

        public DnsRecordSet GetDnsRecordSet(string name, string zoneName, string resourceGroupName, RecordType recordType)
        {
            RecordSetGetResponse getResponse = this.DnsManagementClient.RecordSets.Get(resourceGroupName, zoneName, name, recordType);
            return GetPowerShellRecordSet(zoneName, resourceGroupName, getResponse.RecordSet);
        }

        public List<DnsRecordSet> ListRecordSets(string zoneName, string resourceGroupName, RecordType recordType)
        {
            RecordSetListParameters recordListParameters = new RecordSetListParameters();

            RecordSetListResponse listResponse = this.DnsManagementClient.RecordSets.List(
                resourceGroupName,
                zoneName,
                recordType,
                recordListParameters);
            return listResponse
                .RecordSets
                .Select(recordSetInResponse => GetPowerShellRecordSet(zoneName, resourceGroupName, recordSetInResponse))
                .ToList();
        }

        public List<DnsRecordSet> ListRecordSets(string zoneName, string resourceGroupName)
        {
            RecordSetListParameters recordListParameters = new RecordSetListParameters();

            RecordSetListResponse listResponse = this.DnsManagementClient.RecordSets.ListAll(resourceGroupName, zoneName, recordListParameters);
            return listResponse
                .RecordSets
                .Select(recordSetInResponse => GetPowerShellRecordSet(zoneName, resourceGroupName, recordSetInResponse))
                .ToList();
        }

        private static DnsRecordSet GetPowerShellRecordSet(string zoneName, string resourceGroupName, Management.Dns.Models.RecordSet mamlRecordSet)
        {
            // e.g. "/subscriptions/<guid>/resourceGroups/<rg>/providers/microsoft.dns/dnszones/<zone>/A/<recordset>"
            string recordTypeAsString = mamlRecordSet.Id.Split('/').Reverse().Skip(1).First();

            RecordType recordType = (RecordType) Enum.Parse(typeof (RecordType), recordTypeAsString, ignoreCase: true);

            return new DnsRecordSet
            {
                Etag = mamlRecordSet.ETag,
                Name = mamlRecordSet.Name,
                RecordType = recordType,
                Records = GetPowerShellRecords(mamlRecordSet),
                Tags = TagsConversionHelper.CreateTagHashtable(mamlRecordSet.Properties.Metadata),
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

        private List<MamlRecordType> GetMamlRecords<PSRecordType, MamlRecordType>(List<DnsRecordBase> powerShellRecords)
            where PSRecordType : DnsRecordBase
        {
            return powerShellRecords
                .Where(record => record is PSRecordType)
                .Cast<PSRecordType>()
                .Select(record => record.ToMamlRecord())
                .Cast<MamlRecordType>()
                .ToList();
        }

        private static DnsZone ToDnsZone(Zone zone)
        {
            return new DnsZone()
            {
                Name = zone.Name,
                ResourceGroupName = zone.Properties.ParentResourceGroupName,
                Etag = zone.ETag,
                Tags = TagsConversionHelper.CreateTagHashtable(zone.Tags),
                NameServers = zone.Properties.NameServers != null ? zone.Properties.NameServers.ToList() : new List<string>(),
            };
        }
    }
}

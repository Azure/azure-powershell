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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Dns;
using Microsoft.Azure.Management.Dns.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ProjectResources = Microsoft.Azure.Commands.Dns.Properties.Resources;
using Sdk = Microsoft.Azure.Management.Dns.Models;

namespace Microsoft.Azure.Commands.Dns.Models
{
    using Rest.Azure;

    public class DnsClient
    {
        public const string DnsResourceLocation = "global";

        public const int TxtRecordMaxLength = 1024;

        public const int TxtRecordMinLength = 0;

        private Dictionary<RecordType, Type> recordTypeValidationEntries = new Dictionary<RecordType, Type>()
        {
            {RecordType.A, typeof (ARecord)},
            {RecordType.AAAA, typeof (AaaaRecord)},
            {RecordType.CNAME, typeof (CnameRecord)},
            {RecordType.MX, typeof (MxRecord)},
            {RecordType.NS, typeof (NsRecord)},
            {RecordType.SOA, typeof (SoaRecord)},
            {RecordType.PTR, typeof (PtrRecord)},
            {RecordType.SRV, typeof (SrvRecord)},
            {RecordType.TXT, typeof (TxtRecord)}
        };

        public DnsClient(AzureContext context)
            : this(AzureSession.ClientFactory.CreateArmClient<DnsManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        public DnsClient(IDnsManagementClient managementClient)
        {
            this.DnsManagementClient = managementClient;
        }

        public IDnsManagementClient DnsManagementClient { get; set; }

        public DnsZone CreateDnsZone(
            string name,
            string resourceGroupName,
            Hashtable tags)
        {
            var response = this.DnsManagementClient.Zones.CreateOrUpdate(
                resourceGroupName,
                name,
                new Zone
                {
                    Location = DnsResourceLocation,
                    Tags = TagsConversionHelper.CreateTagDictionary(tags, validate: true),
                },
                ifMatch: null,
                ifNoneMatch: "*");

            return ToDnsZone(response);
        }

        public DnsZone UpdateDnsZone(DnsZone zone, bool overwrite)
        {
            var response = this.DnsManagementClient.Zones.CreateOrUpdate(
                zone.ResourceGroupName,
                zone.Name,
                 new Zone
                    {
                        Location = DnsResourceLocation,
                        Tags = TagsConversionHelper.CreateTagDictionary(zone.Tags, validate: true),
                    },
                ifMatch: overwrite ? "*" : zone.Etag,
                ifNoneMatch: null);

            return ToDnsZone(response);
        }

        public bool DeleteDnsZone(
            DnsZone zone,
            bool overwrite)
        {
            var deleteResult = this.DnsManagementClient.Zones.Delete(
                zone.ResourceGroupName,
                zone.Name,
                ifMatch: overwrite ? null : zone.Etag,
                ifNoneMatch: null);

            return deleteResult.Status == Sdk.OperationStatus.Succeeded ;
        }

        public DnsZone GetDnsZone(string name, string resourceGroupName)
        {
            return ToDnsZone(this.DnsManagementClient.Zones.Get(resourceGroupName, name));
        }

        public List<DnsZone> ListDnsZonesInResourceGroup(string resourceGroupName)
        {
            List<DnsZone> results = new List<DnsZone>();
            IPage<Zone> getResponse = null;
            do
            {
                if (getResponse != null && getResponse.NextPageLink != null)
                {
                    getResponse = this.DnsManagementClient.Zones.ListInResourceGroupNext(getResponse.NextPageLink);
                }
                else
                {
                    getResponse = this.DnsManagementClient.Zones.ListInResourceGroup(resourceGroupName);    
                }
                
                results.AddRange(getResponse.Select(ToDnsZone));
            } while (getResponse != null && getResponse.NextPageLink != null);

            return results;
        }

        public List<DnsZone> ListDnsZonesInSubscription()
        {
            List<DnsZone> results = new List<DnsZone>();
            IPage<Zone> getResponse = null;
            do
            {
                if (getResponse != null && getResponse.NextPageLink != null)
                {
                    getResponse = this.DnsManagementClient.Zones.ListInSubscriptionNext(getResponse.NextPageLink);
                }
                else
                {
                    getResponse = this.DnsManagementClient.Zones.ListInSubscription();
                }

                results.AddRange(getResponse.Select(ToDnsZone));
            } while (getResponse != null && getResponse.NextPageLink != null);

            return results;
        }

        public DnsRecordSet CreateDnsRecordSet(
            string zoneName,
            string resourceGroupName,
            string relativeRecordSetName,
            uint ttl,
            RecordType recordType,
            Hashtable tags,
            bool overwrite,
            DnsRecordBase[] resourceRecords)
        {
            var recordSet = ConstructRecordSetPropeties(relativeRecordSetName, recordType, ttl, tags, resourceRecords);

            var response = this.DnsManagementClient.RecordSets.CreateOrUpdate(
                resourceGroupName,
                zoneName,
                relativeRecordSetName,
                recordType,
                recordSet,
                null,
                overwrite ? null : "*");

            return GetPowerShellRecordSet(zoneName, resourceGroupName, response);
        }

        private RecordSet ConstructRecordSetPropeties(string recordSetName, RecordType recordType, uint ttl, Hashtable tags, DnsRecordBase[] resourceRecords)
        {

            var properties = new RecordSet
            {
                Name = recordSetName,
                Metadata = TagsConversionHelper.CreateTagDictionary(tags, validate: true),
                TTL = ttl,
            };

            if (resourceRecords != null && resourceRecords.Length != 0)
            {
                var expectedTypeOfRecords = this.recordTypeValidationEntries[recordType];
                var mismatchedRecord = resourceRecords.FirstOrDefault(x => x.GetType() != expectedTypeOfRecords);
                if (mismatchedRecord != null)
                {
                    throw new ArgumentException(string.Format(ProjectResources.Error_AddRecordTypeMismatch, mismatchedRecord.GetType(), recordType));
                }

                FillRecordsForType(properties, recordType, resourceRecords);
            }
            else
            {
                FillEmptyRecordsForType( properties, recordType);                
            }
            return properties;
        }

        private void FillRecordsForType(RecordSet properties, RecordType recordType, DnsRecordBase[] resourceRecords)
        {
            switch (recordType)
            {
                case RecordType.A:
                    properties.ARecords = resourceRecords.Select(x => (Sdk.ARecord) (x as ARecord).ToMamlRecord()).ToList();
                    break;
                case RecordType.AAAA:
                    properties.AaaaRecords = resourceRecords.Select(x => (Sdk.AaaaRecord)(x as AaaaRecord).ToMamlRecord()).ToList();
                    break;
                case RecordType.CNAME:
                    if (resourceRecords.Length > 1)
                    {
                        throw new ArgumentException(ProjectResources.Error_AddRecordMultipleCnames);
                    }

                    properties.CnameRecord = (Sdk.CnameRecord) resourceRecords[0].ToMamlRecord();
                    break;
                case RecordType.MX:
                    properties.MxRecords = resourceRecords.Select(x => (Sdk.MxRecord)(x as MxRecord).ToMamlRecord()).ToList();
                    break;
                case RecordType.NS:
                    properties.NsRecords = resourceRecords.Select(x => (Sdk.NsRecord)(x as NsRecord).ToMamlRecord()).ToList();
                    break;
                case RecordType.PTR:
                    properties.PtrRecords = resourceRecords.Select(x => (Sdk.PtrRecord)(x as PtrRecord).ToMamlRecord()).ToList();
                    break;
                case RecordType.SRV:
                    properties.SrvRecords = resourceRecords.Select(x => (Sdk.SrvRecord)(x as SrvRecord).ToMamlRecord()).ToList();
                    break;
                case RecordType.TXT:
                    properties.TxtRecords = resourceRecords.Select(x => (Sdk.TxtRecord)(x as TxtRecord).ToMamlRecord()).ToList();
                    break;
                case RecordType.SOA:
                    properties.SoaRecord = (Sdk.SoaRecord) resourceRecords[0].ToMamlRecord();
                    break;
            }
        }

        private void FillEmptyRecordsForType(RecordSet properties, RecordType recordType)
        {
            properties.AaaaRecords = recordType == RecordType.AAAA ? new List<Management.Dns.Models.AaaaRecord>() : null;
            properties.ARecords = recordType == RecordType.A ? new List<Management.Dns.Models.ARecord>() : null;
            properties.CnameRecord = recordType == RecordType.CNAME ? new Management.Dns.Models.CnameRecord(String.Empty) : null;
            properties.MxRecords = recordType == RecordType.MX ? new List<Management.Dns.Models.MxRecord>() : null;
            properties.NsRecords = recordType == RecordType.NS ? new List<Management.Dns.Models.NsRecord>() : null;
            properties.PtrRecords = recordType == RecordType.PTR ? new List<Management.Dns.Models.PtrRecord>() : null;
            properties.SoaRecord = null;
            properties.SrvRecords = recordType == RecordType.SRV ? new List<Management.Dns.Models.SrvRecord>() : null;
            properties.TxtRecords = recordType == RecordType.TXT ? new List<Management.Dns.Models.TxtRecord>() : null;
        }

        public DnsRecordSet UpdateDnsRecordSet(DnsRecordSet recordSet, bool overwrite)
        {
            var response = this.DnsManagementClient.RecordSets.CreateOrUpdate(
                recordSet.ResourceGroupName,
                recordSet.ZoneName,
                recordSet.Name,
                recordSet.RecordType,
                new RecordSet
                {
                    Name = recordSet.Name,
                    TTL = recordSet.Ttl,
                    Metadata = TagsConversionHelper.CreateTagDictionary(recordSet.Metadata, validate: true),
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
                    PtrRecords =
                        recordSet.RecordType == RecordType.PTR
                            ? GetMamlRecords<PtrRecord, Management.Dns.Models.PtrRecord>(recordSet.Records)
                            : null,
                    SoaRecord =
                        recordSet.RecordType == RecordType.SOA
                            ? GetMamlRecords<SoaRecord, Management.Dns.Models.SoaRecord>(recordSet.Records).SingleOrDefault()
                            : null,
                    CnameRecord =
                        recordSet.RecordType == RecordType.CNAME
                            ? GetMamlRecords<CnameRecord, Management.Dns.Models.CnameRecord>(recordSet.Records).SingleOrDefault()
                            : null,
                },
                ifMatch: overwrite ? "*" : recordSet.Etag,
                ifNoneMatch: null);

            return GetPowerShellRecordSet(recordSet.ZoneName, recordSet.ResourceGroupName, response);
        }

        public bool DeleteDnsRecordSet(DnsRecordSet recordSet, bool overwrite)
        {
            this.DnsManagementClient.RecordSets.Delete(
                recordSet.ResourceGroupName,
                recordSet.ZoneName,
                recordSet.Name,
                recordSet.RecordType,
                ifMatch: overwrite ? "*" : recordSet.Etag,
                ifNoneMatch: null);
            return true;
        }

        public DnsRecordSet GetDnsRecordSet(string name, string zoneName, string resourceGroupName, RecordType recordType)
        {
            var getResponse = this.DnsManagementClient.RecordSets.Get(resourceGroupName, zoneName, name, recordType);
            return GetPowerShellRecordSet(zoneName, resourceGroupName, getResponse);
        }

        public List<DnsRecordSet> ListRecordSets(string zoneName, string resourceGroupName, RecordType recordType)
        {
            List<DnsRecordSet> results = new List<DnsRecordSet>();

            IPage<RecordSet> listResponse = null;
            do
            {
                if (listResponse != null && listResponse.NextPageLink != null)
                {
                    listResponse = this.DnsManagementClient.RecordSets.ListByTypeNext(listResponse.NextPageLink);
                }
                else
                {
                    listResponse = this.DnsManagementClient.RecordSets.ListByType(
                                    resourceGroupName,
                                    zoneName,
                                    recordType);
                }

                results.AddRange(listResponse.Select(recordSet => GetPowerShellRecordSet(zoneName, resourceGroupName, recordSet)));
                
            } while (listResponse != null && listResponse.NextPageLink != null);

            return results;
        }

        public List<DnsRecordSet> ListRecordSets(string zoneName, string resourceGroupName)
        {
            var results = new List<DnsRecordSet>();

            IPage<RecordSet> listResponse = null;
            do
            {
                if (listResponse != null && listResponse.NextPageLink != null)
                {
                    listResponse = this.DnsManagementClient.RecordSets.ListAllInResourceGroupNext(listResponse.NextPageLink);
                }
                else
                {
                    listResponse = this.DnsManagementClient.RecordSets.ListAllInResourceGroup(
                                    resourceGroupName,
                                    zoneName);
                }

                results.AddRange(listResponse.Select(recordSet => GetPowerShellRecordSet(zoneName, resourceGroupName, recordSet)));
            } while (listResponse != null && listResponse.NextPageLink != null);

            return results;
        }

        public DnsZone GetDnsZoneHandleNonExistentZone(string zoneName, string resourceGroupName)
        {
            DnsZone retrievedZone = null;
            try
            {
                retrievedZone = this.GetDnsZone(zoneName, resourceGroupName);
            }
            catch (CloudException exception)
            {
                if (exception.Body.Code != "ResourceNotFound")
                {
                    throw;
                }
            }

            return retrievedZone;
        }

        private static DnsRecordSet GetPowerShellRecordSet(string zoneName, string resourceGroupName, Management.Dns.Models.RecordSet mamlRecordSet)
        {
            // e.g. "/subscriptions/<guid>/resourceGroups/<rg>/providers/microsoft.dns/dnszones/<zone>/A/<recordset>"
            string recordTypeAsString = mamlRecordSet.Id.Split('/').Reverse().Skip(1).First();

            RecordType recordType = (RecordType) Enum.Parse(typeof (RecordType), recordTypeAsString, ignoreCase: true);

            return new DnsRecordSet
            {
                Etag = mamlRecordSet.Etag,
                Name = mamlRecordSet.Name,
                RecordType = recordType,
                Records = GetPowerShellRecords(mamlRecordSet),
                Metadata = TagsConversionHelper.CreateTagHashtable(mamlRecordSet.Metadata),
                ResourceGroupName = resourceGroupName,
                Ttl = (uint) mamlRecordSet.TTL.GetValueOrDefault(),
                ZoneName = zoneName,
            };
        }

        private static List<DnsRecordBase> GetPowerShellRecords(Management.Dns.Models.RecordSet recordSet)
        {
            var result = new List<DnsRecordBase>();
            result.AddRange(GetPowerShellRecords(recordSet.AaaaRecords));
            result.AddRange(GetPowerShellRecords(recordSet.ARecords));
            result.AddRange(GetPowerShellRecords(recordSet.MxRecords));
            result.AddRange(GetPowerShellRecords(recordSet.NsRecords));
            result.AddRange(GetPowerShellRecords(recordSet.SrvRecords));
            result.AddRange(GetPowerShellRecords(recordSet.TxtRecords));
            result.AddRange(GetPowerShellRecords(recordSet.PtrRecords));
            if (recordSet.CnameRecord != null)
            {
                result.Add(DnsRecordBase.FromMamlRecord(recordSet.CnameRecord));
            }
            if (recordSet.SoaRecord != null)
            {
                result.Add(DnsRecordBase.FromMamlRecord(recordSet.SoaRecord));
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
                ResourceGroupName = ExtractResourceGroupNameFromId(zone.Id),
                Etag = zone.Etag,
                Tags = TagsConversionHelper.CreateTagHashtable(zone.Tags),
                NameServers = zone.NameServers != null ? zone.NameServers.ToList() : new List<string>(),
                NumberOfRecordSets = zone.NumberOfRecordSets,
                MaxNumberOfRecordSets = zone.MaxNumberOfRecordSets,
            };
        }

        private static string ExtractResourceGroupNameFromId(string id)
        {
            var parts = id.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            int rgIndex = -1;
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Equals("resourceGroups", StringComparison.OrdinalIgnoreCase))
                {
                    rgIndex = i;
                    break;
                }
            }

            if (rgIndex != -1 && rgIndex + 1 < parts.Length)
            {
                return parts[rgIndex + 1];
            }

            throw new FormatException(string.Format("Unable to extract resource group name from {0} ", id));
        }
    }
}

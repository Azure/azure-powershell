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
//
// ----------------------------------------------------------------------------------

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Azure.Core;
using Azure.ResourceManager.AppService;
using Azure.ResourceManager.AppService.Models;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Management.WebSites.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using ArmSnapshotRestoreRequest =
    Azure.ResourceManager.AppService.Models.SnapshotRestoreRequest;
using ArmSnapshotRecoverySource =
    Azure.ResourceManager.AppService.Models.SnapshotRecoverySource;
using CompatAppServiceEnvironmentResource =
    Microsoft.Azure.Management.WebSites.Models.AppServiceEnvironmentResource;
using CompatConnectionStringPair =
    Microsoft.Azure.Management.WebSites.Models.ConnStringValueTypePair;
using CompatConnectionStringInfo =
    Microsoft.Azure.Management.WebSites.Models.ConnStringInfo;
using CompatSlotConfigNamesResource =
    Microsoft.Azure.Management.WebSites.Models.SlotConfigNamesResource;
using CompatSiteConfigurationSnapshotInfo =
    Microsoft.Azure.Management.WebSites.Models.SiteConfigurationSnapshotInfo;
using CompatSnapshotRestoreRequest =
    Microsoft.Azure.Management.WebSites.Models.SnapshotRestoreRequest;

namespace Microsoft.Azure.Commands.WebApps.Utilities
{
    internal static class AppServiceModelConverter
    {
        private static readonly JsonSerializer Serializer = CreateSerializer();

        private static readonly HashSet<string> TopLevelProperties =
            new HashSet<string>(
                new[]
                {
                    "id",
                    "name",
                    "type",
                    "kind",
                    "location",
                    "tags",
                    "sku",
                    "identity",
                    "extendedLocation",
                    "systemData"
                },
                StringComparer.OrdinalIgnoreCase);

        private static readonly IDictionary<Type, string> DefaultResourceTypes =
            new Dictionary<Type, string>
            {
                [typeof(WebSiteData)] = "Microsoft.Web/sites",
                [typeof(SiteConfigData)] = "Microsoft.Web/sites/config",
                [typeof(AppServicePlanData)] = "Microsoft.Web/serverfarms",
                [typeof(AppCertificateData)] = "Microsoft.Web/certificates",
                [typeof(AppServiceEnvironmentData)] =
                    "Microsoft.Web/hostingEnvironments",
                [typeof(WebAppBackupInfo)] = "Microsoft.Web/sites/config",
                [typeof(RestoreRequestInfo)] = "Microsoft.Web/sites",
                [typeof(AzureStoragePropertyDictionary)] =
                    "Microsoft.Web/sites/config",
                [typeof(ConnectionStringDictionary)] =
                    "Microsoft.Web/sites/config",
                [typeof(AppServiceConfigurationDictionary)] =
                    "Microsoft.Web/sites/config",
                [typeof(SlotConfigNamesResourceData)] =
                    "Microsoft.Web/sites/config"
            };

        internal static Site FromWebSiteData(WebSiteData source)
        {
            Site result = FromResourceData<Site>(source);
            if (result != null)
            {
                result.Location = source.Location.DisplayName;
            }
            return result;
        }

        internal static WebSiteData ToWebSiteData(Site source)
        {
            return ToResourceData<WebSiteData>(
                source == null ? null : new Site(source),
                source?.NativeData);
        }

        internal static SiteConfig FromSiteConfigData(SiteConfigData source)
        {
            return FromResourceData<SiteConfig>(source);
        }

        internal static SiteConfigData ToSiteConfigData(SiteConfig source)
        {
            return ToResourceData<SiteConfigData>(source, source?.NativeData);
        }

        internal static AppServicePlan FromAppServicePlanData(
            AppServicePlanData source)
        {
            AppServicePlan result = FromResourceData<AppServicePlan>(source);
            if (result != null)
            {
                result.Location = source.Location.DisplayName;
                result.NumberOfSites = source.NumberOfSites;
            }
            return result;
        }

        internal static AppServicePlanData ToAppServicePlanData(
            AppServicePlan source)
        {
            return ToResourceData<AppServicePlanData>(
                source == null ? null : new AppServicePlan(source),
                source?.NativeData);
        }

        internal static Certificate FromAppCertificateData(
            AppCertificateData source)
        {
            Certificate result = FromResourceData<Certificate>(source);
            if (result != null)
            {
                result.Location = source.Location.DisplayName;
                result.Thumbprint =
                    source.ThumbprintString ?? result.Thumbprint;
            }
            return result;
        }

        internal static Certificate FromAppCertificateJson(JObject source)
        {
            Certificate result = FromResourceJson<Certificate>(source);
            JObject properties = source?["properties"] as JObject;
            if (result != null && properties != null)
            {
                result.Thumbprint =
                    properties
                        .GetValue(
                            "thumbprint",
                            StringComparison.OrdinalIgnoreCase)
                        ?.Value<string>() ??
                    result.Thumbprint;
            }
            if (result != null &&
                string.IsNullOrEmpty(result.Thumbprint) &&
                result.CerBlob?.Length > 0)
            {
                using (var certificate = new X509Certificate2(result.CerBlob))
                {
                    result.Thumbprint = certificate.Thumbprint;
                }
            }
            return result;
        }

        internal static AppCertificateData ToAppCertificateData(
            Certificate source)
        {
            return ToResourceData<AppCertificateData>(source, source?.NativeData);
        }

        internal static CompatAppServiceEnvironmentResource
            FromAppServiceEnvironmentData(AppServiceEnvironmentData source)
        {
            CompatAppServiceEnvironmentResource result =
                FromResourceData<CompatAppServiceEnvironmentResource>(source);
            if (result != null)
            {
                result.Location = source.Location.DisplayName;
            }
            return result;
        }

        internal static AppServiceEnvironmentData ToAppServiceEnvironmentData(
            CompatAppServiceEnvironmentResource source)
        {
            return ToResourceData<AppServiceEnvironmentData>(
                source,
                source?.NativeData);
        }

        internal static AddressResponse FromAppServiceEnvironmentAddressResult(
            AppServiceEnvironmentAddressResult source)
        {
            return FromResourceData<AddressResponse>(source);
        }

        internal static VnetInfo FromAppServiceVirtualNetworkData(
            AppServiceVirtualNetworkData source)
        {
            return FromResourceData<VnetInfo>(source);
        }

        internal static BackupRequest FromWebAppBackupInfo(
            WebAppBackupInfo source)
        {
            return FromResourceData<BackupRequest>(source);
        }

        internal static WebAppBackupInfo ToWebAppBackupInfo(
            BackupRequest source)
        {
            return ToResourceData<WebAppBackupInfo>(source, source?.NativeData);
        }

        internal static BackupItem FromWebAppBackupData(WebAppBackupData source)
        {
            BackupItem result = FromResourceData<BackupItem>(source);
            if (result != null)
            {
                result.BackupId = source.BackupId ?? result.BackupId;
                result.BackupItemName =
                    source.BackupName ?? result.BackupItemName;
                result.BlobName = source.BlobName ?? result.BlobName;
                result.CorrelationId =
                    source.CorrelationId ?? result.CorrelationId;
                result.Created =
                    source.CreatedOn?.DateTime ?? result.Created;
                result.FinishedTimeStamp =
                    source.FinishedOn?.DateTime ?? result.FinishedTimeStamp;
                result.LastRestoreTimeStamp =
                    source.LastRestoreOn?.DateTime ??
                    result.LastRestoreTimeStamp;
                result.Log = source.Log ?? result.Log;
                result.Scheduled = source.IsScheduled ?? result.Scheduled;
                result.SizeInBytes = source.SizeInBytes ?? result.SizeInBytes;
                result.StorageAccountUrl =
                    source.StorageAccountUri?.OriginalString ??
                    result.StorageAccountUrl;
                result.WebsiteSizeInBytes =
                    source.WebsiteSizeInBytes ?? result.WebsiteSizeInBytes;
            }
            return result;
        }

        internal static BackupItem FromWebAppBackupJson(JObject source)
        {
            BackupItem result = FromResourceJson<BackupItem>(source);
            JObject properties = source?["properties"] as JObject;
            if (result != null && properties != null)
            {
                result.BackupId = properties.Value<int?>("id");
                result.BackupItemName =
                    properties.Value<string>("backupName") ??
                    properties.Value<string>("name");
                result.StorageAccountUrl =
                    properties.Value<string>("storageAccountUrl");
            }
            return result;
        }

        internal static RestoreRequestInfo ToRestoreRequestInfo(
            RestoreRequest source)
        {
            return ToResourceData<RestoreRequestInfo>(source, source?.NativeData);
        }

        internal static AzureStoragePropertyDictionaryResource
            FromAzureStoragePropertyDictionary(
                AzureStoragePropertyDictionary source)
        {
            if (source == null)
            {
                return null;
            }

            JObject wire = ToJObject(source);
            var result = new AzureStoragePropertyDictionaryResource
            {
                NativeData = source,
                Kind = wire.Value<string>("kind"),
                Properties = wire["properties"]?.ToObject<
                    Dictionary<string, AzureStorageInfoValue>>(Serializer)
            };
            return result;
        }

        internal static AzureStoragePropertyDictionary
            ToAzureStoragePropertyDictionary(
                AzureStoragePropertyDictionaryResource source)
        {
            JObject wire = source?.NativeData == null
                ? new JObject()
                : ToJObject(source.NativeData);
            wire["kind"] = source?.Kind;
            wire["properties"] = source?.Properties == null
                ? new JObject()
                : JObject.FromObject(source.Properties, Serializer);
            return ReadModel<AzureStoragePropertyDictionary>(wire);
        }

        internal static ConnectionStringDictionary ToConnectionStringDictionary(
            IDictionary<string, CompatConnectionStringInfo> source)
        {
            var properties = new Dictionary<string, CompatConnectionStringPair>(
                StringComparer.OrdinalIgnoreCase);
            if (source != null)
            {
                foreach (var item in source)
                {
                    properties[item.Key] = new CompatConnectionStringPair
                    {
                        Value = item.Value.ConnectionString,
                        Type = item.Value.Type.GetValueOrDefault()
                    };
                }
            }
            return ToConnectionStringDictionary(properties);
        }

        internal static ConnectionStringDictionary ToConnectionStringDictionary(
            IDictionary<string, CompatConnectionStringPair> source)
        {
            var wire = new JObject
            {
                ["properties"] = source == null
                    ? new JObject()
                    : JObject.FromObject(source, Serializer)
            };
            return ReadModel<ConnectionStringDictionary>(wire);
        }

        internal static IDictionary<string, CompatConnectionStringInfo>
            FromConnectionStringDictionary(ConnectionStringDictionary source)
        {
            if (source == null)
            {
                return null;
            }

            JObject properties = ToJObject(source)["properties"] as JObject;
            if (properties == null)
            {
                return new Dictionary<string, CompatConnectionStringInfo>(
                    StringComparer.OrdinalIgnoreCase);
            }

            var result = new Dictionary<string, CompatConnectionStringInfo>(
                StringComparer.OrdinalIgnoreCase);
            foreach (JProperty property in properties.Properties())
            {
                CompatConnectionStringPair pair =
                    property.Value.ToObject<CompatConnectionStringPair>(
                        Serializer);
                result[property.Name] = new CompatConnectionStringInfo(
                    property.Name,
                    pair.Value,
                    pair.Type);
            }
            return result;
        }

        internal static AppServiceConfigurationDictionary ToAppSettings(
            IDictionary<string, string> source)
        {
            var wire = new JObject
            {
                ["properties"] = source == null
                    ? new JObject()
                    : JObject.FromObject(source, Serializer)
            };
            return ReadModel<AppServiceConfigurationDictionary>(wire);
        }

        internal static IDictionary<string, string> FromAppSettings(
            AppServiceConfigurationDictionary source)
        {
            return source == null
                ? null
                : ToJObject(source)["properties"]?.ToObject<
                    Dictionary<string, string>>(Serializer);
        }

        internal static DeletedSite FromDeletedSiteData(DeletedSiteData source)
        {
            return FromResourceData<DeletedSite>(source);
        }

        internal static Snapshot FromAppSnapshot(AppSnapshot source)
        {
            return FromResourceData<Snapshot>(source);
        }

        internal static CompatSiteConfigurationSnapshotInfo
            FromSiteConfigurationSnapshotInfo(
            global::Azure.ResourceManager.AppService.Models
                .SiteConfigurationSnapshotInfo source)
        {
            if (source == null)
            {
                return null;
            }

            var result =
                FromResourceData<CompatSiteConfigurationSnapshotInfo>(source);
            result.Time = source.SnapshotTakenOn?.UtcDateTime;
            return result;
        }

        internal static User FromPublishingUserData(PublishingUserData source)
        {
            return FromResourceData<User>(source);
        }

        internal static CompatSlotConfigNamesResource
            FromSlotConfigNamesResourceData(SlotConfigNamesResourceData source)
        {
            return FromResourceData<CompatSlotConfigNamesResource>(source);
        }

        internal static CompatSlotConfigNamesResource
            FromSlotConfigNamesJson(JObject source)
        {
            return FromResourceJson<CompatSlotConfigNamesResource>(source);
        }

        internal static JObject ToSlotConfigNamesJson(
            CompatSlotConfigNamesResource source)
        {
            var properties = new JObject();
            if (source?.AppSettingNames != null)
            {
                properties["appSettingNames"] =
                    JArray.FromObject(source.AppSettingNames, Serializer);
            }
            if (source?.ConnectionStringNames != null)
            {
                properties["connectionStringNames"] =
                    JArray.FromObject(source.ConnectionStringNames, Serializer);
            }
            if (source?.AzureStorageConfigNames != null)
            {
                properties["azureStorageConfigNames"] =
                    JArray.FromObject(source.AzureStorageConfigNames, Serializer);
            }
            return new JObject { ["properties"] = properties };
        }

        internal static IList<DeletedSite> FromDeletedSitesJson(JObject source)
        {
            return source?["value"]?
                       .OfType<JObject>()
                       .Select(FromResourceJson<DeletedSite>)
                       .ToList() ??
                   new List<DeletedSite>();
        }

        internal static SlotConfigNamesResourceData
            ToSlotConfigNamesResourceData(CompatSlotConfigNamesResource source)
        {
            return ToResourceData<SlotConfigNamesResourceData>(
                source,
                source?.NativeData);
        }

        internal static ArmSnapshotRestoreRequest ToSnapshotRestoreRequest(
            CompatSnapshotRestoreRequest source)
        {
            if (source == null)
            {
                return null;
            }

            return new ArmSnapshotRestoreRequest
            {
                Kind = source.Kind,
                CanOverwrite = source.Overwrite,
                SnapshotTime = source.SnapshotTime,
                RecoverySource = source.RecoverySource == null
                    ? null
                    : new ArmSnapshotRecoverySource
                    {
                        Id = string.IsNullOrEmpty(source.RecoverySource.Id)
                            ? null
                            : new ResourceIdentifier(source.RecoverySource.Id),
                        Location = string.IsNullOrEmpty(
                            source.RecoverySource.Location)
                            ? null
                            : new AzureLocation(
                                source.RecoverySource.Location)
                    },
                RecoverConfiguration = source.RecoverConfiguration,
                IgnoreConflictingHostNames =
                    source.IgnoreConflictingHostNames,
                UseDRSecondary = source.UseDRSecondary
            };
        }

        internal static DeletedAppRestoreContent ToDeletedAppRestoreContent(
            DeletedAppRestoreRequest source)
        {
            if (source == null)
            {
                return null;
            }

            return new DeletedAppRestoreContent
            {
                Kind = source.Kind,
                DeletedSiteId = string.IsNullOrEmpty(source.DeletedSiteId)
                    ? null
                    : new ResourceIdentifier(source.DeletedSiteId),
                RecoverConfiguration = source.RecoverConfiguration,
                SnapshotTime = source.SnapshotTime,
                UseDRSecondary = source.UseDRSecondary
            };
        }

        private static T FromResourceData<T>(object source)
            where T : class
        {
            if (source == null)
            {
                return null;
            }

            JObject flattened = FlattenResourceData(ToJObject(source));
            T result = flattened.ToObject<T>(Serializer);
            if (result is Resource resource)
            {
                resource.NativeData = source;
            }
            else if (result is ProxyOnlyResource proxyResource)
            {
                proxyResource.NativeData = source;
            }
            else if (result is SiteConfig config)
            {
                config.NativeData = source;
            }
            return result;
        }

        private static T ToResourceData<T>(object source, object nativeData)
        {
            if (source == null)
            {
                return default(T);
            }

            JObject wire = nativeData == null
                ? new JObject()
                : ToJObject(nativeData);
            foreach (string propertyName in new[] { "id", "name", "type" })
            {
                if (wire[propertyName]?.Type == JTokenType.Null)
                {
                    wire.Remove(propertyName);
                }
            }
            JObject properties = wire["properties"] as JObject ?? new JObject();
            JObject flattened = JObject.FromObject(source, Serializer);

            foreach (JProperty property in flattened.Properties())
            {
                JToken value = property.Value.DeepClone();
                if (value.Type == JTokenType.Null &&
                    (string.Equals(
                         property.Name,
                         "id",
                         StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(
                         property.Name,
                         "name",
                         StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(
                         property.Name,
                         "type",
                         StringComparison.OrdinalIgnoreCase)))
                {
                    continue;
                }

                if (TopLevelProperties.Contains(property.Name))
                {
                    wire[property.Name] = value;
                }
                else
                {
                    properties[property.Name] = value;
                }
            }

            wire["properties"] = properties;
            return ReadModel<T>(wire);
        }

        private static T FromResourceJson<T>(JObject wire)
            where T : class
        {
            return wire == null
                ? null
                : FlattenResourceData(wire).ToObject<T>(Serializer);
        }

        private static JObject FlattenResourceData(JObject wire)
        {
            var result = wire["properties"] is JObject properties
                ? (JObject)properties.DeepClone()
                : new JObject();

            foreach (JProperty property in wire.Properties())
            {
                if (!string.Equals(
                        property.Name,
                        "properties",
                        StringComparison.OrdinalIgnoreCase))
                {
                    result[property.Name] = property.Value.DeepClone();
                }
            }
            return result;
        }

        private static JObject ToJObject(object model)
        {
            BinaryData data = ModelReaderWriter.Write(model);
            return JObject.Parse(data.ToString());
        }

        private static T ReadModel<T>(JObject wire)
        {
            if ((wire["type"] == null ||
                 wire["type"].Type == JTokenType.Null) &&
                DefaultResourceTypes.TryGetValue(
                    typeof(T),
                    out string resourceType))
            {
                wire["type"] = resourceType;
            }

            return ModelReaderWriter.Read<T>(
                BinaryData.FromString(wire.ToString(Formatting.None)));
        }

        private static JsonSerializer CreateSerializer()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy
                    {
                        ProcessDictionaryKeys = false
                    }
                },
                NullValueHandling = NullValueHandling.Include
            };
            settings.Converters.Add(new StringEnumConverter());
            return JsonSerializer.Create(settings);
        }
    }
}

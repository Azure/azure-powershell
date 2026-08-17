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
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Microsoft.Azure.Management.WebSites.Models
{
    public class ProxyOnlyResource : Microsoft.Rest.Azure.IResource
    {
        public ProxyOnlyResource()
        {
        }

        public ProxyOnlyResource(
            string id = null,
            string name = null,
            string kind = null,
            string type = null)
        {
            Id = id;
            Name = name;
            Kind = kind;
            Type = type;
        }

        internal object NativeData { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Kind { get; set; }
    }

    public class Resource : Microsoft.Rest.Azure.IResource
    {
        public Resource()
        {
        }

        public Resource(
            string location,
            string id = null,
            string name = null,
            string kind = null,
            string type = null,
            IDictionary<string, string> tags = null)
        {
            Id = id;
            Name = name;
            Kind = kind;
            Location = location;
            Type = type;
            Tags = tags;
        }

        internal object NativeData { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Kind { get; set; }

        public string Location { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        public virtual void Validate()
        {
            if (Location == null)
            {
                throw new Microsoft.Rest.ValidationException(
                    Microsoft.Rest.ValidationRules.CannotBeNull,
                    nameof(Location));
            }
        }
    }

    public class Site : Resource
    {
        public Site()
        {
        }

        public Site(Site other)
        {
            if (other == null)
            {
                return;
            }

            Id = other.Id;
            Name = other.Name;
            Type = other.Type;
            Kind = other.Kind;
            Location = other.Location;
            Tags = other.Tags;
            NativeData = other.NativeData;
            State = other.State;
            HostNames = other.HostNames;
            RepositorySiteName = other.RepositorySiteName;
            UsageState = other.UsageState;
            Enabled = other.Enabled;
            EnabledHostNames = other.EnabledHostNames;
            AvailabilityState = other.AvailabilityState;
            HostNameSslStates = other.HostNameSslStates;
            ServerFarmId = other.ServerFarmId;
            Reserved = other.Reserved;
            IsXenon = other.IsXenon;
            HyperV = other.HyperV;
            LastModifiedTimeUtc = other.LastModifiedTimeUtc;
            SiteConfig = other.SiteConfig;
            TrafficManagerHostNames = other.TrafficManagerHostNames;
            ScmSiteAlsoStopped = other.ScmSiteAlsoStopped;
            TargetSwapSlot = other.TargetSwapSlot;
            HostingEnvironmentProfile = other.HostingEnvironmentProfile;
            ClientAffinityEnabled = other.ClientAffinityEnabled;
            ClientCertEnabled = other.ClientCertEnabled;
            ClientCertMode = other.ClientCertMode;
            ClientCertExclusionPaths = other.ClientCertExclusionPaths;
            HostNamesDisabled = other.HostNamesDisabled;
            CustomDomainVerificationId = other.CustomDomainVerificationId;
            OutboundIpAddresses = other.OutboundIpAddresses;
            PossibleOutboundIpAddresses = other.PossibleOutboundIpAddresses;
            ContainerSize = other.ContainerSize;
            DailyMemoryTimeQuota = other.DailyMemoryTimeQuota;
            SuspendedTill = other.SuspendedTill;
            MaxNumberOfWorkers = other.MaxNumberOfWorkers;
            CloningInfo = other.CloningInfo;
            ResourceGroup = other.ResourceGroup;
            IsDefaultContainer = other.IsDefaultContainer;
            DefaultHostName = other.DefaultHostName;
            SlotSwapStatus = other.SlotSwapStatus;
            HttpsOnly = other.HttpsOnly;
            RedundancyMode = other.RedundancyMode;
            InProgressOperationId = other.InProgressOperationId;
            StorageAccountRequired = other.StorageAccountRequired;
            KeyVaultReferenceIdentity = other.KeyVaultReferenceIdentity;
            VirtualNetworkSubnetId = other.VirtualNetworkSubnetId;
            Identity = other.Identity;
            ExtendedLocation = other.ExtendedLocation;
        }

        public string State { get; set; }

        public IList<string> HostNames { get; set; }

        public string RepositorySiteName { get; set; }

        public UsageState? UsageState { get; set; }

        public bool? Enabled { get; set; }

        public IList<string> EnabledHostNames { get; set; }

        public SiteAvailabilityState? AvailabilityState { get; set; }

        public IList<HostNameSslState> HostNameSslStates { get; set; }

        public string ServerFarmId { get; set; }

        public bool? Reserved { get; set; }

        public bool? IsXenon { get; set; }

        public bool? HyperV { get; set; }

        public DateTime? LastModifiedTimeUtc { get; set; }

        public SiteConfig SiteConfig { get; set; }

        public IList<string> TrafficManagerHostNames { get; set; }

        public bool? ScmSiteAlsoStopped { get; set; }

        public string TargetSwapSlot { get; set; }

        public HostingEnvironmentProfile HostingEnvironmentProfile { get; set; }

        public bool? ClientAffinityEnabled { get; set; }

        public bool? ClientCertEnabled { get; set; }

        public ClientCertMode? ClientCertMode { get; set; }

        public string ClientCertExclusionPaths { get; set; }

        public bool? HostNamesDisabled { get; set; }

        public string CustomDomainVerificationId { get; set; }

        public string OutboundIpAddresses { get; set; }

        public string PossibleOutboundIpAddresses { get; set; }

        public int? ContainerSize { get; set; }

        public int? DailyMemoryTimeQuota { get; set; }

        public DateTime? SuspendedTill { get; set; }

        public int? MaxNumberOfWorkers { get; set; }

        public CloningInfo CloningInfo { get; set; }

        public string ResourceGroup { get; set; }

        public bool? IsDefaultContainer { get; set; }

        public string DefaultHostName { get; set; }

        public SlotSwapStatus SlotSwapStatus { get; set; }

        public bool? HttpsOnly { get; set; }

        public RedundancyMode? RedundancyMode { get; set; }

        public Guid? InProgressOperationId { get; set; }

        public bool? StorageAccountRequired { get; set; }

        public string KeyVaultReferenceIdentity { get; set; }

        public string VirtualNetworkSubnetId { get; set; }

        public ManagedServiceIdentity Identity { get; set; }

        public ExtendedLocation ExtendedLocation { get; set; }
    }

    public class SiteConfig
    {
        internal object NativeData { get; set; }

        public int? NumberOfWorkers { get; set; }

        public IList<string> DefaultDocuments { get; set; }

        public string NetFrameworkVersion { get; set; }

        public string PhpVersion { get; set; }

        public string PythonVersion { get; set; }

        public string NodeVersion { get; set; }

        public string PowerShellVersion { get; set; }

        public string LinuxFxVersion { get; set; }

        public string WindowsFxVersion { get; set; }

        public bool? RequestTracingEnabled { get; set; }

        public DateTime? RequestTracingExpirationTime { get; set; }

        public bool? RemoteDebuggingEnabled { get; set; }

        public string RemoteDebuggingVersion { get; set; }

        public bool? HttpLoggingEnabled { get; set; }

        public bool? AcrUseManagedIdentityCreds { get; set; }

        public string AcrUserManagedIdentityID { get; set; }

        public int? LogsDirectorySizeLimit { get; set; }

        public bool? DetailedErrorLoggingEnabled { get; set; }

        public string PublishingUsername { get; set; }

        public IList<NameValuePair> AppSettings { get; set; }

        public IList<ConnStringInfo> ConnectionStrings { get; set; }

        public SiteMachineKey MachineKey { get; set; }

        public IList<HandlerMapping> HandlerMappings { get; set; }

        public string DocumentRoot { get; set; }

        public string ScmType { get; set; }

        public bool? Use32BitWorkerProcess { get; set; }

        public bool? WebSocketsEnabled { get; set; }

        public bool? AlwaysOn { get; set; }

        public string JavaVersion { get; set; }

        public string JavaContainer { get; set; }

        public string JavaContainerVersion { get; set; }

        public string AppCommandLine { get; set; }

        public ManagedPipelineMode? ManagedPipelineMode { get; set; }

        public IList<VirtualApplication> VirtualApplications { get; set; }

        public SiteLoadBalancing? LoadBalancing { get; set; }

        public Experiments Experiments { get; set; }

        public SiteLimits Limits { get; set; }

        public bool? AutoHealEnabled { get; set; }

        public AutoHealRules AutoHealRules { get; set; }

        public string TracingOptions { get; set; }

        public string VnetName { get; set; }

        public bool? VnetRouteAllEnabled { get; set; }

        public int? VnetPrivatePortsCount { get; set; }

        public CorsSettings Cors { get; set; }

        public PushSettings Push { get; set; }

        public ApiDefinitionInfo ApiDefinition { get; set; }

        public ApiManagementConfig ApiManagementConfig { get; set; }

        public string AutoSwapSlotName { get; set; }

        public bool? LocalMySqlEnabled { get; set; }

        public int? ManagedServiceIdentityId { get; set; }

        public int? XManagedServiceIdentityId { get; set; }

        public string KeyVaultReferenceIdentity { get; set; }

        public IList<IpSecurityRestriction> IpSecurityRestrictions { get; set; }

        public IList<IpSecurityRestriction> ScmIpSecurityRestrictions { get; set; }

        public bool? ScmIpSecurityRestrictionsUseMain { get; set; }

        public bool? Http20Enabled { get; set; }

        public string MinTlsVersion { get; set; }

        public string ScmMinTlsVersion { get; set; }

        public string FtpsState { get; set; }

        public int? PreWarmedInstanceCount { get; set; }

        public int? FunctionAppScaleLimit { get; set; }

        public string HealthCheckPath { get; set; }

        public bool? FunctionsRuntimeScaleMonitoringEnabled { get; set; }

        public string WebsiteTimeZone { get; set; }

        public int? MinimumElasticInstanceCount { get; set; }

        public IDictionary<string, AzureStorageInfoValue> AzureStorageAccounts { get; set; }

        public string PublicNetworkAccess { get; set; }
    }

    public class AppServicePlan : Resource
    {
        public AppServicePlan()
        {
        }

        public AppServicePlan(AppServicePlan other)
        {
            if (other == null)
            {
                return;
            }

            Id = other.Id;
            Name = other.Name;
            Type = other.Type;
            Kind = other.Kind;
            Location = other.Location;
            Tags = other.Tags;
            NativeData = other.NativeData;
            WorkerTierName = other.WorkerTierName;
            Status = other.Status;
            Subscription = other.Subscription;
            HostingEnvironmentProfile = other.HostingEnvironmentProfile;
            MaximumNumberOfWorkers = other.MaximumNumberOfWorkers;
            GeoRegion = other.GeoRegion;
            PerSiteScaling = other.PerSiteScaling;
            ElasticScaleEnabled = other.ElasticScaleEnabled;
            MaximumElasticWorkerCount = other.MaximumElasticWorkerCount;
            NumberOfSites = other.NumberOfSites;
            IsSpot = other.IsSpot;
            SpotExpirationTime = other.SpotExpirationTime;
            FreeOfferExpirationTime = other.FreeOfferExpirationTime;
            ResourceGroup = other.ResourceGroup;
            Reserved = other.Reserved;
            IsXenon = other.IsXenon;
            HyperV = other.HyperV;
            TargetWorkerCount = other.TargetWorkerCount;
            TargetWorkerSizeId = other.TargetWorkerSizeId;
            ProvisioningState = other.ProvisioningState;
            KubeEnvironmentProfile = other.KubeEnvironmentProfile;
            Sku = other.Sku;
            ExtendedLocation = other.ExtendedLocation;
        }

        public string WorkerTierName { get; set; }

        public StatusOptions? Status { get; set; }

        public string Subscription { get; set; }

        public HostingEnvironmentProfile HostingEnvironmentProfile { get; set; }

        public int? MaximumNumberOfWorkers { get; set; }

        public string GeoRegion { get; set; }

        public bool? PerSiteScaling { get; set; }

        public bool? ElasticScaleEnabled { get; set; }

        public int? MaximumElasticWorkerCount { get; set; }

        public int? NumberOfSites { get; set; }

        public bool? IsSpot { get; set; }

        public DateTime? SpotExpirationTime { get; set; }

        public DateTime? FreeOfferExpirationTime { get; set; }

        public string ResourceGroup { get; set; }

        public bool? Reserved { get; set; }

        public bool? IsXenon { get; set; }

        public bool? HyperV { get; set; }

        public int? TargetWorkerCount { get; set; }

        public int? TargetWorkerSizeId { get; set; }

        public ProvisioningState? ProvisioningState { get; set; }

        public KubeEnvironmentProfile KubeEnvironmentProfile { get; set; }

        public SkuDescription Sku { get; set; }

        public ExtendedLocation ExtendedLocation { get; set; }
    }

    public class KubeEnvironmentProfile
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
    }

    public class ExtendedLocation
    {
        public string Name { get; set; }

        public string Type { get; set; }
    }

    public class SkuDescription
    {
        public string Name { get; set; }

        public string Tier { get; set; }

        public string Size { get; set; }

        public string Family { get; set; }

        public int? Capacity { get; set; }

        public SkuCapacity SkuCapacity { get; set; }

        public IList<string> Locations { get; set; }

        public IList<Capability> Capabilities { get; set; }
    }

    public class SkuCapacity
    {
        public int? Minimum { get; set; }

        public int? Maximum { get; set; }

        public int? ElasticMaximum { get; set; }

        [JsonProperty("default")]
        public int? DefaultProperty { get; set; }

        public string ScaleType { get; set; }
    }

    public class Capability
    {
        public Capability()
        {
        }

        public Capability(string name, string value, string reason = null)
        {
            Name = name;
            Value = value;
            Reason = reason;
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public string Reason { get; set; }
    }

    public class NameValuePair
    {
        public NameValuePair()
        {
        }

        public NameValuePair(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }

        public string Value { get; set; }
    }

    public class ConnStringInfo
    {
        public ConnStringInfo()
        {
        }

        public ConnStringInfo(
            string name,
            string connectionString,
            ConnectionStringType? type = null)
        {
            Name = name;
            ConnectionString = connectionString;
            Type = type;
        }

        public string Name { get; set; }

        public string ConnectionString { get; set; }

        public ConnectionStringType? Type { get; set; }
    }

    public class ConnStringValueTypePair
    {
        public string Value { get; set; }

        public ConnectionStringType Type { get; set; }
    }

    public enum ConnectionStringType
    {
        MySql,
        SQLServer,
        SQLAzure,
        Custom,
        NotificationHub,
        ServiceBus,
        EventHub,
        ApiHub,
        DocDb,
        RedisCache,
        PostgreSQL
    }

    public class HandlerMapping
    {
        public string Extension { get; set; }

        public string ScriptProcessor { get; set; }

        public string Arguments { get; set; }
    }

    public class Experiments
    {
        public Experiments()
        {
            RampUpRules = new List<RampUpRule>();
        }

        public IList<RampUpRule> RampUpRules { get; set; }
    }

    public class RampUpRule
    {
        public string ActionHostName { get; set; }

        public double? ReroutePercentage { get; set; }

        public double? ChangeStep { get; set; }

        public int? ChangeIntervalInMinutes { get; set; }

        public double? MinReroutePercentage { get; set; }

        public double? MaxReroutePercentage { get; set; }

        public string ChangeDecisionCallbackUrl { get; set; }

        public string Name { get; set; }
    }

    public class IpSecurityRestriction
    {
        public IpSecurityRestriction()
        {
        }

        public IpSecurityRestriction(
            string ipAddress = null,
            string subnetMask = null,
            string vnetSubnetResourceId = null,
            int? vnetTrafficTag = null,
            int? subnetTrafficTag = null,
            string action = null,
            string tag = null,
            int? priority = null,
            string name = null,
            string description = null,
            IDictionary<string, IList<string>> headers = null)
        {
            IpAddress = ipAddress;
            SubnetMask = subnetMask;
            VnetSubnetResourceId = vnetSubnetResourceId;
            VnetTrafficTag = vnetTrafficTag;
            SubnetTrafficTag = subnetTrafficTag;
            Action = action;
            Tag = tag;
            Priority = priority;
            Name = name;
            Description = description;
            Headers = headers;
        }

        public string IpAddress { get; set; }

        public string SubnetMask { get; set; }

        public string VnetSubnetResourceId { get; set; }

        public int? VnetTrafficTag { get; set; }

        public int? SubnetTrafficTag { get; set; }

        public string Action { get; set; }

        public string Tag { get; set; }

        public int? Priority { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IDictionary<string, IList<string>> Headers { get; set; }
    }

    public class ManagedServiceIdentity
    {
        public ManagedServiceIdentity()
        {
        }

        public ManagedServiceIdentity(
            ManagedServiceIdentityType? type,
            string tenantId,
            string principalId,
            IDictionary<string, UserAssignedIdentity> userAssignedIdentities = null)
        {
            Type = type;
            TenantId = tenantId;
            PrincipalId = principalId;
            UserAssignedIdentities = userAssignedIdentities;
        }

        public ManagedServiceIdentityType? Type { get; set; }

        public string TenantId { get; set; }

        public string PrincipalId { get; set; }

        public IDictionary<string, UserAssignedIdentity> UserAssignedIdentities { get; set; }
    }

    public class UserAssignedIdentity
    {
        public UserAssignedIdentity()
        {
        }

        public UserAssignedIdentity(string principalId, string clientId)
        {
            PrincipalId = principalId;
            ClientId = clientId;
        }

        public string ClientId { get; set; }

        public string PrincipalId { get; set; }
    }

    public enum ManagedServiceIdentityType
    {
        SystemAssigned,
        UserAssigned,
        [EnumMember(Value = "SystemAssigned, UserAssigned")]
        SystemAssignedUserAssigned,
        None
    }

    public class CloningInfo
    {
        public string SourceWebAppId { get; set; }

        public string SourceWebAppLocation { get; set; }

        public Guid? CorrelationId { get; set; }

        public bool? Overwrite { get; set; }

        public bool? CloneCustomHostNames { get; set; }

        public bool? CloneSourceControl { get; set; }

        public string HostingEnvironment { get; set; }

        public IDictionary<string, string> AppSettingsOverrides { get; set; }

        public bool? ConfigureLoadBalancing { get; set; }

        public string TrafficManagerProfileId { get; set; }

        public string TrafficManagerProfileName { get; set; }
    }

    public class HostingEnvironmentProfile
    {
        public HostingEnvironmentProfile()
        {
        }

        public HostingEnvironmentProfile(string id = null, string name = null, string type = null)
        {
            Id = id;
            Name = name;
            Type = type;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
    }

    public class HostNameSslState
    {
        public string Name { get; set; }

        public SslState? SslState { get; set; }

        public string VirtualIP { get; set; }

        public string Thumbprint { get; set; }

        public bool? ToUpdate { get; set; }

        public HostType? HostType { get; set; }
    }

    public enum SslState
    {
        Disabled,
        SniEnabled,
        IpBasedEnabled
    }

    public enum HostType
    {
        Standard,
        Repository
    }

    public enum AzureResourceType
    {
        Website,
        TrafficManager
    }

    public enum CustomHostNameDnsRecordType
    {
        CName,
        A
    }

    public enum HostNameType
    {
        Verified,
        Managed
    }

    public class Certificate : Resource
    {
        public Certificate()
        {
        }

        public Certificate(
            string location,
            string id = null,
            string name = null,
            string kind = null,
            string type = null,
            IDictionary<string, string> tags = null,
            string password = null,
            string friendlyName = null,
            string subjectName = null,
            IList<string> hostNames = null,
            byte[] pfxBlob = null,
            string siteName = null,
            string selfLink = null,
            string issuer = null,
            DateTime? issueDate = null,
            DateTime? expirationDate = null,
            string thumbprint = null,
            bool? valid = null,
            byte[] cerBlob = null,
            string publicKeyHash = null,
            HostingEnvironmentProfile hostingEnvironmentProfile = null,
            string keyVaultId = null,
            string keyVaultSecretName = null,
            KeyVaultSecretStatus? keyVaultSecretStatus = null,
            string serverFarmId = null,
            string canonicalName = null,
            string domainValidationMethod = null)
        {
            Location = location;
            Id = id;
            Name = name;
            Kind = kind;
            Type = type;
            Tags = tags;
            Password = password;
            FriendlyName = friendlyName;
            SubjectName = subjectName;
            HostNames = hostNames;
            PfxBlob = pfxBlob;
            SiteName = siteName;
            SelfLink = selfLink;
            Issuer = issuer;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Thumbprint = thumbprint;
            Valid = valid;
            CerBlob = cerBlob;
            PublicKeyHash = publicKeyHash;
            HostingEnvironmentProfile = hostingEnvironmentProfile;
            KeyVaultId = keyVaultId;
            KeyVaultSecretName = keyVaultSecretName;
            KeyVaultSecretStatus = keyVaultSecretStatus;
            ServerFarmId = serverFarmId;
            CanonicalName = canonicalName;
            DomainValidationMethod = domainValidationMethod;
        }

        public string Password { get; set; }

        public string FriendlyName { get; set; }

        public string SubjectName { get; set; }

        public IList<string> HostNames { get; set; }

        public byte[] PfxBlob { get; set; }

        public string SiteName { get; set; }

        public string SelfLink { get; set; }

        public string Issuer { get; set; }

        public DateTime? IssueDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string Thumbprint { get; set; }

        public bool? Valid { get; set; }

        public byte[] CerBlob { get; set; }

        public string PublicKeyHash { get; set; }

        public HostingEnvironmentProfile HostingEnvironmentProfile { get; set; }

        public string KeyVaultId { get; set; }

        public string KeyVaultSecretName { get; set; }

        public KeyVaultSecretStatus? KeyVaultSecretStatus { get; set; }

        public string ServerFarmId { get; set; }

        public string CanonicalName { get; set; }

        public string DomainValidationMethod { get; set; }
    }

    public class CertificateDetails
    {
        public int? Version { get; set; }

        public string SerialNumber { get; set; }

        public string Thumbprint { get; set; }

        public string Subject { get; set; }

        public DateTime? NotBefore { get; set; }

        public DateTime? NotAfter { get; set; }

        public string SignatureAlgorithm { get; set; }

        public string Issuer { get; set; }

        public string RawData { get; set; }
    }

    public enum KeyVaultSecretStatus
    {
        Initialized,
        WaitingOnCertificateOrder,
        Succeeded,
        CertificateOrderFailed,
        OperationNotPermittedOnKeyVault,
        AzureServiceUnauthorizedToAccessKeyVault,
        KeyVaultDoesNotExist,
        KeyVaultSecretDoesNotExist,
        UnknownError,
        ExternalPrivateKey,
        Unknown
    }

    public class AzureStoragePropertyDictionaryResource : ProxyOnlyResource
    {
        public AzureStoragePropertyDictionaryResource()
        {
            Properties = new Dictionary<string, AzureStorageInfoValue>();
        }

        public IDictionary<string, AzureStorageInfoValue> Properties { get; set; }
    }

    public class AzureStorageInfoValue
    {
        public AzureStorageInfoValue()
        {
        }

        public AzureStorageInfoValue(
            AzureStorageType? type = null,
            string accountName = null,
            string shareName = null,
            string accessKey = null,
            string mountPath = null,
            AzureStorageState? state = null)
        {
            Type = type;
            AccountName = accountName;
            ShareName = shareName;
            AccessKey = accessKey;
            MountPath = mountPath;
            State = state;
        }

        public AzureStorageType? Type { get; set; }

        public string AccountName { get; set; }

        public string ShareName { get; set; }

        public string AccessKey { get; set; }

        public string MountPath { get; set; }

        public AzureStorageState? State { get; set; }
    }

    public enum AzureStorageType
    {
        AzureFiles,
        AzureBlob
    }

    public enum AzureStorageState
    {
        Ok,
        InvalidCredentials,
        InvalidShare,
        NotValidated
    }

    public class BackupSchedule
    {
        public BackupSchedule()
        {
        }

        public BackupSchedule(
            int frequencyInterval,
            FrequencyUnit frequencyUnit,
            bool keepAtLeastOneBackup,
            int retentionPeriodInDays,
            DateTime? startTime = null)
        {
            FrequencyInterval = frequencyInterval;
            FrequencyUnit = frequencyUnit;
            KeepAtLeastOneBackup = keepAtLeastOneBackup;
            RetentionPeriodInDays = retentionPeriodInDays;
            StartTime = startTime;
        }

        public int FrequencyInterval { get; set; }

        public FrequencyUnit FrequencyUnit { get; set; }

        public bool KeepAtLeastOneBackup { get; set; }

        public int RetentionPeriodInDays { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? LastExecutionTime { get; set; }
    }

    public enum FrequencyUnit
    {
        Day,
        Hour
    }

    public class BackupRequest : ProxyOnlyResource
    {
        public string StorageAccountUrl { get; set; }

        public string BackupName { get; set; }

        public bool? Enabled { get; set; }

        public BackupSchedule BackupSchedule { get; set; }

        public IList<DatabaseBackupSetting> Databases { get; set; }
    }

    public class BackupItem : ProxyOnlyResource
    {
        public int? BackupId { get; set; }

        public string StorageAccountUrl { get; set; }

        public string BlobName { get; set; }

        public string BackupItemName { get; set; }

        public BackupItemStatus? Status { get; set; }

        public long? SizeInBytes { get; set; }

        public DateTime? Created { get; set; }

        public string Log { get; set; }

        public IList<DatabaseBackupSetting> Databases { get; set; }

        public bool? Scheduled { get; set; }

        public DateTime? LastRestoreTimeStamp { get; set; }

        public DateTime? FinishedTimeStamp { get; set; }

        public string CorrelationId { get; set; }

        public long? WebsiteSizeInBytes { get; set; }
    }

    public enum BackupItemStatus
    {
        InProgress,
        Failed,
        Succeeded,
        TimedOut,
        Created,
        Skipped,
        PartiallySucceeded,
        DeleteInProgress,
        DeleteFailed,
        Deleted
    }

    public class DatabaseBackupSetting
    {
        public string DatabaseType { get; set; }

        public string Name { get; set; }

        public string ConnectionStringName { get; set; }

        public string ConnectionString { get; set; }
    }

    public class RestoreRequest : ProxyOnlyResource
    {
        public string StorageAccountUrl { get; set; }

        public bool Overwrite { get; set; }

        public string BlobName { get; set; }

        public string SiteName { get; set; }

        public IList<DatabaseBackupSetting> Databases { get; set; }

        public bool? IgnoreConflictingHostNames { get; set; }

        public bool? IgnoreDatabases { get; set; }

        public string AppServicePlan { get; set; }

        public BackupRestoreOperationType? OperationType { get; set; }

        public bool? AdjustConnectionStrings { get; set; }

        public string HostingEnvironment { get; set; }
    }

    public enum BackupRestoreOperationType
    {
        Default,
        Clone,
        Relocation,
        Snapshot,
        CloudFS
    }

    public class Snapshot : ProxyOnlyResource
    {
        public string Time { get; set; }
    }

    public class SnapshotRecoverySource
    {
        public string Location { get; set; }

        public string Id { get; set; }
    }

    public class SnapshotRestoreRequest : ProxyOnlyResource
    {
        public bool Overwrite { get; set; }

        public string SnapshotTime { get; set; }

        public SnapshotRecoverySource RecoverySource { get; set; }

        public bool? RecoverConfiguration { get; set; }

        public bool? IgnoreConflictingHostNames { get; set; }

        public bool? UseDRSecondary { get; set; }
    }

    public class DeletedSite : ProxyOnlyResource
    {
        public int? DeletedSiteId { get; set; }

        public string DeletedTimestamp { get; set; }

        public string Subscription { get; set; }

        public string ResourceGroup { get; set; }

        public string DeletedSiteName { get; set; }

        public string Slot { get; set; }

        public string DeletedSiteKind { get; set; }

        public string GeoRegionName { get; set; }
    }

    public class DeletedAppRestoreRequest : ProxyOnlyResource
    {
        public string DeletedSiteId { get; set; }

        public bool? RecoverConfiguration { get; set; }

        public string SnapshotTime { get; set; }

        public bool? UseDRSecondary { get; set; }
    }

    public class User : ProxyOnlyResource
    {
        public string PublishingUserName { get; set; }

        public string PublishingPassword { get; set; }

        public string PublishingPasswordHash { get; set; }

        public string PublishingPasswordHashSalt { get; set; }

        public string ScmUri { get; set; }
    }

    public class SlotConfigNamesResource : ProxyOnlyResource
    {
        public IList<string> AppSettingNames { get; set; }

        public IList<string> ConnectionStringNames { get; set; }

        public IList<string> AzureStorageConfigNames { get; set; }
    }

    public class SiteConfigurationSnapshotInfo : ProxyOnlyResource
    {
        public DateTime? Time { get; set; }

        public int? SnapshotId { get; set; }
    }

    public class CsmSlotEntity
    {
        public string TargetSlot { get; set; }

        public bool PreserveVnet { get; set; }
    }

    public class CsmPublishingProfileOptions
    {
        public string Format { get; set; }

        public bool? IncludeDisasterRecoveryEndpoints { get; set; }
    }

    public class HostNameBinding : ProxyOnlyResource
    {
        public string SiteName { get; set; }

        public string DomainId { get; set; }

        public string AzureResourceName { get; set; }

        public AzureResourceType? AzureResourceType { get; set; }

        public CustomHostNameDnsRecordType? CustomHostNameDnsRecordType { get; set; }

        public HostNameType? HostNameType { get; set; }

        public SslState? SslState { get; set; }

        public string Thumbprint { get; set; }

        public string VirtualIP { get; set; }
    }

    public class AppServiceEnvironmentResource : Resource
    {
        public ProvisioningState? ProvisioningState { get; set; }

        public HostingEnvironmentStatus? Status { get; set; }

        public string InternalLoadBalancingMode { get; set; }

        public string MultiSize { get; set; }

        public int? MultiRoleCount { get; set; }

        public int? IpsslAddressCount { get; set; }

        public string DnsSuffix { get; set; }

        public int? MaximumNumberOfMachines { get; set; }

        public int? FrontEndScaleFactor { get; set; }

        public bool? Suspended { get; set; }

        public IList<NameValuePair> ClusterSettings { get; set; }

        public IList<string> UserWhitelistedIpRanges { get; set; }

        public bool? HasLinuxWorkers { get; set; }

        public int? DedicatedHostCount { get; set; }

        public VirtualNetworkProfile VirtualNetwork { get; set; }
    }

    public class VirtualNetworkProfile
    {
        public VirtualNetworkProfile()
        {
        }

        public VirtualNetworkProfile(
            string id = null,
            string name = null,
            string type = null,
            string subnet = null)
        {
            Id = id;
            Name = name;
            Type = type;
            Subnet = subnet;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Subnet { get; set; }
    }

    public class AddressResponse : ProxyOnlyResource
    {
        public string ServiceIpAddress { get; set; }

        public string InternalIpAddress { get; set; }

        public IList<string> OutboundIpAddresses { get; set; }

        public IList<VirtualIPMapping> VipMappings { get; set; }
    }

    public class VirtualIPMapping
    {
        public string VirtualIP { get; set; }

        public int? InternalHttpPort { get; set; }

        public int? InternalHttpsPort { get; set; }

        public bool? InUse { get; set; }

        public string ServiceName { get; set; }
    }

    public class VnetInfo : ProxyOnlyResource
    {
        public string VnetResourceId { get; set; }

        public string CertThumbprint { get; set; }

        public string CertBlob { get; set; }

        public IList<VnetRoute> Routes { get; set; }

        public bool? ResyncRequired { get; set; }

        public string DnsServers { get; set; }

        public bool? IsSwift { get; set; }
    }

    public class VnetRoute : ProxyOnlyResource
    {
        public string StartAddress { get; set; }

        public string EndAddress { get; set; }

        public string RouteType { get; set; }
    }

    public class SiteMachineKey
    {
        public string Validation { get; set; }

        public string ValidationKey { get; set; }

        public string Decryption { get; set; }

        public string DecryptionKey { get; set; }
    }

    public class VirtualApplication
    {
        public VirtualApplication()
        {
        }

        public VirtualApplication(
            string virtualPath,
            string physicalPath,
            bool? preloadEnabled = null,
            IList<VirtualDirectory> virtualDirectories = null)
        {
            VirtualPath = virtualPath;
            PhysicalPath = physicalPath;
            PreloadEnabled = preloadEnabled;
            VirtualDirectories = virtualDirectories;
        }

        public string VirtualPath { get; set; }

        public string PhysicalPath { get; set; }

        public bool? PreloadEnabled { get; set; }

        public IList<VirtualDirectory> VirtualDirectories { get; set; }
    }

    public class VirtualDirectory
    {
        public VirtualDirectory()
        {
        }

        public VirtualDirectory(string virtualPath, string physicalPath)
        {
            VirtualPath = virtualPath;
            PhysicalPath = physicalPath;
        }

        public string VirtualPath { get; set; }

        public string PhysicalPath { get; set; }
    }

    public class SiteLimits
    {
        public double? MaxPercentageCpu { get; set; }

        public long? MaxMemoryInMb { get; set; }

        public long? MaxDiskSizeInMb { get; set; }
    }

    public class AutoHealRules
    {
        public AutoHealTriggers Triggers { get; set; }

        public AutoHealActions Actions { get; set; }
    }

    public class AutoHealTriggers
    {
        public RequestsBasedTrigger Requests { get; set; }

        public int? PrivateBytesInKB { get; set; }

        public IList<StatusCodesBasedTrigger> StatusCodes { get; set; }

        public SlowRequestsBasedTrigger SlowRequests { get; set; }

        public IList<SlowRequestsBasedTrigger> SlowRequestsWithPath { get; set; }

        public IList<StatusCodesRangeBasedTrigger> StatusCodesRange { get; set; }
    }

    public class RequestsBasedTrigger
    {
        public RequestsBasedTrigger()
        {
        }

        public RequestsBasedTrigger(
            int? count = null,
            string timeInterval = null)
        {
            Count = count;
            TimeInterval = timeInterval;
        }

        public int? Count { get; set; }

        public string TimeInterval { get; set; }
    }

    public class StatusCodesBasedTrigger
    {
        public StatusCodesBasedTrigger()
        {
        }

        public StatusCodesBasedTrigger(
            int? status = null,
            int? subStatus = null,
            int? win32Status = null,
            int? count = null,
            string timeInterval = null,
            string path = null)
        {
            Status = status;
            SubStatus = subStatus;
            Win32Status = win32Status;
            Count = count;
            TimeInterval = timeInterval;
            Path = path;
        }

        public int? Status { get; set; }

        public int? SubStatus { get; set; }

        public int? Win32Status { get; set; }

        public int? Count { get; set; }

        public string TimeInterval { get; set; }

        public string Path { get; set; }
    }

    public class StatusCodesRangeBasedTrigger
    {
        public string StatusCodes { get; set; }

        public string Path { get; set; }

        public int? Count { get; set; }

        public string TimeInterval { get; set; }
    }

    public class SlowRequestsBasedTrigger
    {
        public SlowRequestsBasedTrigger()
        {
        }

        public SlowRequestsBasedTrigger(
            string timeTaken = null,
            string path = null,
            int? count = null,
            string timeInterval = null)
        {
            TimeTaken = timeTaken;
            Path = path;
            Count = count;
            TimeInterval = timeInterval;
        }

        public string TimeTaken { get; set; }

        public int? Count { get; set; }

        public string TimeInterval { get; set; }

        public string Path { get; set; }
    }

    public class AutoHealActions
    {
        public AutoHealActions()
        {
        }

        public AutoHealActions(
            AutoHealActionType? actionType,
            AutoHealCustomAction customAction,
            string minProcessExecutionTime)
        {
            ActionType = actionType;
            CustomAction = customAction;
            MinProcessExecutionTime = minProcessExecutionTime;
        }

        public AutoHealActionType? ActionType { get; set; }

        public AutoHealCustomAction CustomAction { get; set; }

        public string MinProcessExecutionTime { get; set; }
    }

    public class AutoHealCustomAction
    {
        public AutoHealCustomAction()
        {
        }

        public AutoHealCustomAction(string exe, string parameters)
        {
            Exe = exe;
            Parameters = parameters;
        }

        public string Exe { get; set; }

        public string Parameters { get; set; }
    }

    public enum AutoHealActionType
    {
        Recycle,
        LogEvent,
        CustomAction
    }

    public class CorsSettings
    {
        public IList<string> AllowedOrigins { get; set; }

        public bool? SupportCredentials { get; set; }
    }

    public class PushSettings : ProxyOnlyResource
    {
        public bool IsPushEnabled { get; set; }

        public string TagWhitelistJson { get; set; }

        public string TagsRequiringAuth { get; set; }

        public string DynamicTagsJson { get; set; }
    }

    public class ApiDefinitionInfo
    {
        public ApiDefinitionInfo()
        {
        }

        public ApiDefinitionInfo(string url)
        {
            Url = url;
        }

        public string Url { get; set; }
    }

    public class ApiManagementConfig
    {
        public string Id { get; set; }
    }

    public class SlotSwapStatus
    {
        public DateTime? TimestampUtc { get; set; }

        public string SourceSlotName { get; set; }

        public string DestinationSlotName { get; set; }
    }

    public enum ManagedPipelineMode
    {
        Integrated,
        Classic
    }

    public enum SiteLoadBalancing
    {
        WeightedRoundRobin,
        LeastRequests,
        LeastResponseTime,
        WeightedTotalTraffic,
        RequestHash,
        PerSiteRoundRobin
    }

    public enum UsageState
    {
        Normal,
        Exceeded
    }

    public enum SiteAvailabilityState
    {
        Normal,
        Limited,
        DisasterRecoveryMode
    }

    public enum ClientCertMode
    {
        Required,
        Optional,
        OptionalInteractiveUser
    }

    public enum RedundancyMode
    {
        None,
        Manual,
        Failover,
        ActiveActive,
        GeoRedundant
    }

    public enum StatusOptions
    {
        Ready,
        Pending,
        Creating
    }

    public enum ProvisioningState
    {
        Succeeded,
        Failed,
        Canceled,
        InProgress,
        Deleting
    }

    public enum HostingEnvironmentStatus
    {
        Preparing,
        Ready,
        Scaling,
        Deleting
    }
}

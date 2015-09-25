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
using System.Text;

namespace Microsoft.WindowsAzure.Commands.Storage.ServiceManagement.Model
{

    public static class Constants
    {
        public const string ServiceManagementNS = "http://schemas.microsoft.com/windowsazure";
        public readonly static string StandardTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'";
        // Please put the newest version outside the #endif.MSFTINTERNAL We only want the newest version to show up in what we ship publically.
        // Also, update rdfe\Utilities\Common\VersionHeaders.cs StaticSupportedVersionsList.
        public const string VersionHeaderContent20130801 = "2013-08-01";
    }

    public static class OperationState
    {
        public const string InProgress = "InProgress";
        public const string Succeeded = "Succeeded";
        public const string Failed = "Failed";
    }

    public static class KeyType
    {
        public const string Primary = "Primary";
        public const string Secondary = "Secondary";
    }


    [CollectionDataContract(Name = "StorageServices", ItemName = "StorageService", Namespace = Constants.ServiceManagementNS)]
    public class StorageServiceList : List<StorageService>
    {
        public StorageServiceList()
        {
        }

        public StorageServiceList(IEnumerable<StorageService> storageServices)
            : base(storageServices)
        {
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class StorageDomain : IExtensibleDataObject
    {
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string ServiceName { get; set; }

        [DataMember(Order = 2)]
        public string DomainName { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class CustomDomain : IExtensibleDataObject
    {

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public bool UseSubDomainName { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Namespace = Constants.ServiceManagementNS, Name = "CustomDomains", ItemName = "CustomDomain")]
    public class CustomDomainList : List<CustomDomain>, IExtensibleDataObject
    {
        public CustomDomainList()
        {
        }

        public CustomDomainList(IEnumerable<CustomDomain> customDomains)
            : base(customDomains)
        {
        }

        public ExtensionDataObject ExtensionData { get; set; }
    }


    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class CreateStorageServiceInput : IExtensibleDataObject
    {
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string ServiceName { get; set; }

        [DataMember(Order = 2)]
        public string Description { get; set; }

        [DataMember(Order = 3, Name = "Label")]
        private string _base64EncodedLabel { get; set; }

        public string Label
        {
            get
            {
                string decodedLabel;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedLabel, out decodedLabel))
                {
                    throw new InvalidOperationException("Unable to decode Base64 string");
                }
                return decodedLabel;
            }
            set
            {
                this._base64EncodedLabel = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public string AffinityGroup { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public string Location { get; set; }

        [DataMember(Order = 6, EmitDefaultValue = false)]
        public bool? GeoReplicationEnabled { get; set; }

        [DataMember(Order = 7, EmitDefaultValue = false)]
        public ExtendedPropertiesList ExtendedProperties { get; set; }

        [DataMember(Order = 8, EmitDefaultValue = false)]
        public bool? SecondaryReadEnabled { get; set; }

        [DataMember(Order = 9, EmitDefaultValue = false)]
        public string AccountType { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class UpdateStorageServiceInput : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string Description { get; set; }

        [DataMember(Order = 2, Name = "Label")]
        private string _base64EncodedLabel { get; set; }

        public string Label
        {
            get
            {
                string decodedLabel;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedLabel, out decodedLabel))
                {
                    throw new InvalidOperationException("Unable to decode Base64 string");
                }
                return decodedLabel;
            }
            set
            {
                this._base64EncodedLabel = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public bool? GeoReplicationEnabled { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public ExtendedPropertiesList ExtendedProperties { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public CustomDomainList CustomDomains { get; set; }

        [DataMember(Order = 6, EmitDefaultValue = false)]
        public bool? SecondaryReadEnabled { get; set; }

        [DataMember(Order = 7, EmitDefaultValue = false)]
        public string AccountType { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class StorageService : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public Uri Url { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string ServiceName { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public StorageServiceProperties StorageServiceProperties { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public StorageServiceKeys StorageServiceKeys { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public ExtendedPropertiesList ExtendedProperties { get; set; }

        [DataMember(Order = 6, EmitDefaultValue = false)]
        public CapabilitiesList Capabilities { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Namespace = Constants.ServiceManagementNS, Name = "Endpoints", ItemName = "Endpoint")]
    public class EndpointList : List<String>, IExtensibleDataObject
    {
        public ExtensionDataObject ExtensionData { get; set; }

    }
        //Use ComputeCapabilities for the compute related things. In new API this should not be used
    //as it doesn't give the good idea of what capabilities are supported.
    [CollectionDataContract(Name = "Capabilities", ItemName = "Capability", Namespace = Constants.ServiceManagementNS)]
    public class CapabilitiesList : List<String>, IExtensibleDataObject
    {
        public CapabilitiesList()
        {
        }

        public CapabilitiesList(IEnumerable<String> capabilities)
            : base(capabilities)
        {
        }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class StorageServiceProperties : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string Description { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string AffinityGroup { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string Location { get; set; }

        [DataMember(Order = 4, Name = "Label", EmitDefaultValue = false)]
        private string _base64EncodedLabel { get; set; }

        public string Label
        {
            get
            {
                string decodedLabel;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedLabel, out decodedLabel))
                {
                    throw new InvalidOperationException("Unable to decode Base64 string");
                }
                return decodedLabel;
            }
            set
            {
                this._base64EncodedLabel = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public string Status { get; set; }

        [DataMember(Order = 6, EmitDefaultValue = false)]
        public EndpointList Endpoints { get; set; }

        [DataMember(Order = 7, EmitDefaultValue = false)]
        public bool? GeoReplicationEnabled { get; set; } // Defines as nullable for older client compat.

        [DataMember(Order = 8, EmitDefaultValue = false)]
        public string GeoPrimaryRegion { get; set; }

        [DataMember(Order = 9, EmitDefaultValue = false)]
        public string StatusOfPrimary { get; set; }

        [DataMember(Order = 10, EmitDefaultValue = false)]
        public string GeoSecondaryRegion { get; set; }

        [DataMember(Order = 11, EmitDefaultValue = false)]
        public string StatusOfSecondary { get; set; }

        [DataMember(Order = 12, EmitDefaultValue = false, Name = "LastGeoFailoverTime")]
        public string isoLastGeoFailoverTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Anvil.RdUsage!TimeUtc", "27102",
            Justification = "fixing it at this stage might break the old behavior/interface since LastGeoFailoverTime is customer facing and there is a lot of existing data")]
        public DateTime LastGeoFailoverTime
        {
            get
            {
                return (string.IsNullOrEmpty(this.isoLastGeoFailoverTime) ? new DateTime() : DateTime.Parse(this.isoLastGeoFailoverTime));
            }
            set
            {
                this.isoLastGeoFailoverTime = value.ToString(Constants.StandardTimeFormat);
            }
        }

        // Below property name should be "CreatedTime", alligning with Disk, Deployment, AffinityGroup.
        [DataMember(Order = 13, EmitDefaultValue = false, Name = "CreationTime")]
        private string _isoCreationTimeString { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Anvil.RdUsage!TimeUtc", "27102",
            Justification = "fixing it at this stage might break the old behavior/interface since CreationTime is customer facing and there is a lot of existing data")]
        public DateTime CreationTime
        {
            get
            {
                return (string.IsNullOrEmpty(this._isoCreationTimeString) ? DateTime.MinValue : DateTime.Parse(this._isoCreationTimeString));
            }
            set
            {
                if (value.Equals(DateTime.MinValue))
                {
                    this._isoCreationTimeString = null;
                }
                else
                {
                    this._isoCreationTimeString = value.ToString(Constants.StandardTimeFormat);
                }
            }
        }

        [DataMember(Order = 14, EmitDefaultValue = false)]
        public CustomDomainList CustomDomains { get; set; }

        [DataMember(Order = 15, EmitDefaultValue = false)]
        public bool? SecondaryReadEnabled { get; set; }

        [DataMember(Order = 16, EmitDefaultValue = false)]
        public EndpointList SecondaryEndpoints { get; set; }

        [DataMember(Order = 17, EmitDefaultValue = false)]
        public string AccountType { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public enum StorageAccountType
    {
        [EnumMember]
        Standard_LRS,

        [EnumMember]
        Standard_GRS,

        [EnumMember]
        Standard_RAGRS,

        [EnumMember]
        Standard_ZRS,
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class StorageServiceKeys : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string Primary { get; set; }

        [DataMember(Order = 2)]
        public string Secondary { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class RegenerateKeys : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string KeyType { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class ExtendedProperty : IExtensibleDataObject
    {

        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string Value { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Name = "ExtendedPropertiesList", ItemName = "ExtendedProperty", Namespace = Constants.ServiceManagementNS)]
    public class ExtendedPropertiesList : List<ExtendedProperty>
    {
        public ExtendedPropertiesList()
        {
            // Empty
        }

        public ExtendedPropertiesList(IEnumerable<ExtendedProperty> propertyList)
            : base(propertyList)
        {
            // Empty
        }
    }

        internal static class StringEncoder
    {
        public static bool TryDecodeFromBase64String(string encodedString, out string decodedString)
        {
            bool canDecode = true;
            decodedString = encodedString;

            // A null or empty string will not be considered a failure and will result in the original null or empty value being persisted
            if (!string.IsNullOrEmpty(encodedString))
            {
                try
                {
                    decodedString = StringEncoder.DecodeFromBase64String(encodedString);
                }
                catch (Exception)
                {
                    canDecode = false;
                }
            }

            return canDecode;
        }

        public static string EncodeToBase64String(string decodedString)
        {
            string encodedString = decodedString;

            if (!string.IsNullOrEmpty(decodedString))
            {
                encodedString = Convert.ToBase64String(Encoding.UTF8.GetBytes(decodedString));
            }

            return encodedString;
        }

        public static string DecodeFromBase64String(string encodedString)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(encodedString));
        }
    }

    [DataContract(Name = "Error", Namespace = Constants.ServiceManagementNS)]
    public class ServiceManagementError : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string Code { get; set; }

        [DataMember(Order = 2)]
        public string Message { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public ConfigurationWarningsList ConfigurationWarnings { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public string ConflictingOperationId { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

        [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class ConfigurationWarning : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string WarningCode { get; set; }

        [DataMember(Order = 2)]
        public string WarningMessage { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }

        public override string ToString()
        {
            return string.Format("WarningCode:{0} WarningMessage:{1}", WarningCode, WarningMessage);
        }
    }

    [CollectionDataContract(Namespace = Constants.ServiceManagementNS)]
    public class ConfigurationWarningsList : List<ConfigurationWarning>
    {
        public override string ToString()
        {
            StringBuilder warnings = new StringBuilder(string.Format("ConfigurationWarnings({0}):\n", this.Count));

            foreach (ConfigurationWarning warning in this)
            {
                warnings.Append(warning + "\n");
            }
            return warnings.ToString();
        }
    }

}




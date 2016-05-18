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

//TODO: When transition to SM.NET is completed, rename the namespace to "Microsoft.WindowsAzure.ServiceManagement"

using Microsoft.WindowsAzure.Commands.Common.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Model
{

    #region Constants
    public static class Constants
    {
        public const string ServiceManagementNS = "http://schemas.microsoft.com/windowsazure";
        public readonly static string StandardTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'";
        // Please put the newest version outside the #endif.MSFTINTERNAL We only want the newest version to show up in what we ship publically.
        // Also, update rdfe\Utilities\Common\VersionHeaders.cs StaticSupportedVersionsList.
        public const string VersionHeaderContent20130801 = "2013-08-01";
    }

    public static class DeploymentStatus
    {
        public const string Running = "Running";
        public const string Suspended = "Suspended";
        public const string RunningTransitioning = "RunningTransitioning";
        public const string SuspendedTransitioning = "SuspendedTransitioning";
        public const string Starting = "Starting";
        public const string Suspending = "Suspending";
        public const string Deploying = "Deploying";
        public const string Deleting = "Deleting";
        public const string Unavailable = "Unavailable";
    }

    public static class RoleInstanceStatus
    {
        public const string Initializing = "Initializing";
        public const string Ready = "Ready";
        public const string Busy = "Busy";
        public const string Stopping = "Stopping";
        public const string Stopped = "Stopped";
        public const string Unresponsive = "Unresponsive";

        public const string RoleStateUnknown = "RoleStateUnknown";
        public const string CreatingVM = "CreatingVM";
        public const string StartingVM = "StartingVM";
        public const string CreatingRole = "CreatingRole";
        public const string StartingRole = "StartingRole";
        public const string ReadyRole = "ReadyRole";
        public const string BusyRole = "BusyRole";

        public const string StoppingRole = "StoppingRole";
        public const string StoppingVM = "StoppingVM";
        public const string DeletingVM = "DeletingVM";
        public const string StoppedVM = "StoppedVM";
        public const string RestartingRole = "RestartingRole";
        public const string CyclingRole = "CyclingRole";

        public const string FailedStartingRole = "FailedStartingRole";
        public const string FailedStartingVM = "FailedStartingVM";
        public const string UnresponsiveRole = "UnresponsiveRole";

        public const string Provisioning = "Provisioning";
        public const string ProvisioningFailed = "ProvisioningFailed";
        public const string ProvisioningTimeout = "ProvisioningTimeout";

        public const string StoppingAndDeallocating = "StoppingAndDeallocating";
        public const string StoppedDeallocated = "StoppedDeallocated";
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

    public static class DeploymentSlotType
    {
        public const string Staging = "Staging";
        public const string Production = "Production";
    }

    public static class UpgradeType
    {
        public const string Auto = "Auto";
        public const string Manual = "Manual";
        public const string Simultaneous = "Simultaneous";
    }

    public static class CurrentUpgradeDomainState
    {
        public const string Before = "Before";
        public const string During = "During";
    }
    public static class GuestAgentType
    {
        public const string ProdGA = "ProdGA";
        public const string TestGA = "TestGA";
        public const string HotfixGA = "HotfixGA";
    }

    #endregion

    #region Mergable
    public interface IResolvable
    {
        object ResolveType();
    }

    public interface IMergable
    {
        void Merge(object other);
    }

    public interface IMergable<T> : IMergable
    {
        void Merge(T other);
    }

    [DataContract]
    public abstract class Mergable<T> : IResolvable, IMergable<T>, IExtensibleDataObject where T : Mergable<T>
    {
        #region Field backing store
        private Dictionary<string, object> propertyStore;
        private Dictionary<string, object> PropertyStore
        {
            get
            {
                if (this.propertyStore == null)
                {
                    this.propertyStore = new Dictionary<string, object>();
                }
                return this.propertyStore;
            }
        }
        #endregion

        protected TValue GetValue<TValue>(string fieldName)
        {
            object value;

            if (this.PropertyStore.TryGetValue(fieldName, out value))
            {
                return (TValue)value;
            }
            return default(TValue);
        }
        protected void SetValue<TValue>(string fieldName, TValue value)
        {
            this.PropertyStore[fieldName] = value;
        }

        protected Nullable<TValue> GetField<TValue>(string fieldName) where TValue : struct
        {
            object value;
            if (this.PropertyStore.TryGetValue(fieldName, out value))
            {
                return new Nullable<TValue>((TValue)value);
            }
            else
            {
                return new Nullable<TValue>();
            }
        }

        protected void SetField<TValue>(string fieldName, Nullable<TValue> value) where TValue : struct
        {
            if (value.HasValue)
            {
                this.PropertyStore[fieldName] = value.Value;
            }
        }

        #region IResolvable Members

        public virtual object ResolveType()
        {
            return this;
        }

        #endregion

        protected TValue Convert<TValue>()
        {
            DataContractSerializer sourceSerializer = new DataContractSerializer(this.GetType());
            DataContractSerializer destinationSerializer = new DataContractSerializer(typeof(TValue));

            using (MemoryStream stream = new MemoryStream())
            {
                sourceSerializer.WriteObject(stream, this);
                stream.Position = 0;
                return (TValue)destinationSerializer.ReadObject(stream);
            }
        }


        #region IMergable Members

        public void Merge(object other)
        {
            ((IMergable<T>)this).Merge((T)other);
        }

        #endregion

        #region IMergable<T> members
        public void Merge(T other)
        {
            Mergable<T> otherObject = (Mergable<T>)other;

            foreach (KeyValuePair<string, object> kvPair in otherObject.PropertyStore)
            {
                object currentValue;

                if (this.PropertyStore.TryGetValue(kvPair.Key, out currentValue))
                {
                    IMergable mergableValue = currentValue as IMergable;

                    if (mergableValue != null)
                    {
                        mergableValue.Merge(kvPair.Value);
                        continue;
                    }
                }
                this.PropertyStore[kvPair.Key] = kvPair.Value;
            }
        }
        #endregion

        #region IExtensibleDataObject Members
        public ExtensionDataObject ExtensionData { get; set; }
        #endregion
    }

    #endregion

    #region VirtualIP
    [CollectionDataContract(Name = "VirtualIPs", ItemName = "VirtualIP", Namespace = Constants.ServiceManagementNS)]
    public class VirtualIPList : List<VirtualIP>
    {
        public VirtualIPList()
        {

        }

        public VirtualIPList(IEnumerable<VirtualIP> ips)
            : base(ips)
        {

        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class VirtualIP : IExtensibleDataObject
    {
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string Address { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public bool? IsDnsProgrammed { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public string ReservedIPName { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }

        #region Implements Equals
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            VirtualIP vip = obj as VirtualIP;
            if (vip == null)
            {
                return false;
            }

            return this == vip;
        }

        public static bool operator ==(VirtualIP left, VirtualIP right)
        {
            if (Object.ReferenceEquals(left, right))
            {
                return true;
            }

            if ((object)left == null && (object)right == null)
            {
                return true;
            }

            if ((object)left == null || (object)right == null)
            {
                return false;
            }

            return string.Equals(left.Address, right.Address, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(left.Name, right.Name, StringComparison.OrdinalIgnoreCase);
        }

        public static bool operator !=(VirtualIP left, VirtualIP right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return this.Address.GetHashCode();
        }
        #endregion
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class EndpointContract : IExtensibleDataObject
    {
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string Protocol { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public int Port { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Namespace = Constants.ServiceManagementNS, Name = "EndpointContracts", ItemName = "EndpointContract")]
    public class EndpointContractList : List<EndpointContract>
    {
        public EndpointContractList() { }

        public EndpointContractList(IEnumerable<EndpointContract> collection)
            : base(collection)
        {

        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class VirtualIPGroup : IExtensibleDataObject
    {
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public EndpointContractList EndpointContracts { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public VirtualIPList VirtualIPs { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Name = "VirtualIPGroups", ItemName = "VirtualIPGroup", Namespace = Constants.ServiceManagementNS)]
    public class VirtualIPGroups : List<VirtualIPGroup>
    {
        public VirtualIPGroups()
        {
        }

        public VirtualIPGroups(IEnumerable<VirtualIPGroup> groups)
            : base(groups)
        {
        }
    }
    #endregion

    #region Configuration Set
    [DataContract(Namespace = Constants.ServiceManagementNS)]
    [KnownType(typeof(ProvisioningConfigurationSet))]
    [KnownType(typeof(LinuxProvisioningConfigurationSet))]
    [KnownType(typeof(WindowsProvisioningConfigurationSet))]
    [KnownType(typeof(NetworkConfigurationSet))]
    public class ConfigurationSet : Mergable<ConfigurationSet>
    {
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public virtual string ConfigurationSetType
        {
            get;
            set;
        }

        protected ConfigurationSet()
        {

        }

        public override object ResolveType()
        {
            if (this.GetType() != typeof(ConfigurationSet))
            {
                return this;
            }

            if (!string.IsNullOrEmpty(this.ConfigurationSetType))
            {
                if (string.Equals(this.ConfigurationSetType, "WindowsProvisioningConfiguration"))
                {
                    return base.Convert<WindowsProvisioningConfigurationSet>();
                }

                if (string.Equals(this.ConfigurationSetType, "LinuxProvisioningConfiguration"))
                {
                    return base.Convert<LinuxProvisioningConfigurationSet>();
                }

                if (string.Equals(this.ConfigurationSetType, "NetworkConfiguration"))
                {
                    return base.Convert<NetworkConfigurationSet>();
                }
            }
            return this;
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public abstract class ProvisioningConfigurationSet : ConfigurationSet
    {
        public string CustomData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class WindowsProvisioningConfigurationSet : ProvisioningConfigurationSet
    {
        [DataMember(Name = "ComputerName", EmitDefaultValue = false, Order = 1)]
        public string ComputerName
        {
            get
            {
                return this.GetValue<string>("ComputerName");
            }
            set
            {
                this.SetValue("ComputerName", value);
            }
        }

        [DataMember(Name = "AdminPassword", EmitDefaultValue = false, Order = 2)]
        public System.Security.SecureString AdminPassword
        {
            get
            {
                return this.GetValue<System.Security.SecureString>("AdminPassword");
            }
            set
            {
                this.SetValue("AdminPassword", value);
            }
        }


        [DataMember(Name = "ResetPasswordOnFirstLogon", EmitDefaultValue = false, Order = 4)]
        private bool? resetPasswordOnFirstLogon
        {
            get
            {
                return this.GetField<bool>("ResetPasswordOnFirstLogon");
            }
            set
            {
                this.SetField("ResetPasswordOnFirstLogon", value);
            }
        }
        public bool ResetPasswordOnFirstLogon
        {
            get
            {
                return base.GetValue<bool>("ResetPasswordOnFirstLogon");
            }
            set
            {
                base.SetValue("ResetPasswordOnFirstLogon", value);
            }
        }

        [DataMember(Name = "EnableAutomaticUpdates", EmitDefaultValue = false, Order = 4)]
        public bool? EnableAutomaticUpdates
        {
            get
            {
                return base.GetValue<bool?>("EnableAutomaticUpdates");
            }
            set
            {
                base.SetValue("EnableAutomaticUpdates", value);
            }
        }

        [DataMember(Name = "TimeZone", EmitDefaultValue = false, Order = 5)]
        public string TimeZone
        {
            get
            {
                return base.GetValue<string>("TimeZone");
            }
            set
            {
                base.SetValue("TimeZone", value);
            }
        }

        [DataMember(Name = "DomainJoin", EmitDefaultValue = false, Order = 6)]
        public DomainJoinSettings DomainJoin
        {
            get
            {
                return base.GetValue<DomainJoinSettings>("DomainJoin");
            }
            set
            {
                base.SetValue("DomainJoin", value);
            }
        }

        [DataMember(Name = "StoredCertificateSettings", EmitDefaultValue = false, Order = 7)]
        public CertificateSettingList StoredCertificateSettings
        {
            get
            {
                return base.GetValue<CertificateSettingList>("StoredCertificateSettings");
            }
            set
            {
                base.SetValue("StoredCertificateSettings", value);
            }
        }

        [DataMember(Name = "WinRM", EmitDefaultValue = false, Order = 8)]
        public WinRmConfiguration WinRM
        {
            get
            {
                return base.GetValue<WinRmConfiguration>("WinRM");
            }
            set
            {
                base.SetValue("WinRM", value);
            }
        }

        [DataMember(Name = "AdminUsername", EmitDefaultValue = false, Order = 9)]
        public string AdminUsername
        {
            get
            {
                return this.GetValue<string>("AdminUsername");
            }
            set
            {
                this.SetValue("AdminUsername", value);
            }
        }

        [DataContract(Namespace = Constants.ServiceManagementNS)]
        public class WinRmConfiguration
        {
            [DataMember(EmitDefaultValue = false, Order = 1)]
            public WinRmListenerCollection Listeners { get; set; }
        }

        [CollectionDataContract(Namespace = Constants.ServiceManagementNS, ItemName = "Listener")]
        public class WinRmListenerCollection : Collection<WinRmListenerProperties> { }

        public enum WinRmProtocol
        {
            Http,
            Https
        }

        [DataContract(Namespace = Constants.ServiceManagementNS)]
        public class WinRmListenerProperties
        {

            [DataMember(Order = 0, IsRequired = false, EmitDefaultValue = false)]
            public string CertificateThumbprint { get; set; }

            [DataMember(Order = 1, IsRequired = true)]
            public string Protocol { get; set; }
        }

        public override string ConfigurationSetType
        {
            get
            {
                return "WindowsProvisioningConfiguration";
            }
            set
            {
                base.ConfigurationSetType = value;
            }
        }

        [DataContract(Namespace = Constants.ServiceManagementNS)]
        public class DomainJoinCredentials
        {
            [DataMember(Name = "Domain", EmitDefaultValue = false, Order = 1)]
            public string Domain { get; set; }

            [DataMember(Name = "Username", EmitDefaultValue = false, Order = 2)]
            public string Username { get; set; }

            [DataMember(Name = "Password", EmitDefaultValue = false, Order = 3)]
            public System.Security.SecureString Password { get; set; }
        }

        [DataContract(Namespace = Constants.ServiceManagementNS)]
        public class DomainJoinProvisioning
        {
            [DataMember(Name = "AccountData", EmitDefaultValue = false, Order = 1)]
            public string AccountData { get; set; }
        }

        [DataContract(Namespace = Constants.ServiceManagementNS)]
        public class DomainJoinSettings
        {
            [DataMember(Name = "Credentials", EmitDefaultValue = false, Order = 1)]
            public DomainJoinCredentials Credentials { get; set; }

            [DataMember(Name = "Provisioning", EmitDefaultValue = false, Order = 2)]
            public DomainJoinProvisioning Provisioning { get; set; }

            [DataMember(Name = "JoinDomain", EmitDefaultValue = false, Order = 3)]
            public string JoinDomain { get; set; }

            [DataMember(Name = "MachineObjectOU", EmitDefaultValue = false, Order = 4)]
            public string MachineObjectOU { get; set; }
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class LinuxProvisioningConfigurationSet : ProvisioningConfigurationSet
    {
        [DataMember(Name = "HostName", EmitDefaultValue = false, Order = 1)]
        public string HostName
        {
            get
            {
                return this.GetValue<string>("HostName");
            }
            set
            {
                this.SetValue("HostName", value);
            }
        }

        [DataMember(Name = "UserName", EmitDefaultValue = false, Order = 2)]
        public string UserName
        {
            get
            {
                return this.GetValue<string>("UserName");
            }
            set
            {
                this.SetValue("UserName", value);
            }
        }

        [DataMember(Name = "UserPassword", EmitDefaultValue = false, Order = 3)]
        public System.Security.SecureString UserPassword
        {
            get
            {
                return this.GetValue<System.Security.SecureString>("UserPassword");
            }
            set
            {
                this.SetValue("UserPassword", value);
            }
        }

        [DataMember(Name = "DisableSshPasswordAuthentication", EmitDefaultValue = false, Order = 4)]
        public bool? DisableSshPasswordAuthentication
        {
            get
            {
                return base.GetValue<bool?>("DisableSshPasswordAuthentication");
            }
            set
            {
                base.SetValue("DisableSshPasswordAuthentication", value);
            }
        }

        [DataMember(Name = "SSH", EmitDefaultValue = false, Order = 5)]
        public SSHSettings SSH
        {
            get
            {
                return base.GetValue<SSHSettings>("SSH");
            }
            set
            {
                base.SetValue("SSH", value);
            }
        }

        public override string ConfigurationSetType
        {
            get
            {
                return "LinuxProvisioningConfiguration";
            }
            set
            {
                base.ConfigurationSetType = value;
            }
        }

        [DataContract(Name = "SSHSettings", Namespace = Constants.ServiceManagementNS)]
        public class SSHSettings
        {
            [DataMember(Name = "PublicKeys", EmitDefaultValue = false, Order = 1)]
            public SSHPublicKeyList PublicKeys { get; set; }

            [DataMember(Name = "KeyPairs", EmitDefaultValue = false, Order = 2)]
            public SSHKeyPairList KeyPairs { get; set; }
        }

        [CollectionDataContract(Name = "SSHPublicKeyList", ItemName = "PublicKey", Namespace = Constants.ServiceManagementNS)]
        public class SSHPublicKeyList : List<SSHPublicKey>
        {
        }

        [DataContract(Namespace = Constants.ServiceManagementNS)]
        public class SSHPublicKey
        {
            [DataMember(Name = "Fingerprint", EmitDefaultValue = false, Order = 1)]
            public string Fingerprint { get; set; }

            [DataMember(Name = "Path", EmitDefaultValue = false, Order = 2)]
            public string Path { get; set; }
        }


        [CollectionDataContract(Name = "SSHKeyPairList", ItemName = "KeyPair", Namespace = Constants.ServiceManagementNS)]
        public class SSHKeyPairList : List<SSHKeyPair>
        {
        }

        [DataContract(Namespace = Constants.ServiceManagementNS)]
        public class SSHKeyPair
        {
            [DataMember(Name = "Fingerprint", EmitDefaultValue = false, Order = 1)]
            public string Fingerprint { get; set; }

            [DataMember(Name = "Path", EmitDefaultValue = false, Order = 2)]
            public string Path { get; set; }
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class NetworkConfigurationSet : ConfigurationSet
    {
        public override string ConfigurationSetType
        {
            get
            {
                return "NetworkConfiguration";
            }
            set
            {
                base.ConfigurationSetType = value;
            }
        }

        [DataMember(Name = "InputEndpoints", EmitDefaultValue = false, Order = 0)]
        public Collection<InputEndpoint> InputEndpoints
        {
            get
            {
                return base.GetValue<Collection<InputEndpoint>>("InputEndpoints");
            }
            set
            {
                base.SetValue("InputEndpoints", value);
            }
        }

        [DataMember(Name = "SubnetNames", EmitDefaultValue = false, Order = 1)]
        public SubnetNamesCollection SubnetNames
        {
            get
            {
                return this.GetValue<SubnetNamesCollection>("SubnetNames");
            }
            set
            {
                this.SetValue("SubnetNames", value);
            }
        }

        [DataMember(Name = "VirtualIPGroups", EmitDefaultValue = false, Order = 2)]
        public VirtualIPGroups VirtualIPGroups
        {
            get
            {
                return this.GetValue<VirtualIPGroups>("VirtualIPGroups");
            }
            set
            {
                this.SetValue("VirtualIPGroups", value);
            }
        }

        [DataMember(Name = "StaticVirtualNetworkIPAddress", EmitDefaultValue = false, Order = 3)]
        public string StaticVirtualNetworkIPAddress
        {
            get
            {
                return this.GetValue<string>("StaticVirtualNetworkIPAddress");
            }
            set
            {
                this.SetValue("StaticVirtualNetworkIPAddress", value);
            }
        }

        [DataMember(Name = "PublicIPs", EmitDefaultValue = false, Order = 6)]
        public AssignPublicIPCollection PublicIPs
        {
            get
            {
                return this.GetValue<AssignPublicIPCollection>("PublicIPs");
            }
            set
            {
                this.SetValue("PublicIPs", value);
            }
        }

        [DataMember(Name = "NetworkInterfaces", EmitDefaultValue = false, Order = 7)]
        public AssignNetworkInterfaceCollection NetworkInterfaces
        {
            get
            {
                return this.GetValue<AssignNetworkInterfaceCollection>("NetworkInterfaces");
            }
            set
            {
                this.SetValue("NetworkInterfaces", value);
            }
        }

        [DataMember(Name = "NetworkSecurityGroup", EmitDefaultValue = false, Order = 8)]
        public string NetworkSecurityGroup
        {
            get
            {
                return this.GetValue<string>("NetworkSecurityGroup");
            }
            set
            {
                this.SetValue("NetworkSecurityGroup", value);
            }
        }

        [DataMember(Name = "IPForwarding", EmitDefaultValue = false, Order = 9)]
        public string IPForwarding
        {
            get
            {
                return this.GetValue<string>("IPForwarding");
            }
            set
            {
                this.SetValue("IPForwarding", value);
            }
        }
    }

    [CollectionDataContract(Name = "PublicIPs", ItemName = "PublicIP", Namespace = Constants.ServiceManagementNS)]
    public class AssignPublicIPCollection : List<AssignPublicIP>
    {
        public AssignPublicIPCollection()
        {
        }

        public AssignPublicIPCollection(IEnumerable<AssignPublicIP> publicIPs)
            : base(publicIPs)
        {
        }
    }

    [DataContract(Name = "PublicIP", Namespace = Constants.ServiceManagementNS)]
    public class AssignPublicIP
    {
        [DataMember(Name = "Name", EmitDefaultValue = false, Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "IdleTimeoutInMinutes", EmitDefaultValue = false, Order = 2)]
        public int? IdleTimeoutInMinutes { get; set; }

        [DataMember(Name = "DomainNameLabel", EmitDefaultValue = false, Order = 3)]
        public string DomainNameLabel { get; set; }
    }

    [CollectionDataContract(Name = "NetworkInterfaces", ItemName = "NetworkInterface", Namespace = Constants.ServiceManagementNS)]
    public class AssignNetworkInterfaceCollection : List<AssignNetworkInterface>
    {
        public AssignNetworkInterfaceCollection()
        {
        }

        public AssignNetworkInterfaceCollection(IEnumerable<AssignNetworkInterface> assignNetworkInterface)
            : base(assignNetworkInterface)
        {
        }
    }

    [DataContract(Name = "NetworkInterface", Namespace = Constants.ServiceManagementNS)]
    public class AssignNetworkInterface : Mergable<AssignNetworkInterface>
    {
        [DataMember(Name = "Name", EmitDefaultValue = false, Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "IPConfigurations", EmitDefaultValue = false, Order = 2)]
        public AssignIPConfigurationCollection IPConfigurations
        {
            get
            {
                return this.GetValue<AssignIPConfigurationCollection>("IPConfigurations");
            }
            set
            {
                this.SetValue("IPConfigurations", value);
            }
        }

        [DataMember(Name = "NetworkSecurityGroup", EmitDefaultValue = false, Order = 3)]
        public string NetworkSecurityGroup { get; set; }

        [DataMember(Name = "IPForwarding", EmitDefaultValue = false, Order = 4)]
        public string IPForwarding { get; set; }
    }

    [CollectionDataContract(Name = "IPConfigurations", ItemName = "IPConfiguration", Namespace = Constants.ServiceManagementNS)]
    public class AssignIPConfigurationCollection : List<AssignIPConfiguration>
    {
        public AssignIPConfigurationCollection()
        {
        }

        public AssignIPConfigurationCollection(IEnumerable<AssignIPConfiguration> assignIPConfigurations)
            : base(assignIPConfigurations)
        {
        }
    }

    [DataContract(Name = "IPConfiguration", Namespace = Constants.ServiceManagementNS)]
    public class AssignIPConfiguration
    {
        [DataMember(Name = "SubnetName", EmitDefaultValue = false, Order = 1)]
        public string SubnetName { get; set; }

        [DataMember(Name = "StaticVirtualNetworkIPAddress", EmitDefaultValue = false, Order = 2)]
        public string StaticVirtualNetworkIPAddress { get; set; }
    }

    [CollectionDataContract(Name = "LoadBalancedEndpointList", Namespace = Constants.ServiceManagementNS)]
    public class LoadBalancedEndpointList : List<InputEndpoint>
    {
    }

    [DataContract(Name = "InputEndpoint", Namespace = Constants.ServiceManagementNS)]
    public class InputEndpoint : Mergable<InputEndpoint>
    {
        #region constants
        [IgnoreDataMember]
        private const string EnableDirectServerReturnFieldName = "EnableDirectServerReturn";
        [IgnoreDataMember]
        private const string EndPointAccessControlListMemberName = "EndPointAccessControlList";
        #endregion

        [DataMember(Name = "LoadBalancedEndpointSetName", EmitDefaultValue = false, Order = 1)]
        public string LoadBalancedEndpointSetName
        {
            get
            {
                return base.GetValue<string>("LoadBalancedEndpointSetName");
            }
            set
            {
                base.SetValue("LoadBalancedEndpointSetName", value);
            }
        }

        [DataMember(Name = "LocalPort", EmitDefaultValue = false, Order = 2)]
        private int? localPort
        {
            get
            {
                return base.GetField<int>("LocalPort");
            }
            set
            {
                base.SetField("LocalPort", value);
            }
        }

        public int LocalPort
        {
            get
            {
                return base.GetValue<int>("LocalPort");
            }
            set
            {
                base.SetValue("LocalPort", value);
            }
        }

        [DataMember(Name = "Name", EmitDefaultValue = false, Order = 3)]
        public string Name
        {
            get
            {
                return base.GetValue<string>("Name");
            }
            set
            {
                base.SetValue("Name", value);
            }
        }

        [DataMember(Name = "Port", EmitDefaultValue = false, Order = 4)]
        public int? Port
        {
            get
            {
                return base.GetValue<int?>("Port");
            }
            set
            {
                base.SetValue("Port", value);
            }
        }

        [DataMember(Name = "LoadBalancerProbe", EmitDefaultValue = false, Order = 5)]
        public LoadBalancerProbe LoadBalancerProbe
        {
            get
            {
                return base.GetValue<LoadBalancerProbe>("LoadBalancerProbe");
            }
            set
            {
                base.SetValue("LoadBalancerProbe", value);
            }
        }

        [DataMember(Name = "Protocol", EmitDefaultValue = false, Order = 6)]
        public string Protocol
        {
            get
            {
                return base.GetValue<string>("Protocol");
            }
            set
            {
                base.SetValue("Protocol", value);
            }
        }

        [DataMember(Name = "Vip", EmitDefaultValue = false, Order = 7)]
        public string Vip
        {
            get
            {
                return base.GetValue<string>("Vip");
            }
            set
            {
                base.SetValue("Vip", value);
            }
        }

        [DataMember(Name = "EnableDirectServerReturn", EmitDefaultValue = false, Order = 8)]
        public bool? EnableDirectServerReturn
        {
            get
            {
                return base.GetValue<bool?>(EnableDirectServerReturnFieldName);
            }
            set
            {
                base.SetValue(EnableDirectServerReturnFieldName, value);
            }
        }

        [DataMember(Name = "EndpointAcl", EmitDefaultValue = false, Order = 9)]
        public EndpointAccessControlList EndpointAccessControlList
        {
            get
            {
                return base.GetValue<EndpointAccessControlList>(EndPointAccessControlListMemberName);
            }

            set
            {
                base.SetValue(EndPointAccessControlListMemberName, value);
            }
        }

        public string LoadBalancerName
        {
            get
            {
                return base.GetValue<string>("LoadBalancerName");
            }
            set
            {
                base.SetValue("LoadBalancerName", value);
            }
        }

        [DataMember(Name = "IdleTimeoutInMinutes", EmitDefaultValue = false, Order = 10)]
        public int? IdleTimeoutInMinutes
        {
            get
            {
                return base.GetValue<int?>("IdleTimeoutInMinutes");
            }
            set
            {
                base.SetValue("IdleTimeoutInMinutes", value);
            }
        }

        [DataMember(Name = "LoadBalancerDistribution", EmitDefaultValue = false, Order = 11)]
        public string LoadBalancerDistribution
        {
            get
            {
                return base.GetValue<string>("LoadBalancerDistribution");
            }
            set
            {
                base.SetValue("LoadBalancerDistribution", value);
            }
        }

        [DataMember(Name = "VirtualIPName", EmitDefaultValue = false, Order = 12)]
        public string VirtualIPName
        {
            get
            {
                return base.GetValue<string>("VirtualIPName");
            }
            set
            {
                base.SetValue("VirtualIPName", value);
            }
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class EndpointAccessControlList : Mergable<EndpointAccessControlList>
    {
        #region private constants
        [IgnoreDataMember]
        private const string AccessControlListRulesMemberName = "AccessControlListRules";
        #endregion

        [DataMember(Name = "Rules", IsRequired = false, Order = 0)]
        public Collection<AccessControlListRule> Rules
        {
            get
            {
                return base.GetValue<Collection<AccessControlListRule>>(AccessControlListRulesMemberName);
            }

            set
            {
                base.SetValue(AccessControlListRulesMemberName, value);
            }
        }
    }

    [DataContract(Name = "Rule", Namespace = Constants.ServiceManagementNS)]
    public class AccessControlListRule : Mergable<AccessControlListRule>
    {
        #region private constants
        private const string OrderMemberName = "Order";
        private const string ActionMemberName = "Action";
        private const string RemoteSubnetMemberName = "RemoteSubnet";
        private const string DescriptionMemberName = "Description";
        #endregion

        [DataMember(Name = OrderMemberName, IsRequired = false, Order = 0)]
        public int? Order
        {
            get
            {
                return base.GetValue<int?>(OrderMemberName);
            }

            set
            {
                base.SetValue(OrderMemberName, value);
            }
        }

        [DataMember(Name = ActionMemberName, IsRequired = false, Order = 1)]
        public string Action
        {
            get
            {
                return base.GetValue<string>(ActionMemberName);
            }

            set
            {
                base.SetValue(ActionMemberName, value);
            }
        }

        [DataMember(Name = RemoteSubnetMemberName, IsRequired = false, Order = 2)]
        public string RemoteSubnet
        {
            get
            {
                return base.GetValue<string>(RemoteSubnetMemberName);
            }

            set
            {
                base.SetValue(RemoteSubnetMemberName, value);
            }
        }

        [DataMember(Name = DescriptionMemberName, IsRequired = false, Order = 3)]
        public string Description
        {
            get
            {
                return base.GetValue<string>(DescriptionMemberName);
            }

            set
            {
                base.SetValue(DescriptionMemberName, value);
            }
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class LoadBalancerProbe : Mergable<LoadBalancerProbe>
    {
        #region constants
        // NOTE: fields in this region must be marked with IgnoreDataMember
        [IgnoreDataMember]
        private const string IntervalFieldName = "IntervalInSeconds";

        [IgnoreDataMember]
        private const string TimeoutFieldName = "TimeoutInSeconds";
        #endregion

        [DataMember(Name = "Path", EmitDefaultValue = false, Order = 0)]
        public string Path
        {
            get
            {
                return base.GetValue<string>("Path");
            }
            set
            {
                base.SetValue("Path", value);
            }
        }

        [DataMember(Name = "Port", EmitDefaultValue = false, Order = 1)]
        private int? port
        {
            get
            {
                return base.GetField<int>("Port");
            }
            set
            {
                base.SetField("Port", value);
            }
        }
        public int Port
        {
            get
            {
                return base.GetValue<int>("Port");
            }
            set
            {
                base.SetValue("Port", value);
            }
        }

        [DataMember(Name = "Protocol", EmitDefaultValue = false, Order = 2)]
        public string Protocol
        {
            get
            {
                return base.GetValue<string>("Protocol");
            }
            set
            {
                base.SetValue("Protocol", value);
            }
        }

        /// <summary>
        /// This field and its property counterpart represents the Load Balancer Probe Interval.
        /// This allows customers to specify custom load balance probe intervals.
        /// </summary>
        [DataMember(Name = "IntervalInSeconds", EmitDefaultValue = false, Order = 3)]
        public int? IntervalInSeconds
        {
            get
            {
                return base.GetValue<int?>(IntervalFieldName);
            }
            set
            {
                base.SetValue(IntervalFieldName, value);
            }
        }

        /// <summary>
        /// This field and its property counterpart represents the Load Balancer Probe Timeout.
        /// This allows customers to specify custom load balance probe timeouts.
        /// </summary>
        [DataMember(Name = "TimeoutInSeconds", EmitDefaultValue = false, Order = 4)]
        public int? TimeoutInSeconds
        {
            get
            {
                return base.GetValue<int?>(TimeoutFieldName);
            }
            set
            {
                base.SetValue(TimeoutFieldName, value);
            }
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class CertificateSetting : Mergable<CertificateSetting>
    {
        [DataMember(Name = "StoreLocation", EmitDefaultValue = false, Order = 0)]
        public string StoreLocation
        {
            get
            {
                return base.GetValue<string>("StoreLocation");
            }
            set
            {
                base.SetValue<string>("StoreLocation", value);
            }
        }

        [DataMember(Name = "StoreName", EmitDefaultValue = false, Order = 1)]
        public string StoreName
        {
            get
            {
                return base.GetValue<string>("StoreName");
            }
            set
            {
                base.SetValue<string>("StoreName", value);
            }
        }

        [DataMember(Name = "Thumbprint", EmitDefaultValue = false, Order = 2)]
        public string Thumbprint
        {
            get
            {
                return base.GetValue<string>("Thumbprint");
            }
            set
            {
                base.SetValue<string>("Thumbprint", value);
            }
        }
    }

    [CollectionDataContract(Name = "CertificateSettings", Namespace = Constants.ServiceManagementNS)]
    public class CertificateSettingList : List<CertificateSetting>
    {

    }

    [CollectionDataContract(Name = "SubnetNames", ItemName = "SubnetName", Namespace = Constants.ServiceManagementNS)]
    public class SubnetNamesCollection : Collection<string>
    {

    }

    #endregion

    #region DataDisk
    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class DataVirtualHardDisk : Mergable<DataVirtualHardDisk>
    {
        [DataMember(Name = "HostCaching", EmitDefaultValue = false, Order = 0)]
        public string HostCaching
        {
            get
            {
                return this.GetValue<string>("HostCaching");
            }
            set
            {
                this.SetValue("HostCaching", value);
            }
        }

        [DataMember(Name = "DiskLabel", EmitDefaultValue = false, Order = 1)]
        public string DiskLabel
        {
            get
            {
                return this.GetValue<string>("DiskLabel");
            }
            set
            {
                this.SetValue("DiskLabel", value);
            }
        }

        [DataMember(Name = "DiskName", EmitDefaultValue = false, Order = 2)]
        public string DiskName
        {
            get
            {
                return base.GetValue<string>("DiskName");
            }
            set
            {
                base.SetValue("DiskName", value);
            }
        }

        [DataMember(Name = "Lun", EmitDefaultValue = false, Order = 3)]
        public int Lun
        {
            get
            {
                return this.GetValue<int>("Lun");
            }
            set
            {
                this.SetValue("Lun", value);
            }
        }

        [DataMember(Name = "LogicalDiskSizeInGB", EmitDefaultValue = false, Order = 4)]
        private int? logicalDiskSizeInGB
        {
            get
            {
                return this.GetField<int>("LogicalDiskSizeInGB");
            }
            set
            {
                this.SetField("LogicalDiskSizeInGB", value);
            }
        }
        public int LogicalDiskSizeInGB
        {
            get
            {
                return this.GetValue<int>("LogicalDiskSizeInGB");
            }
            set
            {
                this.SetValue("LogicalDiskSizeInGB", value);
            }
        }

        [DataMember(Name = "MediaLink", EmitDefaultValue = false, Order = 5)]
        public Uri MediaLink
        {
            get
            {
                return this.GetValue<Uri>("MediaLink");
            }
            set
            {
                this.SetValue("MediaLink", value);
            }
        }

        [DataMember(Name = "SourceMediaLink", EmitDefaultValue = false, Order = 6)]
        public Uri SourceMediaLink
        {
            get
            {
                return this.GetValue<Uri>("SourceMediaLink");
            }
            set
            {
                this.SetValue("SourceMediaLink", value);
            }
        }


        [DataMember(Name = "IOType", EmitDefaultValue = false, Order = 7)]
        public string IOType
        {
            get
            {
                return this.GetValue<string>("IOType");
            }
            set
            {
                this.SetValue("IOType", value);
            }
        }
    }
    #endregion

    #region OSDisk
    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class OSVirtualHardDisk : Mergable<OSVirtualHardDisk>
    {
        [DataMember(Name = "HostCaching", EmitDefaultValue = false, Order = 0)]
        public string HostCaching
        {
            get
            {
                return this.GetValue<string>("HostCaching");
            }
            set
            {
                this.SetValue("HostCaching", value);
            }
        }

        [DataMember(Name = "DiskLabel", EmitDefaultValue = false, Order = 1)]
        public string DiskLabel
        {
            get
            {
                return this.GetValue<string>("DiskLabel");
            }
            set
            {
                this.SetValue("DiskLabel", value);
            }
        }

        [DataMember(Name = "DiskName", EmitDefaultValue = false, Order = 2)]
        public string DiskName
        {
            get
            {
                return this.GetValue<string>("DiskName");
            }
            set
            {
                this.SetValue("DiskName", value);
            }
        }

        [DataMember(Name = "MediaLink", EmitDefaultValue = false, Order = 3)]
        public Uri MediaLink
        {
            get
            {
                return this.GetValue<Uri>("MediaLink");
            }
            set
            {
                this.SetValue("MediaLink", value);
            }
        }

        [DataMember(Name = "SourceImageName", EmitDefaultValue = false, Order = 4)]
        public string SourceImageName
        {
            get
            {
                return this.GetValue<string>("SourceImageName");
            }
            set
            {
                this.SetValue("SourceImageName", value);
            }
        }

        [DataMember(Name = "OS", EmitDefaultValue = false, Order = 5)]
        public string OS
        {
            get
            {
                return this.GetValue<string>("OS");
            }
            set
            {
                this.SetValue("OS", value);
            }
        }

        [DataMember(Name = "IOType", EmitDefaultValue = false, Order = 5)]
        public string IOType
        {
            get
            {
                return this.GetValue<string>("IOType");
            }
            set
            {
                this.SetValue("IOType", value);
            }
        }

        [DataMember(Name = "ResizedSizeInGB", EmitDefaultValue = false, Order = 6)]
        public int? ResizedSizeInGB
        {
            get
            {
                return this.GetValue<int?>("ResizedSizeInGB");
            }
            set
            {
                this.SetValue("ResizedSizeInGB", value);
            }
        }
    }
    #endregion

    #region VMImageInput
    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class VMImageInput : Mergable<VMImageInput>
    {
        [DataMember(Name = "OSDiskConfiguration", EmitDefaultValue = false, Order = 1)]
        public OSDiskConfiguration OSDiskConfiguration
        {
            get
            {
                return this.GetValue<OSDiskConfiguration>("OSDiskConfiguration");
            }
            set
            {
                this.SetValue("OSDiskConfiguration", value);
            }
        }

        [DataMember(Name = "DataDiskConfigurations", EmitDefaultValue = false, Order = 2)]
        public DataDiskConfigurationList DataDiskConfigurations
        {
            get
            {
                return this.GetValue<DataDiskConfigurationList>("DataDiskConfigurations");
            }
            set
            {
                this.SetValue("DataDiskConfigurations", value);
            }
        }
    }
    #endregion

    #region DebugSettings
    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class DebugSettings : Mergable<DebugSettings>
    {
        [DataMember(Name = "BootDiagnosticsEnabled", EmitDefaultValue = false, Order = 1)]
        public bool BootDiagnosticsEnabled
        {
            get
            {
                return this.GetValue<bool>("BootDiagnosticsEnabled");
            }
            set
            {
                this.SetValue("BootDiagnosticsEnabled", value);
            }
        }

        [DataMember(Name = "ConsoleScreenshotBlobUri", EmitDefaultValue = false, Order = 2)]
        public Uri ConsoleScreenshotBlobUri
        {
            get
            {
                return this.GetValue<Uri>("ConsoleScreenshotBlobUri");
            }
            set
            {
                this.SetValue("ConsoleScreenshotBlobUri", value);
            }
        }

        [DataMember(Name = "SerialOutputBlobUri", EmitDefaultValue = false, Order = 3)]
        public Uri SerialOutputBlobUri
        {
            get
            {
                return this.GetValue<Uri>("SerialOutputBlobUri");
            }
            set
            {
                this.SetValue("SerialOutputBlobUri", value);
            }
        }
    }
    #endregion

    #region RoleOperation
    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class RoleOperation : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public virtual string OperationType
        {
            get;
            set;
        }

        protected RoleOperation()
        {

        }

        #region IExtensibleDataObject Members

        public ExtensionDataObject ExtensionData
        {
            get;
            set;
        }

        #endregion
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class ShutdownRoleOperation : RoleOperation
    {
        public override string OperationType
        {
            get
            {
                return "ShutdownRoleOperation";
            }
            set
            {

            }
        }

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public PostShutdownAction? PostShutdownAction { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public enum PostShutdownAction
    {
        [EnumMember]
        Stopped,

        [EnumMember]
        StoppedDeallocated,

        [EnumMember]
        Undefined
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class StartRoleOperation : RoleOperation
    {
        public override string OperationType
        {
            get
            {
                return "StartRoleOperation";
            }
            set
            {

            }
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class RestartRoleOperation : RoleOperation
    {
        public override string OperationType
        {
            get
            {
                return "RestartRoleOperation";
            }
            set
            {

            }
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class CaptureRoleOperation : RoleOperation
    {
        public override string OperationType
        {
            get
            {
                return "CaptureRoleOperation";
            }
            set
            {

            }
        }

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string PostCaptureAction { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public ProvisioningConfigurationSet ProvisioningConfiguration
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string TargetImageLabel { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string TargetImageName { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public enum PostCaptureAction
    {
        [EnumMember]
        Delete,
        [EnumMember]
        Reprovision
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public enum PowerState
    {
        [EnumMember]
        Unknown,
        [EnumMember]
        Starting,
        [EnumMember]
        Started,
        [EnumMember]
        Stopping,
        [EnumMember]
        Stopped,
    }
    #endregion // RoleOperation

    #region RoleSetOperations

    [CollectionDataContract(Name = "Roles", ItemName = "Name", Namespace = Constants.ServiceManagementNS)]
    public class RoleNamesCollection : Collection<string> { }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class RoleSetOperation : Mergable<RoleSetOperation>
    {
        protected RoleSetOperation() { }

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public virtual string OperationType
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public virtual RoleNamesCollection Roles
        {
            get;
            set;
        }
    }  // RoleSetOperation


    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class ShutdownRolesOperation : RoleSetOperation
    {
        public override string OperationType
        {
            get
            {
                return "ShutdownRolesOperation";
            }
            set
            {
            }
        }

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public PostShutdownAction PostShutdownAction { get; set; }
    } // ShutdownRolesOperation


    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class StartRolesOperation : RoleSetOperation
    {
        public override string OperationType
        {
            get
            {
                return "StartRolesOperation";
            }
            set
            {
            }
        }
    } // StartRolesOperation

    #endregion // RoleSetOperations


    #region ResourceExtension
    [DataContract(Name = "ResourceExtensionParameterValue", Namespace = Constants.ServiceManagementNS)]
    public class ResourceExtensionParameterValue : Mergable<ResourceExtensionParameterValue>
    {
        [DataMember(Name = "Key", EmitDefaultValue = false, Order = 0)]
        public string Key
        {
            get
            {
                return base.GetValue<string>("Key");
            }
            set
            {
                base.SetValue("Key", value);
            }
        }

        [DataMember(Name = "Value", EmitDefaultValue = false, Order = 1)]
        public string Value
        {
            get
            {
                return base.GetValue<string>("Value");
            }
            set
            {
                base.SetValue("Value", value);
            }
        }

        public System.Security.SecureString SecureValue { get; set; }

        [DataMember(Name = "Type", EmitDefaultValue = false, Order = 2)]
        public string Type
        {
            get
            {
                return base.GetValue<string>("Type");
            }
            set
            {
                base.SetValue("Type", value);
            }
        }
    }

    [CollectionDataContract(Name = "ResourceExtensionParameterValues", Namespace = Constants.ServiceManagementNS)]
    public class ResourceExtensionParameterValueList : List<ResourceExtensionParameterValue>
    {
        public ResourceExtensionParameterValueList()
        {
        }

        public ResourceExtensionParameterValueList(IEnumerable<ResourceExtensionParameterValue> values)
            : base(values)
        {
        }
    }


    [DataContract(Name = "ResourceExtensionReference", Namespace = Constants.ServiceManagementNS)]
    public class ResourceExtensionReference : Mergable<ResourceExtensionReference>
    {
        [DataMember(Name = "ReferenceName", EmitDefaultValue = false, Order = 0)]
        public string ReferenceName
        {
            get
            {
                return base.GetValue<string>("ReferenceName");
            }
            set
            {
                base.SetValue("ReferenceName", value);
            }
        }

        [DataMember(Name = "Publisher", EmitDefaultValue = false, Order = 1)]
        public string Publisher
        {
            get
            {
                return base.GetValue<string>("Publisher");
            }
            set
            {
                base.SetValue("Publisher", value);
            }
        }

        [DataMember(Name = "Name", EmitDefaultValue = false, Order = 2)]
        public string Name
        {
            get
            {
                return base.GetValue<string>("Name");
            }
            set
            {
                base.SetValue("Name", value);
            }
        }

        [DataMember(Name = "Version", EmitDefaultValue = false, Order = 3)]
        public string Version
        {
            get
            {
                return base.GetValue<string>("Version");
            }
            set
            {
                base.SetValue("Version", value);
            }
        }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public ResourceExtensionParameterValueList ResourceExtensionParameterValues { get; set; }

        [DataMember(Name = "State", EmitDefaultValue = false, Order = 5)]
        public string State
        {
            get
            {
                return base.GetValue<string>("State");
            }
            set
            {
                base.SetValue("State", value);
            }
        }

        [DataMember(Name = "ForceUpdate", EmitDefaultValue = false, Order = 7)]
        public bool? ForceUpdate
        {
            get
            {
                return base.GetValue<bool?>("ForceUpdate");
            }
            set
            {
                base.SetValue("ForceUpdate", value);
            }
        }
    }

    [CollectionDataContract(Name = "ResourceExtensionReferences", Namespace = Constants.ServiceManagementNS)]
    public class ResourceExtensionReferenceList : List<ResourceExtensionReference>
    {
        public ResourceExtensionReferenceList()
        {
        }

        public ResourceExtensionReferenceList(IEnumerable<ResourceExtensionReference> references)
            : base(references)
        {
        }
    }
    #endregion

    #region Certificate
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class CertificateFile : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string Data;

        [DataMember(Order = 2)]
        public string CertificateFormat { get; set; }

        [DataMember(Order = 3)]
        public string Password { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    #endregion

    #region Network
    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class VirtualNetworkSite : IExtensibleDataObject
    {
        public VirtualNetworkSite(string name)
        {
            this.Name = name;
        }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Name { get; private set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Id { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string Label { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string AffinityGroup { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string State { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public bool InUse { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public AddressSpace AddressSpace { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public SubnetList Subnets { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public DnsSettings Dns { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 10)]
        public Gateway Gateway { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Name = "VirtualNetworkSites", ItemName = "VirtualNetworkSite", Namespace = Constants.ServiceManagementNS)]
    public class VirtualNetworkSiteList : List<VirtualNetworkSite>
    {
        public VirtualNetworkSiteList()
        {
        }

        public VirtualNetworkSiteList(IEnumerable<VirtualNetworkSite> virtualNetworkSites)
            : base(virtualNetworkSites)
        {
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class DnsServer : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Address { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Name = "DnsServers", ItemName = "DnsServer", Namespace = Constants.ServiceManagementNS)]
    public class DnsServerList : List<DnsServer> { }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class DnsSettings : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public DnsServerList DnsServers { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class Gateway : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Profile { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public LocalNetworkSiteList Sites { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public AddressSpace VPNClientAddressPool { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class LocalNetworkSite : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public AddressSpace AddressSpace { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string VpnGatewayAddress { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public ConnectionList Connections { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class Connection : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Type { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Name = "LocalNetworkSites", ItemName = "LocalNetworkSite", Namespace = Constants.ServiceManagementNS)]
    public class LocalNetworkSiteList : List<LocalNetworkSite> { }

    [CollectionDataContract(Name = "AddressPrefixes", ItemName = "AddressPrefix", Namespace = Constants.ServiceManagementNS)]
    public class AddressPrefixList : List<string> { }

    [CollectionDataContract(Name = "Connections", ItemName = "Connection", Namespace = Constants.ServiceManagementNS)]
    public class ConnectionList : List<Connection> { }


    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class AddressSpace : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public AddressPrefixList AddressPrefixes { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class Subnet : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string AddressPrefix { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Name = "Subnets", ItemName = "Subnet", Namespace = Constants.ServiceManagementNS)]
    public class SubnetList : List<Subnet> { }


    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public enum GatewaySize
    {
        [EnumMember]
        Small = 0,

        [EnumMember]
        Medium = 1,

        [EnumMember]
        Large = 2,

        [EnumMember]
        ExtraLarge = 3
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public enum NetworkState
    {
        [EnumMember]
        Created = 0,

        [EnumMember]
        Creating = 1,

        [EnumMember]
        Updating = 2,

        [EnumMember]
        Deleting = 3,

        [EnumMember]
        Unavailable = 4
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class ReservedIP : IExtensibleDataObject
    {
        public ReservedIP(string name)
        {
            this.Name = name;
        }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Name { get; private set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Address { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string Id { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string Label { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string AffinityGroup { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string State { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public bool InUse { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string ServiceName { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public string DeploymentName { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Name = "ReservedIPs", ItemName = "ReservedIP", Namespace = Constants.ServiceManagementNS)]
    public class ReservedIPList : List<ReservedIP>
    {
        public ReservedIPList()
        {
        }

        public ReservedIPList(IEnumerable<ReservedIP> reservedIPs)
            : base(reservedIPs)
        {
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public enum ReservedIPState
    {
        [EnumMember]
        Created = 0,

        [EnumMember]
        Creating = 1,

        [EnumMember]
        Updating = 2,

        [EnumMember]
        Deleting = 3,

        [EnumMember]
        Unavailable = 4,
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class AddressAvailabilityResponse : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public bool IsAvailable { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public List<string> AvailableAddresses { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
    #endregion

    #region Role
    [DataContract(Namespace = Constants.ServiceManagementNS)]
    [KnownType(typeof(PersistentVMRole))]
    public class Role : Mergable<PersistentVMRole>
    {
        [DataMember(Order = 1)]
        public virtual string RoleName { get; set; }

        [DataMember(Order = 2)]
        public string OsVersion { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public virtual string RoleType { get; set; }

        [DataMember(Name = "ConfigurationSets", EmitDefaultValue = false, Order = 4)]
        public Collection<ConfigurationSet> ConfigurationSets
        {
            get
            {
                return this.GetValue<Collection<ConfigurationSet>>("ConfigurationSets");
            }
            set
            {
                base.SetValue("ConfigurationSets", value);
            }
        }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public ResourceExtensionReferenceList ResourceExtensionReferences
        {
            get
            {
                return this.GetValue<ResourceExtensionReferenceList>("ResourceExtensionReferences");
            }
            set
            {
                base.SetValue("ResourceExtensionReferences", value);
            }
        }

        public NetworkConfigurationSet NetworkConfigurationSet
        {
            get
            {
                if (ConfigurationSets == null)
                {
                    return null;
                }
                return ConfigurationSets.FirstOrDefault(
                   cset => cset is NetworkConfigurationSet) as NetworkConfigurationSet;
            }
            set
            {
                if (ConfigurationSets == null)
                {
                    ConfigurationSets = new Collection<ConfigurationSet>();
                }
                NetworkConfigurationSet networkConfigurationSet = ConfigurationSets.FirstOrDefault(
                        cset => cset is NetworkConfigurationSet) as NetworkConfigurationSet;

                if (networkConfigurationSet != null)
                {
                    ConfigurationSets.Remove(networkConfigurationSet);
                }

                ConfigurationSets.Add(value);
            }
        }

        public override object ResolveType()
        {
            if (this.GetType() != typeof(Role))
            {
                return this;
            }

            if (this.RoleType == typeof(PersistentVMRole).Name)
            {
                return base.Convert<PersistentVMRole>();
            }
            return this;
        }
    }
    #endregion

    #region PersistentVMRole
    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class PersistentVMRole : Role
    {
        private static class PersistentVMRoleConstants
        {
            public const string RoleName = "RoleName";
            public const string AvailabilitySetName = "AvailabilitySetName";
            public const string DataVirtualHardDisks = "DataVirtualHardDisks";
            public const string Label = "Label";
            public const string OSVirtualHardDisk = "OSVirtualHardDisk";
            public const string RoleSize = "RoleSize";
            public const string DefaultWinRmCertificateThumbprint = "DefaultWinRmCertificateThumbprint";
            public const string ProvisionGuestAgent = "ProvisionGuestAgent";
        }

        public override string RoleName
        {
            get
            {
                return this.GetValue<string>(PersistentVMRoleConstants.RoleName);
            }
            set
            {
                this.SetValue(PersistentVMRoleConstants.RoleName, value);
            }
        }

        [DataMember(Name = PersistentVMRoleConstants.AvailabilitySetName, EmitDefaultValue = false, Order = 0)]
        public string AvailabilitySetName
        {
            get
            {
                return this.GetValue<string>(PersistentVMRoleConstants.AvailabilitySetName);
            }
            set
            {
                this.SetValue(PersistentVMRoleConstants.AvailabilitySetName, value);
            }
        }

        [DataMember(Name = PersistentVMRoleConstants.DataVirtualHardDisks, EmitDefaultValue = false, Order = 1)]
        public Collection<DataVirtualHardDisk> DataVirtualHardDisks
        {
            get
            {
                return base.GetValue<Collection<DataVirtualHardDisk>>(PersistentVMRoleConstants.DataVirtualHardDisks);
            }
            set
            {
                base.SetValue(PersistentVMRoleConstants.DataVirtualHardDisks, value);
            }
        }

        [DataMember(Name = PersistentVMRoleConstants.Label, EmitDefaultValue = false, Order = 2)]
        public string Label
        {
            get
            {
                return base.GetValue<string>(PersistentVMRoleConstants.Label);
            }
            set
            {
                base.SetValue(PersistentVMRoleConstants.Label, value);
            }
        }

        [DataMember(Name = PersistentVMRoleConstants.OSVirtualHardDisk, EmitDefaultValue = false, Order = 3)]
        public OSVirtualHardDisk OSVirtualHardDisk
        {
            get
            {
                return base.GetValue<OSVirtualHardDisk>(PersistentVMRoleConstants.OSVirtualHardDisk);
            }
            set
            {
                base.SetValue(PersistentVMRoleConstants.OSVirtualHardDisk, value);
            }
        }

        [DataMember(Name = PersistentVMRoleConstants.RoleSize, EmitDefaultValue = false, Order = 4)]
        public string RoleSize
        {
            get
            {
                return this.GetValue<string>(PersistentVMRoleConstants.RoleSize);
            }
            set
            {
                this.SetValue(PersistentVMRoleConstants.RoleSize, value);
            }
        }

        public override string RoleType
        {
            get
            {
                return typeof(PersistentVMRole).Name;
            }
            set
            {
                base.RoleType = value;
            }
        }

        [DataMember(Name = PersistentVMRoleConstants.DefaultWinRmCertificateThumbprint, EmitDefaultValue = false, Order = 5)]
        public string DefaultWinRmCertificateThumbprint
        {
            get
            {
                return base.GetValue<string>(PersistentVMRoleConstants.DefaultWinRmCertificateThumbprint);
            }
            set
            {
                base.SetValue(PersistentVMRoleConstants.DefaultWinRmCertificateThumbprint, value);
            }
        }

        [DataMember(Name = PersistentVMRoleConstants.ProvisionGuestAgent, EmitDefaultValue = false, Order = 6)]
        public bool? ProvisionGuestAgent
        {
            get
            {
                return base.GetValue<bool?>(PersistentVMRoleConstants.ProvisionGuestAgent);
            }
            set
            {
                base.SetValue(PersistentVMRoleConstants.ProvisionGuestAgent, value);
            }
        }
    }
    #endregion

    [CollectionDataContract(Namespace = Constants.ServiceManagementNS)]
    public class InstanceEndpointList : List<InstanceEndpoint> { }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class InstanceEndpoint : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Vip { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public int PublicPort { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public int LocalPort { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string Protocol { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public int? IdleTimeoutInMinutes { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Namespace = Constants.ServiceManagementNS, Name = "NetworkInterfaces", ItemName = "NetworkInterface")]
    public class NetworkInterfaceList : List<NetworkInterface>, IExtensibleDataObject
    {
        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class NetworkInterface : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string MacAddress { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public IPConfigurationList IpConfigurations { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Namespace = Constants.ServiceManagementNS, Name = "IPConfigurations", ItemName = "IPConfiguration")]
    public class IPConfigurationList : List<IPConfiguration>, IExtensibleDataObject
    {
        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class IPConfiguration : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string SubnetName { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Address { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Namespace = Constants.ServiceManagementNS, Name = "AvailableServices", ItemName = "AvailableService")]
    public class AvailableServicesList : List<string>, IExtensibleDataObject
    {
        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class OSDiskConfiguration : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string Name
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string HostCaching
        {
            get;
            set;
        }


        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string OSState
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string OS
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public Uri MediaLink
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public int LogicalDiskSizeInGB
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string IOType
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public int ResizedSizeInGB
        {
            get;
            set;
        }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class DataDiskConfiguration : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string Name
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string HostCaching
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public int Lun
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public Uri MediaLink
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public int LogicalDiskSizeInGB
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string IOType
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public int ResizedSizeInGB
        {
            get;
            set;
        }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Name = "DataDiskConfigurations", ItemName = "DataDiskConfiguration", Namespace = Constants.ServiceManagementNS)]
    public class DataDiskConfigurationList : Collection<DataDiskConfiguration> { }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class VMImage
    {
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string Name
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Label
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Category
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string Description
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public OSDiskConfiguration OSDiskConfiguration
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public DataDiskConfigurationList DataDiskConfigurations
        {
            get;
            set;
        }


        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string ServiceName
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string DeploymentName
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public string RoleName
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string Location
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public string AffinityGroup
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 10)]
        public DateTime CreatedTime
        {
            get;
            set;
        }
    }

    [CollectionDataContract(Name = "VMImages", ItemName = "VMImage", Namespace = Constants.ServiceManagementNS)]
    public class VMImageList : Collection<VMImage>
    {
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class GuestAgentStatus : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string ProtocolVersion { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2, Name = "Timestamp")]
        private string _isoTimestampString { get; set; }

        public DateTime? TimestampUtc
        {
            get
            {
                return (string.IsNullOrEmpty(this._isoTimestampString) ? DateTime.MinValue : DateTime.Parse(this._isoTimestampString));
            }
            set
            {
                if (value.Equals(DateTime.MinValue))
                {
                    this._isoTimestampString = null;
                }
                else
                {
                    this._isoTimestampString = !value.HasValue ? string.Empty : value.Value.ToUniversalTime().ToString(Constants.StandardTimeFormat);
                }
            }
        }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string GuestAgentVersion { get; set; }

        // Status is one of: "Ready", "NotReady".
        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string Status { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public int? Code { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public GuestAgentMessage Message { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public GuestAgentFormattedMessage FormattedMessage { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class GuestAgentMessage : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string MessageResourceId { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public GuestAgentMessageParamList ParamList { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(ItemName = "Param", Namespace = Constants.ServiceManagementNS)]
    public class GuestAgentMessageParamList : List<string>
    {
        public GuestAgentMessageParamList()
        {
        }

        public GuestAgentMessageParamList(IEnumerable<string> list)
            : base(list)
        {
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class GuestAgentFormattedMessage : IExtensibleDataObject
    {
        // Language is either "Language" or "Language-Locale".
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Language { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Message { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(ItemName = "ResourceExtensionStatus", Namespace = Constants.ServiceManagementNS)]
    public class ResourceExtensionStatusList : List<ResourceExtensionStatus>
    {
        public ResourceExtensionStatusList()
        {
        }

        public ResourceExtensionStatusList(IEnumerable<ResourceExtensionStatus> list)
            : base(list)
        {
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class ResourceExtensionStatus : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string HandlerName { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Version { get; set; }

        // Status is one of: "Installing", "Ready", "NotReady", "Unresponsive".
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string Status { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public int? Code { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public GuestAgentMessage Message { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public GuestAgentFormattedMessage FormattedMessage { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public ResourceExtensionConfigurationStatus ExtensionSettingStatus { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class ResourceExtensionConfigurationStatus : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1, Name = "Timestamp")]
        private string _isoTimestampString { get; set; }

        public DateTime? TimestampUtc
        {
            get
            {
                return (string.IsNullOrEmpty(this._isoTimestampString) ? DateTime.MinValue : DateTime.Parse(this._isoTimestampString));
            }
            set
            {
                if (value.Equals(DateTime.MinValue))
                {
                    this._isoTimestampString = null;
                }
                else
                {
                    this._isoTimestampString = !value.HasValue ? string.Empty : value.Value.ToUniversalTime().ToString(Constants.StandardTimeFormat);
                }
            }
        }

        [DataMember(EmitDefaultValue = false, Order = 2, Name = "ConfigurationAppliedTime")]
        private string _isoConfigurationAppliedTimeString { get; set; }

        public DateTime? ConfigurationAppliedTimeUtc
        {
            get
            {
                return (string.IsNullOrEmpty(this._isoConfigurationAppliedTimeString) ? DateTime.MinValue : DateTime.Parse(this._isoConfigurationAppliedTimeString));
            }
            set
            {
                if (value.Equals(DateTime.MinValue))
                {
                    this._isoConfigurationAppliedTimeString = null;
                }
                else
                {
                    this._isoConfigurationAppliedTimeString = !value.HasValue ? string.Empty : value.Value.ToUniversalTime().ToString(Constants.StandardTimeFormat);
                }
            }
        }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string Operation { get; set; }

        // Status is one of: "transitioning", "error", "success", "warning".
        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string Status { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public int Code { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public GuestAgentMessage Message { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public GuestAgentFormattedMessage FormattedMessage { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public ResourceExtensionSubStatusList SubStatusList { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(ItemName = "SubStatus", Namespace = Constants.ServiceManagementNS)]
    public class ResourceExtensionSubStatusList : List<ResourceExtensionSubStatus>
    {
        public ResourceExtensionSubStatusList()
        {
        }

        public ResourceExtensionSubStatusList(IEnumerable<ResourceExtensionSubStatus> list)
            : base(list)
        {
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class ResourceExtensionSubStatus : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Name { get; set; }

        // Status is one of: "transitioning", "error", "success", "warning".
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Status { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public int Code { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public GuestAgentMessage Message { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public GuestAgentFormattedMessage FormattedMessage { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Namespace = Constants.ServiceManagementNS)]
    public class PublicIPList : List<PublicIP> { }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class PublicIP : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Address { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public int? IdleTimeoutInMinutes { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string DomainNameLabel { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public FqdnsList Fqdns { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Name = "Fqdns", ItemName = "Fqdn", Namespace = Constants.ServiceManagementNS)]
    public class FqdnsList : List<string>
    {
        public FqdnsList()
        {

        }

        public FqdnsList(IEnumerable<string> fqdns)
            : base(fqdns)
        {

        }
    }

    [CollectionDataContract(Name = "LoadBalancers", ItemName = "LoadBalancer", Namespace = Constants.ServiceManagementNS)]
    public class LoadBalancerList : List<LoadBalancer>
    {
        public LoadBalancerList()
        {

        }

        public LoadBalancerList(IEnumerable<LoadBalancer> ips)
            : base(ips)
        {

        }
    }

    /// <summary>
    /// Represents a <see cref="LoadBalancer"/>
    /// </summary>
    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class LoadBalancer : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "FrontendIpConfiguration", EmitDefaultValue = false, Order = 2)]
        public IpConfiguration FrontEndIpConfiguration { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    /// <summary>
    /// Represents a <see cref="IpConfiguration"/>
    /// </summary>
    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class IpConfiguration : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public LoadBalancerType Type { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string SubnetName { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string StaticVirtualNetworkIPAddress { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    /// <summary>
    /// Represents the type of a load balancer.
    /// </summary>
    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public enum LoadBalancerType
    {
        [EnumMember]
        Unknown = 0,

        [EnumMember]
        Private = 1,
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
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
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
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
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
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
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


    [CollectionDataContract(Name = "AffinityGroups", ItemName = "AffinityGroup", Namespace = Constants.ServiceManagementNS)]
    public class AffinityGroupList : List<AffinityGroup>
    {
        public AffinityGroupList()
        {
        }

        public AffinityGroupList(IEnumerable<AffinityGroup> affinityGroups)
            : base(affinityGroups)
        {
        }
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
    public class AffinityGroup : IExtensibleDataObject
    {
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Order = 2, Name = "Label")]
        private string _base64EncodedLabel { get; set; }

        public string Label
        {
            get
            {
                string decodedLabel;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedLabel, out decodedLabel))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedLabel;
            }
            set
            {
                this._base64EncodedLabel = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(Order = 3)]
        public string Description { get; set; }

        [DataMember(Order = 4)]
        public string Location { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public HostedServiceList HostedServices { get; set; }

        [DataMember(Order = 6, EmitDefaultValue = false)]
        public StorageServiceList StorageServices { get; set; }

        //Use ComputeCapabilities for the compute related things. In new API this should not be used
        //as it doesn't give the good idea of what capabilities are supported.
        [DataMember(Order = 7, EmitDefaultValue = false)]
        public CapabilitiesList Capabilities { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8, Name = "CreatedTime")]
        private string _isoCreatedTimeString { get; set; }

        public DateTime CreatedTime
        {
            get
            {
                return (string.IsNullOrEmpty(this._isoCreatedTimeString) ? DateTime.MinValue : DateTime.Parse(this._isoCreatedTimeString));
            }
            set
            {
                if (value.Equals(DateTime.MinValue))
                {
                    this._isoCreatedTimeString = null;
                }
                else
                {
                    this._isoCreatedTimeString = value.ToString(Constants.StandardTimeFormat);
                }
            }
        }
        [DataMember(Order = 9, EmitDefaultValue = false)]
        public ComputeCapabilities ComputeCapabilities { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Name = "CreateAffinityGroup", Namespace = Constants.ServiceManagementNS)]
    public class CreateAffinityGroupInput : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 2, Name = "Label")]
        private string _base64EncodedLabel { get; set; }

        public string Label
        {
            get
            {
                string decodedLabel;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedLabel, out decodedLabel))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedLabel;
            }
            set
            {
                this._base64EncodedLabel = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(Order = 4)]
        public string Location { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Name = "UpdateAffinityGroup", Namespace = Constants.ServiceManagementNS)]
    public class UpdateAffinityGroupInput : IExtensibleDataObject
    {
        [DataMember(Order = 1, Name = "Label")]
        private string _base64EncodedLabel { get; set; }

        public string Label
        {
            get
            {
                string decodedLabel;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedLabel, out decodedLabel))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedLabel;
            }
            set
            {
                this._base64EncodedLabel = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string LocationConstraint { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Name = "HostedServices", ItemName = "HostedService", Namespace = Constants.ServiceManagementNS)]
    public class HostedServiceList : List<HostedService>
    {
        public HostedServiceList()
        {
        }

        public HostedServiceList(IEnumerable<HostedService> hostedServices)
            : base(hostedServices)
        {
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class HostedService : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public Uri Url { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string ServiceName { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public HostedServiceProperties HostedServiceProperties { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public DeploymentList Deployments { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public bool? IsComplete { get; set; }

        [DataMember(Order = 6, EmitDefaultValue = false)]
        public string DefaultWinRmCertificateThumbprint { get; set; }

        [DataMember(Order = 7, EmitDefaultValue = false)]
        public ComputeCapabilities ComputeCapabilities { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Name = "Deployments", ItemName = "Deployment", Namespace = Constants.ServiceManagementNS)]
    public class DeploymentList : List<Deployment>
    {
        public DeploymentList()
        {
        }

        public DeploymentList(IEnumerable<Deployment> deployments)
            : base(deployments)
        {
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class HostedServiceProperties : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string Description { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string AffinityGroup { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string Location { get; set; }

        [DataMember(Order = 4, Name = "Label")]
        private string _base64EncodedLabel { get; set; }

        public string Label
        {
            get
            {
                string decodedLabel;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedLabel, out decodedLabel))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedLabel;
            }
            set
            {
                this._base64EncodedLabel = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string Status { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6, Name = "DateCreated")]
        private string _isoDateCreatedString { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Anvil.RdUsage!TimeUtc", "27102",
            Justification = "fixing it at this stage might break the old behavior/interface since DateCreated is customer facing and there is a lot of existing data")]
        public DateTime DateCreated
        {
            get
            {
                return (string.IsNullOrEmpty(this._isoDateCreatedString) ? new DateTime() : DateTime.Parse(this._isoDateCreatedString));
            }
            set
            {
                this._isoDateCreatedString = value.ToString(Constants.StandardTimeFormat);
            }
        }

        [DataMember(EmitDefaultValue = false, Order = 7, Name = "DateLastModified")]
        private string _isoDateLastModifiedString { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Anvil.RdUsage!TimeUtc", "27102",
            Justification = "fixing it at this stage might break the old behavior/interface since DateLastModified is customer facing and there is a lot of existing data")]
        public DateTime DateLastModified
        {
            get
            {
                return (string.IsNullOrEmpty(this._isoDateLastModifiedString) ? new DateTime() : DateTime.Parse(this._isoDateLastModifiedString));
            }
            set
            {
                this._isoDateLastModifiedString = value.ToString(Constants.StandardTimeFormat);
            }
        }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public ExtendedPropertiesList ExtendedProperties { get; set; }

        [DataMember(Order = 9, EmitDefaultValue = false)]
        public string GuestAgentType { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 10)]
        public string ReverseDnsFqdn { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Name = "Locations", ItemName = "Location", Namespace = Constants.ServiceManagementNS)]
    public class LocationList : List<Location>
    {
        public LocationList()
        {
        }

        public LocationList(IEnumerable<Location> locations)
            : base(locations)
        {
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class Location : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public AvailableServicesList AvailableServices { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public ComputeCapabilities ComputeCapabilities { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class ComputeCapabilities : IExtensibleDataObject
    {

        [DataMember(Order = 1, EmitDefaultValue = false)]
        public WebWorkerRoleSizes WebWorkerRoleSizes { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public VirtualMachinesRoleSizes VirtualMachinesRoleSizes { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Namespace = Constants.ServiceManagementNS, ItemName = "RoleSize")]
    public class WebWorkerRoleSizes : List<String>
    {
        public WebWorkerRoleSizes()
        {
        }

        public WebWorkerRoleSizes(IEnumerable<String> webWorkerRoleSizes)
            : base(webWorkerRoleSizes)
        {
        }
    }

    [CollectionDataContract(Namespace = Constants.ServiceManagementNS, ItemName = "RoleSize")]
    public class VirtualMachinesRoleSizes : List<String>
    {
        public VirtualMachinesRoleSizes()
        {
        }

        public VirtualMachinesRoleSizes(IEnumerable<String> virtualMachinesRoleSizes)
            : base(virtualMachinesRoleSizes)
        {
        }
    }

    [DataContract(Name = "CreateHostedService", Namespace = Constants.ServiceManagementNS)]
    public class CreateHostedServiceInput : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string ServiceName { get; set; }

        [DataMember(Order = 2, Name = "Label")]
        private string _base64EncodedLabel { get; set; }

        public string Label
        {
            get
            {
                string decodedLabel;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedLabel, out decodedLabel))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedLabel;
            }
            set
            {
                this._base64EncodedLabel = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public string Location { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public string AffinityGroup { get; set; }

        [DataMember(Order = 6, EmitDefaultValue = false)]
        public ExtendedPropertiesList ExtendedProperties { get; set; }

        [DataMember(Order = 7, EmitDefaultValue = false)]
        public string ReverseDnsFqdn { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Name = "UpdateHostedService", Namespace = Constants.ServiceManagementNS)]
    public class UpdateHostedServiceInput : IExtensibleDataObject
    {
        [DataMember(Order = 1, EmitDefaultValue = false, Name = "Label")]
        private string _base64EncodedLabel { get; set; }

        public string Label
        {
            get
            {
                string decodedLabel;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedLabel, out decodedLabel))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedLabel;
            }
            set
            {
                this._base64EncodedLabel = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string Location { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public string AffinityGroup { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public ExtendedPropertiesList ExtendedProperties { get; set; }
        [DataMember(Order = 6, EmitDefaultValue = false)]
        public string GuestAgentType { get; set; }

        [DataMember(Order = 7, EmitDefaultValue = false)]
        public string ReverseDnsFqdn { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Name = "AvailabilityResponse", Namespace = Constants.ServiceManagementNS)]
    public class AvailabilityResponse : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public bool Result { get; set; }
        [DataMember(Order = 2)]
        public string Reason { get; set; }
        public ExtensionDataObject ExtensionData { get; set; }
    }


    [DataContract(Name = "Swap", Namespace = Constants.ServiceManagementNS)]
    public class SwapDeploymentInput : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string Production { get; set; }

        [DataMember(Order = 2)]
        public string SourceDeployment { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class Deployment : IExtensibleDataObject
    {
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string DeploymentSlot { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string PrivateID { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public string Status { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false, Name = "Label")]
        private string _base64EncodedLabel { get; set; }

        public string Label
        {
            get
            {
                string decodedLabel;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedLabel, out decodedLabel))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedLabel;
            }
            set
            {
                this._base64EncodedLabel = value;
            }
        }


        [DataMember(Order = 6, EmitDefaultValue = false)]
        public Uri Url { get; set; }

        [DataMember(Order = 7, EmitDefaultValue = false, Name = "Configuration")]
        private string _base64EncodedConfiguration { get; set; }

        public string Configuration
        {
            get
            {
                string decodedConfiguration;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedConfiguration, out decodedConfiguration))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedConfiguration;
            }
            set
            {
                this._base64EncodedConfiguration = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(Order = 8, EmitDefaultValue = false)]
        public RoleInstanceList RoleInstanceList { get; set; }

        [DataMember(Order = 10, EmitDefaultValue = false)]
        public UpgradeStatus UpgradeStatus { get; set; }

        [DataMember(Order = 11, EmitDefaultValue = false)]
        public int UpgradeDomainCount { get; set; }

        [DataMember(Order = 12, EmitDefaultValue = false)]
        public RoleList RoleList { get; set; }

        [DataMember(Order = 13, EmitDefaultValue = false)]
        public string SdkVersion { get; set; }

        [DataMember(Order = 14, EmitDefaultValue = false)]
        public DeploymentInputEndpointList InputEndpointList { get; set; }

        [DataMember(Order = 15, EmitDefaultValue = false)]
        public bool? Locked { get; set; }

        [DataMember(Order = 16, EmitDefaultValue = false)]
        public bool? RollbackAllowed { get; set; }

        [DataMember(Order = 17, EmitDefaultValue = false)]
        public string VirtualNetworkName { get; set; }

        [DataMember(Order = 18, EmitDefaultValue = false, Name = "CreatedTime")]
        private string _isoCreatedTimeString { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Anvil.RdUsage!TimeUtc", "27102",
            Justification = "fixing it at this stage might break the old behavior/interface since CreatedTime is customer facing and there is a lot of existing data")]
        public DateTime CreatedTime
        {
            get
            {
                return (string.IsNullOrEmpty(this._isoCreatedTimeString) ? new DateTime() : DateTime.Parse(this._isoCreatedTimeString));
            }
            set
            {
                if (value.Equals(DateTime.MinValue))
                {
                    this._isoCreatedTimeString = null;
                }
                else
                {
                    this._isoCreatedTimeString = value.ToString(Constants.StandardTimeFormat);
                }
            }
        }

        [DataMember(Order = 19, EmitDefaultValue = false, Name = "LastModifiedTime")]
        private string _isoLastModifiedTimeString { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Anvil.RdUsage!TimeUtc", "27102",
            Justification = "fixing it at this stage might break the old behavior/interface since LastModifiedTime is customer facing and there is a lot of existing data")]
        public DateTime LastModifiedTime
        {
            get
            {
                return (string.IsNullOrEmpty(this._isoLastModifiedTimeString) ? new DateTime() : DateTime.Parse(this._isoLastModifiedTimeString));
            }
            set
            {
                this._isoLastModifiedTimeString = value.ToString(Constants.StandardTimeFormat);
            }
        }

        [DataMember(Order = 20, EmitDefaultValue = false)]
        public ExtendedPropertiesList ExtendedProperties { get; set; }

        [DataMember(Order = 21, EmitDefaultValue = false)]
        public DnsSettings Dns { get; set; }

        [DataMember(Order = 22, EmitDefaultValue = false)]
        public PersistentVMDowntimeInfo PersistentVMDowntime;

        [DataMember(Order = 23, EmitDefaultValue = false)]
        public VirtualIPList VirtualIPs { get; set; }

        [DataMember(Order = 23, EmitDefaultValue = false)]
        public ExtensionConfiguration ExtensionConfiguration { get; set; }

        [DataMember(Order = 24, EmitDefaultValue = false)]
        public string ReservedIPName { get; set; }

        //
        // Note: Setting Order = 26 below to accomodate for the duplicate 
        // order values (23) above which should be fixed.
        //

        // This is the IDNS FQDN suffix, e.g. "hostedservice.a1.internal.cloudapp.net".
        [DataMember(Order = 26, EmitDefaultValue = false)]
        public string InternalDnsSuffix { get; set; }

        [DataMember(Order = 27, EmitDefaultValue = false)]
        public LoadBalancerList LoadBalancers { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class OutboundNatVirtualIP : IExtensibleDataObject
    {
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string Address { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string Name { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }

        #region Implements Equals
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            OutboundNatVirtualIP vip = obj as OutboundNatVirtualIP;
            if (vip == null)
            {
                return false;
            }

            return this == vip;
        }

        public static bool operator ==(OutboundNatVirtualIP left, OutboundNatVirtualIP right)
        {
            if (Object.ReferenceEquals(left, right))
            {
                return true;
            }

            if ((object)left == null && (object)right == null)
            {
                return true;
            }

            if ((object)left == null || (object)right == null)
            {
                return false;
            }

            return string.Equals(left.Address, right.Address, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(left.Name, right.Name, StringComparison.OrdinalIgnoreCase);
        }

        public static bool operator !=(OutboundNatVirtualIP left, OutboundNatVirtualIP right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return this.Address.GetHashCode();
        }
        #endregion
    }

    [CollectionDataContract(Name = "OutboundNatVirtualIPs", ItemName = "OutboundNatVirtualIP", Namespace = Constants.ServiceManagementNS)]
    public class OutboundNatVirtualIPList : List<OutboundNatVirtualIP>
    {
        public OutboundNatVirtualIPList()
        {

        }

        public OutboundNatVirtualIPList(IEnumerable<OutboundNatVirtualIP> ips)
            : base(ips)
        {

        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class OutboundNatVirtualIPGroup : IExtensibleDataObject
    {
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string VipGroupName { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public OutboundNatVirtualIPList OutboundNatVirtualIPs { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Name = "OutboundNatVirtualIPGroups", ItemName = "OutboundNatVirtualIPGroup", Namespace = Constants.ServiceManagementNS)]
    public class OutboundNatVirtualIPGroups : List<OutboundNatVirtualIPGroup>
    {
        public OutboundNatVirtualIPGroups()
        {
        }

        public OutboundNatVirtualIPGroups(IEnumerable<OutboundNatVirtualIPGroup> groups)
            : base(groups)
        {
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class PersistentVMDowntimeInfo : IExtensibleDataObject
    {
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public DateTime? StartTime { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public DateTime? EndTime { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string Status { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Name = "RoleList", ItemName = "Role", Namespace = Constants.ServiceManagementNS)]
    public class RoleList : List<Role>
    {
        public RoleList()
        {
        }

        public RoleList(IEnumerable<Role> roles)
            : base(roles)
        {
        }
    }

    [CollectionDataContract(Name = "InputEndpointList", ItemName = "InputEndpoint", Namespace = Constants.ServiceManagementNS)]
    public class DeploymentInputEndpointList : List<DeploymentInputEndpoint>
    {
        public DeploymentInputEndpointList()
        {
        }

        public DeploymentInputEndpointList(IEnumerable<DeploymentInputEndpoint> endpoints)
            : base(endpoints)
        {
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class DeploymentInputEndpoint : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string RoleName { get; set; }

        [DataMember(Order = 2)]
        public string Vip { get; set; }

        [DataMember(Order = 3)]
        public int Port { get; set; }

        [DataMember(Order = 4)]
        public int? IdleTimeoutInMinutes { get; set; }

        [DataMember(Order = 5)]
        public string LoadBalancerDistribution { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Name = "RoleInstanceList", ItemName = "RoleInstance", Namespace = Constants.ServiceManagementNS)]
    public class RoleInstanceList : List<RoleInstance>
    {
        public RoleInstanceList()
        {
        }

        public RoleInstanceList(IEnumerable<RoleInstance> roles)
            : base(roles)
        {
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class RoleInstance : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string RoleName { get; set; }

        [DataMember(Order = 2)]
        public string InstanceName { get; set; }

        [DataMember(Order = 3)]
        public string InstanceStatus { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public int? InstanceUpgradeDomain { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public int? InstanceFaultDomain { get; set; }

        [DataMember(Order = 6, EmitDefaultValue = false)]
        public string InstanceSize { get; set; }

        [DataMember(Order = 7, EmitDefaultValue = false)]
        public string InstanceStateDetails { get; set; }

        [DataMember(Order = 8, EmitDefaultValue = false)]
        public string InstanceErrorCode { get; set; }

        [DataMember(Order = 10, EmitDefaultValue = false)]
        public string IpAddress { get; set; }

        [DataMember(Order = 11, EmitDefaultValue = false)]
        public InstanceEndpointList InstanceEndpoints { get; set; }

        [DataMember(Order = 12, EmitDefaultValue = false)]
        public string PowerState { get; set; }

        [DataMember(Order = 13, EmitDefaultValue = false)]
        public string HostName { get; set; }

        [DataMember(Order = 14, EmitDefaultValue = false)]
        public string RemoteAccessCertificateThumbprint { get; set; }

        // Order 15 is purposely skipped due to a property being removed before being published.

        [DataMember(Order = 16, EmitDefaultValue = false)]
        public GuestAgentStatus GuestAgentStatus { get; set; }

        [DataMember(Order = 17, EmitDefaultValue = false)]
        public ResourceExtensionStatusList ResourceExtensionStatusList { get; set; }

        [DataMember(Order = 18, EmitDefaultValue = false)]
        public string ExtendedInstanceStatus { get; set; }

        [DataMember(Order = 19, EmitDefaultValue = false)]
        public PublicIPList PublicIPs { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Name = "RoleInstances", ItemName = "Name", Namespace = Constants.ServiceManagementNS)]
    public class RoleInstanceNamesCollection : Collection<string> { }

    [DataContract(Name = "CreateDeployment", Namespace = Constants.ServiceManagementNS)]
    public class CreateDeploymentInput : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 2)]
        public Uri PackageUrl { get; set; }

        [DataMember(Order = 3, Name = "Label")]
        private string _base64EncodedLabel { get; set; }

        public string Label
        {
            get
            {
                string decodedLabel;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedLabel, out decodedLabel))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedLabel;
            }
            set
            {
                this._base64EncodedLabel = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(Order = 4, Name = "Configuration")]
        private string _base64EncodedConfiguration { get; set; }

        public string Configuration
        {
            get
            {
                string decodedConfiguration;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedConfiguration, out decodedConfiguration))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedConfiguration;
            }
            set
            {
                this._base64EncodedConfiguration = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public bool? StartDeployment { get; set; }

        [DataMember(Order = 6, EmitDefaultValue = false)]
        public bool? TreatWarningsAsError { get; set; }

        [DataMember(Order = 7, EmitDefaultValue = false)]
        public ExtendedPropertiesList ExtendedProperties { get; set; }

        [DataMember(Order = 8, EmitDefaultValue = false)]
        public ExtensionConfiguration ExtensionConfiguration { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Name = "ChangeConfiguration", Namespace = Constants.ServiceManagementNS)]
    public class ChangeConfigurationInput : IExtensibleDataObject
    {
        [DataMember(Order = 1, Name = "Configuration")]
        private string _base64EncodedConfiguration { get; set; }

        public string Configuration
        {
            get
            {
                string decodedConfiguration;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedConfiguration, out decodedConfiguration))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedConfiguration;
            }
            set
            {
                this._base64EncodedConfiguration = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public bool? TreatWarningsAsError { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string Mode { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public ExtendedPropertiesList ExtendedProperties { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public ExtensionConfiguration ExtensionConfiguration { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Name = "UpdateDeploymentStatus", Namespace = Constants.ServiceManagementNS)]
    public class UpdateDeploymentStatusInput : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string Status { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Name = "UpgradeDeployment", Namespace = Constants.ServiceManagementNS)]
    public class UpgradeDeploymentInput : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string Mode { get; set; }

        [DataMember(Order = 2)]
        public Uri PackageUrl { get; set; }

        [DataMember(Order = 3, Name = "Configuration")]
        private string _base64EncodedConfiguration { get; set; }

        public string Configuration
        {
            get
            {
                string decodedConfiguration;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedConfiguration, out decodedConfiguration))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedConfiguration;
            }
            set
            {
                this._base64EncodedConfiguration = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(Order = 4, Name = "Label")]
        private string _base64EncodedLabel { get; set; }

        public string Label
        {
            get
            {
                string decodedLabel;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedLabel, out decodedLabel))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedLabel;
            }
            set
            {
                this._base64EncodedLabel = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(Order = 5)]
        public string RoleToUpgrade { get; set; }

        [DataMember(Order = 6, EmitDefaultValue = false)]
        public bool? TreatWarningsAsError { get; set; }

        [DataMember(Order = 7, EmitDefaultValue = false)]
        public bool? Force { get; set; }

        [DataMember(Order = 8, EmitDefaultValue = false)]
        public ExtendedPropertiesList ExtendedProperties { get; set; }

        [DataMember(Order = 9, EmitDefaultValue = false)]
        public ExtensionConfiguration ExtensionConfiguration { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Name = "WalkUpgradeDomain", Namespace = Constants.ServiceManagementNS)]
    public class WalkUpgradeDomainInput : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public int UpgradeDomain { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class UpgradeStatus : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string UpgradeType { get; set; }

        [DataMember(Order = 2)]
        public string CurrentUpgradeDomainState { get; set; }

        [DataMember(Order = 3)]
        public int CurrentUpgradeDomain { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Name = "RollbackUpdateOrUpgrade", Namespace = Constants.ServiceManagementNS)]
    public class RollbackUpdateOrUpgradeInput : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string Mode { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public bool? Force { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }


    #region Extension related classes
    /// <summary>
    /// Extension used in deployment APIs
    /// </summary>
    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class Extension : IExtensibleDataObject
    {
        public Extension(string id, int seqNo, string state)
        {
            Id = id;
            SequenceNumber = seqNo;
            State = state;
        }

        [DataMember(Order = 1)]
        public string Id { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public int SequenceNumber { get; set; }

        [DataMember(Order = 3)]
        public string State { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    /// <summary>
    /// Extension List used in deployment APIs
    /// </summary>
    [CollectionDataContract(Name = "Extensions", ItemName = "Extension", Namespace = Constants.ServiceManagementNS)]
    public class ExtensionList : List<Extension>
    {
        public ExtensionList()
        {
        }
        public ExtensionList(IEnumerable<Extension> list)
            : base(list)
        {
        }
    }

    /// <summary>
    /// Extension Setting used in deployment APIs
    /// </summary>
    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class RoleExtensions : IExtensibleDataObject
    {
        /// <summary>
        /// Name of the role
        /// </summary>
        [DataMember(Order = 1)]
        public string RoleName;

        /// <summary>
        /// List of extension Ids
        /// </summary>
        [DataMember(Order = 2)]
        public ExtensionList Extensions;

        public ExtensionDataObject ExtensionData { get; set; }
    }

    /// <summary>
    /// A default Extension List used in deployment APIs
    /// </summary>
    [CollectionDataContract(Name = "AllRoles", ItemName = "Extension", Namespace = Constants.ServiceManagementNS)]
    public class AllRoles : List<Extension>
    {
        public AllRoles()
        {
        }
        public AllRoles(IEnumerable<Extension> list)
            : base(list)
        {
        }
    }

    /// <summary>
    /// Extension Setting List used in deployment APIs to override extensions specified in AllRoles
    /// </summary>
    [CollectionDataContract(Name = "NamedRoles", ItemName = "Role", Namespace = Constants.ServiceManagementNS)]
    public class NamedRoles : List<RoleExtensions>
    {
        public NamedRoles()
        {
        }
        public NamedRoles(IEnumerable<RoleExtensions> list)
            : base(list)
        {
        }
    }

    /// <summary>
    /// Extension Setting List used in deployment APIs
    /// </summary>
    [DataContract(Name = "ExtensionConfiguration", Namespace = Constants.ServiceManagementNS)]
    public class ExtensionConfiguration : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public AllRoles AllRoles;

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public NamedRoles NamedRoles;

        public ExtensionDataObject ExtensionData { get; set; }
    }
    #endregion


    [CollectionDataContract(Name = "Certificates", ItemName = "Certificate", Namespace = Constants.ServiceManagementNS)]
    public class CertificateList : List<Certificate>
    {
        public CertificateList()
        {
        }

        public CertificateList(IEnumerable<Certificate> certificateList)
            : base(certificateList)
        {
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class Certificate : IExtensibleDataObject
    {
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public Uri CertificateUrl;

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string Thumbprint;

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string ThumbprintAlgorithm;

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public string Data;

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class Disk : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string AffinityGroup
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public RoleReference AttachedTo
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string OS
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public bool IsCorrupted
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string Label
        {
            get;
            set;
        }


        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string Location
        {
            get;
            set;
        }


        [DataMember(EmitDefaultValue = false, Order = 6)]
        public int LogicalDiskSizeInGB
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public Uri MediaLink
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string Name
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public string SourceImageName
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 10, Name = "CreatedTime")]
        private string _isoCreatedTimeString { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 11)]
        public Uri RemoteSourceImageLink
        {
            get;
            set;
        }

        public DateTime CreatedTime
        {
            get
            {
                return (string.IsNullOrEmpty(this._isoCreatedTimeString) ? DateTime.MinValue : DateTime.Parse(this._isoCreatedTimeString));
            }
            set
            {
                if (value.Equals(DateTime.MinValue))
                {
                    this._isoCreatedTimeString = null;
                }
                else
                {
                    this._isoCreatedTimeString = value.ToString(Constants.StandardTimeFormat);
                }
            }
        }

        #region IExtensibleDataObject Members
        public ExtensionDataObject ExtensionData { get; set; }
        #endregion
    }

    [CollectionDataContract(Name = "Disks", ItemName = "Disk", Namespace = Constants.ServiceManagementNS)]
    public class DiskList : Collection<Disk>
    {

    }


    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class ReplicationInput : IExtensibleDataObject
    {
        [DataMember(Order = 0, EmitDefaultValue = false)]
        public RegionList TargetLocations { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Name = "Regions", ItemName = "Region", Namespace = Constants.ServiceManagementNS)]
    public class RegionList : List<String>
    {
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class OSImage : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string AffinityGroup
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Category
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Label
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string Location
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public int LogicalSizeInGB
        {
            get;
            set;
        }


        [DataMember(EmitDefaultValue = false, Order = 5)]
        public Uri MediaLink
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string Name
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public string OS
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string Eula
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public string Description
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 10)]
        public string ImageFamily
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 11)]
        public bool? ShowInGui
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 12)]
        public DateTime? PublishedDate
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 13)]
        public bool? IsPremium
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 14)]
        public Uri IconUri
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 15)]
        public Uri PrivacyUri
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 16)]
        public string RecommendedVMSize
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 17)]
        public string PublisherName
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 18)]
        public Uri SmallIconUri
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 19)]
        public string Language
        {
            get;
            set;
        }

        #region IExtensibleDataObject Members
        public ExtensionDataObject ExtensionData { get; set; }
        #endregion
    }

    [CollectionDataContract(Name = "Images", ItemName = "OSImage", Namespace = Constants.ServiceManagementNS)]
    public class OSImageList : Collection<OSImage>
    {

    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class RoleReference : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string DeploymentName
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string HostedServiceName
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string RoleName
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            RoleReference other = obj as RoleReference;

            if (other != null)
            {
                return string.Equals(other.HostedServiceName, this.HostedServiceName, StringComparison.OrdinalIgnoreCase) && string.Equals(other.DeploymentName, this.DeploymentName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(other.RoleName, this.RoleName, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public override int GetHashCode()
        {
            string hashString = string.Format("{0}-{1}-{2}", this.HostedServiceName, this.DeploymentName, this.RoleName);
            return StringComparer.OrdinalIgnoreCase.GetHashCode(hashString);
        }

        #region IExtensibleDataObject Members
        public ExtensionDataObject ExtensionData { get; set; }
        #endregion
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public enum OSType
    {
        [EnumMember]
        Linux = 0,
        [EnumMember]
        Windows = 1
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class OSImageDetails : OSImage
    {
        [DataMember(EmitDefaultValue = false, Order = 90)]
        public bool IsCorrupted { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 100)]
        public ReplicationProgressList ReplicationProgress { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class ReplicationProgressElement : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Location { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Progress { get; set; }

        #region IExtensibleDataObject Members
        public ExtensionDataObject ExtensionData { get; set; }
        #endregion

    }

    [CollectionDataContract(Name = "ReplicationProgressList", ItemName = "ReplicationProgressElement", Namespace = Constants.ServiceManagementNS)]
    public class ReplicationProgressList : Collection<ReplicationProgressElement>
    {

    }



    [CollectionDataContract(Name = "ExtensionImages", ItemName = "ExtensionImage", Namespace = Constants.ServiceManagementNS)]
    public class ExtensionImageList : List<ExtensionImage>
    {
        public ExtensionImageList()
        {
        }

        public ExtensionImageList(IEnumerable<ExtensionImage> extensions)
            : base(extensions)
        {
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS, Name = "ExtensionImage")]
    public class ExtensionImage : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string ProviderNameSpace { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Type { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string Version { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string Label { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string Description { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string HostingResources { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public string ThumbprintAlgorithm { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8, Name = "PublicConfigurationSchema")]
        private string _base64EncodedPublicConfigurationSchema { get; set; }

        public string PublicConfigurationSchema
        {
            get
            {
                string decodedConfiguration;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedPublicConfigurationSchema, out decodedConfiguration))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedConfiguration;
            }
            set
            {
                this._base64EncodedPublicConfigurationSchema = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(EmitDefaultValue = false, Order = 9, Name = "PrivateConfigurationSchema")]
        private string _base64EncodedPrivateConfigurationSchema { get; set; }

        public string PrivateConfigurationSchema
        {
            get
            {
                string decodedConfiguration;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedPrivateConfigurationSchema, out decodedConfiguration))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedConfiguration;
            }
            set
            {
                this._base64EncodedPrivateConfigurationSchema = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(EmitDefaultValue = false, Order = 10)]
        public bool? BlockRoleUponFailure { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 11)]
        public string SampleConfig { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 12)]
        public bool? ReplicationCompleted { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 13)]
        public Uri Eula { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 14)]
        public Uri PrivacyUri { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 15)]
        public Uri HomepageUri { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 16)]
        public bool IsJsonExtension { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 17)]
        public bool IsInternalExtension { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 18)]
        public string SupportedOS { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 19)]
        public string CompanyName { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 20)]
        public DateTime? PublishedDate { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    /// <summary>
    /// This encapsulates the input for RegisterExtension and UpdateExtension Operation.
    /// </summary>
    [DataContract(Namespace = Constants.ServiceManagementNS, Name = "ExtensionImage")]
    public class ExtensionImageInput : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string ProviderNameSpace { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Type { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Version { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string Label { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string HostingResources { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public Uri MediaLink { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public ExtensionCertificate Certificate { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public ExtensionEndpoints Endpoints { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8, Name = "PublicConfigurationSchema")]
        private string _base64EncodedPublicConfigurationSchema { get; set; }

        public string PublicConfigurationSchema
        {
            get
            {
                string decodedConfiguration;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedPublicConfigurationSchema, out decodedConfiguration))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedConfiguration;
            }
            set
            {
                this._base64EncodedPublicConfigurationSchema = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(EmitDefaultValue = false, Order = 9, Name = "PrivateConfigurationSchema")]
        private string _base64EncodedPrivateConfigurationSchema { get; set; }

        public string PrivateConfigurationSchema
        {
            get
            {
                string decodedConfiguration;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedPrivateConfigurationSchema, out decodedConfiguration))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedConfiguration;
            }
            set
            {
                this._base64EncodedPrivateConfigurationSchema = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(EmitDefaultValue = false, Order = 10)]
        public string Description { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 11)]
        public string PublisherName { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 12)]
        public DateTime? PublishedDate { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 13)]
        public ExtensionImageLocalResourceList LocalResources { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 14)]
        public bool? BlockRoleUponFailure { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 15)]
        public bool IsInternalExtension { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 16)]
        public string SampleConfig { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 17)]
        public Uri Eula { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 18)]
        public Uri PrivacyUri { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 19)]
        public Uri HomepageUri { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 20)]
        public bool IsJsonExtension { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 21)]
        public bool DisallowMajorVersionUpgrade { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 22)]
        public string SupportedOS { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 23)]
        public string CompanyName { get; set; }

        #region IExtensibleDataObject Members
        public ExtensionDataObject ExtensionData { get; set; }
        #endregion
    }

    /// <summary>
    /// This represents the certificate used in ExtensionImage.
    /// </summary>
    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class ExtensionCertificate
    {
        public ExtensionCertificate(string storeLocation, string storeName, bool thumbprintRequired, string thumbprintAlgorithm)
        {
            this.StoreLocation = storeLocation;
            this.StoreName = storeName;
            this.ThumbprintRequired = thumbprintRequired;
            this.ThumbprintAlgorithm = thumbprintAlgorithm;
        }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string StoreLocation { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string StoreName { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public bool ThumbprintRequired { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string ThumbprintAlgorithm { get; set; }
    }

    /// <summary>
    /// This represents the endpoint used in ExtensionImage.
    /// </summary>
    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class ExtensionEndpoints
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public ExtensionInputEndpointList InputEndpoints { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public ExtensionInternalEndpointList InternalEndpoints { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public ExtensionInstanceInputEndpointList InstanceInputEndpoints { get; set; }
    }

    /// <summary>
    /// This represents a list of input endpoints used in ExtensionEndpoint.
    /// </summary>
    [CollectionDataContract(Name = "InputEndpoints", ItemName = "InputEndpoint", Namespace = Constants.ServiceManagementNS)]
    public class ExtensionInputEndpointList : List<ExtensionInputEndpoint>
    {
        public ExtensionInputEndpointList()
        {
        }

        public ExtensionInputEndpointList(IEnumerable<ExtensionInputEndpoint> inputEndpoints)
            : base(inputEndpoints)
        {
        }
    }

    /// <summary>
    /// This represents the input endpoint used in add extension image.
    /// </summary>
    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class ExtensionInputEndpoint
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Protocol { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string Port { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string LocalPort { get; set; }
    }

    /// <summary>
    /// This represents a list of internal endpoints used in ExtensionEndpoint.
    /// </summary>
    [CollectionDataContract(Name = "InternalEndpoints", ItemName = "InternalEndpoint", Namespace = Constants.ServiceManagementNS)]
    public class ExtensionInternalEndpointList : List<ExtensionInternalEndpoint>
    {
        public ExtensionInternalEndpointList()
        {
        }

        public ExtensionInternalEndpointList(IEnumerable<ExtensionInternalEndpoint> internalEndpoints)
            : base(internalEndpoints)
        {
        }
    }

    /// <summary>
    /// This represents the internal endpoint used in add extension image.
    /// </summary>
    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class ExtensionInternalEndpoint
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Protocol { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string Port { get; set; }
    }

    /// <summary>
    /// This represents a list of instance input endpoints used in ExtensionEndpoint.
    /// </summary>
    [CollectionDataContract(Name = "InstanceInputEndpoints", ItemName = "InstanceInputEndpoint", Namespace = Constants.ServiceManagementNS)]
    public class ExtensionInstanceInputEndpointList : List<ExtensionInstanceInputEndpoint>
    {
        public ExtensionInstanceInputEndpointList()
        {
        }

        public ExtensionInstanceInputEndpointList(IEnumerable<ExtensionInstanceInputEndpoint> instanceInputEndpoints)
            : base(instanceInputEndpoints)
        {
        }
    }

    /// <summary>
    /// This represents the instance input endpoint used in add extension image.
    /// </summary>
    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class ExtensionInstanceInputEndpoint
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Protocol { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string LocalPort { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string FixedPortMin { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string FixedPortMax { get; set; }
    }

    /// <summary>
    /// This represents a list of local resources used in extension image.
    /// </summary>
    [CollectionDataContract(Name = "LocalResources", ItemName = "LocalResource", Namespace = Constants.ServiceManagementNS)]
    public class ExtensionImageLocalResourceList : List<ExtensionImageLocalResource>
    {
        public ExtensionImageLocalResourceList()
        {
        }

        public ExtensionImageLocalResourceList(IEnumerable<ExtensionImageLocalResource> resources)
            : base(resources)
        {
        }
    }

    /// <summary>
    /// This represents the local resource used in extension image.
    /// </summary>
    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class ExtensionImageLocalResource
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public int? SizeInMB { get; set; }
    }

    [CollectionDataContract(Name = "ResourceExtensions", ItemName = "ResourceExtension", Namespace = Constants.ServiceManagementNS)]
    public class ResourceExtensionList : List<ResourceExtension>
    {
        public ResourceExtensionList()
        {
        }

        public ResourceExtensionList(IEnumerable<ResourceExtension> extensions)
            : base(extensions)
        {
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class ResourceExtension : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Publisher { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string Version { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string Label { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string Description { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6, Name = "PublicConfigurationSchema")]
        private string base64EncodedPublicConfigurationSchema { get; set; }

        public string PublicConfigurationSchema
        {
            get
            {
                string decodedConfiguration;
                if (!StringEncoder.TryDecodeFromBase64String(this.base64EncodedPublicConfigurationSchema, out decodedConfiguration))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedConfiguration;
            }
            set
            {
                this.base64EncodedPublicConfigurationSchema = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(EmitDefaultValue = false, Order = 7, Name = "PrivateConfigurationSchema")]
        private string base64EncodedPrivateConfigurationSchema { get; set; }

        public string PrivateConfigurationSchema
        {
            get
            {
                string decodedConfiguration;
                if (!StringEncoder.TryDecodeFromBase64String(this.base64EncodedPrivateConfigurationSchema, out decodedConfiguration))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedConfiguration;
            }
            set
            {
                this.base64EncodedPrivateConfigurationSchema = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(EmitDefaultValue = false, Order = 8, Name = "SampleConfig")]
        private string base64EncodedSampleConfig { get; set; }

        public string SampleConfig
        {
            get
            {
                string decodedSampleConfig;
                if (!StringEncoder.TryDecodeFromBase64String(this.base64EncodedSampleConfig, out decodedSampleConfig))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedSampleConfig;
            }
            set
            {
                this.base64EncodedSampleConfig = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public bool? ReplicationCompleted { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 10)]
        public Uri Eula { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 11)]
        public Uri PrivacyUri { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 12)]
        public Uri HomepageUri { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 13)]
        public bool IsJsonExtension { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 14)]
        public bool IsInternalExtension { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 15)]
        public bool DisallowMajorVersionUpgrade { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 16)]
        public string SupportedOS { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 17)]
        public string CompanyName { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 18)]
        public DateTime? PublishedDate { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    /// <summary>
    ///  This represents the a extension object used in ListHostedServiceExtension operation.
    /// </summary>
    [DataContract(Namespace = Constants.ServiceManagementNS, Name = "Extension")]
    public class HostedServiceExtension : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string ProviderNameSpace { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Type { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string Id { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string Version { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string Thumbprint { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string ThumbprintAlgorithm { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7, Name = "PublicConfiguration")]
        private string _base64EncodedPublicConfiguration { get; set; }

        public string PublicConfiguration
        {
            get
            {
                string decodedConfiguration;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedPublicConfiguration, out decodedConfiguration))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedConfiguration;
            }
            set
            {
                this._base64EncodedPublicConfiguration = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public bool IsJsonExtension { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 10)]
        public bool DisallowMajorVersionUpgrade { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    /// <summary>
    /// This represents the input of AddHostedServiceExtension operation.
    /// </summary>
    [DataContract(Namespace = Constants.ServiceManagementNS, Name = "Extension")]
    public class HostedServiceExtensionInput : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string ProviderNameSpace { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Type { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string Id { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string Thumbprint { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string ThumbprintAlgorithm { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6, Name = "PublicConfiguration")]
        private string _base64EncodedPublicConfiguration { get; set; }

        public string PublicConfiguration
        {
            get
            {
                string decodedConfiguration;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedPublicConfiguration, out decodedConfiguration))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedConfiguration;
            }
            set
            {
                this._base64EncodedPublicConfiguration = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(EmitDefaultValue = false, Order = 7, Name = "PrivateConfiguration")]
        private string _base64EncodedPrivateConfiguration { get; set; }

        public string PrivateConfiguration
        {
            get
            {
                string decodedConfiguration;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedPrivateConfiguration, out decodedConfiguration))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedConfiguration;
            }
            set
            {
                this._base64EncodedPrivateConfiguration = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string Version { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Namespace = Constants.ServiceManagementNS, Name = "Extensions", ItemName = "Extension")]
    public class HostedServiceExtensionList : List<HostedServiceExtension>
    {
        public HostedServiceExtensionList() { }

        public HostedServiceExtensionList(IEnumerable<HostedServiceExtension> extensions)
            : base(extensions)
        {
        }
    }


    [CollectionDataContract(Name = "OperatingSystemFamilies", ItemName = "OperatingSystemFamily", Namespace = Constants.ServiceManagementNS)]
    public class OperatingSystemFamilyList : List<OperatingSystemFamily>
    {
        public OperatingSystemFamilyList()
        {
        }

        public OperatingSystemFamilyList(IEnumerable<OperatingSystemFamily> operatingSystemFamilies)
            : base(operatingSystemFamilies)
        {
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class OperatingSystemFamily : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false, Name = "Label")]
        private string _base64EncodedLabel { get; set; }

        public string Label
        {
            get
            {
                string decodedLabel;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedLabel, out decodedLabel))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedLabel;
            }
            set
            {
                this._base64EncodedLabel = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(Order = 3)]
        public OperatingSystemList OperatingSystems { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Name = "OperatingSystems", ItemName = "OperatingSystem", Namespace = Constants.ServiceManagementNS)]
    public class OperatingSystemList : List<OperatingSystem>
    {
        public OperatingSystemList()
        {
        }

        public OperatingSystemList(IEnumerable<OperatingSystem> operatingSystems)
            : base(operatingSystems)
        {
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class OperatingSystem : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string Version { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false, Name = "Label")]
        private string _base64EncodedLabel { get; set; }

        public string Label
        {
            get
            {
                string decodedLabel;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedLabel, out decodedLabel))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedLabel;
            }
            set
            {
                this._base64EncodedLabel = StringEncoder.EncodeToBase64String(value);
            }
        }

        [DataMember(Order = 3)]
        public bool IsDefault { get; set; }

        [DataMember(Order = 4)]
        public bool IsActive { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public string Family { get; set; }

        [DataMember(Order = 6, EmitDefaultValue = false, Name = "FamilyLabel")]
        private string _base64EncodedFamilyLabel { get; set; }

        public string FamilyLabel
        {
            get
            {
                string decodedFamilyLabel;
                if (!StringEncoder.TryDecodeFromBase64String(this._base64EncodedFamilyLabel, out decodedFamilyLabel))
                {
                    throw new InvalidOperationException(Resources.UnableToDecodeBase64String);
                }
                return decodedFamilyLabel;
            }
            set
            {
                this._base64EncodedFamilyLabel = StringEncoder.EncodeToBase64String(value);
            }
        }

        public ExtensionDataObject ExtensionData { get; set; }
    }


    [CollectionDataContract(Name = "SubscriptionCertificates", ItemName = "SubscriptionCertificate", Namespace = Constants.ServiceManagementNS)]
    public class SubscriptionCertificateList : List<SubscriptionCertificate>
    {
        public SubscriptionCertificateList()
        {
        }

        public SubscriptionCertificateList(IEnumerable<SubscriptionCertificate> Certificates)
            : base(Certificates)
        {
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class SubscriptionCertificate : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string SubscriptionCertificatePublicKey { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string SubscriptionCertificateThumbprint { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string SubscriptionCertificateData { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public DateTime Created { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }


    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class SubscriptionOperationCollection : IExtensibleDataObject
    {
        [DataMember(Order = 0)]
        public SubscriptionOperationList SubscriptionOperations { get; set; }

        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string ContinuationToken { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Namespace = Constants.ServiceManagementNS, Name = "SubscriptionOperations", ItemName = "SubscriptionOperation")]
    public class SubscriptionOperationList : List<SubscriptionOperation>, IExtensibleDataObject
    {
        public ExtensionDataObject ExtensionData { get; set; }

        public SubscriptionOperationList()
        {
        }

        public SubscriptionOperationList(IEnumerable<SubscriptionOperation> subscriptions)
            : base(subscriptions)
        {
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class SubscriptionOperationCaller : IExtensibleDataObject
    {
        [DataMember(Order = 0)]
        public bool UsedServiceManagementApi { get; set; }

        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string UserEmailAddress { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string SubscriptionCertificateThumbprint { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string ClientIP { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Namespace = Constants.ServiceManagementNS, Name = "OperationParameters", ItemName = "OperationParameter")]
    public class OperationParameterList : List<OperationParameter>, IExtensibleDataObject
    {
        public ExtensionDataObject ExtensionData { get; set; }

        public OperationParameterList()
        {
        }

        public OperationParameterList(IEnumerable<OperationParameter> operations)
            : base(operations)
        {
        }
    }

    [DataContract]
    public class OperationParameter : IExtensibleDataObject
    {
        [DataMember(Order = 0)]
        public string Name { get; set; }

        [DataMember(Order = 1)]
        private string Value { get; set; }

        private static readonly ReadOnlyCollection<Type> KnownTypes = new ReadOnlyCollection<Type>(new[] {
                                             typeof(CreateAffinityGroupInput),
                                             typeof(UpdateAffinityGroupInput),
                                             typeof(CertificateFile),
                                             typeof(ChangeConfigurationInput),
                                             typeof(CreateDeploymentInput),
                                             typeof(CreateHostedServiceInput),
                                             typeof(CreateStorageServiceInput),
                                             typeof(RegenerateKeys),
                                             typeof(StorageDomain),
                                             typeof(SubscriptionCertificate),
                                             typeof(SwapDeploymentInput),
                                             typeof(UpdateDeploymentStatusInput),
                                             typeof(UpdateHostedServiceInput),
                                             typeof(UpdateStorageServiceInput),
                                             typeof(UpgradeDeploymentInput),
                                             typeof(WalkUpgradeDomainInput),
                                             typeof(CaptureRoleOperation),
                                             typeof(ShutdownRoleOperation),
                                             typeof(StartRoleOperation),
                                             //typeof(CaptureRoleAsVMImageOperation),
                                             typeof(RestartRoleOperation),
                                             typeof(OSImage),
                                             typeof(PersistentVMRole),
                                             typeof(Deployment),
                                             typeof(DataVirtualHardDisk),
                                             typeof(OSImage),
                                             typeof(Disk),
                                             typeof(ExtendedProperty),
                                             typeof(ExtensionConfiguration),
                                             typeof(HostedServiceExtensionInput),
                                             typeof(ReservedIP),
                                           });

        public string GetSerializedValue()
        {
            return this.Value;
        }

        public object GetValue()
        {
            DataContractSerializer serializer;

            if (string.IsNullOrEmpty(this.Value))
            {
                return null;
            }

            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings
            {
                IgnoreComments = true,
                IgnoreProcessingInstructions = true,
                IgnoreWhitespace = false,
                XmlResolver = null,
                DtdProcessing = DtdProcessing.Prohibit,
                MaxCharactersInDocument = 0, // No size limit
                MaxCharactersFromEntities = 0 // No size limit
            };

            serializer = new DataContractSerializer(typeof(Object), OperationParameter.KnownTypes);
            try
            {
                using (StringReader reader = new StringReader(this.Value))
                {
                    return serializer.ReadObject(XmlReader.Create(reader, xmlReaderSettings));
                }
            }
            catch
            {
                return this.Value;
            }
        }

        public void SetValue(object value)
        {
            if (value != null)
            {
                Type valueType = value.GetType();

                if (valueType.Equals(typeof(string)))
                {
                    this.Value = (string)value;
                    return;
                }

                DataContractSerializer serializer = new DataContractSerializer(typeof(Object), OperationParameter.KnownTypes);
                StringBuilder target = new StringBuilder();
                using (XmlWriter writer = XmlWriter.Create(target))
                {
                    serializer.WriteObject(writer, value);
                    writer.Flush();
                    this.Value = target.ToString();
                }
            }
        }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class SubscriptionOperation : IExtensibleDataObject
    {
        [DataMember(Order = 0)]
        public string OperationId { get; set; }

        [DataMember(Order = 1)]
        public string OperationObjectId { get; set; }

        [DataMember(Order = 2)]
        public string OperationName { get; set; }

        [DataMember(Order = 3)]
        public OperationParameterList OperationParameters { get; set; }

        [DataMember(Order = 4)]
        public SubscriptionOperationCaller OperationCaller { get; set; }

        [DataMember(Order = 5)]
        public Operation OperationStatus { get; set; }

        [DataMember(Order = 7, EmitDefaultValue = false)]
        public string OperationStartedTime { get; set; }

        [DataMember(Order = 8, EmitDefaultValue = false)]
        public string OperationCompletedTime { get; set; }

        [DataMember(Order = 9, EmitDefaultValue = false)]
        public string OperationKind { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class Subscription : IExtensibleDataObject
    {
        [DataMember(Order = 0)]
        public string SubscriptionID { get; set; }

        [DataMember(Order = 1)]
        public string SubscriptionName { get; set; }

        [DataMember(Order = 2)]
        public string SubscriptionStatus { get; set; }

        [DataMember(Order = 3)]
        public string AccountAdminLiveEmailId { get; set; }

        [DataMember(Order = 4)]
        public string ServiceAdminLiveEmailId { get; set; }

        [DataMember(Order = 5)]
        public int MaxCoreCount { get; set; }

        [DataMember(Order = 6)]
        public int MaxStorageAccounts { get; set; }

        [DataMember(Order = 7)]
        public int MaxHostedServices { get; set; }

        [DataMember(Order = 8)]
        public int CurrentCoreCount { get; set; }

        [DataMember(Order = 9)]
        public int CurrentHostedServices { get; set; }

        [DataMember(Order = 10)]
        public int CurrentStorageAccounts { get; set; }

        [DataMember(Order = 11, EmitDefaultValue = false)]
        public int MaxVirtualNetworkSites { get; set; }

        [DataMember(Order = 12, EmitDefaultValue = false)]
        public int CurrentVirtualNetworkSites { get; set; }

        [DataMember(Order = 13, EmitDefaultValue = false)]
        public int MaxLocalNetworkSites { get; set; }

        [DataMember(Order = 14, EmitDefaultValue = false)]
        public int CurrentLocalNetworkSites { get; set; }

        [DataMember(Order = 15, EmitDefaultValue = false)]
        public int MaxDnsServers { get; set; }

        [DataMember(Order = 16, EmitDefaultValue = false)]
        public int CurrentDnsServers { get; set; }

        [DataMember(Order = 17, EmitDefaultValue = false)]
        public string OfferCategories { get; set; }

        /// <summary>
        /// Current count of extra multiple vips
        /// </summary>
        [DataMember(Order = 18, EmitDefaultValue = false)]
        public int CurrentExtraVIPCount { get; set; }

        /// <summary>
        /// Max count of extra multiple vips
        /// </summary>
        [DataMember(Order = 19, EmitDefaultValue = false)]
        public int MaxExtraVIPCount { get; set; }

        /// <summary>
        /// Windows Azure Active Directory tenant ID (GUID)
        /// </summary>
        [DataMember(Order = 20, EmitDefaultValue = false)]
        public string AADTenantID { get; set; }

        [DataMember(Order = 21, EmitDefaultValue = false)]
        public string CreatedTime { get; set; }

        [DataMember(Order = 22, EmitDefaultValue = false)]
        public int MaxReservedIPs { get; set; }

        [DataMember(Order = 23, EmitDefaultValue = false)]
        public int? CurrentReservedIPs { get; set; }

        /// <summary>
        /// Current count of extra multiple vips
        /// </summary>
        [DataMember(Order = 24, EmitDefaultValue = false)]
        public int CurrentPublicIPCount { get; set; }

        /// <summary>
        /// Max count of extra multiple vips
        /// </summary>
        [DataMember(Order = 25, EmitDefaultValue = false)]
        public int MaxPublicIPCount { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [CollectionDataContract(Namespace = "http://schemas.microsoft.com/windowsazure", Name = "Subscriptions", ItemName = "Subscription")]
    public class SubscriptionList : List<Subscription>, IExtensibleDataObject
    {
        public ExtensionDataObject ExtensionData { get; set; }

        public SubscriptionList()
        {
        }

        public SubscriptionList(IEnumerable<Subscription> subscriptions)
            : base(subscriptions)
        {
        }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class SubscriptionService : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string SubscriptionID { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string ServiceType { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string ServiceName { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string ServiceUri { get; set; }
        public ExtensionDataObject ExtensionData { get; set; }

    }

    [CollectionDataContract(Namespace = "http://schemas.microsoft.com/windowsazure", Name = "SubscriptionServices", ItemName = "SubscriptionService")]
    public class SubscriptionServicesList : List<SubscriptionService>, IExtensibleDataObject
    {
        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = Constants.ServiceManagementNS)]
    public class Operation : IExtensibleDataObject
    {
        [DataMember(Name = "ID", Order = 1)]
        public string OperationTrackingId { get; set; }

        [DataMember(Order = 2)]
        public string Status { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public int HttpStatusCode { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public ServiceManagementError Error { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
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

    /// <summary>
    /// Represents exceptions on the wire when calling the Service Management API.
    /// </summary>
    [Serializable]
    public class ServiceManagementClientException : Exception
    {
        /// <summary>
        /// Gets the HTTP status code of the failed Service Management request.
        /// </summary>
        public HttpStatusCode HttpStatus { get; private set; }

        /// <summary>
        /// Gets the error details of the failed Service Management request.
        /// </summary>
        public ServiceManagementError ErrorDetails { get; private set; }

        /// <summary>
        /// Gets the operation tracking ID if called asynchronously of the failed Service Management request.
        /// </summary>
        public string OperationTrackingId { get; private set; }

        /// <summary>
        /// Gets the headers associated with the response from the request that caused the exception.
        /// </summary>
        public WebHeaderCollection ResponseHeaders { get; private set; }

        /// <summary>
        /// Constructs a new instance of ServiceManagementClientException.
        /// </summary>
        /// <param name="httpStatus">The HTTP status code of the failed Service Management request.</param>
        /// <param name="errorDetails">The error details of the failed Service Management request.</param>
        /// <param name="operationTrackingId">The operation tracking ID if called asynchronously of the failed Service Management request.</param>
        public ServiceManagementClientException(HttpStatusCode httpStatus, ServiceManagementError errorDetails, string operationTrackingId)
            : this(httpStatus, errorDetails, operationTrackingId, null)
        {
            // Empty
        }

        /// <summary>
        /// Constructs a new instance of ServiceManagementClientException.
        /// </summary>
        /// <param name="httpStatus">The HTTP status code of the failed Service Management request.</param>
        /// <param name="errorDetails">The error details of the failed Service Management request.</param>
        /// <param name="operationTrackingId">The operation tracking ID if called asynchronously of the failed Service Management request.</param>
        /// <param name="responseHeaders">Optional WebResponse containing the original response object from the server</param>
        public ServiceManagementClientException(HttpStatusCode httpStatus, ServiceManagementError errorDetails, string operationTrackingId, WebHeaderCollection responseHeaders)
            : base(string.Format(CultureInfo.CurrentCulture,
                Resources.ServiceManagementClientExceptionStringFormat,
                (int)httpStatus,
                (errorDetails != null) && !string.IsNullOrEmpty(errorDetails.Code) ? errorDetails.Code : Resources.None,
                (errorDetails != null) && !string.IsNullOrEmpty(errorDetails.Message) ? errorDetails.Message : Resources.None,
                string.IsNullOrEmpty(operationTrackingId) ? Resources.None : operationTrackingId))
        {
            this.HttpStatus = httpStatus;
            this.ErrorDetails = errorDetails;
            this.OperationTrackingId = operationTrackingId;
            this.ResponseHeaders = responseHeaders;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
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

    [ServiceContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public interface IServiceManagement
    {
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/affinitygroups")]
        IAsyncResult BeginCreateAffinityGroup(string subscriptionId, CreateAffinityGroupInput input, AsyncCallback callback, object state);

        void EndCreateAffinityGroup(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "DELETE", UriTemplate = "{subscriptionId}/affinitygroups/{affinityGroupName}")]
        IAsyncResult BeginDeleteAffinityGroup(string subscriptionId, string affinityGroupName, AsyncCallback callback, object state);

        void EndDeleteAffinityGroup(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "PUT", UriTemplate = "{subscriptionId}/affinitygroups/{affinityGroupName}")]
        IAsyncResult BeginUpdateAffinityGroup(string subscriptionId, string affinityGroupName, UpdateAffinityGroupInput input, AsyncCallback callback, object state);

        void EndUpdateAffinityGroup(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = "{subscriptionId}/affinitygroups")]
        IAsyncResult BeginListAffinityGroups(string subscriptionId, AsyncCallback callback, object state);

        AffinityGroupList EndListAffinityGroups(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = "{subscriptionId}/affinitygroups/{affinityGroupName}")]
        IAsyncResult BeginGetAffinityGroup(string subscriptionId, string affinityGroupName, AsyncCallback callback, object state);

        AffinityGroup EndGetAffinityGroup(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/certificates")]
        IAsyncResult BeginListCertificates(string subscriptionId, string serviceName, AsyncCallback callback, object state);

        CertificateList EndListCertificates(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/certificates/{thumbprintalgorithm}-{thumbprint_in_hex}")]
        IAsyncResult BeginGetCertificate(string subscriptionId, string serviceName, string thumbprintalgorithm, string thumbprint_in_hex, AsyncCallback callback, object state);

        Certificate EndGetCertificate(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/certificates")]
        IAsyncResult BeginAddCertificates(string subscriptionId, string serviceName, CertificateFile input, AsyncCallback callback, object state);

        void EndAddCertificates(IAsyncResult asyncResult);

        [WebInvoke(Method = "DELETE", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/certificates/{thumbprintalgorithm}-{thumbprint_in_hex}")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginDeleteCertificate(string subscriptionId, string serviceName, string thumbprintalgorithm, string thumbprint_in_hex, AsyncCallback callback, object state);

        void EndDeleteCertificate(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginSwapDeployment(string subscriptionId, string serviceName, SwapDeploymentInput input, AsyncCallback callback, object state);

        void EndSwapDeployment(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deploymentslots/{deploymentSlot}")]
        IAsyncResult BeginCreateOrUpdateDeployment(string subscriptionId, string serviceName, string deploymentSlot, CreateDeploymentInput input, AsyncCallback callback, object state);

        void EndCreateOrUpdateDeployment(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deployments")]
        IAsyncResult BeginCreateDeployment(string subscriptionId, string serviceName, Deployment deployment, AsyncCallback callback, object state);

        void EndCreateDeployment(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "DELETE", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deployments/{deploymentName}")]
        IAsyncResult BeginDeleteDeployment(string subscriptionId, string serviceName, string deploymentName, AsyncCallback callback, object state);

        void EndDeleteDeployment(IAsyncResult asyncResult);

        [WebInvoke(Method = "DELETE", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deploymentslots/{deploymentSlot}")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginDeleteDeploymentBySlot(string subscriptionId, string serviceName, string deploymentSlot, AsyncCallback callback, object state);

        void EndDeleteDeploymentBySlot(IAsyncResult asyncResult);

        [WebGet(UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deployments/{deploymentName}")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginGetDeployment(string subscriptionId, string serviceName, string deploymentName, AsyncCallback callback, object state);

        Deployment EndGetDeployment(IAsyncResult asyncResult);

        [WebGet(UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deploymentslots/{deploymentSlot}")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginGetDeploymentBySlot(string subscriptionId, string serviceName, string deploymentSlot, AsyncCallback callback, object state);

        Deployment EndGetDeploymentBySlot(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deployments/{deploymentName}/?comp=config")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginChangeConfiguration(string subscriptionId, string serviceName, string deploymentName, ChangeConfigurationInput input, AsyncCallback callback, object state);

        void EndChangeConfiguration(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deploymentslots/{deploymentSlot}/?comp=config")]
        IAsyncResult BeginChangeConfigurationBySlot(string subscriptionId, string serviceName, string deploymentSlot, ChangeConfigurationInput input, AsyncCallback callback, object state);

        void EndChangeConfigurationBySlot(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deployments/{deploymentName}/?comp=resume")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginResumeDeploymentUpdateOrUpgrade(string subscriptionId, string serviceName, string deploymentName, AsyncCallback callback, object state);

        void EndResumeDeploymentUpdateOrUpgrade(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deploymentslots/{deploymentSlot}/?comp=resume")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginResumeDeploymentUpdateOrUpgradeBySlot(string subscriptionId, string serviceName, string deploymentSlot, AsyncCallback callback, object state);

        void EndResumeDeploymentUpdateOrUpgradeBySlot(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deployments/{deploymentName}/?comp=suspend")]
        IAsyncResult BeginSuspendDeploymentUpdateOrUpgrade(string subscriptionId, string serviceName, string deploymentName, AsyncCallback callback, object state);

        void EndSuspendDeploymentUpdateOrUpgrade(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deploymentslots/{deploymentSlot}/?comp=suspend")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginSuspendDeploymentUpdateOrUpgradeBySlot(string subscriptionId, string serviceName, string deploymentSlot, AsyncCallback callback, object state);

        void EndSuspendDeploymentUpdateOrUpgradeBySlot(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deployments/{deploymentName}/?comp=status")]
        IAsyncResult BeginUpdateDeploymentStatus(string subscriptionId, string serviceName, string deploymentName, UpdateDeploymentStatusInput input, AsyncCallback callback, object state);

        void EndUpdateDeploymentStatus(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deploymentslots/{deploymentSlot}/?comp=status")]
        IAsyncResult BeginUpdateDeploymentStatusBySlot(string subscriptionId, string serviceName, string deploymentSlot, UpdateDeploymentStatusInput input, AsyncCallback callback, object state);

        void EndUpdateDeploymentStatusBySlot(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deployments/{deploymentName}/?comp=upgrade")]
        IAsyncResult BeginUpgradeDeployment(string subscriptionId, string serviceName, string deploymentName, UpgradeDeploymentInput input, AsyncCallback callback, object state);

        void EndUpgradeDeployment(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deploymentslots/{deploymentSlot}/?comp=upgrade")]
        IAsyncResult BeginUpgradeDeploymentBySlot(string subscriptionId, string serviceName, string deploymentSlot, UpgradeDeploymentInput input, AsyncCallback callback, object state);

        void EndUpgradeDeploymentBySlot(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deployments/{deploymentName}/?comp=walkupgradedomain")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginWalkUpgradeDomain(string subscriptionId, string serviceName, string deploymentName, WalkUpgradeDomainInput input, AsyncCallback callback, object state);

        void EndWalkUpgradeDomain(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deploymentslots/{deploymentSlot}/?comp=walkupgradedomain")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginWalkUpgradeDomainBySlot(string subscriptionId, string serviceName, string deploymentSlot, WalkUpgradeDomainInput input, AsyncCallback callback, object state);

        void EndWalkUpgradeDomainBySlot(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deployments/{deploymentName}/roleinstances/{roleinstancename}?comp=reboot")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginRebootDeploymentRoleInstance(string subscriptionId, string serviceName, string deploymentName, string roleInstanceName, AsyncCallback callback, object state);

        void EndRebootDeploymentRoleInstance(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deployments/{deploymentName}/?comp=rollback")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginRollbackDeploymentUpdateOrUpgrade(string subscriptionId, string serviceName, string deploymentName, RollbackUpdateOrUpgradeInput input, AsyncCallback callback, object state);

        void EndRollbackDeploymentUpdateOrUpgrade(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deploymentslots/{deploymentSlot}/?comp=rollback")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginRollbackDeploymentUpdateOrUpgradeBySlot(string subscriptionId, string serviceName, string deploymentSlot, RollbackUpdateOrUpgradeInput input, AsyncCallback callback, object state);

        void EndRollbackDeploymentUpdateOrUpgradeBySlot(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deployments/{deploymentName}/roleinstances/{roleinstancename}?comp=reimage")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginReimageDeploymentRoleInstance(string subscriptionId, string serviceName, string deploymentName, string roleInstanceName, AsyncCallback callback, object state);

        void EndReimageDeploymentRoleInstance(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deployments/{deploymentName}/roleinstances/{roleinstancename}?comp=rebuild&resources={resources}")]
        IAsyncResult BeginRebuildDeploymentRoleInstance(string subscriptionId, string serviceName, string deploymentName, string roleInstanceName, string resources, AsyncCallback callback, object state);

        void EndRebuildDeploymentRoleInstance(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deploymentslots/{deploymentSlot}/roleinstances/{roleinstancename}?comp=reboot")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginRebootDeploymentRoleInstanceBySlot(string subscriptionId, string serviceName, string deploymentSlot, string roleInstanceName, AsyncCallback callback, object state);

        void EndRebootDeploymentRoleInstanceBySlot(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deploymentslots/{deploymentSlot}/roleinstances/{roleinstancename}?comp=reimage")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginReimageDeploymentRoleInstanceBySlot(string subscriptionId, string serviceName, string deploymentSlot, string roleInstanceName, AsyncCallback callback, object state);

        void EndReimageDeploymentRoleInstanceBySlot(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deploymentslots/{deploymentSlot}/roleinstances/{roleinstancename}?comp=rebuild&resources={resources}")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginRebuildDeploymentRoleInstanceBySlot(string subscriptionId, string serviceName, string deploymentSlot, string roleInstanceName, string resources, AsyncCallback callback, object state);

        void EndRebuildDeploymentRoleInstanceBySlot(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deployments/{deploymentName}/package?containerUri={containerUri}&overwriteExisting={overwriteExisting}")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginGetPackage(string subscriptionId, string serviceName, string deploymentName, string containerUri, bool overwriteExisting, AsyncCallback callback, object state);

        void EndGetPackage(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deploymentslots/{deploymentSlot}/package?containerUri={containerUri}&overwriteExisting={overwriteExisting}")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginGetPackageBySlot(string subscriptionId, string serviceName, string deploymentSlot, string containerUri, bool overwriteExisting, AsyncCallback callback, object state);

        void EndGetPackageBySlot(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deployments/{deploymentName}/virtualipgroups/{vipGroupName}?comp=deletevips")]
        IAsyncResult BeginDeleteDeploymentVirtualIPs(string subscriptionId, string serviceName, string deploymentName, string vipGroupName, VirtualIPList vips, AsyncCallback callback, object state);

        void EndDeleteDeploymentVirtualIPs(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/deploymentslots/{deploymentSlot}/ virtualipgroups/{vipGroupName}?comp=deletevips")]
        IAsyncResult BeginDeleteDeploymentVirtualIPsBySlot(string subscriptionId, string serviceName, string deploymentSlot, string vipGroupName, VirtualIPList vips, AsyncCallback callback, object state);

        void EndDeleteDeploymentVirtualIPsBySlot(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = "{subscriptionID}/services/disks")]
        IAsyncResult BeginListDisks(string subscriptionID, AsyncCallback callback, object state);

        DiskList EndListDisks(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionID}/services/disks")]
        IAsyncResult BeginCreateDisk(string subscriptionID, Disk disk, AsyncCallback callback, object state);

        Disk EndCreateDisk(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = "{subscriptionID}/services/disks/{diskName}")]
        IAsyncResult BeginGetDisk(string subscriptionID, string diskName, AsyncCallback callback, object state);

        Disk EndGetDisk(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "PUT", UriTemplate = "{subscriptionID}/services/disks/{diskName}")]
        IAsyncResult BeginUpdateDisk(string subscriptionID, string diskName, Disk disk, AsyncCallback callback, object state);

        Disk EndUpdateDisk(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "DELETE", UriTemplate = "{subscriptionID}/services/disks/{diskName}")]
        IAsyncResult BeginDeleteDisk(string subscriptionID, string diskName, AsyncCallback callback, object state);

        void EndDeleteDisk(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "DELETE", UriTemplate = "{subscriptionID}/services/disks/{diskName}?comp={comp}")]
        IAsyncResult BeginDeleteDiskEx(string subscriptionID, string diskName, string comp, AsyncCallback callback, object state);

        void EndDeleteDiskEx(IAsyncResult asyncResult);

        [ServiceKnownType(typeof(PersistentVMRole))]
        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionID}/services/hostedservices/{serviceName}/deployments/{deploymentName}/Roles")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginAddRole(string subscriptionID, string serviceName, string deploymentName, Role role, AsyncCallback callback, object state);

        void EndAddRole(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [ServiceKnownType(typeof(PersistentVMRole))]
        [WebGet(UriTemplate = "{subscriptionID}/services/hostedservices/{serviceName}/deployments/{deploymentName}/Roles/{roleName}")]
        IAsyncResult BeginGetRole(string subscriptionID, string serviceName, string deploymentName, string roleName, AsyncCallback callback, object state);

        Role EndGetRole(IAsyncResult asyncResult);

        [WebInvoke(Method = "PUT", UriTemplate = "{subscriptionID}/services/hostedservices/{serviceName}/deployments/{deploymentName}/Roles/{roleName}")]
        [ServiceKnownType(typeof(PersistentVMRole))]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginUpdateRole(string subscriptionID, string serviceName, string deploymentName, string roleName, Role role, AsyncCallback callback, object state);

        void EndUpdateRole(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "DELETE", UriTemplate = "{subscriptionID}/services/hostedservices/{serviceName}/deployments/{deploymentName}/Roles/{roleName}")]
        IAsyncResult BeginDeleteRole(string subscriptionID, string serviceName, string deploymentName, string roleName, AsyncCallback callback, object state);

        void EndDeleteRole(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionID}/services/hostedservices/{serviceName}/deployments/{deploymentName}/Roles/{roleName}/DataDisks")]
        IAsyncResult BeginAddDataDisk(string subscriptionID, string serviceName, string deploymentName, string roleName, DataVirtualHardDisk dataDisk, AsyncCallback callback, object state);

        void EndAddDataDisk(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "PUT", UriTemplate = "{subscriptionID}/services/hostedservices/{serviceName}/deployments/{deploymentName}/Roles/{roleName}/DataDisks/{lun}")]
        IAsyncResult BeginUpdateDataDisk(string subscriptionID, string serviceName, string deploymentName, string roleName, string lun, DataVirtualHardDisk dataDisk, AsyncCallback callback, object state);

        void EndUpdateDataDisk(IAsyncResult asyncResult);

        [WebGet(UriTemplate = "{subscriptionID}/services/hostedservices/{serviceName}/deployments/{deploymentName}/Roles/{roleName}/DataDisks/{lun}")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginGetDataDisk(string subscriptionID, string serviceName, string deploymentName, string roleName, string lun, AsyncCallback callback, object state);

        DataVirtualHardDisk EndGetDataDisk(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "DELETE", UriTemplate = "{subscriptionID}/services/hostedservices/{serviceName}/deployments/{deploymentName}/Roles/{roleName}/DataDisks/{lun}")]
        IAsyncResult BeginDeleteDataDisk(string subscriptionID, string serviceName, string deploymentName, string roleName, string lun, AsyncCallback callback, object state);

        void EndDeleteDataDisk(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionID}/services/hostedservices/{serviceName}/deployments/{deploymentName}/roleInstances/{roleInstanceName}/Operations")]
        [ServiceKnownType(typeof(StartRoleOperation))]
        [ServiceKnownType(typeof(RestartRoleOperation))]
        [ServiceKnownType(typeof(CaptureRoleOperation))]
        [OperationContract(AsyncPattern = true)]
        [ServiceKnownType(typeof(ShutdownRoleOperation))]
        IAsyncResult BeginExecuteRoleOperation(string subscriptionID, string serviceName, string deploymentName, string roleInstanceName, RoleOperation roleOperation, AsyncCallback callback, object state);

        void EndExecuteRoleOperation(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = "{subscriptionID}/services/hostedservices/{serviceName}/deployments/{deploymentName}/roleinstances/{instanceName}/ModelFile?FileType=RDP")]
        IAsyncResult BeginDownloadRDPFile(string subscriptionID, string serviceName, string deploymentName, string instanceName, AsyncCallback callback, object state);

        Stream EndDownloadRDPFile(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionID}/services/hostedservices/{serviceName}/deployments/{deploymentName}/Roles/Operations")]
        [OperationContract(AsyncPattern = true)]
        [ServiceKnownType(typeof(ShutdownRolesOperation))]
        [ServiceKnownType(typeof(StartRolesOperation))]
        IAsyncResult BeginExecuteRoleSetOperation(string subscriptionID, string serviceName, string deploymentName, RoleSetOperation roleSetOperation, AsyncCallback callback, object state);

        void EndExecuteRoleSetOperation(IAsyncResult asyncResult);

        [ServiceKnownType(typeof(LoadBalancedEndpointList))]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionID}/services/hostedservices/{serviceName}/deployments/{deploymentName}?comp=UpdateLbSet")]
        IAsyncResult BeginUpdateLoadBalancedEndpointSet(string subscriptionID, string serviceName, string deploymentName, LoadBalancedEndpointList loadBalancedEndpointList, AsyncCallback callback, object state);

        void EndUpdateLoadBalancedEndpointSet(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/extensions")]
        IAsyncResult BeginAddHostedServiceExtension(string subscriptionId, string serviceName, HostedServiceExtensionInput extension, AsyncCallback callback, object state);

        void EndAddHostedServiceExtension(IAsyncResult asyncResult);

        [WebInvoke(Method = "GET", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/extensions")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginListHostedServiceExtensions(string subscriptionId, string serviceName, AsyncCallback callback, object state);

        HostedServiceExtensionList EndListHostedServiceExtensions(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/extensions/{extensionId}")]
        IAsyncResult BeginGetHostedServiceExtension(string subscriptionId, string serviceName, string extensionId, AsyncCallback callback, object state);

        HostedServiceExtension EndGetHostedServiceExtension(IAsyncResult asyncResult);

        [WebInvoke(Method = "DELETE", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}/extensions/{extensionId}")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginDeleteHostedServiceExtension(string subscriptionId, string serviceName, string extensionId, AsyncCallback callback, object state);

        void EndDeleteHostedServiceExtension(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = "{subscriptionId}/services/extensions")]
        IAsyncResult BeginListLatestExtensions(string subscriptionId, AsyncCallback callback, object state);

        ExtensionImageList EndListLatestExtensions(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/hostedservices")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginCreateHostedService(string subscriptionId, CreateHostedServiceInput input, AsyncCallback callback, object state);

        void EndCreateHostedService(IAsyncResult asyncResult);

        [WebInvoke(Method = "PUT", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginUpdateHostedService(string subscriptionId, string serviceName, UpdateHostedServiceInput input, AsyncCallback callback, object state);

        void EndUpdateHostedService(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "DELETE", UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}")]
        IAsyncResult BeginDeleteHostedService(string subscriptionId, string serviceName, AsyncCallback callback, object state);

        void EndDeleteHostedService(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = "{subscriptionId}/services/hostedservices")]
        IAsyncResult BeginListHostedServices(string subscriptionId, AsyncCallback callback, object state);

        HostedServiceList EndListHostedServices(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}")]
        IAsyncResult BeginGetHostedService(string subscriptionId, string serviceName, AsyncCallback callback, object state);

        HostedService EndGetHostedService(IAsyncResult asyncResult);

        [WebGet(UriTemplate = "{subscriptionId}/services/hostedservices/{serviceName}?embed-detail={embedDetail}")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginGetHostedServiceWithDetails(string subscriptionId, string serviceName, bool embedDetail, AsyncCallback callback, object state);

        HostedService EndGetHostedServiceWithDetails(IAsyncResult asyncResult);

        [WebGet(UriTemplate = "{subscriptionId}/locations")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginListLocations(string subscriptionId, AsyncCallback callback, object state);

        LocationList EndListLocations(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = "{subscriptionId}/services/hostedservices/operations/isavailable/{serviceName}")]
        IAsyncResult BeginIsDNSAvailable(string subscriptionId, string serviceName, AsyncCallback callback, object state);

        AvailabilityResponse EndIsDNSAvailable(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "PUT", UriTemplate = "{subscriptionId}/services/networking/media")]
        IAsyncResult BeginSetNetworkConfiguration(string subscriptionId, Stream networkConfiguration, AsyncCallback callback, object state);

        void EndSetNetworkConfiguration(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = "{subscriptionId}/services/networking/media")]
        IAsyncResult BeginGetNetworkConfiguration(string subscriptionId, AsyncCallback callback, object state);

        Stream EndGetNetworkConfiguration(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = "{subscriptionId}/services/networking/virtualnetwork")]
        IAsyncResult BeginListVirtualNetworkSites(string subscriptionId, AsyncCallback callback, object state);

        VirtualNetworkSiteList EndListVirtualNetworkSites(IAsyncResult asyncResult);

        [WebInvoke(Method = "GET", UriTemplate = "{subscriptionId}/operatingsystems")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginListOperatingSystems(string subscriptionId, AsyncCallback callback, object state);

        OperatingSystemList EndListOperatingSystems(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = "{subscriptionId}/operatingsystemfamilies")]
        IAsyncResult BeginListOperatingSystemFamilies(string subscriptionId, AsyncCallback callback, object state);

        OperatingSystemFamilyList EndListOperatingSystemFamilies(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = "{subscriptionId}/operations/{operationTrackingId}")]
        IAsyncResult BeginGetOperationStatus(string subscriptionId, string operationTrackingId, AsyncCallback callback, object state);

        Operation EndGetOperationStatus(IAsyncResult asyncResult);

        [WebGet(UriTemplate = "{subscriptionID}/services/images")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginListOSImages(string subscriptionID, AsyncCallback callback, object state);

        OSImageList EndListOSImages(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionID}/services/images")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginCreateOSImage(string subscriptionID, OSImage image, AsyncCallback callback, object state);

        OSImage EndCreateOSImage(IAsyncResult asyncResult);

        [WebGet(UriTemplate = "{subscriptionID}/services/images/{imageName}")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginGetOSImage(string subscriptionID, string imageName, AsyncCallback callback, object state);

        OSImage EndGetOSImage(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "PUT", UriTemplate = "{subscriptionID}/services/images/{imageName}")]
        IAsyncResult BeginUpdateOSImage(string subscriptionID, string imageName, OSImage image, AsyncCallback callback, object state);

        OSImage EndUpdateOSImage(IAsyncResult asyncResult);

        [WebInvoke(Method = "DELETE", UriTemplate = "{subscriptionID}/services/images/{imageName}")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginDeleteOSImage(string subscriptionID, string imageName, AsyncCallback callback, object state);

        void EndDeleteOSImage(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "DELETE", UriTemplate = "{subscriptionID}/services/images/{imageName}?comp={comp}")]
        IAsyncResult BeginDeleteOSImageEx(string subscriptionID, string imageName, string comp, AsyncCallback callback, object state);

        void EndDeleteOSImageEx(IAsyncResult asyncResult);

        [WebInvoke(Method = "PUT", UriTemplate = "{subscriptionID}/services/images/{imageName}/replicate")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginReplicateOSImage(string subscriptionID, string imageName, ReplicationInput replicationInput, AsyncCallback callback, object state);

        string EndReplicateOSImage(IAsyncResult asyncResult);

        [WebInvoke(Method = "PUT", UriTemplate = "{subscriptionID}/services/images/{imageName}/share?permission={permission}")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginShareOSImage(string subscriptionID, string imageName, string permission, AsyncCallback callback, object state);

        bool EndShareOSImage(IAsyncResult asyncResult);

        [WebInvoke(Method = "PUT", UriTemplate = "{subscriptionID}/services/images/{imageName}/unreplicate")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginUnReplicateOSImage(string subscriptionID, string imageName, AsyncCallback callback, object state);

        void EndUnReplicateOSImage(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = "{subscriptionID}/services/images/query?location={location}&publisher={publisher}")]
        IAsyncResult BeginQueryOSImages(string subscriptionID, string location, string publisher, AsyncCallback callback, object state);

        OSImageList EndQueryOSImages(IAsyncResult asyncResult);

        [WebGet(UriTemplate = "{subscriptionID}/services/images/{imageName}/details")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginGetOSImageWithDetails(string subscriptionID, string imageName, AsyncCallback callback, object state);

        OSImageDetails EndGetOSImageWithDetails(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/storageservices")]
        IAsyncResult BeginCreateStorageService(string subscriptionId, CreateStorageServiceInput input, AsyncCallback callback, object state);

        void EndCreateStorageService(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "PUT", UriTemplate = "{subscriptionId}/services/storageservices/{serviceName}")]
        IAsyncResult BeginUpdateStorageService(string subscriptionId, string serviceName, UpdateStorageServiceInput input, AsyncCallback callback, object state);

        void EndUpdateStorageService(IAsyncResult asyncResult);

        [WebInvoke(Method = "DELETE", UriTemplate = "{subscriptionId}/services/storageservices/{serviceName}")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginDeleteStorageService(string subscriptionId, string serviceName, AsyncCallback callback, object state);

        void EndDeleteStorageService(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = "{subscriptionId}/services/storageservices")]
        IAsyncResult BeginListStorageServices(string subscriptionId, AsyncCallback callback, object state);

        StorageServiceList EndListStorageServices(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = "{subscriptionId}/services/storageservices/{serviceName}")]
        IAsyncResult BeginGetStorageService(string subscriptionId, string serviceName, AsyncCallback callback, object state);

        StorageService EndGetStorageService(IAsyncResult asyncResult);

        [WebGet(UriTemplate = "{subscriptionId}/services/storageservices/{serviceName}/keys")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginGetStorageKeys(string subscriptionId, string serviceName, AsyncCallback callback, object state);

        StorageService EndGetStorageKeys(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionId}/services/storageservices/{serviceName}/keys?action=regenerate")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginRegenerateStorageServiceKeys(string subscriptionId, string serviceName, RegenerateKeys regenerateKeys, AsyncCallback callback, object state);

        StorageService EndRegenerateStorageServiceKeys(IAsyncResult asyncResult);

        [WebGet(UriTemplate = "{subscriptionID}/services/storageservices/operations/isavailable/{serviceName}")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginIsStorageServiceAvailable(string subscriptionID, string serviceName, AsyncCallback callback, object state);

        AvailabilityResponse EndIsStorageServiceAvailable(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = "{subscriptionID}")]
        IAsyncResult BeginGetSubscription(string subscriptionID, AsyncCallback callback, object state);

        Subscription EndGetSubscription(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = "{subscriptionID}/operations?starttime={starttime}&endtime={endtime}&objectidfilter={objectidfilter}&operationresultfilter={operationresultfilter}&continuationtoken={continuationtoken}")]
        IAsyncResult BeginListSubscriptionOperations(string subscriptionID, string startTime, string endTime, string objectIdFilter, string operationResultFilter, string continuationToken, AsyncCallback callback, object state);

        SubscriptionOperationCollection EndListSubscriptionOperations(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = "{subscriptionID}/certificates")]
        IAsyncResult BeginListSubscriptionCertificates(string subscriptionID, AsyncCallback callback, object state);

        SubscriptionCertificateList EndListSubscriptionCertificates(IAsyncResult asyncResult);

        [WebGet(UriTemplate = "{subscriptionID}/certificates/{thumbprint}")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginGetSubscriptionCertificate(string subscriptionID, string thumbprint, AsyncCallback callback, object state);

        SubscriptionCertificate EndGetSubscriptionCertificate(IAsyncResult asyncResult);

        [WebInvoke(Method = "POST", UriTemplate = "{subscriptionID}/certificates")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginAddSubscriptionCertificate(string subscriptionId, SubscriptionCertificate Certificate, AsyncCallback callback, object state);

        void EndAddSubscriptionCertificate(IAsyncResult asyncResult);

        [WebInvoke(Method = "DELETE", UriTemplate = "{subscriptionID}/certificates/{thumbprint}")]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginRemoveSubscriptionCertificate(string subscriptionID, string thumbprint, AsyncCallback callback, object state);

        void EndRemoveSubscriptionCertificate(IAsyncResult asyncResult);
    }
}




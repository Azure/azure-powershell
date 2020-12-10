namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(MachineTypeConverter))]
    public partial class Machine
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.Machine"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachine" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachine DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Machine(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.Machine"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachine" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachine DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Machine(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Machine" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachine FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.Machine"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Machine(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesAgent = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAgentConfiguration) content.GetValueForProperty("PropertiesAgent",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesAgent, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.AgentConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesHosting = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHostingConfiguration) content.GetValueForProperty("PropertiesHosting",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesHosting, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HostingConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesHypervisor = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHypervisorConfiguration) content.GetValueForProperty("PropertiesHypervisor",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesHypervisor, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HypervisorConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesNetworking = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfiguration) content.GetValueForProperty("PropertiesNetworking",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesNetworking, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.NetworkConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesOperatingSystem = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemConfiguration) content.GetValueForProperty("PropertiesOperatingSystem",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesOperatingSystem, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.OperatingSystemConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesResource = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineResourcesConfiguration) content.GetValueForProperty("PropertiesResource",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesResource, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.MachineResourcesConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesTimezone = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ITimezone) content.GetValueForProperty("PropertiesTimezone",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesTimezone, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.TimezoneTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesVirtualMachine = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVirtualMachineConfiguration) content.GetValueForProperty("PropertiesVirtualMachine",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesVirtualMachine, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VirtualMachineConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesBootTime = (global::System.DateTime?) content.GetValueForProperty("PropertiesBootTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesBootTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesComputerName = (string) content.GetValueForProperty("PropertiesComputerName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesComputerName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesDisplayName = (string) content.GetValueForProperty("PropertiesDisplayName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesDisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesFullyQualifiedDomainName = (string) content.GetValueForProperty("PropertiesFullyQualifiedDomainName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesFullyQualifiedDomainName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesMonitoringState = (string) content.GetValueForProperty("PropertiesMonitoringState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesMonitoringState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesTimestamp = (global::System.DateTime?) content.GetValueForProperty("PropertiesTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesTimestamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesVirtualizationState = (string) content.GetValueForProperty("PropertiesVirtualizationState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesVirtualizationState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingIpv6Interface = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv6NetworkInterface[]) content.GetValueForProperty("PropertyNetworkingIpv6Interface",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingIpv6Interface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv6NetworkInterface>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.Ipv6NetworkInterfaceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentId = (string) content.GetValueForProperty("PropertyAgentId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentDependencyAgentId = (string) content.GetValueForProperty("PropertyAgentDependencyAgentId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentDependencyAgentId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentDependencyAgentRevision = (string) content.GetValueForProperty("PropertyAgentDependencyAgentRevision",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentDependencyAgentRevision, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentDependencyAgentVersion = (string) content.GetValueForProperty("PropertyAgentDependencyAgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentDependencyAgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentRebootStatus = (string) content.GetValueForProperty("PropertyAgentRebootStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentRebootStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyHostingProvider = (string) content.GetValueForProperty("PropertyHostingProvider",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyHostingProvider, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyHypervisorType = (string) content.GetValueForProperty("PropertyHypervisorType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyHypervisorType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyHypervisorNativeHostMachineId = (string) content.GetValueForProperty("PropertyHypervisorNativeHostMachineId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyHypervisorNativeHostMachineId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingDefaultIpv4Gateway = (string[]) content.GetValueForProperty("PropertyNetworkingDefaultIpv4Gateway",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingDefaultIpv4Gateway, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingDnsCanonicalName = (string[]) content.GetValueForProperty("PropertyNetworkingDnsCanonicalName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingDnsCanonicalName, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingDnsName = (string[]) content.GetValueForProperty("PropertyNetworkingDnsName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingDnsName, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingDnsQuestion = (string[]) content.GetValueForProperty("PropertyNetworkingDnsQuestion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingDnsQuestion, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingIpv4Interface = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv4NetworkInterface[]) content.GetValueForProperty("PropertyNetworkingIpv4Interface",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingIpv4Interface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv4NetworkInterface>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.Ipv4NetworkInterfaceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentClockGranularity = (int?) content.GetValueForProperty("PropertyAgentClockGranularity",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentClockGranularity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingMacAddress = (string[]) content.GetValueForProperty("PropertyNetworkingMacAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingMacAddress, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyOperatingSystemBitness = (string) content.GetValueForProperty("PropertyOperatingSystemBitness",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyOperatingSystemBitness, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyOperatingSystemFamily = (string) content.GetValueForProperty("PropertyOperatingSystemFamily",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyOperatingSystemFamily, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyOperatingSystemFullName = (string) content.GetValueForProperty("PropertyOperatingSystemFullName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyOperatingSystemFullName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyResourceCpuSpeed = (int?) content.GetValueForProperty("PropertyResourceCpuSpeed",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyResourceCpuSpeed, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyResourceCpuSpeedAccuracy = (string) content.GetValueForProperty("PropertyResourceCpuSpeedAccuracy",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyResourceCpuSpeedAccuracy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyResourceCpu = (int?) content.GetValueForProperty("PropertyResourceCpu",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyResourceCpu, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyResourcePhysicalMemory = (int?) content.GetValueForProperty("PropertyResourcePhysicalMemory",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyResourcePhysicalMemory, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyTimezoneFullName = (string) content.GetValueForProperty("PropertyTimezoneFullName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyTimezoneFullName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyVirtualMachineNativeHostMachineId = (string) content.GetValueForProperty("PropertyVirtualMachineNativeHostMachineId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyVirtualMachineNativeHostMachineId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyVirtualMachineNativeMachineId = (string) content.GetValueForProperty("PropertyVirtualMachineNativeMachineId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyVirtualMachineNativeMachineId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyVirtualMachineName = (string) content.GetValueForProperty("PropertyVirtualMachineName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyVirtualMachineName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyVirtualMachineType = (string) content.GetValueForProperty("PropertyVirtualMachineType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyVirtualMachineType, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.Machine"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Machine(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesAgent = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAgentConfiguration) content.GetValueForProperty("PropertiesAgent",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesAgent, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.AgentConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesHosting = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHostingConfiguration) content.GetValueForProperty("PropertiesHosting",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesHosting, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HostingConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesHypervisor = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHypervisorConfiguration) content.GetValueForProperty("PropertiesHypervisor",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesHypervisor, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HypervisorConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesNetworking = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfiguration) content.GetValueForProperty("PropertiesNetworking",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesNetworking, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.NetworkConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesOperatingSystem = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemConfiguration) content.GetValueForProperty("PropertiesOperatingSystem",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesOperatingSystem, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.OperatingSystemConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesResource = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineResourcesConfiguration) content.GetValueForProperty("PropertiesResource",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesResource, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.MachineResourcesConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesTimezone = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ITimezone) content.GetValueForProperty("PropertiesTimezone",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesTimezone, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.TimezoneTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesVirtualMachine = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVirtualMachineConfiguration) content.GetValueForProperty("PropertiesVirtualMachine",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesVirtualMachine, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VirtualMachineConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesBootTime = (global::System.DateTime?) content.GetValueForProperty("PropertiesBootTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesBootTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesComputerName = (string) content.GetValueForProperty("PropertiesComputerName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesComputerName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesDisplayName = (string) content.GetValueForProperty("PropertiesDisplayName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesDisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesFullyQualifiedDomainName = (string) content.GetValueForProperty("PropertiesFullyQualifiedDomainName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesFullyQualifiedDomainName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesMonitoringState = (string) content.GetValueForProperty("PropertiesMonitoringState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesMonitoringState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesTimestamp = (global::System.DateTime?) content.GetValueForProperty("PropertiesTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesTimestamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesVirtualizationState = (string) content.GetValueForProperty("PropertiesVirtualizationState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertiesVirtualizationState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingIpv6Interface = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv6NetworkInterface[]) content.GetValueForProperty("PropertyNetworkingIpv6Interface",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingIpv6Interface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv6NetworkInterface>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.Ipv6NetworkInterfaceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentId = (string) content.GetValueForProperty("PropertyAgentId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentDependencyAgentId = (string) content.GetValueForProperty("PropertyAgentDependencyAgentId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentDependencyAgentId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentDependencyAgentRevision = (string) content.GetValueForProperty("PropertyAgentDependencyAgentRevision",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentDependencyAgentRevision, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentDependencyAgentVersion = (string) content.GetValueForProperty("PropertyAgentDependencyAgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentDependencyAgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentRebootStatus = (string) content.GetValueForProperty("PropertyAgentRebootStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentRebootStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyHostingProvider = (string) content.GetValueForProperty("PropertyHostingProvider",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyHostingProvider, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyHypervisorType = (string) content.GetValueForProperty("PropertyHypervisorType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyHypervisorType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyHypervisorNativeHostMachineId = (string) content.GetValueForProperty("PropertyHypervisorNativeHostMachineId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyHypervisorNativeHostMachineId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingDefaultIpv4Gateway = (string[]) content.GetValueForProperty("PropertyNetworkingDefaultIpv4Gateway",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingDefaultIpv4Gateway, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingDnsCanonicalName = (string[]) content.GetValueForProperty("PropertyNetworkingDnsCanonicalName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingDnsCanonicalName, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingDnsName = (string[]) content.GetValueForProperty("PropertyNetworkingDnsName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingDnsName, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingDnsQuestion = (string[]) content.GetValueForProperty("PropertyNetworkingDnsQuestion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingDnsQuestion, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingIpv4Interface = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv4NetworkInterface[]) content.GetValueForProperty("PropertyNetworkingIpv4Interface",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingIpv4Interface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv4NetworkInterface>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.Ipv4NetworkInterfaceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentClockGranularity = (int?) content.GetValueForProperty("PropertyAgentClockGranularity",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyAgentClockGranularity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingMacAddress = (string[]) content.GetValueForProperty("PropertyNetworkingMacAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyNetworkingMacAddress, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyOperatingSystemBitness = (string) content.GetValueForProperty("PropertyOperatingSystemBitness",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyOperatingSystemBitness, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyOperatingSystemFamily = (string) content.GetValueForProperty("PropertyOperatingSystemFamily",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyOperatingSystemFamily, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyOperatingSystemFullName = (string) content.GetValueForProperty("PropertyOperatingSystemFullName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyOperatingSystemFullName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyResourceCpuSpeed = (int?) content.GetValueForProperty("PropertyResourceCpuSpeed",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyResourceCpuSpeed, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyResourceCpuSpeedAccuracy = (string) content.GetValueForProperty("PropertyResourceCpuSpeedAccuracy",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyResourceCpuSpeedAccuracy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyResourceCpu = (int?) content.GetValueForProperty("PropertyResourceCpu",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyResourceCpu, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyResourcePhysicalMemory = (int?) content.GetValueForProperty("PropertyResourcePhysicalMemory",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyResourcePhysicalMemory, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyTimezoneFullName = (string) content.GetValueForProperty("PropertyTimezoneFullName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyTimezoneFullName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyVirtualMachineNativeHostMachineId = (string) content.GetValueForProperty("PropertyVirtualMachineNativeHostMachineId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyVirtualMachineNativeHostMachineId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyVirtualMachineNativeMachineId = (string) content.GetValueForProperty("PropertyVirtualMachineNativeMachineId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyVirtualMachineNativeMachineId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyVirtualMachineName = (string) content.GetValueForProperty("PropertyVirtualMachineName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyVirtualMachineName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyVirtualMachineType = (string) content.GetValueForProperty("PropertyVirtualMachineType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineInternal)this).PropertyVirtualMachineType, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(MachineTypeConverter))]
    public partial interface IMachine

    {

    }
}
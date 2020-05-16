namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Process Information.</summary>
    [System.ComponentModel.TypeConverter(typeof(ProcessInfoTypeConverter))]
    public partial class ProcessInfo
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfo" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfo DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ProcessInfo(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfo" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfo DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ProcessInfo(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ProcessInfo" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfo FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ProcessInfo(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessInfoPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).OpenFileHandle = (string[]) content.GetValueForProperty("OpenFileHandle",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).OpenFileHandle, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).CommandLine = (string) content.GetValueForProperty("CommandLine",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).CommandLine, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).DeploymentName = (string) content.GetValueForProperty("DeploymentName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).DeploymentName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).EnvironmentVariable = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesEnvironmentVariables) content.GetValueForProperty("EnvironmentVariable",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).EnvironmentVariable, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessInfoPropertiesEnvironmentVariablesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).FileName = (string) content.GetValueForProperty("FileName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).FileName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).HandleCount = (int?) content.GetValueForProperty("HandleCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).HandleCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Href = (string) content.GetValueForProperty("Href",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Href, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Identifier = (int?) content.GetValueForProperty("Identifier",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Identifier, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).IisProfileTimeoutInSecond = (double?) content.GetValueForProperty("IisProfileTimeoutInSecond",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).IisProfileTimeoutInSecond, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).IsIisProfileRunning = (bool?) content.GetValueForProperty("IsIisProfileRunning",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).IsIisProfileRunning, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).IsProfileRunning = (bool?) content.GetValueForProperty("IsProfileRunning",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).IsProfileRunning, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).IsScmSite = (bool?) content.GetValueForProperty("IsScmSite",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).IsScmSite, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).IsWebjob = (bool?) content.GetValueForProperty("IsWebjob",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).IsWebjob, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Minidump = (string) content.GetValueForProperty("Minidump",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Minidump, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).ModuleCount = (int?) content.GetValueForProperty("ModuleCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).ModuleCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Module = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfo[]) content.GetValueForProperty("Module",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Module, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfo>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessModuleInfoTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).NonPagedSystemMemory = (long?) content.GetValueForProperty("NonPagedSystemMemory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).NonPagedSystemMemory, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Child = (string[]) content.GetValueForProperty("Child",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Child, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PagedMemory = (long?) content.GetValueForProperty("PagedMemory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PagedMemory, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PagedSystemMemory = (long?) content.GetValueForProperty("PagedSystemMemory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PagedSystemMemory, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Parent = (string) content.GetValueForProperty("Parent",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Parent, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PeakPagedMemory = (long?) content.GetValueForProperty("PeakPagedMemory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PeakPagedMemory, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PeakVirtualMemory = (long?) content.GetValueForProperty("PeakVirtualMemory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PeakVirtualMemory, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PeakWorkingSet = (long?) content.GetValueForProperty("PeakWorkingSet",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PeakWorkingSet, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PrivateMemory = (long?) content.GetValueForProperty("PrivateMemory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PrivateMemory, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PrivilegedCpuTime = (string) content.GetValueForProperty("PrivilegedCpuTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PrivilegedCpuTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).ThreadCount = (int?) content.GetValueForProperty("ThreadCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).ThreadCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Thread = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfo[]) content.GetValueForProperty("Thread",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Thread, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfo>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessThreadInfoTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).TimeStamp = (global::System.DateTime?) content.GetValueForProperty("TimeStamp",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).TimeStamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).TotalCpuTime = (string) content.GetValueForProperty("TotalCpuTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).TotalCpuTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).UserCpuTime = (string) content.GetValueForProperty("UserCpuTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).UserCpuTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).UserName = (string) content.GetValueForProperty("UserName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).UserName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).VirtualMemory = (long?) content.GetValueForProperty("VirtualMemory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).VirtualMemory, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).WorkingSet = (long?) content.GetValueForProperty("WorkingSet",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).WorkingSet, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ProcessInfo(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessInfoPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).OpenFileHandle = (string[]) content.GetValueForProperty("OpenFileHandle",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).OpenFileHandle, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).CommandLine = (string) content.GetValueForProperty("CommandLine",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).CommandLine, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).DeploymentName = (string) content.GetValueForProperty("DeploymentName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).DeploymentName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).EnvironmentVariable = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesEnvironmentVariables) content.GetValueForProperty("EnvironmentVariable",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).EnvironmentVariable, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessInfoPropertiesEnvironmentVariablesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).FileName = (string) content.GetValueForProperty("FileName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).FileName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).HandleCount = (int?) content.GetValueForProperty("HandleCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).HandleCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Href = (string) content.GetValueForProperty("Href",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Href, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Identifier = (int?) content.GetValueForProperty("Identifier",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Identifier, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).IisProfileTimeoutInSecond = (double?) content.GetValueForProperty("IisProfileTimeoutInSecond",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).IisProfileTimeoutInSecond, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).IsIisProfileRunning = (bool?) content.GetValueForProperty("IsIisProfileRunning",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).IsIisProfileRunning, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).IsProfileRunning = (bool?) content.GetValueForProperty("IsProfileRunning",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).IsProfileRunning, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).IsScmSite = (bool?) content.GetValueForProperty("IsScmSite",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).IsScmSite, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).IsWebjob = (bool?) content.GetValueForProperty("IsWebjob",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).IsWebjob, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Minidump = (string) content.GetValueForProperty("Minidump",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Minidump, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).ModuleCount = (int?) content.GetValueForProperty("ModuleCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).ModuleCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Module = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfo[]) content.GetValueForProperty("Module",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Module, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfo>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessModuleInfoTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).NonPagedSystemMemory = (long?) content.GetValueForProperty("NonPagedSystemMemory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).NonPagedSystemMemory, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Child = (string[]) content.GetValueForProperty("Child",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Child, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PagedMemory = (long?) content.GetValueForProperty("PagedMemory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PagedMemory, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PagedSystemMemory = (long?) content.GetValueForProperty("PagedSystemMemory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PagedSystemMemory, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Parent = (string) content.GetValueForProperty("Parent",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Parent, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PeakPagedMemory = (long?) content.GetValueForProperty("PeakPagedMemory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PeakPagedMemory, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PeakVirtualMemory = (long?) content.GetValueForProperty("PeakVirtualMemory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PeakVirtualMemory, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PeakWorkingSet = (long?) content.GetValueForProperty("PeakWorkingSet",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PeakWorkingSet, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PrivateMemory = (long?) content.GetValueForProperty("PrivateMemory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PrivateMemory, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PrivilegedCpuTime = (string) content.GetValueForProperty("PrivilegedCpuTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).PrivilegedCpuTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).ThreadCount = (int?) content.GetValueForProperty("ThreadCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).ThreadCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Thread = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfo[]) content.GetValueForProperty("Thread",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).Thread, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfo>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessThreadInfoTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).TimeStamp = (global::System.DateTime?) content.GetValueForProperty("TimeStamp",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).TimeStamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).TotalCpuTime = (string) content.GetValueForProperty("TotalCpuTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).TotalCpuTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).UserCpuTime = (string) content.GetValueForProperty("UserCpuTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).UserCpuTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).UserName = (string) content.GetValueForProperty("UserName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).UserName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).VirtualMemory = (long?) content.GetValueForProperty("VirtualMemory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).VirtualMemory, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).WorkingSet = (long?) content.GetValueForProperty("WorkingSet",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal)this).WorkingSet, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Process Information.
    [System.ComponentModel.TypeConverter(typeof(ProcessInfoTypeConverter))]
    public partial interface IProcessInfo

    {

    }
}
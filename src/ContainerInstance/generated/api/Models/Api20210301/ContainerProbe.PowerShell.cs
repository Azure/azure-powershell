namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.PowerShell;

    /// <summary>The container probe, for liveness or readiness</summary>
    [System.ComponentModel.TypeConverter(typeof(ContainerProbeTypeConverter))]
    public partial class ContainerProbe
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
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerProbe"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ContainerProbe(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).Exec = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExec) content.GetValueForProperty("Exec",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).Exec, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerExecTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpGet = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGet) content.GetValueForProperty("HttpGet",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpGet, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerHttpGetTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).InitialDelaySecond = (int?) content.GetValueForProperty("InitialDelaySecond",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).InitialDelaySecond, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).PeriodSecond = (int?) content.GetValueForProperty("PeriodSecond",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).PeriodSecond, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).FailureThreshold = (int?) content.GetValueForProperty("FailureThreshold",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).FailureThreshold, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).SuccessThreshold = (int?) content.GetValueForProperty("SuccessThreshold",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).SuccessThreshold, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).TimeoutSecond = (int?) content.GetValueForProperty("TimeoutSecond",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).TimeoutSecond, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpGetHttpHeader = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IHttpHeaders) content.GetValueForProperty("HttpGetHttpHeader",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpGetHttpHeader, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.HttpHeadersTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpGetScheme = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme?) content.GetValueForProperty("HttpGetScheme",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpGetScheme, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).ExecCommand = (string[]) content.GetValueForProperty("ExecCommand",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).ExecCommand, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpGetPath = (string) content.GetValueForProperty("HttpGetPath",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpGetPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpGetPort = (int) content.GetValueForProperty("HttpGetPort",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpGetPort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpHeaderName = (string) content.GetValueForProperty("HttpHeaderName",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpHeaderName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpHeaderValue = (string) content.GetValueForProperty("HttpHeaderValue",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpHeaderValue, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerProbe"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ContainerProbe(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).Exec = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExec) content.GetValueForProperty("Exec",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).Exec, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerExecTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpGet = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGet) content.GetValueForProperty("HttpGet",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpGet, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerHttpGetTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).InitialDelaySecond = (int?) content.GetValueForProperty("InitialDelaySecond",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).InitialDelaySecond, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).PeriodSecond = (int?) content.GetValueForProperty("PeriodSecond",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).PeriodSecond, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).FailureThreshold = (int?) content.GetValueForProperty("FailureThreshold",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).FailureThreshold, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).SuccessThreshold = (int?) content.GetValueForProperty("SuccessThreshold",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).SuccessThreshold, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).TimeoutSecond = (int?) content.GetValueForProperty("TimeoutSecond",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).TimeoutSecond, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpGetHttpHeader = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IHttpHeaders) content.GetValueForProperty("HttpGetHttpHeader",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpGetHttpHeader, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.HttpHeadersTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpGetScheme = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme?) content.GetValueForProperty("HttpGetScheme",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpGetScheme, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).ExecCommand = (string[]) content.GetValueForProperty("ExecCommand",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).ExecCommand, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpGetPath = (string) content.GetValueForProperty("HttpGetPath",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpGetPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpGetPort = (int) content.GetValueForProperty("HttpGetPort",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpGetPort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpHeaderName = (string) content.GetValueForProperty("HttpHeaderName",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpHeaderName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpHeaderValue = (string) content.GetValueForProperty("HttpHeaderValue",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)this).HttpHeaderValue, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerProbe"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbe" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbe DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ContainerProbe(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerProbe"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbe" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbe DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ContainerProbe(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ContainerProbe" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbe FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// The container probe, for liveness or readiness
    [System.ComponentModel.TypeConverter(typeof(ContainerProbeTypeConverter))]
    public partial interface IContainerProbe

    {

    }
}
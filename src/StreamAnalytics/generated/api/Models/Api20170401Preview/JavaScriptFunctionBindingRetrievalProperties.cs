namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The binding retrieval properties associated with a JavaScript function.</summary>
    public partial class JavaScriptFunctionBindingRetrievalProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJavaScriptFunctionBindingRetrievalProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJavaScriptFunctionBindingRetrievalPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Script" /> property.</summary>
        private string _script;

        /// <summary>
        /// The JavaScript code containing a single function definition. For example: 'function (x, y) { return x + y; }'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Script { get => this._script; set => this._script = value; }

        /// <summary>Backing field for <see cref="UdfType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? _udfType;

        /// <summary>The function type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? UdfType { get => this._udfType; set => this._udfType = value; }

        /// <summary>
        /// Creates an new <see cref="JavaScriptFunctionBindingRetrievalProperties" /> instance.
        /// </summary>
        public JavaScriptFunctionBindingRetrievalProperties()
        {

        }
    }
    /// The binding retrieval properties associated with a JavaScript function.
    public partial interface IJavaScriptFunctionBindingRetrievalProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The JavaScript code containing a single function definition. For example: 'function (x, y) { return x + y; }'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The JavaScript code containing a single function definition. For example: 'function (x, y) { return x + y; }'.",
        SerializedName = @"script",
        PossibleTypes = new [] { typeof(string) })]
        string Script { get; set; }
        /// <summary>The function type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The function type.",
        SerializedName = @"udfType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? UdfType { get; set; }

    }
    /// The binding retrieval properties associated with a JavaScript function.
    internal partial interface IJavaScriptFunctionBindingRetrievalPropertiesInternal

    {
        /// <summary>
        /// The JavaScript code containing a single function definition. For example: 'function (x, y) { return x + y; }'.
        /// </summary>
        string Script { get; set; }
        /// <summary>The function type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? UdfType { get; set; }

    }
}
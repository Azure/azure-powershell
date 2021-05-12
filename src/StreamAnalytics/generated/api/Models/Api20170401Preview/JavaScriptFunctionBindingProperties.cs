namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The binding properties associated with a JavaScript function.</summary>
    public partial class JavaScriptFunctionBindingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJavaScriptFunctionBindingProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJavaScriptFunctionBindingPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Script" /> property.</summary>
        private string _script;

        /// <summary>
        /// The JavaScript code containing a single function definition. For example: 'function (x, y) { return x + y; }'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Script { get => this._script; set => this._script = value; }

        /// <summary>Creates an new <see cref="JavaScriptFunctionBindingProperties" /> instance.</summary>
        public JavaScriptFunctionBindingProperties()
        {

        }
    }
    /// The binding properties associated with a JavaScript function.
    public partial interface IJavaScriptFunctionBindingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The JavaScript code containing a single function definition. For example: 'function (x, y) { return x + y; }'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The JavaScript code containing a single function definition. For example: 'function (x, y) { return x + y; }'",
        SerializedName = @"script",
        PossibleTypes = new [] { typeof(string) })]
        string Script { get; set; }

    }
    /// The binding properties associated with a JavaScript function.
    internal partial interface IJavaScriptFunctionBindingPropertiesInternal

    {
        /// <summary>
        /// The JavaScript code containing a single function definition. For example: 'function (x, y) { return x + y; }'
        /// </summary>
        string Script { get; set; }

    }
}
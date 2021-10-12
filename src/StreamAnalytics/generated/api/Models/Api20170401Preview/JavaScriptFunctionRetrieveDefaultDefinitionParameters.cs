namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>
    /// The parameters needed to retrieve the default function definition for a JavaScript function.
    /// </summary>
    public partial class JavaScriptFunctionRetrieveDefaultDefinitionParameters :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJavaScriptFunctionRetrieveDefaultDefinitionParameters,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJavaScriptFunctionRetrieveDefaultDefinitionParametersInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParameters"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParameters __functionRetrieveDefaultDefinitionParameters = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.FunctionRetrieveDefaultDefinitionParameters();

        /// <summary>Backing field for <see cref="BindingRetrievalProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJavaScriptFunctionBindingRetrievalProperties _bindingRetrievalProperty;

        /// <summary>The binding retrieval properties associated with a JavaScript function.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJavaScriptFunctionBindingRetrievalProperties BindingRetrievalProperty { get => (this._bindingRetrievalProperty = this._bindingRetrievalProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.JavaScriptFunctionBindingRetrievalProperties()); set => this._bindingRetrievalProperty = value; }

        /// <summary>
        /// The JavaScript code containing a single function definition. For example: 'function (x, y) { return x + y; }'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string BindingRetrievalPropertyScript { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJavaScriptFunctionBindingRetrievalPropertiesInternal)BindingRetrievalProperty).Script; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJavaScriptFunctionBindingRetrievalPropertiesInternal)BindingRetrievalProperty).Script = value ?? null; }

        /// <summary>The function type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? BindingRetrievalPropertyUdfType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJavaScriptFunctionBindingRetrievalPropertiesInternal)BindingRetrievalProperty).UdfType; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJavaScriptFunctionBindingRetrievalPropertiesInternal)BindingRetrievalProperty).UdfType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType)""); }

        /// <summary>Indicates the function binding type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string BindingType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParametersInternal)__functionRetrieveDefaultDefinitionParameters).BindingType; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParametersInternal)__functionRetrieveDefaultDefinitionParameters).BindingType = value ; }

        /// <summary>Internal Acessors for BindingRetrievalProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJavaScriptFunctionBindingRetrievalProperties Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJavaScriptFunctionRetrieveDefaultDefinitionParametersInternal.BindingRetrievalProperty { get => (this._bindingRetrievalProperty = this._bindingRetrievalProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.JavaScriptFunctionBindingRetrievalProperties()); set { {_bindingRetrievalProperty = value;} } }

        /// <summary>
        /// Creates an new <see cref="JavaScriptFunctionRetrieveDefaultDefinitionParameters" /> instance.
        /// </summary>
        public JavaScriptFunctionRetrieveDefaultDefinitionParameters()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__functionRetrieveDefaultDefinitionParameters), __functionRetrieveDefaultDefinitionParameters);
            await eventListener.AssertObjectIsValid(nameof(__functionRetrieveDefaultDefinitionParameters), __functionRetrieveDefaultDefinitionParameters);
        }
    }
    /// The parameters needed to retrieve the default function definition for a JavaScript function.
    public partial interface IJavaScriptFunctionRetrieveDefaultDefinitionParameters :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParameters
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
        string BindingRetrievalPropertyScript { get; set; }
        /// <summary>The function type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The function type.",
        SerializedName = @"udfType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? BindingRetrievalPropertyUdfType { get; set; }

    }
    /// The parameters needed to retrieve the default function definition for a JavaScript function.
    internal partial interface IJavaScriptFunctionRetrieveDefaultDefinitionParametersInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParametersInternal
    {
        /// <summary>The binding retrieval properties associated with a JavaScript function.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJavaScriptFunctionBindingRetrievalProperties BindingRetrievalProperty { get; set; }
        /// <summary>
        /// The JavaScript code containing a single function definition. For example: 'function (x, y) { return x + y; }'.
        /// </summary>
        string BindingRetrievalPropertyScript { get; set; }
        /// <summary>The function type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? BindingRetrievalPropertyUdfType { get; set; }

    }
}
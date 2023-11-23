namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The binding to a CSharp function.</summary>
    public partial class CSharpFunctionBinding :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICSharpFunctionBinding,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICSharpFunctionBindingInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionBinding"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionBinding __functionBinding = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.FunctionBinding();

        /// <summary>The Csharp code containing a single function definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string Class { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICSharpFunctionBindingPropertiesInternal)Property).Class; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICSharpFunctionBindingPropertiesInternal)Property).Class = value ?? null; }

        /// <summary>The Csharp code containing a single function definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string DllPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICSharpFunctionBindingPropertiesInternal)Property).DllPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICSharpFunctionBindingPropertiesInternal)Property).DllPath = value ?? null; }

        /// <summary>The Csharp code containing a single function definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string Method { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICSharpFunctionBindingPropertiesInternal)Property).Method; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICSharpFunctionBindingPropertiesInternal)Property).Method = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICSharpFunctionBindingProperties Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICSharpFunctionBindingInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.CSharpFunctionBindingProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICSharpFunctionBindingProperties _property;

        /// <summary>The binding properties associated with a CSharp function.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICSharpFunctionBindingProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.CSharpFunctionBindingProperties()); set => this._property = value; }

        /// <summary>The Csharp code containing a single function definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string Script { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICSharpFunctionBindingPropertiesInternal)Property).Script; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICSharpFunctionBindingPropertiesInternal)Property).Script = value ?? null; }

        /// <summary>Indicates the function binding type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionBindingInternal)__functionBinding).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionBindingInternal)__functionBinding).Type = value ; }

        /// <summary>Creates an new <see cref="CSharpFunctionBinding" /> instance.</summary>
        public CSharpFunctionBinding()
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
            await eventListener.AssertNotNull(nameof(__functionBinding), __functionBinding);
            await eventListener.AssertObjectIsValid(nameof(__functionBinding), __functionBinding);
        }
    }
    /// The binding to a CSharp function.
    public partial interface ICSharpFunctionBinding :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionBinding
    {
        /// <summary>The Csharp code containing a single function definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Csharp code containing a single function definition.",
        SerializedName = @"class",
        PossibleTypes = new [] { typeof(string) })]
        string Class { get; set; }
        /// <summary>The Csharp code containing a single function definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Csharp code containing a single function definition.",
        SerializedName = @"dllPath",
        PossibleTypes = new [] { typeof(string) })]
        string DllPath { get; set; }
        /// <summary>The Csharp code containing a single function definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Csharp code containing a single function definition.",
        SerializedName = @"method",
        PossibleTypes = new [] { typeof(string) })]
        string Method { get; set; }
        /// <summary>The Csharp code containing a single function definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Csharp code containing a single function definition.",
        SerializedName = @"script",
        PossibleTypes = new [] { typeof(string) })]
        string Script { get; set; }

    }
    /// The binding to a CSharp function.
    internal partial interface ICSharpFunctionBindingInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionBindingInternal
    {
        /// <summary>The Csharp code containing a single function definition.</summary>
        string Class { get; set; }
        /// <summary>The Csharp code containing a single function definition.</summary>
        string DllPath { get; set; }
        /// <summary>The Csharp code containing a single function definition.</summary>
        string Method { get; set; }
        /// <summary>The binding properties associated with a CSharp function.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICSharpFunctionBindingProperties Property { get; set; }
        /// <summary>The Csharp code containing a single function definition.</summary>
        string Script { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The binding retrieval properties associated with a CSharp function.</summary>
    public partial class CSharpFunctionBindingRetrievalProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICSharpFunctionBindingRetrievalProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICSharpFunctionBindingRetrievalPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Script" /> property.</summary>
        private string _script;

        /// <summary>The CSharp code containing a single function definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Script { get => this._script; set => this._script = value; }

        /// <summary>Backing field for <see cref="UdfType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? _udfType;

        /// <summary>The function type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? UdfType { get => this._udfType; set => this._udfType = value; }

        /// <summary>
        /// Creates an new <see cref="CSharpFunctionBindingRetrievalProperties" /> instance.
        /// </summary>
        public CSharpFunctionBindingRetrievalProperties()
        {

        }
    }
    /// The binding retrieval properties associated with a CSharp function.
    public partial interface ICSharpFunctionBindingRetrievalProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>The CSharp code containing a single function definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The CSharp code containing a single function definition.",
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
    /// The binding retrieval properties associated with a CSharp function.
    internal partial interface ICSharpFunctionBindingRetrievalPropertiesInternal

    {
        /// <summary>The CSharp code containing a single function definition.</summary>
        string Script { get; set; }
        /// <summary>The function type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? UdfType { get; set; }

    }
}
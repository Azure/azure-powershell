namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>
    /// Parameters used to specify the type of function to retrieve the default definition for.
    /// </summary>
    public partial class FunctionRetrieveDefaultDefinitionParameters :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParameters,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParametersInternal
    {

        /// <summary>Backing field for <see cref="BindingType" /> property.</summary>
        private string _bindingType;

        /// <summary>Indicates the function binding type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string BindingType { get => this._bindingType; set => this._bindingType = value; }

        /// <summary>
        /// Creates an new <see cref="FunctionRetrieveDefaultDefinitionParameters" /> instance.
        /// </summary>
        public FunctionRetrieveDefaultDefinitionParameters()
        {

        }
    }
    /// Parameters used to specify the type of function to retrieve the default definition for.
    public partial interface IFunctionRetrieveDefaultDefinitionParameters :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>Indicates the function binding type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Indicates the function binding type.",
        SerializedName = @"bindingType",
        PossibleTypes = new [] { typeof(string) })]
        string BindingType { get; set; }

    }
    /// Parameters used to specify the type of function to retrieve the default definition for.
    internal partial interface IFunctionRetrieveDefaultDefinitionParametersInternal

    {
        /// <summary>Indicates the function binding type.</summary>
        string BindingType { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>
    /// The physical binding of the function. For example, in the Azure Machine Learning web service’s case, this describes the
    /// endpoint.
    /// </summary>
    public partial class FunctionBinding :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionBinding,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionBindingInternal
    {

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Indicates the function binding type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="FunctionBinding" /> instance.</summary>
        public FunctionBinding()
        {

        }
    }
    /// The physical binding of the function. For example, in the Azure Machine Learning web service’s case, this describes the
    /// endpoint.
    public partial interface IFunctionBinding :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>Indicates the function binding type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Indicates the function binding type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// The physical binding of the function. For example, in the Azure Machine Learning web service’s case, this describes the
    /// endpoint.
    internal partial interface IFunctionBindingInternal

    {
        /// <summary>Indicates the function binding type.</summary>
        string Type { get; set; }

    }
}
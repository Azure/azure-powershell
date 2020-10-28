namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Custom domain validate payload.</summary>
    public partial class CustomDomainValidatePayload :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICustomDomainValidatePayload,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICustomDomainValidatePayloadInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name to be validated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="CustomDomainValidatePayload" /> instance.</summary>
        public CustomDomainValidatePayload()
        {

        }
    }
    /// Custom domain validate payload.
    public partial interface ICustomDomainValidatePayload :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>Name to be validated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Name to be validated",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Custom domain validate payload.
    public partial interface ICustomDomainValidatePayloadInternal

    {
        /// <summary>Name to be validated</summary>
        string Name { get; set; }

    }
}
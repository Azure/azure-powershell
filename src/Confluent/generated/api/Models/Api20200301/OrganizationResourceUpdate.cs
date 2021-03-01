namespace Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Extensions;

    /// <summary>Organization Resource update</summary>
    public partial class OrganizationResourceUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceUpdateInternal
    {

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceUpdateTags _tag;

        /// <summary>ARM resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceUpdateTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.OrganizationResourceUpdateTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="OrganizationResourceUpdate" /> instance.</summary>
        public OrganizationResourceUpdate()
        {

        }
    }
    /// Organization Resource update
    public partial interface IOrganizationResourceUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.IJsonSerializable
    {
        /// <summary>ARM resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ARM resource tags",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceUpdateTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceUpdateTags Tag { get; set; }

    }
    /// Organization Resource update
    internal partial interface IOrganizationResourceUpdateInternal

    {
        /// <summary>ARM resource tags</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceUpdateTags Tag { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Extensions;

    /// <summary>the list of ManagementAssociation response</summary>
    public partial class ManagementAssociationPropertiesList :
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociationPropertiesList,
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociationPropertiesListInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociation[] _value;

        /// <summary>List of Management Association properties within the subscription.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociation[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ManagementAssociationPropertiesList" /> instance.</summary>
        public ManagementAssociationPropertiesList()
        {

        }
    }
    /// the list of ManagementAssociation response
    public partial interface IManagementAssociationPropertiesList :
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.IJsonSerializable
    {
        /// <summary>List of Management Association properties within the subscription.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of Management Association properties within the subscription.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociation) })]
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociation[] Value { get; set; }

    }
    /// the list of ManagementAssociation response
    internal partial interface IManagementAssociationPropertiesListInternal

    {
        /// <summary>List of Management Association properties within the subscription.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociation[] Value { get; set; }

    }
}
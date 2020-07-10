namespace Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Extensions;

    /// <summary>
    /// ManagementAssociation properties supported by the OperationsManagement resource provider.
    /// </summary>
    public partial class ManagementAssociationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ApplicationId" /> property.</summary>
        private string _applicationId;

        /// <summary>The applicationId of the appliance for this association.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public string ApplicationId { get => this._applicationId; set => this._applicationId = value; }

        /// <summary>Creates an new <see cref="ManagementAssociationProperties" /> instance.</summary>
        public ManagementAssociationProperties()
        {

        }
    }
    /// ManagementAssociation properties supported by the OperationsManagement resource provider.
    public partial interface IManagementAssociationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.IJsonSerializable
    {
        /// <summary>The applicationId of the appliance for this association.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The applicationId of the appliance for this association.",
        SerializedName = @"applicationId",
        PossibleTypes = new [] { typeof(string) })]
        string ApplicationId { get; set; }

    }
    /// ManagementAssociation properties supported by the OperationsManagement resource provider.
    internal partial interface IManagementAssociationPropertiesInternal

    {
        /// <summary>The applicationId of the appliance for this association.</summary>
        string ApplicationId { get; set; }

    }
}
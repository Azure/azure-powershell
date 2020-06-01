namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>CertificateOrderAction resource specific properties</summary>
    public partial class CertificateOrderActionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateOrderActionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateOrderActionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ActionType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateOrderActionType? _actionType;

        /// <summary>Action type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateOrderActionType? ActionType { get => this._actionType; }

        /// <summary>Backing field for <see cref="CreatedAt" /> property.</summary>
        private global::System.DateTime? _createdAt;

        /// <summary>Time at which the certificate action was performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? CreatedAt { get => this._createdAt; }

        /// <summary>Internal Acessors for ActionType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateOrderActionType? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateOrderActionPropertiesInternal.ActionType { get => this._actionType; set { {_actionType = value;} } }

        /// <summary>Internal Acessors for CreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateOrderActionPropertiesInternal.CreatedAt { get => this._createdAt; set { {_createdAt = value;} } }

        /// <summary>Creates an new <see cref="CertificateOrderActionProperties" /> instance.</summary>
        public CertificateOrderActionProperties()
        {

        }
    }
    /// CertificateOrderAction resource specific properties
    public partial interface ICertificateOrderActionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Action type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Action type.",
        SerializedName = @"actionType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateOrderActionType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateOrderActionType? ActionType { get;  }
        /// <summary>Time at which the certificate action was performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Time at which the certificate action was performed.",
        SerializedName = @"createdAt",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedAt { get;  }

    }
    /// CertificateOrderAction resource specific properties
    internal partial interface ICertificateOrderActionPropertiesInternal

    {
        /// <summary>Action type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateOrderActionType? ActionType { get; set; }
        /// <summary>Time at which the certificate action was performed.</summary>
        global::System.DateTime? CreatedAt { get; set; }

    }
}
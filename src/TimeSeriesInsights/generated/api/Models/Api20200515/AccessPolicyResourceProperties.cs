namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    public partial class AccessPolicyResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IAccessPolicyResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IAccessPolicyResourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>An description of the access policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="PrincipalObjectId" /> property.</summary>
        private string _principalObjectId;

        /// <summary>The objectId of the principal in Azure Active Directory.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public string PrincipalObjectId { get => this._principalObjectId; set => this._principalObjectId = value; }

        /// <summary>Backing field for <see cref="Role" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.AccessPolicyRole[] _role;

        /// <summary>The list of roles the principal is assigned on the environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.AccessPolicyRole[] Role { get => this._role; set => this._role = value; }

        /// <summary>Creates an new <see cref="AccessPolicyResourceProperties" /> instance.</summary>
        public AccessPolicyResourceProperties()
        {

        }
    }
    public partial interface IAccessPolicyResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable
    {
        /// <summary>An description of the access policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"An description of the access policy.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>The objectId of the principal in Azure Active Directory.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The objectId of the principal in Azure Active Directory.",
        SerializedName = @"principalObjectId",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalObjectId { get; set; }
        /// <summary>The list of roles the principal is assigned on the environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of roles the principal is assigned on the environment.",
        SerializedName = @"roles",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.AccessPolicyRole) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.AccessPolicyRole[] Role { get; set; }

    }
    internal partial interface IAccessPolicyResourcePropertiesInternal

    {
        /// <summary>An description of the access policy.</summary>
        string Description { get; set; }
        /// <summary>The objectId of the principal in Azure Active Directory.</summary>
        string PrincipalObjectId { get; set; }
        /// <summary>The list of roles the principal is assigned on the environment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.AccessPolicyRole[] Role { get; set; }

    }
}
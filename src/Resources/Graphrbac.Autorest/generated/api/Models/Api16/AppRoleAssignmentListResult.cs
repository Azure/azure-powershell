namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>AppRoleAssignment list operation result.</summary>
    public partial class AppRoleAssignmentListResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRoleAssignmentListResult,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRoleAssignmentListResultInternal
    {

        /// <summary>Backing field for <see cref="OdataNextLink" /> property.</summary>
        private string _odataNextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string OdataNextLink { get => this._odataNextLink; set => this._odataNextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRoleAssignment[] _value;

        /// <summary>A collection of AppRoleAssignment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRoleAssignment[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="AppRoleAssignmentListResult" /> instance.</summary>
        public AppRoleAssignmentListResult()
        {

        }
    }
    /// AppRoleAssignment list operation result.
    public partial interface IAppRoleAssignmentListResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL to get the next set of results.",
        SerializedName = @"odata.nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string OdataNextLink { get; set; }
        /// <summary>A collection of AppRoleAssignment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of AppRoleAssignment.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRoleAssignment) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRoleAssignment[] Value { get; set; }

    }
    /// AppRoleAssignment list operation result.
    internal partial interface IAppRoleAssignmentListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string OdataNextLink { get; set; }
        /// <summary>A collection of AppRoleAssignment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRoleAssignment[] Value { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Server response for Get tenant users API call.</summary>
    public partial class UserListResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserListResult,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserListResultInternal
    {

        /// <summary>Backing field for <see cref="OdataNextLink" /> property.</summary>
        private string _odataNextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string OdataNextLink { get => this._odataNextLink; set => this._odataNextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUser[] _value;

        /// <summary>the list of users.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUser[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="UserListResult" /> instance.</summary>
        public UserListResult()
        {

        }
    }
    /// Server response for Get tenant users API call.
    public partial interface IUserListResult :
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
        /// <summary>the list of users.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"the list of users.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUser) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUser[] Value { get; set; }

    }
    /// Server response for Get tenant users API call.
    internal partial interface IUserListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string OdataNextLink { get; set; }
        /// <summary>the list of users.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUser[] Value { get; set; }

    }
}
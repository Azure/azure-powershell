namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Server response for Get tenant groups API call</summary>
    public partial class GroupListResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IGroupListResult,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IGroupListResultInternal
    {

        /// <summary>Backing field for <see cref="OdataNextLink" /> property.</summary>
        private string _odataNextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string OdataNextLink { get => this._odataNextLink; set => this._odataNextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAdGroup[] _value;

        /// <summary>A collection of Active Directory groups.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAdGroup[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="GroupListResult" /> instance.</summary>
        public GroupListResult()
        {

        }
    }
    /// Server response for Get tenant groups API call
    public partial interface IGroupListResult :
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
        /// <summary>A collection of Active Directory groups.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of Active Directory groups.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAdGroup) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAdGroup[] Value { get; set; }

    }
    /// Server response for Get tenant groups API call
    internal partial interface IGroupListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string OdataNextLink { get; set; }
        /// <summary>A collection of Active Directory groups.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAdGroup[] Value { get; set; }

    }
}
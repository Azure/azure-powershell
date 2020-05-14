namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Resource name availability request content.</summary>
    public partial class ResourceNameAvailabilityRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceNameAvailabilityRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceNameAvailabilityRequestInternal
    {

        /// <summary>Backing field for <see cref="IsFqdn" /> property.</summary>
        private bool? _isFqdn;

        /// <summary>Is fully qualified domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsFqdn { get => this._isFqdn; set => this._isFqdn = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Resource name to verify.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CheckNameResourceTypes _type;

        /// <summary>Resource type used for verification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CheckNameResourceTypes Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="ResourceNameAvailabilityRequest" /> instance.</summary>
        public ResourceNameAvailabilityRequest()
        {

        }
    }
    /// Resource name availability request content.
    public partial interface IResourceNameAvailabilityRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Is fully qualified domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Is fully qualified domain name.",
        SerializedName = @"isFqdn",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsFqdn { get; set; }
        /// <summary>Resource name to verify.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Resource name to verify.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Resource type used for verification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Resource type used for verification.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CheckNameResourceTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CheckNameResourceTypes Type { get; set; }

    }
    /// Resource name availability request content.
    internal partial interface IResourceNameAvailabilityRequestInternal

    {
        /// <summary>Is fully qualified domain name.</summary>
        bool? IsFqdn { get; set; }
        /// <summary>Resource name to verify.</summary>
        string Name { get; set; }
        /// <summary>Resource type used for verification.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CheckNameResourceTypes Type { get; set; }

    }
}
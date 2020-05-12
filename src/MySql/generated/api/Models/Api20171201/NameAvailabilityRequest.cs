namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>Request from client to check resource name availability.</summary>
    public partial class NameAvailabilityRequest :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.INameAvailabilityRequest,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.INameAvailabilityRequestInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Resource name to verify.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Resource type used for verification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="NameAvailabilityRequest" /> instance.</summary>
        public NameAvailabilityRequest()
        {

        }
    }
    /// Request from client to check resource name availability.
    public partial interface INameAvailabilityRequest :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable
    {
        /// <summary>Resource name to verify.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Resource name to verify.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Resource type used for verification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource type used for verification.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// Request from client to check resource name availability.
    internal partial interface INameAvailabilityRequestInternal

    {
        /// <summary>Resource name to verify.</summary>
        string Name { get; set; }
        /// <summary>Resource type used for verification.</summary>
        string Type { get; set; }

    }
}
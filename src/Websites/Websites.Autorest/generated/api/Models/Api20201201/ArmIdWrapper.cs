namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>A wrapper for an ARM resource id</summary>
    public partial class ArmIdWrapper :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IArmIdWrapper,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IArmIdWrapperInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IArmIdWrapperInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Creates an new <see cref="ArmIdWrapper" /> instance.</summary>
        public ArmIdWrapper()
        {

        }
    }
    /// A wrapper for an ARM resource id
    public partial interface IArmIdWrapper :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }

    }
    /// A wrapper for an ARM resource id
    internal partial interface IArmIdWrapperInternal

    {
        string Id { get; set; }

    }
}
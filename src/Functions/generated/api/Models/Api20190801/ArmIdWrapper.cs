namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>A wrapper for an ARM resource id</summary>
    public partial class ArmIdWrapper :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IArmIdWrapper,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IArmIdWrapperInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IArmIdWrapperInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Creates an new <see cref="ArmIdWrapper" /> instance.</summary>
        public ArmIdWrapper()
        {

        }
    }
    /// A wrapper for an ARM resource id
    public partial interface IArmIdWrapper :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
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
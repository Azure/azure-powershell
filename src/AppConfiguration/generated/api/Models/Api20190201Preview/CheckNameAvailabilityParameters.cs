namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Extensions;

    /// <summary>Parameters used for checking whether a resource name is available.</summary>
    public partial class CheckNameAvailabilityParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.ICheckNameAvailabilityParameters,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.ICheckNameAvailabilityParametersInternal
    {

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.ICheckNameAvailabilityParametersInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name to check for availability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type= @"Microsoft.AppConfiguration/configurationStores";

        /// <summary>The resource type to check for name availability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="CheckNameAvailabilityParameters" /> instance.</summary>
        public CheckNameAvailabilityParameters()
        {

        }
    }
    /// Parameters used for checking whether a resource name is available.
    public partial interface ICheckNameAvailabilityParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>The name to check for availability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name to check for availability.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The resource type to check for name availability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Description = @"The resource type to check for name availability.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// Parameters used for checking whether a resource name is available.
    internal partial interface ICheckNameAvailabilityParametersInternal

    {
        /// <summary>The name to check for availability.</summary>
        string Name { get; set; }
        /// <summary>The resource type to check for name availability.</summary>
        string Type { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Specification for an App Service Environment to use for this resource.</summary>
    public partial class HostingEnvironmentProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfile,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource ID of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Resource type of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="HostingEnvironmentProfile" /> instance.</summary>
        public HostingEnvironmentProfile()
        {

        }
    }
    /// Specification for an App Service Environment to use for this resource.
    public partial interface IHostingEnvironmentProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Resource ID of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID of the App Service Environment.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>Name of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the App Service Environment.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>Resource type of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type of the App Service Environment.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// Specification for an App Service Environment to use for this resource.
    internal partial interface IHostingEnvironmentProfileInternal

    {
        /// <summary>Resource ID of the App Service Environment.</summary>
        string Id { get; set; }
        /// <summary>Name of the App Service Environment.</summary>
        string Name { get; set; }
        /// <summary>Resource type of the App Service Environment.</summary>
        string Type { get; set; }

    }
}
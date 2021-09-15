namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>The list of available versions for an agent pool.</summary>
    public partial class AgentPoolAvailableVersions :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersions,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsInternal
    {

        /// <summary>List of versions available for agent pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsPropertiesAgentPoolVersionsItem[] AgentPoolVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsPropertiesInternal)Property).AgentPoolVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsPropertiesInternal)Property).AgentPoolVersion = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Id of the agent pool available versions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsProperties Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.AgentPoolAvailableVersionsProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the agent pool available versions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsProperties _property;

        /// <summary>Properties of agent pool available versions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.AgentPoolAvailableVersionsProperties()); set => this._property = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of the agent pool available versions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="AgentPoolAvailableVersions" /> instance.</summary>
        public AgentPoolAvailableVersions()
        {

        }
    }
    /// The list of available versions for an agent pool.
    public partial interface IAgentPoolAvailableVersions :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>List of versions available for agent pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of versions available for agent pool.",
        SerializedName = @"agentPoolVersions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsPropertiesAgentPoolVersionsItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsPropertiesAgentPoolVersionsItem[] AgentPoolVersion { get; set; }
        /// <summary>Id of the agent pool available versions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Id of the agent pool available versions.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Name of the agent pool available versions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the agent pool available versions.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>Type of the agent pool available versions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Type of the agent pool  available versions.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// The list of available versions for an agent pool.
    internal partial interface IAgentPoolAvailableVersionsInternal

    {
        /// <summary>List of versions available for agent pool.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsPropertiesAgentPoolVersionsItem[] AgentPoolVersion { get; set; }
        /// <summary>Id of the agent pool available versions.</summary>
        string Id { get; set; }
        /// <summary>Name of the agent pool available versions.</summary>
        string Name { get; set; }
        /// <summary>Properties of agent pool available versions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsProperties Property { get; set; }
        /// <summary>Type of the agent pool available versions.</summary>
        string Type { get; set; }

    }
}
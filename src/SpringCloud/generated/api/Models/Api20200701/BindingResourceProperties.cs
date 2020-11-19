namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Binding resource properties payload</summary>
    public partial class BindingResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="BindingParameter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesBindingParameters _bindingParameter;

        /// <summary>Binding parameters of the Binding resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesBindingParameters BindingParameter { get => (this._bindingParameter = this._bindingParameter ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.BindingResourcePropertiesBindingParameters()); set => this._bindingParameter = value; }

        /// <summary>Backing field for <see cref="CreatedAt" /> property.</summary>
        private string _createdAt;

        /// <summary>Creation time of the Binding resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string CreatedAt { get => this._createdAt; }

        /// <summary>Backing field for <see cref="GeneratedProperty" /> property.</summary>
        private string _generatedProperty;

        /// <summary>
        /// The generated Spring Boot property file for this binding. The secret will be deducted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string GeneratedProperty { get => this._generatedProperty; }

        /// <summary>Backing field for <see cref="Key" /> property.</summary>
        private string _key;

        /// <summary>The key of the bound resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Key { get => this._key; set => this._key = value; }

        /// <summary>Internal Acessors for CreatedAt</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal.CreatedAt { get => this._createdAt; set { {_createdAt = value;} } }

        /// <summary>Internal Acessors for GeneratedProperty</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal.GeneratedProperty { get => this._generatedProperty; set { {_generatedProperty = value;} } }

        /// <summary>Internal Acessors for ResourceName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal.ResourceName { get => this._resourceName; set { {_resourceName = value;} } }

        /// <summary>Internal Acessors for ResourceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal.ResourceType { get => this._resourceType; set { {_resourceType = value;} } }

        /// <summary>Internal Acessors for UpdatedAt</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal.UpdatedAt { get => this._updatedAt; set { {_updatedAt = value;} } }

        /// <summary>Backing field for <see cref="ResourceId" /> property.</summary>
        private string _resourceId;

        /// <summary>The Azure resource id of the bound resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string ResourceId { get => this._resourceId; set => this._resourceId = value; }

        /// <summary>Backing field for <see cref="ResourceName" /> property.</summary>
        private string _resourceName;

        /// <summary>The name of the bound resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string ResourceName { get => this._resourceName; }

        /// <summary>Backing field for <see cref="ResourceType" /> property.</summary>
        private string _resourceType;

        /// <summary>The standard Azure resource type of the bound resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string ResourceType { get => this._resourceType; }

        /// <summary>Backing field for <see cref="UpdatedAt" /> property.</summary>
        private string _updatedAt;

        /// <summary>Update time of the Binding resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string UpdatedAt { get => this._updatedAt; }

        /// <summary>Creates an new <see cref="BindingResourceProperties" /> instance.</summary>
        public BindingResourceProperties()
        {

        }
    }
    /// Binding resource properties payload
    public partial interface IBindingResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>Binding parameters of the Binding resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Binding parameters of the Binding resource",
        SerializedName = @"bindingParameters",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesBindingParameters) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesBindingParameters BindingParameter { get; set; }
        /// <summary>Creation time of the Binding resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Creation time of the Binding resource",
        SerializedName = @"createdAt",
        PossibleTypes = new [] { typeof(string) })]
        string CreatedAt { get;  }
        /// <summary>
        /// The generated Spring Boot property file for this binding. The secret will be deducted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The generated Spring Boot property file for this binding. The secret will be deducted.",
        SerializedName = @"generatedProperties",
        PossibleTypes = new [] { typeof(string) })]
        string GeneratedProperty { get;  }
        /// <summary>The key of the bound resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The key of the bound resource",
        SerializedName = @"key",
        PossibleTypes = new [] { typeof(string) })]
        string Key { get; set; }
        /// <summary>The Azure resource id of the bound resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Azure resource id of the bound resource",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceId { get; set; }
        /// <summary>The name of the bound resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the bound resource",
        SerializedName = @"resourceName",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceName { get;  }
        /// <summary>The standard Azure resource type of the bound resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The standard Azure resource type of the bound resource",
        SerializedName = @"resourceType",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceType { get;  }
        /// <summary>Update time of the Binding resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Update time of the Binding resource",
        SerializedName = @"updatedAt",
        PossibleTypes = new [] { typeof(string) })]
        string UpdatedAt { get;  }

    }
    /// Binding resource properties payload
    public partial interface IBindingResourcePropertiesInternal

    {
        /// <summary>Binding parameters of the Binding resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesBindingParameters BindingParameter { get; set; }
        /// <summary>Creation time of the Binding resource</summary>
        string CreatedAt { get; set; }
        /// <summary>
        /// The generated Spring Boot property file for this binding. The secret will be deducted.
        /// </summary>
        string GeneratedProperty { get; set; }
        /// <summary>The key of the bound resource</summary>
        string Key { get; set; }
        /// <summary>The Azure resource id of the bound resource</summary>
        string ResourceId { get; set; }
        /// <summary>The name of the bound resource</summary>
        string ResourceName { get; set; }
        /// <summary>The standard Azure resource type of the bound resource</summary>
        string ResourceType { get; set; }
        /// <summary>Update time of the Binding resource</summary>
        string UpdatedAt { get; set; }

    }
}
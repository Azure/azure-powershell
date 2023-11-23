namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>Detailed HANA operation information</summary>
    public partial class Display :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplay,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>
        /// The localized friendly description for the operation as shown to the user. This description should be thorough, yet concise.
        /// It will be used in tool-tips and detailed views.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Description { get => this._description; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal.Description { get => this._description; set { {_description = value;} } }

        /// <summary>Internal Acessors for Operation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal.Operation { get => this._operation; set { {_operation = value;} } }

        /// <summary>Internal Acessors for Origin</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal.Origin { get => this._origin; set { {_origin = value;} } }

        /// <summary>Internal Acessors for Provider</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal.Provider { get => this._provider; set { {_provider = value;} } }

        /// <summary>Internal Acessors for Resource</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal.Resource { get => this._resource; set { {_resource = value;} } }

        /// <summary>Backing field for <see cref="Operation" /> property.</summary>
        private string _operation;

        /// <summary>
        /// The localized friendly name for the operation as shown to the user. This name should be concise (to fit in drop downs),
        /// but clear (self-documenting). Use Title Casing and include the entity/resource to which it applies.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Operation { get => this._operation; }

        /// <summary>Backing field for <see cref="Origin" /> property.</summary>
        private string _origin;

        /// <summary>
        /// The intended executor of the operation; governs the display of the operation in the RBAC UX and the audit logs UX. Default
        /// value is 'user,system'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Origin { get => this._origin; }

        /// <summary>Backing field for <see cref="Provider" /> property.</summary>
        private string _provider;

        /// <summary>
        /// The localized friendly form of the resource provider name. This form is also expected to include the publisher/company
        /// responsible. Use Title Casing. Begin with "Microsoft" for 1st party services.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Provider { get => this._provider; }

        /// <summary>Backing field for <see cref="Resource" /> property.</summary>
        private string _resource;

        /// <summary>
        /// The localized friendly form of the resource type related to this action/operation. This form should match the public documentation
        /// for the resource provider. Use Title Casing. For examples, refer to the “name” section.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Resource { get => this._resource; }

        /// <summary>Creates an new <see cref="Display" /> instance.</summary>
        public Display()
        {

        }
    }
    /// Detailed HANA operation information
    public partial interface IDisplay :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The localized friendly description for the operation as shown to the user. This description should be thorough, yet concise.
        /// It will be used in tool-tips and detailed views.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The localized friendly description for the operation as shown to the user. This description should be thorough, yet concise. It will be used in tool-tips and detailed views.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }
        /// <summary>
        /// The localized friendly name for the operation as shown to the user. This name should be concise (to fit in drop downs),
        /// but clear (self-documenting). Use Title Casing and include the entity/resource to which it applies.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The localized friendly name for the operation as shown to the user. This name should be concise (to fit in drop downs), but clear (self-documenting). Use Title Casing and include the entity/resource to which it applies.",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string Operation { get;  }
        /// <summary>
        /// The intended executor of the operation; governs the display of the operation in the RBAC UX and the audit logs UX. Default
        /// value is 'user,system'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The intended executor of the operation; governs the display of the operation in the RBAC UX and the audit logs UX. Default value is 'user,system'",
        SerializedName = @"origin",
        PossibleTypes = new [] { typeof(string) })]
        string Origin { get;  }
        /// <summary>
        /// The localized friendly form of the resource provider name. This form is also expected to include the publisher/company
        /// responsible. Use Title Casing. Begin with "Microsoft" for 1st party services.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The localized friendly form of the resource provider name. This form is also expected to include the publisher/company responsible. Use Title Casing. Begin with ""Microsoft"" for 1st party services.",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string Provider { get;  }
        /// <summary>
        /// The localized friendly form of the resource type related to this action/operation. This form should match the public documentation
        /// for the resource provider. Use Title Casing. For examples, refer to the “name” section.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The localized friendly form of the resource type related to this action/operation. This form should match the public documentation for the resource provider. Use Title Casing. For examples, refer to the “name” section.",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string Resource { get;  }

    }
    /// Detailed HANA operation information
    internal partial interface IDisplayInternal

    {
        /// <summary>
        /// The localized friendly description for the operation as shown to the user. This description should be thorough, yet concise.
        /// It will be used in tool-tips and detailed views.
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// The localized friendly name for the operation as shown to the user. This name should be concise (to fit in drop downs),
        /// but clear (self-documenting). Use Title Casing and include the entity/resource to which it applies.
        /// </summary>
        string Operation { get; set; }
        /// <summary>
        /// The intended executor of the operation; governs the display of the operation in the RBAC UX and the audit logs UX. Default
        /// value is 'user,system'
        /// </summary>
        string Origin { get; set; }
        /// <summary>
        /// The localized friendly form of the resource provider name. This form is also expected to include the publisher/company
        /// responsible. Use Title Casing. Begin with "Microsoft" for 1st party services.
        /// </summary>
        string Provider { get; set; }
        /// <summary>
        /// The localized friendly form of the resource type related to this action/operation. This form should match the public documentation
        /// for the resource provider. Use Title Casing. For examples, refer to the “name” section.
        /// </summary>
        string Resource { get; set; }

    }
}
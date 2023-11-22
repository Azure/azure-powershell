namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>HANA operation information</summary>
    public partial class Operation :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IOperation,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IOperationInternal
    {

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplay _display;

        /// <summary>Displayed HANA operation information</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplay Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.Display()); set => this._display = value; }

        /// <summary>
        /// The localized friendly description for the operation as shown to the user. This description should be thorough, yet concise.
        /// It will be used in tool-tips and detailed views.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal)Display).Description; }

        /// <summary>
        /// The localized friendly name for the operation as shown to the user. This name should be concise (to fit in drop downs),
        /// but clear (self-documenting). Use Title Casing and include the entity/resource to which it applies.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal)Display).Operation; }

        /// <summary>
        /// The intended executor of the operation; governs the display of the operation in the RBAC UX and the audit logs UX. Default
        /// value is 'user,system'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public string DisplayOrigin { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal)Display).Origin; }

        /// <summary>
        /// The localized friendly form of the resource provider name. This form is also expected to include the publisher/company
        /// responsible. Use Title Casing. Begin with "Microsoft" for 1st party services.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal)Display).Provider; }

        /// <summary>
        /// The localized friendly form of the resource type related to this action/operation. This form should match the public documentation
        /// for the resource provider. Use Title Casing. For examples, refer to the “name” section.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal)Display).Resource; }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplay Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IOperationInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.Display()); set { {_display = value;} } }

        /// <summary>Internal Acessors for DisplayDescription</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IOperationInternal.DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal)Display).Description = value; }

        /// <summary>Internal Acessors for DisplayOperation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IOperationInternal.DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal)Display).Operation = value; }

        /// <summary>Internal Acessors for DisplayOrigin</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IOperationInternal.DisplayOrigin { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal)Display).Origin; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal)Display).Origin = value; }

        /// <summary>Internal Acessors for DisplayProvider</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IOperationInternal.DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal)Display).Provider = value; }

        /// <summary>Internal Acessors for DisplayResource</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IOperationInternal.DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplayInternal)Display).Resource = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IOperationInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// The name of the operation being performed on this particular object. This name should match the action name that appears
        /// in RBAC / the event service.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Creates an new <see cref="Operation" /> instance.</summary>
        public Operation()
        {

        }
    }
    /// HANA operation information
    public partial interface IOperation :
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
        string DisplayDescription { get;  }
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
        string DisplayOperation { get;  }
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
        string DisplayOrigin { get;  }
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
        string DisplayProvider { get;  }
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
        string DisplayResource { get;  }
        /// <summary>
        /// The name of the operation being performed on this particular object. This name should match the action name that appears
        /// in RBAC / the event service.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the operation being performed on this particular object. This name should match the action name that appears in RBAC / the event service.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }

    }
    /// HANA operation information
    internal partial interface IOperationInternal

    {
        /// <summary>Displayed HANA operation information</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IDisplay Display { get; set; }
        /// <summary>
        /// The localized friendly description for the operation as shown to the user. This description should be thorough, yet concise.
        /// It will be used in tool-tips and detailed views.
        /// </summary>
        string DisplayDescription { get; set; }
        /// <summary>
        /// The localized friendly name for the operation as shown to the user. This name should be concise (to fit in drop downs),
        /// but clear (self-documenting). Use Title Casing and include the entity/resource to which it applies.
        /// </summary>
        string DisplayOperation { get; set; }
        /// <summary>
        /// The intended executor of the operation; governs the display of the operation in the RBAC UX and the audit logs UX. Default
        /// value is 'user,system'
        /// </summary>
        string DisplayOrigin { get; set; }
        /// <summary>
        /// The localized friendly form of the resource provider name. This form is also expected to include the publisher/company
        /// responsible. Use Title Casing. Begin with "Microsoft" for 1st party services.
        /// </summary>
        string DisplayProvider { get; set; }
        /// <summary>
        /// The localized friendly form of the resource type related to this action/operation. This form should match the public documentation
        /// for the resource provider. Use Title Casing. For examples, refer to the “name” section.
        /// </summary>
        string DisplayResource { get; set; }
        /// <summary>
        /// The name of the operation being performed on this particular object. This name should match the action name that appears
        /// in RBAC / the event service.
        /// </summary>
        string Name { get; set; }

    }
}
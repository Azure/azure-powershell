namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>HostPool properties that can be patched.</summary>
    public partial class HostPoolPatch :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatch,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.Resource();

        /// <summary>Custom rdp property of HostPool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string CustomRdpProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).CustomRdpProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).CustomRdpProperty = value; }

        /// <summary>Description of HostPool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).Description = value; }

        /// <summary>Friendly name of HostPool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string FriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).FriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).FriendlyName = value; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal)__resource).Id; }

        /// <summary>The type of the load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.LoadBalancerType? LoadBalancerType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).LoadBalancerType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).LoadBalancerType = value; }

        /// <summary>The max session limit of HostPool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public int? MaxSessionLimit { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).MaxSessionLimit; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).MaxSessionLimit = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal)__resource).Type = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchProperties Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.HostPoolPatchProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for RegistrationInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IRegistrationInfoPatch Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchInternal.RegistrationInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).RegistrationInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).RegistrationInfo = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal)__resource).Name; }

        /// <summary>PersonalDesktopAssignment type for HostPool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.PersonalDesktopAssignmentType? PersonalDesktopAssignmentType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).PersonalDesktopAssignmentType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).PersonalDesktopAssignmentType = value; }

        /// <summary>
        /// The type of preferred application group type, default to Desktop Application Group
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.PreferredAppGroupType? PreferredAppGroupType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).PreferredAppGroupType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).PreferredAppGroupType = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchProperties _property;

        /// <summary>HostPool properties that can be patched.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.HostPoolPatchProperties()); set => this._property = value; }

        /// <summary>Expiration time of registration token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public global::System.DateTime? RegistrationInfoExpirationTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).RegistrationInfoExpirationTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).RegistrationInfoExpirationTime = value; }

        /// <summary>The type of resetting the token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.RegistrationTokenOperation? RegistrationInfoRegistrationTokenOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).RegistrationInfoRegistrationTokenOperation; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).RegistrationInfoRegistrationTokenOperation = value; }

        /// <summary>The ring number of HostPool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public int? Ring { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).Ring; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).Ring = value; }

        /// <summary>ClientId for the registered Relying Party used to issue WVD SSO certificates.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string SsoClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).SsoClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).SsoClientId = value; }

        /// <summary>Path to Azure KeyVault storing the secret used for communication to ADFS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string SsoClientSecretKeyVaultPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).SsoClientSecretKeyVaultPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).SsoClientSecretKeyVaultPath = value; }

        /// <summary>Path to keyvault containing ssoContext secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string SsoContext { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).SsoContext; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).SsoContext = value; }

        /// <summary>The type of single sign on Secret Type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SsoSecretType? SsoSecretType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).SsoSecretType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).SsoSecretType = value; }

        /// <summary>URL to customer ADFS server for signing WVD SSO certificates.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string SsoadfsAuthority { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).SsoadfsAuthority; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).SsoadfsAuthority = value; }

        /// <summary>The flag to turn on/off StartVMOnConnect feature.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public bool? StartVMOnConnect { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).StartVMOnConnect; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).StartVMOnConnect = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchTags _tag;

        /// <summary>tags to be updated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.HostPoolPatchTags()); set => this._tag = value; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal)__resource).Type; }

        /// <summary>VM template for sessionhosts configuration within hostpool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string VMTemplate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).VMTemplate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).VMTemplate = value; }

        /// <summary>Is validation environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public bool? ValidationEnvironment { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).ValidationEnvironment; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchPropertiesInternal)Property).ValidationEnvironment = value; }

        /// <summary>Creates an new <see cref="HostPoolPatch" /> instance.</summary>
        public HostPoolPatch()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// HostPool properties that can be patched.
    public partial interface IHostPoolPatch :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResource
    {
        /// <summary>Custom rdp property of HostPool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Custom rdp property of HostPool.",
        SerializedName = @"customRdpProperty",
        PossibleTypes = new [] { typeof(string) })]
        string CustomRdpProperty { get; set; }
        /// <summary>Description of HostPool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of HostPool.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>Friendly name of HostPool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Friendly name of HostPool.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>The type of the load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of the load balancer.",
        SerializedName = @"loadBalancerType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.LoadBalancerType) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.LoadBalancerType? LoadBalancerType { get; set; }
        /// <summary>The max session limit of HostPool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The max session limit of HostPool.",
        SerializedName = @"maxSessionLimit",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxSessionLimit { get; set; }
        /// <summary>PersonalDesktopAssignment type for HostPool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"PersonalDesktopAssignment type for HostPool.",
        SerializedName = @"personalDesktopAssignmentType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.PersonalDesktopAssignmentType) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.PersonalDesktopAssignmentType? PersonalDesktopAssignmentType { get; set; }
        /// <summary>
        /// The type of preferred application group type, default to Desktop Application Group
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of preferred application group type, default to Desktop Application Group",
        SerializedName = @"preferredAppGroupType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.PreferredAppGroupType) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.PreferredAppGroupType? PreferredAppGroupType { get; set; }
        /// <summary>Expiration time of registration token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Expiration time of registration token.",
        SerializedName = @"expirationTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RegistrationInfoExpirationTime { get; set; }
        /// <summary>The type of resetting the token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of resetting the token.",
        SerializedName = @"registrationTokenOperation",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.RegistrationTokenOperation) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.RegistrationTokenOperation? RegistrationInfoRegistrationTokenOperation { get; set; }
        /// <summary>The ring number of HostPool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ring number of HostPool.",
        SerializedName = @"ring",
        PossibleTypes = new [] { typeof(int) })]
        int? Ring { get; set; }
        /// <summary>ClientId for the registered Relying Party used to issue WVD SSO certificates.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ClientId for the registered Relying Party used to issue WVD SSO certificates.",
        SerializedName = @"ssoClientId",
        PossibleTypes = new [] { typeof(string) })]
        string SsoClientId { get; set; }
        /// <summary>Path to Azure KeyVault storing the secret used for communication to ADFS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Path to Azure KeyVault storing the secret used for communication to ADFS.",
        SerializedName = @"ssoClientSecretKeyVaultPath",
        PossibleTypes = new [] { typeof(string) })]
        string SsoClientSecretKeyVaultPath { get; set; }
        /// <summary>Path to keyvault containing ssoContext secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Path to keyvault containing ssoContext secret.",
        SerializedName = @"ssoContext",
        PossibleTypes = new [] { typeof(string) })]
        string SsoContext { get; set; }
        /// <summary>The type of single sign on Secret Type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of single sign on Secret Type.",
        SerializedName = @"ssoSecretType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SsoSecretType) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SsoSecretType? SsoSecretType { get; set; }
        /// <summary>URL to customer ADFS server for signing WVD SSO certificates.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL to customer ADFS server for signing WVD SSO certificates.",
        SerializedName = @"ssoadfsAuthority",
        PossibleTypes = new [] { typeof(string) })]
        string SsoadfsAuthority { get; set; }
        /// <summary>The flag to turn on/off StartVMOnConnect feature.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The flag to turn on/off StartVMOnConnect feature.",
        SerializedName = @"startVMOnConnect",
        PossibleTypes = new [] { typeof(bool) })]
        bool? StartVMOnConnect { get; set; }
        /// <summary>tags to be updated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"tags to be updated",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchTags Tag { get; set; }
        /// <summary>VM template for sessionhosts configuration within hostpool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VM template for sessionhosts configuration within hostpool.",
        SerializedName = @"vmTemplate",
        PossibleTypes = new [] { typeof(string) })]
        string VMTemplate { get; set; }
        /// <summary>Is validation environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Is validation environment.",
        SerializedName = @"validationEnvironment",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ValidationEnvironment { get; set; }

    }
    /// HostPool properties that can be patched.
    internal partial interface IHostPoolPatchInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal
    {
        /// <summary>Custom rdp property of HostPool.</summary>
        string CustomRdpProperty { get; set; }
        /// <summary>Description of HostPool.</summary>
        string Description { get; set; }
        /// <summary>Friendly name of HostPool.</summary>
        string FriendlyName { get; set; }
        /// <summary>The type of the load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.LoadBalancerType? LoadBalancerType { get; set; }
        /// <summary>The max session limit of HostPool.</summary>
        int? MaxSessionLimit { get; set; }
        /// <summary>PersonalDesktopAssignment type for HostPool.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.PersonalDesktopAssignmentType? PersonalDesktopAssignmentType { get; set; }
        /// <summary>
        /// The type of preferred application group type, default to Desktop Application Group
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.PreferredAppGroupType? PreferredAppGroupType { get; set; }
        /// <summary>HostPool properties that can be patched.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchProperties Property { get; set; }
        /// <summary>The registration info of HostPool.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IRegistrationInfoPatch RegistrationInfo { get; set; }
        /// <summary>Expiration time of registration token.</summary>
        global::System.DateTime? RegistrationInfoExpirationTime { get; set; }
        /// <summary>The type of resetting the token.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.RegistrationTokenOperation? RegistrationInfoRegistrationTokenOperation { get; set; }
        /// <summary>The ring number of HostPool.</summary>
        int? Ring { get; set; }
        /// <summary>ClientId for the registered Relying Party used to issue WVD SSO certificates.</summary>
        string SsoClientId { get; set; }
        /// <summary>Path to Azure KeyVault storing the secret used for communication to ADFS.</summary>
        string SsoClientSecretKeyVaultPath { get; set; }
        /// <summary>Path to keyvault containing ssoContext secret.</summary>
        string SsoContext { get; set; }
        /// <summary>The type of single sign on Secret Type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SsoSecretType? SsoSecretType { get; set; }
        /// <summary>URL to customer ADFS server for signing WVD SSO certificates.</summary>
        string SsoadfsAuthority { get; set; }
        /// <summary>The flag to turn on/off StartVMOnConnect feature.</summary>
        bool? StartVMOnConnect { get; set; }
        /// <summary>tags to be updated</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchTags Tag { get; set; }
        /// <summary>VM template for sessionhosts configuration within hostpool.</summary>
        string VMTemplate { get; set; }
        /// <summary>Is validation environment.</summary>
        bool? ValidationEnvironment { get; set; }

    }
}
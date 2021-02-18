namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>User credentials used for publishing activity.</summary>
    public partial class User :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUser,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.UserProperties()); set { {_property = value;} } }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserProperties _property;

        /// <summary>User resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.UserProperties()); set => this._property = value; }

        /// <summary>Password used for publishing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PublishingPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)Property).PublishingPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)Property).PublishingPassword = value; }

        /// <summary>Password hash used for publishing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PublishingPasswordHash { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)Property).PublishingPasswordHash; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)Property).PublishingPasswordHash = value; }

        /// <summary>Password hash salt used for publishing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PublishingPasswordHashSalt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)Property).PublishingPasswordHashSalt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)Property).PublishingPasswordHashSalt = value; }

        /// <summary>Username used for publishing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PublishingUserName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)Property).PublishingUserName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)Property).PublishingUserName = value; }

        /// <summary>Url of SCM site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ScmUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)Property).ScmUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)Property).ScmUri = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="User" /> instance.</summary>
        public User()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// User credentials used for publishing activity.
    public partial interface IUser :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>Password used for publishing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Password used for publishing.",
        SerializedName = @"publishingPassword",
        PossibleTypes = new [] { typeof(string) })]
        string PublishingPassword { get; set; }
        /// <summary>Password hash used for publishing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Password hash used for publishing.",
        SerializedName = @"publishingPasswordHash",
        PossibleTypes = new [] { typeof(string) })]
        string PublishingPasswordHash { get; set; }
        /// <summary>Password hash salt used for publishing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Password hash salt used for publishing.",
        SerializedName = @"publishingPasswordHashSalt",
        PossibleTypes = new [] { typeof(string) })]
        string PublishingPasswordHashSalt { get; set; }
        /// <summary>Username used for publishing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Username used for publishing.",
        SerializedName = @"publishingUserName",
        PossibleTypes = new [] { typeof(string) })]
        string PublishingUserName { get; set; }
        /// <summary>Url of SCM site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Url of SCM site.",
        SerializedName = @"scmUri",
        PossibleTypes = new [] { typeof(string) })]
        string ScmUri { get; set; }

    }
    /// User credentials used for publishing activity.
    internal partial interface IUserInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>User resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserProperties Property { get; set; }
        /// <summary>Password used for publishing.</summary>
        string PublishingPassword { get; set; }
        /// <summary>Password hash used for publishing.</summary>
        string PublishingPasswordHash { get; set; }
        /// <summary>Password hash salt used for publishing.</summary>
        string PublishingPasswordHashSalt { get; set; }
        /// <summary>Username used for publishing.</summary>
        string PublishingUserName { get; set; }
        /// <summary>Url of SCM site.</summary>
        string ScmUri { get; set; }

    }
}
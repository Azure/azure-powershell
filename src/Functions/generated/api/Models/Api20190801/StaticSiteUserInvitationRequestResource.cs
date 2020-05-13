namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Static sites user roles invitation resource.</summary>
    public partial class StaticSiteUserInvitationRequestResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationRequestResource,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationRequestResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>The domain name for the static site custom domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Domain { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationRequestResourcePropertiesInternal)Property).Domain; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationRequestResourcePropertiesInternal)Property).Domain = value; }

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
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationRequestResourceProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationRequestResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StaticSiteUserInvitationRequestResourceProperties()); set { {_property = value;} } }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>The number of hours the sas token stays valid</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? NumHoursToExpiration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationRequestResourcePropertiesInternal)Property).NumHoursToExpiration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationRequestResourcePropertiesInternal)Property).NumHoursToExpiration = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationRequestResourceProperties _property;

        /// <summary>StaticSiteUserInvitationRequestResource resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationRequestResourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StaticSiteUserInvitationRequestResourceProperties()); set => this._property = value; }

        /// <summary>The identity provider for the static site user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Provider { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationRequestResourcePropertiesInternal)Property).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationRequestResourcePropertiesInternal)Property).Provider = value; }

        /// <summary>The roles for the static site user, in free-form string format</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Role { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationRequestResourcePropertiesInternal)Property).Role; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationRequestResourcePropertiesInternal)Property).Role = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>The user id for the static site user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string UserDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationRequestResourcePropertiesInternal)Property).UserDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationRequestResourcePropertiesInternal)Property).UserDetail = value; }

        /// <summary>Creates an new <see cref="StaticSiteUserInvitationRequestResource" /> instance.</summary>
        public StaticSiteUserInvitationRequestResource()
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
    /// Static sites user roles invitation resource.
    public partial interface IStaticSiteUserInvitationRequestResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>The domain name for the static site custom domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The domain name for the static site custom domain.",
        SerializedName = @"domain",
        PossibleTypes = new [] { typeof(string) })]
        string Domain { get; set; }
        /// <summary>The number of hours the sas token stays valid</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of hours the sas token stays valid",
        SerializedName = @"numHoursToExpiration",
        PossibleTypes = new [] { typeof(int) })]
        int? NumHoursToExpiration { get; set; }
        /// <summary>The identity provider for the static site user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identity provider for the static site user.",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string Provider { get; set; }
        /// <summary>The roles for the static site user, in free-form string format</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The roles for the static site user, in free-form string format",
        SerializedName = @"roles",
        PossibleTypes = new [] { typeof(string) })]
        string Role { get; set; }
        /// <summary>The user id for the static site user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The user id for the static site user.",
        SerializedName = @"userDetails",
        PossibleTypes = new [] { typeof(string) })]
        string UserDetail { get; set; }

    }
    /// Static sites user roles invitation resource.
    internal partial interface IStaticSiteUserInvitationRequestResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>The domain name for the static site custom domain.</summary>
        string Domain { get; set; }
        /// <summary>The number of hours the sas token stays valid</summary>
        int? NumHoursToExpiration { get; set; }
        /// <summary>StaticSiteUserInvitationRequestResource resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationRequestResourceProperties Property { get; set; }
        /// <summary>The identity provider for the static site user.</summary>
        string Provider { get; set; }
        /// <summary>The roles for the static site user, in free-form string format</summary>
        string Role { get; set; }
        /// <summary>The user id for the static site user.</summary>
        string UserDetail { get; set; }

    }
}
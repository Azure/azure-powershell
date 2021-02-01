namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.PowerShell;

    /// <summary>Request parameters for updating a new application.</summary>
    [System.ComponentModel.TypeConverter(typeof(ApplicationUpdateParametersTypeConverter))]
    public partial class ApplicationUpdateParameters
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ApplicationUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ApplicationUpdateParameters(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationUpdateParametersInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationUpdateParametersInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationUpdateParametersInternal)this).IdentifierUri = (string[]) content.GetValueForProperty("IdentifierUri",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationUpdateParametersInternal)this).IdentifierUri, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).OptionalClaimAccessToken = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[]) content.GetValueForProperty("OptionalClaimAccessToken",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).OptionalClaimAccessToken, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OptionalClaimTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).OptionalClaimIdToken = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[]) content.GetValueForProperty("OptionalClaimIdToken",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).OptionalClaimIdToken, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OptionalClaimTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).OptionalClaimSamlToken = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[]) content.GetValueForProperty("OptionalClaimSamlToken",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).OptionalClaimSamlToken, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OptionalClaimTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).InformationalUrlMarketing = (string) content.GetValueForProperty("InformationalUrlMarketing",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).InformationalUrlMarketing, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).InformationalUrlPrivacy = (string) content.GetValueForProperty("InformationalUrlPrivacy",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).InformationalUrlPrivacy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).InformationalUrlSupport = (string) content.GetValueForProperty("InformationalUrlSupport",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).InformationalUrlSupport, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).InformationalUrlTermsOfService = (string) content.GetValueForProperty("InformationalUrlTermsOfService",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).InformationalUrlTermsOfService, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).InformationalUrl = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IInformationalUrl) content.GetValueForProperty("InformationalUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).InformationalUrl, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.InformationalUrlTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).OptionalClaim = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaims) content.GetValueForProperty("OptionalClaim",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).OptionalClaim, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OptionalClaimsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AllowGuestsSignIn = (bool?) content.GetValueForProperty("AllowGuestsSignIn",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AllowGuestsSignIn, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AllowPassthroughUser = (bool?) content.GetValueForProperty("AllowPassthroughUser",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AllowPassthroughUser, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AppLogoUrl = (string) content.GetValueForProperty("AppLogoUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AppLogoUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AppPermission = (string[]) content.GetValueForProperty("AppPermission",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AppPermission, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AppRole = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole[]) content.GetValueForProperty("AppRole",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AppRole, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.AppRoleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AvailableToOtherTenant = (bool?) content.GetValueForProperty("AvailableToOtherTenant",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AvailableToOtherTenant, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).ErrorUrl = (string) content.GetValueForProperty("ErrorUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).ErrorUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).GroupMembershipClaim = (Microsoft.Azure.PowerShell.Cmdlets.AD.Support.GroupMembershipClaimTypes?) content.GetValueForProperty("GroupMembershipClaim",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).GroupMembershipClaim, Microsoft.Azure.PowerShell.Cmdlets.AD.Support.GroupMembershipClaimTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).Homepage = (string) content.GetValueForProperty("Homepage",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).Homepage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).IsDeviceOnlyAuthSupported = (bool?) content.GetValueForProperty("IsDeviceOnlyAuthSupported",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).IsDeviceOnlyAuthSupported, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).KeyCredentials = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[]) content.GetValueForProperty("KeyCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).KeyCredentials, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.KeyCredentialTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).KnownClientApplication = (string[]) content.GetValueForProperty("KnownClientApplication",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).KnownClientApplication, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).LogoutUrl = (string) content.GetValueForProperty("LogoutUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).LogoutUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).Oauth2AllowImplicitFlow = (bool?) content.GetValueForProperty("Oauth2AllowImplicitFlow",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).Oauth2AllowImplicitFlow, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).Oauth2AllowUrlPathMatching = (bool?) content.GetValueForProperty("Oauth2AllowUrlPathMatching",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).Oauth2AllowUrlPathMatching, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).Oauth2Permission = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission[]) content.GetValueForProperty("Oauth2Permission",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).Oauth2Permission, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OAuth2PermissionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).Oauth2RequirePostResponse = (bool?) content.GetValueForProperty("Oauth2RequirePostResponse",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).Oauth2RequirePostResponse, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).OrgRestriction = (string[]) content.GetValueForProperty("OrgRestriction",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).OrgRestriction, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).PasswordCredentials = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[]) content.GetValueForProperty("PasswordCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).PasswordCredentials, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.PasswordCredentialTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).PreAuthorizedApplication = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplication[]) content.GetValueForProperty("PreAuthorizedApplication",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).PreAuthorizedApplication, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplication>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.PreAuthorizedApplicationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).PublicClient = (bool?) content.GetValueForProperty("PublicClient",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).PublicClient, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).PublisherDomain = (string) content.GetValueForProperty("PublisherDomain",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).PublisherDomain, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).ReplyUrl = (string[]) content.GetValueForProperty("ReplyUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).ReplyUrl, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).RequiredResourceAccess = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess[]) content.GetValueForProperty("RequiredResourceAccess",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).RequiredResourceAccess, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.RequiredResourceAccessTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).SamlMetadataUrl = (string) content.GetValueForProperty("SamlMetadataUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).SamlMetadataUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).SignInAudience = (string) content.GetValueForProperty("SignInAudience",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).SignInAudience, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).WwwHomepage = (string) content.GetValueForProperty("WwwHomepage",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).WwwHomepage, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ApplicationUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ApplicationUpdateParameters(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationUpdateParametersInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationUpdateParametersInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationUpdateParametersInternal)this).IdentifierUri = (string[]) content.GetValueForProperty("IdentifierUri",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationUpdateParametersInternal)this).IdentifierUri, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).OptionalClaimAccessToken = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[]) content.GetValueForProperty("OptionalClaimAccessToken",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).OptionalClaimAccessToken, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OptionalClaimTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).OptionalClaimIdToken = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[]) content.GetValueForProperty("OptionalClaimIdToken",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).OptionalClaimIdToken, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OptionalClaimTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).OptionalClaimSamlToken = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[]) content.GetValueForProperty("OptionalClaimSamlToken",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).OptionalClaimSamlToken, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OptionalClaimTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).InformationalUrlMarketing = (string) content.GetValueForProperty("InformationalUrlMarketing",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).InformationalUrlMarketing, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).InformationalUrlPrivacy = (string) content.GetValueForProperty("InformationalUrlPrivacy",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).InformationalUrlPrivacy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).InformationalUrlSupport = (string) content.GetValueForProperty("InformationalUrlSupport",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).InformationalUrlSupport, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).InformationalUrlTermsOfService = (string) content.GetValueForProperty("InformationalUrlTermsOfService",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).InformationalUrlTermsOfService, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).InformationalUrl = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IInformationalUrl) content.GetValueForProperty("InformationalUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).InformationalUrl, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.InformationalUrlTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).OptionalClaim = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaims) content.GetValueForProperty("OptionalClaim",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).OptionalClaim, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OptionalClaimsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AllowGuestsSignIn = (bool?) content.GetValueForProperty("AllowGuestsSignIn",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AllowGuestsSignIn, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AllowPassthroughUser = (bool?) content.GetValueForProperty("AllowPassthroughUser",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AllowPassthroughUser, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AppLogoUrl = (string) content.GetValueForProperty("AppLogoUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AppLogoUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AppPermission = (string[]) content.GetValueForProperty("AppPermission",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AppPermission, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AppRole = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole[]) content.GetValueForProperty("AppRole",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AppRole, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.AppRoleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AvailableToOtherTenant = (bool?) content.GetValueForProperty("AvailableToOtherTenant",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).AvailableToOtherTenant, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).ErrorUrl = (string) content.GetValueForProperty("ErrorUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).ErrorUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).GroupMembershipClaim = (Microsoft.Azure.PowerShell.Cmdlets.AD.Support.GroupMembershipClaimTypes?) content.GetValueForProperty("GroupMembershipClaim",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).GroupMembershipClaim, Microsoft.Azure.PowerShell.Cmdlets.AD.Support.GroupMembershipClaimTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).Homepage = (string) content.GetValueForProperty("Homepage",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).Homepage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).IsDeviceOnlyAuthSupported = (bool?) content.GetValueForProperty("IsDeviceOnlyAuthSupported",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).IsDeviceOnlyAuthSupported, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).KeyCredentials = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[]) content.GetValueForProperty("KeyCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).KeyCredentials, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.KeyCredentialTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).KnownClientApplication = (string[]) content.GetValueForProperty("KnownClientApplication",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).KnownClientApplication, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).LogoutUrl = (string) content.GetValueForProperty("LogoutUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).LogoutUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).Oauth2AllowImplicitFlow = (bool?) content.GetValueForProperty("Oauth2AllowImplicitFlow",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).Oauth2AllowImplicitFlow, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).Oauth2AllowUrlPathMatching = (bool?) content.GetValueForProperty("Oauth2AllowUrlPathMatching",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).Oauth2AllowUrlPathMatching, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).Oauth2Permission = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission[]) content.GetValueForProperty("Oauth2Permission",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).Oauth2Permission, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OAuth2PermissionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).Oauth2RequirePostResponse = (bool?) content.GetValueForProperty("Oauth2RequirePostResponse",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).Oauth2RequirePostResponse, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).OrgRestriction = (string[]) content.GetValueForProperty("OrgRestriction",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).OrgRestriction, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).PasswordCredentials = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[]) content.GetValueForProperty("PasswordCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).PasswordCredentials, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.PasswordCredentialTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).PreAuthorizedApplication = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplication[]) content.GetValueForProperty("PreAuthorizedApplication",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).PreAuthorizedApplication, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplication>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.PreAuthorizedApplicationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).PublicClient = (bool?) content.GetValueForProperty("PublicClient",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).PublicClient, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).PublisherDomain = (string) content.GetValueForProperty("PublisherDomain",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).PublisherDomain, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).ReplyUrl = (string[]) content.GetValueForProperty("ReplyUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).ReplyUrl, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).RequiredResourceAccess = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess[]) content.GetValueForProperty("RequiredResourceAccess",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).RequiredResourceAccess, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.RequiredResourceAccessTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).SamlMetadataUrl = (string) content.GetValueForProperty("SamlMetadataUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).SamlMetadataUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).SignInAudience = (string) content.GetValueForProperty("SignInAudience",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).SignInAudience, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).WwwHomepage = (string) content.GetValueForProperty("WwwHomepage",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)this).WwwHomepage, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ApplicationUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationUpdateParameters" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationUpdateParameters DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ApplicationUpdateParameters(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ApplicationUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationUpdateParameters" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationUpdateParameters DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ApplicationUpdateParameters(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ApplicationUpdateParameters" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationUpdateParameters FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Request parameters for updating a new application.
    [System.ComponentModel.TypeConverter(typeof(ApplicationUpdateParametersTypeConverter))]
    public partial interface IApplicationUpdateParameters

    {

    }
}
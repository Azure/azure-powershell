namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.PowerShell;

    /// <summary>Active Directory application information.</summary>
    [System.ComponentModel.TypeConverter(typeof(ApplicationTypeConverter))]
    public partial class Application
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.Application"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Application(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).InformationalUrl = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IInformationalUrl) content.GetValueForProperty("InformationalUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).InformationalUrl, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.InformationalUrlTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).OptionalClaim = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaims) content.GetValueForProperty("OptionalClaim",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).OptionalClaim, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OptionalClaimsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AllowGuestsSignIn = (bool?) content.GetValueForProperty("AllowGuestsSignIn",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AllowGuestsSignIn, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AllowPassthroughUser = (bool?) content.GetValueForProperty("AllowPassthroughUser",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AllowPassthroughUser, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AppId = (string) content.GetValueForProperty("AppId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AppLogoUrl = (string) content.GetValueForProperty("AppLogoUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AppLogoUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AppPermission = (string[]) content.GetValueForProperty("AppPermission",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AppPermission, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AppRole = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole[]) content.GetValueForProperty("AppRole",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AppRole, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.AppRoleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AvailableToOtherTenant = (bool?) content.GetValueForProperty("AvailableToOtherTenant",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AvailableToOtherTenant, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).ErrorUrl = (string) content.GetValueForProperty("ErrorUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).ErrorUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).GroupMembershipClaim = (Microsoft.Azure.PowerShell.Cmdlets.AD.Support.GroupMembershipClaimTypes?) content.GetValueForProperty("GroupMembershipClaim",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).GroupMembershipClaim, Microsoft.Azure.PowerShell.Cmdlets.AD.Support.GroupMembershipClaimTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).Homepage = (string) content.GetValueForProperty("Homepage",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).Homepage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).IdentifierUri = (string[]) content.GetValueForProperty("IdentifierUri",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).IdentifierUri, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).IsDeviceOnlyAuthSupported = (bool?) content.GetValueForProperty("IsDeviceOnlyAuthSupported",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).IsDeviceOnlyAuthSupported, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).KeyCredentials = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[]) content.GetValueForProperty("KeyCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).KeyCredentials, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.KeyCredentialTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).KnownClientApplication = (string[]) content.GetValueForProperty("KnownClientApplication",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).KnownClientApplication, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).LogoutUrl = (string) content.GetValueForProperty("LogoutUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).LogoutUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).Oauth2AllowImplicitFlow = (bool?) content.GetValueForProperty("Oauth2AllowImplicitFlow",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).Oauth2AllowImplicitFlow, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).Oauth2AllowUrlPathMatching = (bool?) content.GetValueForProperty("Oauth2AllowUrlPathMatching",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).Oauth2AllowUrlPathMatching, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).Oauth2Permission = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission[]) content.GetValueForProperty("Oauth2Permission",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).Oauth2Permission, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OAuth2PermissionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).Oauth2RequirePostResponse = (bool?) content.GetValueForProperty("Oauth2RequirePostResponse",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).Oauth2RequirePostResponse, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).OrgRestriction = (string[]) content.GetValueForProperty("OrgRestriction",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).OrgRestriction, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).PasswordCredentials = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[]) content.GetValueForProperty("PasswordCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).PasswordCredentials, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.PasswordCredentialTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).PreAuthorizedApplication = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplication[]) content.GetValueForProperty("PreAuthorizedApplication",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).PreAuthorizedApplication, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplication>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.PreAuthorizedApplicationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).PublicClient = (bool?) content.GetValueForProperty("PublicClient",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).PublicClient, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).PublisherDomain = (string) content.GetValueForProperty("PublisherDomain",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).PublisherDomain, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).ReplyUrl = (string[]) content.GetValueForProperty("ReplyUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).ReplyUrl, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).RequiredResourceAccess = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess[]) content.GetValueForProperty("RequiredResourceAccess",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).RequiredResourceAccess, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.RequiredResourceAccessTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).SamlMetadataUrl = (string) content.GetValueForProperty("SamlMetadataUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).SamlMetadataUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).SignInAudience = (string) content.GetValueForProperty("SignInAudience",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).SignInAudience, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).WwwHomepage = (string) content.GetValueForProperty("WwwHomepage",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).WwwHomepage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).DeletionTimestamp = (global::System.DateTime?) content.GetValueForProperty("DeletionTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).DeletionTimestamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectId = (string) content.GetValueForProperty("ObjectId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectType = (string) content.GetValueForProperty("ObjectType",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).OptionalClaimAccessToken = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[]) content.GetValueForProperty("OptionalClaimAccessToken",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).OptionalClaimAccessToken, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OptionalClaimTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).OptionalClaimIdToken = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[]) content.GetValueForProperty("OptionalClaimIdToken",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).OptionalClaimIdToken, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OptionalClaimTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).OptionalClaimSamlToken = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[]) content.GetValueForProperty("OptionalClaimSamlToken",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).OptionalClaimSamlToken, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OptionalClaimTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).InformationalUrlMarketing = (string) content.GetValueForProperty("InformationalUrlMarketing",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).InformationalUrlMarketing, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).InformationalUrlPrivacy = (string) content.GetValueForProperty("InformationalUrlPrivacy",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).InformationalUrlPrivacy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).InformationalUrlSupport = (string) content.GetValueForProperty("InformationalUrlSupport",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).InformationalUrlSupport, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).InformationalUrlTermsOfService = (string) content.GetValueForProperty("InformationalUrlTermsOfService",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).InformationalUrlTermsOfService, global::System.Convert.ToString);
            // this type is a dictionary; copy elements from source to here.
            CopyFrom(content);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.Application"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Application(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).InformationalUrl = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IInformationalUrl) content.GetValueForProperty("InformationalUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).InformationalUrl, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.InformationalUrlTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).OptionalClaim = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaims) content.GetValueForProperty("OptionalClaim",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).OptionalClaim, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OptionalClaimsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AllowGuestsSignIn = (bool?) content.GetValueForProperty("AllowGuestsSignIn",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AllowGuestsSignIn, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AllowPassthroughUser = (bool?) content.GetValueForProperty("AllowPassthroughUser",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AllowPassthroughUser, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AppId = (string) content.GetValueForProperty("AppId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AppLogoUrl = (string) content.GetValueForProperty("AppLogoUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AppLogoUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AppPermission = (string[]) content.GetValueForProperty("AppPermission",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AppPermission, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AppRole = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole[]) content.GetValueForProperty("AppRole",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AppRole, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.AppRoleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AvailableToOtherTenant = (bool?) content.GetValueForProperty("AvailableToOtherTenant",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).AvailableToOtherTenant, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).ErrorUrl = (string) content.GetValueForProperty("ErrorUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).ErrorUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).GroupMembershipClaim = (Microsoft.Azure.PowerShell.Cmdlets.AD.Support.GroupMembershipClaimTypes?) content.GetValueForProperty("GroupMembershipClaim",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).GroupMembershipClaim, Microsoft.Azure.PowerShell.Cmdlets.AD.Support.GroupMembershipClaimTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).Homepage = (string) content.GetValueForProperty("Homepage",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).Homepage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).IdentifierUri = (string[]) content.GetValueForProperty("IdentifierUri",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).IdentifierUri, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).IsDeviceOnlyAuthSupported = (bool?) content.GetValueForProperty("IsDeviceOnlyAuthSupported",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).IsDeviceOnlyAuthSupported, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).KeyCredentials = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[]) content.GetValueForProperty("KeyCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).KeyCredentials, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.KeyCredentialTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).KnownClientApplication = (string[]) content.GetValueForProperty("KnownClientApplication",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).KnownClientApplication, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).LogoutUrl = (string) content.GetValueForProperty("LogoutUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).LogoutUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).Oauth2AllowImplicitFlow = (bool?) content.GetValueForProperty("Oauth2AllowImplicitFlow",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).Oauth2AllowImplicitFlow, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).Oauth2AllowUrlPathMatching = (bool?) content.GetValueForProperty("Oauth2AllowUrlPathMatching",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).Oauth2AllowUrlPathMatching, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).Oauth2Permission = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission[]) content.GetValueForProperty("Oauth2Permission",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).Oauth2Permission, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OAuth2PermissionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).Oauth2RequirePostResponse = (bool?) content.GetValueForProperty("Oauth2RequirePostResponse",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).Oauth2RequirePostResponse, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).OrgRestriction = (string[]) content.GetValueForProperty("OrgRestriction",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).OrgRestriction, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).PasswordCredentials = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[]) content.GetValueForProperty("PasswordCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).PasswordCredentials, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.PasswordCredentialTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).PreAuthorizedApplication = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplication[]) content.GetValueForProperty("PreAuthorizedApplication",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).PreAuthorizedApplication, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplication>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.PreAuthorizedApplicationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).PublicClient = (bool?) content.GetValueForProperty("PublicClient",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).PublicClient, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).PublisherDomain = (string) content.GetValueForProperty("PublisherDomain",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).PublisherDomain, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).ReplyUrl = (string[]) content.GetValueForProperty("ReplyUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).ReplyUrl, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).RequiredResourceAccess = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess[]) content.GetValueForProperty("RequiredResourceAccess",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).RequiredResourceAccess, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.RequiredResourceAccessTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).SamlMetadataUrl = (string) content.GetValueForProperty("SamlMetadataUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).SamlMetadataUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).SignInAudience = (string) content.GetValueForProperty("SignInAudience",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).SignInAudience, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).WwwHomepage = (string) content.GetValueForProperty("WwwHomepage",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).WwwHomepage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).DeletionTimestamp = (global::System.DateTime?) content.GetValueForProperty("DeletionTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).DeletionTimestamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectId = (string) content.GetValueForProperty("ObjectId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectType = (string) content.GetValueForProperty("ObjectType",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).OptionalClaimAccessToken = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[]) content.GetValueForProperty("OptionalClaimAccessToken",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).OptionalClaimAccessToken, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OptionalClaimTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).OptionalClaimIdToken = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[]) content.GetValueForProperty("OptionalClaimIdToken",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).OptionalClaimIdToken, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OptionalClaimTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).OptionalClaimSamlToken = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[]) content.GetValueForProperty("OptionalClaimSamlToken",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).OptionalClaimSamlToken, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OptionalClaimTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).InformationalUrlMarketing = (string) content.GetValueForProperty("InformationalUrlMarketing",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).InformationalUrlMarketing, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).InformationalUrlPrivacy = (string) content.GetValueForProperty("InformationalUrlPrivacy",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).InformationalUrlPrivacy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).InformationalUrlSupport = (string) content.GetValueForProperty("InformationalUrlSupport",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).InformationalUrlSupport, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).InformationalUrlTermsOfService = (string) content.GetValueForProperty("InformationalUrlTermsOfService",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationInternal)this).InformationalUrlTermsOfService, global::System.Convert.ToString);
            // this type is a dictionary; copy elements from source to here.
            CopyFrom(content);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.Application"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplication" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplication DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Application(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.Application"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplication" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplication DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Application(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Application" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplication FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Active Directory application information.
    [System.ComponentModel.TypeConverter(typeof(ApplicationTypeConverter))]
    public partial interface IApplication

    {

    }
}
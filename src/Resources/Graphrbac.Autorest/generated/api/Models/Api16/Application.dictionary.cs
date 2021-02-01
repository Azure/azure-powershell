namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    public partial class Application :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>
    {

        global::System.Collections.Generic.IDictionary<global::System.String,global::System.Object> Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>.AdditionalProperties { get => __directoryObject.AdditionalProperties; }

        int Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>.Count { get => __directoryObject.Count; }

        global::System.Collections.Generic.IEnumerable<global::System.String> Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>.Keys { get => __directoryObject.Keys; }

        global::System.Collections.Generic.IEnumerable<global::System.Object> Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>.Values { get => __directoryObject.Values; }

        public global::System.Object this[global::System.String index] { get => __directoryObject[index]; set => __directoryObject[index] = value; }

        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(global::System.String key, global::System.Object value) => __directoryObject.Add( key, value);

        public void Clear() => __directoryObject.Clear();

        /// <param name="key"></param>
        public bool ContainsKey(global::System.String key) => __directoryObject.ContainsKey( key);

        /// <param name="source"></param>
        public void CopyFrom(global::System.Collections.IDictionary source)
        {
            if (null != source)
            {
                foreach( var property in  Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.PowerShell.TypeConverterExtensions.GetFilteredProperties(source, new global::System.Collections.Generic.HashSet<global::System.String>() { "InformationalUrl","OptionalClaim","AllowGuestsSignIn","AllowPassthroughUser","AppId","AppLogoUrl","AppPermission","AppRole","AvailableToOtherTenant","DisplayName","ErrorUrl","GroupMembershipClaim","Homepage","IdentifierUri","IsDeviceOnlyAuthSupported","KeyCredentials","KnownClientApplication","LogoutUrl","Oauth2AllowImplicitFlow","Oauth2AllowUrlPathMatching","Oauth2Permission","Oauth2RequirePostResponse","OrgRestriction","PasswordCredentials","PreAuthorizedApplication","PublicClient","PublisherDomain","ReplyUrl","RequiredResourceAccess","SamlMetadataUrl","SignInAudience","WwwHomepage","DeletionTimestamp","ObjectId","ObjectType","OptionalClaimAccessToken","OptionalClaimIdToken","OptionalClaimSamlToken","InformationalUrlMarketing","InformationalUrlPrivacy","InformationalUrlSupport","InformationalUrlTermsOfService" } ) )
                {
                    if ((null != property.Key && null != property.Value))
                    {
                        this.__directoryObject.Add(property.Key.ToString(), global::System.Management.Automation.LanguagePrimitives.ConvertTo<global::System.Object>( property.Value));
                    }
                }
            }
        }

        /// <param name="source"></param>
        public void CopyFrom(global::System.Management.Automation.PSObject source)
        {
            if (null != source)
            {
                foreach( var property in  Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.PowerShell.TypeConverterExtensions.GetFilteredProperties(source, new global::System.Collections.Generic.HashSet<global::System.String>() { "InformationalUrl","OptionalClaim","AllowGuestsSignIn","AllowPassthroughUser","AppId","AppLogoUrl","AppPermission","AppRole","AvailableToOtherTenant","DisplayName","ErrorUrl","GroupMembershipClaim","Homepage","IdentifierUri","IsDeviceOnlyAuthSupported","KeyCredentials","KnownClientApplication","LogoutUrl","Oauth2AllowImplicitFlow","Oauth2AllowUrlPathMatching","Oauth2Permission","Oauth2RequirePostResponse","OrgRestriction","PasswordCredentials","PreAuthorizedApplication","PublicClient","PublisherDomain","ReplyUrl","RequiredResourceAccess","SamlMetadataUrl","SignInAudience","WwwHomepage","DeletionTimestamp","ObjectId","ObjectType","OptionalClaimAccessToken","OptionalClaimIdToken","OptionalClaimSamlToken","InformationalUrlMarketing","InformationalUrlPrivacy","InformationalUrlSupport","InformationalUrlTermsOfService" } ) )
                {
                    if ((null != property.Key && null != property.Value))
                    {
                        this.__directoryObject.Add(property.Key.ToString(), global::System.Management.Automation.LanguagePrimitives.ConvertTo<global::System.Object>( property.Value));
                    }
                }
            }
        }

        /// <param name="key"></param>
        public bool Remove(global::System.String key) => __directoryObject.Remove( key);

        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool TryGetValue(global::System.String key, out global::System.Object value) => __directoryObject.TryGetValue( key, out value);
    }
}
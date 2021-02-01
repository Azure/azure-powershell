namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    public partial class UserUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>
    {

        global::System.Collections.Generic.IDictionary<global::System.String,global::System.Object> Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>.AdditionalProperties { get => __userBase.AdditionalProperties; }

        int Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>.Count { get => __userBase.Count; }

        global::System.Collections.Generic.IEnumerable<global::System.String> Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>.Keys { get => __userBase.Keys; }

        global::System.Collections.Generic.IEnumerable<global::System.Object> Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>.Values { get => __userBase.Values; }

        public global::System.Object this[global::System.String index] { get => __userBase[index]; set => __userBase[index] = value; }

        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(global::System.String key, global::System.Object value) => __userBase.Add( key, value);

        public void Clear() => __userBase.Clear();

        /// <param name="key"></param>
        public bool ContainsKey(global::System.String key) => __userBase.ContainsKey( key);

        /// <param name="source"></param>
        public void CopyFrom(global::System.Collections.IDictionary source)
        {
            if (null != source)
            {
                foreach( var property in  Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.PowerShell.TypeConverterExtensions.GetFilteredProperties(source, new global::System.Collections.Generic.HashSet<global::System.String>() { "AccountEnabled","DisplayName","Mail","MailNickname","UserPrincipalName","PasswordProfile","GivenName","ImmutableId","Surname","UsageLocation","UserType" } ) )
                {
                    if ((null != property.Key && null != property.Value))
                    {
                        this.__userBase.Add(property.Key.ToString(), global::System.Management.Automation.LanguagePrimitives.ConvertTo<global::System.Object>( property.Value));
                    }
                }
            }
        }

        /// <param name="source"></param>
        public void CopyFrom(global::System.Management.Automation.PSObject source)
        {
            if (null != source)
            {
                foreach( var property in  Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.PowerShell.TypeConverterExtensions.GetFilteredProperties(source, new global::System.Collections.Generic.HashSet<global::System.String>() { "AccountEnabled","DisplayName","Mail","MailNickname","UserPrincipalName","PasswordProfile","GivenName","ImmutableId","Surname","UsageLocation","UserType" } ) )
                {
                    if ((null != property.Key && null != property.Value))
                    {
                        this.__userBase.Add(property.Key.ToString(), global::System.Management.Automation.LanguagePrimitives.ConvertTo<global::System.Object>( property.Value));
                    }
                }
            }
        }

        /// <param name="key"></param>
        public bool Remove(global::System.String key) => __userBase.Remove( key);

        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool TryGetValue(global::System.String key, out global::System.Object value) => __userBase.TryGetValue( key, out value);
    }
}
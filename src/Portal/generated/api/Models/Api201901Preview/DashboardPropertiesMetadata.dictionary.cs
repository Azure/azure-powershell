namespace Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Extensions;

    public partial class DashboardPropertiesMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IAssociativeArray<global::System.Object>
    {
        protected global::System.Collections.Generic.Dictionary<global::System.String,global::System.Object> __additionalProperties = new global::System.Collections.Generic.Dictionary<global::System.String,global::System.Object>();

        global::System.Collections.Generic.IDictionary<global::System.String,global::System.Object> Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IAssociativeArray<global::System.Object>.AdditionalProperties { get => __additionalProperties; }

        int Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IAssociativeArray<global::System.Object>.Count { get => __additionalProperties.Count; }

        global::System.Collections.Generic.IEnumerable<global::System.String> Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IAssociativeArray<global::System.Object>.Keys { get => __additionalProperties.Keys; }

        global::System.Collections.Generic.IEnumerable<global::System.Object> Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IAssociativeArray<global::System.Object>.Values { get => __additionalProperties.Values; }

        public global::System.Object this[global::System.String index] { get => __additionalProperties[index]; set => __additionalProperties[index] = value; }

        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(global::System.String key, global::System.Object value) => __additionalProperties.Add( key, value);

        public void Clear() => __additionalProperties.Clear();

        /// <param name="key"></param>
        public bool ContainsKey(global::System.String key) => __additionalProperties.ContainsKey( key);

        /// <param name="source"></param>
        public void CopyFrom(global::System.Collections.IDictionary source)
        {
            if (null != source)
            {
                foreach( var property in  Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.PowerShell.TypeConverterExtensions.GetFilteredProperties(source, new global::System.Collections.Generic.HashSet<global::System.String>() {  } ) )
                {
                    if ((null != property.Key && null != property.Value))
                    {
                        this.__additionalProperties.Add(property.Key.ToString(), global::System.Management.Automation.LanguagePrimitives.ConvertTo<global::System.Object>( property.Value));
                    }
                }
            }
        }

        /// <param name="source"></param>
        public void CopyFrom(global::System.Management.Automation.PSObject source)
        {
            if (null != source)
            {
                foreach( var property in  Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.PowerShell.TypeConverterExtensions.GetFilteredProperties(source, new global::System.Collections.Generic.HashSet<global::System.String>() {  } ) )
                {
                    if ((null != property.Key && null != property.Value))
                    {
                        this.__additionalProperties.Add(property.Key.ToString(), global::System.Management.Automation.LanguagePrimitives.ConvertTo<global::System.Object>( property.Value));
                    }
                }
            }
        }

        /// <param name="key"></param>
        public bool Remove(global::System.String key) => __additionalProperties.Remove( key);

        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool TryGetValue(global::System.String key, out global::System.Object value) => __additionalProperties.TryGetValue( key, out value);

        /// <param name="source"></param>

        public static implicit operator global::System.Collections.Generic.Dictionary<global::System.String,global::System.Object>(Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardPropertiesMetadata source) => source.__additionalProperties;
    }
}
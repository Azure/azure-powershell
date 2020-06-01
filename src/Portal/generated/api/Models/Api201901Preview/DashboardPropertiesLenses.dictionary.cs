namespace Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Extensions;

    public partial class DashboardPropertiesLenses :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLens>
    {
        protected global::System.Collections.Generic.Dictionary<global::System.String,Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLens> __additionalProperties = new global::System.Collections.Generic.Dictionary<global::System.String,Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLens>();

        global::System.Collections.Generic.IDictionary<global::System.String,Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLens> Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLens>.AdditionalProperties { get => __additionalProperties; }

        int Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLens>.Count { get => __additionalProperties.Count; }

        global::System.Collections.Generic.IEnumerable<global::System.String> Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLens>.Keys { get => __additionalProperties.Keys; }

        global::System.Collections.Generic.IEnumerable<Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLens> Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLens>.Values { get => __additionalProperties.Values; }

        public Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLens this[global::System.String index] { get => __additionalProperties[index]; set => __additionalProperties[index] = value; }

        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(global::System.String key, Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLens value) => __additionalProperties.Add( key, value);

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
                        this.__additionalProperties.Add(property.Key.ToString(), global::System.Management.Automation.LanguagePrimitives.ConvertTo<Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLens>( property.Value));
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
                        this.__additionalProperties.Add(property.Key.ToString(), global::System.Management.Automation.LanguagePrimitives.ConvertTo<Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLens>( property.Value));
                    }
                }
            }
        }

        /// <param name="key"></param>
        public bool Remove(global::System.String key) => __additionalProperties.Remove( key);

        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool TryGetValue(global::System.String key, out Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLens value) => __additionalProperties.TryGetValue( key, out value);

        /// <param name="source"></param>

        public static implicit operator global::System.Collections.Generic.Dictionary<global::System.String,Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLens>(Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardPropertiesLenses source) => source.__additionalProperties;
    }
}
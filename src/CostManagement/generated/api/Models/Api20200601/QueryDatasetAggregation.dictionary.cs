namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    public partial class QueryDatasetAggregation :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryAggregation>
    {
        protected global::System.Collections.Generic.Dictionary<global::System.String,Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryAggregation> __additionalProperties = new global::System.Collections.Generic.Dictionary<global::System.String,Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryAggregation>();

        global::System.Collections.Generic.IDictionary<global::System.String,Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryAggregation> Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryAggregation>.AdditionalProperties { get => __additionalProperties; }

        int Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryAggregation>.Count { get => __additionalProperties.Count; }

        global::System.Collections.Generic.IEnumerable<global::System.String> Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryAggregation>.Keys { get => __additionalProperties.Keys; }

        global::System.Collections.Generic.IEnumerable<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryAggregation> Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryAggregation>.Values { get => __additionalProperties.Values; }

        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryAggregation this[global::System.String index] { get => __additionalProperties[index]; set => __additionalProperties[index] = value; }

        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(global::System.String key, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryAggregation value) => __additionalProperties.Add( key, value);

        public void Clear() => __additionalProperties.Clear();

        /// <param name="key"></param>
        public bool ContainsKey(global::System.String key) => __additionalProperties.ContainsKey( key);

        /// <param name="source"></param>
        public void CopyFrom(global::System.Collections.IDictionary source)
        {
            if (null != source)
            {
                foreach( var property in  Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.PowerShell.TypeConverterExtensions.GetFilteredProperties(source, new global::System.Collections.Generic.HashSet<global::System.String>() {  } ) )
                {
                    if ((null != property.Key && null != property.Value))
                    {
                        this.__additionalProperties.Add(property.Key.ToString(), global::System.Management.Automation.LanguagePrimitives.ConvertTo<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryAggregation>( property.Value));
                    }
                }
            }
        }

        /// <param name="source"></param>
        public void CopyFrom(global::System.Management.Automation.PSObject source)
        {
            if (null != source)
            {
                foreach( var property in  Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.PowerShell.TypeConverterExtensions.GetFilteredProperties(source, new global::System.Collections.Generic.HashSet<global::System.String>() {  } ) )
                {
                    if ((null != property.Key && null != property.Value))
                    {
                        this.__additionalProperties.Add(property.Key.ToString(), global::System.Management.Automation.LanguagePrimitives.ConvertTo<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryAggregation>( property.Value));
                    }
                }
            }
        }

        /// <param name="key"></param>
        public bool Remove(global::System.String key) => __additionalProperties.Remove( key);

        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool TryGetValue(global::System.String key, out Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryAggregation value) => __additionalProperties.TryGetValue( key, out value);

        /// <param name="source"></param>

        public static implicit operator global::System.Collections.Generic.Dictionary<global::System.String,Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryAggregation>(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryDatasetAggregation source) => source.__additionalProperties;
    }
}
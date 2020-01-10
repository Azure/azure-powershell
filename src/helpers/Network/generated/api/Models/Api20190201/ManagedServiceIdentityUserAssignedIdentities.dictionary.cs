namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// FIXME: Class ManagedServiceIdentityUserAssignedIdentities is MISSING DESCRIPTION
    /// </summary>
    public partial class ManagedServiceIdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>
    {
        /// <summary>FIXME: Field __additionalProperties is MISSING DESCRIPTION</summary>
        protected global::System.Collections.Generic.Dictionary<global::System.String,Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties> __additionalProperties = new global::System.Collections.Generic.Dictionary<global::System.String,Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>();

        /// <summary>
        /// FIXME: Property Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>.AdditionalProperties
        /// is MISSING DESCRIPTION
        /// </summary>
        global::System.Collections.Generic.IDictionary<global::System.String,Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties> Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>.AdditionalProperties { get => __additionalProperties; }

        /// <summary>
        /// FIXME: Property Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>.Count
        /// is MISSING DESCRIPTION
        /// </summary>
        int Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>.Count { get => __additionalProperties.Count; }

        /// <summary>
        /// FIXME: Property Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>.Keys
        /// is MISSING DESCRIPTION
        /// </summary>
        global::System.Collections.Generic.IEnumerable<global::System.String> Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>.Keys { get => __additionalProperties.Keys; }

        /// <summary>
        /// FIXME: Property Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>.Values
        /// is MISSING DESCRIPTION
        /// </summary>
        global::System.Collections.Generic.IEnumerable<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties> Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>.Values { get => __additionalProperties.Values; }

        /// <summary>FIXME: Property this[global::System.String index] is MISSING DESCRIPTION</summary>
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties this[global::System.String index] { get => __additionalProperties[index]; set => __additionalProperties[index] = value; }

        /// <summary>FIXME: Method Add is MISSING DESCRIPTION</summary>
        /// <param name="key">FIXME: Parameter key is MISSING DESCRIPTION</param>
        /// <param name="value">FIXME: Parameter value is MISSING DESCRIPTION</param>
        public void Add(global::System.String key, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties value) => __additionalProperties.Add( key, value);

        /// <summary>FIXME: Method Clear is MISSING DESCRIPTION</summary>
        public void Clear() => __additionalProperties.Clear();

        /// <summary>FIXME: Method ContainsKey is MISSING DESCRIPTION</summary>
        /// <param name="key">FIXME: Parameter key is MISSING DESCRIPTION</param>
        /// <returns>FIXME: Method ContainsKey <returns> is MISSING DESCRIPTION</returns>
        public bool ContainsKey(global::System.String key) => __additionalProperties.ContainsKey( key);

        /// <summary>FIXME: Method CopyFrom is MISSING DESCRIPTION</summary>
        /// <param name="source">FIXME: Parameter source is MISSING DESCRIPTION</param>
        public void CopyFrom(global::System.Collections.IDictionary source)
        {
            if (null != source)
            {
                foreach( var property in  Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell.TypeConverterExtensions.GetFilteredProperties(source, new global::System.Collections.Generic.HashSet<global::System.String>() {  } ) )
                {
                    if ((null != property.Key && null != property.Value))
                    {
                        this.__additionalProperties.Add(property.Key.ToString(), global::System.Management.Automation.LanguagePrimitives.ConvertTo<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>( property.Value));
                    }
                }
            }
        }

        /// <summary>FIXME: Method CopyFrom is MISSING DESCRIPTION</summary>
        /// <param name="source">FIXME: Parameter source is MISSING DESCRIPTION</param>
        public void CopyFrom(global::System.Management.Automation.PSObject source)
        {
            if (null != source)
            {
                foreach( var property in  Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell.TypeConverterExtensions.GetFilteredProperties(source, new global::System.Collections.Generic.HashSet<global::System.String>() {  } ) )
                {
                    if ((null != property.Key && null != property.Value))
                    {
                        this.__additionalProperties.Add(property.Key.ToString(), global::System.Management.Automation.LanguagePrimitives.ConvertTo<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>( property.Value));
                    }
                }
            }
        }

        /// <summary>FIXME: Method Remove is MISSING DESCRIPTION</summary>
        /// <param name="key">FIXME: Parameter key is MISSING DESCRIPTION</param>
        /// <returns>FIXME: Method Remove <returns> is MISSING DESCRIPTION</returns>
        public bool Remove(global::System.String key) => __additionalProperties.Remove( key);

        /// <summary>FIXME: Method TryGetValue is MISSING DESCRIPTION</summary>
        /// <param name="key">FIXME: Parameter key is MISSING DESCRIPTION</param>
        /// <param name="value">FIXME: Parameter value is MISSING DESCRIPTION</param>
        /// <returns>FIXME: Method TryGetValue <returns> is MISSING DESCRIPTION</returns>
        public bool TryGetValue(global::System.String key, out Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties value) => __additionalProperties.TryGetValue( key, out value);

        /// <summary>
        /// FIXME: Method implicit operator global::System.Collections.Generic.Dictionary<global::System.String,Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>
        /// is MISSING DESCRIPTION
        /// </summary>
        /// <param name="source">FIXME: Parameter source is MISSING DESCRIPTION</param>
        /// <returns>
        /// FIXME: Method implicit operator global::System.Collections.Generic.Dictionary<global::System.String,Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>
        /// <returns> is MISSING DESCRIPTION
        /// </returns>
        public static implicit operator global::System.Collections.Generic.Dictionary<global::System.String,Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ManagedServiceIdentityUserAssignedIdentities source) => source.__additionalProperties;
    }
}
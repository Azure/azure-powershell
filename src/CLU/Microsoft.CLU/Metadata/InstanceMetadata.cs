using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.CLU.Metadata
{
    /// <summary>
    /// An entry point to get access to metadata information of a cmdlet instance.
    /// This type implement "IMetadata" contract.
    /// </summary>
    internal class InstanceMetadata : IMetadata
    {
        /// <summary>
        /// Create an instance of InstanceMetadata.
        /// </summary>
        /// <param name="instance">The instance of cmdlet</param>
        public InstanceMetadata(Cmdlet instance)
        {
            Debug.Assert(instance != null);
            _instance = instance;
        }

        #region IMetadata implementation

        /// <summary>
        /// Get name of all parameter-sets.
        /// </summary>
        /// <returns>All parameter-sets</returns>
        public HashSet<string> AllParameterSets
        {
            // TODO: Need to check Dynamic parameters support for parameter-set
            get
            {
                return new HashSet<string>();
            }
        }

        /// <summary>
        /// Get parameter-set metadata collection.
        /// </summary>
        /// <returns>All parameter-sets metadata collection</returns>
        public ReadOnlyCollection<CommandParameterSetInfo> ParameterSets
        {
            // TODO: Need to check Dynamic parameters support for parameter-set
            get
            {
                return new ReadOnlyCollection<CommandParameterSetInfo>(new List<CommandParameterSetInfo>());
            }
        }

        Dictionary<string, ParameterMetadata> _dynamicParameters = new Dictionary<string, ParameterMetadata>();
        /// <summary>
        /// Get dynamic parameter metadata dictionary. The key is name of the dynamic
        /// parameter and value is the dynamic parameter metadata.
        /// </summary>
        public Dictionary<string, ParameterMetadata> Parameters
        {
            get
            {
                Load();
                return _dynamicParameters;
            }
        }

        #endregion

        bool _supportsDynamicParameters;
        /// <summary>
        /// Checks whether this cmdlet instance supports dynamic parameters
        /// </summary>
        public bool SupportsDynamicParameters
        {
            get
            {
                Load();
                return _supportsDynamicParameters;
            }
        }

        object _dynamicParametersInstance;
        /// <summary>
        /// The dynamic parameters instance.
        /// </summary>
        public object DynamicParametersInstance
        {
            get
            {
                Load();
                return _dynamicParametersInstance;
            }
        }

        /// <summary>
        /// Loads metadata information of a cmdlet instance this metadata instance represents.
        /// </summary>
        public void Load()
        {
            if (_loaded)
            {
                return;
            }

            _loaded = true;
            var instance = _instance as IDynamicParameters;
            if (instance == null)
            {
                _dynamicParameters = new Dictionary<string, ParameterMetadata>();
                return;
            }

            _dynamicParametersInstance = instance.GetDynamicParameters();
            if (this.DynamicParametersInstance == null)
            {
                _dynamicParameters = new Dictionary<string, ParameterMetadata>();
                return;
            }

            _supportsDynamicParameters = true;
            if (this.DynamicParametersInstance is RuntimeDefinedParameterDictionary)
            {
                var parameterDictionary = this.DynamicParametersInstance as RuntimeDefinedParameterDictionary;
                _dynamicParameters = GetDynamicParameterMetadata(parameterDictionary);
            }
            else
            {
                _dynamicParameters = GetDynamicParameterMetadata(this.DynamicParametersInstance.GetType());
            }
        }

        /// <summary>
        /// Get the dynamic parameter metadata dictionary from the given RuntimeDefinedParameterDictionary 
        /// </summary>
        /// <param name="dictionary">The runtime defined parameter dictionary</param>
        /// <returns></returns>
        private Dictionary<string, ParameterMetadata> GetDynamicParameterMetadata(RuntimeDefinedParameterDictionary dictionary)
        {
            var propertiesOfInterest = dictionary.Values.Where(p => p.Attributes.Count > 0).ToList();
            var parameters = new Dictionary<string, ParameterMetadata>();
            foreach (var parameterProperty in propertiesOfInterest)
            {
                var parameterMetadata = new ParameterMetadata(parameterProperty.Name, parameterProperty.ParameterType);
                parameterMetadata.IsDynamic = true;
                foreach (var attr in parameterProperty.Attributes)
                {
                    parameterMetadata.Attributes.Add(attr);
                    if (attr is ParameterAttribute)
                    {
                        var pAttr = attr as ParameterAttribute;
                        parameterMetadata.SetMandatory(pAttr.ParameterSetName, pAttr.Mandatory);
                        parameterMetadata.SetPosition(pAttr.ParameterSetName, pAttr.Position);
                    }
                }
                parameters.Add(parameterProperty.Name.ToLowerInvariant(), parameterMetadata);
            }
            return parameters;
        }

        /// <summary>
        /// Get the dynamic parameter metadata dictionary from the given type 
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns></returns>
        private Dictionary<string, ParameterMetadata> GetDynamicParameterMetadata(Type type)
        {
            var parameterProperties = ParameterProperties.Get(type);
            var parameters = new Dictionary<string, ParameterMetadata>();

            foreach (var p in parameterProperties)
            {
                var paramMetadata = new ParameterMetadata(p.Property);
                paramMetadata.IsDynamic = true;
                foreach (var attributes in p.Attributes)
                {
                    paramMetadata.Attributes.Add(attributes);
                    if (attributes is ParameterAttribute)
                    {
                        var parameterAttribute = attributes as ParameterAttribute;
                        paramMetadata.SetMandatory(parameterAttribute.ParameterSetName, parameterAttribute.Mandatory);
                        paramMetadata.SetPosition(parameterAttribute.ParameterSetName, parameterAttribute.Position);
                    }
                }
                parameters.Add(p.Property.Name.ToLowerInvariant(), paramMetadata);
            }
            return parameters;
        }

        #region Private fields

        /// <summary>
        /// The cmdlet instance.
        /// </summary>
        private Cmdlet _instance;

        /// <summary>
        /// Flag indicating the metadata is already loaded or not.
        /// </summary>
        private bool _loaded;

        #endregion
    }
}

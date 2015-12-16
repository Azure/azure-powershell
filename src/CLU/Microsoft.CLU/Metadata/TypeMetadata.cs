using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

namespace Microsoft.CLU.Metadata
{
    /// <summary>
    /// An entry point to get access to metadata information of a cmdlet type.
    /// This type implement "IMetadata" contract.
    /// </summary>
    internal class TypeMetadata : IMetadata
    {
        #region IMetadata implementation

        /// <summary>
        /// Get name of all parameter-sets.
        /// </summary>
        /// <returns>All parameter-sets</returns>
        public HashSet<string> AllParameterSets
        {
            get; internal set;
        }

        /// <summary>
        /// The default parameter set for the cmdlet.
        /// </summary>
        public string DefaultParameterSet
        {
            get; set;
        }


        /// <summary>
        /// Get parameter-set metadata collection.
        /// </summary>
        /// <returns>All parameter-sets metadata collection</returns>
        public ReadOnlyCollection<CommandParameterSetInfo> ParameterSets
        {
            get;
            protected set;
        }

        /// <summary>
        /// Get parameter metadata dictionary. The key is name of the
        /// parameter and value is the parameter metadata.
        /// </summary>
        /// <returns>All parameters metadata collection</returns>
        public Dictionary<string, ParameterMetadata> Parameters
        {
            get;
            protected set;
        }

        #endregion

        /// <summary>
        /// Gets the collection of pipeline parameters declared in this type.
        /// </summary>
        public IEnumerable<ParameterMetadata> PipelineParameters
        {
            get
            {
                // TODO: AC: In the POC we return only parameters with IsBound
                // false [p => p.TakesInputFromPipeline && !p.IsBound]
                // seems this condition check is not required.
                return Parameters.Values.Where(p => p.TakesInputFromPipeline);
            }
        }

        /// <summary>
        /// Create an instance of TypeMetadata.
        /// </summary>
        /// <param name="cmdletType">The type of cmdlet</param>
        public TypeMetadata(Type cmdletType)
        {
            Debug.Assert(cmdletType != null);

            _cmdletType = cmdletType;

            var cmdletAttributes = cmdletType.GetTypeInfo().GetCustomAttributes(typeof(CmdletAttribute), false);
            var cmdletAttribute = cmdletAttributes.FirstOrDefault() as CmdletAttribute;
            if (!string.IsNullOrEmpty(cmdletAttribute.DefaultParameterSetName))
            {
                this.DefaultParameterSet = cmdletAttribute.DefaultParameterSetName;
            }
        }

        /// <summary>
        /// Loads metadata information of a cmdlet type this metadata instance represents.
        /// </summary>
        public void Load()
        {
            var parameterSets = new Dictionary<string, ParameterSetMetadata>();
            var cmdParameterSets = new Dictionary<string, CommandParameterSetInfo>();

            var parameterProperties = ParameterProperties.Get(_cmdletType);
            foreach (var parameterProperty in parameterProperties)
            {
                foreach (var parameterAttribute in parameterProperty.Attributes)
                {
                    var parameterSetName = parameterAttribute.ParameterSetName;
                    if (parameterSetName != null && !parameterSets.ContainsKey(parameterSetName))
                    {
                        parameterSets.Add(parameterSetName, new ParameterSetMetadata());
                        cmdParameterSets.Add(parameterSetName, new CommandParameterSetInfo()
                        {
                            Name = parameterSetName,
                            IsDefault = parameterSetName.Equals(this.DefaultParameterSet)
                        });
                    }
                }
            }

            this.AllParameterSets = cmdParameterSets.Keys.ToSet();
            if (!string.IsNullOrEmpty(this.DefaultParameterSet))
            {
                this.AllParameterSets.Add(this.DefaultParameterSet);
            }

            var parameters = new Dictionary<string, ParameterMetadata>();
            var cmdParameters = new Dictionary<string, CommandParameterInfo>();

            // Add predefined parameters.
            parameters.Add("force", new ParameterMetadata("Force", typeof(SwitchParameter)) { IsBuiltin = true });
            parameters.Add("debug", new ParameterMetadata("Debug", typeof(SwitchParameter)) { IsBuiltin = true });
            parameters.Add("verbose", new ParameterMetadata("Verbose", typeof(SwitchParameter)) { IsBuiltin = true });

            foreach (var paramMetadata in parameters.Values)
            {
                foreach (var parameterSet in parameterSets)
                {
                    paramMetadata.ParameterSets.Add(parameterSet.Key, parameterSet.Value);
                }
            }

            cmdParameters.Add("force", new CommandParameterInfo("Force", typeof(SwitchParameter)));
            cmdParameters.Add("debug", new CommandParameterInfo("Debug", typeof(SwitchParameter)));
            cmdParameters.Add("verbose", new CommandParameterInfo("Verbose", typeof(SwitchParameter)));

            foreach (var paramInfo in cmdParameters.Values)
            {
                foreach (var cmdParameterSet in cmdParameterSets)
                {
                    cmdParameterSet.Value.Add(paramInfo);
                }
            }

            this.ParameterSets = new ReadOnlyCollection<CommandParameterSetInfo>(cmdParameterSets.Values.ToList());

            // Add parameters declared in the source code.
            foreach (var parameterProperty in parameterProperties)
            {
                var name = parameterProperty.Property.Name.ToLowerInvariant();
                var paramMetadata = new ParameterMetadata(parameterProperty.Property);

                parameters[name] = paramMetadata;

                var paramInfo = new CommandParameterInfo(parameterProperty.Property);
                cmdParameters[name] = paramInfo;

                foreach (var parameterAttribute in parameterProperty.Attributes)
                {
                    var parameterSetName = parameterAttribute.ParameterSetName;
                    paramMetadata.SetMandatory(parameterSetName, parameterAttribute.Mandatory);
                    paramMetadata.SetPosition(parameterSetName, parameterAttribute.Position);

                    if (parameterSetName == null)
                    {
                        foreach (var parameterSet in parameterSets)
                        {
                            paramMetadata.ParameterSets.Add(parameterSet.Key, parameterSet.Value);
                        }
                        foreach (var cmdParameterSet in cmdParameterSets)
                        {
                            cmdParameterSet.Value.Add(paramInfo);
                        }
                    }
                    else
                    {
                        paramMetadata.ParameterSets.Add(parameterSetName, parameterSets[parameterSetName]);
                        cmdParameterSets[parameterSetName].Add(paramInfo);
                    }
                }
            }

            this.Parameters = parameters;
        }

        private bool IsSpecial(string name)
        {
            return name.Equals("force") || name.Equals("verbose") || name.Equals("debug");
        }

        #region Private fields

        /// <summary>
        /// The cmdlet type.
        /// </summary>
        private Type _cmdletType;

        #endregion
    }
}

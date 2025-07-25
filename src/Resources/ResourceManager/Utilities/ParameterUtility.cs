using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities
{
    /// <summary>
    /// For use in Deployment and DeploymentStack cmdlets with parameter conversion and operation.
    /// </summary>
    public static class ParameterUtility
    {
        /// <summary>
        /// Adds parameters to parameterObject hashtable.
        /// </summary>
        public static void AddTemplateFileParametersToHashtable(IReadOnlyDictionary<string, TemplateParameterFileParameter> parameters, Hashtable parameterObject)
        {
            parameters.ForEach(dp =>
            {
                var parameter = new Hashtable();
                if (dp.Value.Value != null)
                {
                    parameter.Add("value", dp.Value.Value);
                }
                if (dp.Value.Reference != null)
                {
                    parameter.Add("reference", dp.Value.Reference);
                }

                parameterObject[dp.Key] = parameter;
            });
        }

        /// <summary>
        /// Add parameters within TemplateObject to paramterObject hashtable, 
        /// while accounting for special handling for KeyVault references.
        /// </summary>
        public static void AddTemplateObjectParametersToHashtable(Hashtable templateParameterObject, Hashtable parameterObject)
        {
            foreach (var parameterKey in templateParameterObject.Keys)
            {
                // Let default behavior of a value parameter if not a KeyVault reference Hashtable:
                var hashtableParameter = templateParameterObject[parameterKey] as Hashtable;
                if (hashtableParameter != null && hashtableParameter.ContainsKey("reference"))
                {
                    parameterObject[parameterKey] = templateParameterObject[parameterKey];
                }
                else
                {
                    parameterObject[parameterKey] = new Hashtable { { "value", templateParameterObject[parameterKey] } };
                }
            }
        }

        /// <summary>
        /// Converts bicep file parameters into format that matches TemplateParameterObject.
        /// </summary>
        public static Hashtable RestructureBicepParameters(IDictionary<string, TemplateParameterFileParameter> bicepparamFileParameters)
        {
            // The TemplateParameterObject property expects parameters to be in a different format to the parameters file JSON.
            // Here we convert from { "foo": { "value": "blah" } } to { "foo": "blah" }
            // with the exception of KV secret references which are left as { "foo": { "reference": ... } }
            var parameters = new Hashtable();
            if (bicepparamFileParameters == null) return parameters;

            foreach (var paramName in bicepparamFileParameters.Keys)
            {
                var param = bicepparamFileParameters[paramName];
                if (param.Value != null)
                {
                    parameters[paramName] = param.Value;
                }
                if (param.Reference != null)
                {
                    var parameter = new Hashtable();
                    parameter.Add("reference", param.Reference);
                    parameters[paramName] = parameter;
                }
            }

            return parameters;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.Management.Blueprint.Models;

namespace Microsoft.Azure.Commands.Blueprint.Models
{
    public class PSTemplateArtifact : PSArtifact
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public List<string> DependsOn { get; set; }
        public object Template { get; set; }
        public IDictionary<string, PSParameterValueBase> Parameters { get; set; }
        public string ResourceGroup { get; set; }

        internal static PSTemplateArtifact FromArtifactModel(TemplateArtifact artifact, string scope)
        {
            var psArtifact = new PSTemplateArtifact
            {
                Id = artifact.Id,
                Type = artifact.Type,
                Name = artifact.Name,
                DisplayName = artifact.DisplayName,
                Description = artifact.Description,
                DependsOn = new List<string>(),
                Template = artifact.Template,
                Parameters = new Dictionary<string, PSParameterValueBase>(),
                ResourceGroup = artifact.ResourceGroup
            };

            foreach (var item in artifact.Parameters)
            {
                PSParameterValueBase parameter = GetArtifactParameters(item);
                psArtifact.Parameters.Add(item.Key, parameter);
            }

            psArtifact.DependsOn = artifact.DependsOn.Select(x => x) as List<string>;

            return psArtifact;
        }
        private static PSParameterValueBase GetArtifactParameters(KeyValuePair<string, ParameterValueBase> parameterKvp)
        {
            PSParameterValueBase parameter = null;

            if (parameterKvp.Value != null && parameterKvp.Value is ParameterValue)
            {
                // Need to cast as ParameterValue since assignment.Parameters value type is ParameterValueBase. 
                var parameterValue = (ParameterValue)parameterKvp.Value;

                parameter = new PSParameterValue { Description = parameterValue.Description, Value = parameterValue.Value };
            }
            else if (parameterKvp.Value != null && parameterKvp.Value is SecretReferenceParameterValue)
            {
                // To-Do: Wait until previous changes merged into Azure master - Below should never happen.
                //var parameterValue = (SecretReferenceParameterValue)parameterKvp.Value;

                /*var secretReference = new PSSecretValueReference
                {
                    KeyVault = new PSKeyVaultReference { Id = parameterValue.Reference.KeyVault.Id },
                    SecretName = parameterValue.Reference.SecretName,
                    SecretVersion = parameterValue.Reference.SecretVersion
                };

                parameter = new PSSecretReferenceParameterValue { Reference = secretReference, Description = parameterValue.Description };*/
            }

            return parameter;
        }
    }
}

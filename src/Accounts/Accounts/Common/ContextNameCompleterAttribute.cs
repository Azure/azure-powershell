using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using System.Text;

namespace Microsoft.Azure.Commands.Profile.Common
{
    /// <summary>
    /// This attribute will allow the user to autocomplete the values for valid Azure Context names when applied to context name related cmdlet parameters.
    /// </summary>
    public class ContextNameCompleterAttribute : ArgumentCompleterAttribute, IArgumentCompleter
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ContextNameCompleterAttribute" /> .
        /// </summary>
        public ContextNameCompleterAttribute():base(typeof(ContextNameCompleterAttribute))
        {

        }

        /// <summary>
        /// Implementations CompleteArgument function of the <see cref="IArgumentCompleter"/>.
        /// </summary>
        public IEnumerable<CompletionResult> CompleteArgument(string commandName, string parameterName, string wordToComplete, CommandAst commandAst, IDictionary fakeBoundParameters)
        {
            var profile = AzureRmProfileProvider.Instance.Profile; // Object profile with DefaultContextKey.
            AzureRmProfile localProfile = profile as AzureRmProfile;
            if (localProfile.Contexts != null && localProfile.Contexts.Count > 0)
            {
                IEnumerable<string> names = localProfile.Contexts.Keys.ToArray();
                foreach (string name in names)
                {
                    yield return new CompletionResult($"'{name}'", $"'{name}'", CompletionResultType.ParameterValue, $"'{name}'");
                }
            } 
            else
            {   
                yield return new CompletionResult($"{localProfile.DefaultContextKey}", $"{localProfile.DefaultContextKey}", CompletionResultType.ParameterValue, $"{localProfile.DefaultContextKey}");
            }
        }
    }
}

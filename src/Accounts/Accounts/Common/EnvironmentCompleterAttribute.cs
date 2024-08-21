using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;

namespace Microsoft.Azure.Commands.Profile.Common
{
    /// <summary>
    /// This attribute will allow the user to autocomplete the values for valid Azure Environment names when applied to Environment related cmdlet parameters.
    /// </summary>
    public class EnvironmentCompleterAttribute : ArgumentCompleterAttribute, IArgumentCompleter
    {
        /// <summary>
        /// Initializes a new instance of <see cref="EnvironmentCompleterAttribute" /> .
        /// </summary>
        public EnvironmentCompleterAttribute() : base(typeof(EnvironmentCompleterAttribute))
        {
        }

        /// <summary>
        /// Returns an array of available Azure Environment names.
        /// </summary>
        /// <returns></returns>
        public static string[] GetEnvironments()
        {
            var profileClient = new RMProfileClient(AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>());
            return profileClient.ListEnvironments(null).Select(x => x.Name).ToArray();
        }

        /// <summary>
        /// Implementations CompleteArgument function of the <see cref="IArgumentCompleter"/>.
        /// </summary>
        public IEnumerable<CompletionResult> CompleteArgument(string commandName, string parameterName, string wordToComplete, CommandAst commandAst, IDictionary fakeBoundParameters)
        {
            IEnumerable<string> names = GetEnvironments().Where(env => env.ToLower().StartsWith(wordToComplete.ToLower())) ;
            foreach (string name in names)
            {
                yield return new CompletionResult(name, name, CompletionResultType.ParameterValue, name);
            }
        }
    }
}
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
    /// This attribute will allow the user to autocomplete the values for valid Azure Tenant id when applied to Tenant related cmdlet parameters.
    /// </summary>
    public class TenantCompleterAttribute: ArgumentCompleterAttribute, IArgumentCompleter
    {
        /// <summary>
        /// Initializes a new instance of <see cref="TenantCompleterAttribute" /> .
        /// </summary>
        public TenantCompleterAttribute(): base(typeof(TenantCompleterAttribute))
        {

        }

        /// <summary>
        /// Returns an array of available Azure Tenant ids.
        /// </summary>
        /// <returns></returns>
        public static string[] GetTenantIds()
        {
            var profileClient = new RMProfileClient(AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>());
            return profileClient.ListTenants(null).Select(x => x.Id).ToArray();
        }

        /// <summary>
        /// Implementations CompleteArgument function of the <see cref="IArgumentCompleter"/>.
        /// </summary>
        public IEnumerable<CompletionResult> CompleteArgument(string commandName, string parameterName, string wordToComplete, CommandAst commandAst, IDictionary fakeBoundParameters)
        {
            IEnumerable<string> names = GetTenantIds().Where(ten => ten.StartsWith(wordToComplete));
            foreach (string name in names)
            {
                yield return new CompletionResult(name, name, CompletionResultType.ParameterValue, name);
            }
        }
    }
}

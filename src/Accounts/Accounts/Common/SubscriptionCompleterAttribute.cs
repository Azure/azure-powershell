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
    /// This attribute will allow the user to autocomplete the values for valid Azure Subscription when applied to Subscription related cmdlet parameters.
    /// </summary>
    public class SubscriptionCompleterAttribute: ArgumentCompleterAttribute, IArgumentCompleter
    {
        /// <summary>
        /// Initializes a new instance of <see cref="SubscriptionCompleterAttribute" /> .
        /// </summary>
        public SubscriptionCompleterAttribute(): base(typeof(SubscriptionCompleterAttribute))
        {

        }

        /// <summary>
        /// Returns an array of available Azure subscription.
        /// </summary>
        /// <returns></returns>
        public static string[] GetSubscriptions(string parameterName, string tenantIdOrDomain = "")
        {
            var profileClient = new RMProfileClient(AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>());
            if ("subscriptionid" == parameterName)
                return profileClient.ListSubscriptions(tenantIdOrDomain).Select(x => x.Id).ToArray();
            if ("subscriptionname" == parameterName)
                return profileClient.ListSubscriptions(tenantIdOrDomain).Select(x => x.Name).ToArray();
            return profileClient.ListSubscriptions(tenantIdOrDomain).Select(x => x.Name).Concat(profileClient.ListSubscriptions(tenantIdOrDomain).Select(x => x.Id)).ToArray();
        }

        /// <summary>
        /// Implementations CompleteArgument function of the <see cref="IArgumentCompleter"/>.
        /// </summary>
        public IEnumerable<CompletionResult> CompleteArgument(string commandName, string parameterName, string wordToComplete, CommandAst commandAst, IDictionary fakeBoundParameters)
        {
            var tenantId = fakeBoundParameters["Tenant"];
            string autoCompeterParam = commandAst.CommandElements.Last().ToString().ToLower().TrimStart('-');
            char[] charsToTrim = { '"', '\'' };
            IEnumerable<string> names = GetSubscriptions(autoCompeterParam, tenantId?.ToString()).Where(name => name.ToLower().StartsWith(wordToComplete.Trim(charsToTrim).ToLower()));
            foreach (string name in names)
            {
                // The name may contain spaces. For powershell, Add single quotes before and after the name.
                yield return new CompletionResult(name.Contains(" ") ? $"'{name}'" : name, name, CompletionResultType.ParameterValue, name);
            }
        }
    }
}

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.Common
{
    /// <summary>
    /// This attribute will allow the user to autocomplete the values for valid Azure Environment names when applied to Environment related cmdlet parameters.
    /// </summary>
    public class EnvironmentCompleterAttribute : ArgumentCompleterAttribute
    {
        /// <summary>
        /// Initializes a new instance of <see cref="EnvironmentCompleterAttribute" /> .
        /// </summary>
        public EnvironmentCompleterAttribute() : base(CreateScriptBlock())
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

        private static ScriptBlock CreateScriptBlock()
        {
            string script = "param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)\n" +
                "$environments = [Microsoft.Azure.Commands.Profile.Common.EnvironmentCompleterAttribute]::GetEnvironments()\n" +
                "$environments | Where-Object { $_ -Like \"$wordToComplete*\" } | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }";
            ScriptBlock scriptBlock = ScriptBlock.Create(script);
            return scriptBlock;
        }
    }
}
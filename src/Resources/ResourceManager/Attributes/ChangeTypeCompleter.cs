namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Attributes
{
    using Microsoft.Azure.Management.ResourceManager.Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Management.Automation.Language;

    public class ChangeTypeCompleter : IArgumentCompleter
    {
        private readonly static string[] OrderedChangeTypeNames = new[]
        {
            ChangeType.Ignore.ToString(),
            ChangeType.NoChange.ToString(),
            ChangeType.Deploy.ToString(),
            ChangeType.Create.ToString(),
            ChangeType.Modify.ToString(),
            ChangeType.Delete.ToString()
        };

        public IEnumerable<CompletionResult> CompleteArgument(
            string commandName,
            string parameterName,
            string wordToComplete,
            CommandAst commandAst,
            IDictionary fakeBoundParameters)
        {
            WildcardPattern wildcard = new WildcardPattern(wordToComplete + "*", WildcardOptions.IgnoreCase);

            return OrderedChangeTypeNames.Where(wildcard.IsMatch).Select(s => new CompletionResult(s));
        }
    }
}

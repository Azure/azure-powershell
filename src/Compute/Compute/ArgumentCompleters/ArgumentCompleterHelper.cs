using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Management.Compute.ArgumentCompleters
{
    public static class ArgumentCompleterHelper
    {
        public class ScriptBuilder
        {
            private readonly string[] requiredParameters;
            private readonly string libNamespace;
            private readonly string className;
            private readonly string methodName;

            public ScriptBuilder(string[] requiredParameters, string libNamespace, string className, string methodName)
            {
                this.requiredParameters = requiredParameters;
                this.libNamespace = libNamespace;
                this.className = className;
                this.methodName = methodName;
            }

            public override string ToString()
            {
                var parameters = new List<string>(requiredParameters);
                var parametersAssignments = string.Join(Environment.NewLine, parameters.Select((p, index) => $"$var{index} = $fakeBoundParameter['{p}']"));
                var parametersAsArguments = string.Join(", ", parameters.Select((_, index) => $"$var{index}"));
                return $@"param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
{parametersAssignments}
$candidates = [{libNamespace}.{className}]::{methodName}({parametersAsArguments})
$candidates | Where-Object {{ $_ -Like ""$wordToComplete*"" }} | Sort-Object | Get-Unique | ForEach-Object {{ [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }}";
            }
        }

        public static List<TItem> ReadAllPages<TItem>(Task<IPage<TItem>> task, Func<string, Task<IPage<TItem>>> nextTaskCreator)
        {
            var results = new List<TItem>();

            task.Wait();
            var page = task.Result;
            results.AddRange(page);

            while (!string.IsNullOrEmpty(page.NextPageLink))
            {
                task = nextTaskCreator(page.NextPageLink);
                task.Wait();
                page = task.Result;
                results.AddRange(page);
            }

            return results;
        }

        public static int HashContext(IAzureContext context)
        {
            return (context.Account.Id + context.Environment.Name + context.Subscription.Id + context.Tenant.Id).GetHashCode();
        }
    }
}
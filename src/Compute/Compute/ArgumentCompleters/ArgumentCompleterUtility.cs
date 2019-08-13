using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Management.Compute.ArgumentCompleters
{
    public static class ArgumentCompleterUtility
    {
        public class ScriptBuilder
        {
            private string[] requiredParameters;
            private string libNamespace;
            private string className;
            private string methodName;

            private ScriptBuilder() {}

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
                var asAssignments = string.Join(Environment.NewLine, parameters.Select((p, index) => $"$var{index} = $fakeBoundParameter['{p}']"));
                var asArguments = string.Join(", ", parameters.Select((_, index) => $"$var{index}"));
                return $@"param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
{asAssignments}
$skuNames = [{libNamespace}.{className}]::{methodName}({asArguments})
$locations | Where-Object {{ $_ -Like ""$wordToComplete*"" }} | ForEach-Object {{ [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }}";
            }
        }
    }
}
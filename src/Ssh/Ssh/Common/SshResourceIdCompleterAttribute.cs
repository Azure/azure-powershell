using System.Management.Automation;

namespace Microsoft.Azure.PowerShell.Cmdlets.Ssh.Common
{
    internal class SshResourceIdCompleterAttribute : ArgumentCompleterAttribute
    {
        public SshResourceIdCompleterAttribute(string [] resourceTypes) : base(CreateScriptBlock(resourceTypes))
        {
        }

        public static ScriptBlock CreateScriptBlock(string [] resourceTypes)
        {
            string script = "param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)\n";
            script += "$resourceIds = @()\n";
            foreach (var resourceType in resourceTypes)
            {
                script += $"$resourceType = \"{resourceType}\"\n" +
                    "$resourceIds = $resourceIds + [Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters.ResourceIdCompleterAttribute]::GetResourceIds($resourceType)\n";
            }
            script += "$resourceIds | Where-Object { $_ -Like \"*$wordToComplete*\" } | Sort-Object | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }";
            var scriptBlock = ScriptBlock.Create(script);
            return scriptBlock;
        }
    }
}

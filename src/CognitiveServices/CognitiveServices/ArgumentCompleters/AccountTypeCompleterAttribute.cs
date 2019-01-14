namespace Microsoft.Azure.Commands.Management.CognitiveServices.ArgumentCompleters
{
    using System.Management.Automation;

    public class AccountTypeCompleterAttribute : ArgumentCompleterAttribute
    {
        public AccountTypeCompleterAttribute()
               : base(CreateScriptBlock())
        {
        }

        private static ScriptBlock CreateScriptBlock()
        {
            string scripts = @"param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
$location = $fakeBoundParameter['Location']
$values = $(Get-AzCognitiveServicesAccountType -Location $location)
$values | Where-Object { $_ -Like ""$wordToComplete*"" } | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }";
            return ScriptBlock.Create(scripts);
        }
    }
}

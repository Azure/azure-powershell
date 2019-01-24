namespace Microsoft.Azure.Commands.Management.CognitiveServices.ArgumentCompleters
{
    using System.Management.Automation;

    public class AccountSkuCompleterAttribute : ArgumentCompleterAttribute
    {
        public AccountSkuCompleterAttribute()
               : base(CreateScriptBlock())
        {
        }

        private static ScriptBlock CreateScriptBlock()
        {
            string scripts = @"param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
$location = $fakeBoundParameter['Location']
$type = $fakeBoundParameter['Type']
$values = $(Get-AzCognitiveServicesAccountSkus -Location $location -Type $type) | ForEach-Object { $_.Name }
$values | Where-Object { $_ -Like ""$wordToComplete*"" } | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }";
            return ScriptBlock.Create(scripts);
        }
    }
}

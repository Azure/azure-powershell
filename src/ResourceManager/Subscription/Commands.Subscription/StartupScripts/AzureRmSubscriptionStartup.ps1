Register-ArgumentCompleter -CommandName New-AzureRmSubscription -ParameterName OfferType -ScriptBlock {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

	$values = "MS-AZR-0017P", "MS-AZR-0148P"
    $values |
        ForEach-Object {
            [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_)
        }
}
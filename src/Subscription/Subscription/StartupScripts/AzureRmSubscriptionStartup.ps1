Register-ArgumentCompleter -CommandName Update-AzSubscription -ParameterName Action -ScriptBlock {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

	$values = "Cancel", "Rename", "Enable"
    $values |
        ForEach-Object {
            [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_)
        }
}
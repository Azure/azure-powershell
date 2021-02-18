<<<<<<< HEAD
﻿Register-ArgumentCompleter -CommandName New-AzSubscription -ParameterName OfferType -ScriptBlock {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

	$values = "MS-AZR-0017P", "MS-AZR-0148P"
=======
﻿Register-ArgumentCompleter -CommandName Update-AzSubscription -ParameterName Action -ScriptBlock {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

	$values = "Cancel", "Rename", "Enable"
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    $values |
        ForEach-Object {
            [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_)
        }
}
$testAutomationAccount = @{
    ResourceGroupName = 'anatolib-azureps-test-rg'
    AutomationAccountName = 'anatolib-azureps-test-aa'
}

<#
Test-GetAllModulesInAutomationAccount
#>
function Test-GetAllModulesInAutomationAccount {
	$output = Get-AzureRmAutomationModule @testAutomationAccount

	Assert-NotNull $output

	$outputCount = $output | Measure-Object | % Count;
	Assert-True { $outputCount -gt 1 } "Get-AzureRmAutomationModule should output more than one object"

    $azureModule = $output | ?{ $_.Name -eq 'Azure' }
	Assert-AreEqual $azureModule.AutomationAccountName $testAutomationAccount.AutomationAccountName
	Assert-AreEqual $azureModule.ResourceGroupName $testAutomationAccount.ResourceGroupName
	Assert-AreEqual $azureModule.Name 'Azure'
	Assert-True { $azureModule.IsGlobal }
	Assert-AreEqual $azureModule.Version '1.0.3'
	Assert-AreEqual $azureModule.SizeInBytes 41338511
	Assert-AreEqual $azureModule.ActivityCount 673
	Assert-NotNull $azureModule.CreationTime
	Assert-NotNull $azureModule.LastModifiedTime
	Assert-AreEqual $azureModule.ProvisioningState 'Created'
}

<#
Test-GetModuleByName
#>
function Test-GetModuleByName {
	$output = Get-AzureRmAutomationModule -Name Azure @testAutomationAccount

	Assert-NotNull $output

	$outputCount = $output | Measure-Object | % Count;
	Assert-AreEqual $outputCount 1

	Assert-AreEqual $output.AutomationAccountName $testAutomationAccount.AutomationAccountName
	Assert-AreEqual $output.ResourceGroupName $testAutomationAccount.ResourceGroupName
	Assert-AreEqual $output.Name 'Azure'
	Assert-True { $output.IsGlobal }
	Assert-AreEqual $output.Version '1.0.3'
	Assert-AreEqual $output.SizeInBytes 41338511
	Assert-AreEqual $output.ActivityCount 673
	Assert-NotNull $output.CreationTime
	Assert-NotNull $output.LastModifiedTime
	Assert-AreEqual $output.ProvisioningState 'Created'
}

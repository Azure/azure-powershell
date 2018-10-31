$testAutomationAccount = @{
    ResourceGroupName = 'anatolib-azureps-test-rg'
    AutomationAccountName = 'anatolib-azureps-test-aa'
}

$testNonGlobalModule = @{
    Name = 'AzureRM.profile'
	Version = '5.4.0'
    ContentLinkUri = 'https://devopsgallerystorage.blob.core.windows.net/packages/azurerm.profile.5.4.0.nupkg'
}

<#
Test-GetAllModules
#>
function Test-GetAllModules {
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

<#
Test-NewModule
#>
function Test-NewModule {
	$output = New-AzureRmAutomationModule -Name $testNonGlobalModule.Name -ContentLinkUri $testNonGlobalModule.ContentLinkUri @testAutomationAccount

	Assert-NotNull $output

	$outputCount = $output | Measure-Object | % Count;
	Assert-AreEqual $outputCount 1

	Assert-AreEqual $output.AutomationAccountName $testAutomationAccount.AutomationAccountName
	Assert-AreEqual $output.ResourceGroupName $testAutomationAccount.ResourceGroupName
	Assert-AreEqual $output.Name $testNonGlobalModule.Name
	Assert-False { $output.IsGlobal }
	Assert-Null $output.Version
	Assert-AreEqual $output.SizeInBytes 0
	Assert-AreEqual $output.ActivityCount 0
	Assert-NotNull $output.CreationTime
	Assert-NotNull $output.LastModifiedTime
	Assert-AreEqual $output.ProvisioningState 'Creating'
}

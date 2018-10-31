$testAutomationAccount = @{
    ResourceGroupName = 'anatolib-azureps-test-rg'
    AutomationAccountName = 'anatolib-azureps-test-aa'
}

$testGlobalModule = @{
	Name = 'Azure'
	Version = '1.0.3'
	Size = 41338511
	ActivityCount = 673
}

$testNonGlobalModule = @{
    Name = 'Pester'
	Version = '3.0.3'
    ContentLinkUri = 'https://devopsgallerystorage.blob.core.windows.net/packages/pester.3.0.3.nupkg'
}

function EnsureTestModuleImported {
    if (-not (Get-AzureRmAutomationModule -Name $testNonGlobalModule.Name @testAutomationAccount -ErrorAction Ignore)) {
        $output = New-AzureRmAutomationModule -Name $testNonGlobalModule.Name -ContentLinkUri $testNonGlobalModule.ContentLinkUri @testAutomationAccount

		$startTime = Get-Date
		$timeout = New-TimeSpan -Minutes 2
		$endTime = $startTime + $timeout

        while ($output.ProvisioningState -ne 'Created') {
            Start-Sleep -Seconds 10
            $output = Get-AzureRmAutomationModule -Name $testNonGlobalModule.Name @testAutomationAccount

			if ((Get-Date) -gt $endTime) {
				throw "Module $($testNonGlobalModule.Name) took longer than $timeout to import"
			}
        }
    }
}

function Remove-TestNonGlobalModule {
    if (Get-AzureRmAutomationModule -Name $testNonGlobalModule.Name @testAutomationAccount -ErrorAction Ignore) {
        Remove-AzureRmAutomationModule -Name $testNonGlobalModule.Name @testAutomationAccount -Force
    }
}

<#
Test-GetAllModules
#>
function Test-GetAllModules {
	$output = Get-AzureRmAutomationModule @testAutomationAccount

	Assert-NotNull $output
	$outputCount = $output | Measure-Object | % Count;
	Assert-True { $outputCount -gt 1 } "Get-AzureRmAutomationModule should output more than one object"

    $azureModule = $output | ?{ $_.Name -eq $testGlobalModule.Name }
	Assert-AreEqual $azureModule.AutomationAccountName $testAutomationAccount.AutomationAccountName
	Assert-AreEqual $azureModule.ResourceGroupName $testAutomationAccount.ResourceGroupName
	Assert-AreEqual $azureModule.Name $testGlobalModule.Name
	Assert-True { $azureModule.IsGlobal }
	Assert-AreEqual $azureModule.Version $testGlobalModule.Version
	Assert-AreEqual $azureModule.SizeInBytes $testGlobalModule.Size
	Assert-AreEqual $azureModule.ActivityCount $testGlobalModule.ActivityCount
	Assert-NotNull $azureModule.CreationTime
	Assert-NotNull $azureModule.LastModifiedTime
	Assert-AreEqual $azureModule.ProvisioningState 'Created'
}

<#
Test-GetModuleByName
#>
function Test-GetModuleByName {
	$output = Get-AzureRmAutomationModule -Name $testGlobalModule.Name @testAutomationAccount

	Assert-NotNull $output
	$outputCount = $output | Measure-Object | % Count;
	Assert-AreEqual $outputCount 1

	Assert-AreEqual $output.AutomationAccountName $testAutomationAccount.AutomationAccountName
	Assert-AreEqual $output.ResourceGroupName $testAutomationAccount.ResourceGroupName
	Assert-AreEqual $output.Name $testGlobalModule.Name
	Assert-True { $output.IsGlobal }
	Assert-AreEqual $output.Version $testGlobalModule.Version
	Assert-AreEqual $output.SizeInBytes $testGlobalModule.Size
	Assert-AreEqual $output.ActivityCount $testGlobalModule.ActivityCount
	Assert-NotNull $output.CreationTime
	Assert-NotNull $output.LastModifiedTime
	Assert-AreEqual $output.ProvisioningState 'Created'
}

<#
Test-NewModule
#>
function Test-NewModule {
	Remove-TestNonGlobalModule

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

<#
Test-ImportModuleIsAliasForNewModule
#>
function Test-ImportModuleIsAliasForNewModule {
    $command = Get-Command Import-AzureRmAutomationModule
    Assert-AreEqual $command.CommandType 'Alias'
    Assert-AreEqual $command.Definition 'New-AzureRmAutomationModule'
}

<#
Test-SetModule
#>
function Test-SetModule {
	EnsureTestModuleImported

	$output = Set-AzureRmAutomationModule -Name $testNonGlobalModule.Name -ContentLinkUri $testNonGlobalModule.ContentLinkUri @testAutomationAccount

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

<#
Test-RemoveModule
#>
function Test-RemoveModule {
	EnsureTestModuleImported

	$output = Remove-AzureRmAutomationModule -Name $testNonGlobalModule.Name @testAutomationAccount -Force

	Assert-Null $output
}

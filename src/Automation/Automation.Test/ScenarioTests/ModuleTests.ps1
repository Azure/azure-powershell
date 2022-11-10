$testAutomationAccount = @{
    ResourceGroupName = 'to-delete-01'
    AutomationAccountName = 'fbs-aa-01'
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
	Size = 74921
}

function EnsureTestModuleImported {
	$foundModule = Get-AzAutomationModule -Name $testNonGlobalModule.Name @testAutomationAccount -ErrorAction Ignore
    if ($foundModule) {
		if ($foundModule.ProvisioningState -ne 'Succeeded') {
			Remove-AzAutomationModule -Name $testNonGlobalModule.Name @testAutomationAccount -Force
			$foundModule = $null
		}
	}

    if (-not $foundModule) {
        $output = New-AzAutomationModule -Name $testNonGlobalModule.Name -ContentLinkUri $testNonGlobalModule.ContentLinkUri @testAutomationAccount
		Write-Verbose "Module $($testNonGlobalModule.Name) provisioning state: $($output.ProvisioningState)"

		$startTime = Get-Date
		$timeout = New-TimeSpan -Minutes 3
		$endTime = $startTime + $timeout

        while ($output.ProvisioningState -ne 'Succeeded') {
            [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(10*1000)

            $output = Get-AzAutomationModule -Name $testNonGlobalModule.Name @testAutomationAccount
			Write-Verbose "Module $($testNonGlobalModule.Name) provisioning state: $($output.ProvisioningState)"

			if ((Get-Date) -gt $endTime) {
				throw "Module $($testNonGlobalModule.Name) took longer than $timeout to import"
			}
        }
    }
}

function Remove-TestNonGlobalModule {
    if (Get-AzAutomationModule -Name $testNonGlobalModule.Name @testAutomationAccount -ErrorAction Ignore) {
        Remove-AzAutomationModule -Name $testNonGlobalModule.Name @testAutomationAccount -Force
    }
}

<#
.SYNOPSIS
Tests getting all modules from an Automation account.
#>
function Test-GetAllModules {
	$output = Get-AzAutomationModule @testAutomationAccount

	Assert-NotNull $output
	$outputCount = $output | Measure-Object | % Count;
	Assert-True { $outputCount -gt 1 } "Get-AzAutomationModule should output more than one object"

    $azureModule = $output | ?{ $_.Name -eq $testGlobalModule.Name }
	Assert-AreEqual $azureModule.AutomationAccountName $testAutomationAccount.AutomationAccountName
	Assert-AreEqual $azureModule.ResourceGroupName $testAutomationAccount.ResourceGroupName
	Assert-AreEqual $azureModule.Name $testGlobalModule.Name
	Assert-True { $azureModule.IsGlobal }
	Assert-AreEqual $azureModule.Version $testGlobalModule.Version
	#Assert-AreEqual $azureModule.SizeInBytes $testGlobalModule.Size
	Assert-AreEqual $azureModule.ActivityCount $testGlobalModule.ActivityCount
	Assert-NotNull $azureModule.CreationTime
	Assert-NotNull $azureModule.LastModifiedTime
	Assert-AreEqual $azureModule.ProvisioningState 'Succeeded'
}

<#
.SYNOPSIS
Tests getting a specific module from an Automation account by module name.
#>
function Test-GetModuleByName {
	$output = Get-AzAutomationModule -Name $testGlobalModule.Name @testAutomationAccount

	Assert-NotNull $output
	$outputCount = $output | Measure-Object | % Count;
	Assert-AreEqual $outputCount 1

	Assert-AreEqual $output.AutomationAccountName $testAutomationAccount.AutomationAccountName
	Assert-AreEqual $output.ResourceGroupName $testAutomationAccount.ResourceGroupName
	Assert-AreEqual $output.Name $testGlobalModule.Name
	Assert-True { $output.IsGlobal }
	Assert-AreEqual $output.Version $testGlobalModule.Version
	#Assert-AreEqual $output.SizeInBytes $testGlobalModule.Size
	Assert-AreEqual $output.ActivityCount $testGlobalModule.ActivityCount
	Assert-NotNull $output.CreationTime
	Assert-NotNull $output.LastModifiedTime
	Assert-AreEqual $output.ProvisioningState 'Succeeded'
}

<#
.SYNOPSIS
Tests importing a new module into an Automation account.
#>
function Test-NewModule {
	Remove-TestNonGlobalModule

	$output = New-AzAutomationModule -Name $testNonGlobalModule.Name -ContentLinkUri $testNonGlobalModule.ContentLinkUri @testAutomationAccount

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
.SYNOPSIS
Tests that Import-AzAutomationModule is an alias for New-AzAutomationModule.
#>
function Test-ImportModule {
    $command = Get-Command Import-AzAutomationModule
    Assert-AreEqual $command.CommandType 'Alias'
    Assert-AreEqual $command.Definition 'New-AzAutomationModule'
}

<#
.SYNOPSIS
Tests updating a module already imported into an Automation account.
#>
function Test-SetModule {
	EnsureTestModuleImported

	$output = Set-AzAutomationModule -Name $testNonGlobalModule.Name -ContentLinkUri $testNonGlobalModule.ContentLinkUri @testAutomationAccount -ContentLinkVersion $testNonGlobalModule.Version

	Assert-NotNull $output
	$outputCount = $output | Measure-Object | % Count;
	Assert-AreEqual $outputCount 1

	Assert-AreEqual $output.AutomationAccountName $testAutomationAccount.AutomationAccountName
	Assert-AreEqual $output.ResourceGroupName $testAutomationAccount.ResourceGroupName
	Assert-AreEqual $output.Name $testNonGlobalModule.Name
	Assert-False { $output.IsGlobal }
	#Assert-AreEqual $output.Version $testNonGlobalModule.Version
	#Assert-AreEqual $output.SizeInBytes $testNonGlobalModule.Size
	#Assert-AreEqual $output.ActivityCount 0
	Assert-NotNull $output.CreationTime
	Assert-NotNull $output.LastModifiedTime
	Assert-AreEqual $output.ProvisioningState 'Creating'
}

<#
.SYNOPSIS
Tests removing a module from an Automation account.
#>
function Test-RemoveModule {
	EnsureTestModuleImported

	$output = Remove-AzAutomationModule -Name $testNonGlobalModule.Name @testAutomationAccount -Force

	Assert-Null $output
	$moduleFound = Get-AzAutomationModule -Name $testNonGlobalModule.Name @testAutomationAccount -ErrorAction Ignore
	Assert-Null $moduleFound
}

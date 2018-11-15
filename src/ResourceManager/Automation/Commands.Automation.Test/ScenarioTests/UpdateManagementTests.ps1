$rg = "mo-resources-eus"
$aa = "mo-aaa-eus2"
$azureVMIdsW = @(
        "/subscriptions/422b6c61-95b0-4213-b3be-7282315df71d/resourceGroups/mo-compute/providers/Microsoft.Compute/virtualMachines/mo-vm-w-01",
        "/subscriptions/422b6c61-95b0-4213-b3be-7282315df71d/resourceGroups/mo-compute/providers/Microsoft.Compute/virtualMachines/mo-vm-w-02"
    )

$azureVMIdsL = @(
        "/subscriptions/422b6c61-95b0-4213-b3be-7282315df71d/resourceGroups/mo-compute/providers/Microsoft.Compute/virtualMachines/mo-vm-l-01",
        "/subscriptions/422b6c61-95b0-4213-b3be-7282315df71d/resourceGroups/mo-compute/providers/Microsoft.Compute/virtualMachines/mo-vm-l-02"
    )

$nonAzurecomputers = @("server-01", "server-02")

<#
WaitForProvisioningState
#>
function WaitForProvisioningState() {
    param([string] $Name, [string] $ExpectedState)

    $waitTimeInSeconds = 2
    $retries = 40

    $jobCompleted = Retry-Function {
        return (Get-AzureRmAutomationSoftwareUpdateConfiguration -ResourceGroupName $rg `
                                                                 -AutomationAccountName $aa `
                                                                 -Name $Name).ProvisioningState -eq $ExpectedState } $null $retries $waitTimeInSeconds

    Assert-True {$jobCompleted -gt 0} "Timout waiting for provisioning state to reach '$ExpectedState'"
}

<#
Test-CreateWindowsOneTimeSoftwareUpdateConfigurationWithDefaults
#>
function Test-CreateWindowsOneTimeSoftwareUpdateConfigurationWithDefaults {
    $name = "mo-onetime-01"
    $startTime = ([DateTime]::Now).AddMinutes(10)
	$s = New-AzureRmAutomationSchedule -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Name $name `
                                       -Description test-OneTime `
                                       -OneTime `
                                       -StartTime $startTime `
                                       -ForUpdate

    $suc = New-AzureRmAutomationSoftwareUpdateConfiguration  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Schedule $s `
                                                             -Windows `
                                                             -AzureVMResourceId $azureVMIdsW `
                                                             -Duration (New-TimeSpan -Hours 2)

    Assert-NotNull $suc "New-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $suc.Name $name "Name of created software update configuration didn't match given name"

    WaitForProvisioningState $name "Succeeded"
}

<#
Test-CreateLinuxOneTimeSoftwareUpdateConfigurationWithDefaults
#>
function Test-CreateLinuxOneTimeSoftwareUpdateConfigurationWithDefaults {
    $name = "mo-onetime-02"
    $startTime = ([DateTime]::Now).AddMinutes(10)
	$s = New-AzureRmAutomationSchedule -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Name $name `
                                       -Description test-OneTime `
                                       -OneTime `
                                       -StartTime $startTime `
                                       -ForUpdate

    $suc = New-AzureRmAutomationSoftwareUpdateConfiguration  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Schedule $s `
                                                             -Linux `
                                                             -AzureVMResourceId $azureVMIdsL `
                                                             -Duration (New-TimeSpan -Hours 2)

    Assert-NotNull $suc "New-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $suc.Name $name "Name of created software update configuration didn't match given name"

    WaitForProvisioningState $name "Succeeded"
}

<#
Test-CreateWindowsOneTimeSoftwareUpdateConfigurationWithAllOption
#>
function Test-CreateWindowsOneTimeSoftwareUpdateConfigurationWithAllOption {
    $name = "mo-onetime-03"
    $startTime = ([DateTime]::Now).AddMinutes(10)
	$s = New-AzureRmAutomationSchedule -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Name $name `
                                       -Description test-OneTime `
                                       -OneTime `
                                       -StartTime $startTime `
                                       -ForUpdate

    $suc = New-AzureRmAutomationSoftwareUpdateConfiguration  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Schedule $s `
                                                             -Windows `
                                                             -AzureVMResourceId $azureVMIdsW `
                                                             -NonAzureComputer $nonAzurecomputers `
                                                             -Duration (New-TimeSpan -Hours 2) `
                                                             -IncludedUpdateClassification Security,UpdateRollup `
                                                             -ExcludedKbNumber KB01,KB02 `
                                                             -IncludedKbNumber KB100

    Assert-NotNull $suc "New-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $suc.Name $name "Name of created software update configuration didn't match given name"

    WaitForProvisioningState $name "Failed"
}

<#
Test-CreateLinuxOneTimeSoftwareUpdateConfigurationWithAllOption
#>
function Test-CreateLinuxOneTimeSoftwareUpdateConfigurationWithAllOption {
    $name = "mo-onetime-04"
    $startTime = ([DateTime]::Now).AddMinutes(10)
	$s = New-AzureRmAutomationSchedule -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Name $name `
                                       -Description test-OneTime `
                                       -OneTime `
                                       -StartTime $startTime `
                                       -ForUpdate

    $suc = New-AzureRmAutomationSoftwareUpdateConfiguration  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Schedule $s `
                                                             -Linux `
                                                             -AzureVMResourceId $azureVMIdsL `
                                                             -NonAzureComputer $nonAzurecomputers `
                                                             -Duration (New-TimeSpan -Hours 2) `
                                                             -IncludedPackageClassification Security,Critical `
                                                             -ExcludedPackageNameMask Mask01,Mask02 `
                                                             -IncludedPackageNameMask Mask100

    Assert-NotNull $suc "New-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $suc.Name $name "Name of created software update configuration didn't match given name"

    WaitForProvisioningState $name "Failed"
}

<#
Test-CreateLinuxOneTimeSoftwareUpdateConfigurationNonAzureOnly
#>
function Test-CreateLinuxOneTimeSoftwareUpdateConfigurationNonAzureOnly {
    $name = "mo-onetime-05"
    $startTime = ([DateTime]::Now).AddMinutes(10)
	$s = New-AzureRmAutomationSchedule -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Name $name `
                                       -Description test-OneTime `
                                       -OneTime `
                                       -StartTime $startTime `
                                       -ForUpdate

    $suc = New-AzureRmAutomationSoftwareUpdateConfiguration  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Schedule $s `
                                                             -Linux `
                                                             -NonAzureComputer $nonAzurecomputers `
                                                             -Duration (New-TimeSpan -Hours 2) `
                                                             -IncludedPackageClassification Security,Critical `
                                                             -ExcludedPackageNameMask Mask01,Mask02 `
                                                             -IncludedPackageNameMask Mask100

    Assert-NotNull $suc "New-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $suc.Name $name "Name of created software update configuration didn't match given name"

    WaitForProvisioningState $name "Failed"
}

<#
Test-CreateLinuxOneTimeSoftwareUpdateConfigurationNoTargets
#>
function Test-CreateLinuxOneTimeSoftwareUpdateConfigurationNoTargets {
    $name = "mo-onetime-05"
    $startTime = ([DateTime]::Now).AddMinutes(10)
	$s = New-AzureRmAutomationSchedule -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Name $name `
                                       -Description test-OneTime `
                                       -OneTime `
                                       -StartTime $startTime `
                                       -ForUpdate

    Assert-Throws {
        $suc = New-AzureRmAutomationSoftwareUpdateConfiguration  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Schedule $s `
                                                             -Linux `
                                                             -Duration (New-TimeSpan -Hours 2) `
                                                             -IncludedPackageClassification Security,Critical `
                                                             -ExcludedPackageNameMask Mask01,Mask02 `
                                                             -IncludedPackageNameMask Mask100 `
                                                             -PassThru -ErrorAction Stop
    }
}


<#
Test-GetAllSoftwareUpdateConfigurations
#>
function Test-GetAllSoftwareUpdateConfigurations {
    $sucs = Get-AzureRmAutomationSoftwareUpdateConfiguration -ResourceGroupName $rg `
                                                              -AutomationAccountName $aa
    Assert-AreEqual $sucs.Count 7 "Get all software update configuration didn't retrieve the expected number of items"
}


<#
Test-GetSoftwareUpdateConfigurationsForVM
#>
function Test-GetSoftwareUpdateConfigurationsForVM {
    $sucs = Get-AzureRmAutomationSoftwareUpdateConfiguration -ResourceGroupName $rg `
                                                              -AutomationAccountName $aa `
                                                              -AzureVMResourceId $azureVMIdsW[0]
    Assert-AreEqual $sucs.Count 2 "Get software update configurations for VM didn't return expected number of items"
}


<#
Test-DeleteSoftwareUpdateConfiguration
#>
function Test-DeleteSoftwareUpdateConfiguration {
    $name = "mo-delete-it"
    $startTime = ([DateTime]::Now).AddMinutes(10)
	$s = New-AzureRmAutomationSchedule -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Name $name `
                                       -Description test-OneTime `
                                       -OneTime `
                                       -StartTime $startTime `
                                       -ForUpdate

    New-AzureRmAutomationSoftwareUpdateConfiguration  -ResourceGroupName $rg `
                                                      -AutomationAccountName $aa `
                                                      -Schedule $s `
                                                      -Windows `
                                                      -AzureVMResourceId $azureVMIdsW `
                                                      -Duration (New-TimeSpan -Hours 2) `
													  -IncludedUpdateClassification Critical
    WaitForProvisioningState $name "Succeeded"
    Remove-AzureRmAutomationSoftwareUpdateConfiguration   -ResourceGroupName $rg `
                                                          -AutomationAccountName $aa `
                                                          -Name $name
    Wait-Seconds 5
	Assert-Throws { 
		Get-AzureRmAutomationSoftwareUpdateConfiguration   -ResourceGroupName $rg `
                                                           -AutomationAccountName $aa `
                                                           -Name $name
	}
}

<#
Test-GetAllSoftwareUpdateRuns
#>
function Test-GetAllSoftwareUpdateRuns {
    $runs = Get-AzureRmAutomationSoftwareUpdateRun  -ResourceGroupName $rg `
                                                    -AutomationAccountName $aa
    
    Assert-AreEqual $runs.Count 13 "Get software update configurations runs didn't return expected number of items"
}


<#
Test-GetAllSoftwareUpdateRunsWithFilters
#>
function Test-GetAllSoftwareUpdateRunsWithFilters {
    $runs = Get-AzureRmAutomationSoftwareUpdateRun  -ResourceGroupName $rg `
                                                    -AutomationAccountName $aa `
                                                    -OperatingSystem Windows `
                                                    -StartTime ([DateTime]::Parse("2018-05-22T16:40:00")) `
                                                    -Status Succeeded

    Assert-AreEqual $runs.Count 2 "Get software update configurations runs with filters didn't return expected number of items"
}

<#
Test-GetAllSoftwareUpdateRunsWithFiltersNoResults
#>
function Test-GetAllSoftwareUpdateRunsWithFiltersNoResults {
    $runs = Get-AzureRmAutomationSoftwareUpdateRun  -ResourceGroupName $rg `
                                                    -AutomationAccountName $aa `
                                                    -OperatingSystem Windows `
                                                    -StartTime ([DateTime]::Parse("2018-05-22T16:40:00.0000000-07:00")) `
                                                    -Status Failed

    Assert-AreEqual $runs.Count 0 "Get software update configurations runs with filters and no results didn't return expected number of items"
}


<#
Test-GetAllSoftwareUpdateMachineRuns
#>
function Test-GetAllSoftwareUpdateMachineRuns {
    $runs = Get-AzureRmAutomationSoftwareUpdateMachineRun  -ResourceGroupName $rg `
                                                           -AutomationAccountName $aa
    
    Assert-AreEqual $runs.Count 18 "Get software update configurations machine runs didn't return expected number of items"
}

<#
Test-GetAllSoftwareUpdateMachineRunsWithFilters
#>
function Test-GetAllSoftwareUpdateMachineRunsWithFilters {
    $runs = Get-AzureRmAutomationSoftwareUpdateMachineRun  -ResourceGroupName $rg `
                                                           -AutomationAccountName $aa `
                                                           -SoftwareUpdateRunId b4ec6c22-92bf-4f8a-b2d9-20d8446e618a `
                                                           -Status Succeeded `
                                                           -TargetComputer $azureVMIdsW[0]

    Assert-AreEqual $runs.Count 1 "Get software update configurations machine runs with filters didn't return expected number of items"
}

<#
Test-GetAllSoftwareUpdateMachineRunsWithFiltersNoResults
#>
function Test-GetAllSoftwareUpdateMachineRunsWithFiltersNoResults {
    $runs = Get-AzureRmAutomationSoftwareUpdateMachineRun  -ResourceGroupName $rg `
                                                           -AutomationAccountName $aa `
                                                           -SoftwareUpdateRunId b4ec6c22-92bf-4f8a-b2d9-20d8446e618a `
                                                           -Status Succeeded `
                                                           -TargetComputer foo

    Assert-AreEqual $runs.Count 0 "Get software update configurations machine runs with filters and no results didn't return expected number of items"
}

<#
Test-CreateLinuxWeeklySoftwareUpdateConfigurationWithDefaults
#>
function Test-CreateLinuxWeeklySoftwareUpdateConfiguration() {
    $name = "mo-weekly-01"
    $startTime = ([DateTime]::Now).AddMinutes(10)
    $duration = New-TimeSpan -Hours 2
	$s = New-AzureRmAutomationSchedule -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Name $name `
                                       -Description test-OneTime `
                                       -WeekInterval 1 `
                                       -DaysOfWeek Friday `
                                       -StartTime $startTime `
                                       -ForUpdate

    $suc = New-AzureRmAutomationSoftwareUpdateConfiguration  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Schedule $s `
                                                             -Linux `
                                                             -AzureVMResourceId $azureVMIdsL `
                                                             -Duration $duration `
                                                             -IncludedPackageClassification Other,Security `
                                                             -ExcludedPackageNameMask @("Mask-exc-01", "Mask-exc-02")


    Assert-NotNull $suc "New-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $suc.Name $name "Name of created software update configuration didn't match given name"
    Assert-NotNull $suc.UpdateConfiguration "UpdateConfiguration of the software update configuration object is null"
    Assert-NotNull $suc.ScheduleConfiguration "ScheduleConfiguration of the software update configuration object is null"
    Assert-AreEqual $suc.ProvisioningState "Provisioning" "software update configuration provisioning state was not expected"
    Assert-AreEqual $suc.UpdateConfiguration.OperatingSystem "Linux" "UpdateConfiguration Operating system is not expected"
    Assert-AreEqual $suc.UpdateConfiguration.Duration $duration "UpdateConfiguration Duration is not expected"
    Assert-AreEqual $suc.UpdateConfiguration.AzureVirtualMachines.Count 2 "UpdateConfiguration created doesn't have the correct number of azure virtual machines"
    Assert-AreEqual $suc.UpdateConfiguration.NonAzureComputers.Count 0 "UpdateConfiguration doesn't have correct value of NonAzureComputers"
    Assert-NotNull $suc.UpdateConfiguration.Linux "Linux property of UpdateConfiguration is null"
    Assert-AreEqual $suc.UpdateConfiguration.Linux.IncludedPackageClassifications.Count 2 "Invalid UpdateConfiguration.Linux.IncludedPackageClassifications.Count"
    Assert-AreEqual $suc.UpdateConfiguration.Linux.IncludedPackageClassifications[0] Security "Invalid value of UpdateConfiguration.Linux.IncludedPackageClassifications[0]"
    Assert-AreEqual $suc.UpdateConfiguration.Linux.IncludedPackageClassifications[1] Other "Invalid value of UpdateConfiguration.Linux.IncludedPackageClassifications[1]"
    Assert-AreEqual $suc.UpdateConfiguration.Linux.ExcludedPackageNameMasks.Count 2
    Assert-AreEqual $suc.UpdateConfiguration.Linux.ExcludedPackageNameMasks[0] "Mask-exc-01"
    Assert-AreEqual $suc.UpdateConfiguration.Linux.ExcludedPackageNameMasks[1] "Mask-exc-02"

    WaitForProvisioningState $name "Succeeded"
}

<#
Test-CreateWindowsMonthlySoftwareUpdateConfiguration
#>
function Test-CreateWindowsMonthlySoftwareUpdateConfiguration() {
    $name = "mo-monthly-01"
    $startTime = ([DateTime]::Now).AddMinutes(10)
    $duration = New-TimeSpan -Hours 2
	$s = New-AzureRmAutomationSchedule -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Name $name `
                                       -Description test-OneTime `
                                       -MonthInterval 1 `
                                       -DaysOfMonth Two,Five `
                                       -StartTime $startTime `
                                       -ForUpdate

    $suc = New-AzureRmAutomationSoftwareUpdateConfiguration  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Schedule $s `
                                                             -Windows `
                                                             -AzureVMResourceId $azureVMIdsW `
                                                             -Duration $duration `
                                                             -IncludedUpdateClassification Critical,Security `
                                                             -ExcludedKbNumber @("KB-01", "KB-02")


    Assert-NotNull $suc "New-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $suc.Name $name "Name of created software update configuration didn't match given name"
    Assert-NotNull $suc.UpdateConfiguration "UpdateConfiguration of the software update configuration object is null"
    Assert-NotNull $suc.ScheduleConfiguration "ScheduleConfiguration of the software update configuration object is null"
    Assert-AreEqual $suc.ProvisioningState "Provisioning" "software update configuration provisioning state was not expected"
    Assert-AreEqual $suc.UpdateConfiguration.OperatingSystem "Windows" "UpdateConfiguration Operating system is not expected"
    Assert-AreEqual $suc.UpdateConfiguration.Duration $duration "UpdateConfiguration Duration is not expected"
    Assert-AreEqual $suc.UpdateConfiguration.AzureVirtualMachines.Count 2 "UpdateConfiguration created doesn't have the correct number of azure virtual machines"
    Assert-AreEqual $suc.UpdateConfiguration.NonAzureComputers.Count 0 "UpdateConfiguration doesn't have correct value of NonAzureComputers"
    Assert-NotNull $suc.UpdateConfiguration.Windows "Linux property of UpdateConfiguration is null"
    Assert-AreEqual $suc.UpdateConfiguration.Windows.IncludedUpdateClassifications.Count 2 "Invalid UpdateConfiguration.Linux.IncludedPackageClassifications.Count"
    Assert-AreEqual $suc.UpdateConfiguration.Windows.IncludedUpdateClassifications[0] Critical "Invalid value of UpdateConfiguration.Linux.IncludedPackageClassifications[0]"
    Assert-AreEqual $suc.UpdateConfiguration.Windows.IncludedUpdateClassifications[1] Security "Invalid value of UpdateConfiguration.Linux.IncludedPackageClassifications[1]"
    Assert-AreEqual $suc.UpdateConfiguration.Windows.ExcludedKbNumbers.Count 2
    Assert-AreEqual $suc.UpdateConfiguration.Windows.ExcludedKbNumbers[0] "KB-01"
    Assert-AreEqual $suc.UpdateConfiguration.Windows.ExcludedKbNumbers[1] "KB-02"

    WaitForProvisioningState $name "Succeeded"
}

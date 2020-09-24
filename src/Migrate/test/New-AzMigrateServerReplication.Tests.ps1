$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMigrateServerReplication.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzMigrateServerReplication' {
    It 'ByNameDefaultUser' {
        $output = New-AzMigrateServerReplication -ResourceGroupName $env.srsResourceGroup -ProjectName $env.srsProjectName -MachineName $env.srsSDSMachineName -LicenseType $env.srsLicense -TargetResourceGroupId $env.srsTargetRGId -TargetNetworkId $env.srsTgtNId -TargetSubnetName default -TargetVMName $env.srsTgtVMName -DiskType $env.srsDiskType -OSDiskID $env.srsDiskId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ByNamePowerUser' {
        $OSDisk = New-AzMigrateDiskMapping -DiskID $env.srsDiskId -DiskType $env.srsDiskType -IsOSDisk 'true'
	$output = New-AzMigrateServerReplication -ResourceGroupName $env.srsResourceGroup -ProjectName $env.srsProjectName -MachineName $env.srsSDSMachineName -LicenseType $env.srsLicense -TargetResourceGroupId $env.srsTargetRGId -TargetNetworkId $env.srsTgtNId -TargetSubnetName default -TargetVMName $env.srsTgtVMName -DiskToInclude $OSDisk -PerformAutoResync true
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ByInputObjectDefaultUser' {
        $obj = Get-AzMigrateMachine -Name $env.srsSDSMachineName -ResourceGroupName $env.srsResourceGroup -SiteName $env.srsSDSSite
	$obj.Count | Should -BeGreaterOrEqual 1 
        $output = New-AzMigrateServerReplication -InputObject $obj -LicenseType $env.srsLicense -TargetResourceGroupId $env.srsTargetRGId -TargetNetworkId $env.srsTgtNId -TargetSubnetName default -TargetVMName $env.srsTgtVMName -DiskType $env.srsDiskType -OSDiskID $env.srsDiskId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ByIdDefaultUser' {
        $output = New-AzMigrateServerReplication -VMwareMachineId $env.srsSDSMachineId  -LicenseType $env.srsLicense -TargetResourceGroupId $env.srsTargetRGId -TargetNetworkId $env.srsTgtNId -TargetSubnetName default -TargetVMName $env.srsTgtVMName -DiskType $env.srsDiskType -OSDiskID $env.srsDiskId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ByIdPowerUser' {
	$OSDisk = New-AzMigrateDiskMapping -DiskID $env.srsDiskId -DiskType $env.srsDiskType -IsOSDisk 'true'
        $output = New-AzMigrateServerReplication -VMwareMachineId $env.srsSDSMachineId -LicenseType $env.srsLicense -TargetResourceGroupId $env.srsTargetRGId -TargetNetworkId $env.srsTgtNId -TargetSubnetName default -TargetVMName $env.srsTgtVMName -DiskToInclude $OSDisk -PerformAutoResync true
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ByInputObjectPowerUser' {
        $OSDisk = New-AzMigrateDiskMapping -DiskID $env.srsDiskId -DiskType $env.srsDiskType -IsOSDisk 'true'
 	$obj = Get-AzMigrateMachine -Name $env.srsSDSMachineName -ResourceGroupName $env.srsResourceGroup -SiteName $env.srsSDSSite
	$obj.Count | Should -BeGreaterOrEqual 1 
        $output = New-AzMigrateServerReplication -InputObject $obj -LicenseType $env.srsLicense -TargetResourceGroupId $env.srsTargetRGId -TargetNetworkId $env.srsTgtNId -TargetSubnetName default -TargetVMName $env.srsTgtVMName -DiskToInclude $OSDisk -PerformAutoResync true
        $output.Count | Should -BeGreaterOrEqual 1 
    }
}

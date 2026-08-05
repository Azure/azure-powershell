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

Describe 'New-AzMigrateServerReplication' -Tag 'LiveOnly' {
    It 'ByIdDefaultUser' {
         $output = New-AzMigrateServerReplication -MachineId $env.migGetSDSMachineID  -LicenseType $env.srsLicense -TargetResourceGroupId $env.migResourceGroupId -TargetNetworkId $env.migTestNetworkId -TargetSubnetName default -TargetVMName $env.srsTgtVMName -DiskType $env.srsDiskType -OSDiskID $env.srsDiskId1 -SubscriptionId $env.migSubscriptionId
         $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ByIdPowerUser' {
        $OSDisk = New-AzMigrateDiskMapping -DiskID $env.srsDiskId1 -DiskType $env.srsDiskType -IsOSDisk 'true'
        $output = New-AzMigrateServerReplication -MachineId $env.migGetSDSMachineID -LicenseType $env.srsLicense -TargetResourceGroupId $env.migResourceGroupId -TargetNetworkId $env.migTestNetworkId -TargetSubnetName default -TargetVMName $env.srsTgtVMName -DiskToInclude $OSDisk -PerformAutoResync true -SubscriptionId $env.migSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ByInputObjectDefaultUser' {
        $obj = Get-AzMigrateDiscoveredServer  -ResourceGroupName $env.migResourceGroup -ProjectName $env.migProjectName -SubscriptionId $env.migSubscriptionId
    $obj.Count | Should -BeGreaterOrEqual 1 
        $temp = ""
        foreach($ob in $obj){if($ob.Id -eq $env.migGetSDSMachineID){$temp = $ob}}
        $output = New-AzMigrateServerReplication -InputObject $temp -LicenseType $env.srsLicense -TargetResourceGroupId $env.migResourceGroupId -TargetNetworkId $env.migTestNetworkId -TargetSubnetName default -TargetVMName $env.srsTgtVMName -DiskType $env.srsDiskType -OSDiskID $env.srsDiskId1 -SubscriptionId $env.migSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ByInputObjectPowerUser' {
        $OSDisk = New-AzMigrateDiskMapping -DiskID $env.srsDiskId1 -DiskType $env.srsDiskType -IsOSDisk 'true'
        $obj = Get-AzMigrateDiscoveredServer  -ResourceGroupName $env.migResourceGroup -ProjectName $env.migProjectName -SubscriptionId $env.migSubscriptionId
        $obj.Count | Should -BeGreaterOrEqual 1 
        $temp = ""
        foreach($ob in $obj){if($ob.Id -eq $env.migGetSDSMachineID){$temp = $ob}}
        $output = New-AzMigrateServerReplication -InputObject $temp -LicenseType $env.srsLicense -TargetResourceGroupId $env.migResourceGroupId -TargetNetworkId $env.migTestNetworkId -TargetSubnetName default -TargetVMName $env.srsTgtVMName -DiskToInclude $OSDisk -PerformAutoResync true -SubscriptionId $env.migSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }
}

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
    It 'ByIdDefaultUser' {
         $output = New-AzMigrateServerReplication -MachineId $env.srsSDSMachineId  -LicenseType $env.srsLicense -TargetResourceGroupId $env.srsTargetRGId -TargetNetworkId $env.srsTgtNId -TargetSubnetName default -TargetVMName $env.srsTgtVMName -DiskType $env.srsDiskType -OSDiskID $env.srsDiskId -SubscriptionId $env.srsSubscriptionId
         $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ByIdPowerUser' {
        $OSDisk = New-AzMigrateDiskMapping -DiskID $env.srsDiskId -DiskType $env.srsDiskType -IsOSDisk 'true'
        $output = New-AzMigrateServerReplication -MachineId $env.srsSDSMachineId -LicenseType $env.srsLicense -TargetResourceGroupId $env.srsTargetRGId -TargetNetworkId $env.srsTgtNId -TargetSubnetName default -TargetVMName $env.srsTgtVMName -DiskToInclude $OSDisk -PerformAutoResync true -SubscriptionId $env.srsSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ByInputObjectDefaultUser' -Skip{
        $obj = Get-AzMigrateDiscoveredServer  -ResourceGroupName $env.srsResourceGroup -ProjectName $env.srsProjectName -SubscriptionId $env.srsSubscriptionId
	$obj.Count | Should -BeGreaterOrEqual 1 
        $temp = ""
        foreach($ob in $obj){if($ob.Id -eq $env.srsSDSMachineId){$temp = $ob}}
        $output = New-AzMigrateServerReplication -InputObject $temp -LicenseType $env.srsLicense -TargetResourceGroupId $env.srsTargetRGId -TargetNetworkId $env.srsTgtNId -TargetSubnetName default -TargetVMName $env.srsTgtVMName -DiskType $env.srsDiskType -OSDiskID $env.srsDiskId -SubscriptionId $env.srsSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ByInputObjectPowerUser' -Skip{
        $OSDisk = New-AzMigrateDiskMapping -DiskID $env.srsDiskId -DiskType $env.srsDiskType -IsOSDisk 'true'
 	$obj = Get-AzMigrateDiscoveredServer  -ResourceGroupName $env.srsResourceGroup -ProjectName $env.srsProjectName -SubscriptionId $env.srsSubscriptionId
	$obj.Count | Should -BeGreaterOrEqual 1 
        $temp = ""
        foreach($ob in $obj){if($ob.Id -eq $env.srsSDSMachineId){$temp = $ob}}
        $output = New-AzMigrateServerReplication -InputObject $temp -LicenseType $env.srsLicense -TargetResourceGroupId $env.srsTargetRGId -TargetNetworkId $env.srsTgtNId -TargetSubnetName default -TargetVMName $env.srsTgtVMName -DiskToInclude $OSDisk -PerformAutoResync true -SubscriptionId $env.srsSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }
}

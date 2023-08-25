if(($null -eq $TestName) -or ($TestName -contains 'New-AzMigrateHCIServerReplication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMigrateHCIServerReplication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMigrateHCIServerReplication' {
    It 'ByIdDefaultUser' {
        $output = New-AzMigrateHCIServerReplication -MachineId $env.hciSDSMachineId1 -TargetResourceGroupId $env.hciTargetRGId -TargetVMName $env.hciTgtVMName1 -TargetStoragePathId $env.hciTgtStoragePathId -TargetVirtualSwitch $env.hciTgtVirtualSwitchId -OSDiskID $env.hciDiskId1 -SubscriptionId $env.hciSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ByIdPowerUser' {
        $OSDisk = New-AzMigrateHCIDiskMapping -DiskID $env.hciDiskId2 -IsOSDisk 'true' -IsDynamic 'true' -Size 1 -Format 'VHDX'
        $Nic = New-AzMigrateHCINicMapping -NicID $env.hciNicId -TargetNetworkId $env.hciTgtVirtualSwitchId
        $output = New-AzMigrateHCIServerReplication -MachineId $env.hciSDSMachineId2 -TargetResourceGroupId $env.hciTargetRGId -TargetVMName $env.hciTgtVMName2 -TargetStoragePathId $env.hciTgtStoragePathId -DiskToInclude $OSDisk -NicToInclude $Nic -SubscriptionId $env.hciSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }
}

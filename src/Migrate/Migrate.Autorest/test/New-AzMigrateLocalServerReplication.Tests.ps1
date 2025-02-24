if(($null -eq $TestName) -or ($TestName -contains 'New-AzMigrateLocalServerReplication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMigrateLocalServerReplication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMigrateLocalServerReplication' -Tag 'LiveOnly' {
    It 'ByIdDefaultUser' {
        $output = New-AzMigrateLocalServerReplication `
            -MachineId $env.hciSDSMachineId1 `
            -TargetResourceGroupId $env.hciTargetRGId `
            -TargetVMName $env.hciTgtVMName1 `
            -TargetStoragePathId $env.hciTgtStoragePathId `
            -TargetVirtualSwitchId $env.hciTgtVirtualSwitchId `
            -OSDiskID $env.hciDiskId1 `
            -SubscriptionId $env.hciSubscriptionId `
            -IsDynamicMemoryEnabled "true"
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ByIdPowerUser' {
        $diskToInclude = New-AzMigrateLocalDiskMappingObject -DiskID $env.hciDiskId2 -IsOSDisk "true" -IsDynamic "true" -Size 1 -Format "VHDX"
        $nicToInclude = New-AzMigrateLocalNicMappingObject -NicID $env.hciNicId2 -TargetVirtualSwitchId $env.hciTgtVirtualSwitchId
        $output = New-AzMigrateLocalServerReplication `
            -MachineId $env.hciSDSMachineId2 `
            -TargetResourceGroupId $env.hciTargetRGId `
            -TargetVMName $env.hciTgtVMName2 `
            -TargetStoragePathId $env.hciTgtStoragePathId `
            -DiskToInclude $diskToInclude `
            -NicToInclude $nicToInclude `
            -SubscriptionId $env.hciSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }
}

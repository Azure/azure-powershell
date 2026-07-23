if(($null -eq $TestName) -or ($TestName -contains 'AzScVmmVMDisk'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzScVmmVMDisk.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzScVmmVMDisk' -Tag 'LiveOnly' {
    It 'AddVMDisk - Add-AzScVmmVMDisk' {
        {
            Stop-AzScVmmVM -Name $env.VmName -ResourceGroupName $env.ResourceGroupVmTest

            $result = Add-AzScVmmVMDisk -ResourceGroupName $env.ResourceGroupVmTest -vmName $env.VmName -DiskName $env.DiskName -diskSizeGB 20 -bus 0 -lun 0
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.StorageProfileDisk.Count | Should -Be 2
            $result.StorageProfileDisk.Name | Should -Contain $env.DiskName
            ($result.StorageProfileDisk | Where-Object { $_.Name -eq $env.DiskName }).maxDiskSizeGB | Should -Be 20
        } | Should -Not -Throw
    }

    It 'ListVMDisk - Get-AzScVmmVMDisk' {
        {
            $result = Get-AzScVmmVMDisk -ResourceGroupName $env.ResourceGroupVmTest -vmName $env.VmName
            $result.Count | Should -Be 2 
        } | Should -Not -Throw
    }

    It 'UpdateVMDisk - Update-AzScVmmVMDisk' {
        {
            $result = Update-AzScVmmVMDisk -ResourceGroupName $env.ResourceGroupVmTest -vmName $env.VmName -DiskName $env.DiskName -diskSizeGB 40
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.StorageProfileDisk.Count | Should -Be 2
            $result.StorageProfileDisk.Name | Should -Contain $env.DiskName
            ($result.StorageProfileDisk | Where-Object { $_.Name -eq $env.DiskName }).maxDiskSizeGB | Should -Be 40
        } | Should -Not -Throw
    }

    It 'GetVMDisk - Get-AzScVmmVMDisk' {
        {
            $result = Get-AzScVmmVMDisk -ResourceGroupName $env.ResourceGroupVmTest -vmName $env.VmName -DiskName $env.DiskName
            $result.Name | Should -Be $env.DiskName
        } | Should -Not -Throw
    }

    It 'RemoveVMDisk - Remove-AzScVmmVMDisk' {
        {
            $result = Remove-AzScVmmVMDisk -ResourceGroupName $env.ResourceGroupVmTest -vmName $env.VmName -DiskName $env.DiskName
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.StorageProfileDisk.Count | Should -Be 1
        } | Should -Not -Throw
    }
}

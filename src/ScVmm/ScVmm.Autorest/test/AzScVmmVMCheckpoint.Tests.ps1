if(($null -eq $TestName) -or ($TestName -contains 'AzScVmmVMCheckpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzScVmmVMCheckpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzScVmmVMCheckpoint' -Tag 'LiveOnly' {
    It 'NewVMCheckpoint - New-AzScVmmVMCheckpoint' {
        {
            # Update VM calls requires VM to be in powered off state
            $result = Get-AzScVmmVM -Name $env.VmName -ResourceGroupName $env.ResourceGroupVmTest
            $result.ProvisioningState | Should -Be 'Succeeded'
            Stop-AzScVmmVM -Name $env.VmName -ResourceGroupName $env.ResourceGroupVmTest

            New-AzScVmmVMCheckpoint -ResourceGroupName $env.ResourceGroupVmTest -Name $env.VmName -CheckpointName $env.CheckpointName -CheckpointDescription $env.CheckpointDescription
            
            $result = Get-AzScVmmVM -Name $env.VmName -ResourceGroupName $env.ResourceGroupVmTest
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.InfrastructureProfileCheckpoint.Count | Should -Be 1
        } | Should -Not -Throw
    }

    It 'Update VM - Update-AzScVmmVM' {
        {
            $result = Update-AzScVmmVM -ResourceGroupName $env.ResourceGroupVmTest -Name $env.VmName -CpuCount 2 -MemoryMb 2048
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.HardwareProfileCpuCount | Should -Be 2
            $result.HardwareProfileMemoryMb | Should -Be 2048
        } | Should -Not -Throw
    }

    It 'RestoreVMCheckpoint - Restore-AzScVmmVMCheckpoint' {
        {
            $result = Get-AzScVmmVM -Name $env.VmName -ResourceGroupName $env.ResourceGroupVmTest
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.InfrastructureProfileCheckpoint.Count | Should -Be 1
            $checkPointId = $result.InfrastructureProfileCheckpoint[0].Id
            
            Restore-AzScVmmVMCheckpoint -ResourceGroupName $env.ResourceGroupVmTest -Name $env.VmName -CheckpointId $checkPointId
            
            $result = Get-AzScVmmVM -Name $env.VmName -ResourceGroupName $env.ResourceGroupVmTest
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.HardwareProfileCpuCount | Should -Be 4
            $result.HardwareProfileMemoryMb | Should -Be 4096
        } | Should -Not -Throw
    }

    Start-TestSleep -Seconds 10

    It 'RemoveVMCheckpoint Remove-AzScVmmVMCheckpoint' {
        {
            $result = Get-AzScVmmVM -Name $env.VmName -ResourceGroupName $env.ResourceGroupVmTest
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.InfrastructureProfileCheckpoint.Count | Should -Be 1
            $checkPointId = $result.InfrastructureProfileCheckpoint[0].Id

            Remove-AzScVmmVMCheckpoint -ResourceGroupName $env.ResourceGroupVmTest -Name $env.VmName -CheckpointId $checkPointId
            
            $result = Get-AzScVmmVM -Name $env.VmName -ResourceGroupName $env.ResourceGroupVmTest
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.InfrastructureProfileCheckpoint.Count | Should -Be 0
        } | Should -Not -Throw
    }
}

if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDisconnectedOperationsHardwareSetting'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDisconnectedOperationsHardwareSetting.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDisconnectedOperationsHardwareSetting' {
    It 'UpdateExpanded' {
        $result = Update-AzDisconnectedOperationsHardwareSetting -HardwareSettingName $env.HardwareSettingName -Name $env.Name -ResourceGroupName $env.ResourceGroupName -MemoryInGb 32

        $result | Should -Not -BeNullOrEmpty
        $result.MemoryInGb | Should -Be 32
        $result.Name | Should -Be $env.HardwareSettingName
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Type | Should -Be "microsoft.edge/disconnectedOperations/hardwareSettings"

        Update-AzDisconnectedOperationsHardwareSetting -HardwareSettingName $env.HardwareSettingName -Name $env.Name -ResourceGroupName $env.ResourceGroupName -MemoryInGb 64
    }

    It 'UpdateViaIdentityDisconnectedOperationExpanded' {
        $disconnectedOperationInputObject = @{
            "Name" = $env.Name;
            "ResourceGroupName" = $env.ResourceGroupName;
            "SubscriptionId" = $env.SubscriptionId;
        }

        $result = Update-AzDisconnectedOperationsHardwareSetting -HardwareSettingName $env.HardwareSettingName -DisconnectedOperationInputObject $disconnectedOperationInputObject -MemoryInGb 32

        $result | Should -Not -BeNullOrEmpty
        $result.MemoryInGb | Should -Be 32
        $result.Name | Should -Be $env.HardwareSettingName
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Type | Should -Be "microsoft.edge/disconnectedOperations/hardwareSettings"

        Update-AzDisconnectedOperationsHardwareSetting -HardwareSettingName $env.HardwareSettingName -DisconnectedOperationInputObject $disconnectedOperationInputObject -MemoryInGb 64
    }

    It 'UpdateViaIdentityExpanded' {
        $inputObject = @{
            "HardwareSettingName" = $env.HardwareSettingName;
            "Name" = $env.Name;
            "ResourceGroupName" = $env.ResourceGroupName;
            "SubscriptionId" = $env.SubscriptionId;
        }

        $result = Update-AzDisconnectedOperationsHardwareSetting -InputObject $inputObject -MemoryInGb 32

        $result | Should -Not -BeNullOrEmpty
        $result.MemoryInGb | Should -Be 32
        $result.Name | Should -Be $env.HardwareSettingName
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Type | Should -Be "microsoft.edge/disconnectedOperations/hardwareSettings"

        Update-AzDisconnectedOperationsHardwareSetting -InputObject $inputObject -MemoryInGb 64
    }
}

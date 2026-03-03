if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDisconnectedOperationsHardwareSetting'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDisconnectedOperationsHardwareSetting.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDisconnectedOperationsHardwareSetting' {
    It 'List'  {
        $result = Get-AzDisconnectedOperationsHardwareSetting -Name $env.Name -ResourceGroupName $env.ResourceGroupName

        $result | Should -Not -BeNull

        foreach ($hardwareSetting in $result) {
            $hardwareSetting | Should -Not -BeNullOrEmpty
            $hardwareSetting.Id | Should -Not -BeNullOrEmpty
            $hardwareSetting.Type | Should -Be "microsoft.edge/disconnectedOperations/hardwareSettings"
            $hardwareSetting.ResourceGroupName | Should -Be $env.ResourceGroupName
        }
    }

    It 'GetViaIdentityDisconnectedOperation' {
        $disconnectedOperations = @{
            "Name" = $env.Name;
            "ResourceGroupName" = $env.ResourceGroupName;
            "SubscriptionId" = $env.SubscriptionId;
        }

        $result = Get-AzDisconnectedOperationsHardwareSetting -HardwareSettingName $env.HardwareSettingName -DisconnectedOperationInputObject $disconnectedOperations

        $result | Should -Not -BeNull
        $result.Id | Should -Not -BeNullOrEmpty
        $result.Type | Should -Be "microsoft.edge/disconnectedOperations/hardwareSettings"
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
    }

    It 'Get' {
        $result = Get-AzDisconnectedOperationsHardwareSetting -HardwareSettingName $env.HardwareSettingName -Name $env.Name -ResourceGroupName $env.ResourceGroupName
        $result | Should -Not -BeNull
        $result.Id | Should -Not -BeNullOrEmpty
        $result.Type | Should -Be "microsoft.edge/disconnectedOperations/hardwareSettings"
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
    }

    It 'GetViaIdentity' {
        $inputObject = @{
            "HardwareSettingName" = $env.HardwareSettingName;
            "Name" = $env.Name;
            "ResourceGroupName" = $env.ResourceGroupName;
            "SubscriptionId" = $env.SubscriptionId;
        }

        $result = Get-AzDisconnectedOperationsHardwareSetting -InputObject $inputObject
        $result | Should -Not -BeNull
        $result.Id | Should -Not -BeNullOrEmpty
        $result.Type | Should -Be "microsoft.edge/disconnectedOperations/hardwareSettings"
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
    }
}

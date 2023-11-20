if(($null -eq $TestName) -or ($TestName -contains 'AzContainerAppConnectedEnv'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzContainerAppConnectedEnv.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzContainerAppConnectedEnv' {

    # Contains confidential information, please run it locally

    It 'CreateExpanded' -Skip {
        {
            $config = New-AzContainerAppConnectedEnv -Name $env.connectedEnv2 -ResourceGroupName $env.resourceGroupConnected -Location $env.location -ExtendedLocationName "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroupConnected)/providers/Microsoft.ExtendedLocation/customLocations/$($env.customLocation)" -ExtendedLocationType CustomLocation
            $config.Name | Should -Be $env.connectedEnv2
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzContainerAppConnectedEnv
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' -Skip {
        {
            $config = Get-AzContainerAppConnectedEnv -Name $env.connectedEnv2 -ResourceGroupName $env.resourceGroupConnected
            $config.Name | Should -Be $env.connectedEnv2
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzContainerAppConnectedEnv -ResourceGroupName $env.resourceGroupConnected
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzContainerAppConnectedEnv -Name $env.connectedEnv2 -ResourceGroupName $env.resourceGroupConnected
        } | Should -Not -Throw
    }
}

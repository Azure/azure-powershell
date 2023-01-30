if(($null -eq $TestName) -or ($TestName -contains 'Get-AzServiceLinkerConnector'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzServiceLinkerConnector.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzServiceLinkerConnector' {
    It 'List' -skip {
        $linkers = Get-AzServiceLinkerConnector -ResourceGroupName $env.resourceGroup -Location $env.location
        $linkers.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' -skip {
        $linker = Get-AzServiceLinkerConnector -ResourceGroupName $env.resourceGroup -Location $env.location -LinkerName $env.preparedLinker
        $linker.Name | Should -Be $env.preparedLinker
    }

    It 'GetViaIdentity' -skip {
        $identity = @{
            ResourceGroupName = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.App/containerApps/$($env.containerApp)"
            LinkerName = $env.preparedLinker
        }
        $linker = $identity | Get-AzServiceLinkerForContainerApp
        $linker.Name | Should -Be $env.preparedLinker
    }
}

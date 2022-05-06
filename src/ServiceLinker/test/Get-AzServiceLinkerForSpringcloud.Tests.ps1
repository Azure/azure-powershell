if(($null -eq $TestName) -or ($TestName -contains 'Get-AzServiceLinkerForSpringcloud'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzServiceLinkerForSpringcloud.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzServiceLinkerForSpringcloud' {
    It 'List' {
        $linkers = Get-AzServiceLinkerForSpringcloud -ResourceGroupName $env.resourceGroup -Service $env.spring -App $env.springApp
        $linkers.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $linker = Get-AzServiceLinkerForSpringcloud -ResourceGroupName $env.resourceGroup -Service $env.spring -App $env.springApp -LinkerName $env.preparedLinker
        $linker.Name | Should -Be $env.preparedLinker
    }

    It 'GetViaIdentity' -skip {
        $identity = @{
            ResourceUri = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.AppPlatform/Spring/$($env.spring)/apps/$($env.springApp)/deployments/default"
            LinkerName = $env.preparedLinker
        }
        $linker = $identity | Get-AzServiceLinkerForSpringcloud
        $linker.Name | Should -Be $env.preparedLinker
    }
}

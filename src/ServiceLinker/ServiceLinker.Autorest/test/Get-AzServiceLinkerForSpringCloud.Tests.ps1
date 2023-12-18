if(($null -eq $TestName) -or ($TestName -contains 'Get-AzServiceLinkerForSpringCloud'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzServiceLinkerForSpringCloud.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzServiceLinkerForSpringCloud' {
    It 'List' {
        $linkers = Get-AzServiceLinkerForSpringCloud -ResourceGroupName $env.resourceGroup -ServiceName $env.spring -AppName $env.springApp
        $linkers.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $linker = Get-AzServiceLinkerForSpringCloud -ResourceGroupName $env.resourceGroup -ServiceName $env.spring -AppName $env.springApp -LinkerName $env.preparedLinker
        $linker.Name | Should -Be $env.preparedLinker
    }

    It 'GetViaIdentity' {
        $identity = @{
            ResourceUri = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.AppPlatform/Spring/$($env.spring)/apps/$($env.springApp)/deployments/default"
            LinkerName = $env.preparedLinker
        }
        $linker = $identity | Get-AzServiceLinkerForSpringCloud
        $linker.Name | Should -Be $env.preparedLinker
    }
}

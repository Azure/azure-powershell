if(($null -eq $TestName) -or ($TestName -contains 'Get-AzServiceLinkerForWebApp'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzServiceLinkerForWebApp.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzServiceLinkerForWebApp' {
    It 'List' {
        $linkers = Get-AzServiceLinkerForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.preparedWebApp
        $linkers.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $linker = Get-AzServiceLinkerForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.preparedWebApp -LinkerName $env.preparedLinker
        $linker.Name | Should -Be $env.preparedLinker
    }

    It 'GetViaIdentity' {
        $identity = @{
            ResourceUri = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Web/sites/$($env.preparedWebApp)"
            LinkerName = $env.preparedLinker
        }
        $linker = $identity | Get-AzServiceLinkerForWebApp
        $linker.Name | Should -Be $env.preparedLinker
    }

}

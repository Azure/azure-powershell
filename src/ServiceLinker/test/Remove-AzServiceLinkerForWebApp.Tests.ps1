if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzServiceLinkerForWebApp'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzServiceLinkerForWebApp.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzServiceLinkerForWebApp' {
    It 'Delete' {
        $null = Remove-AzServiceLinkerForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.webapp  -LinkerName $env.newLinker
        
    }

    It 'DeleteViaIdentity' {
        $identity = @{
            ResourceUri = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Web/sites/$($env.webapp)"
            LinkerName = $env.newLinker
        }
        $null = $identity | Remove-AzServiceLinkerForWebApp
    }
}

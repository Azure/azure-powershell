if(($null -eq $TestName) -or ($TestName -contains 'Test-AzServiceLinkerForWebApp'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzServiceLinkerForWebApp.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzServiceLinkerForWebApp' {
    It 'Validate' {
        $result = Test-AzServiceLinkerForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.preparedWebApp -LinkerName $env.preparedLinker
    }

    It 'ValidateViaIdentity' {
        $identity = @{
            ResourceUri = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Web/sites/$($env.preparedWebApp)"
            LinkerName = $env.preparedLinker
        }
        $result = $identity | Test-AzServiceLinkerForWebApp
    }
}

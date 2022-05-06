if(($null -eq $TestName) -or ($TestName -contains 'Test-AzServiceLinkerForWebapp'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzServiceLinkerForWebapp.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzServiceLinkerForWebapp' {
    It 'Validate' {
        $result = Test-AzServiceLinkerForWebapp -ResourceGroupName $env.resourceGroup -Webapp $env.preparedWebapp -LinkerName $env.preparedLinker
    }

    It 'ValidateViaIdentity' {
        $identity = @{
            ResourceUri = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Web/sites/$($env.webapp)"
            LinkerName = $env.newLinker
        }
    }
}

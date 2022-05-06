if(($null -eq $TestName) -or ($TestName -contains 'Test-AzServiceLinkerForSpringcloud'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzServiceLinkerForSpringcloud.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzServiceLinkerForSpringcloud' {
    It 'Validate' {
        $result = Test-AzServiceLinkerForSpringcloud -ResourceGroupName $env.resourceGroup -Service $env.spring -App $env.springApp -LinkerName $env.preparedLinker
    }

    It 'ValidateViaIdentity' {
        $identity = @{
            ResourceUri = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.AppPlatform/Spring/$($env.spring)/apps/$($env.springApp)/deployments/default"
            LinkerName = $env.preparedLinker
        }
        $result = $identity | Test-AzServiceLinkerForSpringcloud
    }
}

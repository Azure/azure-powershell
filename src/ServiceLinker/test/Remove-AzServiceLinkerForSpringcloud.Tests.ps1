if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzServiceLinkerForSpringcloud'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzServiceLinkerForSpringcloud.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzServiceLinkerForSpringcloud' {
    It 'Delete' -skip {
        $null = Remove-AzServiceLinkerForSpringcloud -ResourceGroupName $env.resourceGroup -Service $env.spring -App $env.springApp -LinkerName $env.newLinker
    }

    It 'DeleteViaIdentity' -skip {
        $identity = @{
            ResourceUri = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.AppPlatform/Spring/$($env.spring)/apps/$($env.springApp)/deployments/default"
            LinkerName = $env.newLinker
        }
        $linker = $identity | Remove-AzServiceLinkerForSpringcloud
    }
}

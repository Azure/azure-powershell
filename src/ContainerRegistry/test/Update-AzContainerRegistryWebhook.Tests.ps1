if(($null -eq $TestName) -or ($TestName -contains 'Update-AzContainerRegistryWebhook'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzContainerRegistryWebhook.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzContainerRegistryWebhook' {
    It 'UpdateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update' -skip {
        New-AzContainerRegistryWebhook -RegistryName $rstr1 -ResourceGroupName $resourceGroup -Name $webhook3 -ServiceUri http://www.bing.com -Action Delete,Push -Location "east us" -Status Enabled -Scope "foo:*"
        { Update-azContainerRegistryReplication -RegistryName $env.rstr1 -ResourceGroupName  $env.resourceGroup -Name $env.replication3 -Uri "http://webhookuri.com" } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}

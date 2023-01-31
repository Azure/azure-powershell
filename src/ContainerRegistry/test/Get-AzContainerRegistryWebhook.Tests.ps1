if(($null -eq $TestName) -or ($TestName -contains 'Get-AzContainerRegistryWebhook'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzContainerRegistryWebhook.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzContainerRegistryWebhook' {
    It 'List' {
        {get-AzContainerRegistryWebhook -RegistryName $env.rstr1 -ResourceGroupName $env.ResourceGroup } | Should -Not -Throw
    }

    It 'Get'  {
        {get-AzContainerRegistryWebhook -RegistryName $env.rstr1 -ResourceGroupName $env.ResourceGroup -name $env.Webhook} | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}

if(($null -eq $TestName) -or ($TestName -contains 'Get-AzContainerRegistryWebhookEvent'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzContainerRegistryWebhookEvent.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzContainerRegistryWebhookEvent' {
    It 'List' {
        { Get-AzContainerRegistryWebhookEvent -RegistryName $env.rstr1 -ResourceGroupName $env.ResourceGroup -WebhookName $env.Webhook} | Should -Not -Throw
    }
}

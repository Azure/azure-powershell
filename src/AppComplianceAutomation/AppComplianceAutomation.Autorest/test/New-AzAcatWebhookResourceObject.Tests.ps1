if(($null -eq $TestName) -or ($TestName -contains 'New-AzAcatWebhookResourceObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAcatWebhookResourceObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzAcatWebhookResourceObject' {
    It '__AllParameterSets' {
        $secret = ConvertTo-SecureString $env.Secret -AsPlainText
        $webhookObj = New-AzAcatWebhookResourceObject -TriggerMode "all" -PayloadUrl $env.PayloadUrl -Secret $secret

        $webhookObj.PayloadUrl | Should -Be $env.PayloadUrl
        $webhookObj.ContentType | Should -Be "application/json"
        $webhookObj.EnableSslVerification | Should -Be "true"
        $webhookObj.Status | Should -Be "Enabled"
        $webhookObj.SendAllEvent | Should -Be "true"
        $webhookObj.Event.Count | Should -Be 0
        $webhookObj.UpdateWebhookKey | Should -Be "true"
        $webhookObj.WebhookKey | Should -Be $env.Secret
    }
}

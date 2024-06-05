if(($null -eq $TestName) -or ($TestName -contains 'New-AzAcatWebhook'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAcatWebhook.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzAcatWebhook' {
    It 'CreateExpanded' {
        $secret = ConvertTo-SecureString $env.Secret -AsPlainText
        $webhook = New-AzAcatWebhook -Name $env.WebhookName -ReportName $env.GeneratedReportName `
            -TriggerMode "all" -PayloadUrl $env.PayloadUrl -Secret $secret
        $webhook.Name | Should -Be $env.WebhookName
    }

    It 'Create' {
        $secret = ConvertTo-SecureString $env.Secret -AsPlainText
        $param = New-AzAcatWebhookResourceObject -TriggerMode "all" -PayloadUrl $env.PayloadUrl -Secret $secret
        $webhook = $param | New-AzAcatWebhook -Name $env.WebhookName -ReportName $env.GeneratedReportName
        $webhook.Name | Should -Be $env.WebhookName
    }
}

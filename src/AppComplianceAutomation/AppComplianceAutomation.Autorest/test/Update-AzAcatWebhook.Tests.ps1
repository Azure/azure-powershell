if(($null -eq $TestName) -or ($TestName -contains 'Update-AzAcatWebhook'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzAcatWebhook.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzAcatWebhook' {
    It 'UpdateExpanded' {
        $webhook = Update-AzAcatWebhook -Name $env.PreparedWebhookName -ReportName $env.GeneratedReportName `
            -TriggerMode "all" -PayloadUrl $env.NewPayloadUrl
        $webhook.PayloadUrl | Should -Be $env.NewPayloadUrl
    }

    It 'Update' {
        $oldWebhook = Get-AzAcatWebhook -Name $env.PreparedWebhookName -ReportName $env.GeneratedReportName
        $oldWebhook.PayloadUrl = $env.NewPayloadUrl
        $webhook = $oldWebhook | Update-AzAcatWebhook -Name $env.PreparedWebhookName -ReportName $env.GeneratedReportName
        $webhook.PayloadUrl | Should -Be $env.NewPayloadUrl
    }
}

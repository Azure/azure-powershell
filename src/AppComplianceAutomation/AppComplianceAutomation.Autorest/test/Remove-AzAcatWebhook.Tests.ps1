if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzAcatWebhook'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAcatWebhook.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzAcatWebhook' {
    It 'Delete' {
        New-AzAcatWebhook -Name $env.WebhookName -ReportName $env.GeneratedReportName `
            -TriggerMode "all" -PayloadUrl $env.PayloadUrl
        Remove-AzAcatWebhook -Name $env.WebhookName -ReportName $env.GeneratedReportName
    }
}

if(($null -eq $TestName) -or ($TestName -contains 'DiagnosticSetting'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'DiagnosticSetting.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'DiagnosticSetting' {
    It 'CRUD' {
        $metric = @()
        $log = @()
        $categories = Get-AzDiagnosticSettingCategory -ResourceId $env.vnetId
        $categories | ForEach-Object {if($_.CategoryType -eq "Metrics"){$metric+=New-AzDiagnosticSettingMetricSettingsObject -Enabled $true -Category $_.Name -RetentionPolicyDay 7 -RetentionPolicyEnabled $true} else{$log+=New-AzDiagnosticSettingLogSettingsObject -Enabled $true -Category $_.Name -RetentionPolicyDay 7 -RetentionPolicyEnabled $true}}
        $setting = New-AzDiagnosticSetting -Name $env.diagnosticSettingName -ResourceId $env.vnetId -WorkspaceId $env.workspaceId -Log $log -Metric $metric
        $setting = Get-AzDiagnosticSetting -Name $env.diagnosticSettingName -ResourceId $env.vnetId
        Remove-AzDiagnosticSetting -Name $env.diagnosticSettingName -ResourceId $env.vnetId
    }
}
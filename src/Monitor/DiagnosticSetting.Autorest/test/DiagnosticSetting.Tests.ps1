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
        $categories | ForEach-Object {if($_.CategoryType -eq "Metrics"){$metric+=New-AzDiagnosticSettingMetricSettingsObject -Enabled $true -Category $_.Name } else{$log+=New-AzDiagnosticSettingLogSettingsObject -Enabled $true -Category $_.Name }}
        New-AzDiagnosticSetting -Name $env.diagnosticSettingName -ResourceId $env.vnetId -WorkspaceId $env.workspaceId -Log $log -Metric $metric
        $setting = Get-AzDiagnosticSetting -Name $env.diagnosticSettingName -ResourceId $env.vnetId
        $setting.Name | Should -Be $env.diagnosticSettingName
        $setting.Log.Enabled | Should -Be $true
        $setting.Metric.Enabled | Should -Be $true
        
        $newlog = New-AzDiagnosticSettingLogSettingsObject -Enabled $false -Category $setting.Log.Category
        $newmetric = New-AzDiagnosticSettingMetricSettingsObject -Enabled $false -Category $setting.Metric.Category
        $setting = Update-AzDiagnosticSetting -Name $env.diagnosticSettingName -ResourceId $env.vnetId -Log $newlog -Metric $newmetric
        $setting.Log.Enabled | Should -Be $false
        $setting.Metric.Enabled | Should -Be $false
        Remove-AzDiagnosticSetting -Name $env.diagnosticSettingName -ResourceId $env.vnetId
    }

    It 'SubCRUD' {
        $log = New-AzDiagnosticSettingSubscriptionLogSettingsObject -Category Recommendation -Enabled $true
        $setting = New-AzSubscriptionDiagnosticSetting -Name $env.subscriptiondiagnosticSettingName -WorkspaceId $env.workspaceId -Log $log
        $setting.Name | Should -Be $env.subscriptiondiagnosticSettingName

        $newlog = New-AzDiagnosticSettingSubscriptionLogSettingsObject -Category Recommendation -Enabled $false
        $setting = Update-AzSubscriptionDiagnosticSetting -Name $env.subscriptiondiagnosticSettingName -Log $newlog
        $setting.Log.Enabled | Should -Be $false
        Get-AzSubscriptionDiagnosticSetting
        Remove-AzSubscriptionDiagnosticSetting -Name $env.subscriptiondiagnosticSettingName
    }
}
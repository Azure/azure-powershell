if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDataCollectionRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDataCollectionRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDataCollectionRule' {
    It 'UpdateExpanded' {
        {
            $syslog = New-AzSyslogDataSourceObject -FacilityName syslog -LogLevel Alert,Critical,Emergency -Name syslogBase -Stream Microsoft-Syslog
            $rule = Update-AzDataCollectionRule -Name $env.testCollectionRule1 -ResourceGroupName $env.resourceGroup -DataSourceSyslog $syslog -Tag @{"123"="abc"}
            $rule.DataSourceSyslog -eq $syslog
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $cronlog = New-AzSyslogDataSourceObject -FacilityName cron -LogLevel Debug,Critical,Emergency -Name cronSyslog -Stream Microsoft-Syslog
            $ruleGet = Get-AzDataCollectionRule -ResourceGroupName $env.resourceGroup -Name $env.testCollectionRule1
            $ruleResult = Update-AzDataCollectionRule -InputObject $ruleGet -DataSourceSyslog $cronlog
            $ruleResult.DataSourceSyslog -eq $cronlog
        } | Should -Not -Throw
    }
}

if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRecoveryServicesPolicyTemplate'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRecoveryServicesPolicyTemplate.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRecoveryServicesPolicyTemplate' {
    It '__AllParameterSets' {
        
        $tempPolicy = Get-AzRecoveryServicesPolicyTemplate -DatasourceType AzureVM
        $tempPolicy.SchedulePolicy.ScheduleRunTime[0].ToString() -eq "5/22/2023 2:00:00 PM" | Should be $true

        $tempPolicy = Get-AzRecoveryServicesPolicyTemplate -DatasourceType MSSQL
        $tempPolicy.SubProtectionPolicy[0].SchedulePolicy.ScheduleRunTime[0].ToString() -eq "9/30/2020 7:30:00 PM"

        $tempPolicy = Get-AzRecoveryServicesPolicyTemplate -DatasourceType SAPHANA
        $tempPolicy.SubProtectionPolicy[0].SchedulePolicy.ScheduleRunTime[0].ToString() -eq "9/30/2020 7:30:00 PM"
    }
}

if(($null -eq $TestName) -or ($TestName -contains 'New-AzMonitoringAccountDestinationObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMonitoringAccountDestinationObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMonitoringAccountDestinationObject' {
    It '__AllParameterSets' {
        {
            New-AzMonitoringAccountDestinationObject -AccountResourceId /subscriptions/da58aca0-2082-4f5a-85ba-27344286c17c/resourceGroups/mac-rg/providers/Microsoft.Monitor/accounts/mac-name1 -Name myMonitoringAccountDest1
        } | Should -Not -Throw
    }
}

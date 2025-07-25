if(($null -eq $TestName) -or ($TestName -contains 'New-AzWorkloadsSapLandscapeMonitorSidMappingObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWorkloadsSapLandscapeMonitorSidMappingObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWorkloadsSapLandscapeMonitorSidMappingObject' {
    It '__AllParameterSets' {
        $response = New-AzWorkloadsSapLandscapeMonitorSidMappingObject -Name Prod -TopSid "{SID2,SID1}"
        $response.Name | Should -Be "Prod"
    }
}

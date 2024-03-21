if(($null -eq $TestName) -or ($TestName -contains 'New-AzSecurityCspmMonitorGcpOfferingObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSecurityCspmMonitorGcpOfferingObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSecurityCspmMonitorGcpOfferingObject' {
    It '__AllParameterSets' {
        $offering = New-AzSecurityCspmMonitorGcpOfferingObject -NativeCloudConnectionServiceAccountEmailAddress "microsoft-defender-cspm@asc-sdk-samples.iam.gserviceaccount.com" -NativeCloudConnectionWorkloadIdentityProviderId "cspm"
        $offering.OfferingType | Should -Be "CspmMonitorGcp"
    }
}

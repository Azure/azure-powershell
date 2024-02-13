if(($null -eq $TestName) -or ($TestName -contains 'New-AzSecurityGcpProjectEnvironmentObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSecurityGcpProjectEnvironmentObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSecurityGcpProjectEnvironmentObject' {
    It '__AllParameterSets' {
        $orgData = New-AzSecurityGcpOrganizationalDataOrganizationObject -WorkloadIdentityProviderId "provider" -ServiceAccountEmailAddress "my@email.com" -ExcludedProjectNumber @(1,2)
        $environment = New-AzSecurityGcpProjectEnvironmentObject -ProjectDetailProjectId "asc-sdk-samples" -ScanInterval 24 -OrganizationalData $orgData -ProjectDetailProjectNumber "1234"
        $environment.EnvironmentType | Should -Be "GcpProject"
    }
}

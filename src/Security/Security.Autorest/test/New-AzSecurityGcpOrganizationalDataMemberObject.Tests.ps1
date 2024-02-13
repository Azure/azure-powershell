if(($null -eq $TestName) -or ($TestName -contains 'New-AzSecurityGcpOrganizationalDataMemberObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSecurityGcpOrganizationalDataMemberObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSecurityGcpOrganizationalDataMemberObject' {
    It '__AllParameterSets' {
        $env = New-AzSecurityGcpOrganizationalDataMemberObject -ManagementProjectNumber "12345" -ParentHierarchyId "00000"
        $env.OrganizationMembershipType | Should -Be "Member"
    }
}

if(($null -eq $TestName) -or ($TestName -contains 'New-AzSecurityAwsOrganizationalDataMemberObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSecurityAwsOrganizationalDataMemberObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSecurityAwsOrganizationalDataMemberObject' {
    It '__AllParameterSets' {
        $member = New-AzSecurityAwsOrganizationalDataMemberObject -ParentHierarchyId "123"
        $member.OrganizationMembershipType | Should -Be "Member"
    }
}

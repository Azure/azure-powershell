if(($null -eq $TestName) -or ($TestName -contains 'New-AzSecurityAwsEnvironmentObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSecurityAwsEnvironmentObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSecurityAwsEnvironmentObject' {
    It '__AllParameterSets' {
        $organization = New-AzSecurityAwsOrganizationalDataMasterObject -StacksetName "myAwsStackSet" -ExcludedAccountId "123456789012"
        $environment = New-AzSecurityAwsEnvironmentObject -Region "Central US" -ScanInterval 24 -OrganizationalData $organization
        $environment.EnvironmentType | Should -Be "AwsAccount"
        $environment.OrganizationalData.OrganizationMembershipType | Should -Be "Organization"

        $member = New-AzSecurityAwsOrganizationalDataMemberObject -ParentHierarchyId "123"
        $environment = New-AzSecurityAwsEnvironmentObject -Region "Central US" -ScanInterval 24 -OrganizationalData $member
        
        $environment.EnvironmentType | Should -Be "AwsAccount"
        $environment.OrganizationalData.OrganizationMembershipType | Should -Be "Member"
    }
}

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzConfluentOrganization.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzConfluentOrganization' {
    It 'List' {
      $confluentOrgList = Get-AzConfluentOrganization
      $confluentOrgList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
      $confluentOrg = Get-AzConfluentOrganization -ResourceGroupName $env.resourcegroup -Name $env.confluentOrgName00
      $confluentOrg.Name | Should -Be $env.confluentOrgName00
    }

    It 'List1' {
      $confluentOrgList = Get-AzConfluentOrganization -ResourceGroupName $env.resourcegroup
      $confluentOrgList.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
      $confluentOrg = Get-AzConfluentOrganization -ResourceGroupName $env.resourcegroup -Name $env.confluentOrgName00 
      $confluentOrg = Get-AzConfluentOrganization -InputObject $confluentOrg
      $confluentOrg.Name | Should -Be $env.confluentOrgName00    
    }
}

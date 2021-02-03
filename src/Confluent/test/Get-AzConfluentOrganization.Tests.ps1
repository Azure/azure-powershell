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
      $confluentOrgList.Count | Should -BeGreaterOrEqual 2
    }

    It 'Get' {
      $confluentOrg = Get-AzConfluentOrganization -ResourceGroupName $env.resourcegroup -Name $env.confluentOrgName00
      $confluentOrg.Name | Should -Be $env.confluentOrgName00
    }

    # Issue: Cannot list confluent organization under a resource group. The result is empty.
    It 'List1' {
        { Get-AzConfluentOrganization -ResourceGroupName $env.resourcegroup } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
      $confluentOrg = Get-AzConfluentOrganization -ResourceGroupName $env.resourcegroup -Name $env.confluentOrgName00 
      $confluentOrg = Get-AzConfluentOrganization -InputObject $confluentOrg
      $confluentOrg.Name | Should -Be $env.confluentOrgName00    
    }
}

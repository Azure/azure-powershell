$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzComputeFleetOrganization.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzComputeFleetOrganization' {
    It 'List' {
      $computefleetOrgList = Get-AzComputeFleetOrganization
      $computefleetOrgList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
      $computefleetOrg = Get-AzComputeFleetOrganization -ResourceGroupName $env.resourcegroup -Name $env.computefleetOrgName00
      $computefleetOrg.Name | Should -Be $env.computefleetOrgName00
    }

    It 'List1' {
      $computefleetOrgList = Get-AzComputeFleetOrganization -ResourceGroupName $env.resourcegroup
      $computefleetOrgList.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
      $computefleetOrg = Get-AzComputeFleetOrganization -ResourceGroupName $env.resourcegroup -Name $env.computefleetOrgName00 
      $computefleetOrg = Get-AzComputeFleetOrganization -InputObject $computefleetOrg
      $computefleetOrg.Name | Should -Be $env.computefleetOrgName00    
    }
}

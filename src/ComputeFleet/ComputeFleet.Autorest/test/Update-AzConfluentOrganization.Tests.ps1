$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzComputeFleetOrganization.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzComputeFleetOrganization' {
    It 'UpdateExpanded' {
      Update-AzComputeFleetOrganization -ResourceGroupName $env.resourceGroup -Name $env.computefleetOrgName00 -Tag @{"key01" = "value01"; "key02" = "value02"; "key03" = "value03"}
      $computefleetOrg =  Get-AzComputeFleetOrganization -ResourceGroupName $env.resourceGroup -Name $env.computefleetOrgName00
      $computefleetOrg.Tag.Count | Should -Be 3
    }

    It 'UpdateViaIdentityExpanded' {
      $computefleetOrg = Get-AzComputeFleetOrganization -ResourceGroupName $env.resourceGroup -Name $env.computefleetOrgName00 
      $computefleetOrg = Update-AzComputeFleetOrganization -InputObject $computefleetOrg -Tag @{"key01" = "value01"; "key02" = "value02"}
      $computefleetOrg =  Get-AzComputeFleetOrganization -ResourceGroupName $env.resourceGroup -Name $env.computefleetOrgName00
      $computefleetOrg.Tag.Count | Should -Be 2
    }
}

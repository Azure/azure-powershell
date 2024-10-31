$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzComputeFleetOrganization.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzComputeFleetOrganization' {
    # Skip test case because the cmdlet needs to be interactive to take consent from user 
    It 'Delete' -Skip {
      Remove-AzComputeFleetOrganization -ResourceGroupName $env.resourceGroup -Name $env.computefleetOrgName00
      $computefleetOrgList = Get-AzComputeFleetOrganization 
      $computefleetOrgList.Name | Should -Not -Contain $env.computefleetOrgName00
    }

    It 'DeleteViaIdentity' -Skip {
      $computefleetOrg = Get-AzComputeFleetOrganization -ResourceGroupName $env.resourceGroup -Name $env.computefleetOrgName01 
      Remove-AzComputeFleetOrganization -InputObject $computefleetOrg
      $computefleetOrgList = Get-AzComputeFleetOrganization 
      $computefleetOrgList.Name | Should -Not -Contain $env.computefleetOrgName01
    }
}

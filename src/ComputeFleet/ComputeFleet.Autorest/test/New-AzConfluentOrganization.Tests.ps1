$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzComputeFleetOrganization.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzComputeFleetOrganization' {
    It 'CreateExpanded' {
      New-AzComputeFleetOrganization -ResourceGroupName $env.resourceGroup -Name $env.computefleetOrgName00 -Location $env.location -OfferDetailId "computefleet-cloud-azure-prod" -OfferDetailPlanId "computefleet-cloud-azure-payg-prod" -OfferDetailPlanName "ComputeFleet Cloud - Pay as you Go" -OfferDetailPublisherId "computefleetinc" -OfferDetailTermUnit "P1M" -UserDetailEmailAddress $env.userEmail
      $computefleetOrg = Get-AzComputeFleetOrganization -ResourceGroupName $env.resourcegroup -Name $env.computefleetOrgName00
      $computefleetOrg.ProvisioningState | Should -Be 'Succeeded'
    }
}

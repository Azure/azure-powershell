$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzConfluentOrganization.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzConfluentOrganization' {
    It 'CreateExpanded' {
      New-AzConfluentOrganization -ResourceGroupName $env.resourceGroup -Name $env.confluentOrgName00 -Location $env.location -OfferDetailId "confluent-cloud-azure-prod" -OfferDetailPlanId "confluent-cloud-azure-payg-prod" -OfferDetailPlanName "Confluent Cloud - Pay as you Go" -OfferDetailPublisherId "confluentinc" -OfferDetailTermUnit "P1M" -UserDetailEmailAddress $env.userEmail
      $confluentOrg = Get-AzConfluentOrganization -ResourceGroupName $env.resourcegroup -Name $env.confluentOrgName00
      $confluentOrg.ProvisioningState | Should -Be 'Succeeded'
    }
}

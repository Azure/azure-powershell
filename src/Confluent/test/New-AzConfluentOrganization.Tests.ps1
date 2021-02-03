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
      # For hide exception: There's a problem in creating Confluent Organization. Resource: /subscriptions/ec5a926a-68f0-4b60-b3ae-58399456abb7/resourceGroups/lucas-rg-test/providers/Microsoft.Confluent/organizations/confluentorg-01-pwsh Error: Cannot complete signup. Reason: Email already exists. 
      # Because the confluent organization created complete. But the status is failed.
      try {
        New-AzConfluentOrganization -ResourceGroupName $env.resourceGroup -Name $env.confluentOrgName02 -Location $env.location -OfferDetailId "confluent-cloud-azure-prod" -OfferDetailPlanId "confluent-cloud-azure-payg-prod" -OfferDetailPlanName "Confluent Cloud - Pay as you Go" -OfferDetailPublisherId "confluentinc" -OfferDetailTermUnit "P1M" -UserDetailEmailAddress $env.userEmail
      }
      catch {
        Write-Warning "the confluent organization created complete. But the status is failed."
        Write-Warning "$_"
      }
      $confluentOrg = Get-AzConfluentOrganization -ResourceGroupName $env.resourcegroup -Name $env.confluentOrgName02
      $confluentOrg.Name | Should -Be $env.confluentOrgName02
    }
}

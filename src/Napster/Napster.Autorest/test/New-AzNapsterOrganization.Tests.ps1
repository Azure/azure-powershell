if(($null -eq $TestName) -or ($TestName -contains 'New-AzNapsterOrganization'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNapsterOrganization.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNapsterOrganization' {
    It 'CreateExpanded' {
        {
            try {
                New-AzNapsterOrganization -Name $env.NewResourceName -Location $env.Location -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -MarketplaceSubscriptionId $env.MarketplaceSubscriptionId -OfferDetailOfferId $env.OfferDetailOfferId -OfferDetailPlanId $env.OfferDetailPlanId -OfferDetailPlanName $env.OfferDetailPlanName -OfferDetailPublisherId $env.OfferDetailPublisherId -OfferDetailTermId $env.OfferDetailTermId -OfferDetailTermUnit $env.OfferDetailTermUnit -PartnerPropertyApplication $env.PartnerPropertyApplication -SingleSignOnPropertyType $env.SingleSignOnPropertyType -SingleSignOnPropertyState $env.SingleSignOnPropertyState -SingleSignOnPropertyAadDomain $env.SingleSignOnPropertyAadDomain -SingleSignOnPropertyUrl $env.SingleSignOnPropertyUrl -UserEmailAddress $env.UserEmailAddress -UserFirstName $env.UserFirstName -UserLastName $env.UserLastName -UserUpn $env.UserUpn
            }
            catch {
                if ($_.Exception.Message -match "HttpClient.Timeout") {
                    Write-Host "Received 'Timeout' response"
                }
                else {
                    throw $_
                }
            }
        } | Should -Not -Throw
    }
}

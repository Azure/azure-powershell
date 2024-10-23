if(($null -eq $TestName) -or ($TestName -contains 'New-AzAstroOrganization'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAstroOrganization.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzAstroOrganization' {
    It 'CreateExpanded' {
        {
            $UserUpn = $env.UserEmail
            $WorkSpaceNamePartner = 'aaa'
            $OrgnamePartner = 'bbb'

            $orga = New-AzAstroOrganization -Name $env.ResourceName -ResourceGroupName $env.ResourceGroupName -Location $env.Location -MarketplaceSubscriptionId $env.MarketplaceSubscriptionId -OfferDetailOfferId $env.OfferOffer -OfferDetailPlanId $env.OfferPlan -OfferDetailPublisherId $env.OfferPublisher -OfferDetailPlanName $env.OfferPlanName -OfferDetailTermId $env.OfferTerm -OfferDetailTermUnit Monthly -UserEmailAddress $env.UserEmail -UserFirstName $env.UserFirstName -UserLastName $env.UserLastName -UserUpn $UserUpn -PartnerOrganizationPropertyWorkspaceName $WorkSpaceNamePartner -PartnerOrganizationPropertyOrganizationName $OrgnamePartner -SingleSignOnPropertyAadDomain $env.AadDomain
            $orga.Name | Should -Be $env.ResourceName
        } | Should -Not -Throw
    }
}

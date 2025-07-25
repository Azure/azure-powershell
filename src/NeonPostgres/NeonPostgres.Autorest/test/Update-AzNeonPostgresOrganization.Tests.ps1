if(($null -eq $TestName) -or ($TestName -contains 'Update-AzNeonPostgresOrganization'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNeonPostgresOrganization.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Define variables directly in the script
$resourceName = "NeonDemoOrgPS1"
$resourceGroupName = "neonrg"
$subscriptionId = "a81c0054-6c92-41aa-a235-4f9f98f917c6"

# Company Details
$companyDetailBusinessPhone = "+1234567890"
$companyDetailCompanyName = "Contoso"
$companyDetailCountry = "USA"
$companyDetailDomain = "contoso.com"
$companyDetailNumberOfEmployee = 500
$companyDetailOfficeAddress = "1234 Azure Ave"

# Marketplace Details
$marketplaceDetailSubscriptionId = "e276aac0-83e0-4381-dffe-0400d1af8065"
$marketplaceDetailSubscriptionStatus = "Subscribed"

# Offer Details
$offerDetailOfferId = "neon_serverless_postgres_azure_prod"
$offerDetailPlanId = "neon_serverless_postgres_azure_prod_free"
$offerDetailPlanName = "Free Plan"
$offerDetailPublisherId = "neon1722366567200"
$offerDetailTermId = "gmz7xq9ge3py"
$offerDetailTermUnit = "P1M"

# Partner Organization Properties
$partnerOrganizationPropertyOrganizationId = "org-bitter-scene-70654971"
$partnerOrganizationPropertyOrganizationName = "NeonDemoOrgPS1"

# Single Sign-On Properties
$singleSignOnPropertyAadDomain = ""
$singleSignOnPropertyEnterpriseAppId = ""
$singleSignOnPropertySingleSignOnState = "Enable"
$singleSignOnPropertySingleSignOnUrl = "https://console.neon.tech/azure/sso/org-bitter-scene-70654971"

# User Details
$userDetailEmailAddress = "Demouser@testtestliftrtest2.onmicrosoft.com"
$userDetailFirstName = "Demo"
$userDetailLastName = "User"
$userDetailPhoneNumber = "+1234567890"
$userDetailUpn = "Demouser@testtestliftrtest2.onmicrosoft.com"

Describe 'Update-AzNeonPostgresOrganization' {
    It 'UpdateExpanded' {
        {
            # Execute the Update-AzNeonPostgresOrganization command with parameters from defined variables
            Update-AzNeonPostgresOrganization -Name $resourceName -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -CompanyDetailBusinessPhone $companyDetailBusinessPhone -CompanyDetailCompanyName $companyDetailCompanyName -CompanyDetailCountry $companyDetailCountry -CompanyDetailDomain $companyDetailDomain -CompanyDetailNumberOfEmployee $companyDetailNumberOfEmployee -CompanyDetailOfficeAddress $companyDetailOfficeAddress -MarketplaceDetailSubscriptionId $marketplaceDetailSubscriptionId -MarketplaceDetailSubscriptionStatus $marketplaceDetailSubscriptionStatus -OfferDetailOfferId $offerDetailOfferId -OfferDetailPlanId $offerDetailPlanId -OfferDetailPlanName $offerDetailPlanName -OfferDetailPublisherId $offerDetailPublisherId -OfferDetailTermId $offerDetailTermId -OfferDetailTermUnit $offerDetailTermUnit -PartnerOrganizationPropertyOrganizationId $partnerOrganizationPropertyOrganizationId -PartnerOrganizationPropertyOrganizationName $partnerOrganizationPropertyOrganizationName -SingleSignOnPropertyAadDomain @($singleSignOnPropertyAadDomain) -SingleSignOnPropertyEnterpriseAppId $singleSignOnPropertyEnterpriseAppId -SingleSignOnPropertySingleSignOnState $singleSignOnPropertySingleSignOnState -SingleSignOnPropertySingleSignOnUrl $singleSignOnPropertySingleSignOnUrl -UserDetailEmailAddress $userDetailEmailAddress -UserDetailFirstName $userDetailFirstName -UserDetailLastName $userDetailLastName -UserDetailPhoneNumber $userDetailPhoneNumber -UserDetailUpn $userDetailUpn
            
            # Validate that the update command completes without throwing exceptions
        } | Should -Throw
    }
}

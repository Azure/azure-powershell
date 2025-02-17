if(($null -eq $TestName) -or ($TestName -contains 'New-AzNeonPostgresOrganization'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNeonPostgresOrganization.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Define variables directly
$resourceName = "almasTestNeonPSRecord1A"
$resourceGroupName = "NeonDemoRG"
$location = "centraluseuap"
$subscriptionId = "5d9a6cc3-4e60-4b41-be79-d28f0a01074e"

# Company Details
$companyDetailBusinessPhone = "+1234567890"
$companyDetailCompanyName = "DemoCompany"
$companyDetailCountry = "USA"
$companyDetailDomain = "demo.com"
$companyDetailNumberOfEmployee = 500
$companyDetailOfficeAddress = "1234 Azure Ave"

# Marketplace Details
$marketplaceDetailSubscriptionId = "yxmkfivp"
$marketplaceDetailSubscriptionStatus = "PendingFulfillmentStart"

# Offer Details
$offerDetailOfferId = "neon_test"
$offerDetailPlanId = "neon_test_1"
$offerDetailPlanName = "Neon Serverless Postgres - Free (Test_Liftr)"
$offerDetailPublisherId = "neon1722366567200"
$offerDetailTermId = "gmz7xq9ge3py"
$offerDetailTermUnit = "P1M"

# Partner Organization Properties
$partnerOrganizationPropertyOrganizationId = "org12345"
$partnerOrganizationPropertyOrganizationName = "PartnerOrgRecord1A"

# Single Sign-On Properties
$singleSignOnPropertyAadDomain = "partnerorg.com"
$singleSignOnPropertyEnterpriseAppId = "app12345"
$singleSignOnPropertySingleSignOnState = "Enable"
$singleSignOnPropertySingleSignOnUrl = "https://sso.partnerorg.com"

# User Details
$userDetailEmailAddress = "khanalmas@microsoft.com"
$userDetailFirstName = "Almas"
$userDetailLastName = "Khan"
$userDetailPhoneNumber = "+1234567890"
$userDetailUpn = "khanalmas_microsoft.com#EXT#@qumulotesttenant2.onmicrosoft.com"

Describe 'New-AzNeonPostgresOrganization' {
    It 'CreateExpanded' {
        {
            # Execute the New-AzNeonPostgresOrganization command with parameters from defined variables
            $orga = New-AzNeonPostgresOrganization -Name $resourceName -ResourceGroupName $resourceGroupName -Location $location -SubscriptionId $subscriptionId -CompanyDetailBusinessPhone $companyDetailBusinessPhone -CompanyDetailCompanyName $companyDetailCompanyName -CompanyDetailCountry $companyDetailCountry -CompanyDetailDomain $companyDetailDomain -CompanyDetailNumberOfEmployee $companyDetailNumberOfEmployee -CompanyDetailOfficeAddress $companyDetailOfficeAddress -MarketplaceDetailSubscriptionId $marketplaceDetailSubscriptionId -MarketplaceDetailSubscriptionStatus $marketplaceDetailSubscriptionStatus -OfferDetailOfferId $offerDetailOfferId -OfferDetailPlanId $offerDetailPlanId -OfferDetailPlanName $offerDetailPlanName -OfferDetailPublisherId $offerDetailPublisherId -OfferDetailTermId $offerDetailTermId -OfferDetailTermUnit $offerDetailTermUnit -PartnerOrganizationPropertyOrganizationId $partnerOrganizationPropertyOrganizationId -PartnerOrganizationPropertyOrganizationName $partnerOrganizationPropertyOrganizationName -SingleSignOnPropertyAadDomain @($singleSignOnPropertyAadDomain) -SingleSignOnPropertyEnterpriseAppId $singleSignOnPropertyEnterpriseAppId -SingleSignOnPropertySingleSignOnState $singleSignOnPropertySingleSignOnState -SingleSignOnPropertySingleSignOnUrl $singleSignOnPropertySingleSignOnUrl -UserDetailEmailAddress $userDetailEmailAddress -UserDetailFirstName $userDetailFirstName -UserDetailLastName $userDetailLastName -UserDetailPhoneNumber $userDetailPhoneNumber -UserDetailUpn $userDetailUpn
            
            # Validate the result by checking the Name property
            $orga.Name | Should -Be $resourceName
        } | Should -Not -Throw
    }
}

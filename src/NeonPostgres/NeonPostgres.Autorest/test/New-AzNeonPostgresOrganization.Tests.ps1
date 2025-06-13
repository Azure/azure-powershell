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
$resourceName = "NeonDemoOrgPS2"
$resourceGroupName = "neonrg"
$location = "eastus2"
$subscriptionId = "a81c0054-6c92-41aa-a235-4f9f98f917c6"

# Company Details
$companyDetailBusinessPhone = "+1234567890"
$companyDetailCompanyName = "Contosoft"
$companyDetailCountry = "USA"
$companyDetailDomain = "Contosoft.com"
$companyDetailNumberOfEmployee = 500
$companyDetailOfficeAddress = "1234 Azure Ave"

# Marketplace Details
$marketplaceDetailSubscriptionId = "yxmkfivp"
$marketplaceDetailSubscriptionStatus = "PendingFulfillmentStart"

# Offer Details
$offerDetailOfferId = "neon_serverless_postgres_azure_prod"
$offerDetailPlanId = "neon_serverless_postgres_azure_prod_free"
$offerDetailPlanName = "Free Plan"
$offerDetailPublisherId = "neon1722366567200"
$offerDetailTermId = "gmz7xq9ge3py"
$offerDetailTermUnit = "P1M"

# Partner Organization Properties
$partnerOrganizationPropertyOrganizationId = ""
$partnerOrganizationPropertyOrganizationName = "NeonDemoOrgPS"

# Project Properties
$pgVersion = "17"
$projectName = "NeonDemoOrgPSProject"
$regionId = "eastus2"
$databaseName = "NeonDB"
$branchName = "main"

# Single Sign-On Properties - Optional
# These properties are optional and can be set to empty strings if not needed.
$singleSignOnPropertyAadDomain = ""
$singleSignOnPropertyEnterpriseAppId = ""
$singleSignOnPropertySingleSignOnState = "Enable"
$singleSignOnPropertySingleSignOnUrl = ""

# User Details
$userDetailEmailAddress = "Demouser@testtestliftrtest2.onmicrosoft.com"
$userDetailFirstName = "Demo"
$userDetailLastName = "User"
$userDetailPhoneNumber = "+1234567890"
$userDetailUpn = "Demouser@testtestliftrtest2.onmicrosoft.com"

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

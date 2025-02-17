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
$resourceName = "almasTestNeonPSRecord1A"
$resourceGroupName = "NeonDemoRG"
$subscriptionId = "5d9a6cc3-4e60-4b41-be79-d28f0a01074e"

# Company Details
$companyDetailBusinessPhone = "+1234567890"
$companyDetailCompanyName = "DemoCompany"
$companyDetailCountry = "USA"
$companyDetailDomain = "demo.com"
$companyDetailNumberOfEmployee = 500
$companyDetailOfficeAddress = "1234 Azure Ave"

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

Describe 'Update-AzNeonPostgresOrganization' {
    It 'UpdateExpanded' {
        {
            # Execute the Update-AzNeonPostgresOrganization command with parameters from defined variables
            Update-AzNeonPostgresOrganization -Name $resourceName -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -CompanyDetailBusinessPhone $companyDetailBusinessPhone -CompanyDetailCompanyName $companyDetailCompanyName -CompanyDetailCountry $companyDetailCountry -CompanyDetailDomain $companyDetailDomain -CompanyDetailNumberOfEmployee $companyDetailNumberOfEmployee -CompanyDetailOfficeAddress $companyDetailOfficeAddress -PartnerOrganizationPropertyOrganizationId $partnerOrganizationPropertyOrganizationId -PartnerOrganizationPropertyOrganizationName $partnerOrganizationPropertyOrganizationName -SingleSignOnPropertyAadDomain @($singleSignOnPropertyAadDomain) -SingleSignOnPropertyEnterpriseAppId $singleSignOnPropertyEnterpriseAppId -SingleSignOnPropertySingleSignOnState $singleSignOnPropertySingleSignOnState -SingleSignOnPropertySingleSignOnUrl $singleSignOnPropertySingleSignOnUrl -UserDetailEmailAddress $userDetailEmailAddress -UserDetailFirstName $userDetailFirstName -UserDetailLastName $userDetailLastName -UserDetailPhoneNumber $userDetailPhoneNumber -UserDetailUpn $userDetailUpn
            
            # Validate that the update command completes without throwing exceptions
        } | Should -Not -Throw
    }
}

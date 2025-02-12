### Example 1: Update Informatica Organization
```powershell
Update-AzInformaticaOrganization -Name "InformaticaTestResource" -ResourceGroupName "InformaticaTestRg" -SubscriptionId "ce37d538-dfa3-49c3-b3cd-149b4b7db48a" -Property @{
    userDetails = @{
        firstName = "Test"
        lastName = ""
        emailAddress = "Test_Infa@mpliftrlogz20210811outlook.onmicrosoft.com"
        upn = "Test_Infa@mpliftrlogz20210811outlook.onmicrosoft.com"
        phoneNumber = "9876543210"
    }
    marketplaceDetails = @{
        marketplaceSubscriptionId = "c948d31a-c011-4b16-ce29-688c1565fc06"
        offerDetails = @{
            offerId = "prod-idmc_as_azure_native_isv_service"
            publisherId = "informatica"
            planId = "prod-private_priview_plan_cdi_free"
            planName = "Pay as you go"
            termUnit = "P1Y"
            termId = "zwuaefo5ywwo"
        }
    }
    companyDetails = @{
        companyName = "TestCompany"
        country = "India"
        domain = ""
        business = ""
        numberOfEmployees = 0
    }
}

```

```output
BusinessPhoneNumber                        :
CompanyDetailCompanyName                   : Test
CompanyDetailCountry                       : India
CompanyDetailDomain                        :
CompanyDetailNumberOfEmployee              : 0
CompanyDetailOfficeAddress                 :
Id                                         : /subscriptions/ce37d538-dfa3-49c3-b3cd-149b4b7db48a/resourceGroups/InformaticaTestRg/providers/Informatica.DataManagement/organizations/InformaticaTestResource
InformaticaPropertyInformaticaRegion       :
InformaticaPropertyOrganizationId          :
InformaticaPropertyOrganizationName        :
InformaticaPropertySingleSignOnUrl         :
LinkOrganizationToken                      :
Location                                   : westus2
MarketplaceDetailMarketplaceSubscriptionId : 3217f8a7-3349-4473-900d-3a6ec5d7c16c
Name                                       : InformaticaTestResource
OfferDetailOfferId                         : prod-idmc_as_azure_native_isv_service
OfferDetailPlanId                          : prod-private_priview_plan_cdi_free
OfferDetailPlanName                        : Pay as you go
OfferDetailPublisherId                     : informatica
OfferDetailTermId                          : zwuaefo5ywwo
OfferDetailTermUnit                        : P1Y
ProvisioningState                          : Succeeded
ResourceGroupName                          : InformaticaTestRg
SystemDataCreatedAt                        : 09-Jul-24 11:48:22 AM
SystemDataCreatedBy                        : khanalmas@microsoft.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 09-Jul-24 12:00:42 PM
SystemDataLastModifiedBy                   : khanalmas@microsoft.com
SystemDataLastModifiedByType               : User
Tag                                        : {}
Type                                       : informatica.datamanagement/organizations
UserDetailEmailAddress                     : Test_Infa@mpliftrlogz20210811outlook.onmicrosoft.com
UserDetailFirstName                        : Test
UserDetailLastName                         : Test
UserDetailPhoneNumber                      : 9876543210
UserDetailUpn                              : Test_Infa@mpliftrlogz20210811outlook.onmicrosoft.com
```

Update Informatica resource with the specified properties.

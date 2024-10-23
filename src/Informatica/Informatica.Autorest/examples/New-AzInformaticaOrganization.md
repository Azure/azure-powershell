### Example 1: Create new Informatica Resource
```powershell
New-AzInformaticaOrganization -Name "NewInformaticaTestResource" -ResourceGroupName "InformaticaTestRg" -Location "westus2" -SubscriptionId "ce37d538-dfa3-49c3-b3cd-149b4b7db48a"  -CompanyDetailCompanyName "Test" -CompanyDetailCountry "India" -CompanyDetailDomain "" -CompanyDetailNumberOfEmployee 0  -BusinessPhoneNumber ""  -MarketplaceDetailMarketplaceSubscriptionId "c948d31a-c011-4b16-ce29-688c1565fc06" -OfferDetailOfferId "prod-idmc_as_azure_native_isv_service" -OfferDetailPlanId "prod-private_priview_plan_cdi_free" -OfferDetailPlanName "Pay as you go" -OfferDetailPublisherId "informatica" -OfferDetailTermId "zwuaefo5ywwo" -OfferDetailTermUnit "P1Y" -UserDetailEmailAddress "Test_Infa@mpliftrlogz20210811outlook.onmicrosoft.com" -UserDetailFirstName "Test" -UserDetailLastName "Test" -UserDetailPhoneNumber "9876543210" -UserDetailUpn "Test_Infa@mpliftrlogz20210811outlook.onmicrosoft.com"
```

```output
BusinessPhoneNumber                        :
CompanyDetailCompanyName                   : Test
CompanyDetailCountry                       : India
CompanyDetailDomain                        :
CompanyDetailNumberOfEmployee              : 0
CompanyDetailOfficeAddress                 :
Id                                         : /subscriptions/ce37d538-dfa3-49c3-b3cd-149b4b7db48a/resourceGroups/InformaticaTestRg/providers/Informatica.DataManagement/organizations/NewInformaticaTestResource
InformaticaPropertyInformaticaRegion       :
InformaticaPropertyOrganizationId          :
InformaticaPropertyOrganizationName        :
InformaticaPropertySingleSignOnUrl         :
LinkOrganizationToken                      :
Location                                   : westus2
MarketplaceDetailMarketplaceSubscriptionId : 3217f8a7-3349-4473-900d-3a6ec5d7c16c
Name                                       : NewInformaticaTestResource
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
SystemDataLastModifiedAt                   : 09-Jul-24 11:48:52 AM
SystemDataLastModifiedBy                   : 1907c93c-5795-4a9c-8ad3-7798b1d72580
SystemDataLastModifiedByType               : Application
Tag                                        : {}
Type                                       : informatica.datamanagement/organizations
UserDetailEmailAddress                     : Test_Infa@mpliftrlogz20210811outlook.onmicrosoft.com
UserDetailFirstName                        : Test
UserDetailLastName                         : Test
UserDetailPhoneNumber                      : 9876543210
UserDetailUpn                              : Test_Infa@mpliftrlogz20210811outlook.onmicrosoft.com
```

Create new Informatica Resource in the specified resource group.

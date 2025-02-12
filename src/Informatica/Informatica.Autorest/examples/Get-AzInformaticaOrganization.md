### Example 1: Get Informatica Organization Details
```powershell
 Get-AzInformaticaOrganization -OrganizationName InformaticaTestResource -ResourceGroupName InformaticaTestRg
```

```output
BusinessPhoneNumber                        :
CompanyDetailCompanyName                   : Microsoft
CompanyDetailCountry                       : India
CompanyDetailDomain                        :
CompanyDetailNumberOfEmployee              : 0
CompanyDetailOfficeAddress                 :
Id                                         : /subscriptions/ce37d538-dfa3-49c3-b3cd-149b4b7db48a/resourceGroups/InformaticaTestRg/providers/Informatica.DataManagement/organizations/InformaticaTestResource
InformaticaPropertyInformaticaRegion       : West-US2-Staging
InformaticaPropertyOrganizationId          :
InformaticaPropertyOrganizationName        :
InformaticaPropertySingleSignOnUrl         :
LinkOrganizationToken                      :
Location                                   : westus2
MarketplaceDetailMarketplaceSubscriptionId : 509e641c-c8d9-4ec9-838b-0cdd41d055dc
Name                                       : InformaticaTestResource
OfferDetailOfferId                         : azurenativeinfaservces
OfferDetailPlanId                          : privatepreview-plan-cdi-free_00
OfferDetailPlanName                        : CDI Free - Private Preview
OfferDetailPublisherId                     : informatica
OfferDetailTermId                          : o73usof6rkyy
OfferDetailTermUnit                        : P1Y
ProvisioningState                          : Succeeded
ResourceGroupName                          : InformaticaTestRg
SystemDataCreatedAt                        : 09-Jul-24 11:35:18 AM
SystemDataCreatedBy                        : Test_Infa@mpliftrlogz20210811outlook.onmicrosoft.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 09-Jul-24 11:36:11 AM
SystemDataLastModifiedBy                   : 1907c93c-5795-4a9c-8ad3-7798b1d72580
SystemDataLastModifiedByType               : Application
Tag                                        : {}
Type                                       : informatica.datamanagement/organizations
UserDetailEmailAddress                     : Test_Infa@mpliftrlogz20210811outlook.onmicrosoft.com
UserDetailFirstName                        : Test
UserDetailLastName                         : Infa
UserDetailPhoneNumber                      : 9876543210
```

This command will get Informatica organization details for a specific organization name and resource group

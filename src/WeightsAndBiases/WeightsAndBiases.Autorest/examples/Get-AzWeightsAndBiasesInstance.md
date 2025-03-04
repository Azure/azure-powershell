### Example 1: {{ Add title here }}
```powershell
Get-AzWeightsAndBiasesInstance -ResourceGroupName jawt-rg
```

```output
Location Name                     SystemDataCreatedAt   SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModified
                                                                                                                                                       ByType
-------- ----                     -------------------   -------------------  ----------------------- ------------------------ ------------------------ ----------------------
eastus   pleasedeletethisresource 11/15/2024 8:29:35 AM shijoy@microsoft.com User                    11/15/2024 8:29:35 AM    shijoy@microsoft.com     User
East US  efref4                   2/28/2025 10:38:03 AM shijoy@microsoft.com User                    2/28/2025 10:38:03 AM    shijoy@microsoft.com     User
```

This command lists all the resources in a given resource group

### Example 2: {{ Add title here }}
```powershell
Get-AzWeightsAndBiasesInstance -ResourceGroupName jawt-rg -Name wnb-test-org-5
```

```output
Id                                  : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/jawt-rg/providers/Microsoft.WeightsAndBiases/instances/wnb-test-org-
                                      5
IdentityPrincipalId                 :
IdentityTenantId                    :
IdentityType                        :
IdentityUserAssignedIdentity        : {
                                      }
Location                            : eastus
MarketplaceSubscriptionId           : 03de7830-78ff-45f3-c564-58dd30bc36ca
MarketplaceSubscriptionStatus       : PendingFulfillmentStart
Name                                : wnb-test-org-5
OfferDetailOfferId                  : wandb_liftr
OfferDetailPlanId                   : liftr0plan
OfferDetailPlanName                 : WandB Liftr
OfferDetailPublisherId              : weightsandbiasesinc1641502883483
OfferDetailTermId                   : gmz7xq9ge3py
OfferDetailTermUnit                 : P1M
PartnerPropertyRegion               : eastus
PartnerPropertySubdomain            : testorg5
ProvisioningState                   : Failed
ResourceGroupName                   : jawt-rg
SingleSignOnPropertyAadDomain       :
SingleSignOnPropertyEnterpriseAppId :
SingleSignOnPropertyState           :
SingleSignOnPropertyType            :
SingleSignOnPropertyUrl             :
SystemDataCreatedAt                 : 1/31/2025 11:53:13 AM
SystemDataCreatedBy                 : jawt@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 1/31/2025 11:53:13 AM
SystemDataLastModifiedBy            : jawt@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                      }
Type                                : microsoft.weightsandbiases/instances
UserEmailAddress                    : jawt@microsoft.com
UserFirstName                       :
UserLastName                        :
UserPhoneNumber                     :
UserUpn                             : jawt_microsoft.com#EXT#@MicrosoftCustomerLed.onmicrosoft.com
```

This command lists the details of requested resource name.


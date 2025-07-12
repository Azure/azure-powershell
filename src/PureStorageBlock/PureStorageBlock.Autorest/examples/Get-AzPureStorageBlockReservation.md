### Example 1: {{ Get specific Reservation details in ResourceGroup }}
```powershell
 Get-AzPureStorageBlockReservation -Name testreservation_support_tags -ResourceGroupName dalSUK
```

```output
AddressCity                   : Redmond
AddressCountry                : US
AddressLine1                  : A-313, SVS Palms 2, Chinnapanhalli Main Road, Next To Ekya ITPL School 
                                Chinnapanhalli, Marathahalli, Bengaluru, Karnataka 560037
AddressLine2                  : A-313 3rd Floor
AddressPostalCode             : 98052-8300
AddressState                  : wa
CompanyDetailCompanyName      : nn
Id                            : /subscriptions/834be33e-67e6-45ed-a454-c25a34cdec1f/resourceGroups/dalSUK/pro
                                viders/PureStorage.Block/reservations/testreservation_support_tags
InternalId                    : 28422588-aa48-4beb-9b62-505d858687ba
Location                      : Central US
MarketplaceSubscriptionId     : f58b0d40-98b2-4963-cf53-f9ef81640f8c
MarketplaceSubscriptionStatus : Subscribed
Name                          : testreservation_support_tags
OfferDetailOfferId            : krypton_3_plan
OfferDetailPlanId             : private_preview_zero
OfferDetailPlanName           : Preview Plan
OfferDetailPublisherId        : purestoragemarketplaceadmin
OfferDetailTermId             : gmz7xq9ge3py
OfferDetailTermUnit           : P1M
ProvisioningState             : Succeeded
ResourceGroupName             : dalSUK
SystemDataCreatedAt           : 7/8/2025 12:41:07 PM
SystemDataCreatedBy           : ritikajoshi@microsoft.com
SystemDataCreatedByType       : User
SystemDataLastModifiedAt      : 7/8/2025 12:41:07 PM
SystemDataLastModifiedBy      : ritikajoshi@microsoft.com
SystemDataLastModifiedByType  : User
Tag                           : {
                                }
Type                          : purestorage.block/reservations
UserEmailAddress              : ritikajoshi@microsoft.com
UserFirstName                 : Ritika
UserLastName                  : Joshi
UserPhoneNumber               : 
UserUpn                       : 
```

This command will give details of reservation resource present in the resource group in a given subscription.


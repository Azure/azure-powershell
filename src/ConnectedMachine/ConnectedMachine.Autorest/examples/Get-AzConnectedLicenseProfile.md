### Example 1: Get ESU license profile for a machine
```powershell
Get-AzConnectedLicenseProfile -MachineName WIN-89LGOPE94T3 -ResourceGroupName edyoung
```

```output
AdditionalInfo                       :
Code                                 :
Detail                               :
EsuProfileAssignedLicense            :
EsuProfileAssignedLicenseImmutableId :
EsuProfileEsuEligibility             : Ineligible
EsuProfileEsuKey                     :
EsuProfileEsuKeyState                : Inactive
EsuProfileServerType                 : Datacenter
Id                                   : /subscriptions/********-****-****-****-**********/resourceGroups/edyoung/p
                                       roviders/Microsoft.HybridCompute/machines/WIN-89LGOPE94T3/licenseProfiles/de
                                       fault
Location                             : centraluseuap
Message                              :
Name                                 : default
ProductProfileBillingEndDate         :
ProductProfileBillingStartDate       :
ProductProfileDisenrollmentDate      :
ProductProfileEnrollmentDate         :
ProductProfileProductFeature         :
ProductProfileProductType            :
ProductProfileSubscriptionStatus     :
ProvisioningState                    : Succeeded
ResourceGroupName                    : edyoung
SoftwareAssuranceCustomer            :
SystemDataCreatedAt                  :
SystemDataCreatedBy                  :
SystemDataCreatedByType              :
SystemDataLastModifiedAt             :
SystemDataLastModifiedBy             :
SystemDataLastModifiedByType         :
Tags                                 : {
                                       }
Target                               :
Type                                 : Microsoft.HybridCompute/machines/licenseProfiles
```

Get ESU license profile for a machine



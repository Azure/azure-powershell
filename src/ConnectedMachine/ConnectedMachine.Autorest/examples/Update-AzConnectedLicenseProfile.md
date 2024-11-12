### Example 1: Update a license profile for a machine
```powershell
$productfeature = Update-AzConnectedLicenseProfileFeature -Name "Hotpatch" -SubscriptionStatus "Enable"

Update-AzConnectedLicenseProfile -MachineName "WIN-IAH3TLSP7A8" -ResourceGroupName "PayGo_cmdlet" -ProductProfileProductType "WindowsServer" -ProductProfileSubscriptionStatus "Enabled" -ProductProfileProductFeature $productfeature
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
Id                                   : /subscriptions/********-****-****-****-**********/resourceGroups/e
                                       dyoung/providers/Microsoft.HybridCompute/machines/WIN-89LGOPE94T3/li
                                       censeProfiles/default
Location                             : centraluseuap
Message                              :
Name                                 : default
ProductProfileBillingEndDate         :
ProductProfileBillingStartDate       :
ProductProfileDisenrollmentDate      :
ProductProfileEnrollmentDate         :
ProductProfileProductFeature         : {{
                                         "name": "WindowsServerAzureArcMgmt",
                                         "subscriptionStatus": "Enabled",
                                         "enrollmentDate": "2024-11-07T19:22:26.8693148Z",
                                         "billingStartDate": "2024-11-07T19:22:26.8693071Z"
                                       }}
ProductProfileProductType            : WindowsServer
ProductProfileSubscriptionStatus     :
ProvisioningState                    : Succeeded
ResourceGroupName                    : edyoung
SoftwareAssuranceCustomer            : True
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

Update a license profile for a machine
### Example 1: Get ESU license profile for a machine
```powershell
Get-AzConnectedLicenseProfile -MachineName WIN-IAH3TLSP7A8 -ResourceGroupName PayGo_cmdlet
```

```output
AdditionalInfo                       :
Code                                 :
Detail                               :
EsuProfileAssignedLicense            :
EsuProfileAssignedLicenseImmutableId :
EsuProfileEsuEligibility             : Ineligible
EsuProfileEsuKey                     : {}
EsuProfileEsuKeyState                : Inactive
EsuProfileServerType                 : Datacenter
Id                                   : /subscriptions/b24cc8ee-df4f-48ac-94cf-46edf36b0fae/resourceGroups/PayGo_c
                                       mdlet/providers/Microsoft.HybridCompute/machines/WIN-IAH3TLSP7A8/licensePr
                                       ofiles/default
Location                             : eastus
Message                              :
Name                                 : default
ProductProfileBillingEndDate         :
ProductProfileBillingStartDate       : 11/15/2024 1:53:34 AM
ProductProfileDisenrollmentDate      :
ProductProfileEnrollmentDate         : 11/8/2024 1:53:34 AM
ProductProfileProductFeature         : {{
                                         "name": "WindowsServerAzureArcMgmt",
                                         "subscriptionStatus": "Enabled",
                                         "enrollmentDate": "2024-11-08T01:58:37.6099656Z",
                                         "billingStartDate": "2024-11-08T01:58:37.6096833Z"
                                       }, {
                                         "name": "Hotpatch",
                                         "subscriptionStatus": "Enabled",
                                         "enrollmentDate": "2024-11-08T01:58:37.6095044Z",
                                         "billingStartDate": "2025-02-01T00:00:00.0000000"
                                       }}
ProductProfileProductType            : WindowsServer
ProductProfileSubscriptionStatus     : Enabled
ProvisioningState                    : Succeeded
ResourceGroupName                    : PayGo_cmdlet
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
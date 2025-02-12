### Example 1: Create a license profile for a machine
```powershell
$productfeature = New-AzConnectedLicenseProfileFeature -Name "Hotpatch" -SubscriptionStatus "Enable"

New-AzConnectedLicenseProfile -MachineName "WIN-IAH3TLSP7A8" -ResourceGroupName "PayGo_cmdlet" -Location "eastus" -ProductProfileProductType "WindowsServer" -ProductProfileSubscriptionStatus "Enabled" -ProductProfileProductFeature $productfeature
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
Id                                   : /subscriptions/********-****-****-****-**********/resourceGroups/PayGo_c
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

Create a license profile for a machine


### Example 1: Update an ESU license
```powershell
Set-AzConnectedLicense -Name 'myESULicense' -ResourceGroupName 'ytongtest' -Location 'eastus2euap' -LicenseType 'ESU' -LicenseDetailState 'Deactivated'  -LicenseDetailTarget 'Windows Server 2012' -LicenseDetailEdition 'Datacenter' -LicenseDetailType 'pCore' -LicenseDetailProcessor 16 -SubscriptionId ********-****-****-****-**********
```

```output
DetailAssignedLicense        : 8
DetailEdition                : Datacenter
DetailImmutableId            : ********-****-****-****-**********
DetailProcessor              : 16
DetailState                  : Deactivated
DetailTarget                 : Windows Server 2012
DetailType                   : pCore
DetailVolumeLicenseDetail    :
Id                           : /subscriptions/********-****-****-****-**********/resourceGroups/ytongtest/providers/Microsoft.HybridCompute/licenses/myESULicense
LicenseType                  : ESU
Location                     : eastus2euap
Name                         : myESULicense
ProvisioningState            :
ResourceGroupName            : ytongtest
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
TenantId                     : ********-****-****-****-**********
Type                         : Microsoft.HybridCompute/licenses
```

Update an ESU license

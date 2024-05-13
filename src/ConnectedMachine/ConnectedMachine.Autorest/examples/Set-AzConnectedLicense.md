### Example 1: Update an ESU license
```powershell
Set-AzConnectedLicense -Name 'myESULicense' -ResourceGroupName 'ytongtest' -Location 'eastus2euap' -LicenseType 'ESU' -LicenseDetailState 'Deactivated'  -LicenseDetailTarget 'Windows Server 2012' -LicenseDetailEdition 'Datacenter' -LicenseDetailType 'pCore' -LicenseDetailProcessor 16 -SubscriptionId 'b24cc8ee-df4f-48ac-94cf-46edf36b0fae')
```

```output
DetailAssignedLicense        : 8
DetailEdition                : Datacenter
DetailImmutableId            : 298dbcad-3dd6-493c-8d87-2238ee36ba26
DetailProcessor              : 16
DetailState                  : Deactivated
DetailTarget                 : Windows Server 2012
DetailType                   : pCore
DetailVolumeLicenseDetail    :
Id                           : /subscriptions/b24cc8ee-df4f-48ac-94cf-46edf36b0fae/resourceGroups/ytongtest/providers/Microsoft.HybridCompute/licenses/myESULicense
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
TenantId                     : 72f988bf-86f1-41af-91ab-2d7cd011db47
Type                         : Microsoft.HybridCompute/licenses
```

Update an ESU license

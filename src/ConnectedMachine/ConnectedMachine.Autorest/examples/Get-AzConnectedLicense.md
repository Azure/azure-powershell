### Example 1: Get a list of ESU licenses
```powershell
Get-AzConnectedLicense -SubscriptionId 'b24cc8ee-df4f-48ac-94cf-46edf36b0fae'
```

```output
Location      Name         SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
--------      ----         ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
uksouth       testLicense2                                                                                                                                                dakirbytest
eastus2euap   myESULicense                                                                                                                                                ytongtest
centraluseuap testLicense                                                                                                                                                 dakirbytest
centraluseuap testLicense                                                                                                                                                 dakirbytest
centraluseuap testLicense3                                                                                                                                                dakirbytest
centraluseuap testLicense4                                                                                                                                                dakirbytest
centraluseuap testLicense5                                                                                                                                                dakirbytest
```

Get a list of ESU licenses

### Example 2: Get a specific ESU license
```powershell
Get-AzConnectedLicense -Name 'myESULicense' -ResourceGroupName 'ytongtest' -SubscriptionId 'b24cc8ee-df4f-48ac-94cf-46edf36b0fae'
```

```output
DetailAssignedLicense        : 8
DetailEdition                : Datacenter
DetailImmutableId            : 298dbcad-3dd6-493c-8d87-2238ee36ba26
DetailProcessor              : 16
DetailState                  : Activated
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

Get a specific ESU license

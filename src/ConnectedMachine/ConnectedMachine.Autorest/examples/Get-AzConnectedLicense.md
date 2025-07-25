### Example 1: Get a list of ESU licenses
```powershell
Get-AzConnectedLicense -SubscriptionId ********-****-****-****-**********
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
Get-AzConnectedLicense -Name 'myESULicense' -ResourceGroupName 'ytongtest' -SubscriptionId ********-****-****-****-**********
```

```output
DetailAssignedLicense        : 8
DetailEdition                : Datacenter
DetailImmutableId            : ********-****-****-****-**********
DetailProcessor              : 16
DetailState                  : Activated
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

Get a specific ESU license

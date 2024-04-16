### Example 1: Get a standby container pool
```powershell
Get-AzStandbyContainerGroupPool `
-SubscriptionId f8da6e30-a9d8-48ab-b05c-3f7fe482e13b `
-Name testPool `
-ResourceGroupName test-standbypool
```

```output
ContainerGroupProfileId           : /subscriptions/f8da6e30-a9d8-48ab-b05c-3f7fe482e13b/resourcegroups/test-standbypool/providers/Microsoft.ContainerInstance/containerGroupProfiles/testCG
ContainerGroupProfileRevision     : 1
ContainerGroupPropertySubnetId    : {{
                                      "id": "/subscriptions/f8da6e30-a9d8-48ab-b05c-3f7fe482e13b/resourceGroups/test-standbypool/providers/Microsoft.Network/virtualNetworks/test-vnet/subnets/default"
                                    }}
ElasticityProfileMaxReadyCapacity : 1
ElasticityProfileRefillPolicy     : always
Id                                : /subscriptions/f8da6e30-a9d8-48ab-b05c-3f7fe482e13b/resourceGroups/test-standbypool/providers/Microsoft.StandbyPool/standbyContainerGroupPools/testPool
Location                          : eastus
Name                              : testPool
ProvisioningState                 : Succeeded
ResourceGroupName                 : test-standbypool
SystemDataCreatedAt               : 4/10/2024 7:09:36 PM
SystemDataCreatedBy               : dev@microsoft.com
SystemDataCreatedByType           : User
SystemDataLastModifiedAt          : 4/10/2024 7:09:36 PM
SystemDataLastModifiedBy          : dev@microsoft.com
SystemDataLastModifiedByType      : User
Tag                               : {
                                    }
Type                              : microsoft.standbypool/standbycontainergrouppools
```

Above command is getting a standby container pool.

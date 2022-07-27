### Example 1: List all container groups in the current subscription
```powershell
Get-AzContainerGroup
```

```output
Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cg1      test-rg
eastus   test-cg2      test-rg
```

This command gets all container groups in the current subscription.

### Example 2: Get a specific container group
```powershell
Get-AzContainerGroup -Name test-cg1 -ResourceGroupName test-rg | Format-List
```

```output
Container                      : {test-container1}
DnsConfigNameServer            :
DnsConfigOption                :
DnsConfigSearchDomain          :
EncryptionPropertyKeyName      :
EncryptionPropertyKeyVersion   :
EncryptionPropertyVaultBaseUrl :
IPAddressDnsNameLabel          :
IPAddressFqdn                  :
IPAddressIP                    : 000.000.000.000
IPAddressPort                  : {Microsoft.Azure.PowerShell.Cmdlets.ContainerInsta 
                                 nce.Models.Api20210301.Port, Microsoft.Azure.Power 
                                 Shell.Cmdlets.ContainerInstance.Models.Api20210301 
                                 .Port}
IPAddressType                  : Public
Id                             : /subscriptions/00000000-0000-0000-0000-000000000000 
                                 0/resourceGroups/test-rg/providers/Microsoft.Contai 
                                 nerInstance/containerGroups/test-cg1
IdentityPrincipalId            :
IdentityTenantId               :
IdentityType                   :
IdentityUserAssignedIdentity   : Microsoft.Azure.PowerShell.Cmdlets.ContainerInstan 
                                 ce.Models.Api20210301.ContainerGroupIdentityUserAs 
                                 signedIdentities
ImageRegistryCredentials       :
InitContainer                  : {}
InstanceViewEvent              :
InstanceViewState              :
Location                       : eastus
LogAnalyticLogType             : 
LogAnalyticMetadata            : Microsoft.Azure.PowerShell.Cmdlets.ContainerInstan 
                                 ce.Models.Api20210301.LogAnalyticsMetadata
LogAnalyticWorkspaceId         :
LogAnalyticWorkspaceKey        :
LogAnalyticWorkspaceResourceId : Microsoft.Azure.PowerShell.Cmdlets.ContainerInstan 
                                 ce.Models.Api20210301.LogAnalyticsWorkspaceResourc 
                                 eId
Name                           : test-cg1
NetworkProfileId               :
OSType                         : Linux
ProvisioningState              : Succeeded
ResourceGroupName              : test-rg
RestartPolicy                  : Never
Sku                            : Standard
Tag                            : Microsoft.Azure.PowerShell.Cmdlets.ContainerInstan 
                                 ce.Models.Api20210301.ResourceTags
Type                           : Microsoft.ContainerInstance/containerGroups        
Volume                         :
```

The command gets the specified container group.

### Example 3: Get container groups in a resource group
```powershell
Get-AzContainerGroup -ResourceGroupName test-rg
```

```output
Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cg1      test-rg
eastus   test-cg2      test-rg
```

The command gets the container groups in the resource group `test-rg`.

### Example 4: Get a container group by piping
```powershell
Update-AzContainerGroup -Name test-cg1 -ResourceGroupName test-rg -Tag @{"test"="value"} | Get-AzContainerGroup
```

```output
Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cg1      test-rg
```

The command gets the updated container group by piping.
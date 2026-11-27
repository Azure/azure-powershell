### Example 1: Create a Azure Virtual Desktop SessionHostConfiguration by HostPool Name
```powershell
New-AzWvdSessionHostConfiguration -ResourceGroupName ResourceGroupName `
                            -HostPoolName HostPoolName `
                            -ManagedDiskType "Standard_LRS" `
                            -DomainInfoJoinType "AzureActiveDirectory" `
                            -ImageInfoImageType "Marketplace" `
                            -NetworkInfoSubnetId "/subscriptions/{subscriptionId}/resourceGroups/resourceGrouName/providers/Microsoft.Network/virtualNetworks/{vNetName}/subnets/default" `
                            -VMAdminCredentialsPasswordKeyvaultSecretUri "PasswordSecretUri" `
                            -VMAdminCredentialsUserNameKeyvaultSecretUri "PasswordUsernameUri" `
                            -VMNamePrefix "createTest" `
                            -VMSizeId "Standard_D2s_v3" `
                            -MarketplaceInfoExactVersion "22631.2715.231114" `
                            -MarketplaceInfoOffer "office-365" `
                            -MarketplaceInfoPublisher "microsoftwindowsdesktop" `
                            -MarketplaceInfoSku "win11-23h2-avd-m365" `
                            -SecurityInfoSecureBootEnabled `
                            -SecurityInfoType "TrustedLaunch" `
                            -SecurityInfoVTpmEnabled `
                            -VmLocation westus2 `
                            -VmResourceGroup ResourceGroupName
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     default Microsoft.DesktopVirtualization/hostpools/sessionhostconfigurations
```

This command creates a Azure Virtual Desktop SessionHostConfiguration on a HostPool.

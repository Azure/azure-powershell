## Create a VM
It's very difficult to deploy a HANA VM. Please use this one for testing:

Subscription: 9e223dbe-3399-4e19-88eb-0975f02ac87f (Azure PowerShell Test - Manual)
ResourceGroup: nancyc-hn1
Location: westus2

## Before testing, create a log analytic workspace (Operational Insights workspace)

```powershell
New-AzOperationalInsightsWorkspace -ResourceGroupName nancyc-hn1 -Name yeminglaw -Location westus2
```

## Create a sap monitor and a provider instance

```powershell
New-AzSapMonitor -Name yemingmonitor -ResourceGroupName nancyc-hn1 -Location westus2 -EnableCustomerAnalytic -MonitorSubnet "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/nancyc-hn1/providers/Microsoft.Network/virtualNetworks/vnet-sap/subnets/subnet-admin" -LogAnalyticsWorkspaceSharedKey O5IXp1MjlFqACcRNRASv3SYwQTlw+wJyrZCaX230c3/8WyWpNHct84z0L/8F1NEfRsqqjIZh+yV9aOboZX6yAA== -LogAnalyticsWorkspaceId fdeceea9-46c7-424c-8d1e-808471a2ccf4 -LogAnalyticsWorkspaceResourceId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/nancyc-hn1/providers/Microsoft.OperationalInsights/workspaces/yeminglaw"

New-AzSapMonitor -Name ps-spamonitor-t01 -ResourceGroupName nancyc-hn1 -Location westus2 -EnableCustomerAnalytic -MonitorSubnet "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/nancyc-hn1/providers/Microsoft.Network/virtualNetworks/vnet-sap/subnets/subnet-admin" -LogAnalyticsWorkspaceSharedKey O5IXp1MjlFqACcRNRASv3SYwQTlw+wJyrZCaX230c3/8WyWpNHct84z0L/8F1NEfRsqqjIZh+yV9aOboZX6yAA== -LogAnalyticsWorkspaceId fdeceea9-46c7-424c-8d1e-808471a2ccf4 -LogAnalyticsWorkspaceResourceId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/nancyc-hn1/providers/Microsoft.OperationalInsights/workspaces/yeminglaw"

# new provider, plain password
New-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -Name yeminginstance2 -SapMonitorName yemingmonitor -Type SapHana -HanaHostname 'hdb1-0' -HanaDatabaseName 'SYSTEMDB' -HanaDatabaseSqlPort 30015 -HanaDatabaseUsername SYSTEM -HanaDatabasePassword (ConvertTo-SecureString "Manager1" -AsPlainText -Force)

New-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -Name ps-sapmonitorins-t04 -SapMonitorName yemingmonitortest -Type SapHana -HanaHostname 'hdb1-0' -HanaDatabaseName 'SYSTEMDB' -HanaDatabaseSqlPort 30015 -HanaDatabaseUsername SYSTEM -HanaDatabasePassword (ConvertTo-SecureString "Manager1" -AsPlainText -Force)

# new provider, password stored in key vault
New-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -Name keyvalue-test -SapMonitorName yemingmonitortest -Type SapHana -HanaHostname 'hdb1-0' -HanaDatabaseName 'SYSTEMDB' -HanaDatabaseSqlPort 30015 -HanaDatabaseUsername SYSTEM -HanaDatabasePasswordSecretId https://yeminghana.vault.azure.net/secrets/psw/cb7e620d72c34d9e940ebdcf178e585b -HanaDatabasePasswordKeyVaultResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/yeminghana/providers/Microsoft.KeyVault/vaults/yeminghana
```

1. LogAnalyticsWorkspaceSharedKey can be get by `Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName nancyc-hn1 -Name yeminglaw` (use PrimarySharedKey)
1. The subnet must be the subnet of the hana instance (you can navigate to the vm and see its subnet in networking properties)

## Notes

1. When writing docs, use `SAP` instead of `sap` or `Sap`; use `HANA` instead of `Hana` or `hana`.
















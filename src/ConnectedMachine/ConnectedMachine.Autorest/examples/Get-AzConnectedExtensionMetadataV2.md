### Example 1: Get extension metadata
```powershell
Get-AzConnectedExtensionMetadataV2 -ExtensionType MDE.Windows -Location eastus -Publisher Microsoft.Azure.AzureDefenderForServers
```

```output
Publisher                               ExtensionType Version
---------                               ------------- -------
microsoft.azure.azuredefenderforservers mde.windows   1.0.11.3
microsoft.azure.azuredefenderforservers mde.windows   1.0.11.2
microsoft.azure.azuredefenderforservers mde.windows   1.0.11.1
microsoft.azure.azuredefenderforservers mde.windows   1.0.10.9
microsoft.azure.azuredefenderforservers mde.windows   1.0.10.7
microsoft.azure.azuredefenderforservers mde.windows   1.0.10.6
microsoft.azure.azuredefenderforservers mde.windows   1.0.10.5
microsoft.azure.azuredefenderforservers mde.windows   1.0.10.4
microsoft.azure.azuredefenderforservers mde.windows   1.0.10.3
microsoft.azure.azuredefenderforservers mde.windows   1.0.10.2
microsoft.azure.azuredefenderforservers mde.windows   1.0.9.5
microsoft.azure.azuredefenderforservers mde.windows   1.0.9.4
microsoft.azure.azuredefenderforservers mde.windows   1.0.9.3
```
Get extension metadata
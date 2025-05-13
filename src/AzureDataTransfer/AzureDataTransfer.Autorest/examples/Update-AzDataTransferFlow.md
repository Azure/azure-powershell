### Example 1: Update tags for a flow
```powershell
Update-AzDataTransferFlow -ResourceGroupName ResourceGroup01 -ConnectionName Connection01 -Name Flow01 -Tag @{Environment="Production"; Department="IT"} -Confirm:$false
```

This example updates the tags for the flow `Flow01` in the connection `Connection01` within the resource group `ResourceGroup01`.

---

### Example 2: Update a flow with additional parameters
```powershell
Update-AzDataTransferFlow -ResourceGroupName ResourceGroup01 -ConnectionName Connection01 -Name Flow01 -CustomerManagedKeyVaultUri "https://mykeyvault.vault.azure.net/" -DestinationEndpoint "https://destination.blob.core.windows.net" -Confirm:$false
```

This example updates the flow `Flow01` in the connection `Connection01` within the resource group `ResourceGroup01` by modifying the Key Vault URI and destination endpoint.

---

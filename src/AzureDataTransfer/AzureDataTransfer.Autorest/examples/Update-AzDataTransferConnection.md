### Example 1: Update tags for a connection
```powershell
Update-AzDataTransferConnection -ResourceGroupName ResourceGroup01 -Name Connection01 -Tag @{Environment="Production"; Department="IT"} -Confirm:$false
```

This example updates the tags for the connection `Connection01` in the resource group `ResourceGroup01`.

---

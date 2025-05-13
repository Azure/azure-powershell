### Example 1: Disable a specific flow
```powershell
Disable-AzDataTransferFlow -ResourceGroupName ResourceGroup01 -ConnectionName Connection01 -Name flow01 -Confirm:$false
```

This example disables a specific flow named `flow01` in the connection `Connection01` within the resource group `ResourceGroup01` without prompting for confirmation.

---

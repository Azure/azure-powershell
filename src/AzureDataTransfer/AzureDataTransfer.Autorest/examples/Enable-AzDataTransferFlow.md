### Example 1: Enable a specific flow
```powershell
Enable-AzDataTransferFlow -ResourceGroupName ResourceGroup01 -ConnectionName Connection01 -Name flow01 -Confirm:$false
```

This example enables a specific flow named `flow01` in the connection `Connection01` within the resource group `ResourceGroup01` without prompting for confirmation.

---

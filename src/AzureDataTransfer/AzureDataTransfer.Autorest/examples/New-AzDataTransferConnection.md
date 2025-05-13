### Example 1: Create a new Receive side connection with basic parameters
```powershell
New-AzDataTransferConnection -ResourceGroupName ResourceGroup01 -Name Connection01 -Location "EastUS" -Direction "Receive" -FlowType "Mission" -Justification "Required for data processing" -Confirm:$false
```

This example creates a new connection named `Connection01` in the resource group `ResourceGroup01` located in the `EastUS` region with basic parameters direction, flow type, and justification.

---

### Example 2: Create a new Receive side connection with basic parameters
```powershell
New-AzDataTransferConnection -ResourceGroupName ResourceGroup02 -Name Connection02 -Location "WestUS" -Direction "Send" -PIN "AAAAAA" -FlowType "Mission" -Justification "Required for data processing" -Confirm:$false
```

This example creates a new connection named `Connection02` in the resource group `ResourceGroup02` located in the `WestUS` region with basic parameters direction, flow type, and justification.

---

### Example 3: Create a new connection with additional parameters
```powershell
New-AzDataTransferConnection -ResourceGroupName ResourceGroup01 -Name Connection01 -Location "EastUS" -Direction "Receive" -FlowType "Mission" -Justification "Required for data export" -PrimaryContact "user@example.com" -SecondaryContact "admin@example.com" -Tag @{Environment="Production"} -Confirm:$false
```

This example creates a new connection named `Connection01` in the resource group `ResourceGroup01` with additional parameters such as primary and secondary contacts and resource tags.

---

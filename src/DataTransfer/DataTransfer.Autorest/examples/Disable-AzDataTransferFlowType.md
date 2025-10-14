### Example 1: Disable a single flow type
```powershell
Disable-AzDataTransferFlowType -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowType "FlowType01"
```

Disables the "FlowType01" flow type.

### Example 2: Disable multiple flow types
```powershell
Disable-AzDataTransferFlowType -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowType @("FlowType01", "FlowType02")
```

Disables both "FlowType01" and "FlowType02" flow types.


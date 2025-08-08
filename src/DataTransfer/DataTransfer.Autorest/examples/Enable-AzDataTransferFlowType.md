### Example 1: Enable a single flow type
```powershell
Enable-AzDataTransferFlowType -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowType "FlowType01"
```

Enables the "FlowType01" flow type.

### Example 2: Enable multiple flow types
```powershell
Enable-AzDataTransferFlowType -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowType @("FlowType01", "FlowType02")
```

Enables both "FlowType01" and "FlowType02" flow types.


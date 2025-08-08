### Example 1: Disable a pipeline
```powershell
Disable-AzDataTransferPipeline -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01"
```

Disables the pipeline named "Pipeline01" in the "ResourceGroup01" resource group.

### Example 2: Disable a pipeline with justification
```powershell
Disable-AzDataTransferPipeline -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -Justification "Emergency shutdown for security review"
```

Disables the pipeline with a business justification.


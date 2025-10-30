### Example 1: Enable a pipeline
```powershell
Enable-AzDataTransferPipeline -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01"
```

Enables the pipeline named "Pipeline01" in the "ResourceGroup01" resource group.

### Example 2: Enable a pipeline with justification
```powershell
Enable-AzDataTransferPipeline -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -Justification "Re-enabling after maintenance"
```

Enables the pipeline with a business justification.


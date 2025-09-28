### Example 1: Update FlowProfile status and description
```powershell
Update-AzDataTransferFlowProfile -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowProfileName "files-flowprofile" -Status "Disabled" -Description "Updated FlowProfile - temporarily disabled for maintenance"
```

Updates the status and description of an existing FlowProfile. This is useful for maintenance scenarios or when you need to modify basic properties.

### Example 2: Add antivirus protection to an existing FlowProfile
```powershell
Update-AzDataTransferFlowProfile -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowProfileName "files-flowprofile" -AntivirusAvSolution @("Defender") -Status "Enabled"
```

Enhances an existing FlowProfile by adding antivirus protection while re-enabling it. This demonstrates how to add security features to existing configurations.

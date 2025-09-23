### Example 1: Update FlowProfile status and description
```powershell
Update-AzDataTransferFlowProfile -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowProfileName "files-flowprofile" -Status "Disabled" -Description "Updated FlowProfile - temporarily disabled for maintenance"
```

```output
Name               : files-flowprofile
ResourceGroupName  : ResourceGroup01
Location           : EastUS
Pipeline          : Pipeline01
ReplicationScenario: Files
Status            : Disabled
Description       : Updated FlowProfile - temporarily disabled for maintenance
FlowProfileId     : /subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/pipelines/Pipeline01/flowProfiles/files-flowprofile
ModifiedTime      : 2025-09-23T11:15:30Z
```

Updates the status and description of an existing FlowProfile. This is useful for maintenance scenarios or when you need to modify basic properties.

### Example 2: Add MIME filters and antivirus protection to an existing FlowProfile
```powershell
$mimeFilters = @("application/pdf", "image/jpeg", "image/png", "application/zip")
Update-AzDataTransferFlowProfile -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowProfileName "files-flowprofile" -MimeFilter $mimeFilters -AntiviruAvSolution @("Defender") -Status "Enabled"
```

```output
Name               : files-flowprofile
ResourceGroupName  : ResourceGroup01
Location           : EastUS
Pipeline          : Pipeline01
ReplicationScenario: Files
Status            : Enabled
Description       : Updated FlowProfile - temporarily disabled for maintenance
MimeFilter        : {application/pdf, image/jpeg, image/png, application/zip}
AntiviruAvSolution: {Defender}
FlowProfileId     : /subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/pipelines/Pipeline01/flowProfiles/files-flowprofile
ModifiedTime      : 2025-09-23T11:20:45Z
```

Enhances an existing FlowProfile by adding MIME type filtering and antivirus protection while re-enabling it. This demonstrates how to add security features to existing configurations.


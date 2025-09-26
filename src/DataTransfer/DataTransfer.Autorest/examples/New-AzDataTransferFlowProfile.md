### Example 1: Create a basic FlowProfile for file transfers
```powershell
New-AzDataTransferFlowProfile -Name "files-flowprofile" -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -Location "EastUS" -ReplicationScenario "Files" -Status "Enabled" -Description "Basic FlowProfile for standard file transfers"
```

```output
Name               : files-flowprofile
ResourceGroupName  : ResourceGroup01
Location           : EastUS
Pipeline          : Pipeline01
ReplicationScenario: Files
Status            : Enabled
Description       : Basic FlowProfile for standard file transfers
FlowProfileId     : /subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/pipelines/Pipeline01/flowProfiles/files-flowprofile
```

Creates a basic FlowProfile for file transfers with enabled status. This is the most common scenario for setting up file-based data transfer workflows.

### Example 2: Create a messaging FlowProfile with antivirus protection
```powershell
New-AzDataTransferFlowProfile -Name "messaging-flowprofile" -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -Location "EastUS" -ReplicationScenario "Messaging" -Status "Enabled" -Description "Messaging FlowProfile with antivirus scanning" -AntivirusAvSolution @("Defender")
```

```output
Name               : messaging-flowprofile
ResourceGroupName  : ResourceGroup01
Location           : EastUS
Pipeline          : Pipeline01
ReplicationScenario: Messaging
Status            : Enabled
Description       : Messaging FlowProfile with antivirus scanning
AntiviruAvSolution: {Defender}
FlowProfileId     : /subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/pipelines/Pipeline01/flowProfiles/messaging-flowprofile
```

Creates a FlowProfile for messaging scenarios with Microsoft Defender antivirus protection enabled. This ensures secure data transfer for message-based workflows.

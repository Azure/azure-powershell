### Example 1: List all FlowProfiles in a pipeline
```powershell
Get-AzDataTransferFlowProfile -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01"
```

```output
Name                 ResourceGroupName Location Pipeline           ReplicationScenario Status  Description
----                 ----------------- -------- --------           ------------------- ------  -----------
files-flowprofile    ResourceGroup01   EastUS   Pipeline01         Files               Enabled Basic FlowProfile for file transfers
messaging-flowprofile ResourceGroup01  EastUS   Pipeline01         Messaging           Enabled Messaging FlowProfile with antivirus
api-flowprofile      ResourceGroup01   EastUS   Pipeline01         Api                 Enabled API FlowProfile with advanced security
```

Lists all FlowProfiles configured in the specified pipeline, showing their key properties including replication scenario, status, and description.

### Example 2: Get a specific FlowProfile by name
```powershell
Get-AzDataTransferFlowProfile -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowProfileName "api-flowprofile"
```

```output
Name                 : api-flowprofile
ResourceGroupName    : ResourceGroup01
Location             : EastUS
Pipeline            : Pipeline01
ReplicationScenario  : Api
Status              : Enabled
Description         : API FlowProfile with advanced security
MimeFilter          : {application/json, application/xml, text/plain}
TextMatchingPattern : {*.log, *.txt, *.json}
FlowProfileId       : /subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/pipelines/Pipeline01/flowProfiles/api-flowprofile
CreatedTime         : 2025-09-23T10:30:15Z
ModifiedTime        : 2025-09-23T10:30:15Z
```

Retrieves detailed information about a specific FlowProfile, including advanced configuration such as MIME filters, text matching patterns, and timestamps.


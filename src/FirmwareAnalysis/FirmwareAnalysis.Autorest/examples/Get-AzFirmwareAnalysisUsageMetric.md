### Example 1: Get usage information for current a workspace named 'default'

```powershell
Get-AzFirmwareAnalysisUsageMetric -ResourceGroupName FirmwareAnalysisRG -WorkspaceName default
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rgName/providers/Microsoft.IoTFirmwareDefense/workspaces/default/usageMetrics/current
MonthlyFirmwareUploadCount   : 1
Name                         : current
ProvisioningState            :
ResourceGroupName            : rgName
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TotalFirmwareCount           : 103
Type                         : Microsoft.IoTFirmwareDefense/workspaces/usageMetrics
```

This shows that there was only 1 firmware uploaded to this workspace this month, and there's a total of 103 firmwares in the workspace.

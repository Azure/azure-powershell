### Example 1: List all the analysis results summary for a firmware by analysis type CVE.
```powershell
Get-AzFirmwareAnalysisSummary -FirmwareId FirmwareId -ResourceGroupName ResourceGroupName -WorkspaceName WorkspaceName -Name Type
```

```output
Id                           : 
Name                         : 
Property                     : 
ResourceGroupName            : 
SummaryType                  :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.IoTFirmwareDefense/workspaces/firmwares/summaries
```

List all the analysis results summary for a firmware by analysis type CVE.

### Example 2: List all the analysis results summary for a firmware by analysis type Firmware.
```powershell
Get-AzFirmwareAnalysisSummary -FirmwareId FirmwareId -ResourceGroupName ResourceGroupName -WorkspaceName WorkspaceName -Name Type
```

```output
Id                           : 
Name                         : 
Property                     :
ResourceGroupName            : 
SummaryType                  :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.IoTFirmwareDefense/workspaces/firmwares/summaries
```

List all the analysis results summary for a firmware by analysis type Firmware.


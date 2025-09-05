---
external help file: Az.FirmwareAnalysis-help.xml
Module Name: Az.FirmwareAnalysis
online version: https://learn.microsoft.com/powershell/module/az.firmwareanalysis/get-azfirmwareanalysissummary
schema: 2.0.0
---

# Get-AzFirmwareAnalysisSummary

## SYNOPSIS
Get an analysis result summary of a firmware by name.

## SYNTAX

### Get (Default)
```
Get-AzFirmwareAnalysisSummary -FirmwareId <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -Type <String> -WorkspaceName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityWorkspace
```
Get-AzFirmwareAnalysisSummary -FirmwareId <String> -Type <String>
 -WorkspaceInputObject <IFirmwareAnalysisIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityFirmware
```
Get-AzFirmwareAnalysisSummary -Type <String> -FirmwareInputObject <IFirmwareAnalysisIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzFirmwareAnalysisSummary -InputObject <IFirmwareAnalysisIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION

Get an analysis result summary of a firmware by name.

## EXAMPLES

### Get (Default)
```powershell
Get-AzFirmwareAnalysisSummary -FirmwareId <String> -ResourceGroupName <String> -Type <String>
 -WorkspaceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```powershell
Get-AzFirmwareAnalysisSummary -InputObject <IFirmwareAnalysisIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityFirmware
```powershell
Get-AzFirmwareAnalysisSummary -FirmwareInputObject <IFirmwareAnalysisIdentity> -Type <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityWorkspace
```powershell
Get-AzFirmwareAnalysisSummary -FirmwareId <String> -Type <String>
 -WorkspaceInputObject <IFirmwareAnalysisIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Example 1: List all the analysis results summary for a firmware by analysis type CVE
```powershell
Get-AzFirmwareAnalysisSummary -FirmwareId FirmwareId -ResourceGroupName ResourceGroupName -WorkspaceName WorkspaceName -Type CVE
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rgName/providers/Microsoft.IoTFirmwareDefense/workspaces/default/firmwares/00000000-0000-0000-0000-000000000000/summaries/cve
Name                         : cve
Property                     : {
                                 "summaryType": "CommonVulnerabilitiesAndExposures",
                                 "criticalCveCount": 0,
                                 "highCveCount": 0,
                                 "mediumCveCount": 0,
                                 "lowCveCount": 0,
                                 "unknownCveCount": 0
                               }
ProvisioningState            :
ResourceGroupName            : FirmwareAnalysisRG
SummaryType                  : CommonVulnerabilitiesAndExposures
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.IoTFirmwareDefense/workspaces/firmwares/summaries
```

List all the analysis results summary for a firmware by analysis type CVE.

### Example 2: List all the analysis results summary for a firmware by analysis type Firmware
```powershell
Get-AzFirmwareAnalysisSummary -FirmwareId FirmwareId -ResourceGroupName ResourceGroupName -WorkspaceName WorkspaceName -Type Firmware
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/RgName/providers/Microsoft.IoTFirmwareDefense/workspaces/default/firmwares/00000000-0000-0000-0000-000000000000/summaries/firmware
Name                         : firmware
Property                     : {
                                 "summaryType": "Firmware",
                                 "extractedSize": 3935653,
                                 "fileSize": 16777216,
                                 "extractedFileCount": 57,
                                 "componentCount": 1,
                                 "binaryCount": 0,
                                 "analysisTimeSeconds": 7,
                                 "rootFileSystems": 0
                               }
ProvisioningState            :
ResourceGroupName            : RgName
SummaryType                  : Firmware
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

## PARAMETERS

### -DefaultProfile


Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False


### -FirmwareId

powershell



Type: System.String
Parameter Sets: Get, GetViaIdentityWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FirmwareId
The id of the firmware.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FirmwareInputObject


Type: Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmwareAnalysisIdentity
Parameter Sets: GetViaIdentityFirmware
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False


### -InputObject

powershell



Type: Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmwareAnalysisIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmwareAnalysisIdentity
Parameter Sets: GetViaIdentityFirmware
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmwareAnalysisIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName


Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False


### -SubscriptionId

powershell



Type: System.String[]
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type


Type: System.String
Parameter Sets: Get, GetViaIdentityFirmware, GetViaIdentityWorkspace
Aliases: SummaryType

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False


### -WorkspaceInputObject

powershell



Type: Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmwareAnalysisIdentity
Parameter Sets: GetViaIdentityWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityWorkspace, GetViaIdentityFirmware
Aliases: SummaryType

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmwareAnalysisIdentity
Parameter Sets: GetViaIdentityWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName


Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False


### CommonParameters

powershell



This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmwareAnalysisIdentity

powershell



## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.ISummaryResource

powershell



## NOTES

## RELATED LINKS

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False


### -FirmwareId
The id of the firmware.

yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False


### -FirmwareInputObject
Identity Parameter

yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmwareAnalysisIdentity
Parameter Sets: GetViaIdentityFirmware
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False


### -InputObject
Identity Parameter

yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmwareAnalysisIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False


### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False


### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

yaml
Type: System.String[]
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False


### -Type
The Firmware analysis summary name describing the type of summary.

yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityFirmware, GetViaIdentityWorkspace
Aliases: SummaryType

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False


### -WorkspaceInputObject
Identity Parameter

yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmwareAnalysisIdentity
Parameter Sets: GetViaIdentityWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False


### -WorkspaceName
The name of the firmware analysis workspace.

yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmwareAnalysisIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.ISummaryResource

## NOTES

## RELATED LINKS

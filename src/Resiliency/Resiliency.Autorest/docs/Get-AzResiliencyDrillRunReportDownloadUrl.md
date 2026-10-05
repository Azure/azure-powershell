---
external help file:
Module Name: Az.Resiliency
online version: https://learn.microsoft.com/powershell/module/az.resiliency/get-azresiliencydrillrunreportdownloadurl
schema: 2.0.0
---

# Get-AzResiliencyDrillRunReportDownloadUrl

## SYNOPSIS
This returns a short-lived, read-only URL to download the report for this Drill Run.
The URL expires at the returned expiryTimestamp and grants access to that single report only.

## SYNTAX

### GetExpanded (Default)
```
Get-AzResiliencyDrillRunReportDownloadUrl -DrillName <String> -DrillRunName <String>
 -ServiceGroupName <String> -OperationId <String> [-Format <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Get
```
Get-AzResiliencyDrillRunReportDownloadUrl -DrillName <String> -DrillRunName <String>
 -ServiceGroupName <String> -OperationId <String> -Body <IListReportDownloadUrlRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzResiliencyDrillRunReportDownloadUrl -InputObject <IResiliencyIdentity> -OperationId <String>
 -Body <IListReportDownloadUrlRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### GetViaIdentityDrill
```
Get-AzResiliencyDrillRunReportDownloadUrl -DrillInputObject <IResiliencyIdentity> -DrillRunName <String>
 -OperationId <String> -Body <IListReportDownloadUrlRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentityDrillExpanded
```
Get-AzResiliencyDrillRunReportDownloadUrl -DrillInputObject <IResiliencyIdentity> -DrillRunName <String>
 -OperationId <String> [-Format <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### GetViaIdentityExpanded
```
Get-AzResiliencyDrillRunReportDownloadUrl -InputObject <IResiliencyIdentity> -OperationId <String>
 [-Format <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentityServiceGroup
```
Get-AzResiliencyDrillRunReportDownloadUrl -DrillName <String> -DrillRunName <String>
 -ServiceGroupInputObject <IResiliencyIdentity> -OperationId <String> -Body <IListReportDownloadUrlRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentityServiceGroupExpanded
```
Get-AzResiliencyDrillRunReportDownloadUrl -DrillName <String> -DrillRunName <String>
 -ServiceGroupInputObject <IResiliencyIdentity> -OperationId <String> [-Format <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaJsonFilePath
```
Get-AzResiliencyDrillRunReportDownloadUrl -DrillName <String> -DrillRunName <String>
 -ServiceGroupName <String> -OperationId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaJsonString
```
Get-AzResiliencyDrillRunReportDownloadUrl -DrillName <String> -DrillRunName <String>
 -ServiceGroupName <String> -OperationId <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This returns a short-lived, read-only URL to download the report for this Drill Run.
The URL expires at the returned expiryTimestamp and grants access to that single report only.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
Request to mint a short-lived, read-only download URL for a Drill Run report.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IListReportDownloadUrlRequest
Parameter Sets: Get, GetViaIdentity, GetViaIdentityDrill, GetViaIdentityServiceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -DrillInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity
Parameter Sets: GetViaIdentityDrill, GetViaIdentityDrillExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DrillName
The name of the Drill

```yaml
Type: System.String
Parameter Sets: Get, GetExpanded, GetViaIdentityServiceGroup, GetViaIdentityServiceGroupExpanded, GetViaJsonFilePath, GetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DrillRunName
The name of the DrillRun (GUID).

```yaml
Type: System.String
Parameter Sets: Get, GetExpanded, GetViaIdentityDrill, GetViaIdentityDrillExpanded, GetViaIdentityServiceGroup, GetViaIdentityServiceGroupExpanded, GetViaJsonFilePath, GetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Format
Format of the report to download.
Defaults to Html when not specified.

```yaml
Type: System.String
Parameter Sets: GetExpanded, GetViaIdentityDrillExpanded, GetViaIdentityExpanded, GetViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity
Parameter Sets: GetViaIdentity, GetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Get operation

```yaml
Type: System.String
Parameter Sets: GetViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Get operation

```yaml
Type: System.String
Parameter Sets: GetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OperationId
A GUID that represents the Long Running OperationId.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity
Parameter Sets: GetViaIdentityServiceGroup, GetViaIdentityServiceGroupExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServiceGroupName
The name of the service group.

```yaml
Type: System.String
Parameter Sets: Get, GetExpanded, GetViaJsonFilePath, GetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IListReportDownloadUrlRequest

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IListReportDownloadUrlResponse

## NOTES

## RELATED LINKS


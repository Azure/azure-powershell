---
external help file:
Module Name: Az.Resiliency
online version: https://learn.microsoft.com/powershell/module/az.resiliency/stop-azresiliencydrill
schema: 2.0.0
---

# Stop-AzResiliencyDrill

## SYNOPSIS
This ends the currently running instance of the Drill.

## SYNTAX

### StopExpanded (Default)
```
Stop-AzResiliencyDrill -Name <String> -ServiceGroupName <String> -OperationId <String> -Attestation <String>
 -AttestationNote <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Stop
```
Stop-AzResiliencyDrill -Name <String> -ServiceGroupName <String> -OperationId <String>
 -Body <IDrillEndRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### StopViaIdentity
```
Stop-AzResiliencyDrill -InputObject <IResiliencyIdentity> -OperationId <String> -Body <IDrillEndRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopViaIdentityExpanded
```
Stop-AzResiliencyDrill -InputObject <IResiliencyIdentity> -OperationId <String> -Attestation <String>
 -AttestationNote <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### StopViaIdentityServiceGroup
```
Stop-AzResiliencyDrill -Name <String> -ServiceGroupInputObject <IResiliencyIdentity> -OperationId <String>
 -Body <IDrillEndRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### StopViaIdentityServiceGroupExpanded
```
Stop-AzResiliencyDrill -Name <String> -ServiceGroupInputObject <IResiliencyIdentity> -OperationId <String>
 -Attestation <String> -AttestationNote <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### StopViaJsonFilePath
```
Stop-AzResiliencyDrill -Name <String> -ServiceGroupName <String> -OperationId <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopViaJsonString
```
Stop-AzResiliencyDrill -Name <String> -ServiceGroupName <String> -OperationId <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This ends the currently running instance of the Drill.

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

### -Attestation
Attestation Status

```yaml
Type: System.String
Parameter Sets: StopExpanded, StopViaIdentityExpanded, StopViaIdentityServiceGroupExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttestationNote
Notes

```yaml
Type: System.String
Parameter Sets: StopExpanded, StopViaIdentityExpanded, StopViaIdentityServiceGroupExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
Request body of the End Action of Drill.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IDrillEndRequest
Parameter Sets: Stop, StopViaIdentity, StopViaIdentityServiceGroup
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity
Parameter Sets: StopViaIdentity, StopViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Stop operation

```yaml
Type: System.String
Parameter Sets: StopViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Stop operation

```yaml
Type: System.String
Parameter Sets: StopViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Drill

```yaml
Type: System.String
Parameter Sets: Stop, StopExpanded, StopViaIdentityServiceGroup, StopViaIdentityServiceGroupExpanded, StopViaJsonFilePath, StopViaJsonString
Aliases: DrillName

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
Parameter Sets: StopViaIdentityServiceGroup, StopViaIdentityServiceGroupExpanded
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
Parameter Sets: Stop, StopExpanded, StopViaJsonFilePath, StopViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IDrillEndRequest

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IDrillActionResponse

## NOTES

## RELATED LINKS


---
external help file:
Module Name: Az.Resilience
online version: https://learn.microsoft.com/powershell/module/az.resilience/stop-azresiliencedrill
schema: 2.0.0
---

# Stop-AzResilienceDrill

## SYNOPSIS
This ends the currently running instance of the Drill.

## SYNTAX

### StopExpanded (Default)
```
Stop-AzResilienceDrill -Name <String> -ServiceGroupName <String> -OperationId <String> -Attestation <String>
 -AttestationNote <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Stop
```
Stop-AzResilienceDrill -Name <String> -ServiceGroupName <String> -OperationId <String>
 -Body <IDrillEndRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### StopViaIdentity
```
Stop-AzResilienceDrill -InputObject <IResilienceIdentity> -OperationId <String> -Body <IDrillEndRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopViaIdentityExpanded
```
Stop-AzResilienceDrill -InputObject <IResilienceIdentity> -OperationId <String> -Attestation <String>
 -AttestationNote <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### StopViaIdentityServiceGroup
```
Stop-AzResilienceDrill -Name <String> -ServiceGroupInputObject <IResilienceIdentity> -OperationId <String>
 -Body <IDrillEndRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### StopViaIdentityServiceGroupExpanded
```
Stop-AzResilienceDrill -Name <String> -ServiceGroupInputObject <IResilienceIdentity> -OperationId <String>
 -Attestation <String> -AttestationNote <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### StopViaJsonFilePath
```
Stop-AzResilienceDrill -Name <String> -ServiceGroupName <String> -OperationId <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopViaJsonString
```
Stop-AzResilienceDrill -Name <String> -ServiceGroupName <String> -OperationId <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This ends the currently running instance of the Drill.

## EXAMPLES

### Example 1: Stop a drill
```powershell
Stop-AzResilienceDrill `
  -Name 'drill-zonal-payments' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -Attestation 'Success' `
  -AttestationNote 'Drill completed; all tier-1 services recovered within RTO.'
```

Stops the running drill and records the attestation outcome.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IDrillEndRequest
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
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

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IDrillEndRequest

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IDrillActionResponse

## NOTES

## RELATED LINKS


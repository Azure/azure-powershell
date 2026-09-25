---
external help file:
Module Name: Az.Resiliency
online version: https://learn.microsoft.com/powershell/module/az.resiliency/invoke-azresiliencyrecoveryplantestfailovercleanup
schema: 2.0.0
---

# Invoke-AzResiliencyRecoveryPlanTestFailoverCleanup

## SYNOPSIS
This action triggers the test failover cleanup operation on the recovery orchestration plan for the qualified resources.

## SYNTAX

### InvokeExpanded (Default)
```
Invoke-AzResiliencyRecoveryPlanTestFailoverCleanup -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> [-Comment <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Invoke
```
Invoke-AzResiliencyRecoveryPlanTestFailoverCleanup -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -Body <ITestFailoverCleanupRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InvokeViaIdentity
```
Invoke-AzResiliencyRecoveryPlanTestFailoverCleanup -InputObject <IResiliencyIdentity> -OperationId <String>
 -Body <ITestFailoverCleanupRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### InvokeViaIdentityExpanded
```
Invoke-AzResiliencyRecoveryPlanTestFailoverCleanup -InputObject <IResiliencyIdentity> -OperationId <String>
 [-Comment <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InvokeViaIdentityServiceGroup
```
Invoke-AzResiliencyRecoveryPlanTestFailoverCleanup -RecoveryPlanName <String>
 -ServiceGroupInputObject <IResiliencyIdentity> -OperationId <String> -Body <ITestFailoverCleanupRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InvokeViaIdentityServiceGroupExpanded
```
Invoke-AzResiliencyRecoveryPlanTestFailoverCleanup -RecoveryPlanName <String>
 -ServiceGroupInputObject <IResiliencyIdentity> -OperationId <String> [-Comment <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InvokeViaJsonFilePath
```
Invoke-AzResiliencyRecoveryPlanTestFailoverCleanup -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### InvokeViaJsonString
```
Invoke-AzResiliencyRecoveryPlanTestFailoverCleanup -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This action triggers the test failover cleanup operation on the recovery orchestration plan for the qualified resources.

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
TestFailoverCleanup post action request.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.ITestFailoverCleanupRequest
Parameter Sets: Invoke, InvokeViaIdentity, InvokeViaIdentityServiceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Comment
Comments for test failover cleanup.

```yaml
Type: System.String
Parameter Sets: InvokeExpanded, InvokeViaIdentityExpanded, InvokeViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
Parameter Sets: InvokeViaIdentity, InvokeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Invoke operation

```yaml
Type: System.String
Parameter Sets: InvokeViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Invoke operation

```yaml
Type: System.String
Parameter Sets: InvokeViaJsonString
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

### -RecoveryPlanName
The name of the recovery orchestration plan.

```yaml
Type: System.String
Parameter Sets: Invoke, InvokeExpanded, InvokeViaIdentityServiceGroup, InvokeViaIdentityServiceGroupExpanded, InvokeViaJsonFilePath, InvokeViaJsonString
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
Parameter Sets: InvokeViaIdentityServiceGroup, InvokeViaIdentityServiceGroupExpanded
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
Parameter Sets: Invoke, InvokeExpanded, InvokeViaJsonFilePath, InvokeViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.ITestFailoverCleanupRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IRecoveryPlanActionBaseResponse

## NOTES

## RELATED LINKS


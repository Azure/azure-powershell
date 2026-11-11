---
external help file:
Module Name: Az.ResilienceManagement
online version: https://learn.microsoft.com/powershell/module/az.resiliencemanagement/start-azresiliencemanagementrecoveryplantestfailovercleanup
schema: 2.0.0
---

# Start-AzResilienceManagementRecoveryPlanTestFailoverCleanup

## SYNOPSIS
This action triggers the test failover cleanup operation on the recovery orchestration plan for the qualified resources.

## SYNTAX

### TriggerExpanded (Default)
```
Start-AzResilienceManagementRecoveryPlanTestFailoverCleanup -RecoveryPlanName <String>
 -ServiceGroupName <String> -OperationId <String> [-Comment <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Trigger
```
Start-AzResilienceManagementRecoveryPlanTestFailoverCleanup -RecoveryPlanName <String>
 -ServiceGroupName <String> -OperationId <String> -Body <ITestFailoverCleanupRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TriggerViaIdentity
```
Start-AzResilienceManagementRecoveryPlanTestFailoverCleanup -InputObject <IResilienceManagementIdentity>
 -OperationId <String> -Body <ITestFailoverCleanupRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TriggerViaIdentityExpanded
```
Start-AzResilienceManagementRecoveryPlanTestFailoverCleanup -InputObject <IResilienceManagementIdentity>
 -OperationId <String> [-Comment <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### TriggerViaIdentityServiceGroup
```
Start-AzResilienceManagementRecoveryPlanTestFailoverCleanup -RecoveryPlanName <String>
 -ServiceGroupInputObject <IResilienceManagementIdentity> -OperationId <String>
 -Body <ITestFailoverCleanupRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### TriggerViaIdentityServiceGroupExpanded
```
Start-AzResilienceManagementRecoveryPlanTestFailoverCleanup -RecoveryPlanName <String>
 -ServiceGroupInputObject <IResilienceManagementIdentity> -OperationId <String> [-Comment <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TriggerViaJsonFilePath
```
Start-AzResilienceManagementRecoveryPlanTestFailoverCleanup -RecoveryPlanName <String>
 -ServiceGroupName <String> -OperationId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TriggerViaJsonString
```
Start-AzResilienceManagementRecoveryPlanTestFailoverCleanup -RecoveryPlanName <String>
 -ServiceGroupName <String> -OperationId <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This action triggers the test failover cleanup operation on the recovery orchestration plan for the qualified resources.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
{{ Add code here }}
```



### -------------------------- EXAMPLE 2 --------------------------
```powershell
{{ Add code here }}
```



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
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.ITestFailoverCleanupRequest
Parameter Sets: Trigger, TriggerViaIdentity, TriggerViaIdentityServiceGroup
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
Parameter Sets: TriggerExpanded, TriggerViaIdentityExpanded, TriggerViaIdentityServiceGroupExpanded
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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity
Parameter Sets: TriggerViaIdentity, TriggerViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Trigger operation

```yaml
Type: System.String
Parameter Sets: TriggerViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Trigger operation

```yaml
Type: System.String
Parameter Sets: TriggerViaJsonString
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
Parameter Sets: Trigger, TriggerExpanded, TriggerViaIdentityServiceGroup, TriggerViaIdentityServiceGroupExpanded, TriggerViaJsonFilePath, TriggerViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceGroupInputObject
Identity Parameter
To construct, see NOTES section for SERVICEGROUPINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity
Parameter Sets: TriggerViaIdentityServiceGroup, TriggerViaIdentityServiceGroupExpanded
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
Parameter Sets: Trigger, TriggerExpanded, TriggerViaJsonFilePath, TriggerViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.ITestFailoverCleanupRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IRecoveryPlanActionBaseResponse

## NOTES

## RELATED LINKS


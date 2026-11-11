---
external help file:
Module Name: Az.ResilienceManagement
online version: https://learn.microsoft.com/powershell/module/az.resiliencemanagement/start-azresiliencemanagementdrillrunreprotect
schema: 2.0.0
---

# Start-AzResilienceManagementDrillRunReprotect

## SYNOPSIS
This initiates a new Reprotect operation on this Drill Run.

## SYNTAX

### TriggerExpanded (Default)
```
Start-AzResilienceManagementDrillRunReprotect -DrillName <String> -DrillRunName <String>
 -ServiceGroupName <String> -OperationId <String> [-ReprotectRequestPropertySelectedResourceId <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Trigger
```
Start-AzResilienceManagementDrillRunReprotect -DrillName <String> -DrillRunName <String>
 -ServiceGroupName <String> -OperationId <String> -Body <IDrillRunReprotectRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TriggerViaIdentity
```
Start-AzResilienceManagementDrillRunReprotect -InputObject <IResilienceManagementIdentity>
 -OperationId <String> -Body <IDrillRunReprotectRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TriggerViaIdentityDrill
```
Start-AzResilienceManagementDrillRunReprotect -DrillInputObject <IResilienceManagementIdentity>
 -DrillRunName <String> -OperationId <String> -Body <IDrillRunReprotectRequest> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TriggerViaIdentityDrillExpanded
```
Start-AzResilienceManagementDrillRunReprotect -DrillInputObject <IResilienceManagementIdentity>
 -DrillRunName <String> -OperationId <String> [-ReprotectRequestPropertySelectedResourceId <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TriggerViaIdentityExpanded
```
Start-AzResilienceManagementDrillRunReprotect -InputObject <IResilienceManagementIdentity>
 -OperationId <String> [-ReprotectRequestPropertySelectedResourceId <String[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TriggerViaIdentityServiceGroup
```
Start-AzResilienceManagementDrillRunReprotect -DrillName <String> -DrillRunName <String>
 -ServiceGroupInputObject <IResilienceManagementIdentity> -OperationId <String>
 -Body <IDrillRunReprotectRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### TriggerViaIdentityServiceGroupExpanded
```
Start-AzResilienceManagementDrillRunReprotect -DrillName <String> -DrillRunName <String>
 -ServiceGroupInputObject <IResilienceManagementIdentity> -OperationId <String>
 [-ReprotectRequestPropertySelectedResourceId <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TriggerViaJsonFilePath
```
Start-AzResilienceManagementDrillRunReprotect -DrillName <String> -DrillRunName <String>
 -ServiceGroupName <String> -OperationId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TriggerViaJsonString
```
Start-AzResilienceManagementDrillRunReprotect -DrillName <String> -DrillRunName <String>
 -ServiceGroupName <String> -OperationId <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This initiates a new Reprotect operation on this Drill Run.

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
Request body for Reprotect API.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IDrillRunReprotectRequest
Parameter Sets: Trigger, TriggerViaIdentity, TriggerViaIdentityDrill, TriggerViaIdentityServiceGroup
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
To construct, see NOTES section for DRILLINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity
Parameter Sets: TriggerViaIdentityDrill, TriggerViaIdentityDrillExpanded
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
Parameter Sets: Trigger, TriggerExpanded, TriggerViaIdentityServiceGroup, TriggerViaIdentityServiceGroupExpanded, TriggerViaJsonFilePath, TriggerViaJsonString
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
Parameter Sets: Trigger, TriggerExpanded, TriggerViaIdentityDrill, TriggerViaIdentityDrillExpanded, TriggerViaIdentityServiceGroup, TriggerViaIdentityServiceGroupExpanded, TriggerViaJsonFilePath, TriggerViaJsonString
Aliases:

Required: True
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

### -ReprotectRequestPropertySelectedResourceId
Selected recovery resource Ids to be processed.
If not provided, all qualified resources will be processed.

```yaml
Type: System.String[]
Parameter Sets: TriggerExpanded, TriggerViaIdentityDrillExpanded, TriggerViaIdentityExpanded, TriggerViaIdentityServiceGroupExpanded
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IDrillRunReprotectRequest

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IDrillRunActionResponse

## NOTES

## RELATED LINKS


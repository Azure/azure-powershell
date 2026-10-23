---
external help file:
Module Name: Az.ResilienceManagement
online version: https://learn.microsoft.com/powershell/module/az.resiliencemanagement/invoke-azresiliencemanagementmarkdrillrunascomplete
schema: 2.0.0
---

# Invoke-AzResilienceManagementMarkDrillRunAsComplete

## SYNOPSIS
This enables the user to mark this stage as complete, disabling further retries on it.

## SYNTAX

### MarkExpanded (Default)
```
Invoke-AzResilienceManagementMarkDrillRunAsComplete -DrillName <String> -DrillRunName <String>
 -ServiceGroupName <String> -OperationId <String> -DrillRunStage <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Mark
```
Invoke-AzResilienceManagementMarkDrillRunAsComplete -DrillName <String> -DrillRunName <String>
 -ServiceGroupName <String> -OperationId <String> -Body <IMarkAsCompleteRequest> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MarkViaIdentity
```
Invoke-AzResilienceManagementMarkDrillRunAsComplete -InputObject <IResilienceManagementIdentity>
 -OperationId <String> -Body <IMarkAsCompleteRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MarkViaIdentityDrill
```
Invoke-AzResilienceManagementMarkDrillRunAsComplete -DrillInputObject <IResilienceManagementIdentity>
 -DrillRunName <String> -OperationId <String> -Body <IMarkAsCompleteRequest> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MarkViaIdentityDrillExpanded
```
Invoke-AzResilienceManagementMarkDrillRunAsComplete -DrillInputObject <IResilienceManagementIdentity>
 -DrillRunName <String> -OperationId <String> -DrillRunStage <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MarkViaIdentityExpanded
```
Invoke-AzResilienceManagementMarkDrillRunAsComplete -InputObject <IResilienceManagementIdentity>
 -OperationId <String> -DrillRunStage <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### MarkViaIdentityServiceGroup
```
Invoke-AzResilienceManagementMarkDrillRunAsComplete -DrillName <String> -DrillRunName <String>
 -ServiceGroupInputObject <IResilienceManagementIdentity> -OperationId <String> -Body <IMarkAsCompleteRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MarkViaIdentityServiceGroupExpanded
```
Invoke-AzResilienceManagementMarkDrillRunAsComplete -DrillName <String> -DrillRunName <String>
 -ServiceGroupInputObject <IResilienceManagementIdentity> -OperationId <String> -DrillRunStage <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MarkViaJsonFilePath
```
Invoke-AzResilienceManagementMarkDrillRunAsComplete -DrillName <String> -DrillRunName <String>
 -ServiceGroupName <String> -OperationId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MarkViaJsonString
```
Invoke-AzResilienceManagementMarkDrillRunAsComplete -DrillName <String> -DrillRunName <String>
 -ServiceGroupName <String> -OperationId <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This enables the user to mark this stage as complete, disabling further retries on it.

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
Request body for MarkAsComplete API.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IMarkAsCompleteRequest
Parameter Sets: Mark, MarkViaIdentity, MarkViaIdentityDrill, MarkViaIdentityServiceGroup
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
Parameter Sets: MarkViaIdentityDrill, MarkViaIdentityDrillExpanded
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
Parameter Sets: Mark, MarkExpanded, MarkViaIdentityServiceGroup, MarkViaIdentityServiceGroupExpanded, MarkViaJsonFilePath, MarkViaJsonString
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
Parameter Sets: Mark, MarkExpanded, MarkViaIdentityDrill, MarkViaIdentityDrillExpanded, MarkViaIdentityServiceGroup, MarkViaIdentityServiceGroupExpanded, MarkViaJsonFilePath, MarkViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DrillRunStage
State of the Drill Run.

```yaml
Type: System.String
Parameter Sets: MarkExpanded, MarkViaIdentityDrillExpanded, MarkViaIdentityExpanded, MarkViaIdentityServiceGroupExpanded
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
Parameter Sets: MarkViaIdentity, MarkViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Mark operation

```yaml
Type: System.String
Parameter Sets: MarkViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Mark operation

```yaml
Type: System.String
Parameter Sets: MarkViaJsonString
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
To construct, see NOTES section for SERVICEGROUPINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity
Parameter Sets: MarkViaIdentityServiceGroup, MarkViaIdentityServiceGroupExpanded
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
Parameter Sets: Mark, MarkExpanded, MarkViaJsonFilePath, MarkViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IMarkAsCompleteRequest

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IMarkAsCompleteResponse

## NOTES

## RELATED LINKS


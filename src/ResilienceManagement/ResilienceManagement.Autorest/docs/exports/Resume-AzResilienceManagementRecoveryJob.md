---
external help file:
Module Name: Az.ResilienceManagement
online version: https://learn.microsoft.com/powershell/module/az.resiliencemanagement/resume-azresiliencemanagementrecoveryjob
schema: 2.0.0
---

# Resume-AzResilienceManagementRecoveryJob

## SYNOPSIS
This action resumes the ongoing recovery orchestration job that was paused for required user intervention.

## SYNTAX

### ResumeExpanded (Default)
```
Resume-AzResilienceManagementRecoveryJob -Name <String> -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> [-Description <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Resume
```
Resume-AzResilienceManagementRecoveryJob -Name <String> -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -Body <IRecoveryActionRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ResumeViaIdentity
```
Resume-AzResilienceManagementRecoveryJob -InputObject <IResilienceManagementIdentity> -OperationId <String>
 -Body <IRecoveryActionRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ResumeViaIdentityExpanded
```
Resume-AzResilienceManagementRecoveryJob -InputObject <IResilienceManagementIdentity> -OperationId <String>
 [-Description <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ResumeViaIdentityRecoveryPlan
```
Resume-AzResilienceManagementRecoveryJob -Name <String>
 -RecoveryPlanInputObject <IResilienceManagementIdentity> -OperationId <String> -Body <IRecoveryActionRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ResumeViaIdentityRecoveryPlanExpanded
```
Resume-AzResilienceManagementRecoveryJob -Name <String>
 -RecoveryPlanInputObject <IResilienceManagementIdentity> -OperationId <String> [-Description <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ResumeViaIdentityServiceGroup
```
Resume-AzResilienceManagementRecoveryJob -Name <String> -RecoveryPlanName <String>
 -ServiceGroupInputObject <IResilienceManagementIdentity> -OperationId <String> -Body <IRecoveryActionRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ResumeViaIdentityServiceGroupExpanded
```
Resume-AzResilienceManagementRecoveryJob -Name <String> -RecoveryPlanName <String>
 -ServiceGroupInputObject <IResilienceManagementIdentity> -OperationId <String> [-Description <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ResumeViaJsonFilePath
```
Resume-AzResilienceManagementRecoveryJob -Name <String> -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ResumeViaJsonString
```
Resume-AzResilienceManagementRecoveryJob -Name <String> -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This action resumes the ongoing recovery orchestration job that was paused for required user intervention.

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
Request body for providing user input for a recovery action.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IRecoveryActionRequest
Parameter Sets: Resume, ResumeViaIdentity, ResumeViaIdentityRecoveryPlan, ResumeViaIdentityServiceGroup
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

### -Description
User-provided input for the action.

```yaml
Type: System.String
Parameter Sets: ResumeExpanded, ResumeViaIdentityExpanded, ResumeViaIdentityRecoveryPlanExpanded, ResumeViaIdentityServiceGroupExpanded
Aliases:

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
Parameter Sets: ResumeViaIdentity, ResumeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Resume operation

```yaml
Type: System.String
Parameter Sets: ResumeViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Resume operation

```yaml
Type: System.String
Parameter Sets: ResumeViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The unique name (GUID) of the recovery job.

```yaml
Type: System.String
Parameter Sets: Resume, ResumeExpanded, ResumeViaIdentityRecoveryPlan, ResumeViaIdentityRecoveryPlanExpanded, ResumeViaIdentityServiceGroup, ResumeViaIdentityServiceGroupExpanded, ResumeViaJsonFilePath, ResumeViaJsonString
Aliases: RecoveryJobName

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

### -RecoveryPlanInputObject
Identity Parameter
To construct, see NOTES section for RECOVERYPLANINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity
Parameter Sets: ResumeViaIdentityRecoveryPlan, ResumeViaIdentityRecoveryPlanExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RecoveryPlanName
The name of the recovery orchestration plan.

```yaml
Type: System.String
Parameter Sets: Resume, ResumeExpanded, ResumeViaIdentityServiceGroup, ResumeViaIdentityServiceGroupExpanded, ResumeViaJsonFilePath, ResumeViaJsonString
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
Parameter Sets: ResumeViaIdentityServiceGroup, ResumeViaIdentityServiceGroupExpanded
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
Parameter Sets: Resume, ResumeExpanded, ResumeViaJsonFilePath, ResumeViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IRecoveryActionRequest

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IErrorResponse

## NOTES

## RELATED LINKS


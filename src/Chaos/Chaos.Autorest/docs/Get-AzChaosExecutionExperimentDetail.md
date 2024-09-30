---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/get-azchaosexecutionexperimentdetail
schema: 2.0.0
---

# Get-AzChaosExecutionExperimentDetail

## SYNOPSIS
Execution details of an experiment resource.

## SYNTAX

### Execution (Default)
```
Get-AzChaosExecutionExperimentDetail -ExecutionId <String> -ExperimentName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ExecutionViaIdentity
```
Get-AzChaosExecutionExperimentDetail -InputObject <IChaosIdentity> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ExecutionViaIdentityExperiment
```
Get-AzChaosExecutionExperimentDetail -ExecutionId <String> -ExperimentInputObject <IChaosIdentity>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Execution details of an experiment resource.

## EXAMPLES

### Example 1: Execution details of an experiment resource.
```powershell
Get-AzChaosExecutionExperimentDetail -ExperimentName experiment-test -ResourceGroupName azps_test_group_chaos -ExecutionId 13E31E28-45F4-402E-99B4-DF19A78E457E
```

```output
FailureReason      :
Id                 : /subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Chaos/experiments/experiment-test/executions/13E31E28-45F4-402E-99B4-DF19A
                     78E457E
LastActionAt       : 2024-05-06 09:54:20 AM
Name               : 13E31E28-45F4-402E-99B4-DF19A78E457E
ResourceGroupName  : azps_test_group_chaos
RunInformationStep : {{
                       "stepName": "step1",
                       "stepId": "step1",
                       "status": "completed",
                       "branches": [
                         {
                           "branchName": "branch1",
                           "branchId": "branch1",
                           "status": "completed",
                           "actions": [
                             {
                               "actionName": "urn:csci:microsoft:virtualMachine:shutdown/1.0",
                               "actionId": "c5e62ae5-60c2-4cb4-b620-890bbf671c7b",
                               "status": "completed",
                               "startTime": "2024-05-06T09:43:15.6470366Z",
                               "endTime": "2024-05-06T09:54:16.1794070Z",
                               "targets": [
                                 {
                                   "status": "completed",
                                   "target": "urn:x-chaos-targets:Azure-virtualMachine:/subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Compute/virt
                     ualMachines/exampleVM/providers/Microsoft.Chaos/targets/microsoft-virtualMachine",
                                   "targetFailedTime": "0001-01-01T00:00:00.0000000Z",
                                   "targetCompletedTime": "2024-05-06T09:54:16.1708885Z"
                                 }
                               ]
                             }
                           ]
                         }
                       ]
                     }}
StartedAt          : 2024-05-06 09:42:44 AM
Status             : Success
StoppedAt          : 2024-05-06 09:54:20 AM
Type               : Microsoft.Chaos/experiments/executions
```

Execution details of an experiment resource.

## PARAMETERS

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

### -ExecutionId
GUID that represents a Experiment execution detail.

```yaml
Type: System.String
Parameter Sets: Execution, ExecutionViaIdentityExperiment
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExperimentInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: ExecutionViaIdentityExperiment
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ExperimentName
String that represents a Experiment resource name.

```yaml
Type: System.String
Parameter Sets: Execution
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: ExecutionViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
String that represents an Azure resource group.

```yaml
Type: System.String
Parameter Sets: Execution
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
GUID that represents an Azure subscription ID.

```yaml
Type: System.String[]
Parameter Sets: Execution
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IExperimentExecutionDetails

## NOTES

## RELATED LINKS


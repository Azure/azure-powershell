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
Get-AzChaosExecutionExperimentDetail -ExperimentName experiment-test -ResourceGroupName azps_test_group_chaos -ExecutionId 1B326FD9-1E4D-4BD1-98CA-F700071C20E1
```

```output
FailureReason      :
Id                 : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_chaos/providers/Microsoft.Chaos/experiments/experiment-test/executions/1B326FD9-1E4D-4BD1-98CA-F700071C2
                     0E1
LastActionAt       :
Name               : 1B326FD9-1E4D-4BD1-98CA-F700071C20E1
ResourceGroupName  : azps_test_group_chaos
RunInformationStep :
StartedAt          : 2024-04-02 09:39:17 AM
Status             : PreProcessingQueued
StoppedAt          :
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


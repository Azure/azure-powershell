---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/get-azchaosexperimentexecution
schema: 2.0.0
---

# Get-AzChaosExperimentExecution

## SYNOPSIS
Get an execution of an Experiment resource.

## SYNTAX

### List (Default)
```
Get-AzChaosExperimentExecution -ExperimentName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzChaosExperimentExecution -ExecutionId <String> -ExperimentName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzChaosExperimentExecution -InputObject <IChaosIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityExperiment
```
Get-AzChaosExperimentExecution -ExecutionId <String> -ExperimentInputObject <IChaosIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get an execution of an Experiment resource.

## EXAMPLES

### Example 1: Get an execution of an Experiment resource.
```powershell
Get-AzChaosExperimentExecution -ExperimentName experiment-test -ResourceGroupName azps_test_group_chaos
```

```output
Name                                 ResourceGroupName
----                                 -----------------
F7FEAFD8-5D50-42A1-ADB7-044A19B997AA azps_test_group_chaos
13E31E28-45F4-402E-99B4-DF19A78E457E azps_test_group_chaos
```

Get an execution of an Experiment resource.

### Example 2: Get an execution of an Experiment resource.
```powershell
Get-AzChaosExperimentExecution -ExperimentName experiment-test -ResourceGroupName azps_test_group_chaos -ExecutionId 13E31E28-45F4-402E-99B4-DF19A78E457E
```

```output
Id                : /subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Chaos/experiments/experiment-test/executions/13E31E28-45F4-402E-99B4-DF19A7
                    8E457E
Name              : 13E31E28-45F4-402E-99B4-DF19A78E457E
ResourceGroupName : azps_test_group_chaos
StartedAt         : 2024-05-06 09:42:44 AM
Status            : Success
StoppedAt         : 2024-05-06 09:54:20 AM
Type              : Microsoft.Chaos/experiments/executions
```

Get an execution of an Experiment resource.

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
Parameter Sets: Get, GetViaIdentityExperiment
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
Parameter Sets: GetViaIdentityExperiment
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
Parameter Sets: Get, List
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
Parameter Sets: GetViaIdentity
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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IExperimentExecution

## NOTES

## RELATED LINKS


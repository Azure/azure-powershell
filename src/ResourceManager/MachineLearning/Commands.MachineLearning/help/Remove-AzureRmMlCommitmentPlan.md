---
external help file: Microsoft.Azure.Commands.MachineLearning.dll-Help.xml
online version: 
schema: 2.0.0
---

# Remove-AzureRmMlCommitmentPlan

## SYNOPSIS
Deletes a commitment plan.

## SYNTAX

### Remove an Azure ML commitment plan specified by name and resource group.
```
Remove-AzureRmMlCommitmentPlan -ResourceGroupName <String> -Name <String> [-Force] [-Confirm]
```

### Remove an Azure ML commitment plan specified as an object.
```
Remove-AzureRmMlCommitmentPlan -MlCommitmentPlan <CommitmentPlan> [-Force] [-Confirm]
```

## DESCRIPTION
Deletes an Azure Machine Learning commitment plan. Note that commitment plans which have commitment associations cannot be deleted. Commitment associations can only be deleted by their target resource. For example, if you delete an Azure Machine Learning web service, the commitment association which associates the web service to a commitment plan will also be deleted.

## EXAMPLES

### --------------------------  Example 1: Delete a commitment plan  --------------------------
@{paragraph=PS C:\\\>}

```
Remove-AzureRmMlCommitmentPlan -ResourceGroupName "MyResourceGroup" -Name "MyCommitmentPlanName"
```

## PARAMETERS

### -Force
Do not ask for confirmation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MlCommitmentPlan
The machine learning web service object.

```yaml
Type: CommitmentPlan
Parameter Sets: Remove an Azure ML commitment plan specified as an object.
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Azure ML commitment plan.

```yaml
Type: String
Parameter Sets: Remove an Azure ML commitment plan specified by name and resource group.
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group for the Azure ML commitment plan.

```yaml
Type: String
Parameter Sets: Remove an Azure ML commitment plan specified by name and resource group.
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### Microsoft.Azure.Management.MachineLearning.CommitmentPlans.Models.CommitmentPlan

## OUTPUTS

### None

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, machine, machine learning, azureml

## RELATED LINKS


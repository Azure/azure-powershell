---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.machinelearningservices/get-azmlworkspacefeature
schema: 2.0.0
---

# Get-AzMLWorkspaceFeature

## SYNOPSIS
Lists all enabled features for a workspace

## SYNTAX

```
Get-AzMLWorkspaceFeature -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists all enabled features for a workspace

## EXAMPLES

### Example 1: Lists all enabled features for a workspace
```powershell
Get-AzMLWorkspaceFeature  -ResourceGroupName ml-rg-test -Name mlworkspace-portal01
```

```output
Description                                                                            DisplayName
-----------                                                                            -----------
Raw feature explanation for AutoML models                                              Model Explanability
Create, edit or delete AutoML experiments in the SDK                                   Create edit experiments SDK
Create, edit or delete HyperDrive experiments in the SDK                               Create edit hyperdrive SDK
Select or upload a dataset to train on from datasets in the SDK                        Dataset integration from SDK
Deploy an AutoML model from the SDK                                                    Deploy model SDK
Auto train a forecasting DNN from SDK                                                  DNN Forecasting SDK
Auto train an NLP DNN from SDK                                                         DNN NLP SDK
Deploy and view explainability dashboard for inference data                            Explainability at Inference time SDK
Create and view explainability dashboard in the SDK                                    Explainability dashboard in SDK at training time
```

Lists all enabled features for a workspace

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

### -Name
Name of Azure Machine Learning workspace.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IAmlUserFeature

## NOTES

## RELATED LINKS


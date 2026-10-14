---
external help file: Az.MachineLearningServices-help.xml
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.machinelearningservices/update-azmlworkspacemodelversion
schema: 2.0.0
---

# Update-AzMLWorkspaceModelVersion

## SYNOPSIS
Update version.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMLWorkspaceModelVersion -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Version <String> -WorkspaceName <String> [-Description <String>] [-Flavor <Hashtable>] [-IsArchived]
 [-JobName <String>] [-ModelType <String>] [-ModelUri <String>] [-ResourceBaseProperty <Hashtable>]
 [-Stage <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityWorkspaceExpanded
```
Update-AzMLWorkspaceModelVersion -Name <String> -Version <String>
 -WorkspaceInputObject <IMachineLearningServicesIdentity> [-Description <String>] [-Flavor <Hashtable>]
 [-IsArchived] [-JobName <String>] [-ModelType <String>] [-ModelUri <String>]
 [-ResourceBaseProperty <Hashtable>] [-Stage <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityModelExpanded
```
Update-AzMLWorkspaceModelVersion -Version <String> -ModelInputObject <IMachineLearningServicesIdentity>
 [-Description <String>] [-Flavor <Hashtable>] [-IsArchived] [-JobName <String>] [-ModelType <String>]
 [-ModelUri <String>] [-ResourceBaseProperty <Hashtable>] [-Stage <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMLWorkspaceModelVersion -InputObject <IMachineLearningServicesIdentity> [-Description <String>]
 [-Flavor <Hashtable>] [-IsArchived] [-JobName <String>] [-ModelType <String>] [-ModelUri <String>]
 [-ResourceBaseProperty <Hashtable>] [-Stage <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update version.

## EXAMPLES

### Example 1: Create or update model version
```powershell
Update-AzMLWorkspaceModelVersion -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name heart-classifier-mlflow -Version 1 -Description "Test heart-classifier"
```

```output
Description                  : Test heart-classifier
Flavor                       : {
                                 "python_function": {
                                   "data": {
                                     "env": "conda.yaml",
                                     "loader_module": "mlflow.sklearn",
                                     "model_path": "model.pkl",
                                     "python_version": "3.8.5"
                                   }
                                 },
                                 "sklearn": {
                                   "data": {
                                     "pickled_model": "model.pkl",
                                     "serialization_format": "cloudpickle",
                                     "sklearn_version": "1.1.2"
                                   }
                                 }
                               }
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/models/heart-classifier-mlflow/versions/1
IsAnonymou                   : False
IsArchived                   : False
JobName                      : 
ModelType                    : mlflow_model
ModelUri                     : azureml://subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/workspaces/mlworkspace-test2/datastores/workspaceblobstore/paths/heart-classifier 
                               -mlflow
Name                         : 1
ProvisioningState            : Succeeded
ResourceBaseProperty         : {
                               }
ResourceGroupName            : ml-test
Stage                        : Development
SystemDataCreatedAt          : 11/5/2025 10:16:48 AM
SystemDataCreatedBy          : User Name (Example)
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/5/2025 10:18:16 AM
SystemDataLastModifiedBy     : User Name (Example)
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : Microsoft.MachineLearningServices/workspaces/models/versions
XmsAsyncOperationTimeout     :
```

This command updates model version

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

### -Description
The asset description text.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Flavor
Mapping of model flavors to their properties.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsArchived
Is the asset archived?

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

### -JobName
Name of the training job which produced this model

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ModelInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity
Parameter Sets: UpdateViaIdentityModelExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ModelType
The storage format for this entity.
Used for NCD.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ModelUri
The URI path to the model contents.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Container name.
This is case-sensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityWorkspaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceBaseProperty
The asset property dictionary.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Stage
Stage in the model lifecycle assigned to this model

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Tag dictionary.
Tags can be added, removed, and updated.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Version identifier.
This is case-sensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityWorkspaceExpanded, UpdateViaIdentityModelExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity
Parameter Sets: UpdateViaIdentityWorkspaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
Name of Azure Machine Learning workspace.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IModelVersion

## NOTES

## RELATED LINKS

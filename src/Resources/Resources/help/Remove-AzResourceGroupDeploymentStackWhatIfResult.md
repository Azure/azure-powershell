---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/Remove-AzResourceGroupDeploymentStackWhatIfResult
schema: 2.0.0
---

# Remove-AzResourceGroupDeploymentStackWhatIfResult

## SYNOPSIS
Removes a resource group scoped deployment stack WhatIf result.

## SYNTAX

### RemoveByNameAndResourceGroupName (Default)
```
Remove-AzResourceGroupDeploymentStackWhatIfResult [-Name] <String> [-ResourceGroupName] <String> [-PassThru]
 [-Force] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [-AcquirePolicyToken]
 [-ChangeReference <String>] [<CommonParameters>]
```

### RemoveByResourceId
```
Remove-AzResourceGroupDeploymentStackWhatIfResult -ResourceId <String> [-PassThru] [-Force] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [-AcquirePolicyToken]
 [-ChangeReference <String>] [<CommonParameters>]
```

### RemoveByInputObject
```
Remove-AzResourceGroupDeploymentStackWhatIfResult [-InputObject] <PSDeploymentStackWhatIfResult> [-PassThru]
 [-Force] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [-AcquirePolicyToken]
 [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
Removes a resource group scoped deployment stack WhatIf result resource. This cmdlet works with persisted deployment stack WhatIf result resources.

## EXAMPLES

### Example 1: Use Remove-AzResourceGroupDeploymentStackWhatIfResult
```powershell
Remove-AzResourceGroupDeploymentStackWhatIfResult -Name MyWhatIfResult -ResourceGroupName MyResourceGroup -Force
```

Removes the deployment stack WhatIf result named MyWhatIfResult.

### Example 2: Remove a resource group scoped deployment stack WhatIf result by resource ID
```powershell
$whatIfResultId = "/subscriptions/$((Get-AzContext).Subscription.Id)/resourceGroups/MyResourceGroup/providers/Microsoft.Resources/deploymentStacksWhatIfResults/MyWhatIfResult"
Remove-AzResourceGroupDeploymentStackWhatIfResult -ResourceId $whatIfResultId -Force
```

Removes the deployment stack WhatIf result by its fully-qualified resource ID.

### Example 3: Remove a resource group scoped deployment stack WhatIf result from an input object
```powershell
$result = Get-AzResourceGroupDeploymentStackWhatIfResult -Name MyWhatIfResult -ResourceGroupName MyResourceGroup
$result | Remove-AzResourceGroupDeploymentStackWhatIfResult -Force
```

Removes a deployment stack WhatIf result passed through the pipeline.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

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

### -ChangeReference
The change reference resource ID for this resource operation.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -InputObject
The WhatIf result PS object.

```yaml
Type: PSDeploymentStackWhatIfResult
Parameter Sets: RemoveByInputObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the WhatIf result to delete.

```yaml
Type: String
Parameter Sets: RemoveByNameAndResourceGroupName
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
If set, a boolean will be returned with value dependent on cmdlet success.

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

### -Pre
When set, indicates that the cmdlet should use pre-release API versions when automatically determining which version to use.

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

### -ResourceGroupName
The name of the ResourceGroup containing the WhatIf result.

```yaml
Type: String
Parameter Sets: RemoveByNameAndResourceGroupName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The fully-qualified resource ID of the WhatIf result to delete.

```yaml
Type: String
Parameter Sets: RemoveByResourceId
Aliases: Id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
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

### System.String

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.DeploymentStackWhatIf.PSDeploymentStackWhatIfResult

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS


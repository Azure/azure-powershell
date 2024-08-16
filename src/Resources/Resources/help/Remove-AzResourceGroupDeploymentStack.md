---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/Remove-AzResourceGroupDeploymentStack
schema: 2.0.0
---

# Remove-AzResourceGroupDeploymentStack

## SYNOPSIS
Removes a Resource Group scoped Deployment Stack.

## SYNTAX

### RemoveByNameAndResourceGroupName (Default)
```
Remove-AzResourceGroupDeploymentStack [-Name] <String> [-ResourceGroupName] <String>
 -ActionOnUnmanage <PSActionOnUnmanage> [-PassThru] [-Force] [-BypassStackOutOfSyncError] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RemoveByResourceId
```
Remove-AzResourceGroupDeploymentStack -ResourceId <String> -ActionOnUnmanage <PSActionOnUnmanage> [-PassThru]
 [-Force] [-BypassStackOutOfSyncError] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RemoveByStackObject
```
Remove-AzResourceGroupDeploymentStack [-InputObjet] <PSDeploymentStack> -ActionOnUnmanage <PSActionOnUnmanage>
 [-PassThru] [-Force] [-BypassStackOutOfSyncError] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Delete a resource group scoped deployment stack.

## EXAMPLES

### Example 1: Deletes the resource group deployment tsack MyRgStack from MyResourceGroup
```powershell
Remove-AzResourceGroupDeploymentStack -ResourceGroupName MyResourceGroup -Name MyRGStack
```

Deletes a resource group scoped deployment stack named 'MyRGStack' in resource group 'MyResourceGroup,' with unmanaged resources and resource groups being detached on cleanup.

## PARAMETERS

### -ActionOnUnmanage
Action to take on resources that become unmanaged on deletion or update of the deployment stack. Possible values include: 'detachAll' (do not delete any unmanaged resources), 'deleteResources' (delete all unmanaged resources that are not RGs or MGs), and 'deleteAll' (delete every unmanaged resource).

```yaml
Type: Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.DeploymentStacks.PSActionOnUnmanage
Parameter Sets: (All)
Aliases:
Accepted values: DetachAll, DeleteResources, DeleteAll

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BypassStackOutOfSyncError
Bypass errors for the stack being out of sync when running the operation. If the stack is out of sync and this parameter is not set, the operation will fail. Only include this parameter if instructed to do so on a failed stack operation.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObjet
The stack PS object.

```yaml
Type: Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.PSDeploymentStack
Parameter Sets: RemoveByStackObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the deploymentStack to delete

```yaml
Type: System.String
Parameter Sets: RemoveByNameAndResourceGroupName
Aliases: StackName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
If set, a boolean will be returned with value dependent on cmdlet success.

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

### -Pre
When set, indicates that the cmdlet should use pre-release API versions when automatically determining which version to use.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the Resource Group with the stack to delete

```yaml
Type: System.String
Parameter Sets: RemoveByNameAndResourceGroupName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
ResourceId of the stack to delete

```yaml
Type: System.String
Parameter Sets: RemoveByResourceId
Aliases: Id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### System.String

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

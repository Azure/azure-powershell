---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
ms.assetid: 880D321E-30F2-4CAE-B14A-5F6DD8E1DB99
online version: https://learn.microsoft.com/powershell/module/az.resources/remove-azresourcegroup
schema: 2.0.0
---

# Remove-AzResourceGroup

## SYNOPSIS
Removes a resource group.

## SYNTAX

### RemoveByResourceGroupName (Default)
```
Remove-AzResourceGroup [-Name] <String> [-ForceDeletionType <String>] [-Force] [-AsJob] [-ApiVersion <String>]
 [-Pre] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RemoveByResourceGroupId
```
Remove-AzResourceGroup -Id <String> [-ForceDeletionType <String>] [-Force] [-AsJob] [-ApiVersion <String>]
 [-Pre] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzResourceGroup** cmdlet removes an Azure resource group and its resources from the current subscription.
To delete a resource, but leave the resource group, use the Remove-AzResource cmdlet.

## EXAMPLES

### Example 1: Remove a resource group
```powershell
Remove-AzResourceGroup -Name "ContosoRG01"
```

This command removes the ContosoRG01 resource group from the subscription.
The cmdlet prompts you for confirmation and returns no output.

### Example 2: Remove a resource group without confirmation
```powershell
Get-AzResourceGroup -Name "ContosoRG01" | Remove-AzResourceGroup -Force
```

This command uses the Get-AzResourceGroup cmdlet to get the resource group ContosoRG01, and then passes it to **Remove-AzResourceGroup** by using the pipeline operator. The *Force* parameter suppresses the confirmation prompt.

### Example 3: Remove all resource groups
```powershell
Get-AzResourceGroup | Remove-AzResourceGroup
```

This command uses the **Get-AzResourceGroup** cmdlet to get all resource groups, and then passes them to **Remove-AzResourceGroup** by using the pipeline operator.

### Example 4: Remove a resource groups use ForceDeletionType
```powershell
Remove-AzResourceGroup -Name "ContosoRG01" -ForceDeletionType "Microsoft.Compute/virtualMachineScaleSets,Microsoft.Compute/virtualMachines,Microsoft.Databricks/workspaces"
```

This command removes the ContosoRG01 resource group use the ForceDeletionType.
The cmdlet prompts you for confirmation and returns no output.

## PARAMETERS

### -ApiVersion
Specifies the API version that is supported by the resource Provider.
You can specify a different version than the default version.

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

### -AsJob
Run cmdlet in the background

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
The credentials, account, tenant, and subscription used for communication with azure

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
Forces the command to run without asking for user confirmation.

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

### -ForceDeletionType
The resource types you want to force delete.Currently, only the following is supported: forceDeletionTypes=Microsoft.Compute/virtualMachines,Microsoft.Compute/virtualMachineScaleSets

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

### -Id
Specifies the ID of resource group to remove.
Wildcard characters are not permitted.

```yaml
Type: System.String
Parameter Sets: RemoveByResourceGroupId
Aliases: ResourceGroupId, ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the names of resource groups to remove.
Wildcard characters are not permitted.

```yaml
Type: System.String
Parameter Sets: RemoveByResourceGroupName
Aliases: ResourceGroupName

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Pre
Indicates that this cmdlet considers pre-release API versions when it automatically determines which version to use.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
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
Default value: False
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

[Get-AzResourceGroup](./Get-AzResourceGroup.md)

[New-AzResourceGroup](./New-AzResourceGroup.md)

[Set-AzResourceGroup](./Set-AzResourceGroup.md)

---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/Save-AzManagementGroupDeploymentStackTemplate
schema: 2.0.0
---

# Save-AzManagementGroupDeploymentStackTemplate

## SYNOPSIS
Saves a Management Group scoped Deployment Stack Template.

## SYNTAX

### SaveByNameAndManagmentGroupId (Default)
```
Save-AzManagementGroupDeploymentStackTemplate [-StackName] <String> [-ManagementGroupId] <String> [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### SaveByResourceId
```
Save-AzManagementGroupDeploymentStackTemplate -ResourceId <String> [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### SaveByStackObject
```
Save-AzManagementGroupDeploymentStackTemplate [-InputObjet] <PSDeploymentStack> [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Saves a template (or template link) for a management group scoped deployment stack.

## EXAMPLES

### Example 1: Save the template used for the deployment stack named MyManagementGroup at MyManagementGroup management group
```powershell
Save-AzManagementGroupDeploymentStackTemplate -ManagementGroupId MyManagementGroup -StackName MyMGStack
```

Save a template (or template link) from a stack named 'MyMGStack' under an MG named 'MyManagementGroup'.

## PARAMETERS

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

### -InputObjet
The stack PS object

```yaml
Type: Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.PSDeploymentStack
Parameter Sets: SaveByStackObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagementGroupId
The id of the ManagementGroup where the DeploymentStack is deployed

```yaml
Type: System.String
Parameter Sets: SaveByNameAndManagmentGroupId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -ResourceId
ResourceId of the DeploymentStack to get

```yaml
Type: System.String
Parameter Sets: SaveByResourceId
Aliases: Id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StackName
The name of the DeploymentStack to get

```yaml
Type: System.String
Parameter Sets: SaveByNameAndManagmentGroupId
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.PSDeploymentStackTemplateDefinition

## NOTES

## RELATED LINKS

---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/Save-AzSubscriptionDeploymentStackTemplate
schema: 2.0.0
---

# Save-AzSubscriptionDeploymentStackTemplate

## SYNOPSIS
Saves a Subscription scoped Deployment Stack Template.

## SYNTAX

### SaveByName (Default)
```
Save-AzSubscriptionDeploymentStackTemplate [-StackName] <String> [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### SaveByResourceId
```
Save-AzSubscriptionDeploymentStackTemplate -ResourceId <String> [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### SaveByStackObject
```
Save-AzSubscriptionDeploymentStackTemplate [-InputObjet] <PSDeploymentStack> [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Saves a template (or template link) for a subscription scoped deployment stack.

## EXAMPLES

### Example 1: Saves the template used for the deployment stack MySubStack at the current subscription
```powershell
Save-AzSubscriptionDeploymentStackTemplate -StackName MySubStack
```

Save a template (or template link) for a stack named 'MySubStack' under the default subscription.

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
Parameter Sets: SaveByName
Aliases:

Required: True
Position: 0
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

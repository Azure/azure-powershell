---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/Get-AzManagementGroupDeploymentStack
schema: 2.0.0
---

# Get-AzManagementGroupDeploymentStack

## SYNOPSIS
Gets Management Group scoped Deployment Stacks.

## SYNTAX

### ListByManagmentGroupId (Default)
```
Get-AzManagementGroupDeploymentStack -ManagementGroupId <String> [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByManagementGroupIdAndName
```
Get-AzManagementGroupDeploymentStack [-Name] <String> -ManagementGroupId <String> [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByResourceId
```
Get-AzManagementGroupDeploymentStack -ResourceId <String> [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Retrieve a mangement group scoped deployment stack.

## EXAMPLES

### Example 1: Retrieves the deployment stack MyMGStack in mangement group MyManagementGroup
```powershell
Get-AzManagementGroupDeploymentStack -ManagementGroupId MyMangementGroup -Name MyMGStack
```

Get a deployment stack named 'MyMGStack' under an MG named 'MyManagementGroup'.

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

### -ManagementGroupId
The id of the ManagementGroup where the DeploymentStack is deployed

```yaml
Type: System.String
Parameter Sets: ListByManagmentGroupId, GetByManagementGroupIdAndName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the DeploymentStack to get

```yaml
Type: System.String
Parameter Sets: GetByManagementGroupIdAndName
Aliases: StackName

Required: True
Position: 1
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
Parameter Sets: GetByResourceId
Aliases: Id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.PSDeploymentStack

## NOTES

## RELATED LINKS

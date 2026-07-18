---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/Get-AzManagementGroupDeploymentStackWhatIfResult
schema: 2.0.0
---

# Get-AzManagementGroupDeploymentStackWhatIfResult

## SYNOPSIS
Gets a management group scoped deployment stack WhatIf result.

## SYNTAX

### List (Default)
```
Get-AzManagementGroupDeploymentStackWhatIfResult -ManagementGroupId <String> [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByName
```
Get-AzManagementGroupDeploymentStackWhatIfResult -Name <String> -ManagementGroupId <String>
 [-WithPropertyChanges] [-Pre] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByResourceId
```
Get-AzManagementGroupDeploymentStackWhatIfResult -ResourceId <String> [-WithPropertyChanges] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Gets one or more management group scoped deployment stack WhatIf result resources.

## EXAMPLES

### Example 1: List deployment stack WhatIf results in a management group
```powershell
Get-AzManagementGroupDeploymentStackWhatIfResult -ManagementGroupId MyManagementGroup
```

Gets deployment stack WhatIf results in management group `MyManagementGroup`.

### Example 2: Get a deployment stack WhatIf result by name
```powershell
Get-AzManagementGroupDeploymentStackWhatIfResult -ManagementGroupId MyManagementGroup -Name MyWhatIfResult
```

Gets the deployment stack WhatIf result named `MyWhatIfResult` in management group `MyManagementGroup`.

### Example 3: Get a deployment stack WhatIf result with property changes
```powershell
Get-AzManagementGroupDeploymentStackWhatIfResult -ManagementGroupId MyManagementGroup -Name MyWhatIfResult -WithPropertyChanges
```

Gets the deployment stack WhatIf result named `MyWhatIfResult` with resource property changes populated.

### Example 4: Get a deployment stack WhatIf result by resource ID
```powershell
$whatIfResultId = "/providers/Microsoft.Management/managementGroups/MyManagementGroup/providers/Microsoft.Resources/deploymentStacksWhatIfResults/MyWhatIfResult"
Get-AzManagementGroupDeploymentStackWhatIfResult -ResourceId $whatIfResultId
```

Gets the deployment stack WhatIf result by its fully-qualified resource ID.

## PARAMETERS

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

### -ManagementGroupId
The ID of the management group.

```yaml
Type: String
Parameter Sets: List, GetByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the WhatIf result to get.

```yaml
Type: String
Parameter Sets: GetByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -ResourceId
The fully-qualified resource ID of the WhatIf result to get.

```yaml
Type: String
Parameter Sets: GetByResourceId
Aliases: Id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WithPropertyChanges
If set, returns the WhatIf result with resource property changes (delta) populated.

```yaml
Type: SwitchParameter
Parameter Sets: GetByName, GetByResourceId
Aliases:

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

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.DeploymentStackWhatIf.PSDeploymentStackWhatIfResult

## NOTES

## RELATED LINKS


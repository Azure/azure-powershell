---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/Get-AzSubscriptionDeploymentStackWhatIfResult
schema: 2.0.0
---

# Get-AzSubscriptionDeploymentStackWhatIfResult

## SYNOPSIS
Gets a subscription scoped deployment stack WhatIf result.

## SYNTAX

### List (Default)
```
Get-AzSubscriptionDeploymentStackWhatIfResult [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### GetByName
```
Get-AzSubscriptionDeploymentStackWhatIfResult -Name <String> [-IncludePropertyChange] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByResourceId
```
Get-AzSubscriptionDeploymentStackWhatIfResult -ResourceId <String> [-IncludePropertyChange] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Gets one or more subscription scoped deployment stack WhatIf result resources.

## EXAMPLES

### Example 1: List deployment stack WhatIf results in the current subscription
```powershell
Get-AzSubscriptionDeploymentStackWhatIfResult
```

Gets deployment stack WhatIf results in the current subscription.

### Example 2: Get a deployment stack WhatIf result by name
```powershell
Get-AzSubscriptionDeploymentStackWhatIfResult -Name MyWhatIfResult
```

Gets the deployment stack WhatIf result named `MyWhatIfResult` in the current subscription.

### Example 3: Get a deployment stack WhatIf result with property changes
```powershell
Get-AzSubscriptionDeploymentStackWhatIfResult -Name MyWhatIfResult -IncludePropertyChange
```

Gets the deployment stack WhatIf result named `MyWhatIfResult` with resource property changes populated.

### Example 4: Get a deployment stack WhatIf result by resource ID
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$whatIfResultId = "/subscriptions/$subscriptionId/providers/Microsoft.Resources/deploymentStacksWhatIfResults/MyWhatIfResult"
Get-AzSubscriptionDeploymentStackWhatIfResult -ResourceId $whatIfResultId
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

### -IncludePropertyChange
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

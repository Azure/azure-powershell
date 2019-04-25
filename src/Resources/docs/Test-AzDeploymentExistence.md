---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/test-azdeploymentexistence
schema: 2.0.0
---

# Test-AzDeploymentExistence

## SYNOPSIS
Checks whether the deployment exists.

## SYNTAX

### CheckSubscriptionIdViaHost (Default)
```
Test-AzDeploymentExistence -DeploymentName <String> [-PassThru] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Check1
```
Test-AzDeploymentExistence -DeploymentName <String> -SubscriptionId <String> -ResourceGroupName <String>
 [-PassThru] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Check
```
Test-AzDeploymentExistence -DeploymentName <String> -SubscriptionId <String> [-PassThru]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### CheckSubscriptionIdViaHost1
```
Test-AzDeploymentExistence -DeploymentName <String> -ResourceGroupName <String> [-PassThru]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Checks whether the deployment exists.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -DeploymentName
The name of the deployment to check.

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

### -PassThru
When specified, PassThru will force the cmdlet return a 'bool' given that there isn't a return type by default.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group with the deployment to check.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Check1, CheckSubscriptionIdViaHost1
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
Type: System.String
Parameter Sets: Check1, Check
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Boolean
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.resources/test-azdeploymentexistence](https://docs.microsoft.com/en-us/powershell/module/az.resources/test-azdeploymentexistence)


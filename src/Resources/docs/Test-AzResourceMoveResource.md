---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/test-azresourcemoveresource
schema: 2.0.0
---

# Test-AzResourceMoveResource

## SYNOPSIS
This operation checks whether the specified resources can be moved to the target.
The resources to move must be in the same source resource group.
The target resource group may be in a different subscription.
If validation succeeds, it returns HTTP response code 204 (no content).
If validation fails, it returns HTTP response code 409 (Conflict) with an error message.
Retrieve the URL in the Location header value to check the result of the long-running operation.

## SYNTAX

### ValidateSubscriptionIdViaHost (Default)
```
Test-AzResourceMoveResource -SourceResourceGroupName <String> [-Parameters <IResourcesMoveInfo>] [-PassThru]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ValidateExpanded
```
Test-AzResourceMoveResource -SourceResourceGroupName <String> -SubscriptionId <String> [-PassThru]
 [-Resources <String[]>] [-TargetResourceGroup <String>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### Validate
```
Test-AzResourceMoveResource -SourceResourceGroupName <String> -SubscriptionId <String>
 [-Parameters <IResourcesMoveInfo>] [-PassThru] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ValidateSubscriptionIdViaHostExpanded
```
Test-AzResourceMoveResource -SourceResourceGroupName <String> [-PassThru] [-Resources <String[]>]
 [-TargetResourceGroup <String>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
This operation checks whether the specified resources can be moved to the target.
The resources to move must be in the same source resource group.
The target resource group may be in a different subscription.
If validation succeeds, it returns HTTP response code 204 (no content).
If validation fails, it returns HTTP response code 409 (Conflict) with an error message.
Retrieve the URL in the Location header value to check the result of the long-running operation.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AsJob
Run the command as a job

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

### -Parameters
Parameters of move resources.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IResourcesMoveInfo
Parameter Sets: ValidateSubscriptionIdViaHost, Validate
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Resources
The IDs of the resources.

```yaml
Type: System.String[]
Parameter Sets: ValidateExpanded, ValidateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceResourceGroupName
The name of the resource group containing the resources to validate for move.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, Validate
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceGroup
The target resource group.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateSubscriptionIdViaHostExpanded
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

## OUTPUTS

### System.Boolean
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.resources/test-azresourcemoveresource](https://docs.microsoft.com/en-us/powershell/module/az.resources/test-azresourcemoveresource)


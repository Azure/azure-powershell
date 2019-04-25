---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/remove-azmanagementlock
schema: 2.0.0
---

# Remove-AzManagementLock

## SYNOPSIS
Delete a management lock by scope.

## SYNTAX

### DeleteSubscriptionIdViaHost1 (Default)
```
Remove-AzManagementLock -LockName <String> [-PassThru] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Delete
```
Remove-AzManagementLock -LockName <String> -Scope <String> [-PassThru] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### DeleteSubscriptionIdViaHost
```
Remove-AzManagementLock -LockName <String> -ParentResourcePath <String> -ResourceGroupName <String>
 -ResourceName <String> -ResourceProviderNamespace <String> -ResourceType <String> [-PassThru]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Delete1
```
Remove-AzManagementLock -LockName <String> -ParentResourcePath <String> -ResourceGroupName <String>
 -ResourceName <String> -ResourceProviderNamespace <String> -ResourceType <String> -SubscriptionId <String>
 [-PassThru] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteSubscriptionIdViaHost2
```
Remove-AzManagementLock -LockName <String> -ResourceGroupName <String> [-PassThru] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Delete3
```
Remove-AzManagementLock -LockName <String> -ResourceGroupName <String> -SubscriptionId <String> [-PassThru]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Delete2
```
Remove-AzManagementLock -LockName <String> -SubscriptionId <String> [-PassThru] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Delete a management lock by scope.

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

### -LockName
The name of lock.

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

### -ParentResourcePath
The parent resource identity.

```yaml
Type: System.String
Parameter Sets: DeleteSubscriptionIdViaHost, Delete1
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
The name of the resource group containing the resource with the lock to delete.

```yaml
Type: System.String
Parameter Sets: DeleteSubscriptionIdViaHost, Delete1, DeleteSubscriptionIdViaHost2, Delete3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The name of the resource with the lock to delete.

```yaml
Type: System.String
Parameter Sets: DeleteSubscriptionIdViaHost, Delete1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceProviderNamespace
The resource provider namespace of the resource with the lock to delete.

```yaml
Type: System.String
Parameter Sets: DeleteSubscriptionIdViaHost, Delete1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceType
The resource type of the resource with the lock to delete.

```yaml
Type: System.String
Parameter Sets: DeleteSubscriptionIdViaHost, Delete1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope for the lock.

```yaml
Type: System.String
Parameter Sets: Delete
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
Parameter Sets: Delete1, Delete3, Delete2
Aliases:

Required: True
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

[https://docs.microsoft.com/en-us/powershell/module/az.resources/remove-azmanagementlock](https://docs.microsoft.com/en-us/powershell/module/az.resources/remove-azmanagementlock)


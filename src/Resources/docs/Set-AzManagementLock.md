---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/set-azmanagementlock
schema: 2.0.0
---

# Set-AzManagementLock

## SYNOPSIS
When you apply a lock at a parent scope, all child resources inherit the same lock.
To create management locks, you must have access to Microsoft.Authorization/* or Microsoft.Authorization/locks/* actions.
Of the built-in roles, only Owner and User Access Administrator are granted those actions.

## SYNTAX

### UpdateSubscriptionIdViaHost1 (Default)
```
Set-AzManagementLock -LockName <String> [-Parameters <IManagementLockObject>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateSubscriptionIdViaHostExpanded
```
Set-AzManagementLock -LockName <String> -ParentResourcePath <String> -ResourceGroupName <String>
 -ResourceName <String> -ResourceProviderNamespace <String> -ResourceType <String> -Level <LockLevel>
 [-Notes <String>] [-Owners <IManagementLockOwner[]>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateSubscriptionIdViaHost
```
Set-AzManagementLock -LockName <String> -ParentResourcePath <String> -ResourceGroupName <String>
 -ResourceName <String> -ResourceProviderNamespace <String> -ResourceType <String>
 [-Parameters <IManagementLockObject>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzManagementLock -LockName <String> -ParentResourcePath <String> -ResourceGroupName <String>
 -ResourceName <String> -ResourceProviderNamespace <String> -ResourceType <String> -SubscriptionId <String>
 -Level <LockLevel> [-Notes <String>] [-Owners <IManagementLockOwner[]>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### Update
```
Set-AzManagementLock -LockName <String> -ParentResourcePath <String> -ResourceGroupName <String>
 -ResourceName <String> -ResourceProviderNamespace <String> -ResourceType <String> -SubscriptionId <String>
 [-Parameters <IManagementLockObject>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateSubscriptionIdViaHostExpanded2
```
Set-AzManagementLock -LockName <String> -ResourceGroupName <String> -Level <LockLevel> [-Notes <String>]
 [-Owners <IManagementLockOwner[]>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateSubscriptionIdViaHost2
```
Set-AzManagementLock -LockName <String> -ResourceGroupName <String> [-Parameters <IManagementLockObject>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpanded2
```
Set-AzManagementLock -LockName <String> -ResourceGroupName <String> -SubscriptionId <String> -Level <LockLevel>
 [-Notes <String>] [-Owners <IManagementLockOwner[]>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Update2
```
Set-AzManagementLock -LockName <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Parameters <IManagementLockObject>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpanded1
```
Set-AzManagementLock -LockName <String> -SubscriptionId <String> -Level <LockLevel> [-Notes <String>]
 [-Owners <IManagementLockOwner[]>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Update1
```
Set-AzManagementLock -LockName <String> -SubscriptionId <String> [-Parameters <IManagementLockObject>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpanded3
```
Set-AzManagementLock -LockName <String> -Scope <String> -Level <LockLevel> [-Notes <String>]
 [-Owners <IManagementLockOwner[]>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Update3
```
Set-AzManagementLock -LockName <String> -Scope <String> [-Parameters <IManagementLockObject>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateSubscriptionIdViaHostExpanded1
```
Set-AzManagementLock -LockName <String> -Level <LockLevel> [-Notes <String>] [-Owners <IManagementLockOwner[]>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
When you apply a lock at a parent scope, all child resources inherit the same lock.
To create management locks, you must have access to Microsoft.Authorization/* or Microsoft.Authorization/locks/* actions.
Of the built-in roles, only Owner and User Access Administrator are granted those actions.

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

### -Level
The level of the lock.
Possible values are: NotSpecified, CanNotDelete, ReadOnly.
CanNotDelete means authorized users are able to read and modify the resources, but not delete.
ReadOnly means authorized users can only read from a resource, but they can't modify or delete it.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.LockLevel
Parameter Sets: UpdateSubscriptionIdViaHostExpanded, UpdateExpanded, UpdateSubscriptionIdViaHostExpanded2, UpdateExpanded2, UpdateExpanded1, UpdateExpanded3, UpdateSubscriptionIdViaHostExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LockName
The name of lock.
The lock name can be a maximum of 260 characters.
It cannot contain \<, \> %, &, :, \, ?, /, or any control characters.

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

### -Notes
Notes about the lock.
Maximum of 512 characters.

```yaml
Type: System.String
Parameter Sets: UpdateSubscriptionIdViaHostExpanded, UpdateExpanded, UpdateSubscriptionIdViaHostExpanded2, UpdateExpanded2, UpdateExpanded1, UpdateExpanded3, UpdateSubscriptionIdViaHostExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Owners
The owners of the lock.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20160901.IManagementLockOwner[]
Parameter Sets: UpdateSubscriptionIdViaHostExpanded, UpdateExpanded, UpdateSubscriptionIdViaHostExpanded2, UpdateExpanded2, UpdateExpanded1, UpdateExpanded3, UpdateSubscriptionIdViaHostExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameters
The lock information.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20160901.IManagementLockObject
Parameter Sets: UpdateSubscriptionIdViaHost1, UpdateSubscriptionIdViaHost, Update, UpdateSubscriptionIdViaHost2, Update2, Update1, Update3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ParentResourcePath
The parent resource identity.

```yaml
Type: System.String
Parameter Sets: UpdateSubscriptionIdViaHostExpanded, UpdateSubscriptionIdViaHost, UpdateExpanded, Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group containing the resource to lock.

```yaml
Type: System.String
Parameter Sets: UpdateSubscriptionIdViaHostExpanded, UpdateSubscriptionIdViaHost, UpdateExpanded, Update, UpdateSubscriptionIdViaHostExpanded2, UpdateSubscriptionIdViaHost2, UpdateExpanded2, Update2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The name of the resource to lock.

```yaml
Type: System.String
Parameter Sets: UpdateSubscriptionIdViaHostExpanded, UpdateSubscriptionIdViaHost, UpdateExpanded, Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceProviderNamespace
The resource provider namespace of the resource to lock.

```yaml
Type: System.String
Parameter Sets: UpdateSubscriptionIdViaHostExpanded, UpdateSubscriptionIdViaHost, UpdateExpanded, Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceType
The resource type of the resource to lock.

```yaml
Type: System.String
Parameter Sets: UpdateSubscriptionIdViaHostExpanded, UpdateSubscriptionIdViaHost, UpdateExpanded, Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope for the lock.
When providing a scope for the assignment, use '/subscriptions/{subscriptionId}' for subscriptions, '/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}' for resource groups, and '/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePathIfPresent}/{resourceType}/{resourceName}' for resources.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded3, Update3
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
Parameter Sets: UpdateExpanded, Update, UpdateExpanded2, Update2, UpdateExpanded1, Update1
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20160901.IManagementLockObject
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.resources/set-azmanagementlock](https://docs.microsoft.com/en-us/powershell/module/az.resources/set-azmanagementlock)


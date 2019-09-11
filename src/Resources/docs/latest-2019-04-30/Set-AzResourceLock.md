---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/set-azresourcelock
schema: 2.0.0
---

# Set-AzResourceLock

## SYNOPSIS
When you apply a lock at a parent scope, all child resources inherit the same lock.
To create management locks, you must have access to Microsoft.Authorization/* or Microsoft.Authorization/locks/* actions.
Of the built-in roles, only Owner and User Access Administrator are granted those actions.

## SYNTAX

### UpdateExpanded1 (Default)
```
Set-AzResourceLock -LockName <String> -Level <LockLevel> [-SubscriptionId <String>] [-Note <String>]
 [-Owner <IManagementLockOwner[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzResourceLock -LockName <String> -ParentResourcePath <String> -ResourceGroupName <String>
 -ResourceName <String> -ResourceProviderNamespace <String> -ResourceType <String>
 -Parameter <IManagementLockObject> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Update1
```
Set-AzResourceLock -LockName <String> -Parameter <IManagementLockObject> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update2
```
Set-AzResourceLock -LockName <String> -ResourceGroupName <String> -Parameter <IManagementLockObject>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update3
```
Set-AzResourceLock -LockName <String> -Scope <String> -Parameter <IManagementLockObject>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzResourceLock -LockName <String> -ParentResourcePath <String> -ResourceGroupName <String>
 -ResourceName <String> -ResourceProviderNamespace <String> -ResourceType <String> -Level <LockLevel>
 [-SubscriptionId <String>] [-Note <String>] [-Owner <IManagementLockOwner[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded2
```
Set-AzResourceLock -LockName <String> -ResourceGroupName <String> -Level <LockLevel>
 [-SubscriptionId <String>] [-Note <String>] [-Owner <IManagementLockOwner[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded3
```
Set-AzResourceLock -LockName <String> -Scope <String> -Level <LockLevel> [-Note <String>]
 [-Owner <IManagementLockOwner[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateTopLevelResource
```
Set-AzResourceLock -LockName <String> -ResourceGroupName <String> -ResourceName <String>
 -ResourceProviderNamespace <String> -ResourceType <String> -Level <LockLevel> [-SubscriptionId <String>]
 [-Note <String>] [-Owner <IManagementLockOwner[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
When you apply a lock at a parent scope, all child resources inherit the same lock.
To create management locks, you must have access to Microsoft.Authorization/* or Microsoft.Authorization/locks/* actions.
Of the built-in roles, only Owner and User Access Administrator are granted those actions.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

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
Dynamic: False
```

### -Level
The level of the lock.
Possible values are: NotSpecified, CanNotDelete, ReadOnly.
CanNotDelete means authorized users are able to read and modify the resources, but not delete.
ReadOnly means authorized users can only read from a resource, but they can't modify or delete it.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.LockLevel
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateExpanded2, UpdateExpanded3, UpdateTopLevelResource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -Note
Notes about the lock.
Maximum of 512 characters.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateExpanded2, UpdateExpanded3, UpdateTopLevelResource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Owner
The owners of the lock.
To construct, see NOTES section for OWNER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20160901.IManagementLockOwner[]
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateExpanded2, UpdateExpanded3, UpdateTopLevelResource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
The lock information.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20160901.IManagementLockObject
Parameter Sets: Update, Update1, Update2, Update3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ParentResourcePath
The parent resource identity.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group containing the resource to lock.

```yaml
Type: System.String
Parameter Sets: Update, Update2, UpdateExpanded, UpdateExpanded2, UpdateTopLevelResource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceName
The name of the resource to lock.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateTopLevelResource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceProviderNamespace
The resource provider namespace of the resource to lock.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateTopLevelResource
Aliases: ProviderNamespace

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceType
The resource type of the resource to lock.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateTopLevelResource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Scope
The scope for the lock.
When providing a scope for the assignment, use '/subscriptions/{subscriptionId}' for subscriptions, '/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}' for resource groups, and '/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePathIfPresent}/{resourceType}/{resourceName}' for resources.

```yaml
Type: System.String
Parameter Sets: Update3, UpdateExpanded3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Update, Update1, Update2, UpdateExpanded, UpdateExpanded1, UpdateExpanded2, UpdateTopLevelResource
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20160901.IManagementLockObject

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20160901.IManagementLockObject

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### OWNER <IManagementLockOwner[]>: The owners of the lock.
  - `[ApplicationId <String>]`: The application ID of the lock owner.

#### PARAMETER <IManagementLockObject>: The lock information.
  - `Level <LockLevel>`: The level of the lock. Possible values are: NotSpecified, CanNotDelete, ReadOnly. CanNotDelete means authorized users are able to read and modify the resources, but not delete. ReadOnly means authorized users can only read from a resource, but they can't modify or delete it.
  - `[Note <String>]`: Notes about the lock. Maximum of 512 characters.
  - `[Owner <IManagementLockOwner[]>]`: The owners of the lock.
    - `[ApplicationId <String>]`: The application ID of the lock owner.

## RELATED LINKS


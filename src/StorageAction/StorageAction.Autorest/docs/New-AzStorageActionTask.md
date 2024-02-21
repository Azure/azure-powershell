---
external help file:
Module Name: Az.StorageAction
online version: https://learn.microsoft.com/powershell/module/az.storageaction/new-azstorageactiontask
schema: 2.0.0
---

# New-AzStorageActionTask

## SYNOPSIS
Asynchronously creates a new storage task resource with the specified parameters.
If a storage task is already created and a subsequent create request is issued with different properties, the storage task properties will be updated.
If a storage task is already created and a subsequent Create request is issued with the exact same set of properties, the request will succeed.

## SYNTAX

### CreateExpanded (Default)
```
New-AzStorageActionTask -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-Description <String>] [-ElseOperation <IStorageTaskOperation[]>] [-Enabled]
 [-IdentityType <String>] [-IfCondition <String>] [-IfOperation <IStorageTaskOperation[]>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzStorageActionTask -InputObject <IStorageActionIdentity> -Location <String> [-Description <String>]
 [-ElseOperation <IStorageTaskOperation[]>] [-Enabled] [-IdentityType <String>] [-IfCondition <String>]
 [-IfOperation <IStorageTaskOperation[]>] [-Tag <Hashtable>] [-UserAssignedIdentity <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Asynchronously creates a new storage task resource with the specified parameters.
If a storage task is already created and a subsequent create request is issued with different properties, the storage task properties will be updated.
If a storage task is already created and a subsequent Create request is issued with the exact same set of properties, the request will succeed.

## EXAMPLES

### Example 1: Create storage task with if operation
```powershell
$ifoperation = New-AzStorageActionTaskOperationObject -Name SetBlobTier -Parameter @{"tier"= "Hot"} -OnFailure break -OnSuccess continue
New-AzStorageActionTask -Name mytask1 -ResourceGroupName ps1-test -Location eastus2euap -Enabled -Description 'my storage task' -IfCondition "[[equals(AccessTier, 'Cool')]]" -IfOperation $ifoperation -IdentityType None
```

```output
CreationTimeInUtc            : 1/23/2024 6:47:43 AM
Description                  : my storage task
ElseOperation                : 
Enabled                      : True
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ps1-test/providers/Microsoft.StorageActions/storageTasks/mytask1
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : None
IdentityUserAssignedIdentity : {
                               }
IfCondition                  : [[equals(AccessTier, 'Cool')]]
IfOperation                  : {{
                                 "name": "SetBlobTier",
                                 "parameters": {
                                   "tier": "Hot"
                                 },
                                 "onSuccess": "continue",
                                 "onFailure": "break"
                               }}
Location                     : eastus2euap
Name                         : mytask1
ProvisioningState            : Succeeded
ResourceGroupName            : ps1-test
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : {
                               }
TaskVersion                  : 1
Type                         : Microsoft.StorageActions/storageTasks
```

The first command creates a if operation object.
The second command creates a storage task.

## PARAMETERS

### -AsJob
Run the command as a job

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -Description
Text that describes the purpose of the storage task

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ElseOperation
List of operations to execute in the else block
To construct, see NOTES section for ELSEOPERATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTaskOperation[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Enabled
Storage Task is enabled when set to true and disabled when set to false

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

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfCondition
The condition predicate which is composed of object properties, eg: blob and container properties.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfOperation
List of operations to execute when the condition predicate satisfies.
To construct, see NOTES section for IFOPERATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTaskOperation[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageActionIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

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

### -Name
The name of the storage task within the specified resource group.
Storage task names must be between 3 and 18 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases: StorageTaskName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The set of user assigned identities associated with the resource.
The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
The dictionary values can be empty objects ({}) in requests.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageActionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTask

## NOTES

## RELATED LINKS


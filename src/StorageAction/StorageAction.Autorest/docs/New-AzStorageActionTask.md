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
If a storage task is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed.

## SYNTAX

### CreateExpanded (Default)
```
New-AzStorageActionTask -Name <String> -ResourceGroupName <String> -Description <String> -Enabled
 -IfCondition <String> -IfOperation <IStorageTaskOperation[]> -Location <String> [-SubscriptionId <String>]
 [-ElseOperation <IStorageTaskOperation[]>] [-EnableSystemAssignedIdentity] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzStorageActionTask -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzStorageActionTask -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Asynchronously creates a new storage task resource with the specified parameters.
If a storage task is already created and a subsequent create request is issued with different properties, the storage task properties will be updated.
If a storage task is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed.

## EXAMPLES

### Example 1: Create storage task with if operation
```powershell
$ifoperation = New-AzStorageActionTaskOperationObject -Name SetBlobTier -Parameter @{"tier"= "Hot"} -OnFailure break -OnSuccess continue
New-AzStorageActionTask -Name mytask1 -ResourceGroupName group001 -Location eastus2euap -Enabled -Description 'my storage task' -IfCondition "[[equals(AccessTier, 'Cool')]]" -IfOperation $ifoperation
```

```output
CreationTimeInUtc            : 1/23/2024 6:47:43 AM
Description                  : my storage task
ElseOperation                : 
Enabled                      : True
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group001/providers/Microsoft.StorageActions/storageTasks/mytask1
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
ResourceGroupName            : group001
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

### Example 2: Create storage task with user assign identity
```powershell
$ifOperation = New-AzStorageActionTaskOperationObject -Name SetBlobTier -Parameter @{"tier"= "Hot"} -OnFailure break -OnSuccess continue
$elseoperation = New-AzStorageActionTaskOperationObject -Name DeleteBlob -OnFailure break -OnSuccess continue
$mi = New-AzUserAssignedIdentity -Name testUserAssignedMI -ResourceGroupName group001 -Location eastus2euap
New-AzStorageActionTask -Name mytask2 -ResourceGroupName group001 -Location eastus2euap -Enabled -Description 'my storage task 2' -IfCondition "[[equals(AccessTier, 'Hot')]]" -IfOperation $ifoperation -ElseOperation $elseoperation -UserAssignedIdentity $mi.Id
```

```output
CreationTimeInUtc            : 5/6/2024 9:41:50 AM
Description                  : my storage task 2
ElseOperation                : {{
                                 "name": "DeleteBlob",
                                 "onSuccess": "continue",
                                 "onFailure": "break"
                               }}
Enabled                      : True
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group001/providers/Microsoft.StorageActions/storageTasks/mytask2
IdentityPrincipalId          : 
IdentityTenantId             : 11111111-2222-3333-4444-123456789101
IdentityType                 : UserAssigned
IdentityUserAssignedIdentity : {
                                 "/subscriptions/11111111-2222-3333-4444-123456789101/resourcegroups/group001/providers/Microsoft.ManagedIdentity/userAssignedI 
                               dentities/testUserAssignedMI": {
                                 }
                               }
IfCondition                  : [[equals(AccessTier, 'Hot')]]
IfOperation                  : {{
                                 "name": "SetBlobTier",
                                 "parameters": {
                                   "tier": "Hot"
                                 },
                                 "onSuccess": "continue",
                                 "onFailure": "break"
                               }}
Location                     : eastus2euap
Name                         : mytask2
ProvisioningState            : Succeeded
ResourceGroupName            : group001
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
The second command creates a else operation object.
This third command creates a storage task.

### Example 3: Create storage task with if and else operation
```powershell
$ifOperation = New-AzStorageActionTaskOperationObject -Name SetBlobTier -Parameter @{"tier"= "Cool"} -OnFailure break -OnSuccess continue
$elseoperation = New-AzStorageActionTaskOperationObject -Name DeleteBlob -OnFailure break -OnSuccess continue
New-AzStorageActionTask -Name mytask3 -ResourceGroupName group001 -Location eastus2euap -Enabled -Description 'my storage task 3' -IfCondition "[[equals(AccessTier, 'Cool')]]" -IfOperation $ifoperation -ElseOperation $elseoperation -EnableSystemAssignedIdentity
```

```output
CreationTimeInUtc            : 4/12/2024 9:56:05 AM
Description                  : my storage task 3
ElseOperation                : {{
                                 "name": "DeleteBlob",
                                 "onSuccess": "continue",
                                 "onFailure": "break"
                               }}
Enabled                      : True
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group001/providers/Microsoft.StorageActions/storageTasks/mytask3
IdentityPrincipalId          : 00001111-aaaa-2222-bbbb-3333cccc4444
IdentityTenantId             : 11111111-2222-3333-4444-123456789101
IdentityType                 : SystemAssigned
IdentityUserAssignedIdentity : {
                               }
IfCondition                  : [[equals(AccessTier, 'Cool')]]
IfOperation                  : {{
                                 "name": "SetBlobTier",
                                 "parameters": {
                                   "tier": "Cool"
                                 },
                                 "onSuccess": "continue",
                                 "onFailure": "break"
                               }}
Location                     : eastus2euap
Name                         : mytask3
ProvisioningState            : Succeeded
ResourceGroupName            : group001
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
The second command creates a else operation object.
This third command creates a storage task.

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
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ElseOperation
List of operations to execute in the else block

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTaskOperation[]
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableSystemAssignedIdentity
Decides if enable a system assigned identity for the resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfCondition
Condition predicate to evaluate each object.
See https://aka.ms/storagetaskconditions for valid properties and operators.

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

### -IfOperation
List of operations to execute when the condition predicate satisfies.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTaskOperation[]
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

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

### -Name
The name of the storage task within the specified resource group.
Storage task names must be between 3 and 18 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: (All)
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
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTask

## NOTES

## RELATED LINKS


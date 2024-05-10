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

The first command creates a if operation object. The second command creates a storage task.

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

The first command creates a if operation object. The second command creates a else operation object. This third command creates a storage task.


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
IdentityPrincipalId          : 11111111-2222-3333-4444-123456789123
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

The first command creates a if operation object. The second command creates a else operation object. This third command creates a storage task.


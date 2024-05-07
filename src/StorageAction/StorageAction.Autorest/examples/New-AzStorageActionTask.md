### Example 1: Create storage task with if operation
```powershell
$ifoperation = New-AzStorageActionTaskOperationObject -Name SetBlobTier -Parameter @{"tier"= "Hot"} -OnFailure break -OnSuccess continue
New-AzStorageActionTask -Name mytask1 -ResourceGroupName ps1-test -Location eastus2euap -Enabled -Description 'my storage task' -IfCondition "[[equals(AccessTier, 'Cool')]]" -IfOperation $ifoperation
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

The first command creates a if operation object. The second command creates a storage task.

### Example 2: Create storage task with user assign identity
```powershell
$ifOperation = New-AzStorageActionTaskOperationObject -Name SetBlobTier -Parameter @{"tier"= "Hot"} -OnFailure break -OnSuccess continue
$elseoperation = New-AzStorageActionTaskOperationObject -Name DeleteBlob -OnFailure break -OnSuccess continue
$mi = New-AzUserAssignedIdentity -Name testUserAssignedMI -ResourceGroupName joyer-test -Location eastus2euap
New-AzStorageActionTask -Name mytask2 -ResourceGroupName joyer-test -Location eastus2euap -Enabled -Description 'my storage task 2' -IfCondition "[[equals(AccessTier, 'Hot')]]" -IfOperation $ifoperation -ElseOperation $elseoperation -UserAssignedIdentity $mi.Id
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
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.StorageActions/storageTasks/myta 
                               sk2
IdentityPrincipalId          : 
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : UserAssigned
IdentityUserAssignedIdentity : {
                                 "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/joyer-test/providers/Microsoft.ManagedIdentity/userAssignedI 
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
ResourceGroupName            : joyer-test
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
New-AzStorageActionTask -Name mytask3 -ResourceGroupName joyer-test -Location eastus2euap -Enabled -Description 'my storage task 3' -IfCondition "[[equals(AccessTier, 'Cool')]]" -IfOperation $ifoperation -ElseOperation $elseoperation -EnableSystemAssignedIdentity
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
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.StorageActions/storageTasks/myta 
                               sk3
IdentityPrincipalId          : ea96114b-ac3c-4350-87f5-4db5a91c656c
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
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
ResourceGroupName            : joyer-test
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


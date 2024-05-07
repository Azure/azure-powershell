### Example 1: Update storage action task with conditions
```powershell
$elseoperation = New-AzStorageActionTaskOperationObject -Name DeleteBlob -OnFailure break -OnSuccess continue
Update-AzStorageActionTask -Name mytask1 -ResourceGroupName ps1-test -ElseOperation $elseoperation
```

```output
CreationTimeInUtc            : 1/23/2024 6:47:43 AM
Description                  : my storage task
ElseOperation                : {{
                                 "name": "DeleteBlob",
                                 "onSuccess": "continue",
                                 "onFailure": "break"
                               }}
Enabled                      : False
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

This command updates storage action task.


### Example 2: Update storage action task with conditions
```powershell
$ifOperation = New-AzStorageActionTaskOperationObject -Name SetBlobTier -Parameter @{"tier"= "Hot"} -OnFailure break -OnSuccess continue
Update-AzStorageActionTask -Name mytask3 -ResourceGroupName joyer-test -IfCondition "[[equals(AccessTier, 'Hot')]]" -IfOperation $ifoperation
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

This command updates storage action task.


### Example 3: Update storage action task with system assigned
```powershell
Update-AzStorageActionTask -Name mytask1 -ResourceGroupName joyer-test -EnableSystemAssignedIdentity 1
```

```output
CreationTimeInUtc            : 2/27/2024 6:48:18 AM
Description                  : my storage task
ElseOperation                : 
Enabled                      : True
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.StorageActions/storageTasks/myta 
                               sk1
IdentityPrincipalId          : 66aefa04-060e-4eeb-9342-7228e31d1596
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
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

This command updates storage action task.
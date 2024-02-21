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

The first command creates a if operation object. The second command creates a storage task.
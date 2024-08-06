### Example 1: Get specific storage action task with specified resource group
```powershell
Get-AzStorageActionTask -Name mytask1 -ResourceGroupName group001
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

This command gets specific storage action task with specified resource group

### Example 2: List storage action task by subscription
```powershell
Get-AzStorageActionTask
```

```output
Location      Name    SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Resour 
                                                                                                                                                                     ceGrou 
                                                                                                                                                                     pName  
--------      ----    ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- ------ 
canadacentral task1                                                                                                                                                  test-… 
eastus2euap   mytask1                                                                                                                                                ps1-t… 
```

This command gets list of storage action task by subscription.


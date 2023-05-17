### Example 1: By machine id.
```powershell
Resume-AzMigrateServerReplication -TargetObjectID "/Subscriptions/xxx-xxx-xxxxxx-xxx-xxx/resourceGroups/cbtsignoff2201rg/providers/Microsoft.RecoveryServices/vaults/signoffccyapp3352vault/replicationFabrics/signoffccyappae52replicationfabric/replicationProtectionContainers/signoffccyappae52replicationcontainer/replicationMigrationItems/idclab-vcen67-fareast-corp-micr-0f144e99-ba36-4649-b92b-8b06854aa539_5015f6d8-fc84-afdf-de47-1eab79330f00"
```

```output
ActivityId                       : 0b810233-b0aa-4a4c-a44e-bea4589c0513 ActivityId: ccb4889b-b9ec-4a76-af4d-4eb59c76ebac
AllowedAction                    : {}
CustomDetailAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202301.JobDetailsAffectedObjectDetails
CustomDetailInstanceType         : AsrJobDetails
EndTime                          :
Error                            : {}
FriendlyName                     :
Id                               : /Subscriptions/xxx-xxx-xxxxxx-xxx-xxx/resourceGroups/cbtsignoff2201rg/providers/Microsoft.RecoveryServices/vaults/signoff
                                   ccyapp3352vault/replicationJobs/75a6945d-2276-4dbb-926c-d0745e004130
Location                         :
Name                             : 75a6945d-2276-4dbb-926c-d0745e004130
ScenarioName                     :
StartTime                        :
State                            : NotStarted
StateDescription                 : NotStarted
TargetInstanceType               : ProtectionEntity
TargetObjectId                   :
TargetObjectName                 :
Task                             : {}
Type                             : Microsoft.RecoveryServices/vaults/replicationJobs
```

By machine id.

### Example 2: By input object
```powershell
$obj = Get-AzMigrateServerReplication -ProjectName "signoffccyproj" -ResourceGroupName "cbtsignoff2201rg" -MachineName "Win2k16"
Resume-AzMigrateServerReplication -InputObject $obj
```
```output
ActivityId                       : 0b810233-b0aa-4a4c-a44e-bea4589c0513 ActivityId: ccb4889b-b9ec-4a76-af4d-4eb59c76ebac
AllowedAction                    : {}
CustomDetailAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202301.JobDetailsAffectedObjectDetails
CustomDetailInstanceType         : AsrJobDetails
EndTime                          :
Error                            : {}
FriendlyName                     :
Id                               : /Subscriptions/xxx-xxx-xxxxxx-xxx-xxx/resourceGroups/cbtsignoff2201rg/providers/Microsoft.RecoveryServices/vaults/signoff
                                   ccyapp3352vault/replicationJobs/75a6945d-2276-4dbb-926c-d0745e004130
Location                         :
Name                             : 75a6945d-2276-4dbb-926c-d0745e004130
ScenarioName                     :
StartTime                        :
State                            : NotStarted
StateDescription                 : NotStarted
TargetInstanceType               : ProtectionEntity
TargetObjectId                   :
TargetObjectName                 :
Task                             : {}
Type                             : Microsoft.RecoveryServices/vaults/replicationJobs
```
By input object.
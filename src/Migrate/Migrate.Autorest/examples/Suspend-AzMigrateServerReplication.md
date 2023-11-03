### Example 1: By machine id.
```powershell
Suspend-AzMigrateServerReplication -TargetObjectID "/Subscriptions/xxx-xxx-xxxxxx-xxx-xxx/resourceGroups/cbtsignoff2201rg/providers/Microsoft.RecoveryServices/vaults/signoffccyapp3352vault/replicationFabrics/signoffccyappae52replicationfabric/replicationProtectionContainers/signoffccyappae52replicationcontainer/replicationMigrationItems/idclab-vcen67-fareast-corp-micr-0f144e99-ba36-4649-b92b-8b06854aa539_5015f6d8-fc84-afdf-de47-1eab79330f00"
```

```output
ActivityId                       : da61a495-48b7-40df-a251-f23f491b2566 ActivityId: e16e0301-be13-4c35-8242-1451cb057994
AllowedAction                    : {}
CustomDetailAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202301.JobDetailsAffectedObjectDetails
CustomDetailInstanceType         : AsrJobDetails
EndTime                          :
Error                            : {}
FriendlyName                     : Pause replication
Id                               : /Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2201rg/providers/Microsoft.RecoveryServices/vaults/signoff
                                   ccyapp3352vault/replicationJobs/6ded7417-b939-4c30-b622-d80a63865025
Location                         :
Name                             : 6ded7417-b939-4c30-b622-d80a63865025
ScenarioName                     : PauseReplication
StartTime                        : 9/25/2022 9:10:42 PM
State                            : InProgress
StateDescription                 : InProgress
TargetInstanceType               : ProtectionEntity
TargetObjectId                   : 52896ea4-214d-5825-bc32-24169dfcc44c
TargetObjectName                 : Win2k16
Task                             : {PauseReplicationPreflightChecksTask, PauseReplicationTask}
Type                             : Microsoft.RecoveryServices/vaults/replicationJobs
```

By machine id.

### Example 2: By input object
```powershell
$obj = Get-AzMigrateServerReplication -ProjectName "signoffccyproj" -ResourceGroupName "cbtsignoff2201rg" -MachineName "Win2k16"
Suspend-AzMigrateServerReplication -InputObject $obj
```
```output
ActivityId                       : da61a495-48b7-40df-a251-f23f491b2566 ActivityId: e16e0301-be13-4c35-8242-1451cb057994
AllowedAction                    : {}
CustomDetailAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202301.JobDetailsAffectedObjectDetails
CustomDetailInstanceType         : AsrJobDetails
EndTime                          :
Error                            : {}
FriendlyName                     : Pause replication
Id                               : /Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2201rg/providers/Microsoft.RecoveryServices/vaults/signoff
                                   ccyapp3352vault/replicationJobs/6ded7417-b939-4c30-b622-d80a63865025
Location                         :
Name                             : 6ded7417-b939-4c30-b622-d80a63865025
ScenarioName                     : PauseReplication
StartTime                        : 9/25/2022 9:10:42 PM
State                            : InProgress
StateDescription                 : InProgress
TargetInstanceType               : ProtectionEntity
TargetObjectId                   : 52896ea4-214d-5825-bc32-24169dfcc44c
TargetObjectName                 : Win2k16
Task                             : {PauseReplicationPreflightChecksTask, PauseReplicationTask}
Type                             : Microsoft.RecoveryServices/vaults/replicationJobs
```
By input object.
---
external help file:
Module Name: Az.Migrate
online version: https://learn.microsoft.com/powershell/module/az.migrate/suspend-azmigrateserverreplication
schema: 2.0.0
---

# Suspend-AzMigrateServerReplication

## SYNOPSIS
Suspends the ongoing replication.

## SYNTAX

### ByIDVMwareCbt (Default)
```
Suspend-AzMigrateServerReplication -TargetObjectID <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ByInputObjectVMwareCbt
```
Suspend-AzMigrateServerReplication -InputObject <IMigrationItem> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The Suspend-AzMigrateServerReplication suspends the ongoing replication.

## EXAMPLES

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
```

### -InputObject
Specifies the replicating server for which the suspend replication needs to be initiated.
The server object can be retrieved using the Get-AzMigrateServerReplication cmdlet
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202301.IMigrationItem
Parameter Sets: ByInputObjectVMwareCbt
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

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

### -TargetObjectID
Specifies the replicating server for which the suspend replication needs to be initiated.
The ID should be retrieved using the Get-AzMigrateServerReplication cmdlet.

```yaml
Type: System.String
Parameter Sets: ByIDVMwareCbt
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202301.IJob

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IMigrationItem>`: Specifies the replicating server for which the suspend replication needs to be initiated. The server object can be retrieved using the Get-AzMigrateServerReplication cmdlet
  - `[Location <String>]`: Resource Location
  - `[ProviderSpecificDetail <IMigrationProviderSpecificSettings>]`: The migration provider custom settings.
    - `InstanceType <String>`: Gets the instance type.

## RELATED LINKS


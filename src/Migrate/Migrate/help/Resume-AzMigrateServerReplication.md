---
external help file:
Module Name: Az.Migrate
online version: https://learn.microsoft.com/powershell/module/az.migrate/resume-azmigrateserverreplication
schema: 2.0.0
---

# Resume-AzMigrateServerReplication

## SYNOPSIS
Starts the replication that has been suspended.

## SYNTAX

### ByIDVMwareCbt (Default)
```
Resume-AzMigrateServerReplication -TargetObjectID <String> [-DeleteMigratedResource]
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ByInputObjectVMwareCbt
```
Resume-AzMigrateServerReplication -InputObject <IMigrationItem> [-DeleteMigratedResource]
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The Resume-AzMigrateServerReplication starts the replication that has been suspended.

## EXAMPLES

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

### -DeleteMigratedResource
Specifies whether the migrated resources needs to be deleted.

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

### -InputObject
Specifies the replicating server for which the resume replication needs to be initiated.
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
Specifies the replicating server for which the resume replication needs to be initiated.
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


`INPUTOBJECT <IMigrationItem>`: Specifies the replicating server for which the resume replication needs to be initiated. The server object can be retrieved using the Get-AzMigrateServerReplication cmdlet
  - `[Location <String>]`: Resource Location
  - `[ProviderSpecificDetail <IMigrationProviderSpecificSettings>]`: The migration provider custom settings.
    - `InstanceType <String>`: Gets the instance type.

## RELATED LINKS


---
external help file: Az.Migrate-help.xml
Module Name: Az.Migrate
online version: https://learn.microsoft.com/powershell/module/az.migrate/get-azmigratehciserverreplication
schema: 2.0.0
---

# Get-AzMigrateHCIServerReplication

## SYNOPSIS
Retrieves the details of the replicating server.

## SYNTAX

### ListByName (Default)
```
Get-AzMigrateHCIServerReplication -ResourceGroupName <String> -ProjectName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByMachineName
```
Get-AzMigrateHCIServerReplication -ResourceGroupName <String> -ProjectName <String> [-SubscriptionId <String>]
 -MachineName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByItemID
```
Get-AzMigrateHCIServerReplication [-SubscriptionId <String>] -TargetObjectID <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetBySDSID
```
Get-AzMigrateHCIServerReplication [-SubscriptionId <String>] -DiscoveredMachineId <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByInputObject
```
Get-AzMigrateHCIServerReplication [-SubscriptionId <String>] -InputObject <IMigrateIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ListById
```
Get-AzMigrateHCIServerReplication [-SubscriptionId <String>] -ResourceGroupID <String> -ProjectID <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzMigrateHCIServerReplication cmdlet retrieves the object for the replicating server.

## EXAMPLES

### Example 1: Get details by id
```powershell
Get-AzMigrateHCIServerReplication -TargetObjectID '/subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/proj62434replicationvault/protectedItems/503a4f02-916c-d6b0-8d14-222bbd4767e5'
```

```output
Id                           : /subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/proj62434replicationvault/protectedItems/503a4f02-916c-d6b0-8d14-222bbd4767e5
Name                         : 503a4f02-916c-d6b0-8d14-222bbd4767e5
Property                     : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ProtectedItemModelProperties
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ProtectedItemModelTags
Type                         : Microsoft.DataReplication/replicationVaults/protectedItems
```

Get by id.

### Example 2: Get detail by discovered machine id
```powershell
Get-AzMigrateHCIServerReplication -DiscoveredMachineId "/subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.OffAzure/HyperVSites/siteName1/machines/503a4f02-916c-d6b0-8d14-222bbd4767e5"
```

```output
Id                           : /subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/proj62434replicationvault/protectedItems/503a4f02-916c-d6b0-8d14-222bbd4767e5
Name                         : 503a4f02-916c-d6b0-8d14-222bbd4767e5
Property                     : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ProtectedItemModelProperties
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ProtectedItemModelTags
Type                         : Microsoft.DataReplication/replicationVaults/protectedItems
```

Get by discovered machine id.

### Example 3: List all in project by name
```powershell
Get-AzMigrateServerReplication -ResourceGroupName testResourceGroup -ProjectName testProjectName
```

```output
Id                           : /subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/proj62434replicationvault/protectedItems/503a4f02-916c-d6b0-8d14-222bbd4767e5
Name                         : 503a4f02-916c-d6b0-8d14-222bbd4767e5
Property                     : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ProtectedItemModelProperties
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ProtectedItemModelTags
Type                         : Microsoft.DataReplication/replicationVaults/protectedItems

Id                           : /subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/proj62434replicationvault/protectedItems/d758f4fb-ae5e-4ac8-bb97-1e114555fe9f
Name                         : d758f4fb-ae5e-4ac8-bb97-1e114555fe9f
Property                     : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ProtectedItemModelProperties
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ProtectedItemModelTags
Type                         : Microsoft.DataReplication/replicationVaults/protectedItems
```

List all.

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

### -DiscoveredMachineId
Specifies the machine ID of the discovered server.

```yaml
Type: System.String
Parameter Sets: GetBySDSID
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Specifies the machine object of the replicating server.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IMigrateIdentity
Parameter Sets: GetByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MachineName
Specifies the display name of the replicating machine.

```yaml
Type: System.String
Parameter Sets: GetByMachineName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectID
Specifies the Azure Migrate Project in which servers are replicating.

```yaml
Type: System.String
Parameter Sets: ListById
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
Specifies the Azure Migrate project  in the current subscription.

```yaml
Type: System.String
Parameter Sets: ListByName, GetByMachineName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupID
Specifies the Resource Group of the Azure Migrate Project in the current subscription.

```yaml
Type: System.String
Parameter Sets: ListById
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the Resource Group of the Azure Migrate Project in the current subscription.

```yaml
Type: System.String
Parameter Sets: ListByName, GetByMachineName
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
Specifies the replicating server ARM ID.

```yaml
Type: System.String
Parameter Sets: GetByItemID
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IMigrateIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.IProtectedItemModel

## NOTES

## RELATED LINKS

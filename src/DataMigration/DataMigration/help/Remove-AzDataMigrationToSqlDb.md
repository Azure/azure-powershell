---
external help file: Az.DataMigration-help.xml
Module Name: Az.DataMigration
online version: https://docs.microsoft.com/powershell/module/az.datamigration/remove-azdatamigrationtosqldb
schema: 2.0.0
---

# Remove-AzDataMigrationToSqlDb

## SYNOPSIS
Remove the specified database migration for a given SQL Db.

## SYNTAX

### Delete (Default)
```
Remove-AzDataMigrationToSqlDb -ResourceGroupName <String> -SqlDbInstanceName <String>
 [-SubscriptionId <String>] -TargetDbName <String> [-Force] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzDataMigrationToSqlDb -InputObject <IDataMigrationIdentity> [-Force] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Remove the specified database migration for a given SQL Db.

## EXAMPLES

### Example 1: Delete the SQL DB Database Migration resource.
```powershell
Remove-AzDataMigrationToSqlDb -ResourceGroupName tsum38RG -SqlDbInstanceName dmstestsqldb -TargetDbName at_sqldbtrgtps1
```

Delete the SQL DB Database Migration resource.

### Example 2: Delete the SQL DB Database Migration resource even if it is in progress
```powershell
Remove-AzDataMigrationToSqlDb -ResourceGroupName tsum38RG -SqlDbInstanceName dmstestsqldb -TargetDbName at_sqldbtrgtps1 -Force
```

Forcibly deletes an ongoing Migration to SQL DB by adding the optional "Force" parameter

## PARAMETERS

### -AsJob
Run the command as a job

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

### -Force
Optional force delete boolean.
If this is provided as true, migration will be deleted even if active.

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
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.IDataMigrationIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -PassThru
Returns true when the command succeeds

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

### -ResourceGroupName
Name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlDbInstanceName
.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription ID that identifies an Azure subscription.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetDbName
The name of the target database.

```yaml
Type: System.String
Parameter Sets: Delete
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

### Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.IDataMigrationIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDataMigrationIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ManagedInstanceName <String>]`: 
  - `[ResourceGroupName <String>]`: Name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  - `[SqlDbInstanceName <String>]`: 
  - `[SqlMigrationServiceName <String>]`: Name of the SQL Migration Service.
  - `[SqlVirtualMachineName <String>]`: 
  - `[SubscriptionId <String>]`: Subscription ID that identifies an Azure subscription.
  - `[TargetDbName <String>]`: The name of the target database.

## RELATED LINKS

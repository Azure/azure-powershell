---
external help file:
Module Name: Az.DataMigration
online version: https://docs.microsoft.com/powershell/module/az.datamigration/remove-azdatamigrationsqlservicenode
schema: 2.0.0
---

# Remove-AzDataMigrationSqlServiceNode

## SYNOPSIS
Delete the integration runtime node.

## SYNTAX

### DeleteExpanded (Default)
```
Remove-AzDataMigrationSqlServiceNode -ResourceGroupName <String> -SqlMigrationServiceName <String>
 [-SubscriptionId <String>] [-IntegrationRuntimeName <String>] [-NodeName <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteViaIdentityExpanded
```
Remove-AzDataMigrationSqlServiceNode -InputObject <IDataMigrationIdentity> [-IntegrationRuntimeName <String>]
 [-NodeName <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Delete the integration runtime node.

## EXAMPLES

### Example 1: Remove the specified Intergration Runtime Node for a Sql Migration Service
```powershell
PS C:\> Remove-AzDataMigrationSqlServiceNode -ResourceGroupName "MyResourceGroup" -SqlMigrationServiceName "MySqlMigrationService" -NodeName "WIN-AKLAB" | Select *

Name       Node
----       ----
default-ir {}
```

This command removes the specified Intergration Runtime Node for the given Sql Migration Service.

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
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.IDataMigrationIdentity
Parameter Sets: DeleteViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IntegrationRuntimeName
The name of integration runtime.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeName
The name of node to delete.

```yaml
Type: System.String
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
Parameter Sets: DeleteExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlMigrationServiceName
Name of the SQL Migration Service.

```yaml
Type: System.String
Parameter Sets: DeleteExpanded
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
Parameter Sets: DeleteExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20211030Preview.IDeleteNode

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDataMigrationIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ManagedInstanceName <String>]`: 
  - `[ResourceGroupName <String>]`: Name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  - `[SqlMigrationServiceName <String>]`: Name of the SQL Migration Service.
  - `[SqlVirtualMachineName <String>]`: 
  - `[SubscriptionId <String>]`: Subscription ID that identifies an Azure subscription.
  - `[TargetDbName <String>]`: The name of the target database.

## RELATED LINKS


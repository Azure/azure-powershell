---
external help file:
Module Name: Az.DataMigration
online version: https://docs.microsoft.com/en-us/powershell/module/az.datamigration/invoke-azdatamigrationcommandtask
schema: 2.0.0
---

# Invoke-AzDataMigrationCommandTask

## SYNOPSIS
The tasks resource is a nested, proxy-only resource representing work performed by a DMS instance.
This method executes a command on a running task.

## SYNTAX

### CommandExpanded (Default)
```
Invoke-AzDataMigrationCommandTask -GroupName <String> -ProjectName <String> -ServiceName <String>
 -TaskName <String> -CommandType <CommandType> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Command
```
Invoke-AzDataMigrationCommandTask -GroupName <String> -ProjectName <String> -ServiceName <String>
 -TaskName <String> -Parameter <ICommandProperties> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CommandViaIdentity
```
Invoke-AzDataMigrationCommandTask -InputObject <IDataMigrationIdentity> -Parameter <ICommandProperties>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CommandViaIdentityExpanded
```
Invoke-AzDataMigrationCommandTask -InputObject <IDataMigrationIdentity> -CommandType <CommandType>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The tasks resource is a nested, proxy-only resource representing work performed by a DMS instance.
This method executes a command on a running task.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -CommandType
Command type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Support.CommandType
Parameter Sets: CommandExpanded, CommandViaIdentityExpanded
Aliases:

Required: True
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

### -GroupName
Name of the resource group

```yaml
Type: System.String
Parameter Sets: Command, CommandExpanded
Aliases:

Required: True
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
Parameter Sets: CommandViaIdentity, CommandViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Parameter
Base class for all types of DMS command properties.
If command is not supported by current client, this object is returned.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview.ICommandProperties
Parameter Sets: Command, CommandViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProjectName
Name of the project

```yaml
Type: System.String
Parameter Sets: Command, CommandExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
Name of the service

```yaml
Type: System.String
Parameter Sets: Command, CommandExpanded
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
Parameter Sets: Command, CommandExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TaskName
Name of the Task

```yaml
Type: System.String
Parameter Sets: Command, CommandExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview.ICommandProperties

### Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.IDataMigrationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview.ICommandProperties

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDataMigrationIdentity>: Identity Parameter
  - `[FileName <String>]`: Name of the File
  - `[GroupName <String>]`: Name of the resource group
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The Azure region of the operation
  - `[ManagedInstanceName <String>]`: 
  - `[ProjectName <String>]`: Name of the project
  - `[ResourceGroupName <String>]`: Name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  - `[ServiceName <String>]`: Name of the service
  - `[SqlDbInstanceName <String>]`: 
  - `[SqlMigrationServiceName <String>]`: Name of the SQL Migration Service.
  - `[SqlVirtualMachineName <String>]`: 
  - `[SubscriptionId <String>]`: Subscription ID that identifies an Azure subscription.
  - `[TargetDbName <String>]`: The name of the target database.
  - `[TaskName <String>]`: Name of the Task

PARAMETER <ICommandProperties>: Base class for all types of DMS command properties. If command is not supported by current client, this object is returned.
  - `CommandType <CommandType>`: Command type.

## RELATED LINKS


---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/set-azsqlserverconfigurationoption
schema: 2.0.0
---

# Set-AzSqlServerConfigurationOption

## SYNOPSIS
Sets the value for a server configuration option on Azure SQL Managed Instance.

## SYNTAX

### CreateByNameParameterSet (Default)
```
Set-AzSqlServerConfigurationOption [-ResourceGroupName] <String> [-InstanceName] <String> [-Name] <String>
 [-Value] <Int32> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateByParentObjectParameterSet
```
Set-AzSqlServerConfigurationOption [-Name] <String> [-Value] <Int32>
 [-InstanceObject] <AzureSqlManagedInstanceModel> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzSqlServerConfigurationOption** cmdlet sets the value of a server configuration option on Azure SQL Managed Instance.

## EXAMPLES

### Example 1
```powershell
Set-AzSqlServerConfigurationOption -ResourceGroupName "ResourceGroup01" -InstanceName "ManagedInstance01" -Name "allowPolybaseExport"
```

```Output
ResourceGroupName : ResourceGroup01
InstanceName      : ManagedInstance01
Type              : Microsoft.Sql/managedInstances/serverConfigurationOptions
Id                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01/serverConfigurationOptions/allowPolybaseExport
Name              : allowPolybaseExport
Value             : 1
```

This command sets the value of a server configuration option named "allowPolybaseExport" on instance "Instance01" and resource group "ResourceGroup01".

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstanceName
Name of Azure SQL Managed Instance.

```yaml
Type: System.String
Parameter Sets: CreateByNameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstanceObject
Instance input object.

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel
Parameter Sets: CreateByParentObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the server configuration option.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ConfigOptionName
Accepted values: allowPolybaseExport

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group.

```yaml
Type: System.String
Parameter Sets: CreateByNameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
Value of the server configuration option.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases: ConfigOptionValue
Accepted values: 0, 1

Required: True
Position: 3
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

### Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ServerConfigurationOptions.Model.ServerConfigurationOptionsModel

## NOTES

## RELATED LINKS

[Get-AzSqlServerConfigurationOption](./Get-AzSqlServerConfigurationOption.md)
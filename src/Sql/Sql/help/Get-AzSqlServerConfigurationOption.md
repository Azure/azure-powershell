---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/get-azsqlserverconfigurationoption
schema: 2.0.0
---

# Get-AzSqlServerConfigurationOption

## SYNOPSIS
Returns information about server configuration options for Azure SQL Managed Instance.

## SYNTAX

### GetByNameParameterSet (Default)
```
Get-AzSqlServerConfigurationOption [-ResourceGroupName] <String> [-InstanceName] <String> [[-Name] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByParentObjectParameterSet
```
Get-AzSqlServerConfigurationOption [[-Name] <String>] [-InstanceObject] <AzureSqlManagedInstanceModel>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByInstanceResourceIdParameterSet
```
Get-AzSqlServerConfigurationOption [[-Name] <String>] [-InstanceResourceId] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByResourceIdParameterSet
```
Get-AzSqlServerConfigurationOption [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSqlServerConfigurationOption** cmdlet returns information about one or more server configuration option on Azure SQL Managed Instance. Specify the name of a server configuration option to see information for that option only.

## EXAMPLES

### Example 1
```powershell
Get-AzSqlServerConfigurationOption -ResourceGroupName "ResourceGroup01" -InstanceName "ManagedInstance01" -Name "allowPolybaseExport"
```

```Output
ResourceGroupName : ResourceGroup01
InstanceName      : ManagedInstance01
Type              : Microsoft.Sql/managedInstances/serverConfigurationOptions
Id                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01/serverConfigurationOptions/allowPolybaseExport
Name              : allowPolybaseExport
Value             : 0
```

This command gets information about the server configuration option named "allowPolybaseExport" on instance "Instance01" and resource group "ResourceGroup01".

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
Parameter Sets: GetByNameParameterSet
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
Parameter Sets: GetByParentObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceResourceId
Managed instance resource ID.

```yaml
Type: System.String
Parameter Sets: GetByInstanceResourceIdParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Name of the server configuration option.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet, GetByParentObjectParameterSet, GetByInstanceResourceIdParameterSet
Aliases: ConfigOptionName
Accepted values: allowPolybaseExport

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Server configuration option resource ID.

```yaml
Type: System.String
Parameter Sets: GetByResourceIdParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ServerConfigurationOptions.Model.ServerConfigurationOptionsModel

## NOTES

## RELATED LINKS

[Set-AzSqlServerConfigurationOption](./Set-AzSqlServerConfigurationOption.md)

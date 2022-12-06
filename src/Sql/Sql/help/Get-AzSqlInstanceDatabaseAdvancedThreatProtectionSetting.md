---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/powershell/module/az.sql/Get-AzSqlInstanceDatabaseAdvancedThreatProtectionSetting
schema: 2.0.0
---

# Get-AzSqlInstanceDatabaseAdvancedThreatProtectionSetting

## SYNOPSIS
Gets the Advanced Threat Protection settings for a managed database.

## SYNTAX

```
Get-AzSqlInstanceDatabaseAdvancedThreatProtectionSetting -InstanceName <String> [-DatabaseName] <String>
 [-ResourceGroupName] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSqlInstanceDatabaseAdvancedThreatProtectionSetting** cmdlet gets the Advanced Threat Protection settings of an Azure SQL managed database.
To use this cmdlet, specify the *ResourceGroupName*, *InstanceName* and *DatabaseName* parameters to identify the managed database for which this cmdlet gets the settings.


## EXAMPLES

### Example 1: Get the Advanced Threat Protection settings for a managed database
```powershell
Get-AzSqlInstanceDatabaseAdvancedThreatProtectionSetting -ResourceGroupName "ResourceGroup11" -InstanceName "Instance01" -DatabaseName "Database01"
```

```output
DatabaseName                  : Database01
ResourceGroupName             : ResourceGroup11
InstanceName                  : Instance01
AdvancedThreatProtectionState : Enabled
```

This command gets the Advanced Threat Protection settings for a managed database named Database01.
The managed database is assigned to the resource group ResourceGroup11.

## PARAMETERS

### -DatabaseName
SQL Managed Database name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstanceName
SQL Managed Instance name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Model.ManagedDatabaseAdvancedThreatProtectionSettingsModel

## NOTES

## RELATED LINKS

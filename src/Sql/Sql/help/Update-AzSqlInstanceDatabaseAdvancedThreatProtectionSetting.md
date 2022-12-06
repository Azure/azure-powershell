---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/powershell/module/az.sql/Update-AzSqlInstanceDatabaseAdvancedThreatProtectionSetting
schema: 2.0.0
---

# Update-AzSqlInstanceDatabaseAdvancedThreatProtectionSetting

## SYNOPSIS
Sets the Advanced Threat Protection settings on a managed database.

## SYNTAX

```
Update-AzSqlInstanceDatabaseAdvancedThreatProtectionSetting -Enable <Boolean> [-PassThru]
 -InstanceName <String> [-DatabaseName] <String> [-ResourceGroupName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzSqlInstanceDatabaseAdvancedThreatProtectionSetting** cmdlet sets the Advanced Threat Protection settings on an Azure SQL managed database.
To use this cmdlet, specify the *ResourceGroupName*, *InstanceName* and *DatabaseName* parameters to identify the managed database.


## EXAMPLES

### Example 1: Set the Advanced Threat Protection settings for a managed database
```powershell
Update-AzSqlInstanceDatabaseAdvancedThreatProtectionSetting -ResourceGroupName "ResourceGroup11" -InstanceName "Instance01" -DatabaseName "Database01"
```

This command sets the Advanced Threat Protection settings for a managed database named Database01.

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

### -Enable
Defines whether to enable or disable Advanced Threat Protection

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -PassThru
Returns an object representing the item with which you are working.
By default, this cmdlet does not generate any output.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Model.ManagedDatabaseAdvancedThreatProtectionSettingsModel

## NOTES

## RELATED LINKS

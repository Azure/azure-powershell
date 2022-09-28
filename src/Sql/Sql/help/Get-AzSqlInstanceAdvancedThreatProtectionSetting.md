---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/powershell/module/az.sql/Get-AzSqlInstanceAdvancedThreatProtectionSetting
schema: 2.0.0
---

# Get-AzSqlInstanceAdvancedThreatProtectionSetting

## SYNOPSIS
Gets the Advanced Threat Protection settings for a managed instance.

## SYNTAX

```
Get-AzSqlInstanceAdvancedThreatProtectionSetting -InstanceName <String> [-ResourceGroupName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSqlInstanceAdvancedThreatProtectionSetting** cmdlet gets the Advanced Threat Protection settings of an Azure SQL managed instance.
To use this cmdlet, specify the *ResourceGroupName* and *InstanceName* parameters to identify the managed instance for which this cmdlet gets the settings.

## EXAMPLES

### Example 1: Get the Advanced Threat Protection settings for a managed instance
```powershell
Get-AzSqlInstanceAdvancedThreatProtectionSetting -ResourceGroupName "ResourceGroup11" -InstanceName "Instance01"
```

```output
ResourceGroupName             : ResourceGroup11
InstanceName                  : Instance01
AdvancedThreatProtectionState : Enabled
```

This command gets the Advanced Threat Protection settings for a managed instance named Instance01.
The managed instance is assigned to the resource group ResourceGroup11.

## PARAMETERS

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

### Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Model.ManagedInstanceAdvancedThreatProtectionSettingsModel

## NOTES

## RELATED LINKS

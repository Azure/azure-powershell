---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/powershell/module/az.sql/new-azsqlserveroutboundfirewallrule
schema: 2.0.0
---

# New-AzSqlServerOutboundFirewallRule

## SYNOPSIS
Adds the allowed FQDN to the list of outbound firewall rules and creates a new outbound firewall rule for Azure SQL Database server.

## SYNTAX

```
New-AzSqlServerOutboundFirewallRule [-AllowedFQDN] <String> [-ServerName] <String>
 [-ResourceGroupName] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzSqlServerOutboundFirewallRule** cmdlet adds the allowed FQDN to the list of outbound firewall rules and creates a new outbound firewall rule for Azure SQL Database server.

## EXAMPLES

### Example 1: Create a new outbound firewall rule
```powershell
New-AzSqlServerOutboundFirewallRule -ServerName "Server01" -ResourceGroupName "ResourceGroup01" -AllowedFQDN "OutboundFirewallRule01"
```

```output
ResourceGroupName : ResourceGroup01
ServerName        : Server01
AllowedFQDN       : OutboundFirewallRule01
```

This command creates a new allowed FQDN named OutboundFirewallRule01 in the list of outbound firewall rules on the server named Server01.

## PARAMETERS

### -AllowedFQDN
Specifies the allowed fully qualified domain name (FQDN) in the list of outbound firewall rules.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

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

### -ResourceGroupName
Specifies the name of a resource group to which the server is assigned.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServerName
Specifies the name of a server.
Specify the server name, not the fully qualified DNS name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Default value: False
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.OutboundFirewallRules.Model.AzureSqlServerOutboundFirewallRulesModel

## NOTES

## RELATED LINKS

[Get-AzSqlServerOutboundFirewallRule](./Get-AzSqlServerOutboundFirewallRule.md)

[Remove-AzSqlServerOutboundFirewallRule](./Remove-AzSqlServerOutboundFirewallRule.md)

[SQL Database Documentation](https://docs.microsoft.com/azure/sql-database/)

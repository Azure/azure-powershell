---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/powershell/module/az.sql/get-azsqlserveroutboundfirewallrule
schema: 2.0.0
---

# Get-AzSqlServerOutboundFirewallRule

## SYNOPSIS
Gets outbound firewall rules (Allowed FQDNs) for a SQL Database server.

## SYNTAX

```
Get-AzSqlServerOutboundFirewallRule [[-AllowedFQDN] <String>] [-ServerName] <String>
 [-ResourceGroupName] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSqlServerOutboundFirewallRule** cmdlet gets the list of Allowed FQDNs in the Outbound Firewall Rules for an Azure SQL Database server.
If you specify the name of an allowed FQDN, this cmdlet gets information about that specific allowed FQDN.

## EXAMPLES

### Example 1: Get outbound firewall rule(s) for a server
<!-- Skip: Output cannot be splitted from code -->
```powershell
Get-AzSqlServerOutboundFirewallRule -ServerName "Server01" -ResourceGroupName "ResourceGroup01" -AllowedFQDN "OutboundFirewallRule01"

ResourceGroupName : ResourceGroup01
ServerName        : Server01
AllowedFQDN       : OutboundFirewallRule01

Get-AzSqlServerOutboundFirewallRule -ResourceGroupName "ResourceGroup01" -ServerName "Server01"

ResourceGroupName : ResourceGroup01
ServerName        : Server01
AllowedFQDN       : OutboundFirewallRule01

ResourceGroupName : ResourceGroup01
ServerName        : Server01
AllowedFQDN       : OutboundFirewallRule02

ResourceGroupName : ResourceGroup01
ServerName        : Server01
AllowedFQDN       : OutboundFirewallRule03
```

This command gets all the allowed FQDNs from the list of Outbound Firewall Rules for the server named Server01 in the resource group named ResourceGroup01.

## PARAMETERS

### -AllowedFQDN
Specifies the allowed fully qualified domain name (FQDN) in the list of outbound firewall rules.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

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

### -ResourceGroupName
Specifies the name of the resource group to which the SQL Server is assigned.

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
Specifies the name of the SQL Server.

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

[New-AzSqlServerOutboundFirewallRule](./New-AzSqlServerOutboundFirewallRule.md)

[Remove-AzSqlServerOutboundFirewallRule](./Remove-AzSqlServerOutboundFirewallRule.md)

[SQL Database Documentation](https://docs.microsoft.com/azure/sql-database/)

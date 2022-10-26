---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/powershell/module/az.sql/get-azsqlserveripv6firewallrule
schema: 2.0.0
---

# Get-AzSqlServerIpv6FirewallRule

## SYNOPSIS
Gets IPv6 firewall rules for a SQL Database server.

## SYNTAX

```
Get-AzSqlServerIpv6FirewallRule [[-Ipv6FirewallRuleName] <String>] [-ServerName] <String> [-ResourceGroupName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSqlServerIpv6FirewallRule** cmdlet gets IPv6 firewall rules for an Azure SQL Database server.
If you specify the name of an IPv6 firewall rule, this cmdlet gets information about that specific IPv6 firewall rule.

## EXAMPLES

### Example 1: Get all IPv6 rules for a server
```powershell
Get-AzSqlServerIpv6FirewallRule -ResourceGroupName "ResourceGroup01" -ServerName "Server01"
```

```output
ResourceGroupName : ResourceGroup01
ServerName        : server01
StartIpv6Address    : 0000:0000:0000:0000:0000:ffff:0000:0000
EndIpv6Address      : 0000:0000:0000:0000:0000:ffff:0000:0001
Ipv6FirewallRuleName  : Rule01

ResourceGroupName : ResourceGroup01
ServerName        : Server01
StartIpv6Address    : 0000:0000:0000:0000:0000:ffff:0000:0002
EndIpv6Address      : 0000:0000:0000:0000:0000:ffff:0000:0003
Ipv6FirewallRuleName  : Rule02
```

This command gets all the IPv6 firewall rules for the server named Server01.

### Example 2: Get all IPv6 rules for a server using filtering
```powershell
Get-AzSqlServerIpv6FirewallRule -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -Ipv6FirewallRuleName "Rule*"
```

```output
ResourceGroupName : ResourceGroup01
ServerName        : server01
StartIpv6Address    : 0000:0000:0000:0000:0000:ffff:0000:0000
EndIpv6Address      : 0000:0000:0000:0000:0000:ffff:0000:0001
Ipv6FirewallRuleName  : Rule01

ResourceGroupName : ResourceGroup01
ServerName        : Server01
StartIpv6Address    : 0000:0000:0000:0000:0000:ffff:0000:0002
EndIpv6Address      : 0000:0000:0000:0000:0000:ffff:0000:0003
Ipv6FirewallRuleName  : Rule02
```

This command gets all the IPv6 firewall rules for the server named Server01 that start with "Rule".

## PARAMETERS

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

### -Ipv6FirewallRuleName
Specifies the name of the IPv6 firewall rule.

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

### Microsoft.Azure.Commands.Sql.Ipv6FirewallRule.Model.AzureSqlServerIpv6FirewallRuleModel

## NOTES

## RELATED LINKS

[New-AzSqlServerIpv6FirewallRule](./New-AzSqlServerIpv6FirewallRule.md)

[Remove-AzSqlServerIpv6FirewallRule](./Remove-AzSqlServerIpv6FirewallRule.md)

[Set-AzSqlServerIpv6FirewallRule](./Set-AzSqlServerIpv6FirewallRule.md)

[SQL Database Documentation](https://docs.microsoft.com/azure/sql-database/)



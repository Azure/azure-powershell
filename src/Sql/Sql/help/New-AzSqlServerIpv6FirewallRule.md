---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/new-azsqlserveripv6firewallrule
schema: 2.0.0
---

# New-AzSqlServerIpv6FirewallRule

## SYNOPSIS
Creates an IPv6 firewall rule for a SQL Database server.

## SYNTAX

### UserSpecifiedRuleSet
```
New-AzSqlServerIpv6FirewallRule -Ipv6FirewallRuleName <String> -StartIpv6Address <String> -EndIpv6Address <String>
 [-ServerName] <String> [-ResourceGroupName] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzSqlServerIpv6FirewallRule** cmdlet creates an IPv6 firewall rule for the specified Azure SQL Database server.

## EXAMPLES

### Example 1: Create an IPv6 firewall rule
```powershell
New-AzSqlServerIpv6FirewallRule -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -Ipv6FirewallRuleName "Rule01" -StartIpv6Address "0000:0000:0000:0000:0000:ffff:c0a8:00c6" -EndIpv6Address "0000:0000:0000:0000:0000:ffff:c0a8:00c7"
```

```output
ResourceGroupName : ResourceGroup01
ServerName        : Server01
StartIpv6Address    : 0000:0000:0000:0000:0000:ffff:c0a8:00c6
EndIpv6Address      : 0000:0000:0000:0000:0000:ffff:c0a8:00c7
Ipv6FirewallRuleName  : Rule01
```

This command creates an IPv6 firewall rule named Rule01 on the server named Server01.
The rule includes the specified start and end IPv6 addresses.

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

### -EndIpv6Address
Specifies the end value of the IPv6 address range for this rule.

```yaml
Type: System.String
Parameter Sets: UserSpecifiedRuleSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Ipv6FirewallRuleName
Specifies the name of the new IPv6 firewall rule.

```yaml
Type: System.String
Parameter Sets: UserSpecifiedRuleSet
Aliases: Name

Required: True
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

### -StartIpv6Address
Specifies the start value of the IPv6 address range for the IPv6 firewall rule.

```yaml
Type: System.String
Parameter Sets: UserSpecifiedRuleSet
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

[Get-AzSqlServerIpv6FirewallRule](./Get-AzSqlServerIpv6FirewallRule.md)

[Remove-AzSqlServerIpv6FirewallRule](./Remove-AzSqlServerIpv6FirewallRule.md)

[Set-AzSqlServerIpv6FirewallRule](./Set-AzSqlServerIpv6FirewallRule.md)

[SQL Database Documentation](https://learn.microsoft.com/azure/sql-database/)


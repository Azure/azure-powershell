---
external help file: Az.PostgreSqlFlexibleServer-help.xml
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/update-azpostgresqlflexibleserverfirewallrule
schema: 2.0.0
---

# Update-AzPostgreSqlFlexibleServerFirewallRule

## SYNOPSIS
Update a new firewall rule or update an existing firewall rule.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzPostgreSqlFlexibleServerFirewallRule -Name <String> -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String>] [-EndIPAddress <String>] [-StartIPAddress <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityFlexibleServerExpanded
```
Update-AzPostgreSqlFlexibleServerFirewallRule -Name <String>
 -FlexibleServerInputObject <IPostgreSqlFlexibleServerIdentity> [-EndIPAddress <String>]
 [-StartIPAddress <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzPostgreSqlFlexibleServerFirewallRule -InputObject <IPostgreSqlFlexibleServerIdentity>
 [-EndIPAddress <String>] [-StartIPAddress <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a new firewall rule or update an existing firewall rule.

## EXAMPLES

### Example 1: Update IP address range for a firewall rule
```powershell
Update-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -FirewallRuleName "AllowMyOffice" -StartIPAddress "203.0.113.1" -EndIPAddress "203.0.113.20"
```

```output
Name          : AllowMyOffice
StartIPAddress: 203.0.113.1
EndIPAddress  : 203.0.113.20
Id            : /subscriptions/ssssssss-ssss-ssss-ssss-ssssssssssss/resourceGroups/myResourceGroup/providers/Microsoft.DBforPostgreSQL/flexibleServers/myPostgreSqlServer/firewallRules/AllowMyOffice
```

Updates an existing firewall rule to expand the allowed IP address range from 10 to 20 addresses.

### Example 2: Update firewall rule to allow single IP address
```powershell
Update-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -FirewallRuleName "AdminAccess" -StartIPAddress "198.51.100.10" -EndIPAddress "198.51.100.10"
```

```output
Name          : AdminAccess
StartIPAddress: 198.51.100.10
EndIPAddress  : 198.51.100.10
Id            : /subscriptions/ssssssss-ssss-ssss-ssss-ssssssssssss/resourceGroups/production-rg/providers/Microsoft.DBforPostgreSQL/flexibleServers/prod-postgresql-01/firewallRules/AdminAccess
```

Updates a firewall rule to allow access from a single specific IP address for administrative purposes.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -EndIPAddress
IP address defining the end of the range of addresses of a firewall rule.
Must be expressed in IPv4 format.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FlexibleServerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity
Parameter Sets: UpdateViaIdentityFlexibleServerExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the firewall rule.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityFlexibleServerExpanded
Aliases: FirewallRuleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
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
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerName
The name of the server.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartIPAddress
IP address defining the start of the range of addresses of a firewall rule.
Must be expressed in IPv4 format.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IFirewallRule

## NOTES

## RELATED LINKS

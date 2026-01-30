---
external help file:
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleserverfirewallrule
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerFirewallRule

## SYNOPSIS
Gets information about a firewall rule in a server.

## SYNTAX

### List (Default)
```
Get-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPostgreSqlFlexibleServerFirewallRule -Name <String> -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPostgreSqlFlexibleServerFirewallRule -InputObject <IPostgreSqlFlexibleServerIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityFlexibleServer
```
Get-AzPostgreSqlFlexibleServerFirewallRule -FlexibleServerInputObject <IPostgreSqlFlexibleServerIdentity>
 -Name <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets information about a firewall rule in a server.

## EXAMPLES

### Example 1: List all firewall rules for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
Name           : ClientIPAddress_1-15-2024_10-30
ResourceGroupName: myResourceGroup
ServerName     : myPostgreSqlServer
StartIPAddress : 192.168.1.100
EndIPAddress   : 192.168.1.100

Name           : AllowAzureServices
ResourceGroupName: myResourceGroup
ServerName     : myPostgreSqlServer
StartIPAddress : 0.0.0.0
EndIPAddress   : 0.0.0.0
```

Lists all firewall rules configured for the PostgreSQL Flexible Server.

### Example 2: Get a specific firewall rule
```powershell
Get-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -Name "ClientIPAddress_1-15-2024_10-30"
```

```output
Name           : ClientIPAddress_1-15-2024_10-30
ResourceGroupName: myResourceGroup
ServerName     : myPostgreSqlServer
StartIPAddress : 192.168.1.100
EndIPAddress   : 192.168.1.100
```

Gets details for a specific firewall rule by name.

## PARAMETERS

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

### -FlexibleServerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity
Parameter Sets: GetViaIdentityFlexibleServer
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
Parameter Sets: GetViaIdentity
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
Parameter Sets: Get, GetViaIdentityFlexibleServer
Aliases: FirewallRuleName

Required: True
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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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


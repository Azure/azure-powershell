---
external help file: Az.PostgreSqlFlexibleServer-help.xml
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleserver
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServer

## SYNOPSIS
Gets information about an existing server.

## SYNTAX

### List (Default)
```
Get-AzPostgreSqlFlexibleServer [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzPostgreSqlFlexibleServer -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzPostgreSqlFlexibleServer -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPostgreSqlFlexibleServer -InputObject <IPostgreSqlFlexibleServerIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets information about an existing server.

## EXAMPLES

### Example 1: List all PostgreSQL Flexible Servers in a subscription
```powershell
Get-AzPostgreSqlFlexibleServer
```

```output
Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
myserver1           East US   Standard_D2s_v3 GeneralPurpose admin              128
myserver2           West US   Standard_B1ms   Burstable      postgres           32
```

Lists all PostgreSQL Flexible Servers in the current subscription.

### Example 2: Get a specific PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServer -Name "myserver1" -ResourceGroupName "myresourcegroup"
```

```output
Name      Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----      --------  -------         -------        ------------------ -------------
myserver1 East US   Standard_D2s_v3 GeneralPurpose admin              128
```

Gets information about the PostgreSQL Flexible Server named 'myserver1' in the specified resource group.

### Example 3: List PostgreSQL Flexible Servers in a resource group
```powershell
Get-AzPostgreSqlFlexibleServer -ResourceGroupName "myresourcegroup"
```

```output
Name      Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----      --------  -------         -------        ------------------ -------------
myserver1 East US   Standard_D2s_v3 GeneralPurpose admin              128
myserver3 East US   Standard_B2s    Burstable      postgres           64
```

Lists all PostgreSQL Flexible Servers in the specified resource group.

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
The name of the server.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ServerName

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
Parameter Sets: Get, List1
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
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServer

## NOTES

## RELATED LINKS

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

### List1 (Default)
```
Get-AzPostgreSqlFlexibleServer [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzPostgreSqlFlexibleServer -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
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

### Example 1: List flexible servers in subscription from default context
```powershell
Get-AzPostgreSqlFlexibleServer
```

```output
Name                                     ResourceGroupName                        Location             SkuName              SkuTier         AdministratorLogin        StorageSizeGb
----                                     -----------------                        --------             -------              -------         ------------------        -------------
example-server-01                        example-resource-group-01                Australia East       Standard_D4ads_v5    GeneralPurpose  adminlogin01              128
example-server-02                        example-resource-group-02                Canada Central       Standard_D4ds_v4     GeneralPurpose  adminlogin02              32
example-server-03                        example-resource-group-03                Japan West           Standard_B1ms        Burstable       adminlogin03              64
example-server-04                        example-resource-group-01                Southeast Asia       Standard_D4ads_v5    GeneralPurpose  adminlogin04              4096
example-server-05                        example-resource-group-04                Central US           Standard_E2ds_v4     MemoryOptimized adminlogin05              128
```

Gets Azure Database for PostgreSQL flexible servers in subscription taken from default context.

### Example 2: List flexible servers in subscription explicitly specified
```powershell
Get-AzPostgreSqlFlexibleServer -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e
```

```output
Name                                     ResourceGroupName                        Location             SkuName              SkuTier         AdministratorLogin        StorageSizeGb
----                                     -----------------                        --------             -------              -------         ------------------        -------------
example-server-01                        example-resource-group-01                Australia East       Standard_D4ads_v5    GeneralPurpose  adminlogin01              128
example-server-02                        example-resource-group-02                Canada Central       Standard_D4ds_v4     GeneralPurpose  adminlogin02              32
example-server-03                        example-resource-group-03                Japan West           Standard_B1ms        Burstable       adminlogin03              64
example-server-04                        example-resource-group-01                Southeast Asia       Standard_D4ads_v5    GeneralPurpose  adminlogin04              4096
example-server-05                        example-resource-group-04                Central US           Standard_E2ds_v4     MemoryOptimized adminlogin05              128
```

Gets Azure Database for PostgreSQL flexible servers in subscription explicitly passed as an argument.

### Example 3: List flexible servers in specific resource group of a subscription
```powershell
Get-AzPostgreSqlFlexibleServer -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group-01
```

```output
Name                                     ResourceGroupName                        Location             SkuName              SkuTier         AdministratorLogin        StorageSizeGb
----                                     -----------------                        --------             -------              -------         ------------------        -------------
example-server-01                        example-resource-group-01                Australia East       Standard_D4ads_v5    GeneralPurpose  adminlogin01              128
example-server-04                        example-resource-group-01                Southeast Asia       Standard_D4ads_v5    GeneralPurpose  adminlogin04              4096
```

Gets Azure Database for PostgreSQL flexible servers in subscription and resource group explicitly passed as an arguments.

### Example 4: Get flexible server corresponding to specific name, resource group and subscription
```powershell
Get-AzPostgreSqlFlexibleServer -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -Name example-server
```

```output
Name                                     ResourceGroupName                        Location             SkuName              SkuTier         AdministratorLogin        StorageSizeGb
----                                     -----------------                        --------             -------              -------         ------------------        -------------
example-server                           example-resource-group                   Southeast Asia       Standard_D4ads_v5    GeneralPurpose  adminlogin                4096
```

Gets Azure Database for PostgreSQL flexible server with name, resource group, and subscription explicitly passed as an arguments.

### Example 5: Get flexible server corresponding to specific resource identifier
```powershell
$ID = "/subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-server"
Get-AzPostgreSqlFlexibleServer -InputObject $ID
```

```output
Name                                     ResourceGroupName                        Location             SkuName              SkuTier         AdministratorLogin        StorageSizeGb
----                                     -----------------                        --------             -------              -------         ------------------        -------------
example-server                           example-resource-group                   Southeast Asia       Standard_D4ads_v5    GeneralPurpose  adminlogin                4096
```

Gets Azure Database for PostgreSQL flexible server with the specific resource identifier of the server, explicitly passed as an argument.

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
Parameter Sets: List1, Get, List
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

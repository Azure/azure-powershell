---
external help file:
Module Name: Az.MySql
online version: https://docs.microsoft.com/en-us/powershell/module/az.mysql/get-azmysqlserver
schema: 2.0.0
---

# Get-AzMySqlServer

## SYNOPSIS
Gets information about a server.

## SYNTAX

### List1 (Default)
```
Get-AzMySqlServer [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMySqlServer -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMySqlServer -InputObject <IMySqlIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzMySqlServer -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets information about a server.

## EXAMPLES

### Example 1: Get MySql server by ResourceGroup and ServerName
```powershell
PS C:\> Get-AzMySqlServer -ResourceGroupName mysql_test -ServerName mysql-test

Name        Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuSize SkuTier        SslEnforcement
----        -------- ------------------ ------- ----------------------- -------   ------- -------        --------------
mysql-test  eastus   mysql_test         5.7     5120                    GP_Gen5_4         GeneralPurpose Enabled
```

The cmdlet gets MySql server by ResourceGroup and ServerName.

### Example 2: Lists all the MySql servers in specified resource group
```powershell
PS C:\> Get-AzMySqlServer -ResourceGroupName mysql_test

Name        Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuSize SkuTier        SslEnforcement
----        -------- ------------------ ------- ----------------------- -------   ------- -------        --------------
mysql-test  eastus   mysql_test         5.7     5120                    GP_Gen5_4         GeneralPurpose Enabled
```

The cmdlet lists all the MySql servers in specified resource group.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.IMySqlIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.IMySqlIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServer

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### INPUTOBJECT <IMySqlIdentity>: Identity Parameter
  - `[ConfigurationName <String>]`: The name of the server configuration.
  - `[DatabaseName <String>]`: The name of the database.
  - `[FirewallRuleName <String>]`: The name of the server firewall rule.
  - `[Id <String>]`: Resource identity path
  - `[LocationName <String>]`: The name of the location.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SecurityAlertPolicyName <SecurityAlertPolicyName?>]`: The name of the security alert policy.
  - `[ServerName <String>]`: The name of the server.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VirtualNetworkRuleName <String>]`: The name of the virtual network rule.

## RELATED LINKS


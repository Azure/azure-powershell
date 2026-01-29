---
external help file:
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleserveradministratorsmicrosoftentra
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra

## SYNOPSIS
Gets information about a server administrator associated to a Microsoft Entra principal.

## SYNTAX

### List (Default)
```
Get-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -ObjectId <String> -ResourceGroupName <String>
 -ServerName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -InputObject <IPostgreSqlFlexibleServerIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityFlexibleServer
```
Get-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra
 -FlexibleServerInputObject <IPostgreSqlFlexibleServerIdentity> -ObjectId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets information about a server administrator associated to a Microsoft Entra principal.

## EXAMPLES

### Example 1: List all Microsoft Entra administrators for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
Name              : user@contoso.com
ResourceGroupName : myResourceGroup
ServerName        : myPostgreSqlServer
PrincipalType     : User
PrincipalName     : user@contoso.com
ObjectId          : 12345678-1234-1234-1234-123456789abc
TenantId          : 11111111-1111-1111-1111-111111111111

Name              : PostgreSQL-Admins
ResourceGroupName : myResourceGroup
ServerName        : myPostgreSqlServer
PrincipalType     : Group
PrincipalName     : PostgreSQL-Admins
ObjectId          : 87654321-4321-4321-4321-210987654321
TenantId          : 11111111-1111-1111-1111-111111111111
```

Lists all Microsoft Entra administrators configured for the PostgreSQL Flexible Server.

### Example 2: Get a specific Microsoft Entra administrator
```powershell
Get-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -ObjectId "12345678-1234-1234-1234-123456789abc"
```

```output
Name              : user@contoso.com
ResourceGroupName : myResourceGroup
ServerName        : myPostgreSqlServer
PrincipalType     : User
PrincipalName     : user@contoso.com
ObjectId          : 12345678-1234-1234-1234-123456789abc
TenantId          : 11111111-1111-1111-1111-111111111111
```

Gets details for a specific Microsoft Entra administrator by object ID.

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

### -ObjectId
Object identifier of the Microsoft Entra principal.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityFlexibleServer
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdministratorMicrosoftEntra

## NOTES

## RELATED LINKS


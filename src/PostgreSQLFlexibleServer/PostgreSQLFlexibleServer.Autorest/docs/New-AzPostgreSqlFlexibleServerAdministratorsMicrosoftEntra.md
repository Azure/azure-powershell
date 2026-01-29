---
external help file:
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/new-azpostgresqlflexibleserveradministratorsmicrosoftentra
schema: 2.0.0
---

# New-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra

## SYNOPSIS
Create a new server administrator associated to a Microsoft Entra principal.

## SYNTAX

### CreateExpanded (Default)
```
New-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -ObjectId <String> -ResourceGroupName <String>
 -ServerName <String> [-SubscriptionId <String>] [-PrincipalName <String>] [-PrincipalType <String>]
 [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityFlexibleServerExpanded
```
New-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra
 -FlexibleServerInputObject <IPostgreSqlFlexibleServerIdentity> -ObjectId <String> [-PrincipalName <String>]
 [-PrincipalType <String>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -ObjectId <String> -ResourceGroupName <String>
 -ServerName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -ObjectId <String> -ResourceGroupName <String>
 -ServerName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new server administrator associated to a Microsoft Entra principal.

## EXAMPLES

### Example 1: Add a Microsoft Entra user as administrator
```powershell
New-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -PrincipalName "user@contoso.com" -PrincipalType "User" -ObjectId "12345678-1234-1234-1234-123456789abc"
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

Adds a Microsoft Entra user as an administrator for the PostgreSQL Flexible Server.

### Example 2: Add a Microsoft Entra group as administrator
```powershell
New-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -PrincipalName "PostgreSQL-Admins" -PrincipalType "Group" -ObjectId "87654321-4321-4321-4321-210987654321"
```

```output
Name              : PostgreSQL-Admins
ResourceGroupName : production-rg
ServerName        : prod-postgresql-01
PrincipalType     : Group
PrincipalName     : PostgreSQL-Admins
ObjectId          : 87654321-4321-4321-4321-210987654321
TenantId          : 11111111-1111-1111-1111-111111111111
```

Adds a Microsoft Entra group as an administrator for the PostgreSQL Flexible Server.

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

### -FlexibleServerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity
Parameter Sets: CreateViaIdentityFlexibleServerExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

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

### -ObjectId
Object identifier of the Microsoft Entra principal.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrincipalName
Name of the Microsoft Entra principal.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityFlexibleServerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrincipalType
Type of Microsoft Entra principal to which the server administrator is associated.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityFlexibleServerExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantId
Identifier of the tenant in which the Microsoft Entra principal exists.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityFlexibleServerExpanded
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdministratorMicrosoftEntra

## NOTES

## RELATED LINKS


---
external help file:
Module Name: Az.ServiceLinker
online version: https://learn.microsoft.com/powershell/module/az.ServiceLinker/new-azservicelinkeruserassignedidentityauthinfoobject
schema: 2.0.0
---

# New-AzServiceLinkerUserAssignedIdentityAuthInfoObject

## SYNOPSIS
Create an in-memory object for UserAssignedIdentityAuthInfo.

## SYNTAX

```
New-AzServiceLinkerUserAssignedIdentityAuthInfoObject [-ClientId <String>] [-SubscriptionId <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for UserAssignedIdentityAuthInfo.

## EXAMPLES

### Example 1: create linker's auth info with user assigned identity type
```powershell
New-AzServiceLinkerUserAssignedIdentityAuthInfoObject -ClientId 00000000-0000-0000-0000-000000000000 -SubscriptionId 00000000-0000-0000-0000-000000000000
```

```output
AuthType             ClientId                             SubscriptionId
--------             --------                             --------------
userAssignedIdentity 00000000-0000-0000-0000-000000000000 00000000-0000-0000-0000-0000… 
```

create linker's auth info with user assigned identity type

## PARAMETERS

### -ClientId
Client Id for userAssignedIdentity.

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
Subscription id for userAssignedIdentity.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.Api20221101Preview.UserAssignedIdentityAuthInfo

## NOTES

## RELATED LINKS


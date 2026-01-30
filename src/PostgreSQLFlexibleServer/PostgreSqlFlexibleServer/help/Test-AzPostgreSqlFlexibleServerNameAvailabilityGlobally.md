---
external help file: Az.PostgreSqlFlexibleServer-help.xml
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/test-azpostgresqlflexibleservernameavailabilityglobally
schema: 2.0.0
---

# Test-AzPostgreSqlFlexibleServerNameAvailabilityGlobally

## SYNOPSIS
Checks the validity and availability of the given name, to assign it to a new server or to use it as the base name of a new pair of virtual endpoints.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzPostgreSqlFlexibleServerNameAvailabilityGlobally [-SubscriptionId <String>] [-Name <String>]
 [-Type <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Check
```
Test-AzPostgreSqlFlexibleServerNameAvailabilityGlobally [-SubscriptionId <String>]
 -Parameter <ICheckNameAvailabilityRequest> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaJsonFilePath
```
Test-AzPostgreSqlFlexibleServerNameAvailabilityGlobally [-SubscriptionId <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaJsonString
```
Test-AzPostgreSqlFlexibleServerNameAvailabilityGlobally [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Checks the validity and availability of the given name, to assign it to a new server or to use it as the base name of a new pair of virtual endpoints.

## EXAMPLES

### Example 1: Test server name availability across all Azure regions
```powershell
Test-AzPostgreSqlFlexibleServerNameAvailabilityGlobally -ServerName "globally-unique-postgresql-2025"
```

```output
NameAvailable : True
Reason        : 
Message       : 
```

Checks if the specified server name is globally available across all Azure regions.

### Example 2: Test a name that conflicts globally
```powershell
Test-AzPostgreSqlFlexibleServerNameAvailabilityGlobally -ServerName "postgresql-server"
```

```output
NameAvailable : False
Reason        : AlreadyExists
Message       : The specified name is already in use globally.
```

Tests a server name that already exists globally and confirms it's unavailable for use.

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

### -JsonFilePath
Path of Json file supplied to the Check operation

```yaml
Type: System.String
Parameter Sets: CheckViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Check operation

```yaml
Type: System.String
Parameter Sets: CheckViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the resource for which availability needs to be checked.

```yaml
Type: System.String
Parameter Sets: CheckExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The check availability request body.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICheckNameAvailabilityRequest
Parameter Sets: Check
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The resource type.

```yaml
Type: System.String
Parameter Sets: CheckExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICheckNameAvailabilityRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INameAvailabilityModel

## NOTES

## RELATED LINKS

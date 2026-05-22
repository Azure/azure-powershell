---
external help file:
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleserverquotausage
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerQuotaUsage

## SYNOPSIS
Get quota usages at specified location in a given subscription.

## SYNTAX

```
Get-AzPostgreSqlFlexibleServerQuotaUsage -LocationName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get quota usages at specified location in a given subscription.

## EXAMPLES

### Example 1: List all quotas in a subscription for a given location
```powershell
Get-AzPostgreSqlFlexibleServerQuotaUsage -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -LocationName example-location
```

```output
NameValue                                NameLocalizedValue                       Unit       Limit      CurrentValue
---------                                ------------------                       ----       -----      ------------
cores                                    cores                                    Count      196        118
standardBSFamily                         standardBSFamily                         Count      622        6
standardDDSv4Family                      standardDDSv4Family                      Count      260        4
standardDDSv5Family                      standardDDSv5Family                      Count      502        58
standardDSv3Family                       standardDSv3Family                       Count      424        0
standardEDSv4Family                      standardEDSv4Family                      Count      250        0
standardEDSv5Family                      standardEDSv5Family                      Count      271        0
standardESv3Family                       standardESv3Family                       Count      145        0
```

Lists all quotas defined, and their corresponding usage, for Azure Database for PostgreSQL flexible server, with location and subscription explicitly passed as an arguments.
If subscription is not passed explicitly, it's taken from default context.

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

### -LocationName
The name of the location.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IQuotaUsage

## NOTES

## RELATED LINKS


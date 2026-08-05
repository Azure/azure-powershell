---
external help file: Az.SecurityInsights-help.xml
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/get-azsentinelenrichment
schema: 2.0.0
---

# Get-AzSentinelEnrichment

## SYNOPSIS
Get geodata for a single IP address

## SYNTAX

### Get (Default)
```
Get-AzSentinelEnrichment -ResourceGroupName <String> [-SubscriptionId <String[]>] -IPAddress <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzSentinelEnrichment -ResourceGroupName <String> [-SubscriptionId <String[]>] -Domain <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get geodata for a single IP address

## EXAMPLES

### Example 1: Get a Domain Enrichment
```powershell
Get-AzSentinelEnrichment -ResourceGroupName "myResourceGroupName" -Domain "microsoft.com"
```

```output
Created : 5/2/1991 12:00:00 AM
Domain  : microsoft.com
Expire  : 5/3/2022 12:00:00 AM
Server  : whois.markmonitor.com
Updated : 3/12/2021 12:00:00 AM
```

This command gets an enrichment for a domain.

### Example 2: Get a IP Enrichment
```powershell
Get-AzSentinelEnrichment -ResourceGroupName "myResourceGroupName" -IPAddress "1.1.1.1"
```

```output
Asn              : 13335
Carrier          : cloudflare
City             : ringwood
CityCf           : 90
Continent        : oceania
Country          : australia
CountryCf        : 99
IPAddr           : 1.1.1.1
IPRoutingType    : fixed
Latitude         : -37.8143
Longitude        : 145.2274
Organization     : apnic and cloudflare dns resolver project
OrganizationType : Internet Hosting Services
Region           :
State            : victoria
StateCf          : 95
StateCode        :
```

This command an enrichment for an IP Address.

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

### -Domain
Domain name to be enriched

```yaml
Type: System.String
Parameter Sets: Get1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IPAddress
IP address (v4 or v6) to be enriched

```yaml
Type: System.String
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.IEnrichmentDomainWhois

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.IEnrichmentIPGeodata

## NOTES

## RELATED LINKS

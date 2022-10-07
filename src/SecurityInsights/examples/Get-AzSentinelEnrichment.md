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


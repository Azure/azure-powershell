---
Module Name: Az.Dns
Module Guid: 6bb9f5b6-6948-424c-b7b3-faba33be0aef
Download Help Link: https://learn.microsoft.com/powershell/module/az.dns
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Dns Module
## Description
Microsoft Azure PowerShell: Dns cmdlets

## Az.Dns Cmdlets
### [Get-AzDnsDnssecConfig](Get-AzDnsDnssecConfig.md)
Gets the DNSSEC configuration.

### [Get-AzDnsRecordSet](Get-AzDnsRecordSet.md)
Gets a record set.

### [Get-AzDnsResourceReference](Get-AzDnsResourceReference.md)
Returns the DNS records specified by the referencing targetResourceIds.

### [Get-AzDnsZone](Get-AzDnsZone.md)
Gets a DNS zone.
Retrieves the zone properties, but not the record sets within the zone.

### [New-AzDnsDnssecConfig](New-AzDnsDnssecConfig.md)
Creates or updates the DNSSEC configuration on a DNS zone.

### [New-AzDnsRecordSet](New-AzDnsRecordSet.md)
Creates or updates a record set within a DNS zone.
Record sets of type SOA can be updated but not created (they are created when the DNS zone is created).

### [New-AzDnsZone](New-AzDnsZone.md)
Creates or updates a DNS zone.
Does not modify DNS records within the zone.

### [Remove-AzDnsDnssecConfig](Remove-AzDnsDnssecConfig.md)
Deletes the DNSSEC configuration on a DNS zone.
This operation cannot be undone.

### [Remove-AzDnsRecordSet](Remove-AzDnsRecordSet.md)
Deletes a record set from a DNS zone.
This operation cannot be undone.
Record sets of type SOA cannot be deleted (they are deleted when the DNS zone is deleted).

### [Remove-AzDnsZone](Remove-AzDnsZone.md)
Deletes a DNS zone.
WARNING: All DNS records in the zone will also be deleted.
This operation cannot be undone.

### [Update-AzDnsRecordSet](Update-AzDnsRecordSet.md)
Updates a record set within a DNS zone.

### [Update-AzDnsZone](Update-AzDnsZone.md)
Updates a DNS zone.
Does not modify DNS records within the zone.


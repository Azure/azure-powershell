# Az.Dns Release Notes

## Version 0.1.0-preview
### What's New
- For New/Set/Update of a DnsRecordSet, they now have parameter sets for each RecordSet type. This allows more intuitive creation/updating.
- For New/Set of a DnsZone, they now have parameter sets based on if you are creating a Private DnsZone versus a Public DnsZone.
- The DnsRecordConfig cmdlets were removed as they only created in-memory objects and did not communicate with Azure.

### Supported Cmdlets
- Get-AzDnsRecordSet
- Get-AzDnsResourceReference
- Get-AzDnsZone
- New-AzDnsRecordSet
- New-AzDnsZone
- Remove-AzDnsRecordSet
- Remove-AzDnsZone
- Set-AzDnsRecordSet
- Set-AzDnsZone
- Update-AzDnsRecordSet

### Removed Cmdlets
- Add-AzDnsRecordConfig
- New-AzDnsRecordConfig
- Remove-AzDnsRecordConfig
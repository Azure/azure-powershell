## Incorrect Cmdlets

- Get-AzDnsRecordSet
    - Zone
- New-AzDnsRecordSet
    - Zone
    - RecordType
    - DnsRecords
    - Overwrite
- New-AzDnsZone
    - ZoneType
    - RegistrationVirtualNetwork
    - ResolutionVirtualNetwork
- Remove-AzDnsRecordSet
    - Zone
    - RecordSet
    - Overwrite
- Remove-AzDnsZone
    - Zone
    - Overwrite
- Set-AzDnsRecordSet
    - RecordSet
    - Overwrite
- Set-AzDnsZone
    - RegistrationVirtualNetwork
    - ResolutionVirtualNetwork
    - Zone
    - Overwrite

## Correct Cmdlets

- Get-AzDnsZone
- Test-AzDummy

## New Cmdlets

- Get-AzDnsResourceReference
- Update-AzDnsRecordSet

## Missing Cmdlets


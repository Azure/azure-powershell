---
Module Name: Az.PrivateDns
Module Guid: 8427197a-020a-404e-b7df-d66f5fd3d11c
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.privatedns
Help Version: 1.0.0.0
Locale: en-US
---

# Az.PrivateDns Module
## Description
Microsoft Azure PowerShell: PrivateDns cmdlets

## Az.PrivateDns Cmdlets
### [Get-AzPrivateDnsPrivateZone](Get-AzPrivateDnsPrivateZone.md)
Gets a Private DNS zone.
Retrieves the zone properties, but not the virtual networks links or the record sets within the zone.

### [Get-AzPrivateDnsRecordSet](Get-AzPrivateDnsRecordSet.md)
Gets a record set.

### [Get-AzPrivateDnsVirtualNetworkLink](Get-AzPrivateDnsVirtualNetworkLink.md)
Gets a virtual network link to the specified Private DNS zone.

### [New-AzPrivateDnsPrivateZone](New-AzPrivateDnsPrivateZone.md)
Creates or updates a Private DNS zone.
Does not modify Links to virtual networks or DNS records within the zone.

### [New-AzPrivateDnsRecordSet](New-AzPrivateDnsRecordSet.md)
Creates or updates a record set within a Private DNS zone.

### [New-AzPrivateDnsVirtualNetworkLink](New-AzPrivateDnsVirtualNetworkLink.md)
Creates or updates a virtual network link to the specified Private DNS zone.

### [Remove-AzPrivateDnsPrivateZone](Remove-AzPrivateDnsPrivateZone.md)
Deletes a Private DNS zone.
WARNING: All DNS records in the zone will also be deleted.
This operation cannot be undone.
Private DNS zone cannot be deleted unless all virtual network links to it are removed.

### [Remove-AzPrivateDnsRecordSet](Remove-AzPrivateDnsRecordSet.md)
Deletes a record set from a Private DNS zone.
This operation cannot be undone.

### [Remove-AzPrivateDnsVirtualNetworkLink](Remove-AzPrivateDnsVirtualNetworkLink.md)
Deletes a virtual network link to the specified Private DNS zone.
WARNING: In case of a registration virtual network, all auto-registered DNS records in the zone for the virtual network will also be deleted.
This operation cannot be undone.

### [Update-AzPrivateDnsPrivateZone](Update-AzPrivateDnsPrivateZone.md)
Updates a Private DNS zone.
Does not modify virtual network links or DNS records within the zone.

### [Update-AzPrivateDnsRecordSet](Update-AzPrivateDnsRecordSet.md)
Updates a record set within a Private DNS zone.

### [Update-AzPrivateDnsVirtualNetworkLink](Update-AzPrivateDnsVirtualNetworkLink.md)
Updates a virtual network link to the specified Private DNS zone.


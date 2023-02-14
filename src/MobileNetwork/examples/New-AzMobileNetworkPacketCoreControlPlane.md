<<<<<<< HEAD
### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

=======
### Example 1: Creates or updates a packet core control plane.
```powershell
$siteResourceId = New-AzMobileNetworkSiteResourceIdObject -Id /subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/sites/azps-mn-site

New-AzMobileNetworkPacketCoreControlPlane -Name azps-mn-pccp -ResourceGroupName azps_test_group -LocalDiagnosticAccessAuthenticationType Password -Location eastus -PlatformType AKS-HCI -Site $siteResourceId -Sku G0 -ControlPlaneAccessInterfaceIpv4Address 192.168.1.10 -ControlPlaneAccessInterfaceIpv4Gateway 192.168.1.1 -ControlPlaneAccessInterfaceIpv4Subnet 192.168.1.0/24 -ControlPlaneAccessInterfaceName N2 -CoreNetworkTechnology 5GC
```

```output
Location Name         ResourceGroupName ProvisioningState
-------- ----         ----------------- -----------------
eastus   azps-mn-pccp azps_test_group   Succeeded
```

Creates or updates a packet core control plane.
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91

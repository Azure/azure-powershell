### Example 1: Create network security perimeter link

```powershell
$remoteNsp = "/subscriptions/<SUBSCRIPTION_ID>/resourceGroups/psrg_ex/providers/Microsoft.Network/networkSecurityPerimeters/nsp7"
New-AzNetworkSecurityPerimeterLink -Name exlink3 -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp6 -AutoApprovedRemotePerimeterResourceId $remoteNsp  -LocalInboundProfile @('*') -RemoteInboundProfile @('*')
```

```output
Etag Name
---- ----
     exlink3
```

Create network security perimeter link

### Example 2: Create network security perimeter link

```powershell
$remoteNsp = "/subscriptions/<SUBSCRIPTION_ID>/resourceGroups/psrg_ex/providers/Microsoft.Network/networkSecurityPerimeters/nsp7"
New-AzNetworkSecurityPerimeterLink -Name exlink4 -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp6 -AutoApprovedRemotePerimeterResourceId $remoteNsp  -LocalInboundProfile @('*') -RemoteInboundProfile @('*')
```

```output
Etag Name
---- ----
     exlink4
```

Create network security perimeter link

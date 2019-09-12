# SETUP
# Set-AzContext -Subscription 'Azure SDK Powershell Test'
# New-AzResourceGroup -Name rgmy -Location centralus

try {
  $wan = Get-AzVirtualWan -Name vwmy -ResourceGroupName rgmy
} catch [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.RestException[Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IError]] {
  if($_.Exception.Code -eq 'NotFound') {
    $wan = New-AzVirtualWan -Name vwmy -ResourceGroupName rgmy -Location centralus
  }
}
$wan.Id

try {
  $hub = Get-AzVirtualHub -Name vhmy -ResourceGroupName rgmy
} catch [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.RestException[Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IError]] {
  if($_.Exception.Code -eq 'NotFound') {
    $hub = New-AzVirtualHub -Name vhmy -ResourceGroupName rgmy -Location centralus -AddressPrefix '10.0.1.0/24' -VirtualWanId $wan.Id
  }
}
$hub.Id

try {
  $gateway = Get-AzExpressRouteGateway -Name ergmy -ResourceGroupName rgmy
} catch [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.UndeclaredResponseException] {
  if($_.Exception.Code -eq 'NotFound') {
    $gateway = New-AzExpressRouteGateway -Name ergmy -ResourceGroupName rgmy -Location centralus -MinimumScaleUnit 2 -VirtualHubId $hub.Id
  }
}
$gateway.Id
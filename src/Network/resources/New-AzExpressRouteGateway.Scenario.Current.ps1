# SETUP
# Set-AzContext -Subscription 'Azure SDK Powershell Test'
# New-AzResourceGroup -Name rgmy -Location centralus

try {
  $wan = Get-AzVirtualWan -Name vwmy -ResourceGroupName rgmy
} catch [Microsoft.Azure.Commands.Network.Common.NetworkCloudException]] {
  if($_.Exception.InnerException.Response.StatusCode -eq 'NotFound') {
    $wan = New-AzVirtualWan -Name vwmy -ResourceGroupName rgmy -Location centralus
  }
}
$wan.Id

$hub = Get-AzVirtualHub -Name vhmy -ResourceGroupName rgmy
if(-not $hub) {
  $hub = New-AzVirtualHub -Name vhmy -ResourceGroupName rgmy -Location centralus -AddressPrefix '10.0.1.0/24' -VirtualWanId $wan.Id
}
$hub.Id

try {
  $gateway = Get-AzExpressRouteGateway -Name ergmy -ResourceGroupName rgmy
} catch [Microsoft.Azure.Commands.Network.Common.NetworkCloudException]] {
  if($_.Exception.InnerException.Response.StatusCode -eq 'NotFound') {
    $gateway = New-AzExpressRouteGateway -Name ergmy -ResourceGroupName rgmy -Location centralus -MinScaleUnits 2 -VirtualHubId $hub.Id
  }
}
$gateway.Id
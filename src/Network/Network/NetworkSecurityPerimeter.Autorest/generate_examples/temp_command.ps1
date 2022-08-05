
$GETObj = Get-AzNetworkSecurityPerimeterAssociation -Name association1 -SecurityPerimeterName nsp3 -ResourceGroupName kumarkaushal-PS-RG-1  
  $UpdateObj = Update-AzNetworkSecurityPerimeterAssociation -InputObject $GETObj -AccessMode Learning

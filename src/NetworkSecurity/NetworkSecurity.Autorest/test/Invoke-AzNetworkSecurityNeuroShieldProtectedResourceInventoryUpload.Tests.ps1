if (($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNetworkSecurityNeuroShieldProtectedResourceInventoryUpload')) {
    . (Join-Path $PSScriptRoot 'NetworkSecurity.Transport.ps1')
    Invoke-NetworkSecurityTransportTest -CmdletName 'Invoke-AzNetworkSecurityNeuroShieldProtectedResourceInventoryUpload'
}

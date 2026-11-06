if (($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkSecurityNeuroShield')) {
    . (Join-Path $PSScriptRoot 'NetworkSecurity.Transport.ps1')
    Invoke-NetworkSecurityTransportTest -CmdletName 'New-AzNetworkSecurityNeuroShield'
}

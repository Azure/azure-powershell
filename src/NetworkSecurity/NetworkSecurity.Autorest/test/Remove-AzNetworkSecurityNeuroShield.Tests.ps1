if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzNetworkSecurityNeuroShield')) {
    . (Join-Path $PSScriptRoot 'NetworkSecurity.Transport.ps1')
    Invoke-NetworkSecurityTransportTest -CmdletName 'Remove-AzNetworkSecurityNeuroShield'
}

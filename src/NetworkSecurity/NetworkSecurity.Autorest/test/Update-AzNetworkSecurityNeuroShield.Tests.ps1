if (($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkSecurityNeuroShield')) {
    . (Join-Path $PSScriptRoot 'NetworkSecurity.Transport.ps1')
    Invoke-NetworkSecurityTransportTest -CmdletName 'Update-AzNetworkSecurityNeuroShield'
}

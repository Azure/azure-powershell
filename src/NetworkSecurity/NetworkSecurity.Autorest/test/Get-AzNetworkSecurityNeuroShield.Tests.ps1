if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkSecurityNeuroShield')) {
    . (Join-Path $PSScriptRoot 'NetworkSecurity.Transport.ps1')
    Invoke-NetworkSecurityTransportTest -CmdletName 'Get-AzNetworkSecurityNeuroShield'
}

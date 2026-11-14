if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkSecurityNeuroShieldSummary')) {
    . (Join-Path $PSScriptRoot 'NetworkSecurity.Transport.ps1')
    Invoke-NetworkSecurityTransportTest -CmdletName 'Get-AzNetworkSecurityNeuroShieldSummary'
}

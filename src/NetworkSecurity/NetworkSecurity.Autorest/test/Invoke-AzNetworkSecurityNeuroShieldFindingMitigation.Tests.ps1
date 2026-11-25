if (($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNetworkSecurityNeuroShieldFindingMitigation')) {
    . (Join-Path $PSScriptRoot 'NetworkSecurity.Transport.ps1')
    Invoke-NetworkSecurityTransportTest -CmdletName 'Invoke-AzNetworkSecurityNeuroShieldFindingMitigation'
}

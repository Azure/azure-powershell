if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkSecurityNeuroShieldMitigation')) {
    . (Join-Path $PSScriptRoot 'NetworkSecurity.Transport.ps1')
    Invoke-NetworkSecurityTransportTest -CmdletName 'Get-AzNetworkSecurityNeuroShieldMitigation'
}

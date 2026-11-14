if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkSecurityNeuroShieldFinding')) {
    . (Join-Path $PSScriptRoot 'NetworkSecurity.Transport.ps1')
    Invoke-NetworkSecurityTransportTest -CmdletName 'Get-AzNetworkSecurityNeuroShieldFinding'
}

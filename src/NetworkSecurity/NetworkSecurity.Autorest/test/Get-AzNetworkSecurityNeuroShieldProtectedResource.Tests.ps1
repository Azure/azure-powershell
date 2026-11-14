if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkSecurityNeuroShieldProtectedResource')) {
    . (Join-Path $PSScriptRoot 'NetworkSecurity.Transport.ps1')
    Invoke-NetworkSecurityTransportTest -CmdletName 'Get-AzNetworkSecurityNeuroShieldProtectedResource'
}

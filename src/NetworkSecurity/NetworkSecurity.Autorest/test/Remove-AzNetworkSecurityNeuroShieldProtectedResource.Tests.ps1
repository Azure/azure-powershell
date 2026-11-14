if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzNetworkSecurityNeuroShieldProtectedResource')) {
    . (Join-Path $PSScriptRoot 'NetworkSecurity.Transport.ps1')
    Invoke-NetworkSecurityTransportTest -CmdletName 'Remove-AzNetworkSecurityNeuroShieldProtectedResource'
}

if (($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkSecurityNeuroShieldProtectedResource')) {
    . (Join-Path $PSScriptRoot 'NetworkSecurity.Transport.ps1')
    Invoke-NetworkSecurityTransportTest -CmdletName 'New-AzNetworkSecurityNeuroShieldProtectedResource'
}

if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkSecurityNeuroShieldOperationStatus')) {
    . (Join-Path $PSScriptRoot 'NetworkSecurity.Transport.ps1')
    Invoke-NetworkSecurityTransportTest -CmdletName 'Get-AzNetworkSecurityNeuroShieldOperationStatus'
}

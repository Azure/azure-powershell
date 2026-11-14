if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkSecurityOperation')) {
    . (Join-Path $PSScriptRoot 'NetworkSecurity.Transport.ps1')
    Invoke-NetworkSecurityTransportTest -CmdletName 'Get-AzNetworkSecurityOperation'
}

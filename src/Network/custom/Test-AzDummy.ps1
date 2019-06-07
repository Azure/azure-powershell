<#
.Synopsis
Dummy alias cmdlet
.Description
Dummy alias cmdlet
.Link
https://docs.microsoft.com/en-us/powershell/module/az.network/get-azoperation
#>
function Test-AzDummy {
[OutputType('Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOperation')]
[CmdletBinding(PositionalBinding=$false)]
[Alias(
    'Get-AzApplicationGatewayAuthenticationCertificate'
    ,'Get-AzApplicationGatewayBackendAddressPool'
    ,'Get-AzApplicationGatewayBackendHttpSettings'
    ,'Get-AzApplicationGatewayConnectionDraining'
    ,'Get-AzApplicationGatewayCustomError'
    ,'Get-AzApplicationGatewayFrontendPort'
    ,'Get-AzApplicationGatewayHttpListener'
    ,'Get-AzApplicationGatewayHttpListenerCustomError'
    ,'Get-AzApplicationGatewayIdentity'
    ,'Get-AzApplicationGatewayRequestRoutingRule'
    ,'Get-AzApplicationGatewayRewriteRuleSet'
    ,'Get-AzApplicationGatewaySku'
    ,'Get-AzApplicationGatewaySslCertificate'
    ,'Get-AzApplicationGatewaySslPolicy'
    ,'Get-AzApplicationGatewayTrustedRootCertificate'
    ,'Get-AzDelegation'
)]
[Microsoft.Azure.PowerShell.Cmdlets.Network.Profile('latest-2019-04-30')]
[Microsoft.Azure.PowerShell.Cmdlets.Network.Description('Dummy alias cmdlet')]
param()

process {}
}

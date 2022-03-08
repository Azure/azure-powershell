@{
  GUID = 'f9fae843-9c26-4513-9442-17f4379802bf'
  RootModule = './Az.Cdn.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Cdn cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Cdn.private.dll'
  FormatsToProcess = './Az.Cdn.format.ps1xml'
  FunctionsToExport = 'Clear-AzCdnAfdEndpointContent', 'Clear-AzCdnEndpointContent', 'Disable-AzCdnCustomDomainCustomHttps', 'Enable-AzCdnCustomDomainCustomHttps', 'Get-AzCdnAfdCustomDomain', 'Get-AzCdnAfdEndpoint', 'Get-AzCdnAfdEndpointResourceUsage', 'Get-AzCdnAfdOrigin', 'Get-AzCdnAfdOriginGroup', 'Get-AzCdnAfdOriginGroupResourceUsage', 'Get-AzCdnAfdProfileResourceUsage', 'Get-AzCdnCustomDomain', 'Get-AzCdnEdgeNode', 'Get-AzCdnEndpoint', 'Get-AzCdnEndpointResourceUsage', 'Get-AzCdnLogAnalyticLocation', 'Get-AzCdnLogAnalyticMetric', 'Get-AzCdnLogAnalyticRanking', 'Get-AzCdnLogAnalyticResource', 'Get-AzCdnLogAnalyticWafLogAnalyticMetric', 'Get-AzCdnLogAnalyticWafLogAnalyticRanking', 'Get-AzCdnManagedRuleSet', 'Get-AzCdnOrigin', 'Get-AzCdnOriginGroup', 'Get-AzCdnPolicy', 'Get-AzCdnProfile', 'Get-AzCdnProfileResourceUsage', 'Get-AzCdnProfileSupportedOptimizationType', 'Get-AzCdnResourceUsage', 'Get-AzCdnRoute', 'Get-AzCdnRule', 'Get-AzCdnRuleSet', 'Get-AzCdnRuleSetResourceUsage', 'Get-AzCdnSecret', 'Get-AzCdnSecurityPolicy', 'Get-AzFrontDoorCdnProfile', 'Import-AzCdnEndpointContent', 'Invoke-AzCdnSecretValidate', 'New-AzCdnAfdCustomDomain', 'New-AzCdnAfdEndpoint', 'New-AzCdnAfdOrigin', 'New-AzCdnAfdOriginGroup', 'New-AzCdnCustomDomain', 'New-AzCdnEndpoint', 'New-AzCdnOrigin', 'New-AzCdnOriginGroup', 'New-AzCdnPolicy', 'New-AzCdnProfileSsoUri', 'New-AzCdnRoute', 'New-AzCdnRule', 'New-AzCdnSecret', 'New-AzCdnSecurityPolicy', 'New-AzFrontDoorCdnProfile', 'Remove-AzCdnAfdCustomDomain', 'Remove-AzCdnAfdEndpoint', 'Remove-AzCdnAfdOrigin', 'Remove-AzCdnAfdOriginGroup', 'Remove-AzCdnCustomDomain', 'Remove-AzCdnEndpoint', 'Remove-AzCdnOrigin', 'Remove-AzCdnOriginGroup', 'Remove-AzCdnPolicy', 'Remove-AzCdnRoute', 'Remove-AzCdnRule', 'Remove-AzCdnRuleSet', 'Remove-AzCdnSecret', 'Remove-AzCdnSecurityPolicy', 'Remove-AzFrontDoorCdnProfile', 'Start-AzCdnEndpoint', 'Stop-AzCdnEndpoint', 'Test-AzCdnAfdEndpointCustomDomain', 'Test-AzCdnAfdProfileHostNameAvailability', 'Test-AzCdnEndpointCustomDomain', 'Test-AzCdnEndpointNameAvailability', 'Test-AzCdnNameAvailability', 'Test-AzCdnProbe', 'Update-AzCdnAfdCustomDomain', 'Update-AzCdnAfdCustomDomainValidationToken', 'Update-AzCdnAfdEndpoint', 'Update-AzCdnAfdOrigin', 'Update-AzCdnAfdOriginGroup', 'Update-AzCdnEndpoint', 'Update-AzCdnOrigin', 'Update-AzCdnOriginGroup', 'Update-AzCdnPolicy', 'Update-AzCdnRoute', 'Update-AzCdnRule', 'Update-AzCdnSecurityPolicy', 'Update-AzFrontDoorCdnProfile', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Cdn'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

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
  FunctionsToExport = 'Clear-AzCdnEndpointContent', 'Clear-AzFrontDoorCdnEndpointContent', 'Disable-AzCdnCustomDomainCustomHttps', 'Enable-AzCdnCustomDomainCustomHttps', 'Get-AzCdnCustomDomain', 'Get-AzCdnEdgeNode', 'Get-AzCdnEndpoint', 'Get-AzCdnEndpointResourceUsage', 'Get-AzCdnLogAnalyticLocation', 'Get-AzCdnLogAnalyticMetric', 'Get-AzCdnLogAnalyticRanking', 'Get-AzCdnLogAnalyticResource', 'Get-AzCdnLogAnalyticWafLogAnalyticMetric', 'Get-AzCdnLogAnalyticWafLogAnalyticRanking', 'Get-AzCdnManagedRuleSet', 'Get-AzCdnOrigin', 'Get-AzCdnOriginGroup', 'Get-AzCdnPolicy', 'Get-AzCdnProfile', 'Get-AzCdnProfileResourceUsage', 'Get-AzCdnProfileSupportedOptimizationType', 'Get-AzCdnResourceUsage', 'Get-AzFrontDoorCdnCustomDomain', 'Get-AzFrontDoorCdnEndpoint', 'Get-AzFrontDoorCdnEndpointResourceUsage', 'Get-AzFrontDoorCdnOrigin', 'Get-AzFrontDoorCdnOriginGroup', 'Get-AzFrontDoorCdnOriginGroupResourceUsage', 'Get-AzFrontDoorCdnProfile', 'Get-AzFrontDoorCdnProfileResourceUsage', 'Get-AzFrontDoorCdnRoute', 'Get-AzFrontDoorCdnRule', 'Get-AzFrontDoorCdnRuleSet', 'Get-AzFrontDoorCdnRuleSetResourceUsage', 'Get-AzFrontDoorCdnSecret', 'Get-AzFrontDoorCdnSecurityPolicy', 'Import-AzCdnEndpointContent', 'Invoke-AzCdnSecretValidate', 'New-AzCdnCustomDomain', 'New-AzCdnEndpoint', 'New-AzCdnOrigin', 'New-AzCdnOriginGroup', 'New-AzCdnPolicy', 'New-AzCdnProfile', 'New-AzCdnProfileSsoUri', 'New-AzFrontDoorCdnCustomDomain', 'New-AzFrontDoorCdnEndpoint', 'New-AzFrontDoorCdnOrigin', 'New-AzFrontDoorCdnOriginGroup', 'New-AzFrontDoorCdnProfile', 'New-AzFrontDoorCdnRoute', 'New-AzFrontDoorCdnRule', 'New-AzFrontDoorCdnRuleSet', 'New-AzFrontDoorCdnSecret', 'New-AzFrontDoorCdnSecurityPolicy', 'Remove-AzCdnCustomDomain', 'Remove-AzCdnEndpoint', 'Remove-AzCdnOrigin', 'Remove-AzCdnOriginGroup', 'Remove-AzCdnPolicy', 'Remove-AzCdnProfile', 'Remove-AzFrontDoorCdnCustomDomain', 'Remove-AzFrontDoorCdnEndpoint', 'Remove-AzFrontDoorCdnOrigin', 'Remove-AzFrontDoorCdnOriginGroup', 'Remove-AzFrontDoorCdnProfile', 'Remove-AzFrontDoorCdnRoute', 'Remove-AzFrontDoorCdnRule', 'Remove-AzFrontDoorCdnRuleSet', 'Remove-AzFrontDoorCdnSecret', 'Remove-AzFrontDoorCdnSecurityPolicy', 'Start-AzCdnEndpoint', 'Stop-AzCdnEndpoint', 'Test-AzCdnEndpointCustomDomain', 'Test-AzCdnEndpointNameAvailability', 'Test-AzCdnNameAvailability', 'Test-AzCdnProbe', 'Test-AzFrontDoorCdnEndpointCustomDomain', 'Test-AzFrontDoorCdnProfileHostNameAvailability', 'Update-AzCdnEndpoint', 'Update-AzCdnOrigin', 'Update-AzCdnOriginGroup', 'Update-AzCdnPolicy', 'Update-AzCdnProfile', 'Update-AzFrontDoorCdnCustomDomain', 'Update-AzFrontDoorCdnCustomDomainValidationToken', 'Update-AzFrontDoorCdnEndpoint', 'Update-AzFrontDoorCdnOrigin', 'Update-AzFrontDoorCdnOriginGroup', 'Update-AzFrontDoorCdnProfile', 'Update-AzFrontDoorCdnRoute', 'Update-AzFrontDoorCdnRule', 'Update-AzFrontDoorCdnSecurityPolicy', '*'
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

@{
  GUID = 'f781d2f9-c4c6-4d0b-bcfb-26973544c41d'
  RootModule = './Az.MarketplaceOrdering.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: MarketplaceOrdering cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.MarketplaceOrdering.private.dll'
  FormatsToProcess = './Az.MarketplaceOrdering.format.ps1xml'
  FunctionsToExport = 'Get-AzMarketplaceTerms', 'Invoke-AzMarketplaceSignTerms', 'Set-AzMarketplaceTerms', 'Stop-AzMarketplaceTerms', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'MarketplaceOrdering'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

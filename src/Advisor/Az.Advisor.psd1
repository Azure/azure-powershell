@{
  GUID = '6828a285-3916-4785-a754-9313c53b910f'
  RootModule = './Az.Advisor.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Advisor cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Advisor.private.dll'
  FormatsToProcess = './Az.Advisor.format.ps1xml'
  FunctionsToExport = 'Disable-AzAdvisorRecommendation', 'Enable-AzAdvisorRecommendation', 'Get-AzAdvisorConfiguration', 'Get-AzAdvisorRecommendation', 'Set-AzAdvisorConfiguration', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Advisor'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

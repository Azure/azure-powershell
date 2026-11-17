@{
  GUID = '7bd59be1-754b-4ed4-9f31-f425c7cc2bbb'
  RootModule = './Az.AIInfraOptimization.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: AIInfraOptimization cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.AIInfraOptimization.private.dll'
  FormatsToProcess = './Az.AIInfraOptimization.format.ps1xml'
  FunctionsToExport = 'Get-AzAIInfraOptimizationVMSkuRecommendation'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'AIInfraOptimization'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

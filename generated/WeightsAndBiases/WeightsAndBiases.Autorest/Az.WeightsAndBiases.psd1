@{
  GUID = 'f5c947b7-6a8f-45ec-9b2f-0e2cede0cc39'
  RootModule = './Az.WeightsAndBiases.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: WeightsAndBiases cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.WeightsAndBiases.private.dll'
  FormatsToProcess = './Az.WeightsAndBiases.format.ps1xml'
  FunctionsToExport = 'Get-AzWeightsAndBiasesInstance'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'WeightsAndBiases'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

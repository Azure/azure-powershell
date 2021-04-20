@{
  GUID = 'b966b775-aa46-4ceb-8b5e-cd8bdc1052e9'
  RootModule = './Az.Communication.psm1'
  ModuleVersion = '1.0.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Communication cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Communication.private.dll'
  FormatsToProcess = './Az.Communication.format.ps1xml'
  FunctionsToExport = 'Get-AzCommunicationService', 'Get-AzCommunicationServiceKey', 'New-AzCommunicationService', 'New-AzCommunicationServiceKey', 'Remove-AzCommunicationService', 'Test-AzCommunicationServiceNameAvailability', 'Update-AzCommunicationService', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Communication'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

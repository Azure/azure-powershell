@{
  GUID = '2104c31d-8a79-4ea7-9485-2fe25d5c97be'
  RootModule = './Az.VoiceServices.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: VoiceServices cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.VoiceServices.private.dll'
  FormatsToProcess = './Az.VoiceServices.format.ps1xml'
  FunctionsToExport = 'Get-AzVoiceServicesCommunicationsGateway', 'Get-AzVoiceServicesCommunicationsTestLine', 'New-AzVoiceServicesCommunicationsGateway', 'New-AzVoiceServicesCommunicationsGatewayServiceRegionObject', 'New-AzVoiceServicesCommunicationsTestLine', 'Remove-AzVoiceServicesCommunicationsGateway', 'Remove-AzVoiceServicesCommunicationsTestLine', 'Test-AzVoiceServicesNameAvailability', 'Update-AzVoiceServicesCommunicationsGateway', 'Update-AzVoiceServicesCommunicationsTestLine', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'VoiceServices'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

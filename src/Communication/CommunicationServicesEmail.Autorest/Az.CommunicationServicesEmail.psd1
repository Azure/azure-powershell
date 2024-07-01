@{
  GUID = '752c8cb4-cb71-4ae6-bcdc-62bc691c2529'
  RootModule = './Az.CommunicationServicesEmail.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: CommunicationServicesEmail cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.CommunicationServicesEmail.private.dll'
  FormatsToProcess = './Az.CommunicationServicesEmail.format.ps1xml'
  FunctionsToExport = 'Get-AzCommunicationServicesEmailSendResult', 'Send-AzCommunicationServicesEmail'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'CommunicationServicesEmail'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

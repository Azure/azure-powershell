@{
  GUID = '9391b75f-d056-4cf6-adee-e3b40204ec22'
  RootModule = './Az.MongoDB.psm1'
  ModuleVersion = '1.0.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: MongoDb cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.MongoDB.private.dll'
  FormatsToProcess = './Az.MongoDB.format.ps1xml'
  FunctionsToExport = 'Get-AzMongoDBOrganization', 'New-AzMongoDBOrganization', 'Remove-AzMongoDBOrganization'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'MongoDb'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

@{
  GUID = 'b532faf0-0d23-401e-9ca0-acaf561865ca'
  RootModule = './Az.ADDomainServices.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: AdDomainServices cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ADDomainServices.private.dll'
  FormatsToProcess = './Az.ADDomainServices.format.ps1xml'
  FunctionsToExport = 'Get-AzADDomainService', 'New-AzADDomainService', 'New-AzADDomainServiceDomainSecuritySettingObject', 'New-AzADDomainServiceLdapsSettingObject', 'New-AzADDomainServiceNotificationSettingObject', 'New-AzADDomainServiceReplicaSetObject', 'New-AzADDomainServiceResourceForestSettingObject', 'Remove-AzADDomainService', 'Update-AzADDomainService', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'AdDomainServices'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

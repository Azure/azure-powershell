@{
  GUID = 'bd26548c-ac2c-4447-9d5d-2e4d8c622495'
  RootModule = './Az.Quota.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Quota cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Quota.private.dll'
  FormatsToProcess = './Az.Quota.format.ps1xml'
  FunctionsToExport = 'Get-AzQuota', 'Get-AzQuotaOperation', 'Get-AzQuotaRequestStatus', 'Get-AzQuotaUsage', 'New-AzQuota', 'New-AzQuotaLimitObject', 'Update-AzQuota'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Quota'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

@{
  GUID = '8184d481-1cae-4edf-b582-c2071460c705'
  RootModule = './Az.QuotaExtensionApi.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: QuotaExtensionApi cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.QuotaExtensionApi.private.dll'
  FormatsToProcess = './Az.QuotaExtensionApi.format.ps1xml'
  FunctionsToExport = 'Get-AzQuotaExtensionApiQuota', 'Get-AzQuotaExtensionApiQuotaOperation', 'Get-AzQuotaExtensionApiQuotaRequestStatus', 'Get-AzQuotaExtensionApiUsage', 'New-AzQuotaExtensionApiQuota', 'Update-AzQuotaExtensionApiQuota', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'QuotaExtensionApi'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

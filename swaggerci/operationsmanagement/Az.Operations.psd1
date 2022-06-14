@{
  GUID = '6fef01a0-fc0f-40a2-9f73-da797719b5a3'
  RootModule = './Az.Operations.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Operations cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Operations.private.dll'
  FormatsToProcess = './Az.Operations.format.ps1xml'
  FunctionsToExport = 'Get-AzOperationsManagementAssociation', 'Get-AzOperationsManagementConfiguration', 'Get-AzOperationsSolution', 'New-AzOperationsManagementAssociation', 'New-AzOperationsManagementConfiguration', 'New-AzOperationsSolution', 'Remove-AzOperationsManagementAssociation', 'Remove-AzOperationsManagementConfiguration', 'Remove-AzOperationsSolution', 'Update-AzOperationsSolution', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Operations'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

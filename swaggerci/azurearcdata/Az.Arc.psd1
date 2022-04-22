@{
  GUID = 'c40740e8-0fcf-4b72-bf34-023592ffa7e5'
  RootModule = './Az.Arc.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Arc cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Arc.private.dll'
  FormatsToProcess = './Az.Arc.format.ps1xml'
  FunctionsToExport = 'Get-AzArcActiveDirectoryConnector', 'Get-AzArcDataController', 'Get-AzArcPostgreInstance', 'Get-AzArcPostgresInstance', 'Get-AzArcSqlManagedInstance', 'Get-AzArcSqlServerInstance', 'New-AzArcActiveDirectoryConnector', 'New-AzArcPostgresInstance', 'New-AzArcSqlManagedInstance', 'New-AzArcSqlServerInstance', 'Remove-AzArcActiveDirectoryConnector', 'Remove-AzArcDataController', 'Remove-AzArcPostgresInstance', 'Remove-AzArcSqlManagedInstance', 'Remove-AzArcSqlServerInstance', 'Update-AzArcDataController', 'Update-AzArcPostgresInstance', 'Update-AzArcSqlManagedInstance', 'Update-AzArcSqlServerInstance', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Arc'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

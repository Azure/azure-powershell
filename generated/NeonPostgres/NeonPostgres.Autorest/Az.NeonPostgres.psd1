@{
  GUID = 'b3e01e02-1629-4884-8793-ec1494a14142'
  RootModule = './Az.NeonPostgres.psm1'
  ModuleVersion = '0.2.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: NeonPostgres cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.NeonPostgres.private.dll'
  FormatsToProcess = './Az.NeonPostgres.format.ps1xml'
  FunctionsToExport = 'Get-AzNeonPostgresBranch', 'Get-AzNeonPostgresCompute', 'Get-AzNeonPostgresEndpoint', 'Get-AzNeonPostgresNeonDatabase', 'Get-AzNeonPostgresNeonRole', 'Get-AzNeonPostgresOrganization', 'Get-AzNeonPostgresProject', 'Get-AzNeonPostgresProjectConnectionUri', 'New-AzNeonPostgresBranch', 'New-AzNeonPostgresOrganization', 'New-AzNeonPostgresProject', 'Remove-AzNeonPostgresBranch', 'Remove-AzNeonPostgresOrganization', 'Remove-AzNeonPostgresProject', 'Update-AzNeonPostgresBranch', 'Update-AzNeonPostgresOrganization', 'Update-AzNeonPostgresProject'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'NeonPostgres'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

@{
  GUID = '47d0d6ff-e7e2-4560-9459-a2b6b643236c'
  RootModule = './Az.MigrateV2.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: MigrateV2 cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.MigrateV2.private.dll'
  FormatsToProcess = './Az.MigrateV2.format.ps1xml'
  FunctionsToExport = 'Get-AzMigrateV2AssessedMachine', 'Get-AzMigrateV2Assessment', 'Get-AzMigrateV2AssessmentReportDownloadUrl', 'Get-AzMigrateV2Group', 'Get-AzMigrateV2HyperVCollector', 'Get-AzMigrateV2ImportCollector', 'Get-AzMigrateV2Machine', 'Get-AzMigrateV2PrivateEndpointConnection', 'Get-AzMigrateV2PrivateLinkResource', 'Get-AzMigrateV2Project', 'Get-AzMigrateV2ProjectAssessmentOption', 'Get-AzMigrateV2ServerCollector', 'Get-AzMigrateV2VMwareCollector', 'Invoke-AzMigrateV2AssessmentProjectOption', 'New-AzMigrateV2Assessment', 'New-AzMigrateV2Group', 'New-AzMigrateV2HyperVCollector', 'New-AzMigrateV2ImportCollector', 'New-AzMigrateV2Project', 'New-AzMigrateV2ServerCollector', 'New-AzMigrateV2VMwareCollector', 'Remove-AzMigrateV2Assessment', 'Remove-AzMigrateV2Group', 'Remove-AzMigrateV2HyperVCollector', 'Remove-AzMigrateV2ImportCollector', 'Remove-AzMigrateV2PrivateEndpointConnection', 'Remove-AzMigrateV2Project', 'Remove-AzMigrateV2ServerCollector', 'Remove-AzMigrateV2VMwareCollector', 'Update-AzMigrateV2GroupMachine', 'Update-AzMigrateV2Project', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'MigrateV2'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

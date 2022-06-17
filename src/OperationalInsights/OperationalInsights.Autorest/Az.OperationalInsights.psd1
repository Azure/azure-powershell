@{
  GUID = 'c4733603-3414-41cb-b2f6-2e53c59925f4'
  RootModule = './Az.OperationalInsights.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: OperationalInsights cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.OperationalInsights.private.dll'
  FormatsToProcess = './Az.OperationalInsights.format.ps1xml'
  FunctionsToExport = 'Get-AzOperationalInsightsDeletedWorkspace', 'Get-AzOperationalInsightsTable', 'Get-AzOperationalInsightsWorkspace', 'Move-AzOperationalInsightsTable', 'New-AzOperationalInsightsTable', 'New-AzOperationalInsightsTableColumnObject', 'New-AzOperationalInsightsWorkspace', 'Remove-AzOperationalInsightsTable', 'Remove-AzOperationalInsightsWorkspace', 'Update-AzOperationalInsightsTable', 'Update-AzOperationalInsightsWorkspace', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'OperationalInsights'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

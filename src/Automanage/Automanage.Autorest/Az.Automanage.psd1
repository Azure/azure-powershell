@{
  GUID = 'b573b797-567a-4f0d-8ba3-6a447bed6278'
  RootModule = './Az.Automanage.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Automanage cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Automanage.private.dll'
  FormatsToProcess = './Az.Automanage.format.ps1xml'
  FunctionsToExport = 'Get-AzAutomanageBestPractice', 'Get-AzAutomanageConfigProfile', 'Get-AzAutomanageConfigProfileAssignment', 'Get-AzAutomanageConfigProfileHciAssignment', 'Get-AzAutomanageConfigProfileHcrpAssignment', 'Get-AzAutomanageHciReport', 'Get-AzAutomanageHcrpReport', 'Get-AzAutomanageReport', 'New-AzAutomanageConfigProfile', 'New-AzAutomanageConfigProfileAssignment', 'New-AzAutomanageConfigProfileHciAssignment', 'New-AzAutomanageConfigProfileHcrpAssignment', 'Remove-AzAutomanageConfigProfile', 'Remove-AzAutomanageConfigProfileAssignment', 'Remove-AzAutomanageConfigProfileHciAssignment', 'Remove-AzAutomanageConfigProfileHcrpAssignment', 'Update-AzAutomanageConfigProfile', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Automanage'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

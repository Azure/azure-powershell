@{
  GUID = 'fe9cdcde-fc77-437e-865a-8640b50f463a'
  RootModule = 'MSGraph.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: MSGraph cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Resources.MSGraph.private.dll'
  FormatsToProcess = 'MSGraph.format.ps1xml'
  FunctionsToExport = 'Get-AzMgApplication', 'Get-AzMgGroup', 'Get-AzMgServicePrincipal', 'Get-AzMgUser', 'New-AzMgApplication', 'New-AzMgGroup', 'New-AzMgServicePrincipal', 'New-AzMgUser', 'Remove-AzMgApplication', 'Remove-AzMgGroup', 'Remove-AzMgServicePrincipal', 'Remove-AzMgUser', 'Update-AzMgApplication', 'Update-AzMgGroup', 'Update-AzMgServicePrincipal', 'Update-AzMgUser', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'MSGraph'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

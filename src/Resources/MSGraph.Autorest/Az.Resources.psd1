@{
  GUID = '26500ceb-dbf8-4aae-b866-5fa86b3ec272'
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
  FunctionsToExport = 'Add-AzADAppPermission', 'Add-AzADGroupMember', 'Get-AzADAppCredential', 'Get-AzADApplication', 'Get-AzADAppPermission', 'Get-AzADGroup', 'Get-AzADGroupMember', 'Get-AzADServicePrincipal', 'Get-AzADSpCredential', 'Get-AzADUser', 'New-AzADAppCredential', 'New-AzADApplication', 'New-AzADGroup', 'New-AzADServicePrincipal', 'New-AzADSpCredential', 'New-AzADUser', 'Remove-AzADAppCredential', 'Remove-AzADApplication', 'Remove-AzADAppPermission', 'Remove-AzADGroup', 'Remove-AzADGroupMember', 'Remove-AzADServicePrincipal', 'Remove-AzADSpCredential', 'Remove-AzADUser', 'Update-AzADApplication', 'Update-AzADServicePrincipal', 'Update-AzADUser', '*'
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

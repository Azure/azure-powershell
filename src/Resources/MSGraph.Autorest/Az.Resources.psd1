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
  FunctionsToExport = 'Add-AzAdAppPermission', 'Add-AzAdGroupMember', 'Get-AzAdAppCredential', 'Get-AzAdApplication', 'Get-AzAdAppPermission', 'Get-AzAdGroup', 'Get-AzAdGroupMember', 'Get-AzAdServicePrincipal', 'Get-AzAdSpCredential', 'Get-AzAdUser', 'Get-AzAdUserSigned', 'New-AzAdAppCredential', 'New-AzAdApplication', 'New-AzAdGroup', 'New-AzAdServicePrincipal', 'New-AzAdSpCredential', 'New-AzAdUser', 'Remove-AzAdAppCredential', 'Remove-AzAdApplication', 'Remove-AzAdAppPermission', 'Remove-AzAdGroup', 'Remove-AzAdGroupMember', 'Remove-AzAdServicePrincipal', 'Remove-AzAdSpCredential', 'Remove-AzAdUser', 'Update-AzAdApplication', 'Update-AzAdServicePrincipal', 'Update-AzAdUser', '*'
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

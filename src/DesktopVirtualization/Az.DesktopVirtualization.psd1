@{
  GUID = '4cbade8e-48e0-42f8-a847-7872d0006d54'
  RootModule = './Az.DesktopVirtualization.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DesktopVirtualization cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DesktopVirtualization.private.dll'
  RequiredModules = @(@{ModuleName = 'Az.Accounts'; ModuleVersion = '1.8.0'; })
  FormatsToProcess = './Az.DesktopVirtualization.format.ps1xml'
  FunctionsToExport = 'Disconnect-AzWvdUserSession', 'Get-AzWvdApplication', 'Get-AzWvdApplicationGroup', 'Get-AzWvdDesktop', 'Get-AzWvdHostPool', 'Get-AzWvdRegistrationInfo', 'Get-AzWvdSessionHost', 'Get-AzWvdStartMenuItem', 'Get-AzWvdUserSession', 'Get-AzWvdWorkspace', 'New-AzWvdApplication', 'New-AzWvdApplicationGroup', 'New-AzWvdHostPool', 'New-AzWvdRegistrationInfo', 'New-AzWvdWorkspace', 'Register-AzWvdApplicationGroup', 'Remove-AzWvdApplication', 'Remove-AzWvdApplicationGroup', 'Remove-AzWvdHostPool', 'Remove-AzWvdRegistrationInfo', 'Remove-AzWvdSessionHost', 'Remove-AzWvdUserSession', 'Remove-AzWvdWorkspace', 'Send-AzWvdUserSessionMessage', 'Unregister-AzWvdApplicationGroup', 'Update-AzWvdApplication', 'Update-AzWvdApplicationGroup', 'Update-AzWvdDesktop', 'Update-AzWvdHostPool', 'Update-AzWvdSessionHost', 'Update-AzWvdWorkspace', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DesktopVirtualization'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

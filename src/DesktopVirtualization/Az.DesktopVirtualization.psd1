@{
  GUID = 'c78eb738-b339-4296-8c9f-13ef28817c3c'
  RootModule = './Az.DesktopVirtualization.psm1'
  ModuleVersion = '2.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DesktopVirtualization cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DesktopVirtualization.private.dll'
  FormatsToProcess = './Az.DesktopVirtualization.format.ps1xml'
  FunctionsToExport = 'Disconnect-AzWvdUserSession', 'Expand-AzWvdMsixImage', 'Get-AzWvdApplication', 'Get-AzWvdApplicationGroup', 'Get-AzWvdDesktop', 'Get-AzWvdHostPool', 'Get-AzWvdHostPoolRegistrationToken', 'Get-AzWvdMsixPackage', 'Get-AzWvdRegistrationInfo', 'Get-AzWvdScalingPlan', 'Get-AzWvdScalingPlanPooledSchedule', 'Get-AzWvdSessionHost', 'Get-AzWvdStartMenuItem', 'Get-AzWvdUserSession', 'Get-AzWvdWorkspace', 'New-AzWvdApplication', 'New-AzWvdApplicationGroup', 'New-AzWvdHostPool', 'New-AzWvdMsixPackage', 'New-AzWvdRegistrationInfo', 'New-AzWvdScalingPlan', 'New-AzWvdScalingPlanPooledSchedule', 'New-AzWvdWorkspace', 'Register-AzWvdApplicationGroup', 'Remove-AzWvdApplication', 'Remove-AzWvdApplicationGroup', 'Remove-AzWvdHostPool', 'Remove-AzWvdMsixPackage', 'Remove-AzWvdRegistrationInfo', 'Remove-AzWvdScalingPlan', 'Remove-AzWvdScalingPlanPooledSchedule', 'Remove-AzWvdSessionHost', 'Remove-AzWvdUserSession', 'Remove-AzWvdWorkspace', 'Send-AzWvdUserSessionMessage', 'Unregister-AzWvdApplicationGroup', 'Update-AzWvdApplication', 'Update-AzWvdApplicationGroup', 'Update-AzWvdDesktop', 'Update-AzWvdHostPool', 'Update-AzWvdMsixPackage', 'Update-AzWvdScalingPlan', 'Update-AzWvdScalingPlanPooledSchedule', 'Update-AzWvdSessionHost', 'Update-AzWvdWorkspace', '*'
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

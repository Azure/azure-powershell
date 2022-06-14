@{
  GUID = 'b97c7da0-deaf-4198-9219-74404f834b5f'
  RootModule = './Az.IoTSecurity.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: IoTSecurity cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.IoTSecurity.private.dll'
  FormatsToProcess = './Az.IoTSecurity.format.ps1xml'
  FunctionsToExport = 'Get-AzIoTSecurityDefenderSetting', 'Get-AzIoTSecurityDevice', 'Get-AzIoTSecurityDeviceGroup', 'Get-AzIoTSecurityLocation', 'Get-AzIoTSecurityOnPremiseSensor', 'Get-AzIoTSecuritySensor', 'Get-AzIoTSecuritySite', 'Invoke-AzIoTSecurityDownloadDefenderSettingManagerActivation', 'Invoke-AzIoTSecurityDownloadOnPremiseSensorActivation', 'Invoke-AzIoTSecurityDownloadOnPremiseSensorResetPassword', 'Invoke-AzIoTSecurityDownloadSensorActivation', 'Invoke-AzIoTSecurityDownloadSensorResetPassword', 'Invoke-AzIoTSecurityPackageDefenderSettingDownload', 'New-AzIoTSecurityDefenderSetting', 'New-AzIoTSecurityDeviceGroup', 'New-AzIoTSecuritySensor', 'New-AzIoTSecuritySite', 'Remove-AzIoTSecurityDefenderSetting', 'Remove-AzIoTSecurityDeviceGroup', 'Remove-AzIoTSecurityOnPremiseSensor', 'Remove-AzIoTSecuritySensor', 'Remove-AzIoTSecuritySite', 'Start-AzIoTSecuritySensorTiPackageUpdate', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'IoTSecurity'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

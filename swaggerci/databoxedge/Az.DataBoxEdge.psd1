@{
  GUID = '9b726635-8457-4844-b20a-42443e9f5811'
  RootModule = './Az.DataBoxEdge.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DataBoxEdge cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DataBoxEdge.private.dll'
  FormatsToProcess = './Az.DataBoxEdge.format.ps1xml'
  FunctionsToExport = 'Get-AzDataBoxEdgeAddon', 'Get-AzDataBoxEdgeAlert', 'Get-AzDataBoxEdgeAvailableSku', 'Get-AzDataBoxEdgeBandwidthSchedule', 'Get-AzDataBoxEdgeContainer', 'Get-AzDataBoxEdgeDevice', 'Get-AzDataBoxEdgeDeviceCapacityInfoDeviceCapacityInfo', 'Get-AzDataBoxEdgeDeviceExtendedInformation', 'Get-AzDataBoxEdgeDeviceNetworkSetting', 'Get-AzDataBoxEdgeDeviceUpdateSummary', 'Get-AzDataBoxEdgeDiagnosticSettingDiagnosticProactiveLogCollectionSetting', 'Get-AzDataBoxEdgeDiagnosticSettingDiagnosticRemoteSupportSetting', 'Get-AzDataBoxEdgeJob', 'Get-AzDataBoxEdgeMonitoringConfig', 'Get-AzDataBoxEdgeNode', 'Get-AzDataBoxEdgeOperationsStatus', 'Get-AzDataBoxEdgeOrder', 'Get-AzDataBoxEdgeOrderDcAccessCode', 'Get-AzDataBoxEdgeRole', 'Get-AzDataBoxEdgeShare', 'Get-AzDataBoxEdgeStorageAccount', 'Get-AzDataBoxEdgeStorageAccountCredentials', 'Get-AzDataBoxEdgeTrigger', 'Get-AzDataBoxEdgeUser', 'Install-AzDataBoxEdgeDeviceUpdate', 'Invoke-AzDataBoxEdgeDownloadDeviceUpdate', 'Invoke-AzDataBoxEdgeScanDevice', 'Invoke-AzDataBoxEdgeUploadDeviceCertificate', 'New-AzDataBoxEdgeAddon', 'New-AzDataBoxEdgeBandwidthSchedule', 'New-AzDataBoxEdgeContainer', 'New-AzDataBoxEdgeDevice', 'New-AzDataBoxEdgeDeviceCertificate', 'New-AzDataBoxEdgeDeviceSecuritySetting', 'New-AzDataBoxEdgeMonitoringConfig', 'New-AzDataBoxEdgeOrder', 'New-AzDataBoxEdgeRole', 'New-AzDataBoxEdgeShare', 'New-AzDataBoxEdgeStorageAccount', 'New-AzDataBoxEdgeStorageAccountCredentials', 'New-AzDataBoxEdgeTrigger', 'New-AzDataBoxEdgeUser', 'Remove-AzDataBoxEdgeAddon', 'Remove-AzDataBoxEdgeBandwidthSchedule', 'Remove-AzDataBoxEdgeContainer', 'Remove-AzDataBoxEdgeDevice', 'Remove-AzDataBoxEdgeMonitoringConfig', 'Remove-AzDataBoxEdgeOrder', 'Remove-AzDataBoxEdgeRole', 'Remove-AzDataBoxEdgeShare', 'Remove-AzDataBoxEdgeStorageAccount', 'Remove-AzDataBoxEdgeStorageAccountCredentials', 'Remove-AzDataBoxEdgeTrigger', 'Remove-AzDataBoxEdgeUser', 'Start-AzDataBoxEdgeSupportPackage', 'Test-AzDataBoxEdgeDeviceCapacityCheckResourceCreationFeasibility', 'Update-AzDataBoxEdgeContainer', 'Update-AzDataBoxEdgeDevice', 'Update-AzDataBoxEdgeDeviceExtendedInformation', 'Update-AzDataBoxEdgeDeviceSecuritySetting', 'Update-AzDataBoxEdgeShare', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DataBoxEdge'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

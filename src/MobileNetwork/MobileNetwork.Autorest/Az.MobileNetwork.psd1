@{
  GUID = '11f61d2d-3318-4e19-8917-0f0bd2cc78c7'
  RootModule = './Az.MobileNetwork.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: MobileNetwork cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.MobileNetwork.private.dll'
  FormatsToProcess = './Az.MobileNetwork.format.ps1xml'
  FunctionsToExport = 'Deploy-AzMobileNetworkReinstallPacketCoreControlPlane', 'Deploy-AzMobileNetworkRollbackPacketCoreControlPlane', 'Get-AzMobileNetwork', 'Get-AzMobileNetworkAttachedDataNetwork', 'Get-AzMobileNetworkDataNetwork', 'Get-AzMobileNetworkPacketCoreControlPlane', 'Get-AzMobileNetworkPacketCoreControlPlaneVersion', 'Get-AzMobileNetworkPacketCoreDataPlane', 'Get-AzMobileNetworkService', 'Get-AzMobileNetworkSim', 'Get-AzMobileNetworkSimGroup', 'Get-AzMobileNetworkSimPolicy', 'Get-AzMobileNetworkSite', 'Get-AzMobileNetworkSlice', 'New-AzMobileNetwork', 'New-AzMobileNetworkAttachedDataNetwork', 'New-AzMobileNetworkDataNetwork', 'New-AzMobileNetworkDataNetworkConfigurationObject', 'New-AzMobileNetworkPacketCoreControlPlane', 'New-AzMobileNetworkPacketCoreDataPlane', 'New-AzMobileNetworkPccRuleConfigurationObject', 'New-AzMobileNetworkService', 'New-AzMobileNetworkServiceDataFlowTemplateObject', 'New-AzMobileNetworkServiceResourceIdObject', 'New-AzMobileNetworkSim', 'New-AzMobileNetworkSimGroup', 'New-AzMobileNetworkSimPolicy', 'New-AzMobileNetworkSimStaticIPPropertiesObject', 'New-AzMobileNetworkSite', 'New-AzMobileNetworkSiteResourceIdObject', 'New-AzMobileNetworkSlice', 'New-AzMobileNetworkSliceConfigurationObject', 'Remove-AzMobileNetwork', 'Remove-AzMobileNetworkAttachedDataNetwork', 'Remove-AzMobileNetworkBulkSimDelete', 'Remove-AzMobileNetworkDataNetwork', 'Remove-AzMobileNetworkPacketCoreControlPlane', 'Remove-AzMobileNetworkPacketCoreDataPlane', 'Remove-AzMobileNetworkService', 'Remove-AzMobileNetworkSim', 'Remove-AzMobileNetworkSimGroup', 'Remove-AzMobileNetworkSimPolicy', 'Remove-AzMobileNetworkSite', 'Remove-AzMobileNetworkSlice', 'Trace-AzMobileNetworkCollectPacketCoreControlPlaneDiagnosticPackage', 'Update-AzMobileNetwork', 'Update-AzMobileNetworkAttachedDataNetwork', 'Update-AzMobileNetworkBulkSimUpload', 'Update-AzMobileNetworkBulkSimUploadEncrypted', 'Update-AzMobileNetworkDataNetwork', 'Update-AzMobileNetworkPacketCoreControlPlane', 'Update-AzMobileNetworkPacketCoreDataPlane', 'Update-AzMobileNetworkService', 'Update-AzMobileNetworkSimGroup', 'Update-AzMobileNetworkSimPolicy', 'Update-AzMobileNetworkSite', 'Update-AzMobileNetworkSlice', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'MobileNetwork'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

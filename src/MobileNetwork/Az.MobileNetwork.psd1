@{
  GUID = '5ecd135a-5394-4d9a-a328-321233b8f904'
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
  FunctionsToExport = 'Get-AzMobileNetwork', 'Get-AzMobileNetworkAttachedDataNetwork', 'Get-AzMobileNetworkDataNetwork', 'Get-AzMobileNetworkPacketCoreControlPlane', 'Get-AzMobileNetworkPacketCoreControlPlaneVersion', 'Get-AzMobileNetworkPacketCoreDataPlane', 'Get-AzMobileNetworkService', 'Get-AzMobileNetworkSim', 'Get-AzMobileNetworkSimGroup', 'Get-AzMobileNetworkSimPolicy', 'Get-AzMobileNetworkSite', 'Get-AzMobileNetworkSlouse', 'Invoke-AzMobileNetworkBulkSimDelete', 'Invoke-AzMobileNetworkBulkSimUpload', 'Invoke-AzMobileNetworkBulkSimUploadEncrypted', 'Invoke-AzMobileNetworkCollectPacketCoreControlPlaneDiagnosticPackage', 'Invoke-AzMobileNetworkReinstallPacketCoreControlPlane', 'Invoke-AzMobileNetworkRollbackPacketCoreControlPlane', 'New-AzMobileNetwork', 'New-AzMobileNetworkAttachedDataNetwork', 'New-AzMobileNetworkDataNetwork', 'New-AzMobileNetworkPacketCoreControlPlane', 'New-AzMobileNetworkPacketCoreDataPlane', 'New-AzMobileNetworkService', 'New-AzMobileNetworkSim', 'New-AzMobileNetworkSimGroup', 'New-AzMobileNetworkSimPolicy', 'New-AzMobileNetworkSite', 'New-AzMobileNetworkSlouse', 'Remove-AzMobileNetwork', 'Remove-AzMobileNetworkAttachedDataNetwork', 'Remove-AzMobileNetworkDataNetwork', 'Remove-AzMobileNetworkPacketCoreControlPlane', 'Remove-AzMobileNetworkPacketCoreDataPlane', 'Remove-AzMobileNetworkService', 'Remove-AzMobileNetworkSim', 'Remove-AzMobileNetworkSimGroup', 'Remove-AzMobileNetworkSimPolicy', 'Remove-AzMobileNetworkSite', 'Remove-AzMobileNetworkSlouse', 'Update-AzMobileNetworkAttachedDataNetworkTag', 'Update-AzMobileNetworkDataNetworkTag', 'Update-AzMobileNetworkPacketCoreControlPlaneTag', 'Update-AzMobileNetworkPacketCoreDataPlaneTag', 'Update-AzMobileNetworkServiceTag', 'Update-AzMobileNetworkSimGroupTag', 'Update-AzMobileNetworkSimPolicyTag', 'Update-AzMobileNetworkSiteTag', 'Update-AzMobileNetworkSlouseTag', 'Update-AzMobileNetworkTag', '*'
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

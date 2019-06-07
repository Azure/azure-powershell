@{
# region definition
  RootModule = './Az.Compute.psm1'
  ModuleVersion = '0.0.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Compute cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Compute.private.dll'
  FormatsToProcess = './Az.Compute.format.ps1xml'
# endregion

# region persistent data
  GUID = 'cff3f125-febd-4c4c-4ad4-b3e52903a71f'
# endregion

# region private data
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'Compute'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
      Profiles = 'latest-2019-04-30', 'hybrid-2019-03-01'
    }
  }
# endregion

# region exports
  CmdletsToExport = 'ConvertTo-AzVMManagedDisk', 'ConvertTo-AzVmssSinglePlacementGroup', 'Export-AzLogAnalyticRequestRateByInterval', 'Export-AzLogAnalyticThrottledRequest', 'Get-AzAvailabilitySet', 'Get-AzComputeResourceSku', 'Get-AzDisk', 'Get-AzGallery', 'Get-AzGalleryImageDefinition', 'Get-AzGalleryImageVersion', 'Get-AzImage', 'Get-AzProximityPlacementGroup', 'Get-AzSnapshot', 'Get-AzVM', 'Get-AzVMExtension', 'Get-AzVMExtensionImage', 'Get-AzVMExtensionImageType', 'Get-AzVMImage', 'Get-AzVMImageOffer', 'Get-AzVMImagePublisher', 'Get-AzVMImageSku', 'Get-AzVMRunCommandDocument', 'Get-AzVMSize', 'Get-AzVmss', 'Get-AzVmssExtension', 'Get-AzVmssRollingUpgrade', 'Get-AzVmssSku', 'Get-AzVmssVM', 'Get-AzVMUsage', 'Grant-AzDiskAccess', 'Grant-AzSnapshotAccess', 'Invoke-AzVMCommand', 'Invoke-AzVMReimage', 'Invoke-AzVmssReimage', 'Invoke-AzVmssVMCommand', 'Invoke-AzVmssVMReimage', 'New-AzAvailabilitySet', 'New-AzDisk', 'New-AzGallery', 'New-AzGalleryImageDefinition', 'New-AzGalleryImageVersion', 'New-AzImage', 'New-AzProximityPlacementGroup', 'New-AzSnapshot', 'New-AzVM', 'New-AzVMExtension', 'New-AzVmss', 'New-AzVmssExtension', 'Remove-AzAvailabilitySet', 'Remove-AzDisk', 'Remove-AzGallery', 'Remove-AzGalleryImageDefinition', 'Remove-AzGalleryImageVersion', 'Remove-AzImage', 'Remove-AzProximityPlacementGroup', 'Remove-AzSnapshot', 'Remove-AzVM', 'Remove-AzVMExtension', 'Remove-AzVmss', 'Remove-AzVmssExtension', 'Remove-AzVmssInstance', 'Remove-AzVmssVM', 'Repair-AzVmssServiceFabricUpdateDomain', 'Restart-AzVM', 'Restart-AzVmss', 'Restart-AzVmssVM', 'Revoke-AzDiskAccess', 'Revoke-AzSnapshotAccess', 'Save-AzVMImage', 'Set-AzAvailabilitySet', 'Set-AzDisk', 'Set-AzImage', 'Set-AzProximityPlacementGroup', 'Set-AzSnapshot', 'Set-AzVM', 'Set-AzVMExtension', 'Set-AzVmss', 'Set-AzVmssExtension', 'Set-AzVmssVM', 'Start-AzVM', 'Start-AzVmss', 'Start-AzVmssRollingOSUpgrade', 'Start-AzVmssRollingUpgradeExtensionUpgrade', 'Start-AzVmssVM', 'Stop-AzVM', 'Stop-AzVmss', 'Stop-AzVmssRollingUpgrade', 'Stop-AzVmssVM', 'Update-AzAvailabilitySet', 'Update-AzDisk', 'Update-AzGallery', 'Update-AzGalleryImageDefinition', 'Update-AzGalleryImageVersion', 'Update-AzImage', 'Update-AzProximityPlacementGroup', 'Update-AzSnapshot', 'Update-AzVM', 'Update-AzVMExtension', 'Update-AzVmss', 'Update-AzVmssInstance', '*'
  AliasesToExport = 'Export-AzLogAnalyticThrottledRequests', 'Invoke-AzVMRunCommand', 'Invoke-AzVmssVMRunCommand', 'Update-AzVmssVM', '*'
# endregion

}
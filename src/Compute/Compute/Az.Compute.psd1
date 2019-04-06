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
  FormatsToProcess = './custom/extensions.format.ps1xml', './Az.Compute.format.ps1xml' 
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
      Profiles = 'latest-2019-04-01', 'hybrid-2019'
    }
  }
# endregion

# region exports
  CmdletsToExport = 'Convert-AzVMToManagedDisk', 'Export-AzLogAnalyticRequestRateByInterval', 'Export-AzLogAnalyticThrottledRequest', 'Export-AzVM', 'Get-AzAvailabilitySet', 'Get-AzAvailabilitySetAvailableSize', 'Get-AzDisk', 'Get-AzGallery', 'Get-AzGalleryImage', 'Get-AzGalleryImageVersion', 'Get-AzImage', 'Get-AzResourceSku', 'Get-AzSnapshot', 'Get-AzUsage', 'Get-AzVM', 'Get-AzVMAll', 'Get-AzVMAvailableSize', 'Get-AzVMExtension', 'Get-AzVMExtensionImage', 'Get-AzVMExtensionImageType', 'Get-AzVMExtensionImageVersion', 'Get-AzVMImage', 'Get-AzVMImageOffer', 'Get-AzVMImagePublisher', 'Get-AzVMImageSku', 'Get-AzVMRunCommand', 'Get-AzVMSize', 'Get-AzVmss', 'Get-AzVmssAll', 'Get-AzVmssExtension', 'Get-AzVmssInstanceView', 'Get-AzVmssOSUpgradeHistory', 'Get-AzVmssRollingUpgradeLatest', 'Get-AzVmssSku', 'Get-AzVmssVM', 'Get-AzVmssVMInstanceView', 'Grant-AzDiskAccess', 'Grant-AzSnapshotAccess', 'Invoke-AzDeallocateVM', 'Invoke-AzDeallocateVmss', 'Invoke-AzDeallocateVmssVM', 'Invoke-AzForceVmssRecoveryServiceFabricPlatformUpdateDomainWalk', 'Invoke-AzInstanceVMView', 'Invoke-AzPerformVMMaintenance', 'Invoke-AzPerformVmssMaintenance', 'Invoke-AzPerformVmssVMMaintenance', 'Invoke-AzRedeployVM', 'Invoke-AzRedeployVmss', 'Invoke-AzRedeployVmssVM', 'New-AzAvailabilitySet', 'New-AzDisk', 'New-AzGallery', 'New-AzGalleryImage', 'New-AzGalleryImageVersion', 'New-AzImage', 'New-AzSnapshot', 'New-AzVM', 'New-AzVMExtension', 'New-AzVmss', 'New-AzVmssExtension', 'Remove-AzAvailabilitySet', 'Remove-AzDisk', 'Remove-AzGallery', 'Remove-AzGalleryImage', 'Remove-AzGalleryImageVersion', 'Remove-AzImage', 'Remove-AzSnapshot', 'Remove-AzVM', 'Remove-AzVMExtension', 'Remove-AzVmss', 'Remove-AzVmssExtension', 'Remove-AzVmssInstance', 'Remove-AzVmssVM', 'Reset-AzVM', 'Restart-AzVM', 'Restart-AzVmss', 'Restart-AzVmssVM', 'Revoke-AzDiskAccess', 'Revoke-AzSnapshotAccess', 'Set-AzAvailabilitySet', 'Set-AzDisk', 'Set-AzGallery', 'Set-AzGalleryImage', 'Set-AzGalleryImageVersion', 'Set-AzImage', 'Set-AzSnapshot', 'Set-AzVM', 'Set-AzVMExtension', 'Set-AzVmss', 'Set-AzVmssExtension', 'Set-AzVmssVM', 'Start-AzVM', 'Start-AzVMCommand', 'Start-AzVmss', 'Start-AzVmssRollingUpgradeExtensionUpgrade', 'Start-AzVmssRollingUpgradeOSUpgrade', 'Start-AzVmssVM', 'Start-AzVmssVMCommand', 'Stop-AzVM', 'Stop-AzVmss', 'Stop-AzVmssRollingUpgrade', 'Stop-AzVmssVM', 'Update-AzAvailabilitySet', 'Update-AzDisk', 'Update-AzImage', 'Update-AzSnapshot', 'Update-AzVM', 'Update-AzVMExtension', 'Update-AzVmss', 'Update-AzVmssAll', 'Update-AzVmssInstance', 'Update-AzVmssVM', 'Update-AzVmssVMAll', '*'
# endregion

}
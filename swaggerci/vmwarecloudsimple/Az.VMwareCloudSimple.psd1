@{
  GUID = 'd619d17e-5906-4829-b3b8-7be41b98eac4'
  RootModule = './Az.VMwareCloudSimple.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: VMwareCloudSimple cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.VMwareCloudSimple.private.dll'
  FormatsToProcess = './Az.VMwareCloudSimple.format.ps1xml'
  FunctionsToExport = 'Get-AzVMwareCloudSimpleCustomizationPolicy', 'Get-AzVMwareCloudSimpleDedicatedCloudNode', 'Get-AzVMwareCloudSimpleDedicatedCloudService', 'Get-AzVMwareCloudSimplePrivateCloud', 'Get-AzVMwareCloudSimpleResourcePool', 'Get-AzVMwareCloudSimpleSkusAvailability', 'Get-AzVMwareCloudSimpleUsage', 'Get-AzVMwareCloudSimpleVirtualMachine', 'Get-AzVMwareCloudSimpleVirtualMachineTemplate', 'Get-AzVMwareCloudSimpleVirtualNetwork', 'New-AzVMwareCloudSimpleDedicatedCloudNode', 'New-AzVMwareCloudSimpleDedicatedCloudService', 'New-AzVMwareCloudSimpleVirtualMachine', 'Remove-AzVMwareCloudSimpleDedicatedCloudNode', 'Remove-AzVMwareCloudSimpleDedicatedCloudService', 'Remove-AzVMwareCloudSimpleVirtualMachine', 'Start-AzVMwareCloudSimpleVirtualMachine', 'Stop-AzVMwareCloudSimpleVirtualMachine', 'Update-AzVMwareCloudSimpleDedicatedCloudNode', 'Update-AzVMwareCloudSimpleDedicatedCloudService', 'Update-AzVMwareCloudSimpleVirtualMachine', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'VMwareCloudSimple'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

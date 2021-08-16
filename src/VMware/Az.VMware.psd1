@{
  GUID = '78d2fac8-ec90-47ad-b8aa-a27106b158f5'
  RootModule = './Az.VMware.psm1'
  ModuleVersion = '0.3.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: VMware cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.VMware.private.dll'
  FormatsToProcess = './Az.VMware.format.ps1xml'
  FunctionsToExport = 'Get-AzVMwareAddon', 'Get-AzVMwareCloudLink', 'Get-AzVMwareCluster', 'Get-AzVMwareDatastore', 'Get-AzVMwareExpressRouteAuthorization', 'Get-AzVMwareGlobalReachConnection', 'Get-AzVMwarePrivateCloud', 'Get-AzVMwarePrivateCloudAdminCredential', 'New-AzVMwareAddon', 'New-AzVMwareAddonHcxPropertiesObject', 'New-AzVMwareAddonSrmPropertiesObject', 'New-AzVMwareAddonVrPropertiesObject', 'New-AzVMwareCloudLink', 'New-AzVMwareCluster', 'New-AzVMwareDatastore', 'New-AzVMwareExpressRouteAuthorization', 'New-AzVMwareGlobalReachConnection', 'New-AzVMwarePrivateCloud', 'New-AzVMwarePrivateCloudNsxtPassword', 'New-AzVMwarePrivateCloudVcenterPassword', 'New-AzVMwarePSCredentialExecutionParameterObject', 'New-AzVMwareScriptExecutionParameterObject', 'New-AzVMwareScriptSecureStringExecutionParameterObject', 'New-AzVMwareScriptStringExecutionParameterObject', 'Remove-AzVMwareAddon', 'Remove-AzVMwareCloudLink', 'Remove-AzVMwareCluster', 'Remove-AzVMwareDatastore', 'Remove-AzVMwareExpressRouteAuthorization', 'Remove-AzVMwareGlobalReachConnection', 'Remove-AzVMwarePrivateCloud', 'Test-AzVMwareLocationQuotaAvailability', 'Test-AzVMwareLocationTrialAvailability', 'Update-AzVMwareCluster', 'Update-AzVMwarePrivateCloud', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'VMware'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

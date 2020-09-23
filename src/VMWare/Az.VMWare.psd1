@{
  GUID = '78d2fac8-ec90-47ad-b8aa-a27106b158f5'
  RootModule = './Az.VMWare.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: VMWare cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.VMWare.private.dll'
  FormatsToProcess = './Az.VMWare.format.ps1xml'
  FunctionsToExport = 'Get-AzVMWareAuthorization', 'Get-AzVMWareCluster', 'Get-AzVMWarePrivateCloud', 'Get-AzVMWarePrivateCloudAdminCredentials', 'New-AzVMWareAuthorization', 'New-AzVMWareCluster', 'New-AzVMWarePrivateCloud', 'Remove-AzVMWareAuthorization', 'Remove-AzVMWareCluster', 'Remove-AzVMWarePrivateCloud', 'Test-AzVMWareLocationQuotaAvailability', 'Test-AzVMWareLocationTrialAvailability', 'Update-AzVMWareCluster', 'Update-AzVMWarePrivateCloud', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'VMWare'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

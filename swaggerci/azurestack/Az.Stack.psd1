@{
  GUID = 'ade2da78-170a-46dc-8047-aa82ca6441cf'
  RootModule = './Az.Stack.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Stack cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Stack.private.dll'
  FormatsToProcess = './Az.Stack.format.ps1xml'
  FunctionsToExport = 'Enable-AzStackRegistrationRemoteManagement', 'Get-AzStackCloudManifestFile', 'Get-AzStackCustomerSubscription', 'Get-AzStackLinkedSubscription', 'Get-AzStackProduct', 'Get-AzStackProductDetail', 'Get-AzStackRegistration', 'Get-AzStackRegistrationActivationKey', 'Invoke-AzStackUploadProductLog', 'New-AzStackCustomerSubscription', 'New-AzStackLinkedSubscription', 'New-AzStackRegistration', 'Remove-AzStackCustomerSubscription', 'Remove-AzStackLinkedSubscription', 'Remove-AzStackRegistration', 'Update-AzStackLinkedSubscription', 'Update-AzStackRegistration', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Stack'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

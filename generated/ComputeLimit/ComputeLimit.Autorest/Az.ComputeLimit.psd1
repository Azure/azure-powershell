@{
  GUID = '842a6dda-4874-4a97-9a64-005b9ca8792c'
  RootModule = './Az.ComputeLimit.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ComputeLimit cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ComputeLimit.private.dll'
  FormatsToProcess = './Az.ComputeLimit.format.ps1xml'
  FunctionsToExport = 'Add-AzGuestSubscription', 'Add-AzSharedLimit', 'Get-AzGuestSubscription', 'Get-AzSharedLimit', 'Remove-AzGuestSubscription', 'Remove-AzSharedLimit'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ComputeLimit'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

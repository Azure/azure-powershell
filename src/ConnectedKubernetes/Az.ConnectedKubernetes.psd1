@{
  GUID = '59df8ab1-442a-41ae-9b55-60b505bae789'
  RootModule = './Az.ConnectedKubernetes.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ConnectedKubernetes cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ConnectedKubernetes.private.dll'
  RequiredModules = @(@{ModuleName = 'Az.Accounts'; ModuleVersion = '2.2.5'; })
  FormatsToProcess = './Az.ConnectedKubernetes.format.ps1xml'
  FunctionsToExport = 'Get-AzConnectedKubernetes', 'New-AzConnectedKubernetes', 'Remove-AzConnectedKubernetes', 'Update-AzConnectedKubernetes'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ConnectedKubernetes'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = '* the first preview release'
    }
  }
}

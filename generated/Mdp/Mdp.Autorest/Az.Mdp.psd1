@{
  GUID = 'c9f4a15f-58e0-4476-821d-a0d998e51a11'
  RootModule = './Az.Mdp.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Mdp cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Mdp.private.dll'
  FormatsToProcess = './Az.Mdp.format.ps1xml'
  FunctionsToExport = 'Get-AzMdpPool', 'Get-AzMdpPoolAgent', 'Get-AzMdpSku', 'New-AzMdpPool', 'Remove-AzMdpPool', 'Update-AzMdpPool'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Mdp'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

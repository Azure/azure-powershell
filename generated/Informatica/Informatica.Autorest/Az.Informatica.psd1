@{
  GUID = '2cc23942-2b17-4b45-84c4-ebd4d2af2292'
  RootModule = './Az.Informatica.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Informatica cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Informatica.private.dll'
  FormatsToProcess = './Az.Informatica.format.ps1xml'
  FunctionsToExport = 'Get-AzInformaticaOrganization', 'Get-AzInformaticaOrganizationServerlessMetadata', 'Get-AzInformaticaOrganizationServerlessRuntime', 'Get-AzInformaticaServerlessRuntime', 'Invoke-AzInformaticaServerlessRuntimeResource', 'New-AzInformaticaOrganization', 'New-AzInformaticaServerlessRuntime', 'Remove-AzInformaticaOrganization', 'Remove-AzInformaticaServerlessRuntime', 'Start-AzInformaticaServerlessRuntimeFailedServerlessRuntime', 'Test-AzInformaticaServerlessRuntimeDependency', 'Update-AzInformaticaOrganization', 'Update-AzInformaticaServerlessRuntime'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Informatica'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

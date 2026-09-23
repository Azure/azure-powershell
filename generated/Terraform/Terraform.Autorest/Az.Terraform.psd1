@{
  GUID = '0e83fac3-e2db-4aed-9b5e-d28ca6a2fa90'
  RootModule = './Az.Terraform.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Terraform cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Terraform.private.dll'
  FormatsToProcess = './Az.Terraform.format.ps1xml'
  FunctionsToExport = 'Export-AzTerraform', 'New-AzTerraformExportQueryObject', 'New-AzTerraformExportResourceGroupObject', 'New-AzTerraformExportResourceObject'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Terraform'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

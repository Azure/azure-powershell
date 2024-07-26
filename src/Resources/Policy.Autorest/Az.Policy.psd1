@{
  GUID = '28bf853b-7409-4d2c-bb4a-9c72f30e9a09'
  RootModule = './Az.Policy.psm1'
  ModuleVersion = '0.1.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Policy cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Policy.private.dll'
  FormatsToProcess = './Az.Policy.format.ps1xml'
  ScriptsToProcess = @('./custom/Helpers.ps1')
  FunctionsToExport = 'Get-AzPolicyAssignment', 'Get-AzPolicyDefinition', 'Get-AzPolicyExemption', 'Get-AzPolicySetDefinition', 'New-AzPolicyAssignment', 'New-AzPolicyDefinition', 'New-AzPolicyExemption', 'New-AzPolicySetDefinition', 'Remove-AzPolicyAssignment', 'Remove-AzPolicyDefinition', 'Remove-AzPolicyExemption', 'Remove-AzPolicySetDefinition', 'Update-AzPolicyAssignment', 'Update-AzPolicyDefinition', 'Update-AzPolicyExemption', 'Update-AzPolicySetDefinition'
  AliasesToExport = 'Set-AzPolicyAssignment', 'Set-AzPolicyDefinition', 'Set-AzPolicyExemption', 'Set-AzPolicySetDefinition'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Policy'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

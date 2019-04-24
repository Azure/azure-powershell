@{
# region definition 
  RootModule = './Az.AppConfiguration.psm1'
  ModuleVersion = '0.1.2'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: AppConfiguration cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.AppConfiguration.private.dll'
  FormatsToProcess = './Az.AppConfiguration.format.ps1xml'
# endregion 

# region persistent data 
  GUID = '3ff16738-381e-4d5a-9d90-c7ef6816f78e'
# endregion 

# region private data 
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'AppConfiguration'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
# endregion 

# region exports
  CmdletsToExport = 'Get-AzAppConfigurationStore', 'Get-AzAppConfigurationStoreKey', 'New-AzAppConfigurationStore', 'New-AzAppConfigurationStoreKey', 'Remove-AzAppConfigurationStore', 'Test-AzAppConfigurationStoreNameAvailability', '*'
# endregion

}
@{
# region definition 
  RootModule = './Az.Billing.psm1'
  ModuleVersion = '0.0.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Billing cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Billing.private.dll'
  FormatsToProcess = './Az.Billing.format.ps1xml'
# endregion 

# region persistent data 
  GUID = 'f6447640-ffdf-42f9-5ffe-a11eed4aa63f'
# endregion 

# region private data 
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'Billing'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
      Profiles = 'latest-2019-04-01'
    }
  }
# endregion 

}
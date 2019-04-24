@{
# region definition 
  RootModule = './Az.Dns.psm1'
  ModuleVersion = '0.0.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Dns cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Dns.private.dll'
  FormatsToProcess = './Az.Dns.format.ps1xml'
# endregion 

# region persistent data 
  GUID = '7417c0b6-55f6-4ee9-a3de-831752536106'
# endregion 

# region private data 
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'Dns'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
      Profiles = 'latest-2019-04-01', 'hybrid-2019'
    }
  }
# endregion 

}
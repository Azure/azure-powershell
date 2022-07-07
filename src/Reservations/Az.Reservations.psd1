@{
  GUID = 'bc87987e-4244-40d6-a49e-698173bcbb59'
  RootModule = './Az.Reservations.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Reservations cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Reservations.private.dll'
  FormatsToProcess = './Az.Reservations.format.ps1xml'
  FunctionsToExport = 'Get-AzReservationsAppliedReservationList', 'Get-AzReservationsCatalog', 'Get-AzReservationsReservation', 'Get-AzReservationsReservationOrder', 'Get-AzReservationsReservationRevision', 'Invoke-AzReservationsAvailableReservationScope', 'Invoke-AzReservationsCalculateExchange', 'Invoke-AzReservationsCalculateReservationOrder', 'Invoke-AzReservationsExchange', 'Invoke-AzReservationsPurchaseReservationOrder', 'Merge-AzReservationsReservation', 'Rename-AzReservationsReservationOrderDirectory', 'Split-AzReservationsReservation', 'Update-AzReservationsReservation', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Reservations'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}

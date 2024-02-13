if(($null -eq $TestName) -or ($TestName -contains 'New-AzSecurityDefenderForDatabasesGcpOfferingObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSecurityDefenderForDatabasesGcpOfferingObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSecurityDefenderForDatabasesGcpOfferingObject' {
    It '__AllParameterSets' {
        $emailSuffix = "myproject.iam.gserviceaccount.com"
        $offering = New-AzSecurityDefenderForDatabasesGcpOfferingObject `
            -ArcAutoProvisioningEnabled $true `
            -DefenderForDatabaseArcAutoProvisioningServiceAccountEmailAddress "microsoft-databases-arc-ap@" -DefenderForDatabaseArcAutoProvisioningWorkloadIdentityProviderId "defender-for-databases-arc-ap"
        $offering.OfferingType | Should -Be "DefenderForDatabasesGcp"
    }
}

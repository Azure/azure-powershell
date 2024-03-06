if(($null -eq $TestName) -or ($TestName -contains 'New-AzSecurityDefenderForServersGcpOfferingObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSecurityDefenderForServersGcpOfferingObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSecurityDefenderForServersGcpOfferingObject' {
    It '__AllParameterSets' {
        $emailSuffix = "myproject.iam.gserviceaccount.com"
        $offering = New-AzSecurityDefenderForServersGcpOfferingObject `
            -DefenderForServerServiceAccountEmailAddress "microsoft-defender-for-servers@$emailSuffix" -DefenderForServerWorkloadIdentityProviderId "defender-for-servers" `
            -ArcAutoProvisioningEnabled $true -MdeAutoProvisioningEnabled $true -VaAutoProvisioningEnabled $true -ConfigurationType TVM `
            -VMScannerEnabled $true -ConfigurationScanningMode Default `
            -SubPlanType P2
        $offering.OfferingType | Should -Be "DefenderForServersGcp"
    }
}

if(($null -eq $TestName) -or ($TestName -contains 'New-AzSecurityDefenderForServersAwsOfferingObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSecurityDefenderForServersAwsOfferingObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSecurityDefenderForServersAwsOfferingObject' {
    It '__AllParameterSets' {
        $arnPrefix = "arn:aws:iam::123456789012:role"
        $offering = New-AzSecurityDefenderForServersAwsOfferingObject `
            -DefenderForServerCloudRoleArn "$arnPrefix/DefenderForCloud-DefenderForServers" `
            -ArcAutoProvisioningEnabled $true -ArcAutoProvisioningCloudRoleArn "$arnPrefix/DefenderForCloud-ArcAutoProvisioning" `
            -MdeAutoProvisioningEnabled $true `
            -VaAutoProvisioningEnabled $true -ConfigurationType TVM `
            -VMScannerEnabled $true -ConfigurationCloudRoleArn "$arnPrefix/DefenderForCloud-AgentlessScanner" -ConfigurationScanningMode Default `
            -SubPlanType P2
        
        $offering.OfferingType | Should -Be "DefenderForServersAws"
    }
}

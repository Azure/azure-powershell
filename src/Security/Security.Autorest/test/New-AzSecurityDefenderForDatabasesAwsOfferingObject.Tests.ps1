if(($null -eq $TestName) -or ($TestName -contains 'New-AzSecurityDefenderForDatabasesAwsOfferingObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSecurityDefenderForDatabasesAwsOfferingObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSecurityDefenderForDatabasesAwsOfferingObject' {
    It '__AllParameterSets' {
        $arnPrefix = "arn:aws:iam::123456789012:role"
        $offering = New-AzSecurityDefenderForDatabasesAwsOfferingObject `
            -ArcAutoProvisioningEnabled $true -ArcAutoProvisioningCloudRoleArn "$arnPrefix/DefenderForCloud-ArcAutoProvisioning" `
            -DatabaseDspmEnabled $true -DatabaseDspmCloudRoleArn "$arnPrefix/DefenderForCloud-DataSecurityPostureDB"
        
        $offering.OfferingType | Should -Be "DefenderForDatabasesAws"
    }
}

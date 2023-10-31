if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRecoveryServicesBackupProtectionPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRecoveryServicesBackupProtectionPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRecoveryServicesBackupProtectionPolicy' {
    It 'GetPolicyByName' {
        # get the variables
        $subscriptionId = $env.TestCommon.SubscriptionId
        $resourceGroupName = $env.TestCommon.ResourceGroupName
        $vaultName = $env.TestCommon.VaultName

        # get all policies
        $policyByName = Get-AzRecoveryServicesBackupProtectionPolicy -ResourceGroupName $resourceGroupName -VaultName $vaultName -Name "HourlyLogBackup"
        $policyByName.Name | Should -Be "HourlyLogBackup"
    }

    It 'ListPolicy' {
        # get the variables
        $subscriptionId = $env.TestCommon.SubscriptionId
        $resourceGroupName = $env.TestCommon.ResourceGroupName
        $vaultName = $env.TestCommon.VaultName
        
        # get all policies
        $allPolicies = Get-AzRecoveryServicesBackupProtectionPolicy -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId
        
        # validate
        $allPolicies.Count -ge 7 | Should -Be $true

        $policiesWithFilter =  Get-AzRecoveryServicesBackupProtectionPolicy -ResourceGroupName $ResourceGroupName -VaultName $VaultName -PolicySubType "Standard" -IsArchiveSmartTieringEnabled $true -DatasourceType MSSQL
                
        foreach($policy in $policiesWithFilter){
            # validate DatasourceType
            $policy.Property.WorkloadType | Should -Be "SQLDataBase"

            # validate v1 policy
            if($policy.Property.PolicyType -ne $null -and $policy.Property.PolicyType.ToString() -ne $null){
                $policy.Property.PolicyType.ToString().ToLower() -match "v2" | Should -Be $false
            }

            # validate smart tiering
            if($policy.Property.SubProtectionPolicy -ne $null -and $policy.Property.SubProtectionPolicy[$PolicyType -eq "Full"].TieringPolicy -ne $null){
                $policy.Property.SubProtectionPolicy[$PolicyType -eq "Full"].TieringPolicy["ArchivedRP"].TieringMode -eq "TierRecommended" -or $policy.Property.SubProtectionPolicy[$PolicyType -eq "Full"].TieringPolicy["ArchivedRP"].TieringMode -eq "TierAfter" | Should -Be $true
            }
        }
    }
}

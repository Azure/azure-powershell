if(($null -eq $TestName) -or ($TestName -contains 'New-AzDataProtectionResourceGuard'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataProtectionResourceGuard.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDataProtectionResourceGuard' {
    It 'PutExpanded' {
        $subId = $env.TestResourceGuard.SubscriptionId
        $rgName = $env.TestResourceGuard.ResourceGroupName
        $resGuardName = $env.TestResourceGuard.ResourceGuardName
        $location = $env.TestResourceGuard.Location 
        $tag = @{"MABUsed"="Yes";"Owner"="hiaga";"Purpose"="testing";"DeleteBy"="01-2099"}
        
        # create resource guard
        $resourceGuard = New-AzDataProtectionResourceGuard -SubscriptionId $subId -ResourceGroupName $rgName -Name $resGuardName -Location $location -Tag $tag
        $resourceGuard = Get-AzDataProtectionResourceGuard -SubscriptionId $subId  -ResourceGroupName $rgName -Name $resGuardName
        $criticalOperations  = $resourceGuard.ResourceGuardOperation.VaultCriticalOperation 
        
        $criticalOperations -contains "Microsoft.RecoveryServices/vaults/backupPolicies/write" | Should be $true
        $criticalOperations -contains "Microsoft.RecoveryServices/vaults/backupSecurityPIN/action" | Should be $true
        $criticalOperations -contains "Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers/protectedItems/write" | Should be $true

        # remove resource guard 
        Remove-AzDataProtectionResourceGuard -Name $resourceGuard.Name -ResourceGroupName $rgName -SubscriptionId $subId
        
        # resource guard should be null
        $resourceGuard = Get-AzDataProtectionResourceGuard -SubscriptionId $subId  -ResourceGroupName $rgName        
        ($resourceGuard -eq $null -or $resourceGuard.Name -notcontains $resGuardName) | Should be $true
    }

    It 'Put' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PutViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PutViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}

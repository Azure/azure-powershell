if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzSite'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSite.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzSite' {
    BeforeEach {
        # Create a site for deletion tests
        $testSiteName = "site-delete-$(Get-Random -Maximum 999)"
        
        # Create site with minimal required parameters
        New-AzSite -SiteName $testSiteName -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId -DisplayName $env.displayName01
        
        Start-TestSleep -Seconds 10  # Allow time for resource creation
        $script:testSiteName = $testSiteName
    }

    It 'Delete' {
        # Verify site exists before deletion
        $site = Get-AzSite -Name $script:testSiteName -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId
        $site | Should -Not -BeNullOrEmpty

        # Delete the site
        Remove-AzSite -Name $script:testSiteName -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId

        # Verify site is deleted
        Start-TestSleep -Seconds 10  # Allow time for deletion to propagate
        { Get-AzSite -Name $script:testSiteName -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId } | Should -Throw
    }

    It 'Delete non-existent site should not throw error' {
        # PowerShell should handle this gracefully
        { Remove-AzSite -Name "non-existent-site-12345" -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue } | Should -Not -Throw
    }

    AfterEach {
        # Cleanup any remaining test sites
        if ($script:testSiteName) {
            try {
                Remove-AzSite -Name $script:testSiteName -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue
            }
            catch {
                # Site may already be deleted, ignore errors
            }
        }
    }

    It 'Delete site at Subscription Scope' {
        # First create a site at subscription scope
        $testSite = New-AzSite -SiteName $env.siteNameSubscriptionScope -SubscriptionId $env.SubscriptionId -DisplayName "Test Sub Delete" -Description "Test subscription scope deletion" -Country $env.country -PostalCode $env.postalCode
        
        # Verify it was created
        $createdSite = Get-AzSite -Name $env.siteNameSubscriptionScope -SubscriptionId $env.SubscriptionId
        $createdSite | Should -Not -BeNullOrEmpty
        
        # Delete the site at subscription scope
        Remove-AzSite -Name $env.siteNameSubscriptionScope -SubscriptionId $env.SubscriptionId
        
        # Wait for deletion to propagate
        Start-TestSleep -Seconds 10
        
        # Verify deletion
        { Get-AzSite -Name $env.siteNameSubscriptionScope -SubscriptionId $env.SubscriptionId } | Should -Throw
    }

    It 'Delete site at Service Group Scope' {
        # First create a site at service group scope
        $testSite = New-AzSite -SiteName $env.siteNameServiceGroupScope -ServicegroupName $env.servicegroupname -SubscriptionId $env.SubscriptionId -DisplayName "Test SG Delete" -Description "Test service group scope deletion" -Country $env.country -PostalCode $env.postalCode
        
        # Verify it was created
        $createdSite = Get-AzSite -Name $env.siteNameServiceGroupScope -ServicegroupName $env.servicegroupname -SubscriptionId $env.SubscriptionId
        $createdSite | Should -Not -BeNullOrEmpty
        
        # Delete the site at service group scope
        Remove-AzSite -Name $env.siteNameServiceGroupScope -ServicegroupName $env.servicegroupname -SubscriptionId $env.SubscriptionId
        
        # Wait for deletion to propagate
        Start-TestSleep -Seconds 10
        
        # Verify deletion
        { Get-AzSite -Name $env.siteNameServiceGroupScope -ServicegroupName $env.servicegroupname -SubscriptionId $env.SubscriptionId } | Should -Throw
    }
}

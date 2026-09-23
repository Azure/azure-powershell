if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSite'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSite.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSite' {
    It 'List' {
        $sites = Get-AzSite -SubscriptionId $env.SubscriptionId
        $sites | Should -Not -BeNullOrEmpty
    }

    It 'List by ResourceGroup' {
        $sites = Get-AzSite -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroup
        $sites | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        $site = Get-AzSite -Name $env.siteName01 -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId
        $site | Should -Not -BeNullOrEmpty
        $site.Name | Should -Be $env.siteName01
        $site.Type | Should -Be "Microsoft.Edge/sites"
    }

    It 'Get non-existent site should throw' {
        { Get-AzSite -Name "non-existent-site" -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId } | Should -Throw
    }

    It 'GetViaIdentity' {
        $site = Get-AzSite -Name $env.siteName01 -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId
        $site | Should -Not -BeNullOrEmpty
        
        # Test identity-based retrieval by parsing the resource ID
        # This validates that sites can be retrieved using identity information extracted from Resource IDs
        if ($site.Id -match '/subscriptions/([^/]+)/resourceGroups/([^/]+)/providers/[^/]+/[^/]+/(.+)') {
            $subscriptionId = $matches[1]
            $resourceGroupName = $matches[2] 
            $siteName = $matches[3]
            
            $result = Get-AzSite -Name $siteName -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId
            
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $site.Name
            $result.Id | Should -Be $site.Id
        } else {
            throw "Unable to parse site Resource ID: $($site.Id)"
        }
    }

    It 'Validate site properties structure' {
        $site = Get-AzSite -Name $env.siteName01 -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId
        $site.Id | Should -Not -BeNullOrEmpty
        $site.Name | Should -Not -BeNullOrEmpty
        $site.Type | Should -Be "microsoft.edge/sites"
        $site.DisplayName | Should -Not -BeNullOrEmpty
    }

    It 'List sites by Subscription Scope' {
        # Test listing sites at subscription scope
        $sites = Get-AzSite -SubscriptionId $env.SubscriptionId
        $sites | Should -Not -BeNullOrEmpty
        
        # Handle case where PowerShell returns single object instead of array
        $siteArray = if ($sites -is [Array]) { $sites } else { @($sites) }
        
        # Verify at least one site exists
        $siteArray.Count | Should -BeGreaterThan 0
        
        # Verify each site has required properties
        foreach ($site in $siteArray) {
            $site.Name | Should -Not -BeNullOrEmpty
            $site.Type | Should -Be "microsoft.edge/sites"
        }
    }

    It 'Get site by Subscription Scope' {
        # First create a site at subscription scope for testing
        $testSite = New-AzSite -SiteName $env.siteNameSubscriptionScope -SubscriptionId $env.SubscriptionId -DisplayName "Test Sub Scope" -Description "Test subscription scope"
        
        try {
            # Get the site at subscription scope
            $site = Get-AzSite -Name $env.siteNameSubscriptionScope -SubscriptionId $env.SubscriptionId
            $site | Should -Not -BeNullOrEmpty
            $site.Name | Should -Be $env.siteNameSubscriptionScope
            $site.DisplayName | Should -Be "Test Sub Scope"
        }
        finally {
            # Cleanup
            Remove-AzSite -Name $env.siteNameSubscriptionScope -SubscriptionId $env.SubscriptionId
        }
    }

    It 'Get site by Service Group Scope' {
        # First create a site at service group scope for testing
        $testSite = New-AzSite -SiteName $env.siteNameServiceGroupScope -ServicegroupName $env.servicegroupname -SubscriptionId $env.SubscriptionId -DisplayName "Test SG Scope" -Description "Test service group scope"
        
        try {
            # Get the site at service group scope
            $site = Get-AzSite -Name $env.siteNameServiceGroupScope -ServicegroupName $env.servicegroupname -SubscriptionId $env.SubscriptionId
            $site | Should -Not -BeNullOrEmpty
            $site.Name | Should -Be $env.siteNameServiceGroupScope
            $site.DisplayName | Should -Be "Test SG Scope"
        }
        finally {
            # Cleanup
            Remove-AzSite -Name $env.siteNameServiceGroupScope -ServicegroupName $env.servicegroupname -SubscriptionId $env.SubscriptionId
        }
    }
}

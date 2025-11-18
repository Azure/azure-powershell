if(($null -eq $TestName) -or ($TestName -contains 'New-AzQuotaLimitObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzQuotaLimitObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzQuotaLimitObject' {
    It 'CreateLimitObjectWithValue' {
        # Test creating a limit object with only the required Value parameter
        $limit = New-AzQuotaLimitObject -Value 100
        
        $limit | Should -Not -BeNullOrEmpty
        $limit.Value | Should -Be 100
        $limit.Type | Should -Be "LimitValue"
        $limit.LimitType | Should -BeNullOrEmpty
    }

    It 'CreateLimitObjectWithIndependentType' {
        # Test creating a limit object with Independent limit type
        # Based on API specs, Independent means the quota is not shared with other resources
        $limit = New-AzQuotaLimitObject -Value 250 -LimitType "Independent"
        
        $limit | Should -Not -BeNullOrEmpty
        $limit.Value | Should -Be 250
        $limit.Type | Should -Be "LimitValue"
        $limit.LimitType | Should -Be "Independent"
    }

    It 'CreateLimitObjectWithSharedType' {
        # Test creating a limit object with Shared limit type
        # Based on API specs, Shared means the quota is shared with other resources
        $limit = New-AzQuotaLimitObject -Value 500 -LimitType "Shared"
        
        $limit | Should -Not -BeNullOrEmpty
        $limit.Value | Should -Be 500
        $limit.Type | Should -Be "LimitValue"
        $limit.LimitType | Should -Be "Shared"
    }

    It 'CreateLimitObjectWithZeroValue' {
        # Test creating a limit object with zero value (edge case)
        $limit = New-AzQuotaLimitObject -Value 0
        
        $limit | Should -Not -BeNullOrEmpty
        $limit.Value | Should -Be 0
        $limit.Type | Should -Be "LimitValue"
    }

    It 'CreateLimitObjectWithLargeValue' {
        # Test creating a limit object with a large value (common for compute quotas)
        # Example from API specs: standardFSv2Family can have values like 10, 11, etc.
        $limit = New-AzQuotaLimitObject -Value 10000 -LimitType "Independent"
        
        $limit | Should -Not -BeNullOrEmpty
        $limit.Value | Should -Be 10000
        $limit.Type | Should -Be "LimitValue"
        $limit.LimitType | Should -Be "Independent"
    }

    It 'CreateMultipleLimitObjects' {
        # Test creating multiple limit objects to ensure no state leakage
        $limit1 = New-AzQuotaLimitObject -Value 100 -LimitType "Independent"
        $limit2 = New-AzQuotaLimitObject -Value 200 -LimitType "Shared"
        $limit3 = New-AzQuotaLimitObject -Value 300
        
        $limit1.Value | Should -Be 100
        $limit1.LimitType | Should -Be "Independent"
        
        $limit2.Value | Should -Be 200
        $limit2.LimitType | Should -Be "Shared"
        
        $limit3.Value | Should -Be 300
        $limit3.LimitType | Should -BeNullOrEmpty
    }

    It 'CreateLimitObjectForComputeQuota' {
        # Test creating a limit object for typical compute quota scenario
        # Based on real-world example from recording: standardFSv2Family with value 10-11
        $limit = New-AzQuotaLimitObject -Value 64 -LimitType "Independent"
        
        $limit | Should -Not -BeNullOrEmpty
        $limit.Value | Should -Be 64
        $limit.Type | Should -Be "LimitValue"
        $limit.LimitType | Should -Be "Independent"
    }

    It 'VerifyLimitObjectProperties' {
        # Comprehensive test to verify all properties of the created object
        $limit = New-AzQuotaLimitObject -Value 1000 -LimitType "Independent"
        
        # Verify the object has the expected properties
        $limit.PSObject.Properties.Name | Should -Contain "Value"
        $limit.PSObject.Properties.Name | Should -Contain "Type"
        $limit.PSObject.Properties.Name | Should -Contain "LimitType"
        
        # Verify the Type is always "LimitValue" (constant)
        $limit.Type | Should -Be "LimitValue"
        
        # Verify the object type
        $limit.GetType().Name | Should -Be "LimitObject"
    }

    It 'CreateLimitObjectWithPipelineInput' {
        # Test that limit objects can be used in pipeline scenarios
        $values = @(10, 20, 30)
        $limits = $values | ForEach-Object { New-AzQuotaLimitObject -Value $_ -LimitType "Independent" }
        
        $limits.Count | Should -Be 3
        $limits[0].Value | Should -Be 10
        $limits[1].Value | Should -Be 20
        $limits[2].Value | Should -Be 30
        $limits | ForEach-Object { $_.LimitType | Should -Be "Independent" }
    }
}

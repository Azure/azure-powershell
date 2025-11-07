if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFunctionAppFlexConsumptionRuntime'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFunctionAppFlexConsumptionRuntime.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFunctionAppFlexConsumptionRuntime' {
    
    BeforeAll {
        $testLocation = 'East Asia'
    }

    It 'Should get all available runtimes for Flex Consumption' {
        $runtimes = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation
        
        $runtimes | Should -Not -BeNullOrEmpty
        $runtimes | Should -BeOfType [System.Object]
        
        # Verify common runtime properties exist
        $runtimes[0].Name | Should -Not -BeNullOrEmpty
        $runtimes[0].Version | Should -Not -BeNullOrEmpty
        $runtimes[0].IsDefault | Should -BeOfType [System.Boolean]
        $runtimes[0].Sku | Should -Not -BeNull
        
        # Verify expected runtimes are available for Flex Consumption
        $runtimeNames = $runtimes | Select-Object -ExpandProperty Name -Unique
        $runtimeNames | Should -Contain 'dotnet-isolated'
        $runtimeNames | Should -Contain 'node'
        $runtimeNames | Should -Contain 'python'
        $runtimeNames | Should -Contain 'java'
        $runtimeNames | Should -Contain 'powershell'
        $runtimeNames | Should -Contain 'custom'
        
        # Verify we have the expected total count (13 runtimes based on actual data)
        $runtimes | Should -HaveCount 13
    }

    It 'Should get specific runtime versions for dotnet-isolated' {
        $dotnetRuntimes = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'dotnet-isolated'
        
        $dotnetRuntimes | Should -Not -BeNullOrEmpty
        $dotnetRuntimes | Should -HaveCount 3
        
        $dotnetRuntimes | ForEach-Object { 
            $_.Name | Should -Be 'dotnet-isolated'
            $_.Version | Should -Not -BeNullOrEmpty
            $_.IsDefault | Should -BeOfType [System.Boolean]
            $_.Sku.skuCode | Should -Be 'FC1'
            $_.EndOfLifeDate | Should -Not -BeNullOrEmpty
        }
        
        # Verify exact versions available
        $versions = $dotnetRuntimes | Select-Object -ExpandProperty Version | Sort-Object
        $versions | Should -Be @('10.0', '8.0', '9.0')
        
        # Verify default version
        $defaultVersion = $dotnetRuntimes | Where-Object { $_.IsDefault -eq $true }
        $defaultVersion | Should -HaveCount 1
        $defaultVersion.Version | Should -Be '8.0'
    }

    It 'Should get specific runtime versions for node' {
        $nodeRuntimes = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'node'
        
        $nodeRuntimes | Should -Not -BeNullOrEmpty
        $nodeRuntimes | Should -HaveCount 2
        
        $nodeRuntimes | ForEach-Object { 
            $_.Name | Should -Be 'node'
            $_.Version | Should -Not -BeNullOrEmpty
            $_.IsDefault | Should -BeOfType [System.Boolean]
            $_.Sku.skuCode | Should -Be 'FC1'
            $_.EndOfLifeDate | Should -Not -BeNullOrEmpty
        }
        
        # Verify exact versions available
        $versions = $nodeRuntimes | Select-Object -ExpandProperty Version | Sort-Object
        $versions | Should -Be @('20', '22')
        
        # Verify default version
        $defaultVersion = $nodeRuntimes | Where-Object { $_.IsDefault -eq $true }
        $defaultVersion | Should -HaveCount 1
        $defaultVersion.Version | Should -Be '22'
    }

    It 'Should get specific runtime versions for java' {
        $javaRuntimes = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'java'
        
        $javaRuntimes | Should -Not -BeNullOrEmpty
        $javaRuntimes | Should -HaveCount 2
        
        $javaRuntimes | ForEach-Object { 
            $_.Name | Should -Be 'java'
            $_.Version | Should -Not -BeNullOrEmpty
            $_.IsDefault | Should -BeOfType [System.Boolean]
            $_.Sku.skuCode | Should -Be 'FC1'
            $_.EndOfLifeDate | Should -Not -BeNullOrEmpty
        }
        
        # Verify exact versions available
        $versions = $javaRuntimes | Select-Object -ExpandProperty Version | Sort-Object
        $versions | Should -Be @('17', '21')
        
        # Verify default version
        $defaultVersion = $javaRuntimes | Where-Object { $_.IsDefault -eq $true }
        $defaultVersion | Should -HaveCount 1
        $defaultVersion.Version | Should -Be '17'
    }

    It 'Should get specific runtime versions for powershell' {
        $powershellRuntimes = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'powershell'
        
        $powershellRuntimes | Should -Not -BeNullOrEmpty
        $powershellRuntimes | Should -HaveCount 1
        
        $powershellRuntimes | ForEach-Object { 
            $_.Name | Should -Be 'powershell'
            $_.Version | Should -Not -BeNullOrEmpty
            $_.IsDefault | Should -BeOfType [System.Boolean]
            $_.Sku.skuCode | Should -Be 'FC1'
            $_.EndOfLifeDate | Should -Not -BeNullOrEmpty
        }
        
        # Verify exact version available
        $powershellRuntimes[0].Version | Should -Be '7.4'
        $powershellRuntimes[0].IsDefault | Should -Be $true
    }

    It 'Should get specific runtime versions for python' {
        $pythonRuntimes = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'python'
        
        $pythonRuntimes | Should -Not -BeNullOrEmpty
        $pythonRuntimes | Should -HaveCount 4
        
        $pythonRuntimes | ForEach-Object { 
            $_.Name | Should -Be 'python'
            $_.Version | Should -Not -BeNullOrEmpty
            $_.IsDefault | Should -BeOfType [System.Boolean]
            $_.Sku.skuCode | Should -Be 'FC1'
            $_.EndOfLifeDate | Should -Not -BeNullOrEmpty
        }
        
        # Verify exact versions available
        $versions = $pythonRuntimes | Select-Object -ExpandProperty Version | Sort-Object
        $versions | Should -Be @('3.10', '3.11', '3.12', '3.13')
        
        # Verify default versions (Python has multiple defaults)
        $defaultVersions = $pythonRuntimes | Where-Object { $_.IsDefault -eq $true }
        $defaultVersions | Should -HaveCount 3
        $defaultVersions.Version | Sort-Object | Should -Be @('3.10', '3.11', '3.12')
        
        # Verify 3.13 is not default
        $nonDefaultVersion = $pythonRuntimes | Where-Object { $_.Version -eq '3.13' }
        $nonDefaultVersion.IsDefault | Should -Be $false
    }

    It 'Should get specific runtime versions for custom' {
        $customRuntimes = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'custom'
        
        $customRuntimes | Should -Not -BeNullOrEmpty
        $customRuntimes | Should -HaveCount 1
        
        $customRuntimes | ForEach-Object { 
            $_.Name | Should -Be 'custom'
            $_.Version | Should -Not -BeNullOrEmpty
            $_.IsDefault | Should -BeOfType [System.Boolean]
            $_.Sku.skuCode | Should -Be 'FC1'
        }
        
        # Verify exact version available
        $customRuntimes[0].Version | Should -Be '1.0'
        $customRuntimes[0].IsDefault | Should -Be $false
        
        # Custom runtime has no EndOfLifeDate
        $customRuntimes[0].EndOfLifeDate | Should -BeNullOrEmpty
    }

    It 'Should get specific runtime and version combination' {
        $specificRuntime = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'dotnet-isolated' -Version '8.0'
        
        $specificRuntime | Should -Not -BeNullOrEmpty
        $specificRuntime | Should -HaveCount 1
        $specificRuntime.Name | Should -Be 'dotnet-isolated'
        $specificRuntime.Version | Should -Be '8.0'
        $specificRuntime.IsDefault | Should -Be $true
        $specificRuntime.EndOfLifeDate | Should -Not -BeNullOrEmpty
        $specificRuntime.Sku.skuCode | Should -Be 'FC1'
    }

    It 'Should get default or latest version for runtime' {
        $defaultRuntime = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'node' -DefaultOrLatest
        
        $defaultRuntime | Should -Not -BeNullOrEmpty
        $defaultRuntime.Name | Should -Be 'node'
        $defaultRuntime.Version | Should -Not -BeNullOrEmpty
        
        # Should return only one runtime (the default/latest)
        $defaultRuntime | Should -HaveCount 1
        
        # Should have IsDefault set to True for default runtime
        $defaultRuntime.IsDefault | Should -Be $true
    }

    It 'Should validate runtime objects have correct structure' {
        $runtimes = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'python'
        
        $runtimes | Should -Not -BeNullOrEmpty
        
        foreach ($runtime in $runtimes) {
            # Required properties validation
            $runtime.Name | Should -Be 'python'
            $runtime.Version | Should -Not -BeNullOrEmpty
            $runtime.IsDefault | Should -BeOfType [System.Boolean]
            $runtime.EndOfLifeDate | Should -Not -BeNullOrEmpty
            $runtime.Sku | Should -Not -BeNull
            $runtime.Sku.skuCode | Should -Be 'FC1'
            
            # Validate Sku object has expected properties
            $runtime.Sku.skuCode | Should -Not -BeNullOrEmpty
            $runtime.Sku.instanceMemoryMB | Should -Not -BeNullOrEmpty
            $runtime.Sku.maximumInstanceCount | Should -Not -BeNullOrEmpty
            $runtime.Sku.functionAppConfigProperties | Should -Not -BeNull
        }
    }

    It 'Should validate EndOfLifeDate is a valid date' {
        $pythonRuntimes = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'python'
        
        foreach ($runtime in $pythonRuntimes) {
            # EndOfLifeDate should be parseable as DateTime
            { [DateTime]::Parse($runtime.EndOfLifeDate) } | Should -Not -Throw
            
            # EndOfLifeDate should be in the future (for current versions)
            $eolDate = [DateTime]::Parse($runtime.EndOfLifeDate)
            $eolDate | Should -BeGreaterThan (Get-Date)
        }
    }

    It 'Should have at least one default version per runtime (excluding custom)' {
        $allRuntimes = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation
        $runtimeNames = $allRuntimes | Select-Object -ExpandProperty Name -Unique
        
        foreach ($runtimeName in $runtimeNames) {
            # Skip 'custom' runtime as it may not have default versions
            if ($runtimeName -eq 'custom') {
                continue
            }
            
            $runtimeVersions = $allRuntimes | Where-Object { $_.Name -eq $runtimeName }
            $defaultVersions = $runtimeVersions | Where-Object { $_.IsDefault -eq $true }
            
            $defaultVersions | Should -Not -BeNullOrEmpty -Because "Runtime '$runtimeName' should have at least one default version"
        }
    }

    It 'Should validate specific EndOfLife dates match expected values' {
        $allRuntimes = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation
        
        # Test specific known EndOfLife dates (based on actual data)
        $dotnet8 = $allRuntimes | Where-Object { $_.Name -eq 'dotnet-isolated' -and $_.Version -eq '8.0' }
        $dotnet8.EndOfLifeDate | Should -Be '11/9/2026'
        
        $dotnet10 = $allRuntimes | Where-Object { $_.Name -eq 'dotnet-isolated' -and $_.Version -eq '10.0' }
        $dotnet10.EndOfLifeDate | Should -Be '11/9/2028'
        
        $node22 = $allRuntimes | Where-Object { $_.Name -eq 'node' -and $_.Version -eq '22' }
        $node22.EndOfLifeDate | Should -Be '4/29/2027'
        
        $java17 = $allRuntimes | Where-Object { $_.Name -eq 'java' -and $_.Version -eq '17' }
        $java17.EndOfLifeDate | Should -Be '8/31/2027'
        
        $java21 = $allRuntimes | Where-Object { $_.Name -eq 'java' -and $_.Version -eq '21' }
        $java21.EndOfLifeDate | Should -Be '8/31/2028'
        
        $powershell74 = $allRuntimes | Where-Object { $_.Name -eq 'powershell' -and $_.Version -eq '7.4' }
        $powershell74.EndOfLifeDate | Should -Be '11/9/2026'
        
        $python311 = $allRuntimes | Where-Object { $_.Name -eq 'python' -and $_.Version -eq '3.11' }
        $python311.EndOfLifeDate | Should -Be '10/30/2027'
        
        $python312 = $allRuntimes | Where-Object { $_.Name -eq 'python' -and $_.Version -eq '3.12' }
        $python312.EndOfLifeDate | Should -Be '10/30/2028'
        
        $python313 = $allRuntimes | Where-Object { $_.Name -eq 'python' -and $_.Version -eq '3.13' }
        $python313.EndOfLifeDate | Should -Be '10/30/2029'
    }

    It 'Should validate long-term supported versions (expire on or after 11/9/2026)' {
        $allRuntimes = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation
        $cutoffDate = [DateTime]'11/9/2026'
        
        # Test long-term supported versions
        $longTermRuntimes = $allRuntimes | Where-Object { 
            ($_.Name -eq 'custom') -or 
            ([DateTime]::Parse($_.EndOfLifeDate) -ge $cutoffDate)
        }
        
        $longTermRuntimes | Should -Not -BeNullOrEmpty
        
        # Verify expected long-term versions
        $dotnetLongTerm = $longTermRuntimes | Where-Object { $_.Name -eq 'dotnet-isolated' }
        $dotnetLongTerm.Version | Sort-Object | Should -Be @('10.0', '8.0')  # 9.0 expires before cutoff
        
        $nodeLongTerm = $longTermRuntimes | Where-Object { $_.Name -eq 'node' }
        $nodeLongTerm.Version | Should -Be '22'  # 20 expires before cutoff
        
        $javaLongTerm = $longTermRuntimes | Where-Object { $_.Name -eq 'java' }
        $javaLongTerm.Version | Sort-Object | Should -Be @('17', '21')  # Both qualify
        
        $powershellLongTerm = $longTermRuntimes | Where-Object { $_.Name -eq 'powershell' }
        $powershellLongTerm.Version | Should -Be '7.4'  # Expires exactly on cutoff
        
        $pythonLongTerm = $longTermRuntimes | Where-Object { $_.Name -eq 'python' }
        $pythonLongTerm.Version | Sort-Object | Should -Be @('3.11', '3.12', '3.13')  # 3.10 expires before cutoff
        
        $customLongTerm = $longTermRuntimes | Where-Object { $_.Name -eq 'custom' }
        $customLongTerm.Version | Should -Be '1.0'  # No expiration
    }

    It 'Should get specific runtime and version for all long-term versions' {
        # Test specific long-term runtime/version combinations
        $testCases = @(
            @{ Runtime = 'dotnet-isolated'; Version = '8.0'; IsDefault = $true },
            @{ Runtime = 'dotnet-isolated'; Version = '10.0'; IsDefault = $false },
            @{ Runtime = 'node'; Version = '22'; IsDefault = $true },
            @{ Runtime = 'java'; Version = '17'; IsDefault = $true },
            @{ Runtime = 'java'; Version = '21'; IsDefault = $false },
            @{ Runtime = 'powershell'; Version = '7.4'; IsDefault = $true },
            @{ Runtime = 'python'; Version = '3.11'; IsDefault = $true },
            @{ Runtime = 'python'; Version = '3.12'; IsDefault = $true },
            @{ Runtime = 'python'; Version = '3.13'; IsDefault = $false },
            @{ Runtime = 'custom'; Version = '1.0'; IsDefault = $false }
        )
        
        foreach ($testCase in $testCases) {
            $result = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime $testCase.Runtime -Version $testCase.Version
            $result | Should -Not -BeNullOrEmpty
            $result | Should -HaveCount 1
            $result.Name | Should -Be $testCase.Runtime
            $result.Version | Should -Be $testCase.Version
            $result.IsDefault | Should -Be $testCase.IsDefault
            $result.Sku.skuCode | Should -Be 'FC1'
        }
    }

    It 'Should handle invalid runtime gracefully' {
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'invalidruntime' } | Should -Throw
    }

    It 'Should handle invalid version gracefully' {
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'node' -Version '999.0' } | Should -Throw
    }

    It 'Should handle invalid location gracefully' {
        { Get-AzFunctionAppFlexConsumptionRuntime -Location 'Invalid Location' } | Should -Throw
    }

    It 'Should validate parameter combinations work correctly' {
        # Test that all parameter sets work without errors
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation } | Should -Not -Throw
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'node' } | Should -Not -Throw
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'node' -Version '22' } | Should -Not -Throw
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'node' -DefaultOrLatest } | Should -Not -Throw
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'python' -Version '3.12' } | Should -Not -Throw
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'powershell' -Version '7.4' } | Should -Not -Throw
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'java' -Version '21' } | Should -Not -Throw
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'dotnet-isolated' -Version '10.0' } | Should -Not -Throw
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'custom' -Version '1.0' } | Should -Not -Throw
    }
}

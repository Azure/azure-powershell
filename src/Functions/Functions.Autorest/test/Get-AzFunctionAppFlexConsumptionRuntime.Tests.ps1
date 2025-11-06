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
        $runtimes[0] | Should -HaveProperty 'Name'
        $runtimes[0] | Should -HaveProperty 'Version'
        $runtimes[0] | Should -HaveProperty 'IsDefault'
        $runtimes[0] | Should -HaveProperty 'EndOfLifeDate'
        $runtimes[0] | Should -HaveProperty 'Sku'
        
        # Verify expected runtimes are available for Flex Consumption
        $runtimeNames = $runtimes | Select-Object -ExpandProperty Name -Unique
        $runtimeNames | Should -Contain 'dotnet-isolated'
        $runtimeNames | Should -Contain 'node'
        $runtimeNames | Should -Contain 'python'
        $runtimeNames | Should -Contain 'java'
    }

    It 'Should get specific runtime versions for dotnet-isolated' {
        $dotnetRuntimes = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'dotnet-isolated'
        
        $dotnetRuntimes | Should -Not -BeNullOrEmpty
        $dotnetRuntimes | ForEach-Object { 
            $_.Name | Should -Be 'dotnet-isolated'
            $_.Version | Should -Not -BeNullOrEmpty
            $_.IsDefault | Should -BeOfType [System.Boolean]
            $_.Sku.skuCode | Should -Be 'FC1'
        }
        
        # Should contain common .NET versions
        $versions = $dotnetRuntimes | Select-Object -ExpandProperty Version
        $versions | Should -Contain '8.0'
    }

    It 'Should get specific runtime versions for node' {
        $nodeRuntimes = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'node'
        
        $nodeRuntimes | Should -Not -BeNullOrEmpty
        $nodeRuntimes | ForEach-Object { 
            $_.Name | Should -Be 'node'
            $_.Version | Should -Not -BeNullOrEmpty
            $_.IsDefault | Should -BeOfType [System.Boolean]
            $_.Sku.skuCode | Should -Be 'FC1'
        }
        
        # Should contain common Node.js versions (updated to actual supported versions)
        $versions = $nodeRuntimes | Select-Object -ExpandProperty Version
        $versions | Should -Contain '20'
        $versions | Should -Contain '22'
    }

    It 'Should get specific runtime versions for python' {
        $pythonRuntimes = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'python'
        
        $pythonRuntimes | Should -Not -BeNullOrEmpty
        $pythonRuntimes | ForEach-Object { 
            $_.Name | Should -Be 'python'
            $_.Version | Should -Not -BeNullOrEmpty
            $_.IsDefault | Should -BeOfType [System.Boolean]
            $_.Sku.skuCode | Should -Be 'FC1'
        }
        
        # Should contain common Python versions
        $versions = $pythonRuntimes | Select-Object -ExpandProperty Version
        $versions | Should -Contain '3.10'
        $versions | Should -Contain '3.11'
        $versions | Should -Contain '3.12'
        $versions | Should -Contain '3.13'
    }

    It 'Should get specific runtime versions for java' {
        $javaRuntimes = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'java'
        
        $javaRuntimes | Should -Not -BeNullOrEmpty
        $javaRuntimes | ForEach-Object { 
            $_.Name | Should -Be 'java'
            $_.Version | Should -Not -BeNullOrEmpty
            $_.IsDefault | Should -BeOfType [System.Boolean]
            $_.Sku.skuCode | Should -Be 'FC1'
        }
        
        # Should contain common Java versions (updated to actual supported versions)
        $versions = $javaRuntimes | Select-Object -ExpandProperty Version
        $versions | Should -Contain '17'
        $versions | Should -Contain '21'
    }

    It 'Should get specific runtime and version combination' {
        $specificRuntime = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'dotnet-isolated' -Version '8.0'
        
        $specificRuntime | Should -Not -BeNullOrEmpty
        $specificRuntime.Name | Should -Be 'dotnet-isolated'
        $specificRuntime.Version | Should -Be '8.0'
        $specificRuntime | Should -HaveProperty 'IsDefault'
        $specificRuntime | Should -HaveProperty 'EndOfLifeDate'
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
            # Required properties
            $runtime | Should -HaveProperty 'Name'
            $runtime | Should -HaveProperty 'Version'
            $runtime | Should -HaveProperty 'IsDefault'
            $runtime | Should -HaveProperty 'EndOfLifeDate'
            $runtime | Should -HaveProperty 'Sku'
            
            # Validate property types and values
            $runtime.Name | Should -Be 'python'
            $runtime.Version | Should -Not -BeNullOrEmpty
            $runtime.IsDefault | Should -BeOfType [System.Boolean]
            $runtime.EndOfLifeDate | Should -Not -BeNullOrEmpty
            $runtime.Sku | Should -Not -BeNull
            $runtime.Sku.skuCode | Should -Be 'FC1'
            
            # Validate Sku object has expected properties
            $runtime.Sku | Should -HaveProperty 'skuCode'
            $runtime.Sku | Should -HaveProperty 'instanceMemoryMB'
            $runtime.Sku | Should -HaveProperty 'maximumInstanceCount'
            $runtime.Sku | Should -HaveProperty 'functionAppConfigProperties'
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
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'node' -Version '20' } | Should -Not -Throw
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'node' -DefaultOrLatest } | Should -Not -Throw
    }
}

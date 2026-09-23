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

# Please note that these tests can run in Playback mode only when executed locally. They fail in the pipeline due to the environment.
# However, they can be used for local deployment in Playback mode.
# Describe 'Get-AzFunctionAppFlexConsumptionRuntime' {
Describe 'Get-AzFunctionAppFlexConsumptionRuntime' -Tag 'LiveOnly' {
    
    BeforeAll {
        $testLocation = 'East Asia'
        $cutoffDate = [DateTime]'11/9/2026'

        function Assert-ContainsAll {
            param(
                [Parameter(Mandatory)] $Actual,
                [Parameter(Mandatory)] [string[]] $Expected,
                [string] $Label = 'collection'
            )
            foreach ($e in $Expected) {
                $Actual | Should -Contain $e -Because "'$e' must be present in $Label"
            }
        }
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
    }

    It 'Should get current runtime stack versions with extended support' {
        $allRuntimes = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation
        
        # Test current supported runtime stack versions
        $currentStackRuntimes = $allRuntimes | Where-Object {
            ($_.Name -eq 'custom') -or 
            ([DateTime]::Parse($_.EndOfLifeDate) -ge $cutoffDate)
        }
        
        $currentStackRuntimes | Should -Not -BeNullOrEmpty

        # Test each runtime has expected current stack versions
        $dotnetCurrent = $currentStackRuntimes | Where-Object { $_.Name -eq 'dotnet-isolated' }
        Write-Verbose "Current .NET Isolated versions: $($dotnetCurrent.Version -join ', ')" -Verbose
        $actualDotnet = $dotnetCurrent.Version | Sort-Object -Unique
        Assert-ContainsAll -Actual $actualDotnet -Expected @('10.0','8.0') -Label '.NET isolated versions'
        
        $nodeCurrent = $currentStackRuntimes | Where-Object { $_.Name -eq 'node' }
        Write-Verbose "Current Node versions: $($nodeCurrent.Version -join ', ')" -Verbose
        $actualNode = $nodeCurrent.Version | Sort-Object -Unique
        Assert-ContainsAll -Actual $actualNode -Expected @('22') -Label 'Node versions'
        
        $javaCurrent = $currentStackRuntimes | Where-Object { $_.Name -eq 'java' }
        Write-Verbose "Current Java versions: $($javaCurrent.Version -join ', ')" -Verbose
        $actualJava = $javaCurrent.Version | Sort-Object -Unique
        Assert-ContainsAll -Actual $actualJava -Expected @('17', '21') -Label 'Java versions'
        
        $powershellCurrent = $currentStackRuntimes | Where-Object { $_.Name -eq 'powershell' }
        Write-Verbose "Current PowerShell versions: $($powershellCurrent.Version -join ', ')" -Verbose
        $actualPowershell = $powershellCurrent.Version | Sort-Object -Unique
        Assert-ContainsAll -Actual $actualPowershell -Expected @('7.4') -Label 'PowerShell versions'
        
        $pythonCurrent = $currentStackRuntimes | Where-Object { $_.Name -eq 'python' }
        Write-Verbose "Current Python versions: $($pythonCurrent.Version -join ', ')" -Verbose
        $actualPython = $pythonCurrent.Version | Sort-Object -Unique
        Assert-ContainsAll -Actual $actualPython -Expected @('3.11', '3.12', '3.13') -Label 'Python versions'
        
        $customCurrent = $currentStackRuntimes | Where-Object { $_.Name -eq 'custom' }
        Write-Verbose "Current Custom versions: $($customCurrent.Version -join ', ')" -Verbose
        $actualCustom = $customCurrent.Version | Sort-Object -Unique
        Assert-ContainsAll -Actual $actualCustom -Expected @('1.0') -Label 'Custom versions'
    }

    It 'Should validate default runtime versions for current stack' {
        # Test default versions for each runtime (focusing on current/recommended versions)
        $testCases = @(
            @{ Runtime = 'dotnet-isolated'; Version = '8.0'; IsDefault = $true; Description = 'LTS version' },
            @{ Runtime = 'node'; Version = '22'; IsDefault = $true; Description = 'Current LTS' },
            @{ Runtime = 'java'; Version = '17'; IsDefault = $true; Description = 'LTS version' },
            @{ Runtime = 'powershell'; Version = '7.4'; IsDefault = $true; Description = 'Current stable' },
            @{ Runtime = 'python'; Version = '3.12'; IsDefault = $true; Description = 'Latest stable' },
            @{ Runtime = 'custom'; Version = '1.0'; IsDefault = $false; Description = 'Custom handler' }
        )
        
        foreach ($testCase in $testCases) {
            $result = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime $testCase.Runtime -Version $testCase.Version
            $result | Should -Not -BeNullOrEmpty -Because "Should find $($testCase.Runtime) $($testCase.Version) ($($testCase.Description))"
            $result | Should -HaveCount 1
            $result.Name | Should -Be $testCase.Runtime
            $result.Version | Should -Be $testCase.Version
            $result.IsDefault | Should -Be $testCase.IsDefault
            $result.Sku.skuCode | Should -Be 'FC1'
        }
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
        $defaultRuntime.Version | Should -Be '22'  # Current default
        
        # Should return only one runtime (the default/latest)
        $defaultRuntime | Should -HaveCount 1
        
        # Should have IsDefault set to True for default runtime
        $defaultRuntime.IsDefault | Should -Be $true
    }

    It 'Should validate runtime objects have correct structure' {
        # Test with python as it has multiple versions
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

    It 'Should validate EndOfLifeDate for current runtime stack versions' {
        # Focus on current supported runtime stack versions
        $currentStackVersions = @(
            'dotnet-isolated|8.0', 'dotnet-isolated|10.0',
            'node|22',
            'java|17', 'java|21',
            'powershell|7.4',
            'python|3.11', 'python|3.12', 'python|3.13'
        )
        
        foreach ($runtimeVersionPair in $currentStackVersions) {
            $parts = $runtimeVersionPair -split '\|'
            $runtime = $parts[0]
            $version = $parts[1]
            
            $result = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime $runtime -Version $version
            
            # EndOfLifeDate should be parseable as DateTime
            { [DateTime]::Parse($result.EndOfLifeDate) } | Should -Not -Throw -Because "$runtime $version should have valid EndOfLifeDate"
            
            # EndOfLifeDate should be in the future for current versions
            $eolDate = [DateTime]::Parse($result.EndOfLifeDate)
            $eolDate | Should -BeGreaterOrEqual $cutoffDate -Because "$runtime $version should be part of current runtime stack"
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

    It 'Should get specific runtime and version for all current stack versions' {
        # Test specific current runtime stack combinations
        $testCases = @(
            @{ Runtime = 'dotnet-isolated'; Version = '8.0'},
            @{ Runtime = 'dotnet-isolated'; Version = '10.0'},
            @{ Runtime = 'node'; Version = '22'},
            @{ Runtime = 'java'; Version = '17'},
            @{ Runtime = 'java'; Version = '21'},
            @{ Runtime = 'powershell'; Version = '7.4'},
            @{ Runtime = 'python'; Version = '3.11'},
            @{ Runtime = 'python'; Version = '3.12'},
            @{ Runtime = 'python'; Version = '3.13'},
            @{ Runtime = 'custom'; Version = '1.0'}
        )
        
        foreach ($testCase in $testCases) {
            $result = Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime $testCase.Runtime -Version $testCase.Version
            $result | Should -Not -BeNullOrEmpty
            $result | Should -HaveCount 1
            $result.Name | Should -Be $testCase.Runtime
            $result.Version | Should -Be $testCase.Version
            $result.Sku.skuCode | Should -Be 'FC1'
        }
    }

    It 'Should handle invalid runtime gracefully' {
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'invalidruntime' } | Should -Throw
    }

    It 'Should handle invalid version gracefully' {
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'node' -Version '999.0' } | Should -Throw
    }

    It 'Should throw RuntimeVersionNotSupportedInFlexConsumption for unsupported runtime versions' {
        # Test cases for unsupported runtime versions that should trigger the specific error
        $unsupportedVersionCases = @(
            @{ Runtime = 'powershell'; Version = '9.0'; SupportedVersions = '7.4' },
            @{ Runtime = 'node'; Version = '18'; SupportedVersions = '20, 22' },
            @{ Runtime = 'python'; Version = '3.8'; SupportedVersions = '3.10, 3.11, 3.12, 3.13' },
            @{ Runtime = 'java'; Version = '11'; SupportedVersions = '17, 21' },
            @{ Runtime = 'dotnet-isolated'; Version = '6.0'; SupportedVersions = '8.0, 9.0, 10.0' }
        )

        foreach ($testCase in $unsupportedVersionCases) {
            $errorThrown = $null
            try {
                Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime $testCase.Runtime -Version $testCase.Version -ErrorAction Stop
            }
            catch {
                $errorThrown = $_
            }

            # Validate that an error was thrown
            $errorThrown | Should -Not -BeNull -Because "Should throw error for unsupported $($testCase.Runtime) version $($testCase.Version)"
            
            # Validate the FullyQualifiedErrorId
            $errorThrown.FullyQualifiedErrorId | Should -Be 'RuntimeVersionNotSupportedInFlexConsumption' -Because "Should have correct error ID for $($testCase.Runtime) $($testCase.Version)"
            
            # Validate the error message contains expected information
            $errorThrown.Exception.Message | Should -Match "Invalid version $($testCase.Version) for runtime $($testCase.Runtime)" -Because "Error message should contain version and runtime info"
            $errorThrown.Exception.Message | Should -Match "function apps on the Flex Consumption plan" -Because "Error message should specify Flex Consumption plan"
            $errorThrown.Exception.Message | Should -Match "Supported versions for runtime $($testCase.Runtime)" -Because "Error message should list supported versions"
        }
    }

    It 'Should handle invalid location gracefully' {
        { Get-AzFunctionAppFlexConsumptionRuntime -Location 'Invalid Location' } | Should -Throw
    }

    It 'Should validate parameter combinations work correctly' {
        # Test that all parameter sets work without errors (using current stack versions)
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation } | Should -Not -Throw
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'node' } | Should -Not -Throw
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'node' -Version '22' } | Should -Not -Throw
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'node' -DefaultOrLatest } | Should -Not -Throw
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'python' -Version '3.12' } | Should -Not -Throw
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'powershell' -Version '7.4' } | Should -Not -Throw
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'java' -Version '17' } | Should -Not -Throw
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'dotnet-isolated' -Version '8.0' } | Should -Not -Throw
        { Get-AzFunctionAppFlexConsumptionRuntime -Location $testLocation -Runtime 'custom' -Version '1.0' } | Should -Not -Throw
    }

    It "Get-AzFunctionAppFlexConsumptionRuntime should throw RegionNotSupportedForFlexConsumption for invalid region" {

        $myError = $null
        $errorId = "RegionNotSupportedForFlexConsumption"
        $invalidLocation = "invalidregion"

        try
        {
            Get-AzFunctionAppFlexConsumptionRuntime -Location $invalidLocation -ErrorAction Stop
        }
        catch
        {
            Write-Verbose "Catch the expected exception" -Verbose
            $myError = $_
        }

        Write-Verbose "Validate FullyQualifiedErrorId" -Verbose
        $myError.FullyQualifiedErrorId | Should Be $errorId
    }
}

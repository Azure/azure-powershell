$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFunctionAppAvailableLocation.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzFunctionAppAvailableLocation' {

    It 'Validate set default parameters for -PlanType and -OSType' {

        try
        {
            $filePath = Join-Path $PSScriptRoot "verboseOutput.log"

            &{ Get-AzFunctionAppAvailableLocation } 4>&1 2>&1 > $filePath

            $logFileContent = Get-Content -Path $filePath -Raw
            $logFileContent | Should Match "PlanType not specified. Setting default PlanType to 'Premium'."
            $logFileContent | Should Match "OSType not specified. Setting default OSType to 'Windows'."
        }
        finally
        {
            if (Test-Path $filePath)
            {
                Remove-Item $filePath -Force -ErrorAction SilentlyContinue
            }
        }
    }

    It 'Validate output for -PlanType Premium -OSType Linux' {

        $expectedRegions = @(
            'Central US'
            'North Europe'
            'West Europe'
            'Southeast Asia'
            'East Asia'
            'West US'
            'East US'
            'Japan West'
            'Japan East'
            'East US 2'
            'North Central US'
            'South Central US'
            'Brazil South'
            'Australia East'
            'Australia Southeast'
            'West India'
            'Canada Central'
            'West Central US'
            'West US 2'
            'UK West'
            'UK South'
            'Central US EUAP'
            'Korea Central'
            'France Central'
            'Norway East'
        )

        $actualRegions = @(Get-AzFunctionAppAvailableLocation -PlanType Premium -OSType Linux | ForEach-Object { $_.Name })
        ValidateAvailableLocation -ActualRegions $actualRegions -ExpectedRegions $expectedRegions
    }

    It 'Validate output for -PlanType Premium -OSType Windows' {

        $expectedRegions = @(
            'Central US'
            'North Europe'
            'West Europe'
            'Southeast Asia'
            'East Asia'
            'West US'
            'East US'
            'Japan West'
            'Japan East'
            'East US 2'
            'North Central US'
            'South Central US'
            'Brazil South'
            'Australia East'
            'Australia Southeast'
            'East Asia (Stage)'
            'West India'
            'South India'
            'Canada Central'
            'West US 2'
            'UK West'
            'UK South'
            'East US 2 EUAP'
            'Central US EUAP'
            'Korea Central'
            'France Central'
            'Australia Central 2'
            'Australia Central'
            'Germany West Central'
            'Norway East'
        )

        $actualRegions = @(Get-AzFunctionAppAvailableLocation -PlanType Premium -OSType Windows | ForEach-Object { $_.Name })
        ValidateAvailableLocation -ActualRegions $actualRegions -ExpectedRegions $expectedRegions
    }

    It 'Validate output for -PlanType Consumption -OSType Linux' {

        $expectedRegions = @(
            'Central US'
            'North Europe'
            'West Europe'
            'Southeast Asia'
            'East Asia'
            'West US'
            'East US'
            'Japan West'
            'Japan East'
            'East US 2'
            'North Central US'
            'South Central US'
            'Brazil South'
            'Australia East'
            'Australia Southeast'
            'Central India'
            'West India'
            'South India'
            'Canada Central'
            'Canada East'
            'West Central US'
            'West US 2'
            'UK West'
            'UK South'
            'East US 2 EUAP'
            'Central US EUAP'
            'Korea South'
            'Korea Central'
            'France Central'
            'Australia Central 2'
            'Australia Central'
            'South Africa North'
            'South Africa West'
            'Switzerland North'
            'Germany West Central'
            'Norway East'
        )

        $actualRegions = @(Get-AzFunctionAppAvailableLocation -PlanType Consumption -OSType Linux | ForEach-Object { $_.Name })
        ValidateAvailableLocation -ActualRegions $actualRegions -ExpectedRegions $expectedRegions
    }

    It 'Validate output for -PlanType Consumption -OSType Windows' {

        $expectedRegions = @(
            'Central US'
            'North Europe'
            'West Europe'
            'Southeast Asia'
            'East Asia'
            'West US'
            'East US'
            'Japan West'
            'Japan East'
            'East US 2'
            'North Central US'
            'South Central US'
            'Brazil South'
            'Australia East'
            'Australia Southeast'
            'Central India'
            'West India'
            'South India'
            'Canada Central'
            'Canada East'
            'West Central US'
            'West US 2'
            'UK West'
            'UK South'
            'East US 2 EUAP'
            'Central US EUAP'
            'Korea Central'
            'France Central'
            'Australia Central 2'
            'Australia Central'
            'South Africa North'
            'Switzerland North'
            'Germany West Central'
        )

        $actualRegions = @(Get-AzFunctionAppAvailableLocation -PlanType Consumption -OSType Windows | ForEach-Object { $_.Name })
        ValidateAvailableLocation -ActualRegions $actualRegions -ExpectedRegions $expectedRegions
    }

    It 'Validate output for -PlanType FlexConsumption' {

        $expectedRegions = @(
            'Canada Central'
            'North Europe'
            'West Europe'
            'Southeast Asia'
            'East Asia'
            'West US'
            'Japan West'
            'Japan East'
            'East US 2'
            'North Central US'
            'South Central US'
            'Brazil South'
            'Australia East'
            'Australia Southeast'
            'Central US'
            'East US'
            'North Central US (Stage)'
            'Central India'
            'South India'
            'Canada East'
            'West Central US'
            'West US 2'
            'UK West'
            'UK South'
            'East US 2 EUAP'
            'Korea Central'
            'France South'
            'France Central'
            'South Africa North'
            'Switzerland North'
            'Germany West Central'
            'Switzerland West'
            'UAE North'
            'Norway East'
            'West US 3'
            'Sweden Central'
            'Poland Central'
            'Italy North'
            'Israel Central'
            'Spain Central'
            'Mexico Central'
            'Taiwan North'
            'Taiwan Northwest'
            'New Zealand North'
            'Indonesia Central'
            'Malaysia West'
        )

        $actualRegions = @(Get-AzFunctionAppAvailableLocation -PlanType FlexConsumption | ForEach-Object { $_.Name })
        ValidateAvailableLocation -ActualRegions $actualRegions -ExpectedRegions $expectedRegions
    }

    It 'Validate output for -PlanType FlexConsumption -OSType Linux should not error out' {

        $expectedRegions = @(
            'Canada Central'
            'North Europe'
            'West Europe'
            'Southeast Asia'
            'East Asia'
            'West US'
            'Japan West'
            'Japan East'
            'East US 2'
            'North Central US'
            'South Central US'
            'Brazil South'
            'Australia East'
            'Australia Southeast'
            'Central US'
            'East US'
            'North Central US (Stage)'
            'Central India'
            'South India'
            'Canada East'
            'West Central US'
            'West US 2'
            'UK West'
            'UK South'
            'East US 2 EUAP'
            'Korea Central'
            'France South'
            'France Central'
            'South Africa North'
            'Switzerland North'
            'Germany West Central'
            'Switzerland West'
            'UAE North'
            'Norway East'
            'West US 3'
            'Sweden Central'
            'Poland Central'
            'Italy North'
            'Israel Central'
            'Spain Central'
            'Mexico Central'
            'Taiwan North'
            'Taiwan Northwest'
            'New Zealand North'
            'Indonesia Central'
            'Malaysia West'
        )

        $actualRegions = @(Get-AzFunctionAppAvailableLocation -PlanType FlexConsumption -OSType Linux | ForEach-Object { $_.Name })
        ValidateAvailableLocation -ActualRegions $actualRegions -ExpectedRegions $expectedRegions
    }

    It 'Validate -PlanType FlexConsumption -OSType Windows fails' {

        $expectedErrorMessage = "FlexConsumption plan type is only supported on Linux OS type."
        $expectedErrorId = "FlexConsumptionIsOnlySupportedOnLinux"

        $myError = $null
        try
        {
            Get-AzFunctionAppAvailableLocation -PlanType FlexConsumption -OSType Windows -ErrorAction Stop
        }
        catch
        {
            Write-Verbose "Catch the expected exception" -Verbose
            $myError = $_
        }

        Write-Verbose "Validate FullyQualifiedErrorId" -Verbose
        $myError.FullyQualifiedErrorId | Should Be $expectedErrorId
        Write-Verbose "Validate Exception.Message" -Verbose
        $myError.Exception.Message | Should Match $expectedErrorMessage
    }

    It 'Validate output for -PlanType FlexConsumption -ZoneRedundancy' {

        $expectedRegions = @(
            'Canada Central'
            'Southeast Asia'
            'East Asia'
            'Australia East'
            'East US'
            'Central India'
            'UK South'
            'East US 2 EUAP'
            'South Africa North'
            'Germany West Central'
            'UAE North'
            'Norway East'
            'West US 3'
            'Sweden Central'
            'Italy North'
            'Israel Central'
        )

        $actualRegions = @(Get-AzFunctionAppAvailableLocation -PlanType FlexConsumption -ZoneRedundancy | ForEach-Object { $_.Name })
        ValidateAvailableLocation -ActualRegions $actualRegions -ExpectedRegions $expectedRegions
    }

    It "Validate -PlanType Premium -OSType Windows -ZoneRedundancy fails" {

        $expectedErrorMessage = "The ZoneRedundancy parameter is only applicable for FlexConsumption plan type."
        $expectedErrorId = "ZoneRedundancyIsOnlyApplicableForFlexConsumption"

        $myError = $null
        try
        {
            Get-AzFunctionAppAvailableLocation -PlanType Premium -OSType Windows -ZoneRedundancy -ErrorAction Stop
        }
        catch
        {
            Write-Verbose "Catch the expected exception" -Verbose
            $myError = $_
        }

        Write-Verbose "Validate FullyQualifiedErrorId" -Verbose
        $myError.FullyQualifiedErrorId | Should Be $expectedErrorId
        Write-Verbose "Validate Exception.Message" -Verbose
        $myError.Exception.Message | Should Match $expectedErrorMessage
    }
}

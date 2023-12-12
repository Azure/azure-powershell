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
}

BeforeAll {
    if (-not (Get-Module AzDev)) {
        Import-Module "$PSScriptRoot/../../../../artifacts/AzDev/AzDev.psd1"
    }
}

Describe 'Repo inventory' {
    It 'Every autorest project should have either a Wrapper or SdkBased project' {
        (Get-DevModule).Project.Count | Should -BeGreaterThan 0
        Get-DevModule | ForEach-Object{
            if ($_.Project.Type -contains "AutoRestBased") {
                $_.Project.Type -contains "Wrapper" -or $_.Project.Type -contains "SdkBased" | Should -BeTrue
            }
        }
    }

    It 'The number of unidentified project types should not grow' {
        $others = Get-DevProject -Type Other
        $others.Count | Should -BeLessOrEqual 8
    }
}

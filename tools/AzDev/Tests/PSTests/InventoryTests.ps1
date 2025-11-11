BeforeAll {
    if (-not (Get-Module AzDev)) {
        Import-Module "$PSScriptRoot/../../../../artifacts/AzDev/AzDev.psd1"
    }
}

Describe 'Repo inventory' {
    It 'Should get all modules and projects' {
        (Get-DevModule).Count | Should -BeGreaterThan 0
        (Get-DevProject -Type Wrapper).Count | Should -BeGreaterThan 0
        (Get-DevProject -Type SdkBased).Count | Should -BeGreaterThan 0
        (Get-DevProject -Type AutoRestBased).Count | Should -BeGreaterThan 0
    }

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

    It 'AutoRest projects expose a valid SubType (AutoRest version)' {
        $proj = Get-DevProject -Type AutoRestBased
        $proj | Should -Not -BeNullOrEmpty
        $proj.SubType | Should -Match '^(v3|v4)$'
    }
}

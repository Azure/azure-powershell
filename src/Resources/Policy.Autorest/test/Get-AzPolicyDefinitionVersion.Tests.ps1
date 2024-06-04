# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'GetPolicyDefinitionVersion'

Describe 'GetPolicyDefinitionVersion' {

    BeforeAll {
        $customDefinition = $env.customSubDefinition
    }

    It 'Get-AzPolicyDefinition -Name <nonexistent>' {
        {
            Get-AzPolicyDefinition -Name $someName
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'Get-AzPolicyDefinition -Version' {
        {
            Get-AzPolicyDefinition -Version '1.0.0'
        } | Should -Throw $versionRequiresNameOrId
    }

    It 'Get-AzPolicyDefinition -ListVersion' {
        {
            Get-AzPolicyDefinition -ListVersion
        } | Should -Throw $ListVersionRequiresNameOrId
    }

    It 'Get-AzPolicyDefinition -Name <nonexistent> -Version <missing>' {
        {
            Get-AzPolicyDefinition -Name $someName -Version
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicyDefinition -Name <custom>' {
        $result = Get-AzPolicyDefinition -Name $customDefinition.Name
        $version = $result.Version
        $version | Should -Not -BeNullOrEmpty
        $result.Version | Should -Be $version
        $result.Versions | Should -Be @($version)
    }

    It 'Get-AzPolicyDefinition -Name <custom> -Version' {
        $result = Get-AzPolicyDefinition -Name $customDefinition.Name -Version '1.0.0'
        $result.Version | Should -Be '1.0.0'
        $result.Versions | Should -BeNull
    }

    It 'Get-AzPolicyDefinition -Name <custom> -ListVersion' {
        $result = Get-AzPolicyDefinition -Name $customDefinition.Name -ListVersion
        $result.Version | Should -Be '1.0.0'
        $result.Versions | Should -BeNull
    }

    It 'Get-AzPolicyDefinition -Name <builtin> -Version' {
        $expected = Get-AzPolicyDefinition -Builtin | ?{ $_.Versions.Count -gt 2 } | select -First 1
        $expected.Versions.Count | Should -BeGreaterThan 2
        $version = $expected.Versions[1]
        $version | Should -Not -BeNullOrEmpty
        $actual = Get-AzPolicyDefinition -Name $expected.Name -Version $version
        $actual.Version | Should -Be $version
    }

    It 'Get-AzPolicyDefinition -Name <builtin> -ListVersion' {
        $expected = Get-AzPolicyDefinition -Builtin | ?{ $_.Versions.Count -gt 2 } | select -Last 1
        $expected.Versions.Count | Should -BeGreaterThan 2
        $version = $expected.Versions[1]
        $version | Should -Not -BeNullOrEmpty
        $actual = Get-AzPolicyDefinition -Name $expected.Name -ListVersion
        $actual.Count | Should -BeGreaterThan 2
        @($actual.Version) | sort | Should -Be ($expected.Versions | sort)
    }

    It 'Get-AzPolicyDefinition -Id <custom>' {
        $result = Get-AzPolicyDefinition -Id $customDefinition.Id
        $version = $result.Version
        $version | Should -Not -BeNullOrEmpty
        $result.Version | Should -Be $version
        $result.Versions | Should -Be @($version)
    }

    It 'Get-AzPolicyDefinition -Id <custom> -Version' {
        $result = Get-AzPolicyDefinition -Id $customDefinition.Id -Version '1.0.0'
        $result.Version | Should -Be '1.0.0'
        $result.Versions | Should -BeNull
    }

    It 'Get-AzPolicyDefinition -Id <custom> -ListVersion' {
        $result = Get-AzPolicyDefinition -Id $customDefinition.Id -ListVersion
        $result.Version | Should -Be '1.0.0'
        $result.Versions | Should -BeNull
    }

    It 'Get-AzPolicyDefinition -Id <builtin> -Version' {
        $expected = Get-AzPolicyDefinition -Builtin | ?{ $_.Versions.Count -gt 2 } | select -First 1
        $expected.Versions.Count | Should -BeGreaterThan 2
        $version = $expected.Versions[1]
        $version | Should -Not -BeNullOrEmpty
        $actual = Get-AzPolicyDefinition -Id $expected.Id -Version $version
        $actual.Version | Should -Be $version
    }

    It 'Get-AzPolicyDefinition -Id <builtin> -ListVersion' {
        $expected = Get-AzPolicyDefinition -Builtin | ?{ $_.Versions.Count -gt 2 } | select -Last 1
        $expected.Versions.Count | Should -BeGreaterThan 2
        $version = $expected.Versions[1]
        $version | Should -Not -BeNullOrEmpty
        $actual = Get-AzPolicyDefinition -Id $expected.Id -ListVersion
        $actual.Count | Should -BeGreaterThan 2
        @($actual.Version) | sort | Should -Be ($expected.Versions | sort)
    }
}

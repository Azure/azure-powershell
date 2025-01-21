# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'GetPolicySetDefinitionVersion'

Describe 'GetPolicySetDefinitionVersion' -Tag 'LiveOnly' {

    BeforeAll {
        $customSetDefinition = $env.customSubSetDefinition
    }

    It 'Get-AzPolicySetDefinition -Name <nonexistent>' {
        {
            Get-AzPolicySetDefinition -Name $someName
        } | Should -Throw $PolicySetDefinitionNotFound
    }

    It 'Get-AzPolicySetDefinition -Version' {
        {
            Get-AzPolicySetDefinition -Version '1.0.0'
        } | Should -Throw $versionRequiresNameOrId
    }

    It 'Get-AzPolicySetDefinition -ListVersion' {
        {
            Get-AzPolicySetDefinition -ListVersion
        } | Should -Throw $ListVersionRequiresNameOrId
    }

    It 'Get-AzPolicySetDefinition -Name <nonexistent> -Version <missing>' {
        {
            Get-AzPolicySetDefinition -Name $someName -Version
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicySetDefinition -Name <custom>' {
        $result = Get-AzPolicySetDefinition -Name $customSetDefinition.Name
        $version = $result.Version
        $version | Should -Not -BeNullOrEmpty
        $result.Version | Should -Be $version
        $result.Versions | Should -Be @($version)
    }

    It 'Get-AzPolicySetDefinition -Name <custom> -Version' {
        $result = Get-AzPolicySetDefinition -Name $customSetDefinition.Name -Version '1.0.0'
        $result.Version | Should -Be '1.0.0'
        $result.Versions | Should -BeNull
    }

    It 'Get-AzPolicySetDefinition -Name <custom> -ListVersion' {
        $result = Get-AzPolicySetDefinition -Name $customSetDefinition.Name -ListVersion
        $result.Version | Should -Be '1.0.0'
        $result.Versions | Should -BeNull
    }

    It 'Get-AzPolicySetDefinition -Name <builtin> -Version' {
        $expected = Get-AzPolicySetDefinition -Builtin | ?{ $_.Versions.Count -gt 2 } | select -First 1
        $expected.Versions.Count | Should -BeGreaterThan 2
        $version = $expected.Versions[1]
        $version | Should -Not -BeNullOrEmpty
        $actual = Get-AzPolicySetDefinition -Name $expected.Name -Version $version
        $actual.Version | Should -Be $version
    }

    It 'Get-AzPolicySetDefinition -Name <builtin> -ListVersion' {
        $expected = Get-AzPolicySetDefinition -Builtin | ?{ $_.Versions.Count -gt 2 } | select -Last 1
        $expected.Versions.Count | Should -BeGreaterThan 2
        $version = $expected.Versions[1]
        $version | Should -Not -BeNullOrEmpty
        $actual = Get-AzPolicySetDefinition -Name $expected.Name -ListVersion
        $actual.Count | Should -BeGreaterThan 2
        @($actual.Version) | sort | Should -Be ($expected.Versions | sort)
    }

    It 'Get-AzPolicySetDefinition -Id <custom>' {
        $result = Get-AzPolicySetDefinition -Id $customSetDefinition.Id
        $version = $result.Version
        $version | Should -Not -BeNullOrEmpty
        $result.Version | Should -Be $version
        $result.Versions | Should -Be @($version)
    }

    It 'Get-AzPolicySetDefinition -Id <custom> -Version' {
        $result = Get-AzPolicySetDefinition -Id $customSetDefinition.Id -Version '1.0.0'
        $result.Version | Should -Be '1.0.0'
        $result.Versions | Should -BeNull
    }

    It 'Get-AzPolicySetDefinition -Id <custom> -ListVersion' {
        $result = Get-AzPolicySetDefinition -Id $customSetDefinition.Id -ListVersion
        $result.Version | Should -Be '1.0.0'
        $result.Versions | Should -BeNull
    }

    It 'Get-AzPolicySetDefinition -Id <builtin> -Version' {
        $expected = Get-AzPolicySetDefinition -Builtin | ?{ $_.Versions.Count -gt 2 } | select -First 1
        $expected.Versions.Count | Should -BeGreaterThan 2
        $version = $expected.Versions[1]
        $version | Should -Not -BeNullOrEmpty
        $actual = Get-AzPolicySetDefinition -Id $expected.Id -Version $version
        $actual.Version | Should -Be $version
    }

    It 'Get-AzPolicySetDefinition -Id <builtin> -ListVersion' {
        $expected = Get-AzPolicySetDefinition -Builtin | ?{ $_.Versions.Count -gt 2 } | select -Last 1
        $expected.Versions.Count | Should -BeGreaterThan 2
        $version = $expected.Versions[1]
        $version | Should -Not -BeNullOrEmpty
        $actual = Get-AzPolicySetDefinition -Id $expected.Id -ListVersion
        $actual.Count | Should -BeGreaterThan 2
        @($actual.Version) | sort | Should -Be ($expected.Versions | sort)
    }
}

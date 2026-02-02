# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'GetPolicyDefinitionVersion'

Describe 'GetPolicyDefinitionVersion' -Tag 'LiveOnly' {

    BeforeAll {
        $customDefinition = $env.customSubDefinition
    }

    It 'Get-AzPolicyDefinition -Version' {
        {
            Get-AzPolicyDefinition -Version $defaultVersion
        } | Should -Throw $versionRequiresNameOrId
    }

    It 'Get-AzPolicyDefinition -Name -Version <missing>' {
        {
            Get-AzPolicyDefinition -Name $someName -Version
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicyDefinition -Name -Id -Version' {
        {
            Get-AzPolicyDefinition -Name $someName -Id $someId -Version $someNewVersion 
        } | Should -Throw $nameOrIdIdentifier
    }

    It 'Get-AzPolicyDefinition -ManagementGroupName -Id -Version' {
        {
            Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -Id $someId -Version $someNewVersion 
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -SubscriptionId -Id -Version' {
        {
            Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Id $someId -Version $someNewVersion 
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Name -ManagementGroupName -Version' {
        {
            Get-AzPolicyDefinition -Name $someName -ManagementGroupName $someManagementGroup -Version $someNewVersion 
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'Get-AzPolicyDefinition -Name -SubscriptionId -Version' {
        {
            Get-AzPolicyDefinition -Name $someName -SubscriptionId $subscriptionId -Version $someNewVersion 
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'Get-AzPolicyDefinition -ManagementGroupName -Version' {
        {
            Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -Version $someNewVersion 
        } | Should -Throw $versionRequiresNameOrId
    }

    It 'Get-AzPolicyDefinition -SubscriptionId -Version' {
        {
            Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Version $someNewVersion 
        } | Should -Throw $versionRequiresNameOrId
    }

    It 'Get-AzPolicyDefinition -ListVersion' {
        {
            Get-AzPolicyDefinition -ListVersion
        } | Should -Throw $listVersionRequiresNameOrId
    }

    It 'Get-AzPolicyDefinition -Name -Id -ListVersion' {
        {
            Get-AzPolicyDefinition -Name $someName -Id $someId -ListVersion
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -ManagementGroupName -Id -ListVersion' {
        {
            Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -Id $someId -ListVersion
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -SubscriptionId -Id -ListVersion' {
        {
            Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Id $someId -ListVersion 
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Name -ManagementGroupName -ListVersion' {
        {
            Get-AzPolicyDefinition -Name $someName -ManagementGroupName $someManagementGroup -ListVersion
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'Get-AzPolicyDefinition -Name -SubscriptionId -ListVersion' {
        {
            Get-AzPolicyDefinition -Name $someName -SubscriptionId $subscriptionId -ListVersion
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'Get-AzPolicyDefinition -ManagementGroupName -ListVersion' {
        {
            Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -ListVersion
        } | Should -Throw $listVersionRequiresNameOrId
    }

    It 'Get-AzPolicyDefinition -SubscriptionId -ListVersion' {
        {
            Get-AzPolicyDefinition -SubscriptionId $subscriptionId -ListVersion
        } | Should -Throw $listVersionRequiresNameOrId
    }

    It 'Get-AzPolicyDefinition -Name <custom>' {
        $result = Get-AzPolicyDefinition -Name $customDefinition.Name
        $version = $result.Version
        $version | Should -Not -BeNullOrEmpty
        $result.Version | Should -Be $version
        $result.Versions | Should -Be @($version)
        $result.PolicyRule | Should -Not -BeNull
    }

    It 'Get-AzPolicyDefinition -Name <custom> -Version' {
        $result = Get-AzPolicyDefinition -Name $customDefinition.Name -Version $defaultVersion
        $result.Version | Should -Be $defaultVersion
        $result.Versions | Should -BeNull
        $result.PolicyRule | Should -Not -BeNull
    }

    It 'Get-AzPolicyDefinition -Name <custom> -ListVersion' {
        $result = Get-AzPolicyDefinition -Name $customDefinition.Name -ListVersion
        $result.Version | Should -Be $defaultVersion
        $result.Versions | Should -BeNull
        $result.PolicyRule | Should -Not -BeNull
    }

    It 'Get-AzPolicyDefinition -Name <builtin> -Version' {
        $expected = Get-AzPolicyDefinition -Builtin | ?{ $_.Versions.Count -gt 2 } | select -First 1
        $expected.Versions.Count | Should -BeGreaterThan 2
        $expected.PolicyRule | Should -Not -BeNull
        $expected.Metadata | Should -Not -BeNull
        $version = $expected.Versions[1]
        $version | Should -Not -BeNullOrEmpty
        $actual = Get-AzPolicyDefinition -Name $expected.Name -Version $version
        $actual.Version | Should -Be $version
        $actual.PolicyRule | Should -Not -BeNullOrEmpty
        $actual.Metadata | Should -Not -BeNullOrEmpty
    }

    It 'Get-AzPolicyDefinition -Name <builtin> -ListVersion' {
        $expected = Get-AzPolicyDefinition -Builtin | ?{ $_.Versions.Count -gt 2 } | select -Last 1
        $expected.Versions.Count | Should -BeGreaterThan 2
        $expected.PolicyRule | Should -Not -BeNull
        $expected.Metadata | Should -Not -BeNull
        $version = $expected.Versions[1]
        $version | Should -Not -BeNullOrEmpty
        $actual = Get-AzPolicyDefinition -Name $expected.Name -ListVersion
        $actual.Count | Should -BeGreaterThan 2
        @($actual.Version) | sort | Should -Be ($expected.Versions | sort)
        (($actual | sort -Property version)[-1]).PolicyRule | Should -BeLike $expected.PolicyRule
        (($actual | sort -Property version)[-1]).Metadata | Should -BeLike $expected.Metadata
    }

    It 'Get-AzPolicyDefinition -Id <custom>' {
        $result = Get-AzPolicyDefinition -Id $customDefinition.Id
        $version = $result.Version
        $version | Should -Not -BeNullOrEmpty
        $result.Version | Should -Be $version
        $result.Versions | Should -Be @($version)
        $result.PolicyRule | Should -Not -BeNull
    }

    It 'Get-AzPolicyDefinition -Id <custom> -Version' {
        $result = Get-AzPolicyDefinition -Id $customDefinition.Id -Version $defaultVersion
        $result.Version | Should -Be $defaultVersion
        $result.Versions | Should -BeNull
        $result.PolicyRule | Should -Not -BeNull
    }

    It 'Get-AzPolicyDefinition -Id <custom> -ListVersion' {
        $result = Get-AzPolicyDefinition -Id $customDefinition.Id -ListVersion
        $result.Version | Should -Be $defaultVersion
        $result.Versions | Should -BeNull
        $result.PolicyRule | Should -Not -BeNull
    }

    It 'Get-AzPolicyDefinition -Id <builtin> -Version' {
        $expected = Get-AzPolicyDefinition -Builtin | ?{ $_.Versions.Count -gt 2 } | select -First 1
        $expected.Versions.Count | Should -BeGreaterThan 2
        $expected.PolicyRule | Should -Not -BeNull
        $expected.Metadata | Should -Not -BeNull
        $version = $expected.Versions[1]
        $version | Should -Not -BeNullOrEmpty
        $actual = Get-AzPolicyDefinition -Id $expected.Id -Version $version
        $actual.Version | Should -Be $version
        $actual.PolicyRule | Should -Not -BeNullOrEmpty
        $actual.Metadata | Should -Not -BeNullOrEmpty
    }

    It 'Get-AzPolicyDefinition -Id <builtin> -ListVersion' {
        $expected = Get-AzPolicyDefinition -Builtin | ?{ $_.Versions.Count -gt 2 } | select -Last 1
        $expected.Versions.Count | Should -BeGreaterThan 2
        $expected.PolicyRule | Should -Not -BeNull
        $expected.Metadata | Should -Not -BeNull
        $version = $expected.Versions[1]
        $version | Should -Not -BeNullOrEmpty
        $actual = Get-AzPolicyDefinition -Id $expected.Id -ListVersion
        $actual.Count | Should -BeGreaterThan 2
        @($actual.Version) | sort | Should -Be ($expected.Versions | sort)
        @($actual.PolicyRule | %{ $_ -like $expected.PolicyRule }).Count | Should -BeGreaterThan 0
        @($actual.Metadata | %{ $_ -like $expected.Metadata }).Count | Should -BeGreaterThan 0
        (($actual | sort -Property version)[-1]).PolicyRule | Should -BeLike $expected.PolicyRule
        (($actual | sort -Property version)[-1]).Metadata | Should -BeLike $expected.Metadata
    }
}

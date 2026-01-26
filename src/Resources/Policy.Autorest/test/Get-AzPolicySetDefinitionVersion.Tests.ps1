# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'GetPolicySetDefinitionVersion'

Describe 'GetPolicySetDefinitionVersion' -Tag 'LiveOnly' {

    BeforeAll {
        $customSetDefinition = $env.customSubSetDefinition
    }

    It 'Get-AzPolicySetDefinition -Version' {
        {
            Get-AzPolicySetDefinition -Version $defaultVersion
        } | Should -Throw $versionRequiresNameOrId
    }

    It 'Get-AzPolicySetDefinition -Name -Version <missing>' {
        {
            Get-AzPolicySetDefinition -Name $someName -Version
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicySetDefinition -Name -Id -Version' {
        {
            Get-AzPolicySetDefinition -Name $someName -Id $someId -Version $someNewVersion 
        } | Should -Throw $nameOrIdIdentifier
    }

    It 'Get-AzPolicySetDefinition -ManagementGroupName -Id -Version' {
        {
            Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -Id $someId -Version $someNewVersion 
        } | Should -Throw $managementGroupSubscriptionWithName
    }

    It 'Get-AzPolicySetDefinition -SubscriptionId -Id -Version' {
        {
            Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -Id $someId -Version $someNewVersion 
        } | Should -Throw $managementGroupSubscriptionWithName
    }

    It 'Get-AzPolicySetDefinition -Name -ManagementGroupName -Version' {
        {
            Get-AzPolicySetDefinition -Name $someName -ManagementGroupName $someManagementGroup -Version $someNewVersion 
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Get-AzPolicySetDefinition -Name -SubscriptionId -Version' {
        {
            Get-AzPolicySetDefinition -Name $someName -SubscriptionId $subscriptionId -Version $someNewVersion 
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Get-AzPolicySetDefinition -ManagementGroupName -Version' {
        {
            Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -Version $someNewVersion 
        } | Should -Throw $versionRequiresNameOrId
    }

    It 'Get-AzPolicySetDefinition -SubscriptionId -Version' {
        {
            Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -Version $someNewVersion 
        } | Should -Throw $versionRequiresNameOrId
    }

    It 'Get-AzPolicySetDefinition -ListVersion' {
        {
            Get-AzPolicySetDefinition -ListVersion
        } | Should -Throw $listVersionRequiresNameOrId
    }

    It 'Get-AzPolicySetDefinition -Name -Id -ListVersion' {
        {
            Get-AzPolicySetDefinition -Name $someName -Id $someId -ListVersion
        } | Should -Throw $nameOrIdIdentifier
    }

    It 'Get-AzPolicySetDefinition -ManagementGroupName -Id -ListVersion' {
        {
            Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -Id $someId -ListVersion
        } | Should -Throw $managementGroupSubscriptionWithName
    }

    It 'Get-AzPolicySetDefinition -SubscriptionId -Id -ListVersion' {
        {
            Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -Id $someId -ListVersion 
        } | Should -Throw $managementGroupSubscriptionWithName
    }

    It 'Get-AzPolicySetDefinition -Name -ManagementGroupName -ListVersion' {
        {
            Get-AzPolicySetDefinition -Name $someName -ManagementGroupName $someManagementGroup -ListVersion
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Get-AzPolicySetDefinition -Name -SubscriptionId -ListVersion' {
        {
            Get-AzPolicySetDefinition -Name $someName -SubscriptionId $subscriptionId -ListVersion
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Get-AzPolicySetDefinition -ManagementGroupName -ListVersion' {
        {
            Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -ListVersion
        } | Should -Throw $listVersionRequiresNameOrId
    }

    It 'Get-AzPolicySetDefinition -SubscriptionId -ListVersion' {
        {
            Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -ListVersion
        } | Should -Throw $listVersionRequiresNameOrId
    }

    It 'Get-AzPolicySetDefinition -Name <custom>' {
        $result = Get-AzPolicySetDefinition -Name $customSetDefinition.Name
        $version = $result.Version
        $version | Should -Not -BeNullOrEmpty
        $result.Version | Should -Be $version
        $result.Versions | Should -Be @($version)
    }

    It 'Get-AzPolicySetDefinition -Name <custom> -Version' {
        $result = Get-AzPolicySetDefinition -Name $customSetDefinition.Name -Version $defaultVersion
        $result.Version | Should -Be $defaultVersion
        $result.Versions | Should -BeNull
    }

    It 'Get-AzPolicySetDefinition -Name <custom> -ListVersion' {
        $result = Get-AzPolicySetDefinition -Name $customSetDefinition.Name -ListVersion
        $result.Version | Should -Be $defaultVersion
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
        $result = Get-AzPolicySetDefinition -Id $customSetDefinition.Id -Version $defaultVersion
        $result.Version | Should -Be $defaultVersion
        $result.Versions | Should -BeNull
    }

    It 'Get-AzPolicySetDefinition -Id <custom> -ListVersion' {
        $result = Get-AzPolicySetDefinition -Id $customSetDefinition.Id -ListVersion
        $result.Version | Should -Be $defaultVersion
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
# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'GetPolicySetDefinitionVersion'

Describe 'GetPolicySetDefinitionVersion' {

    BeforeAll {
        $customSetDefinition = $env.customSubSetDefinition
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policySetDefinitions/$someName"
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
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -ManagementGroupName -Id -Version' {
        {
            Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -Id $someId -Version $someNewVersion 
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -SubscriptionId -Id -Version' {
        {
            Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -Id $someId -Version $someNewVersion 
        } | Should -Throw $parameterSetError
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
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -ManagementGroupName -Id -ListVersion' {
        {
            Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -Id $someId -ListVersion
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -SubscriptionId -Id -ListVersion' {
        {
            Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -Id $someId -ListVersion 
        } | Should -Throw $parameterSetError
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

    It 'Get-AzPolicySetDefinition -Expand <missing> -Version' {
        {
            Get-AzPolicySetDefinition -Expand -Version $someNewVersion 
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicySetDefinition -Expand <missing> -ListVersion' {
        {
            Get-AzPolicySetDefinition -Version $someNewVersion -Expand -ListVersion
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicySetDefinition -Expand -Version' {
        {
            Get-AzPolicySetDefinition -Expand "LatestDefinitionVersion" -Version $someNewVersion 
        } | Should -Throw $versionRequiresNameOrId
    }

    It 'Get-AzPolicySetDefinition -ManagementGroupName -Expand -Version' {
        {
            Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -Expand "EffectiveDefinitionVersion" -Version $someNewVersion 
        } | Should -Throw $versionRequiresNameOrId
    }

    It 'Get-AzPolicySetDefinition -SubscriptionId -Expand -Version' {
        {
            Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -Expand "EffectiveDefinitionVersion" -Version $someNewVersion 
        } | Should -Throw $versionRequiresNameOrId
    }

    It 'Get-AzPolicySetDefinition -Custom -Expand -Version' {
        {
            Get-AzPolicySetDefinition -Custom -Expand "EffectiveDefinitionVersion" -Version $someNewVersion 
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -BuiltIn -Expand -Version' {
        {
            Get-AzPolicySetDefinition -BuiltIn -Expand "EffectiveDefinitionVersion" -Version $someNewVersion 
        } | Should -Throw $parameterSetError
    }
    
    It 'Get-AzPolicySetDefinition -ManagementGroupName -Name -Expand <invalid value> -Version' {
        {
            Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -Name $someName -Expand $someName -Version $someNewVersion 
        } | Should -Throw $unsupportedFilterValue
    }

    It 'Get-AzPolicySetDefinition -SubscriptionId -Name -Expand <invalid value> -Version' {
        {
            Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -Name $someName -Expand $someName -Version $someNewVersion 
        } | Should -Throw $unsupportedFilterValue
    }

    It 'Get-AzPolicySetDefinition -ManagementGroupName -Name -Expand -Version' {
        {
            Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -Name $someName -Expand "EffectiveDefinitionVersion" -Version $someNewVersion
        } | Should -Throw $PolicySetDefinitionNotFound
    }

    It 'Get-AzPolicySetDefinition -SubscriptionId -Name -Expand -Version' {
        {
            Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -Name $someName -Expand "EffectiveDefinitionVersion" -Version $someNewVersion 
        } | Should -Throw $PolicySetDefinitionNotFound
    }

    It 'Get-AzPolicySetDefinition -Id -Expand <invalid value> -Version' {
        {
            Get-AzPolicySetDefinition -Id $goodId -Expand $someName -Version $someNewVersion 
        } | Should -Throw $unsupportedFilterValue
    }

    It 'Get-AzPolicySetDefinition -Id -Expand -Version' {
        {
            Get-AzPolicySetDefinition -Id $goodId -Expand "LatestDefinitionVersion, EffectiveDefinitionVersion" -Version $someNewVersion 
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Get-AzPolicySetDefinition -ManagementGroupName -Id -Expand -Version' {
        {
            Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -Id $goodId -Expand "LatestDefinitionVersion, EffectiveDefinitionVersion" -Version $someNewVersion 
        } | Should -Throw $parameterSetError
    }
    
    It 'Get-AzPolicySetDefinition -SubscriptionId -Id -Expand -Version' {
        {
            Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -Id $goodId -Expand "LatestDefinitionVersion, EffectiveDefinitionVersion" -Version $someNewVersion 
        } | Should -Throw $parameterSetError
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
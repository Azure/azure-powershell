# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-GetCmdletFilterParameter'

Describe 'Backcompat-GetCmdletFilterParameter' -Tag 'LiveOnly' {

    It 'list builtin definitions' {
        {
            # builtin policy definitions
            $builtins = Get-AzPolicyDefinition -Builtin -BackwardCompatible
            $builtins | %{ Assert-AreEqual $_.Properties.PolicyType "BuiltIn" }
        } | Should -Not -Throw
    }

    It 'list custom definitions' {
        {
            # custom policy definitions
            $custom = Get-AzPolicyDefinition -Custom -BackwardCompatible
            $custom | %{ Assert-AreEqual $_.Properties.PolicyType "Custom" }
        } | Should -Not -Throw
    }

    It 'list static definitions' {
        {
            # static policy definitions
            $static = Get-AzPolicyDefinition -Static -BackwardCompatible
            $static | %{ Assert-AreEqual $_.Properties.PolicyType "Static" }
        } | Should -Not -Throw
    }

    It 'list builtin set definitions' {
        {
            # builtin policy set definitions
            $builtins = Get-AzPolicySetDefinition -Builtin -BackwardCompatible
            $builtins | %{ Assert-AreEqual $_.Properties.PolicyType "BuiltIn" }
        } | Should -Not -Throw
    }

    It 'list custom set definitions' {
        {
            # custom policy definitions
            $custom = Get-AzPolicySetDefinition -Custom -BackwardCompatible
            $custom | %{ Assert-AreEqual $_.Properties.PolicyType "Custom" }
        } | Should -Not -Throw
    }
}

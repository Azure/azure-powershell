# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyDefinitionWithUri'

Describe 'PolicyDefinitionWithUri' {

    BeforeAll {
        # setup
        $policyName = Get-ResourceName
    }

    It 'Make a policy definition using a URI to the policy rule' {
        # make a policy definition using a Uri to the policy rule, get it back and validate
        $actual = New-AzPolicyDefinition -Name $policyName -Policy "https://raw.githubusercontent.com/vivsriaus/armtemplates/master/policyDef.json" -Mode All -Description $description
        $expected = Get-AzPolicyDefinition -Name $policyName
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $actual.PolicyRule | Should -Not -BeNullOrEmpty
        $expected.PolicyRule | Should -BeLike $actual.PolicyRule
        $expected.Mode | Should -Be $actual.Mode
    }

    AfterAll {
        $remove = Remove-AzPolicyDefinition -Name $policyName -Force -PassThru
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}

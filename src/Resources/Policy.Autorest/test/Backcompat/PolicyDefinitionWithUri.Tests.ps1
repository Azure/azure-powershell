# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-PolicyDefinitionWithUri'

Describe 'Backcompat-PolicyDefinitionWithUri' {

    BeforeAll {
        # setup
        $policyName = Get-ResourceName
    }

    It 'make a policy definition using a URI to the policy rule' {
        {
            # make a policy definition using a Uri to the policy rule, get it back and validate
            $actual = New-AzPolicyDefinition -Name $policyName -Policy "https://raw.githubusercontent.com/vivsriaus/armtemplates/master/policyDef.json" -Mode All -Description $description -BackwardCompatible
            $expected = Get-AzPolicyDefinition -Name $policyName -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
            Assert-NotNull($actual.Properties.PolicyRule)
            Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode
        } | Should -Not -Throw
    }

    AfterAll {
        $remove = Remove-AzPolicyDefinition -Name $policyName -Force -BackwardCompatible
        Assert-AreEqual True $remove

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}

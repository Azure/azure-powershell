# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-PolicyDefinitionCRUD'

Describe 'Backcompat-PolicyDefinitionCRUD' -Tag 'LiveOnly' {

    BeforeAll {
        # setup
        $policyName = Get-ResourceName
        $test2 = Get-ResourceName
        $test3 = Get-ResourceName
    }

    It 'make a policy definition from rule file' {
        {
            # make a policy definition, get it back and validate
            $expected = New-AzPolicyDefinition -Name $policyName -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Mode Indexed -Description $description -BackwardCompatible
            $actual = Get-AzPolicyDefinition -Name $policyName -BackwardCompatible
            Assert-NotNull $actual
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
            Assert-NotNull($actual.Properties.PolicyRule)
            Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode
        } | Should -Not -Throw
    }

    It 'update policy descriptors and metadata' {
        {
            # update the same policy definition, get it back and validate the new properties
            $actual = Set-AzPolicyDefinition -Name $policyName -DisplayName testDisplay -Description $updatedDescription -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Metadata $metadata -BackwardCompatible
            $expected = Get-AzPolicyDefinition -Name $policyName -BackwardCompatible
            Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
            Assert-NotNull($actual.Properties.Metadata)
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
        } | Should -Not -Throw
    }

    It 'make policy definition from command line rule' {
        {
            # make another policy definition, ensure both are present in listing
            New-AzPolicyDefinition -Name $test2 -Policy "{""if"":{""source"":""action"",""equals"":""blah""},""then"":{""effect"":""deny""}}" -Description $description -BackwardCompatible
            $list = Get-AzPolicyDefinition -BackwardCompatible | ?{ $_.Name -in @($policyName, $test2) }
            Assert-AreEqual 2 $list.Count
            Assert-True { $list.Count -eq 2 }
        } | Should -Not -Throw
    }

    It 'check policy definition listing filters' {
        {
            # ensure that only builtin definitions are returned using the builtin flag
            $list = Get-AzPolicyDefinition -BuiltIn -BackwardCompatible
            Assert-True { $list.Count -gt 0 }
            $builtIns = $list | Where-Object { !($_.Properties.policyType -ieq 'BuiltIn') }
            Assert-True { $builtIns.Count -eq 0 }

            # ensure that only custom definitions are returned using the custom flag
            $list = Get-AzPolicyDefinition -Custom -BackwardCompatible
            Assert-True { $list.Count -gt 0 }
            $builtIns = $list | Where-Object { !($_.Properties.policyType -ieq 'Custom') }
            Assert-True { $builtIns.Count -eq 0 }

            # ensure that only static definitions are returned using the static flag
            $list = Get-AzPolicyDefinition -Static -BackwardCompatible
            Assert-True { $list.Count -gt 0 }
            $builtIns = $list | Where-Object { !($_.Properties.policyType -ieq 'Static') }
            Assert-True { $builtIns.Count -eq 0 }
        } | Should -Not -Throw
    }

    It 'make a policy definition from an export file' {
        {
            # make a policy definition from export format, get it back and validate
            $expected = New-AzPolicyDefinition -Name $test3 -Policy "$testFilesFolder\SamplePolicyDefinitionFromExport.json" -Description $description -BackwardCompatible
            $actual = Get-AzPolicyDefinition -Name $test3 -BackwardCompatible
            Assert-NotNull $actual
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
            Assert-NotNull($actual.Properties.PolicyRule)
            Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode
            Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
        } | Should -Not -Throw
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyDefinition -Name $policyName -Force -BackwardCompatible
        $remove = (Remove-AzPolicyDefinition -Name $test2 -Force -BackwardCompatible) -and $remove
        $remove = (Remove-AzPolicyDefinition -Name $test3 -Force -BackwardCompatible) -and $remove
        Assert-AreEqual True $remove

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}

# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyDefinitionWithComplexParameters'

Describe 'PolicyDefinitionWithComplexParameters' {

    BeforeAll {
        $testPDWCP = Get-ResourceName
        $testPDWNV = Get-ResourceName
        $testAssignment = Get-ResourceName
    }

    It 'make test definition with complex parameters from a file' {
        $actual = New-AzPolicyDefinition -Name $testPDWCP -Policy "$testFilesFolder\SamplePolicyDefinitionWithComplexParameters.json"
        $actual.PolicyRule | Should -Not -BeNullOrEmpty
        $actual.parameter | Should -Not -BeNullOrEmpty
        $actual.parameter.warn | Should -Not -BeNullOrEmpty
        $actual.parameter.warn.type | Should -Be 'boolean'
        $actual.parameter.warn.metadata | Should -Not -BeNullOrEmpty
        $actual.parameter.warn.metadata.displayName | Should -Be 'Warn'
        $actual.parameter.warn.metadata.description | Should -BeLike 'Whether or not to return warnings*'
        $actual.parameter.effect | Should -Not -BeNullOrEmpty
        $actual.parameter.effect.type | Should -Be 'string'
        $actual.parameter.effect.metadata | Should -Not -BeNullOrEmpty
        $actual.parameter.effect.metadata.displayName | Should -Be 'Effect'
        $actual.parameter.effect.metadata.description | Should -BeLike "'Audit' allows a non-compliant*"
        $actual.parameter.effect.metadata.portalReview | Should -Be $true
        $actual.parameter.effect.allowedValues | Should -Be @("audit", "Audit", "deny", "Deny", "disabled", "Disabled")
        $actual.parameter.effect.defaultValue | Should -Be "Deny"
        $actual.parameter.excludedNamespaces | Should -Not -BeNullOrEmpty
        $actual.parameter.excludedNamespaces.type | Should -Be 'array'
        $actual.parameter.excludedNamespaces.metadata | Should -Not -BeNullOrEmpty
        $actual.parameter.excludedNamespaces.metadata.displayName | Should -Be 'Namespace exclusions'
        $actual.parameter.excludedNamespaces.metadata.description | Should -BeLike 'List of Kubernetes namespaces to exclude*'
        $actual.parameter.excludedNamespaces.defaultValue | Should -Be @("kube-system", "gatekeeper-system", "azure-arc", "azure-extensions-usage-system")
        $actual.parameter.namespaces | Should -Not -BeNullOrEmpty
        $actual.parameter.namespaces.type | Should -Be 'array'
        $actual.parameter.namespaces.metadata | Should -Not -BeNullOrEmpty
        $actual.parameter.namespaces.metadata.displayName | Should -Be 'Namespace inclusions'
        $actual.parameter.namespaces.metadata.description | Should -BeLike 'List of Kubernetes namespaces to only include*'
        $actual.parameter.namespaces.defaultValue | Should -Be @()
        $actual.parameter.labelSelector | Should -Not -BeNullOrEmpty
        $actual.parameter.labelSelector.type | Should -Be 'object'
        $actual.parameter.labelSelector.metadata | Should -Not -BeNullOrEmpty
        $actual.parameter.labelSelector.metadata.displayName | Should -Be 'Kubernetes label selector'
        $actual.parameter.labelSelector.metadata.description | Should -BeLike 'Label query to select Kubernetes resources*'
        $actual.parameter.labelSelector.defaultValue | Should -BeNullOrEmpty
        $actual.parameter.allowedContainerImagesRegex | Should -Not -BeNullOrEmpty
        $actual.parameter.allowedContainerImagesRegex.type | Should -Be 'string'
        $actual.parameter.allowedContainerImagesRegex.metadata | Should -Not -BeNullOrEmpty
        $actual.parameter.allowedContainerImagesRegex.metadata.displayName | Should -Be 'Allowed registry or registries regex'
        $actual.parameter.allowedContainerImagesRegex.metadata.description | Should -BeLike 'The RegEx rule used to match allowed*'
        $actual.parameter.allowedContainerImagesRegex.metadata.portalReview | Should -Be $true
        $actual.parameter.excludedContainers | Should -Not -BeNullOrEmpty
        $actual.parameter.excludedContainers.type | Should -Be 'array'
        $actual.parameter.excludedContainers.metadata | Should -Not -BeNullOrEmpty
        $actual.parameter.excludedContainers.metadata.displayName | Should -Be 'Containers exclusions'
        $actual.parameter.excludedContainers.metadata.description | Should -BeLike 'The list of InitContainers and*'
        $actual.parameter.excludedContainers.defaultValue | Should -Be @()

        # get it back and validate
        $expected = Get-AzPolicyDefinition -Name $testPDWCP
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $expected.Version | Should -Be $actual.Version
        $expected.parameter | Should -Not -BeNullOrEmpty
        $expected.parameter.warn | Should -Not -BeNullOrEmpty
        $expected.parameter.warn.type | Should -Be $actual.parameter.warn.type
        $expected.parameter.warn.metadata | Should -Not -BeNullOrEmpty
        $expected.parameter.warn.metadata.displayName | Should -Be $actual.parameter.warn.metadata.displayName
        $expected.parameter.warn.metadata.description | Should -Be $actual.parameter.warn.metadata.description
        $expected.parameter.effect | Should -Not -BeNullOrEmpty
        $expected.parameter.effect.type | Should -Be $actual.parameter.effect.type
        $expected.parameter.effect.metadata | Should -Not -BeNullOrEmpty
        $expected.parameter.effect.metadata.displayName | Should -Be $actual.parameter.effect.metadata.displayName
        $expected.parameter.effect.metadata.description | Should -Be $actual.parameter.effect.metadata.description
        $expected.parameter.effect.metadata.portalReview | Should -Be $actual.parameter.effect.metadata.portalReview
        $expected.parameter.effect.allowedValues | Should -Be $actual.parameter.effect.allowedValues
        $expected.parameter.effect.defaultValue | Should -Be $actual.parameter.effect.defaultValue
        $expected.parameter.excludedNamespaces | Should -Not -BeNullOrEmpty
        $expected.parameter.excludedNamespaces.type | Should -Be $actual.parameter.excludedNamespaces.type
        $expected.parameter.excludedNamespaces.metadata | Should -Not -BeNullOrEmpty
        $expected.parameter.excludedNamespaces.metadata.displayName | Should -Be $actual.parameter.excludedNamespaces.metadata.displayName
        $expected.parameter.excludedNamespaces.metadata.description | Should -Be $actual.parameter.excludedNamespaces.metadata.description
        $expected.parameter.excludedNamespaces.defaultValue | Should -Be $actual.parameter.excludedNamespaces.defaultValue
        $expected.parameter.namespaces | Should -Not -BeNullOrEmpty
        $expected.parameter.namespaces.type | Should -Be $actual.parameter.namespaces.type
        $expected.parameter.namespaces.metadata | Should -Not -BeNullOrEmpty
        $expected.parameter.namespaces.metadata.displayName | Should -Be $actual.parameter.namespaces.metadata.displayName
        $expected.parameter.namespaces.metadata.description | Should -Be $actual.parameter.namespaces.metadata.description
        $expected.parameter.namespaces.defaultValue | Should -Be $actual.parameter.namespaces.defaultValue
        $expected.parameter.labelSelector | Should -Not -BeNullOrEmpty
        $expected.parameter.labelSelector.type | Should -Be $actual.parameter.labelSelector.type
        $expected.parameter.labelSelector.metadata | Should -Not -BeNullOrEmpty
        $expected.parameter.labelSelector.metadata.displayName | Should -Be $actual.parameter.labelSelector.metadata.displayName
        $expected.parameter.labelSelector.metadata.description | Should -Be $actual.parameter.labelSelector.metadata.description
        $expected.parameter.labelSelector.defaultValue | Should -BeNullOrEmpty
        $expected.parameter.allowedContainerImagesRegex | Should -Not -BeNullOrEmpty
        $expected.parameter.allowedContainerImagesRegex.type | Should -Be $actual.parameter.allowedContainerImagesRegex.type
        $expected.parameter.allowedContainerImagesRegex.metadata | Should -Not -BeNullOrEmpty
        $expected.parameter.allowedContainerImagesRegex.metadata.displayName | Should -Be $actual.parameter.allowedContainerImagesRegex.metadata.displayName
        $expected.parameter.allowedContainerImagesRegex.metadata.description | Should -Be $actual.parameter.allowedContainerImagesRegex.metadata.description
        $expected.parameter.allowedContainerImagesRegex.metadata.portalReview | Should -Be $actual.parameter.allowedContainerImagesRegex.metadata.portalReview
        $expected.parameter.excludedContainers | Should -Not -BeNullOrEmpty
        $expected.parameter.excludedContainers.type | Should -Be $actual.parameter.excludedContainers.type
        $expected.parameter.excludedContainers.metadata | Should -Not -BeNullOrEmpty
        $expected.parameter.excludedContainers.metadata.displayName | Should -Be $actual.parameter.excludedContainers.metadata.displayName
        $expected.parameter.excludedContainers.metadata.description | Should -Be $actual.parameter.excludedContainers.metadata.description
        $expected.parameter.excludedContainers.defaultValue | Should -Be $actual.parameter.excludedContainers.defaultValue
    }

    It 'make a policy assignment with complex parameters on the command line' {
        # make a policy assignment with parameters from the command line, get it back and validate
        $policyParameterObject = @{
            warn = $true;
            effect = 'Audit';
            excludedNamespaces = @('uh-oh', 'no-way');
            namespaces = @('namespace1', 'namespace2');
            labelSelector = @{
                matchLabels = @{ label1 = "don't label me"; label2 = 'another label' };
                matchExpressions = @(
                    @{
                        key = 'thing1';
                        operator = 'NotIn';
                        values = @('thing2', 'thing3', 'thing4')
                    };
                    @{
                        key = 'thing2';
                        operator = 'In';
                        values = @('thing2')
                    }
                )
            };
            allowedContainerImagesRegex = 'regex1';
            excludedContainers = @()
        }

        $actual = (Get-AzPolicyDefinition -Name $testPDWCP | New-AzPolicyAssignment -Name $testAssignment -PolicyParameterObject $policyParameterObject)
        $actual.parameter | Should -Not -BeNullOrEmpty
        $actual.parameter.warn | Should -Be $true
        $actual.parameter.effect.value | Should -Be 'Audit'
        $actual.parameter.excludedNamespaces.value | Should -Be @('uh-oh', 'no-way')
        $actual.parameter.namespaces.value | Should -Be @('namespace1', 'namespace2')
        $actual.parameter.labelSelector | Should -Not -BeNullOrEmpty
        $actual.parameter.labelSelector.value | Should -Not -BeNullOrEmpty
        $actual.parameter.labelSelector.value.matchLabels | Should -Not -BeNullOrEmpty
        $actual.parameter.labelSelector.value.matchLabels.label1 | Should -Be "don't label me"
        $actual.parameter.labelSelector.value.matchLabels.label2 | Should -Be 'another label'
        $actual.parameter.labelSelector.value.matchExpressions | Should -Not -BeNullOrEmpty
        $actual.parameter.labelSelector.value.matchExpressions[0] | Should -Not -BeNullOrEmpty
        $actual.parameter.labelSelector.value.matchExpressions[0].key | Should -Be 'thing1'
        $actual.parameter.labelSelector.value.matchExpressions[0].operator | Should -Be 'NotIn'
        $actual.parameter.labelSelector.value.matchExpressions[0].values | Should -Be @('thing2', 'thing3', 'thing4')
        $actual.parameter.labelSelector.value.matchExpressions[1] | Should -Not -BeNullOrEmpty
        $actual.parameter.labelSelector.value.matchExpressions[1].key | Should -Be 'thing2'
        $actual.parameter.labelSelector.value.matchExpressions[1].operator | Should -Be 'In'
        $actual.parameter.labelSelector.value.matchExpressions[1].values | Should -Be @('thing2')
        $actual.parameter.allowedContainerImagesRegex.value | Should -Be 'regex1'
        $actual.parameter.excludedContainers.value | Should -Be @()

        # get it back and validate
        $expected = Get-AzPolicyAssignment -Name $testAssignment
        $expected.Name | Should -Be $actual.Name
        $expected.PolicyDefinitionId | Should -Be $actual.PolicyDefinitionId
        $expected.parameter | Should -Not -BeNullOrEmpty
        $expected.parameter.warn | Should -Not -BeNullOrEmpty
        $expected.parameter.warn.value | Should -Be $actual.parameter.warn.value
        $expected.parameter.effect | Should -Not -BeNullOrEmpty
        $expected.parameter.effect.value | Should -Be $actual.parameter.effect.value
        $expected.parameter.excludedNamespaces | Should -Not -BeNullOrEmpty
        $expected.parameter.excludedNamespaces.value | Should -Be $actual.parameter.excludedNamespaces.value
        $expected.parameter.namespaces | Should -Not -BeNullOrEmpty
        $expected.parameter.namespaces.value | Should -Be $actual.parameter.namespaces.value
        $expected.parameter.labelSelector | Should -Not -BeNullOrEmpty
        $expected.parameter.labelSelector.value | Should -Not -BeNullOrEmpty
        $expected.parameter.labelSelector.value.matchLabels | Should -Not -BeNullOrEmpty
        $expected.parameter.labelSelector.value.matchLabels.label1 | Should -Be $actual.parameter.labelSelector.value.matchLabels.label1
        $expected.parameter.labelSelector.value.matchLabels.label2 | Should -Be $actual.parameter.labelSelector.value.matchLabels.label2
        $expected.parameter.labelSelector.value.matchExpressions | Should -Not -BeNullOrEmpty
        $expected.parameter.labelSelector.value.matchExpressions[0] | Should -Not -BeNullOrEmpty
        $expected.parameter.labelSelector.value.matchExpressions[0].key | Should -Be $actual.parameter.labelSelector.value.matchExpressions[0].key
        $expected.parameter.labelSelector.value.matchExpressions[0].operator | Should -Be $actual.parameter.labelSelector.value.matchExpressions[0].operator
        $expected.parameter.labelSelector.value.matchExpressions[0].values | Should -Be $actual.parameter.labelSelector.value.matchExpressions[0].values
        $expected.parameter.labelSelector.value.matchExpressions[1] | Should -Not -BeNullOrEmpty
        $expected.parameter.labelSelector.value.matchExpressions[1].key | Should -Be $actual.parameter.labelSelector.value.matchExpressions[1].key
        $expected.parameter.labelSelector.value.matchExpressions[1].operator | Should -Be $actual.parameter.labelSelector.value.matchExpressions[1].operator
        $expected.parameter.labelSelector.value.matchExpressions[1].values | Should -Be $actual.parameter.labelSelector.value.matchExpressions[1].values
        $expected.parameter.allowedContainerImagesRegex.value | Should -Not -BeNullOrEmpty
        $expected.parameter.allowedContainerImagesRegex.value | Should -Be $actual.parameter.allowedContainerImagesRegex.value
        $expected.parameter.excludedContainers.value | Should -Be $actual.parameter.excludedContainers.value
    }

$definitionParameter = @"
{
    "effect": {
        "type": "String",
        "metadata": {
            "displayName": "Effect",
            "description": "'Audit' allows a non-compliant resource to be created, but flags it as non-compliant. 'Deny' blocks the resource creation. 'Disable' turns off the policy.",
            "portalReview": true
        },
        "allowedValues": [
            "audit",
            "Audit",
            "deny",
            "Deny",
            "disabled",
            "Disabled"
        ],
        "defaultValue": "Deny"
    }
}
"@

    It 'make test definition with complex parameters including null value from a file' {
        $actual = New-AzPolicyDefinition -Name $testPDWNV -Policy "$testFilesFolder\SamplePolicyDefinitionWithNullValue.json" -Parameter $definitionParameter
        $actual.PolicyRule | Should -Not -BeNullOrEmpty
        $actual.parameter | Should -Not -BeNullOrEmpty
        $actual.parameter.effect | Should -Not -BeNullOrEmpty
        $actual.parameter.effect.type | Should -Be 'string'
        $actual.parameter.effect.metadata | Should -Not -BeNullOrEmpty
        $actual.parameter.effect.metadata.displayName | Should -Be 'Effect'
        $actual.parameter.effect.metadata.description | Should -BeLike "'Audit' allows a non-compliant*"
        $actual.parameter.effect.metadata.portalReview | Should -Be $true
        $actual.parameter.effect.allowedValues | Should -Be @("audit", "Audit", "deny", "Deny", "disabled", "Disabled")
        $actual.parameter.effect.defaultValue | Should -Be "Deny"

        # get it back and validate
        $expected = Get-AzPolicyDefinition -Name $testPDWNV
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $expected.Version | Should -Be $actual.Version
        $expected.parameter | Should -Not -BeNullOrEmpty
        $expected.parameter.effect | Should -Not -BeNullOrEmpty
        $expected.parameter.effect.type | Should -Be $actual.parameter.effect.type
        $expected.parameter.effect.metadata | Should -Not -BeNullOrEmpty
        $expected.parameter.effect.metadata.displayName | Should -Be $actual.parameter.effect.metadata.displayName
        $expected.parameter.effect.metadata.description | Should -Be $actual.parameter.effect.metadata.description
        $expected.parameter.effect.metadata.portalReview | Should -Be $actual.parameter.effect.metadata.portalReview
        $expected.parameter.effect.allowedValues | Should -Be $actual.parameter.effect.allowedValues
        $expected.parameter.effect.defaultValue | Should -Be $actual.parameter.effect.defaultValue
    }

    AfterAll {
        # delete the policy assignment
        $remove = Remove-AzPolicyAssignment -Name $testAssignment -PassThru
        $remove | Should -Be $true

        # delete the policy definitions
        $remove = Remove-AzPolicyDefinition -Name $testPDWCP -Force -PassThru
        $remove = Remove-AzPolicyDefinition -Name $testPDWNV -Force -PassThru
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}

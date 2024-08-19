# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'ParsePolicyId'

# This validates the ParsePolicyId function that parses the PolicyDefinitionId parameter value for New-AzPolicyAssignment
Describe 'ParsePolicyId' {

    BeforeAll {
        $policyName = 'somePolicyName'
        $mgName = 'someManagementGroup'
        $rgName = 'someResourceGroup'
        $resNamespace = 'Someone.AirFryer'
        $resType = 'someType/someChildType'
        $resName = 'someResource'
        $definitionType = 'policyDefinitions'
        $setDefinitionType = 'policySetDefinitions'
        $fqDefType = "Microsoft.Authorization/$definitionType"
        $fqSetType = "Microsoft.Authorization/$setDefinitionType"
        $subId = '4126dcee-53d4-4846-ab7f-22f3bdb285e8'
        $scopeMg = "/providers/Microsoft.Management/managementGroups/$mgName"
        $scopeSub = "/subscriptions/$subId"
        $scopeRg = "$scopeSub/resourceGroups/$rgName"
        $scopeRes = "$scopeRg/providers/$resNamespace/$resType/$resName"
        $major = '12'
        $minor = '32'
        $patch = '9'
        $version = "$major.$minor.$patch"
        $versionMajorRef = "$major.*.*"
        $versionMinorRef = "$major.$minor.*"
        $suffix = 'preview'
        $suffixVersion = "$version-$suffix"
        $suffixVersionMajorRef = "$major.*.*-$suffix"
        $suffixVersionMinorRef = "$major.$minor.*-$suffix"
        $suffixVersionRef = $suffixVersionMinorRef
    }

    # base policy id tests
    It 'policy definition at global scope' {
        $id = "/providers/$fqDefType/$policyName"
        $parsed = ParsePolicyId $id
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -BeNullOrEmpty
        $parsed.ScopeType | Should -Be 'builtin'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -BeNullOrEmpty
        $parsed.Major | Should -BeNullOrEmpty
        $parsed.Minor | Should -BeNullOrEmpty
        $parsed.Patch | Should -BeNullOrEmpty
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -BeNullOrEmpty
        $parsed.VersionMajorRef | Should -BeNullOrEmpty
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -BeNullOrEmpty
    }

    It 'policy set definition at global scope' {
        $id = "/providers/$fqSetType/$policyName"
        $parsed = ParsePolicyId $id
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -BeNullOrEmpty
        $parsed.ScopeType | Should -Be 'builtin'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -BeNullOrEmpty
        $parsed.Major | Should -BeNullOrEmpty
        $parsed.Minor | Should -BeNullOrEmpty
        $parsed.Patch | Should -BeNullOrEmpty
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -BeNullOrEmpty
        $parsed.VersionMajorRef | Should -BeNullOrEmpty
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -BeNullOrEmpty
    }

    It 'policy definition at MG scope' {
        $id = "$scopeMg/providers/$fqDefType/$policyName"
        $parsed = ParsePolicyId $id
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeMg
        $parsed.ScopeType | Should -Be 'mgname'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -Be $mgName
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -BeNullOrEmpty
        $parsed.Major | Should -BeNullOrEmpty
        $parsed.Minor | Should -BeNullOrEmpty
        $parsed.Patch | Should -BeNullOrEmpty
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -BeNullOrEmpty
        $parsed.VersionMajorRef | Should -BeNullOrEmpty
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -BeNullOrEmpty
    }

    It 'policy set definition at MG scope' {
        $id = "$scopeMg/providers/$fqSetType/$policyName"
        $parsed = ParsePolicyId $id
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeMg
        $parsed.ScopeType | Should -Be 'mgname'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -Be $mgName
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -BeNullOrEmpty
        $parsed.Major | Should -BeNullOrEmpty
        $parsed.Minor | Should -BeNullOrEmpty
        $parsed.Patch | Should -BeNullOrEmpty
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -BeNullOrEmpty
        $parsed.VersionMajorRef | Should -BeNullOrEmpty
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -BeNullOrEmpty
    }

    It 'policy definition at sub scope' {
        $id = "$scopeSub/providers/$fqDefType/$policyName"
        $parsed = ParsePolicyId $id
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeSub
        $parsed.ScopeType | Should -Be 'subid'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -BeNullOrEmpty
        $parsed.Major | Should -BeNullOrEmpty
        $parsed.Minor | Should -BeNullOrEmpty
        $parsed.Patch | Should -BeNullOrEmpty
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -BeNullOrEmpty
        $parsed.VersionMajorRef | Should -BeNullOrEmpty
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -BeNullOrEmpty
    }

    It 'policy set definition at sub scope' {
        $id = "$scopeSub/providers/$fqSetType/$policyName"
        $parsed = ParsePolicyId $id
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeSub
        $parsed.ScopeType | Should -Be 'subid'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -BeNullOrEmpty
        $parsed.Major | Should -BeNullOrEmpty
        $parsed.Minor | Should -BeNullOrEmpty
        $parsed.Patch | Should -BeNullOrEmpty
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -BeNullOrEmpty
        $parsed.VersionMajorRef | Should -BeNullOrEmpty
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -BeNullOrEmpty
    }

    It 'policy definition at RG scope' {
        $id = "$scopeRg/providers/$fqDefType/$policyName"
        $parsed = ParsePolicyId $id
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeRg
        $parsed.ScopeType | Should -Be 'rgname'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -BeNullOrEmpty
        $parsed.Major | Should -BeNullOrEmpty
        $parsed.Minor | Should -BeNullOrEmpty
        $parsed.Patch | Should -BeNullOrEmpty
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -BeNullOrEmpty
        $parsed.VersionMajorRef | Should -BeNullOrEmpty
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -BeNullOrEmpty
    }

    It 'policy set definition at RG scope' {
        $id = "$scopeRg/providers/$fqSetType/$policyName"
        $parsed = ParsePolicyId $id
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeRg
        $parsed.ScopeType | Should -Be 'rgname'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -BeNullOrEmpty
        $parsed.Major | Should -BeNullOrEmpty
        $parsed.Minor | Should -BeNullOrEmpty
        $parsed.Patch | Should -BeNullOrEmpty
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -BeNullOrEmpty
        $parsed.VersionMajorRef | Should -BeNullOrEmpty
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -BeNullOrEmpty
    }

    It 'policy definition at resource scope' {
        $id = "$scopeRes/providers/$fqDefType/$policyName"
        $parsed = ParsePolicyId $id
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeRes
        $parsed.ScopeType | Should -Be 'resource'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -Be $scopeRes
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -BeNullOrEmpty
        $parsed.Major | Should -BeNullOrEmpty
        $parsed.Minor | Should -BeNullOrEmpty
        $parsed.Patch | Should -BeNullOrEmpty
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -BeNullOrEmpty
        $parsed.VersionMajorRef | Should -BeNullOrEmpty
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -BeNullOrEmpty
    }

    It 'policy set definition at resource scope' {
        $id = "$scopeRes/providers/$fqSetType/$policyName"
        $parsed = ParsePolicyId $id
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeRes
        $parsed.ScopeType | Should -Be 'resource'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -Be $scopeRes
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -BeNullOrEmpty
        $parsed.Major | Should -BeNullOrEmpty
        $parsed.Minor | Should -BeNullOrEmpty
        $parsed.Patch | Should -BeNullOrEmpty
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -BeNullOrEmpty
        $parsed.VersionMajorRef | Should -BeNullOrEmpty
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -BeNullOrEmpty
    }

    # patch version reference tests
    It 'policy definition at global scope with patch version' {
        $id = "/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$version"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -BeNullOrEmpty
        $parsed.ScopeType | Should -Be 'builtin'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $version
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be $patch
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMinorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -Be $versionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMinorRef"
    }

    It 'policy set definition at global scope with patch version' {
        $id = "/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$version"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -BeNullOrEmpty
        $parsed.ScopeType | Should -Be 'builtin'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $version
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be $patch
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMinorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -Be $versionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMinorRef"
    }

    It 'policy definition at MG scope with patch version' {
        $id = "$scopeMg/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$version"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeMg
        $parsed.ScopeType | Should -Be 'mgname'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -Be $mgName
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $version
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be $patch
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMinorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -Be $versionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMinorRef"
    }

    It 'policy set definition at MG scope with patch version' {
        $id = "$scopeMg/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$version"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeMg
        $parsed.ScopeType | Should -Be 'mgname'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -Be $mgName
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $version
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be $patch
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMinorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -Be $versionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMinorRef"
    }

    It 'policy definition at sub scope with patch version' {
        $id = "$scopeSub/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$version"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeSub
        $parsed.ScopeType | Should -Be 'subid'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $version
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be $patch
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMinorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -Be $versionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMinorRef"
    }

    It 'policy set definition at sub scope with patch version' {
        $id = "$scopeSub/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$version"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeSub
        $parsed.ScopeType | Should -Be 'subid'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $version
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be $patch
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMinorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -Be $versionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMinorRef"
    }

    It 'policy definition at RG scope with patch version' {
        $id = "$scopeRg/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$version"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeRg
        $parsed.ScopeType | Should -Be 'rgname'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $version
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be $patch
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMinorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -Be $versionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMinorRef"
    }

    It 'policy set definition at RG scope with patch version' {
        $id = "$scopeRg/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$version"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeRg
        $parsed.ScopeType | Should -Be 'rgname'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $version
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be $patch
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMinorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -Be $versionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMinorRef"
    }

    It 'policy definition at resource scope with patch version' {
        $id = "$scopeRes/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$version"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeRes
        $parsed.ScopeType | Should -Be 'resource'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -Be $scopeRes
        $parsed.ResourceNamespace | Should -Be $resNamespace
        $parsed.ResourceType | Should -Be $resType
        $parsed.ResourceName | Should -Be $resName
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $version
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be $patch
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMinorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -Be $versionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMinorRef"
    }

    It 'policy set definition at resource scope with patch version' {
        $id = "$scopeRes/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$version"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeRes
        $parsed.ScopeType | Should -Be 'resource'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -Be $scopeRes
        $parsed.ResourceNamespace | Should -Be $resNamespace
        $parsed.ResourceType | Should -Be $resType
        $parsed.ResourceName | Should -Be $resName
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $version
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be $patch
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMinorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -Be $versionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMinorRef"
    }

    It 'policy definition at global scope with patch suffix version' {
        $id = "/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$suffixVersion"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -BeNullOrEmpty
        $parsed.ScopeType | Should -Be 'builtin'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersion
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be $patch
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -Be $suffixVersionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionRef"
    }

    It 'policy set definition at global scope with patch suffix version' {
        $id = "/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$suffixVersion"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -BeNullOrEmpty
        $parsed.ScopeType | Should -Be 'builtin'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersion
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be $patch
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -Be $suffixVersionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionRef"
    }

    It 'policy definition at MG scope with patch suffix version' {
        $id = "$scopeMg/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$suffixVersion"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeMg
        $parsed.ScopeType | Should -Be 'mgname'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -Be $mgName
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersion
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be $patch
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -Be $suffixVersionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionRef"
    }

    It 'policy set definition at MG scope with patch suffix version' {
        $id = "$scopeMg/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$suffixVersion"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeMg
        $parsed.ScopeType | Should -Be 'mgname'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -Be $mgName
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersion
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be $patch
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -Be $suffixVersionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionRef"
    }

    It 'policy definition at sub scope with patch suffix version' {
        $id = "$scopeSub/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$suffixVersion"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeSub
        $parsed.ScopeType | Should -Be 'subid'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersion
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be $patch
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -Be $suffixVersionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionRef"
    }

    It 'policy set definition at sub scope with patch suffix version' {
        $id = "$scopeSub/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$suffixVersion"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeSub
        $parsed.ScopeType | Should -Be 'subid'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersion
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be $patch
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -Be $suffixVersionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionRef"
    }

    It 'policy definition at RG scope with patch suffix version' {
        $id = "$scopeRg/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$suffixVersion"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeRg
        $parsed.ScopeType | Should -Be 'rgname'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersion
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be $patch
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -Be $suffixVersionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionRef"
    }

    It 'policy set definition at RG scope with patch suffix version' {
        $id = "$scopeRg/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$suffixVersion"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeRg
        $parsed.ScopeType | Should -Be 'rgname'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersion
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be $patch
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -Be $suffixVersionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionRef"
    }

    It 'policy definition at resource scope with patch suffix version' {
        $id = "$scopeRes/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$suffixVersion"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeRes
        $parsed.ScopeType | Should -Be 'resource'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -Be $scopeRes
        $parsed.ResourceNamespace | Should -Be $resNamespace
        $parsed.ResourceType | Should -Be $resType
        $parsed.ResourceName | Should -Be $resName
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersion
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be $patch
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -Be $suffixVersionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionRef"
    }

    It 'policy set definition at resource scope with patch suffix version' {
        $id = "$scopeRes/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$suffixVersion"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeRes
        $parsed.ScopeType | Should -Be 'resource'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -Be $scopeRes
        $parsed.ResourceNamespace | Should -Be $resNamespace
        $parsed.ResourceType | Should -Be $resType
        $parsed.ResourceName | Should -Be $resName
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersion
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be $patch
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -Be $suffixVersionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionRef"
    }

    # minor version reference tests
    It 'policy definition at global scope with minor version' {
        $id = "/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$versionMinorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -BeNullOrEmpty
        $parsed.ScopeType | Should -Be 'builtin'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $versionMinorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMinorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -Be $versionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMinorRef"
    }

    It 'policy set definition at global scope with minor version' {
        $id = "/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$versionMinorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -BeNullOrEmpty
        $parsed.ScopeType | Should -Be 'builtin'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $versionMinorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMinorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -Be $versionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMinorRef"
    }

    It 'policy definition at MG scope with minor version' {
        $id = "$scopeMg/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$versionMinorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeMg
        $parsed.ScopeType | Should -Be 'mgname'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -Be $mgName
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $versionMinorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMinorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -Be $versionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMinorRef"
    }

    It 'policy set definition at MG scope with minor version' {
        $id = "$scopeMg/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$versionMinorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeMg
        $parsed.ScopeType | Should -Be 'mgname'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -Be $mgName
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $versionMinorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMinorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -Be $versionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMinorRef"
    }

    It 'policy definition at sub scope with minor version' {
        $id = "$scopeSub/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$versionMinorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeSub
        $parsed.ScopeType | Should -Be 'subid'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $versionMinorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMinorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -Be $versionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMinorRef"
    }

    It 'policy set definition at sub scope with minor version' {
        $id = "$scopeSub/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$versionMinorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeSub
        $parsed.ScopeType | Should -Be 'subid'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $versionMinorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMinorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -Be $versionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMinorRef"
    }

    It 'policy definition at RG scope with minor version' {
        $id = "$scopeRg/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$versionMinorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeRg
        $parsed.ScopeType | Should -Be 'rgname'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $versionMinorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMinorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -Be $versionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMinorRef"
    }

    It 'policy set definition at RG scope with minor version' {
        $id = "$scopeRg/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$versionMinorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeRg
        $parsed.ScopeType | Should -Be 'rgname'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $versionMinorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMinorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -Be $versionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMinorRef"
    }

    It 'policy definition at resource scope with minor version' {
        $id = "$scopeRes/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$versionMinorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeRes
        $parsed.ScopeType | Should -Be 'resource'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -Be $scopeRes
        $parsed.ResourceNamespace | Should -Be $resNamespace
        $parsed.ResourceType | Should -Be $resType
        $parsed.ResourceName | Should -Be $resName
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $versionMinorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMinorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -Be $versionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMinorRef"
    }

    It 'policy set definition at resource scope with minor version' {
        $id = "$scopeRes/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$versionMinorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeRes
        $parsed.ScopeType | Should -Be 'resource'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -Be $scopeRes
        $parsed.ResourceNamespace | Should -Be $resNamespace
        $parsed.ResourceType | Should -Be $resType
        $parsed.ResourceName | Should -Be $resName
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $versionMinorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMinorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -Be $versionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMinorRef"
    }

    It 'policy definition at global scope with minor suffix version' {
        $id = "/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$suffixVersionMinorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -BeNullOrEmpty
        $parsed.ScopeType | Should -Be 'builtin'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersionMinorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -Be $suffixVersionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionRef"
    }

    It 'policy set definition at global scope with minor suffix version' {
        $id = "/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$suffixVersionMinorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -BeNullOrEmpty
        $parsed.ScopeType | Should -Be 'builtin'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersionMinorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -Be $suffixVersionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionRef"
    }

    It 'policy definition at MG scope with minor suffix version' {
        $id = "$scopeMg/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$suffixVersionMinorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeMg
        $parsed.ScopeType | Should -Be 'mgname'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -Be $mgName
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersionMinorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -Be $suffixVersionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionRef"
    }

    It 'policy set definition at MG scope with minor suffix version' {
        $id = "$scopeMg/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$suffixVersionMinorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeMg
        $parsed.ScopeType | Should -Be 'mgname'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -Be $mgName
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersionMinorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -Be $suffixVersionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionRef"
    }

    It 'policy definition at sub scope with minor suffix version' {
        $id = "$scopeSub/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$suffixVersionMinorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeSub
        $parsed.ScopeType | Should -Be 'subid'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersionMinorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -Be $suffixVersionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionRef"
    }

    It 'policy set definition at sub scope with minor suffix version' {
        $id = "$scopeSub/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$suffixVersionMinorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeSub
        $parsed.ScopeType | Should -Be 'subid'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersionMinorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -Be $suffixVersionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionRef"
    }

    It 'policy definition at RG scope with minor suffix version' {
        $id = "$scopeRg/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$suffixVersionMinorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeRg
        $parsed.ScopeType | Should -Be 'rgname'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersionMinorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -Be $suffixVersionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionRef"
    }

    It 'policy set definition at RG scope with minor suffix version' {
        $id = "$scopeRg/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$suffixVersionMinorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeRg
        $parsed.ScopeType | Should -Be 'rgname'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersionMinorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -Be $suffixVersionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionRef"
    }

    It 'policy definition at resource scope with minor suffix version' {
        $id = "$scopeRes/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$suffixVersionMinorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeRes
        $parsed.ScopeType | Should -Be 'resource'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -Be $scopeRes
        $parsed.ResourceNamespace | Should -Be $resNamespace
        $parsed.ResourceType | Should -Be $resType
        $parsed.ResourceName | Should -Be $resName
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersionMinorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -Be $suffixVersionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionRef"
    }

    It 'policy set definition at resource scope with minor suffix version' {
        $id = "$scopeRes/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$suffixVersionMinorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeRes
        $parsed.ScopeType | Should -Be 'resource'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -Be $scopeRes
        $parsed.ResourceNamespace | Should -Be $resNamespace
        $parsed.ResourceType | Should -Be $resType
        $parsed.ResourceName | Should -Be $resName
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersionMinorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be $minor
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -Be $suffixVersionMinorRef
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionRef"
    }

    # major version reference tests
    It 'policy definition at global scope with major version' {
        $id = "/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$versionMajorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -BeNullOrEmpty
        $parsed.ScopeType | Should -Be 'builtin'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $versionMajorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be '*'
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMajorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMajorRef"
    }

    It 'policy set definition at global scope with major version' {
        $id = "/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$versionMajorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -BeNullOrEmpty
        $parsed.ScopeType | Should -Be 'builtin'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $versionMajorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be '*'
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMajorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMajorRef"
    }

    It 'policy definition at MG scope with major version' {
        $id = "$scopeMg/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$versionMajorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeMg
        $parsed.ScopeType | Should -Be 'mgname'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -Be $mgName
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $versionMajorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be '*'
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMajorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMajorRef"
    }

    It 'policy set definition at MG scope with major version' {
        $id = "$scopeMg/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$versionMajorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeMg
        $parsed.ScopeType | Should -Be 'mgname'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -Be $mgName
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $versionMajorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be '*'
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMajorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMajorRef"
    }

    It 'policy definition at sub scope with major version' {
        $id = "$scopeSub/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$versionMajorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeSub
        $parsed.ScopeType | Should -Be 'subid'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $versionMajorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be '*'
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMajorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMajorRef"
    }

    It 'policy set definition at sub scope with major version' {
        $id = "$scopeSub/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$versionMajorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeSub
        $parsed.ScopeType | Should -Be 'subid'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $versionMajorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be '*'
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMajorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMajorRef"
    }

    It 'policy definition at RG scope with major version' {
        $id = "$scopeRg/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$versionMajorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeRg
        $parsed.ScopeType | Should -Be 'rgname'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $versionMajorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be '*'
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMajorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMajorRef"
    }

    It 'policy set definition at RG scope with major version' {
        $id = "$scopeRg/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$versionMajorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeRg
        $parsed.ScopeType | Should -Be 'rgname'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $versionMajorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be '*'
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMajorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMajorRef"
    }

    It 'policy definition at resource scope with major version' {
        $id = "$scopeRes/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$versionMajorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeRes
        $parsed.ScopeType | Should -Be 'resource'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -Be $scopeRes
        $parsed.ResourceNamespace | Should -Be $resNamespace
        $parsed.ResourceType | Should -Be $resType
        $parsed.ResourceName | Should -Be $resName
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $versionMajorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be '*'
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMajorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMajorRef"
    }

    It 'policy set definition at resource scope with major version' {
        $id = "$scopeRes/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$versionMajorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeRes
        $parsed.ScopeType | Should -Be 'resource'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -Be $scopeRes
        $parsed.ResourceNamespace | Should -Be $resNamespace
        $parsed.ResourceType | Should -Be $resType
        $parsed.ResourceName | Should -Be $resName
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $versionMajorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be '*'
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -BeNullOrEmpty
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $versionMajorRef
        $parsed.VersionMajorRef | Should -Be $versionMajorRef
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -Be "$id/versions/$versionMajorRef"
    }

    It 'policy definition at global scope with major suffix version' {
        $id = "/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$suffixVersionMajorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -BeNullOrEmpty
        $parsed.ScopeType | Should -Be 'builtin'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersionMajorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be '*'
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionMajorRef"
    }

    It 'policy set definition at global scope with major suffix version' {
        $id = "/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$suffixVersionMajorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -BeNullOrEmpty
        $parsed.ScopeType | Should -Be 'builtin'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersionMajorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be '*'
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionMajorRef"
    }

    It 'policy definition at MG scope with major suffix version' {
        $id = "$scopeMg/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$suffixVersionMajorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeMg
        $parsed.ScopeType | Should -Be 'mgname'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -Be $mgName
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersionMajorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be '*'
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionMajorRef"
    }

    It 'policy set definition at MG scope with major suffix version' {
        $id = "$scopeMg/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$suffixVersionMajorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeMg
        $parsed.ScopeType | Should -Be 'mgname'
        $parsed.SubscriptionId | Should -BeNullOrEmpty
        $parsed.ManagementGroupName | Should -Be $mgName
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersionMajorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be '*'
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionMajorRef"
    }

    It 'policy definition at sub scope with major suffix version' {
        $id = "$scopeSub/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$suffixVersionMajorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeSub
        $parsed.ScopeType | Should -Be 'subid'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersionMajorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be '*'
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionMajorRef"
    }

    It 'policy set definition at sub scope with major suffix version' {
        $id = "$scopeSub/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$suffixVersionMajorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeSub
        $parsed.ScopeType | Should -Be 'subid'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -BeNullOrEmpty
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersionMajorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be '*'
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionMajorRef"
    }

    It 'policy definition at RG scope with major suffix version' {
        $id = "$scopeRg/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$suffixVersionMajorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeRg
        $parsed.ScopeType | Should -Be 'rgname'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersionMajorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be '*'
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionMajorRef"
    }

    It 'policy set definition at RG scope with major suffix version' {
        $id = "$scopeRg/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$suffixVersionMajorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeRg
        $parsed.ScopeType | Should -Be 'rgname'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -BeNullOrEmpty
        $parsed.ResourceNamespace | Should -BeNullOrEmpty
        $parsed.ResourceType | Should -BeNullOrEmpty
        $parsed.ResourceName | Should -BeNullOrEmpty
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersionMajorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be '*'
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionMajorRef"
    }

    It 'policy definition at resource scope with major suffix version' {
        $id = "$scopeRes/providers/$fqDefType/$policyName"
        $idVersion = "$id/versions/$suffixVersionMajorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $definitionType
        $parsed.Scope | Should -Be $scopeRes
        $parsed.ScopeType | Should -Be 'resource'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -Be $scopeRes
        $parsed.ResourceNamespace | Should -Be $resNamespace
        $parsed.ResourceType | Should -Be $resType
        $parsed.ResourceName | Should -Be $resName
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersionMajorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be '*'
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionMajorRef"
    }

    It 'policy set definition at resource scope with major suffix version' {
        $id = "$scopeRes/providers/$fqSetType/$policyName"
        $idVersion = "$id/versions/$suffixVersionMajorRef"
        $parsed = ParsePolicyId $idVersion
        $parsed.PolicyType | Should -Be $setDefinitionType
        $parsed.Scope | Should -Be $scopeRes
        $parsed.ScopeType | Should -Be 'resource'
        $parsed.SubscriptionId | Should -Be $subId
        $parsed.ManagementGroupName | Should -BeNullOrEmpty
        $parsed.ResourceGroupName | Should -Be $rgName
        $parsed.Resource | Should -Be $scopeRes
        $parsed.ResourceNamespace | Should -Be $resNamespace
        $parsed.ResourceType | Should -Be $resType
        $parsed.ResourceName | Should -Be $resName
        $parsed.Name | Should -Be $policyName
        $parsed.Version | Should -Be $suffixVersionMajorRef
        $parsed.Major | Should -Be $major
        $parsed.Minor | Should -Be '*'
        $parsed.Patch | Should -Be '*'
        $parsed.Suffix | Should -Be $suffix
        $parsed.Artifact | Should -Be $id
        $parsed.VersionRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMajorRef | Should -Be $suffixVersionMajorRef
        $parsed.VersionMinorRef | Should -BeNullOrEmpty
        $parsed.ArtifactRef | Should -Be "$id/versions/$suffixVersionMajorRef"
    }
}
Describe 'Get-AzPolicyRemediation custom wrapper' {
    BeforeAll {
        $script:scriptFile = (Resolve-Path (Join-Path $PSScriptRoot '../custom/Get-AzPolicyRemediation.ps1')).Path
        $script:scriptContent = Get-Content -Path $script:scriptFile -Raw
    }

    It 'rewrites management group requests to the management group resource ID' {
        $script:scriptContent | Should -Match 'if\(\$PSBoundParameters\.ContainsKey\("ManagementGroupId"\)\)'
        $script:scriptContent | Should -Match '\$PSBoundParameters\.Add\("ResourceId", "/providers/Microsoft\.Management/managementGroups/\$\(\$PSBoundParameters\["ManagementGroupId"\]\)"\)'
        $script:scriptContent | Should -Match '\$PSBoundParameters\.Remove\("ManagementGroupId"\)'
    }

    It 'rewrites management group requests before IncludeDetail dispatch' {
        $managementGroupRewriteIndex = $script:scriptContent.IndexOf('if($PSBoundParameters.ContainsKey("ManagementGroupId"))')
        $includeDetailIndex = $script:scriptContent.IndexOf('if($PSBoundParameters.ContainsKey("IncludeDetail"))')

        $managementGroupRewriteIndex | Should -BeGreaterThan -1
        $includeDetailIndex | Should -BeGreaterThan -1
        $managementGroupRewriteIndex | Should -BeLessThan $includeDetailIndex
    }
}

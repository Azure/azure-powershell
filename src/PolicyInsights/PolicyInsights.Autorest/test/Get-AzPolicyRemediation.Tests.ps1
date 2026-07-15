Describe 'Get-AzPolicyRemediation custom wrapper' {
    BeforeAll {
        $script:scriptFile = (Resolve-Path (Join-Path $PSScriptRoot '../custom/Get-AzPolicyRemediation.ps1')).Path
        $parseErrors = $null
        $script:scriptAst = [System.Management.Automation.Language.Parser]::ParseFile($script:scriptFile, [ref]$null, [ref]$parseErrors)
        $parseErrors | Should -BeNullOrEmpty
    }

    It 'rewrites management group requests to the management group resource ID' {
        $managementGroupRewrite = $script:scriptAst.Find({
            param($ast)

            $ast -is [System.Management.Automation.Language.IfStatementAst] -and
            $ast.Clauses[0].Item1.Extent.Text -eq '$PSBoundParameters.ContainsKey("ManagementGroupId")'
        }, $true)

        $managementGroupRewrite | Should -Not -BeNullOrEmpty
        $managementGroupRewrite.Extent.Text | Should -Match '\$PSBoundParameters\.Add\("ResourceId", "/providers/Microsoft\.Management/managementGroups/\$\(\$PSBoundParameters\["ManagementGroupId"\]\)"\)'
        $managementGroupRewrite.Extent.Text | Should -Match '\$PSBoundParameters\.Remove\("ManagementGroupId"\)'
    }

    It 'rewrites management group requests before IncludeDetail dispatch' {
        $managementGroupRewrite = $script:scriptAst.Find({
            param($ast)

            $ast -is [System.Management.Automation.Language.IfStatementAst] -and
            $ast.Clauses[0].Item1.Extent.Text -eq '$PSBoundParameters.ContainsKey("ManagementGroupId")'
        }, $true)
        $includeDetailDispatch = $script:scriptAst.Find({
            param($ast)

            $ast -is [System.Management.Automation.Language.IfStatementAst] -and
            $ast.Clauses[0].Item1.Extent.Text -eq '$PSBoundParameters.ContainsKey("IncludeDetail")'
        }, $true)

        $managementGroupRewrite | Should -Not -BeNullOrEmpty
        $includeDetailDispatch | Should -Not -BeNullOrEmpty
        $managementGroupRewrite.Extent.StartOffset | Should -BeLessThan $includeDetailDispatch.Extent.StartOffset
    }
}

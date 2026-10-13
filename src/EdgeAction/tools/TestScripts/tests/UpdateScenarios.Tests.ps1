# Copyright Microsoft Corporation. Licensed under the Apache License, Version 2.0.
#Requires -Version 7.0
# Execute maintained scenario bodies with offline command doubles, never their module-loading preambles.
$script:scenarioRoot = (Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..' 'EdgeAction.Autorest' 'test')).Path
. (Join-Path $script:scenarioRoot 'utils.ps1')

function Get-AzEdgeAction { [CmdletBinding()] param($ResourceGroupName, $Name) throw 'Unmocked fixture command' }
function Update-AzEdgeAction { [CmdletBinding()] param($ResourceGroupName, $Name, $Tag, $JsonString) throw 'Unmocked fixture command' }
function New-AzEdgeActionVersion { [CmdletBinding()] param($ResourceGroupName, $EdgeActionName, $Version, $DeploymentType, $IsDefaultVersion, $Location) throw 'Unmocked fixture command' }
function Get-AzEdgeActionVersion { [CmdletBinding()] param($ResourceGroupName, $EdgeActionName, $Version) throw 'Unmocked fixture command' }
function Update-AzEdgeActionVersion { [CmdletBinding()] param($ResourceGroupName, $EdgeActionName, $Version, $Tag) throw 'Unmocked fixture command' }
function Deploy-AzEdgeActionVersionCode { [CmdletBinding()] param($ResourceGroupName, $EdgeActionName, $Version, $FilePath) throw 'Unmocked fixture command' }
function New-AzEdgeActionExecutionFilter {
    [CmdletBinding()]
    param($ResourceGroupName, $EdgeActionName, $ExecutionFilter, $VersionId, $Location,
        $ExecutionFilterIdentifierHeaderName, $ExecutionFilterIdentifierHeaderValue)
    throw 'Unmocked fixture command'
}
function Get-AzEdgeActionExecutionFilter { [CmdletBinding()] param($ResourceGroupName, $EdgeActionName, $ExecutionFilter) throw 'Unmocked fixture command' }
function Update-AzEdgeActionExecutionFilter {
    [CmdletBinding()]
    param($ResourceGroupName, $EdgeActionName, $ExecutionFilter, $VersionId, $Tag,
        $ExecutionFilterIdentifierHeaderName, $ExecutionFilterIdentifierHeaderValue)
    throw 'Unmocked fixture command'
}

function Get-UpdateScenarioBlocks {
    param($Name)
    $tokens = $null
    $errors = $null
    $ast = [System.Management.Automation.Language.Parser]::ParseFile(
        (Join-Path $script:scenarioRoot "$Name.Tests.ps1"), [ref]$tokens, [ref]$errors)
    if ($errors) { throw ($errors.Message -join '; ') }
    $commands = $ast.FindAll({
        param($node)
        $node -is [System.Management.Automation.Language.CommandAst] -and
            $node.GetCommandName() -in @('BeforeAll', 'AfterAll', 'It')
    }, $true)
    $blocks = @{}
    foreach ($command in $commands) {
        $key = $command.GetCommandName()
        if ($key -eq 'It') {
            if ($command.CommandElements[1].Value -notlike 'UpdateExpanded*') {
                @($command.CommandElements | Where-Object { $_.ParameterName -eq 'skip' }).Count | Should -Be 1
                continue
            }
            @($command.CommandElements | Where-Object { $_.ParameterName -eq 'skip' }).Count | Should -Be 0
        }
        $blocks[$key] = $command.CommandElements[-1].ScriptBlock.GetScriptBlock()
    }
    $blocks.Count | Should -Be 3
    $blocks
}

Describe 'Maintained UpdateExpanded scenario bodies' {
    BeforeEach {
        $script:defaults = $PSDefaultParameterValues.Clone()
        $PSDefaultParameterValues.Remove('*:HttpPipelinePrepend')
        $script:parent = $null
        $script:versions = @{}
        $script:filter = $null
        $script:updates = [System.Collections.Generic.List[string]]::new()
        $script:cleanupCount = 0
        $script:breakReadback = $false
        $script:failSetup = $false
        $script:failCleanup = $false
        Mock New-EdgeActionTestResource {
            Assert-EdgeActionTestFixture $ResourceGroupName $Name
            $script:parent = [pscustomobject]@{ Name = $Name; Location = 'global'; SkuName = 'Standard'; SkuTier = 'Standard'; Tag = @{} }
            if ($script:failSetup) { throw 'offline setup failure' }
        }
        Mock Remove-EdgeActionTestResource {
            Assert-EdgeActionTestFixture $ResourceGroupName $Name
            $Name | Should -Be $script:parent.Name
            $script:cleanupCount++
            if ($script:failCleanup) { throw 'offline cleanup failure' }
        }
        Mock Get-AzEdgeAction { $script:parent.PSObject.Copy() }
        Mock Update-AzEdgeAction {
            # Model the generated wire shape, including its omission of empty expanded objects.
            $body = @{}
            if ($JsonString) { $body = $JsonString | ConvertFrom-Json -AsHashtable }
            elseif ($null -ne $Tag -and $Tag.Count) { $body.tags = $Tag }
            if (-not $body.Count) { throw 'The PATCH request body must contain at least one property.' }
            $body.ContainsKey('tags') | Should -Be $true
            $script:updates.Add('Parent')
            $script:parent.Tag = $body.tags.Clone()
            if ($script:breakReadback) { $script:parent.Tag = @{} }
        }
        Mock New-AzEdgeActionVersion {
            $EdgeActionName | Should -Be $script:parent.Name
            $script:versions[$Version] = [pscustomobject]@{
                Name = $Version; Id = "/offline/versions/$Version"; DeploymentType = $DeploymentType
                IsDefaultVersion = $IsDefaultVersion; ProvisioningState = 'Succeeded'
                ValidationStatus = 'Pending'; Tag = @{}
            }
        }
        Mock Deploy-AzEdgeActionVersionCode {
            $FilePath | Should -Match 'test_handler.js$'
            $script:versions[$Version].ValidationStatus = 'Succeeded'
        }
        Mock Get-AzEdgeActionVersion { $script:versions[$Version].PSObject.Copy() }
        Mock Update-AzEdgeActionVersion {
            $script:updates.Add('Version')
            $script:versions[$Version].Tag = $Tag.Clone()
            if ($script:breakReadback) { $script:versions[$Version].IsDefaultVersion = 'False' }
        }
        Mock New-AzEdgeActionExecutionFilter {
            $script:versions.v1.ValidationStatus | Should -Be 'Succeeded'
            $script:versions.v2.ValidationStatus | Should -Be 'Succeeded'
            $VersionId | Should -Be $script:versions.v1.Id
            $script:filter = [pscustomobject]@{
                Name = $ExecutionFilter; VersionId = $VersionId; Tag = @{}
                ExecutionFilterIdentifierHeaderName = $ExecutionFilterIdentifierHeaderName
                ExecutionFilterIdentifierHeaderValue = $ExecutionFilterIdentifierHeaderValue
            }
        }
        Mock Get-AzEdgeActionExecutionFilter { $script:filter.PSObject.Copy() }
        Mock Update-AzEdgeActionExecutionFilter {
            $script:updates.Add('Filter')
            if ($VersionId) { $VersionId | Should -Be $script:versions.v2.Id; $script:filter.VersionId = $VersionId }
            if ($null -ne $Tag) { $script:filter.Tag = $Tag.Clone() }
            if ($ExecutionFilterIdentifierHeaderName) { $script:filter.ExecutionFilterIdentifierHeaderName = $ExecutionFilterIdentifierHeaderName }
            if ($ExecutionFilterIdentifierHeaderValue) { $script:filter.ExecutionFilterIdentifierHeaderValue = $ExecutionFilterIdentifierHeaderValue }
            if ($script:breakReadback) { $script:filter.VersionId = $script:versions.v1.Id }
        }
    }
    AfterEach { $PSDefaultParameterValues = $script:defaults }

    It 'runs <Name> with readback assertions and dedicated cleanup' -TestCases @(
        @{ Name = 'Update-AzEdgeAction'; Count = 3 }
        @{ Name = 'Update-AzEdgeActionVersion'; Count = 1 }
        @{ Name = 'Update-AzEdgeActionExecutionFilter'; Count = 2 }
    ) {
        param($Name, $Count)
        $blocks = Get-UpdateScenarioBlocks $Name
        try { & $blocks.BeforeAll; & $blocks.It } finally { & $blocks.AfterAll }
        $script:updates.Count | Should -Be $Count
        $script:cleanupCount | Should -Be 1
        if ($Name -eq 'Update-AzEdgeActionVersion') {
            $script:versions.v1.IsDefaultVersion | Should -Be 'True'
        }
        if ($Name -eq 'Update-AzEdgeActionExecutionFilter') {
            $script:versions.v1.IsDefaultVersion | Should -Be 'True'
            $script:versions.v2.IsDefaultVersion | Should -Be 'False'
        }
    }

    It 'rejects empty expanded PATCH bodies but accepts explicit JSON tag clearing' {
        $blocks = Get-UpdateScenarioBlocks 'Update-AzEdgeAction'
        try {
            & $blocks.BeforeAll
            $parameters = @{ ResourceGroupName = $script:resourceGroupName; Name = $script:edgeActionName }
            { Update-AzEdgeAction @parameters } | Should -Throw 'The PATCH request body must contain at least one property.'
            { Update-AzEdgeAction @parameters -Tag @{} } | Should -Throw 'The PATCH request body must contain at least one property.'
            $script:updates.Count | Should -Be 0
            Update-AzEdgeAction @parameters -JsonString '{"tags":{}}'
            $script:updates.Count | Should -Be 1
            $script:parent.Tag.Count | Should -Be 0
        } finally {
            & $blocks.AfterAll
        }
        $script:cleanupCount | Should -Be 1
    }

    It 'fails <Name> on incorrect readback instead of accepting a successful PATCH alone' -TestCases @(
        @{ Name = 'Update-AzEdgeAction' }
        @{ Name = 'Update-AzEdgeActionVersion' }
        @{ Name = 'Update-AzEdgeActionExecutionFilter' }
    ) {
        param($Name)
        $blocks = Get-UpdateScenarioBlocks $Name
        $script:breakReadback = $true
        try { & $blocks.BeforeAll; { & $blocks.It } | Should -Throw } finally { & $blocks.AfterAll }
        $script:cleanupCount | Should -Be 1
    }

    It 'preserves setup and cleanup failures for <Name>' -TestCases @(
        @{ Name = 'Update-AzEdgeAction' }
        @{ Name = 'Update-AzEdgeActionVersion' }
        @{ Name = 'Update-AzEdgeActionExecutionFilter' }
    ) {
        param($Name)
        $blocks = Get-UpdateScenarioBlocks $Name
        $script:failSetup = $true
        $script:failCleanup = $true
        { & $blocks.BeforeAll } | Should -Throw 'offline setup failure'
        $message = try { & $blocks.AfterAll } catch { $_.Exception.Message }
        $message | Should -Match 'offline setup failure'
        $message | Should -Match 'offline cleanup failure'
        $script:cleanupCount | Should -Be 1
        $script:updates.Count | Should -Be 0
    }
}

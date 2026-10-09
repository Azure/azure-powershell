# Copyright Microsoft Corporation. Licensed under the Apache License, Version 2.0.
#Requires -Version 7.0
# Offline fixtures only: no module import, authentication, or Azure requests.
$script:utilsPath = (Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..' 'EdgeAction.Autorest' 'test' 'utils.ps1')).Path
. $script:utilsPath
Import-Module (Join-Path $PSScriptRoot '..' 'EdgeAction.TestRunner.psm1') -Force

Describe 'Dedicated EdgeAction fixture cleanup' {
    BeforeEach {
        $script:state = @{ Parent = $true; ExecutionFilter = $true; Version = $true }
        $script:calls = [System.Collections.Generic.List[string]]::new()
        $script:failureCommand = ''
        $script:retainDeletedChild = $false
        $script:deleteAlreadyAbsent = $false
        Mock Invoke-EdgeActionTestCommand {
            $script:calls.Add($Command)
            $Parameters.ResourceGroupName | Should -Be 'powershelltests'
            if ($Parameters.Name) { $Parameters.Name | Should -Be 'eagetdec01' }
            if ($Parameters.EdgeActionName) { $Parameters.EdgeActionName | Should -Be 'eagetdec01' }
            $Parameters.ContainsKey('NoWait') | Should -Be $false
            if ($Command -eq $script:failureCommand) { throw 'fixture cleanup request failed' }
            $notFound = $false
            $value = $null
            switch ($Command) {
                'Get-AzEdgeAction' {
                    $notFound = -not $script:state.Parent
                    if (-not $notFound) { $value = [pscustomobject]@{ Name = 'eagetdec01' } }
                }
                'New-AzEdgeAction' {
                    $script:state.Parent | Should -Be $false
                    $script:state.Parent = $true
                    $value = [pscustomobject]@{ Name = 'eagetdec01' }
                }
                'Remove-AzEdgeAction' {
                    $script:state.ExecutionFilter | Should -Be $false
                    $script:state.Version | Should -Be $false
                    $Parameters.Confirm | Should -Be $false
                    $script:state.Parent = $false
                }
                { $_ -in 'Get-AzEdgeActionExecutionFilter', 'Get-AzEdgeActionVersion' } {
                    $kind = $Command -replace '^Get-AzEdgeAction', ''
                    if ($script:state[$kind]) { $value = [pscustomobject]@{ Name = 'child'; IsDefaultVersion = 'True' } }
                    elseif ($Parameters.ContainsKey($kind)) { $notFound = $true }
                }
                { $_ -in 'Remove-AzEdgeActionExecutionFilter', 'Remove-AzEdgeActionVersion' } {
                    $kind = $Command -replace '^Remove-AzEdgeAction', ''
                    $Parameters[$kind] | Should -Be 'child'
                    $Parameters.Confirm | Should -Be $false
                    if ($kind -eq 'Version') { $script:state.ExecutionFilter | Should -Be $false }
                    if (-not $script:retainDeletedChild) { $script:state[$kind] = $false }
                    $notFound = $script:deleteAlreadyAbsent
                }
                default { throw "Unexpected fixture command $Command" }
            }
            @{ NotFound = $notFound; Value = $value }
        }
    }

    It 'deletes filters then versions then parent and verifies absence' {
        Remove-EdgeActionTestResource powershelltests eagetdec01
        ($script:calls -join ',') | Should -Be (
            'Get-AzEdgeAction,Get-AzEdgeActionExecutionFilter,Remove-AzEdgeActionExecutionFilter,' +
            'Get-AzEdgeActionExecutionFilter,Get-AzEdgeActionVersion,Remove-AzEdgeActionVersion,' +
            'Get-AzEdgeActionVersion,Remove-AzEdgeAction,Get-AzEdgeAction')
        $script:state.Parent | Should -Be $false
    }

    It 'is idempotent when the parent is already absent or cleanup is repeated' {
        Remove-EdgeActionTestResource powershelltests eagetdec01
        $script:calls.Clear()
        Remove-EdgeActionTestResource powershelltests eagetdec01
        ($script:calls -join ',') | Should -Be 'Get-AzEdgeAction'
    }

    It 'accepts a child disappearing between listing and deletion' {
        $script:deleteAlreadyAbsent = $true
        Remove-EdgeActionTestResource powershelltests eagetdec01
        $script:state.Parent | Should -Be $false
    }

    It 'handles partial setup with no filters or versions' {
        $script:state.ExecutionFilter = $false
        $script:state.Version = $false
        Remove-EdgeActionTestResource powershelltests eagetdec01
        @($script:calls | Where-Object { $_ -like 'Remove-AzEdgeAction?*' }).Count | Should -Be 0
        $script:state.Parent | Should -Be $false
    }

    It 'does not delete the parent after child deletion fails' {
        $script:failureCommand = 'Remove-AzEdgeActionVersion'
        { Remove-EdgeActionTestResource powershelltests eagetdec01 } | Should -Throw 'cleanup request failed'
        $script:calls | Should -Not -Contain 'Remove-AzEdgeAction'
    }

    It 'fails instead of assuming successful deletion means absence' {
        $script:retainDeletedChild = $true
        { Remove-EdgeActionTestResource powershelltests eagetdec01 } | Should -Throw 'still exists'
        $script:calls | Should -Not -Contain 'Remove-AzEdgeActionVersion'
        $script:calls | Should -Not -Contain 'Remove-AzEdgeAction'
    }

    It 'does not create when pre-cleaning fails' {
        $script:failureCommand = 'Get-AzEdgeActionVersion'
        { New-EdgeActionTestResource powershelltests eagetdec01 } | Should -Throw 'cleanup request failed'
        $script:calls | Should -Not -Contain 'New-AzEdgeAction'
    }

    It 'resets the selected fixture before creation in <Mode> mode' -TestCases @(
        @{ Mode = 'record' }, @{ Mode = 'live' }, @{ Mode = 'playback' }
    ) {
        param($Mode)
        $TestMode = $Mode
        (New-EdgeActionTestResource powershelltests eagetdec01).Name | Should -Be 'eagetdec01'
        $script:calls[-2] | Should -Be 'Get-AzEdgeAction'
        $script:calls[-1] | Should -Be 'New-AzEdgeAction'
    }

    It 'rejects unrelated names and groups before any request' -TestCases @(
        @{ Group = 'production'; Name = 'eagetdec01' }
        @{ Group = 'powershelltests'; Name = 'unrelated-resource' }
        @{ Group = 'powershelltests'; Name = 'eaupdatedec01' }
    ) {
        param($Group, $Name)
        { Remove-EdgeActionTestResource $Group $Name } | Should -Throw 'restricted'
        { New-EdgeActionTestResource $Group $Name } | Should -Throw 'restricted'
        $script:calls.Count | Should -Be 0
    }
}

Describe 'Current default version cleanup order' {
    BeforeEach {
        $script:versions = @()
        $script:deletedVersions = [System.Collections.Generic.List[string]]::new()
        $script:parentExists = $true
        $script:failedVersion = ''
        Mock Invoke-EdgeActionTestCommand {
            $value = $null
            $notFound = $false
            switch ($Command) {
                'Get-AzEdgeAction' { $notFound = -not $script:parentExists }
                'Get-AzEdgeActionExecutionFilter' { $value = @() }
                'Get-AzEdgeActionVersion' {
                    if ($Parameters.Version) {
                        $value = @($script:versions | Where-Object Name -EQ $Parameters.Version)
                        $notFound = $value.Count -eq 0
                    } else { $value = $script:versions }
                }
                'Remove-AzEdgeActionVersion' {
                    if ($Parameters.Version -eq $script:failedVersion) { throw 'fixture version deletion failed' }
                    $version = $script:versions | Where-Object Name -EQ $Parameters.Version
                    if ($version.IsDefaultVersion -eq 'True' -and $script:versions.Count -gt 1) {
                        throw 'Cannot delete the default while other versions remain'
                    }
                    $script:deletedVersions.Add($Parameters.Version)
                    $script:versions = @($script:versions | Where-Object Name -NE $Parameters.Version)
                }
                'Remove-AzEdgeAction' {
                    $script:versions.Count | Should -Be 0
                    $script:parentExists = $false
                }
                'New-AzEdgeAction' {
                    $script:parentExists | Should -Be $false
                    $script:parentExists = $true
                    $value = [pscustomobject]@{ Name = 'eagetdec01' }
                }
                default { throw "Unexpected fixture command $Command" }
            }
            @{ NotFound = $notFound; Value = $value }
        }
    }

    It 'uses the reported default <Default> during <Phase>, regardless of intended swap outcome' -TestCases @(
        @{ Default = 'v1'; Phase = 'preclean' }
        @{ Default = 'v2'; Phase = 'preclean' }
        @{ Default = 'v1'; Phase = 'teardown' }
        @{ Default = 'v2'; Phase = 'teardown' }
    ) {
        param($Default, $Phase)
        # Return the default first to catch reliance on list order or a hardcoded version name.
        $script:versions = @([pscustomobject]@{ Name = $Default; IsDefaultVersion = 'True' })
        foreach ($name in 'v1', 'v2', 'v3') {
            if ($name -ne $Default) {
                $script:versions += [pscustomobject]@{ Name = $name; IsDefaultVersion = 'False' }
            }
        }
        if ($Phase -eq 'preclean') {
            $null = New-EdgeActionTestResource powershelltests eagetdec01
        } else {
            Initialize-EdgeActionTestScenario {}
            Complete-EdgeActionTestScenario powershelltests eagetdec01
        }
        $script:deletedVersions.Count | Should -Be 3
        $script:deletedVersions[-1] | Should -Be $Default
        (($script:deletedVersions | Sort-Object) -join ',') | Should -Be 'v1,v2,v3'
    }

    It 'does not delete any version when default status is <Label>' -TestCases @(
        @{ Label = 'missing'; Status = $null }
        @{ Label = 'empty'; Status = '' }
        @{ Label = 'unrecognized'; Status = 'Unknown' }
    ) {
        param($Label, $Status)
        $script:versions = @(
            [pscustomobject]@{ Name = 'v1'; IsDefaultVersion = 'False' }
            [pscustomobject]@{ Name = 'v2'; IsDefaultVersion = $Status }
        )
        { Remove-EdgeActionTestResource powershelltests eagetdec01 } | Should -Throw 'cannot determine default status'
        $script:deletedVersions.Count | Should -Be 0
        $script:parentExists | Should -Be $true
    }

    It 'rejects multiple reported defaults instead of guessing their order' {
        $script:versions = @(
            [pscustomobject]@{ Name = 'v1'; IsDefaultVersion = 'True' }
            [pscustomobject]@{ Name = 'v2'; IsDefaultVersion = 'True' }
        )
        { Remove-EdgeActionTestResource powershelltests eagetdec01 } | Should -Throw 'multiple default versions'
        $script:deletedVersions.Count | Should -Be 0
        $script:parentExists | Should -Be $true
    }

    It 'retains the default and parent if deleting a non-default fails' {
        $script:versions = @(
            [pscustomobject]@{ Name = 'v2'; IsDefaultVersion = 'True' }
            [pscustomobject]@{ Name = 'v1'; IsDefaultVersion = 'False' }
        )
        $script:failedVersion = 'v1'
        { Remove-EdgeActionTestResource powershelltests eagetdec01 } | Should -Throw 'fixture version deletion failed'
        $script:deletedVersions.Count | Should -Be 0
        $script:parentExists | Should -Be $true
    }
}

function Invoke-CleanupResponseFixture {
    [CmdletBinding()]
    param([object[]]$HttpPipelinePrepend)
    if ($script:failWithoutResponse) { throw '404 NotFound timeout fixture' }
    if ($script:skipResponse) { return 'unverified fixture result' }
    $script:observedSteps = $HttpPipelinePrepend
    $next = [pscustomobject]@{}
    $next | Add-Member ScriptMethod SendAsync {
        param($request, $listener)
        $completed = [System.Threading.Tasks.TaskCompletionSource[System.Net.Http.HttpResponseMessage]]::new()
        $completed.SetResult($script:response)
        $completed.Task
    }
    $task = & $HttpPipelinePrepend[-1] $null $null $next
    $null = $task.GetAwaiter().GetResult()
    if ([int]$script:response.StatusCode -ge 400) {
        # Like generated onDefault, this exception deliberately contains no HTTP status.
        throw 'fixture command failed'
    }
    'fixture result'
}

Describe 'Cleanup HTTP status and diagnostics' {
    BeforeEach {
        $script:response = [System.Net.Http.HttpResponseMessage]::new([System.Net.HttpStatusCode]::OK)
        $script:response.Content = [System.Net.Http.StringContent]::new('{}')
        $script:failWithoutResponse = $false
        $script:skipResponse = $false
        $script:defaults = $PSDefaultParameterValues.Clone()
    }
    AfterEach {
        $script:response.Dispose()
        $PSDefaultParameterValues = $script:defaults
    }

    It 'retains the recorder and observes a response outside it' {
        $recorder = [pscustomobject]@{ Name = 'offline recorder sentinel' }
        $PSDefaultParameterValues['*:HttpPipelinePrepend'] = $recorder
        $result = Invoke-EdgeActionTestCommand Invoke-CleanupResponseFixture @{} 'fixture'
        $result.NotFound | Should -Be $false
        $result.Value | Should -Be 'fixture result'
        $script:observedSteps.Count | Should -Be 2
        [object]::ReferenceEquals($script:observedSteps[0], $recorder) | Should -Be $true
    }

    It 'accepts only an observed HTTP 404 as absence' {
        $script:response.StatusCode = [System.Net.HttpStatusCode]::NotFound
        (Invoke-EdgeActionTestCommand Invoke-CleanupResponseFixture @{} 'fixture' -AllowNotFound).NotFound |
            Should -Be $true
    }

    It 'fails for HTTP <Status> even when absence is allowed' -TestCases @(
        @{ Status = 401 }, @{ Status = 403 }, @{ Status = 409 }, @{ Status = 429 }, @{ Status = 500 }
    ) {
        param($Status)
        $script:response.StatusCode = [System.Net.HttpStatusCode]$Status
        { Invoke-EdgeActionTestCommand Invoke-CleanupResponseFixture @{} 'version child' -AllowNotFound } |
            Should -Throw "HTTP $Status"
    }

    It 'does not infer absence from an exception message without an HTTP response' {
        $script:failWithoutResponse = $true
        { Invoke-EdgeActionTestCommand Invoke-CleanupResponseFixture @{} 'fixture' -AllowNotFound } |
            Should -Throw 'no HTTP status'
    }

    It 'rejects success-shaped output when no HTTP response was observed' {
        $script:skipResponse = $true
        { Invoke-EdgeActionTestCommand Invoke-CleanupResponseFixture @{} 'fixture' } |
            Should -Throw 'resource state could not be verified'
    }

    It 'observes asynchronously completed responses without changing their body' {
        $null = Invoke-EdgeActionTestCommand Invoke-CleanupResponseFixture @{} 'fixture'
        $pending = [System.Threading.Tasks.TaskCompletionSource[System.Net.Http.HttpResponseMessage]]::new()
        $observer = New-Object EdgeActionTestResponse
        $task = $observer.Observe($pending.Task)
        $task.IsCompleted | Should -Be $false
        $script:response.StatusCode = [System.Net.HttpStatusCode]::NotFound
        $script:response.Content = [System.Net.Http.StringContent]::new('{"error":{"code":"NotFound"}}')
        $pending.SetResult($script:response)
        $returned = $task.GetAwaiter().GetResult()
        [object]::ReferenceEquals($returned, $script:response) | Should -Be $true
        $observer.StatusCode | Should -Be 404
        $returned.Content.ReadAsStringAsync().GetAwaiter().GetResult() | Should -Be $observer.ErrorBody
    }

    It 'reports non-JSON service errors without dumping their body' {
        $script:response.StatusCode = [System.Net.HttpStatusCode]::Conflict
        $script:response.Content = [System.Net.Http.StringContent]::new('<html>fixture server details</html>')
        { Invoke-EdgeActionTestCommand Invoke-CleanupResponseFixture @{} 'parent fixture' } |
            Should -Throw 'non-JSON error response'
    }

    It 'extracts PascalCase service messages and redacts identifiers and URLs' {
        $script:response.StatusCode = [System.Net.HttpStatusCode]::Conflict
        $script:response.Content = [System.Net.Http.StringContent]::new(
            '{"Error":{"Code":"CannotDeleteResource","Message":"Nested resources remain: /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/test. See https://example.invalid/details"}}')
        $message = try { Invoke-EdgeActionTestCommand Invoke-CleanupResponseFixture @{} "parent 'eagetdec01'" } catch { $_.Exception.Message }
        $message | Should -Match 'parent.*eagetdec01.*HTTP 409.*Nested resources remain'
        $message | Should -Not -Match '00000000|https://|/subscriptions/'
    }
}

Describe 'Scenario cleanup wiring' {
    It 'keeps every active scenario on shared pre-clean and teardown, with skipped groups inert' {
        $testRoot = Split-Path $script:utilsPath
        $active = 0
        foreach ($file in Get-ChildItem $testRoot -Filter '*.Tests.ps1') {
            $text = Get-Content $file.FullName -Raw
            if ($file.Name -like 'Update-*') {
                $text | Should -Not -Match 'BeforeAll|AfterAll|New-AzEdgeAction '
            } else {
                $active++
                $text | Should -Match 'New-EdgeActionTestResource'
                $text | Should -Match 'BeforeAll\s*\{\s*Initialize-EdgeActionTestScenario'
                $text | Should -Match 'AfterAll\s*\{[^}]*Complete-EdgeActionTestScenario'
                $text | Should -Not -Match 'New-AzEdgeAction -'
                $name = [regex]::Match($text, '(?i)\$script:edgeActionName\s*=\s*"([^"]+)"').Groups[1].Value
                { Assert-EdgeActionTestFixture powershelltests $name } | Should -Not -Throw
                if ($file.Name -like 'Remove-*') {
                    $text | Should -Match '\$remaining.NotFound \| Should -Be \$true'
                    $text | Should -Not -Match 'SilentlyContinue|Should -Throw'
                }
            }
        }
        $active | Should -Be 12
    }
}

Describe 'Pester 4 cleanup result propagation' {
    It 'retains <Failure> failure alongside teardown failure and blocks Record handoff' -TestCases @(
        @{ Failure = 'scenario' }, @{ Failure = 'setup' }, @{ Failure = 'none' }
    ) {
        param($Failure)
        $fixture = Join-Path $TestDrive "$Failure.Tests.ps1"
        $driver = Join-Path $TestDrive "$Failure-driver.ps1"
        $xml = Join-Path $TestDrive "$Failure.xml"
        @'
param($Failure)
Describe 'CleanupLifecycleFixture' {
    BeforeAll {
      Initialize-EdgeActionTestScenario {
        $script:resourceGroupName = 'powershelltests'
        $script:edgeActionName = 'eagetdec01'
        $script:created = $false
        Mock Invoke-EdgeActionTestCommand {
            switch ($Command) {
                'Get-AzEdgeAction' { return @{ NotFound = -not $script:created; Value = @{ Name = 'eagetdec01' } } }
                'New-AzEdgeAction' { $script:created = $true; return @{ NotFound = $false; Value = @{ Name = 'eagetdec01' } } }
                'Remove-AzEdgeAction' { throw 'fixture cleanup conflict' }
                default { return @{ NotFound = $false; Value = @() } }
            }
        }
        New-EdgeActionTestResource $script:resourceGroupName $script:edgeActionName
        if ($Failure -eq 'setup') { throw 'fixture setup failure' }
      }
    }
    AfterAll { Complete-EdgeActionTestScenario $script:resourceGroupName $script:edgeActionName }
    It 'original scenario' {
        $script:edgeActionName | Should -Be 'eagetdec01'
        if ($Failure -eq 'scenario') { throw 'fixture scenario failure' }
        $true | Should -Be $true
    }
}
'@ | Set-Content $fixture
        @'
param($Pester, $Fixture, $Utils, $Failure, $Results)
Import-Module $Pester
. $Utils
Invoke-Pester -Script @{ Path=$Fixture; Parameters=@{ Failure=$Failure } } -OutputFile $Results -EnableExit -Show None
'@ | Set-Content $driver
        $pester = (Get-Module Pester).Path
        $null = & (Join-Path $PSHOME 'pwsh') -NoLogo -NoProfile -File $driver $pester $fixture $script:utilsPath $Failure $xml 2>&1
        $childExit = $LASTEXITCODE
        $childExit | Should -BeGreaterThan 0
        [xml]$results = Get-Content $xml -Raw
        $messages = @($results.SelectNodes('//test-case/failure/message') | ForEach-Object InnerText) -join "`n"
        $messages | Should -Match 'fixture cleanup conflict'
        if ($Failure -ne 'none') { $messages | Should -Match "fixture $Failure failure" }
        # Also reject failing XML if a child host incorrectly reports exit zero.
        foreach ($exitCode in @($childExit, 0)) {
            { & (Get-Module EdgeAction.TestRunner) { param($Path, $Code)
                Assert-EdgeActionResults $Path ([datetime]::MinValue) $Code
            } $xml $exitCode } | Should -Throw
        }
        $artifact = Join-Path $TestDrive "$Failure-artifact"
        $null = New-Item -ItemType Directory (Join-Path $artifact 'test')
        & (Get-Module EdgeAction.TestRunner) {
            param($Root, $Results)
            $script:Artifact = $Root
            $script:fixtureResults = $Results
        } $artifact $xml
        InModuleScope EdgeAction.TestRunner {
            Mock Get-EdgeActionTestConfig { @{} }
            Mock Assert-EdgeActionMutation {}
            Mock Update-EdgeActionArtifactTests { @{} }
            Mock Get-EdgeActionRecordingState { @{} }
            Mock Invoke-EdgeActionTestChild {
                $destination = Join-Path $script:Artifact 'test' 'Az.EdgeAction-TestResults.xml'
                Copy-Item $script:fixtureResults $destination
                (Get-Item $destination).LastWriteTimeUtc = [datetime]::UtcNow
                return 0
            }
            Mock Copy-EdgeActionRecordingsForReview {}
            # Fail closed before any real runner bootstrap if a mock is accidentally bypassed.
            { Invoke-EdgeActionTests @{
                Mode = 'Record'; AllowResourceChanges = $false
                ConfigPath = (Join-Path $script:Artifact 'nonexistent-fixture-settings.psd1')
            } } | Should -Throw
            Assert-MockCalled Invoke-EdgeActionTestChild -Times 1 -Exactly -Scope It
            Assert-MockCalled Copy-EdgeActionRecordingsForReview -Times 0 -Exactly -Scope It
        }
    }
}

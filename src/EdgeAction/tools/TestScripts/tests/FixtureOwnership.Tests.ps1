# Copyright Microsoft Corporation. Licensed under the Apache License, Version 2.0.
#Requires -Version 7.0
# Copy the helper into TestDrive so persistence checks cannot write real test environment files.
$sourceUtils = Join-Path $PSScriptRoot '..' '..' '..' 'EdgeAction.Autorest' 'test' 'utils.ps1'
. $sourceUtils
function Get-AzContext { throw 'Offline tests must mock Azure context.' }

Describe 'Run-owned EdgeAction fixtures' {
    BeforeEach {
        $script:fixtureUtils = Join-Path $TestDrive 'utils.ps1'
        Copy-Item $sourceUtils $script:fixtureUtils
        . $script:fixtureUtils
        Remove-Item (Join-Path $TestDrive 'env.json'), (Join-Path $TestDrive 'localEnv.json') -ErrorAction SilentlyContinue
        Get-ChildItem $TestDrive -Filter '*.Recording.json' -File | Remove-Item
        $script:TestMode = 'record'
        $env = $script:env = @{
            SubscriptionId = 'offline-subscription'; Tenant = 'offline-tenant'; EnvironmentName = 'Offline'
            ResourceGroupName = 'rgps-powershellsdk-edgeaction-tests-0123456789ab'
            ResourceGroupState = 'Created'
            EdgeActionFixtures = @{
                'Get-AzEdgeAction' = @{ Name = 'eaget0123456789ab'; State = 'NotCreated' }
            }
        }
        $script:context = [pscustomobject]@{
            Subscription = @{ Id = 'offline-subscription' }; Tenant = @{ Id = 'offline-tenant' }
            Environment = @{ Name = 'Offline' }
        }
        Mock Get-AzContext { $script:context }
        $script:edgeActionEnvironmentStarted = $false
        $script:groupExists = $false
        $script:keepGroupAfterDelete = $false
        $script:parentExists = $false
        $script:versions = @()
        $script:filters = @()
        $script:calls = [System.Collections.Generic.List[string]]::new()
        $script:deletedVersions = [System.Collections.Generic.List[string]]::new()
        $script:failCommand = ''
        Mock Invoke-EdgeActionTestCommand {
            $script:calls.Add($Command)
            if ($Command -eq $script:failCommand) { throw 'offline request failure' }
            $value = $null; $notFound = $false
            switch ($Command) {
                'Get-AzResourceGroup' {
                    $WithoutRecorder | Should -Be $true
                    $notFound = -not $script:groupExists
                }
                'New-AzResourceGroup' {
                    $WithoutRecorder | Should -Be $true
                    $saved = Get-Content (Join-Path $TestDrive 'env.json') -Raw | ConvertFrom-Json
                    $saved.ResourceGroupState | Should -Be 'Creating'
                    $Parameters.Name | Should -Be $saved.ResourceGroupName
                    $Parameters.Location | Should -Not -BeNullOrEmpty
                    $Parameters.SubscriptionId | Should -Be 'offline-subscription'
                    $script:groupExists = $true
                }
                'Remove-AzResourceGroup' {
                    $WithoutRecorder | Should -Be $true
                    $Parameters.Name | Should -Match '^rgps-powershellsdk-edgeaction-tests-[0-9a-f]{12}$'
                    $Parameters.Confirm | Should -Be $false
                    if (-not $script:keepGroupAfterDelete) { $script:groupExists = $false }
                }
                'Get-AzEdgeAction' { $notFound = -not $script:parentExists }
                'New-AzEdgeAction' {
                    $saved = Get-Content (Join-Path $TestDrive 'env.json') -Raw | ConvertFrom-Json
                    $saved.EdgeActionFixtures.'Get-AzEdgeAction'.State | Should -Be 'Creating'
                    $script:parentExists = $true
                    $value = @{ Name = $Parameters.Name }
                }
                'Get-AzEdgeActionExecutionFilter' {
                    $value = $script:filters
                    if ($Parameters.ExecutionFilter) { $notFound = $script:filters.Count -eq 0 }
                }
                'Remove-AzEdgeActionExecutionFilter' { $script:filters = @() }
                'Get-AzEdgeActionVersion' {
                    $value = $script:versions
                    if ($Parameters.Version) {
                        $value = @($script:versions | Where-Object Name -EQ $Parameters.Version)
                        $notFound = $value.Count -eq 0
                    }
                }
                'Remove-AzEdgeActionVersion' {
                    $script:filters.Count | Should -Be 0
                    $script:deletedVersions.Add($Parameters.Version)
                    $script:versions = @($script:versions | Where-Object Name -NE $Parameters.Version)
                }
                'Remove-AzEdgeAction' {
                    $script:versions.Count | Should -Be 0
                    $script:parentExists = $false
                }
                default { throw "Unexpected offline command: $Command" }
            }
            @{ NotFound = $notFound; Value = $value }
        }
    }

    It 'creates fifteen unique names and saves them before scenario writes' {
        setupEnv
        $env.EdgeActionFixtures.Count | Should -Be 15
        $names = @($env.EdgeActionFixtures.Values | ForEach-Object Name)
        @($names | Select-Object -Unique).Count | Should -Be 15
        foreach ($name in $names) { $null = Assert-EdgeActionTestFixture $env.ResourceGroupName $name }
        ($script:calls -join ',') | Should -Be 'Get-AzResourceGroup,New-AzResourceGroup'
        $saved = Get-Content (Join-Path $TestDrive 'env.json') -Raw | ConvertFrom-Json
        @($saved.EdgeActionFixtures.PSObject.Properties).Count | Should -Be 15
        $saved.ResourceGroupName | Should -Match '^rgps-powershellsdk-edgeaction-tests-[0-9a-f]{12}$'
        $saved.ResourceGroupState | Should -Be 'Created'
    }

    It 'records ownership before and after creation and clears it only after verified cleanup' {
        (New-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab).Name | Should -Be 'eaget0123456789ab'
        $env.EdgeActionFixtures.'Get-AzEdgeAction'.State | Should -Be 'Created'
        Remove-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab
        $saved = Get-Content (Join-Path $TestDrive 'env.json') -Raw | ConvertFrom-Json
        $saved.EdgeActionFixtures.'Get-AzEdgeAction'.State | Should -Be 'Cleaned'
    }

    It 'refuses collisions without overwriting or deleting the existing resource' {
        $script:parentExists = $true
        { New-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab } | Should -Throw 'already exists'
        Remove-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab
        ($script:calls -join ',') | Should -Be 'Get-AzEdgeAction'
        $script:parentExists | Should -Be $true
    }

    It 'does not create after an inconclusive preflight' {
        $script:failCommand = 'Get-AzEdgeAction'
        { New-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab } | Should -Throw 'offline request failure'
        $script:calls | Should -Not -Contain 'New-AzEdgeAction'
        $env.EdgeActionFixtures.'Get-AzEdgeAction'.State | Should -Be 'NotCreated'
    }

    It 'retains an unknown creation result for manual recovery without deleting it' {
        $script:failCommand = 'New-AzEdgeAction'
        { New-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab } | Should -Throw 'offline request failure'
        { Remove-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab } | Should -Throw 'not confirmed'
        $saved = Get-Content (Join-Path $TestDrive 'env.json') -Raw | ConvertFrom-Json
        $saved.EdgeActionFixtures.'Get-AzEdgeAction'.State | Should -Be 'Creating'
        $script:calls | Should -Not -Contain 'Remove-AzEdgeAction'
    }

    It 'does not issue a PUT when the creation journal cannot be saved' {
        $blockedPath = Join-Path $TestDrive 'env.json.tmp'
        $null = New-Item -ItemType Directory $blockedPath
        try {
            { New-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab } | Should -Throw
            $script:calls | Should -Not -Contain 'New-AzEdgeAction'
        } finally { Remove-Item $blockedPath }
    }

    It 'retains failed cleanup state and blocks another run from overwriting it' {
        $null = New-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab
        $script:failCommand = 'Remove-AzEdgeAction'
        { Remove-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab } | Should -Throw 'offline request failure'
        $before = Get-Content (Join-Path $TestDrive 'env.json') -Raw
        { setupEnv } | Should -Throw 'unfinished EdgeAction resource group'
        Get-Content (Join-Path $TestDrive 'env.json') -Raw | Should -Be $before
    }

    It 'resumes confirmed ownership from the persisted environment' {
        $null = New-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab
        Resume-EdgeActionTestCleanup -Mode record -Name eaget0123456789ab -Confirm:$false
        $script:parentExists | Should -Be $false
        $saved = Get-Content (Join-Path $TestDrive 'env.json') -Raw | ConvertFrom-Json
        $saved.EdgeActionFixtures.'Get-AzEdgeAction'.State | Should -Be 'Cleaned'
    }

    It 'does not delete an existing resource with an unknown creation outcome' {
        $env.EdgeActionFixtures.'Get-AzEdgeAction'.State = 'Creating'
        Save-EdgeActionTestEnvironment
        $script:parentExists = $true
        { Resume-EdgeActionTestCleanup -Mode record -Name eaget0123456789ab -Confirm:$false } | Should -Throw 'Verify ownership'
        ($script:calls -join ',') | Should -Be 'Get-AzEdgeAction'
    }

    It 'clears unknown creation state only after verifying absence' {
        $env.EdgeActionFixtures.'Get-AzEdgeAction'.State = 'Creating'
        Save-EdgeActionTestEnvironment
        Resume-EdgeActionTestCleanup -Mode record -Name eaget0123456789ab -Confirm:$false
        ($script:calls -join ',') | Should -Be 'Get-AzEdgeAction'
        $saved = Get-Content (Join-Path $TestDrive 'env.json') -Raw | ConvertFrom-Json
        $saved.EdgeActionFixtures.'Get-AzEdgeAction'.State | Should -Be 'Cleaned'
    }

    It 'does not modify resources or state during recovery WhatIf' {
        $null = New-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab
        $script:calls.Clear()
        $before = Get-Content (Join-Path $TestDrive 'env.json') -Raw
        Resume-EdgeActionTestCleanup -Mode record -Name eaget0123456789ab -WhatIf
        $script:calls.Count | Should -Be 0
        Get-Content (Join-Path $TestDrive 'env.json') -Raw | Should -Be $before
    }

    It 'blocks new runs for unresolved <State> state in <File>' -TestCases @(
        @{ State = 'Creating'; File = 'env.json' }, @{ State = 'Created'; File = 'env.json' }
        @{ State = 'Creating'; File = 'localEnv.json' }, @{ State = 'Created'; File = 'localEnv.json' }
    ) {
        param($State, $File)
        $env.ResourceGroupState = 'NotCreated'
        $env.EdgeActionFixtures.'Get-AzEdgeAction'.State = $State
        $env | ConvertTo-Json -Depth 10 | Set-Content (Join-Path $TestDrive $File)
        { setupEnv } | Should -Throw 'Unfinished EdgeAction fixtures'
    }

    It 'refuses a changed <Part> before any fixture request' -TestCases @(
        @{ Part = 'Subscription' }, @{ Part = 'Tenant' }, @{ Part = 'Environment' }
    ) {
        param($Part)
        if ($Part -eq 'Environment') { $script:context.Environment.Name = 'Wrong' }
        else { $script:context.$Part.Id = 'Wrong' }
        { New-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab } | Should -Throw 'context does not match'
        { Remove-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab } | Should -Throw 'context does not match'
        $script:calls.Count | Should -Be 0
    }

    It 'rejects an unrelated fixture or group' -TestCases @(
        @{ Group = 'production'; Name = 'eaget0123456789ab' }
        @{ Group = 'rgps-powershellsdk-edgeaction-tests-0123456789ab'; Name = 'eagetdec01' }
        @{ Group = 'rgps-powershellsdk-edgeaction-tests-0123456789ab'; Name = 'eaget0123456789ac' }
    ) {
        param($Group, $Name)
        { New-EdgeActionTestResource $Group $Name } | Should -Throw 'restricted'
        { Remove-EdgeActionTestResource $Group $Name } | Should -Throw 'restricted'
        $script:calls.Count | Should -Be 0
    }

    It 'rejects a saved resource group using the Python prefix before any request' {
        $env.ResourceGroupName = 'rgpy-sdk-edgeaction-tests-0123456789ab'
        { Assert-EdgeActionTestResourceGroup } | Should -Throw 'restricted'
        $script:calls.Count | Should -Be 0
        Assert-MockCalled Get-AzContext -Times 0 -Exactly -Scope It
    }

    It 'replays saved names without requiring Azure context or writing environment files' {
        $script:TestMode = 'playback'
        $env.EdgeActionFixtures.'Get-AzEdgeAction'.State = 'Cleaned'
        Get-EdgeActionTestFixtureName 'Get-AzEdgeAction' | Should -Be 'eaget0123456789ab'
        $env.EdgeActionFixtures.'Get-AzEdgeAction'.State | Should -Be 'NotCreated'
        $null = Assert-EdgeActionTestFixture rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab
        Save-EdgeActionTestEnvironment
        setupEnv
        cleanupEnv
        Remove-EdgeActionTestResourceGroup
        $script:calls.Count | Should -Be 0
        Test-Path (Join-Path $TestDrive 'env.json') | Should -Be $false
        Assert-MockCalled Get-AzContext -Times 0 -Exactly -Scope It
    }

    It 'requires new recordings instead of falling back to fixed names' {
        $env.Remove('EdgeActionFixtures')
        { Get-EdgeActionTestFixtureName 'Get-AzEdgeAction' } | Should -Throw 'Record all scenario groups'
    }

    It 'deletes the current default <Default> last and retains it on a child failure' -TestCases @(
        @{ Default = 'v1'; Fail = $false }, @{ Default = 'v2'; Fail = $false }
        @{ Default = 'v1'; Fail = $true }, @{ Default = 'v2'; Fail = $true }
    ) {
        param($Default, $Fail)
        $null = New-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab
        $script:versions = @(
            @{ Name = $Default; IsDefaultVersion = 'True' }
            @{ Name = 'other'; IsDefaultVersion = 'False' }
        )
        $script:filters = @(@{ Name = 'filter' })
        if ($Fail) {
            $script:failCommand = 'Remove-AzEdgeActionVersion'
            { Remove-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab } | Should -Throw
            $script:calls | Should -Not -Contain 'Remove-AzEdgeAction'
            $env.EdgeActionFixtures.'Get-AzEdgeAction'.State | Should -Be 'Created'
        } else {
            Remove-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab
            $script:deletedVersions[-1] | Should -Be $Default
            $env.EdgeActionFixtures.'Get-AzEdgeAction'.State | Should -Be 'Cleaned'
        }
    }

    It 'rejects ambiguous default state before deleting versions' {
        $null = New-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab
        $script:versions = @(@{ Name = 'unknown'; IsDefaultVersion = $null })
        { Remove-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab } | Should -Throw 'cannot determine default'
        $script:deletedVersions.Count | Should -Be 0
    }

    It 'clears stale script-scoped names when setup fails before selecting a fixture' {
        $script:edgeActionName = 'previous-fixture'
        { Initialize-EdgeActionTestScenario { throw 'early setup failure' } } | Should -Throw 'early setup failure'
        $script:edgeActionName | Should -BeNullOrEmpty
        Complete-EdgeActionTestScenario $script:resourceGroupName $script:edgeActionName
        $script:calls.Count | Should -Be 0
    }

    It 'wires all fifteen groups to persisted names and explicit cleanup' {
        $root = Split-Path (Resolve-Path $sourceUtils)
        $files = @(Get-ChildItem $root -Filter '*.Tests.ps1')
        $files.Count | Should -Be 15
        foreach ($file in $files) {
            $text = Get-Content $file.FullName -Raw
            $text | Should -Match 'Get-EdgeActionTestFixtureName'
            $text | Should -Match 'Initialize-EdgeActionTestScenario'
            $text | Should -Match 'Complete-EdgeActionTestScenario'
            $text | Should -Match '\$env\.ResourceGroupName'
            $text | Should -Not -Match '"powershelltests"'
        }
    }

    It 'deletes only the run-owned group and persists completed cleanup' {
        setupEnv
        cleanupEnv
        $script:groupExists | Should -Be $false
        $saved = Get-Content (Join-Path $TestDrive 'env.json') -Raw | ConvertFrom-Json
        $saved.ResourceGroupState | Should -Be 'Cleaned'
        $saved.ResourceGroupName | Should -Be 'powershellsdk-edgeaction-tests-rgname'
        @($saved.EdgeActionFixtures.PSObject.Properties.Value | Where-Object State -NE 'Cleaned').Count | Should -Be 0
        $script:calls | Should -Contain 'Remove-AzResourceGroup'
    }

    It 'refuses an existing group without updating or deleting it' {
        $script:groupExists = $true
        { setupEnv } | Should -Throw 'already exists'
        cleanupEnv
        ($script:calls -join ',') | Should -Be 'Get-AzResourceGroup'
        $script:groupExists | Should -Be $true
    }

    It 'does not treat an inconclusive group preflight as absence' {
        $script:failCommand = 'Get-AzResourceGroup'
        { setupEnv } | Should -Throw 'offline request failure'
        cleanupEnv
        $script:calls | Should -Not -Contain 'New-AzResourceGroup'
        $script:calls | Should -Not -Contain 'Remove-AzResourceGroup'
    }

    It 'preserves uncertain group creation without deleting an existing group' {
        $script:failCommand = 'New-AzResourceGroup'
        { setupEnv } | Should -Throw 'offline request failure'
        $script:groupExists = $true
        { cleanupEnv } | Should -Throw 'not confirmed'
        $saved = Get-Content (Join-Path $TestDrive 'env.json') -Raw | ConvertFrom-Json
        $saved.ResourceGroupState | Should -Be 'Creating'
        $script:calls | Should -Not -Contain 'Remove-AzResourceGroup'
    }

    It 'recovers an uncertain group only after observing its absence' {
        $env.ResourceGroupState = 'Creating'
        Save-EdgeActionTestEnvironment
        Resume-EdgeActionTestCleanup -Mode record -ResourceGroup -Confirm:$false
        ($script:calls -join ',') | Should -Be 'Get-AzResourceGroup'
        (Get-Content (Join-Path $TestDrive 'env.json') -Raw | ConvertFrom-Json).ResourceGroupState | Should -Be 'Cleaned'
    }

    It 'retains failed group deletion and supports a fresh recovery attempt' {
        setupEnv
        $script:failCommand = 'Remove-AzResourceGroup'
        { cleanupEnv } | Should -Throw 'offline request failure'
        (Get-Content (Join-Path $TestDrive 'env.json') -Raw | ConvertFrom-Json).ResourceGroupState | Should -Be 'Created'
        $script:failCommand = ''
        Resume-EdgeActionTestCleanup -Mode record -ResourceGroup -Confirm:$false
        $script:groupExists | Should -Be $false
        (Get-Content (Join-Path $TestDrive 'env.json') -Raw | ConvertFrom-Json).ResourceGroupState | Should -Be 'Cleaned'
    }

    It 'does not mark a still-existing group cleaned' {
        setupEnv
        $script:keepGroupAfterDelete = $true
        { cleanupEnv } | Should -Throw 'still exists'
        (Get-Content (Join-Path $TestDrive 'env.json') -Raw | ConvertFrom-Json).ResourceGroupState | Should -Be 'Created'
    }

    It 'does not clean an older run from finally when setup is blocked' {
        setupEnv
        $script:calls.Clear()
        { setupEnv } | Should -Throw 'unfinished EdgeAction resource group'
        cleanupEnv
        $script:calls.Count | Should -Be 0
        $script:groupExists | Should -Be $true
    }

    It 'blocks unresolved resource groups in either mode file' -TestCases @(
        @{ State = 'Creating'; File = 'env.json' }, @{ State = 'Created'; File = 'env.json' }
        @{ State = 'Creating'; File = 'localEnv.json' }, @{ State = 'Created'; File = 'localEnv.json' }
    ) {
        param($State, $File)
        $env.ResourceGroupState = $State
        $env | ConvertTo-Json -Depth 10 | Set-Content (Join-Path $TestDrive $File)
        { setupEnv } | Should -Throw 'unfinished EdgeAction resource group'
        cleanupEnv
        $script:calls.Count | Should -Be 0
    }

    It 'rejects a changed context or shared group before RG recovery' {
        Save-EdgeActionTestEnvironment
        $script:context.Subscription.Id = 'wrong'
        { Resume-EdgeActionTestCleanup -Mode record -ResourceGroup -Confirm:$false } | Should -Throw 'context does not match'
        $script:context.Subscription.Id = 'offline-subscription'
        $env.ResourceGroupName = 'powershelltests'
        Save-EdgeActionTestEnvironment
        { Resume-EdgeActionTestCleanup -Mode record -ResourceGroup -Confirm:$false } | Should -Throw 'restricted'
        $script:calls.Count | Should -Be 0
    }

    It 'previews group recovery without any resource call or journal change' {
        setupEnv
        $script:calls.Clear()
        $before = Get-Content (Join-Path $TestDrive 'env.json') -Raw
        Resume-EdgeActionTestCleanup -Mode record -ResourceGroup -WhatIf
        $script:calls.Count | Should -Be 0
        Get-Content (Join-Path $TestDrive 'env.json') -Raw | Should -Be $before
    }

    It 'uses a separate live journal and keeps saved scenario names after cleanup' {
        $script:TestMode = 'live'
        # The mock reads the selected journal just as the harness does.
        Mock Invoke-EdgeActionTestCommand {
            if ($Command -eq 'Get-AzResourceGroup') { return @{ NotFound = $true } }
            if ($Command -ne 'New-AzResourceGroup') { throw "Unexpected command $Command" }
            (Get-Content (Join-Path $TestDrive 'localEnv.json') -Raw | ConvertFrom-Json).ResourceGroupState | Should -Be 'Creating'
        }
        setupEnv
        $name = $env.ResourceGroupName
        cleanupEnv
        $saved = Get-Content (Join-Path $TestDrive 'localEnv.json') -Raw | ConvertFrom-Json
        $saved.ResourceGroupName | Should -Be $name
        $saved.ResourceGroupState | Should -Be 'Cleaned'
        Test-Path (Join-Path $TestDrive 'env.json') | Should -Be $false
    }

    It 'normalizes RG names through the real recorder and replays without Azure resources' {
        $binary = Join-Path $PSScriptRoot '..' '..' '..' '..' '..' 'artifacts' 'Debug' 'Az.EdgeAction' 'EdgeAction.Autorest' 'bin' 'Az.EdgeAction.private.dll'
        $null = [System.Reflection.Assembly]::LoadFrom((Resolve-Path $binary))
        $path = Join-Path $TestDrive 'Offline.Recording.json'
        $liveName = $env.ResourceGroupName
        $url = "https://example.invalid/subscriptions/offline/resourceGroups/$liveName/providers/Microsoft.Cdn/edgeActions/offline"
        $pollingUrl = "$url/operations/1?api-version=2026-10-01&t=keep-t&c=keep-c&s=keep-s&h=keep-h"
        $key = "Offline+Context+Scenario+`$GET+$url+1"
        $request = [System.Net.Http.HttpRequestMessage]::new([System.Net.Http.HttpMethod]::Get, $url)
        $request.Content = [System.Net.Http.StringContent]::new('{"resourceGroup":"' + $liveName + '"}')
        $response = [System.Net.Http.HttpResponseMessage]::new([System.Net.HttpStatusCode]::OK)
        $response.Content = [System.Net.Http.StringContent]::new('{"id":"' + $url + '","name":"offline"}')
        $null = $response.Headers.TryAddWithoutValidation('Azure-AsyncOperation', $pollingUrl)
        $recorder = [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Runtime.PipelineMock]::new($path)
        try {
            $recorder.SaveMessage($key, $request, $response)
            $env.ResourceGroupState = 'Cleaned'
            Save-EdgeActionTestEnvironment
            Complete-EdgeActionTestRecording
            $text = Get-Content $path -Raw
            $text | Should -Not -Match $liveName
            $text | Should -Match 'powershellsdk-edgeaction-tests-rgname'
            $normalized = $text | ConvertFrom-Json -AsHashtable
            $normalized[$key.Replace($liveName, 'powershellsdk-edgeaction-tests-rgname')].Response.Headers.'Azure-AsyncOperation'[0] |
                Should -Match 't=keep-t&c=keep-c&s=keep-s&h=keep-h'
            $saved = Get-Content (Join-Path $TestDrive 'env.json') -Raw | ConvertFrom-Json
            $saved.ResourceGroupName | Should -Be 'powershellsdk-edgeaction-tests-rgname'
            $recorder.SetPlayback()
            $replayed = $recorder.LoadMessage($key.Replace($liveName, $saved.ResourceGroupName))
            try {
                $replayed.RequestMessage.RequestUri.AbsoluteUri | Should -Be $url.Replace($liveName, $saved.ResourceGroupName)
                $replayed.Content.ReadAsStringAsync().GetAwaiter().GetResult() | Should -Match $saved.ResourceGroupName
                @($replayed.Headers.GetValues('Azure-AsyncOperation'))[0] | Should -Be $pollingUrl.Replace($liveName, $saved.ResourceGroupName)
            } finally { $replayed.Dispose() }
            Complete-EdgeActionTestRecording
            Get-Content $path -Raw | Should -Be $text
            $script:TestMode = 'playback'
            $env.ResourceGroupName = $saved.ResourceGroupName
            $null = Assert-EdgeActionTestFixture $env.ResourceGroupName eaget0123456789ab
            setupEnv
            cleanupEnv
            $script:calls.Count | Should -Be 0
            Assert-MockCalled Get-AzContext -Times 1 -Exactly -Scope It
        } finally {
            $request.Dispose()
            $response.Dispose()
        }
    }

    It 'keeps the live name recoverable if normalization fails and retries after repair' {
        $path = Join-Path $TestDrive 'Invalid.Recording.json'
        $liveName = $env.ResourceGroupName
        $env.ResourceGroupState = 'Cleaned'
        Save-EdgeActionTestEnvironment
        '{broken "' + $liveName + '"' | Set-Content $path
        { Complete-EdgeActionTestRecording } | Should -Throw
        (Get-Content (Join-Path $TestDrive 'env.json') -Raw | ConvertFrom-Json).ResourceGroupName | Should -Be $liveName
        ('{"key":"' + $liveName + '"}') | Set-Content $path
        Resume-EdgeActionTestCleanup -Mode record -ResourceGroup -Confirm:$false
        (Get-Content (Join-Path $TestDrive 'env.json') -Raw | ConvertFrom-Json).ResourceGroupName | Should -Be 'powershellsdk-edgeaction-tests-rgname'
        $script:calls.Count | Should -Be 0
    }

    It 'does not normalize records until the RG is confirmed absent' {
        Save-EdgeActionTestEnvironment
        { Complete-EdgeActionTestRecording } | Should -Throw 'Verify resource-group cleanup'
        (Get-Content (Join-Path $TestDrive 'env.json') -Raw | ConvertFrom-Json).ResourceGroupName | Should -Be 'rgps-powershellsdk-edgeaction-tests-0123456789ab'
    }

    It 'refuses mixed live and placeholder names before changing any recording' {
        $path = Join-Path $TestDrive 'Mixed.Recording.json'
        $before = '{"one":"' + $env.ResourceGroupName + '","two":"powershellsdk-edgeaction-tests-rgname"}'
        $before | Set-Content $path
        $env.ResourceGroupState = 'Cleaned'
        Save-EdgeActionTestEnvironment
        { Complete-EdgeActionTestRecording } | Should -Throw 'mixes live and placeholder'
        (Get-Content $path -Raw).Trim() | Should -Be $before
        (Get-Content (Join-Path $TestDrive 'env.json') -Raw | ConvertFrom-Json).ResourceGroupName | Should -Be 'rgps-powershellsdk-edgeaction-tests-0123456789ab'
    }

    It 'never uses a playback placeholder for live fixture writes or group deletion' {
        $env.ResourceGroupName = 'powershellsdk-edgeaction-tests-rgname'
        { New-EdgeActionTestResource $env.ResourceGroupName eaget0123456789ab } | Should -Throw 'restricted'
        { Remove-EdgeActionTestResourceGroup } | Should -Throw 'restricted'
        $script:calls.Count | Should -Be 0
    }
}

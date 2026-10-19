# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.

# Automatic discovery is PLAYBACK ONLY. Recording is an explicitly approved,
# exact-operation workflow; never let a missing mode select live passthrough.
$cosmosServiceMode = Get-Variable -Name TestMode -ValueOnly -ErrorAction SilentlyContinue
if ([string]$cosmosServiceMode -cne 'playback') { return }
. (Join-Path $PSScriptRoot 'CosmosRecordedServiceHelpers.ps1')
$cosmosServiceFixturePath = Join-Path $PSScriptRoot 'CosmosRecordedService.Fixture.json'
$cosmosServiceRecordingPath = Join-Path $PSScriptRoot 'CosmosRecordedService.Recording.json'
if (-not (Test-Path -LiteralPath $cosmosServiceFixturePath -PathType Leaf) -or
    -not (Test-Path -LiteralPath $cosmosServiceRecordingPath -PathType Leaf)) {
    throw 'Cosmos service playback fixture/recording is missing; no live fallback is permitted.'
}
$cosmosServiceFixture = Get-Content -LiteralPath $cosmosServiceFixturePath -Raw -Encoding UTF8 | ConvertFrom-Json
$cosmosServiceExchanges = Get-Content -LiteralPath $cosmosServiceRecordingPath -Raw -Encoding UTF8 | ConvertFrom-Json
$cosmosServicePreviousPlayback = $env:AzPSAutorestTestPlaybackMode
try {
    $env:AzPSAutorestTestPlaybackMode = 'true'
    # Use Pester directly; the helper scopes its own recorder explicitly and does
    # not inherit a previous test file's HttpPipelineMocking Describe wrappers.
    pester\Describe 'CosmosRecordedService' -Tag 'CosmosRestore', 'RecordedService' {
        pester\It 'requires the complete ordered real-service case manifest' {
            $cosmosServiceFixture.SchemaVersion | Should -Be 1
            (@($cosmosServiceFixture.Cases.Name) -join '|') | Should -BeExactly 'full|single|database|mixed'
            $cosmosServiceFixture.SourceUnchanged | Should -Be $true
            foreach ($case in $cosmosServiceFixture.Cases) {
                @($case.Polls).Count | Should -BeGreaterThan 0
                @($case.Polls)[-1].Status | Should -BeExactly 'Completed'
                $case.TargetId | Should -Not -Be $cosmosServiceFixture.SourceId
            }
        }

        $cases = @(foreach ($case in $cosmosServiceFixture.Cases) { @{ Name = [string]$case.Name; RecordedCase = $case } })
        pester\It 'replays native validation, submission and every captured job snapshot for <Name>' -TestCases $cases {
            param($Name, $RecordedCase)

            # Framework keys do not compare request bodies. Compare the current
            # generated model with BOTH real captured POST bodies independently.
            $request = New-CosmosRecordedRestoreRequest -Fixture $cosmosServiceFixture -Case $RecordedCase
            $wire = $request.ToJson($null, [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode]::IncludeCreateOrUpdate).ToString() | ConvertFrom-Json
            foreach ($step in @('validate', 'submit')) {
                $prefix = "CosmosRecordedService+$Name+$step+" + '$POST+'
                $entries = @($cosmosServiceExchanges.PSObject.Properties | Where-Object { $_.Name.StartsWith($prefix, [StringComparison]::Ordinal) })
                $entries.Count | Should -Be 1
                $capturedBody = ConvertFrom-Json -InputObject $entries[0].Value.Request.Content
                $expectedBody = if ($step -ceq 'validate') { @{ restoreRequestObject = $wire } } else { $wire }
                (ConvertTo-CosmosRecordedCanonicalJson $capturedBody) | Should -BeExactly (ConvertTo-CosmosRecordedCanonicalJson $expectedBody)
            }
            $null = Invoke-CosmosRecordedExchange -Fixture $cosmosServiceFixture -Case $RecordedCase -Mode Playback `
                -RecordingPath $cosmosServiceRecordingPath -Operation Validate -Step validate
            $submission = Invoke-CosmosRecordedExchange -Fixture $cosmosServiceFixture -Case $RecordedCase -Mode Playback `
                -RecordingPath $cosmosServiceRecordingPath -Operation Submit -Step submit
            $id = ([string]$submission.JobId).TrimEnd('/').Split('/')[-1]
            $id | Should -BeExactly ([string]$RecordedCase.JobId)
            $job = $null
            foreach ($poll in $RecordedCase.Polls) {
                $job = Invoke-CosmosRecordedExchange -Fixture $cosmosServiceFixture -Case $RecordedCase -Mode Playback `
                    -RecordingPath $cosmosServiceRecordingPath -Operation Job -Step ([string]$poll.Step) -JobId $id
                $job.Status | Should -BeExactly ([string]$poll.Status)
                $job.BackupInstanceId | Should -Be ([string]$cosmosServiceFixture.BackupInstanceId)
                $job.OperationCategory | Should -BeExactly 'Restore'
                if ($job.SourceRecoverPointRecoveryPointId) {
                    $job.SourceRecoverPointRecoveryPointId | Should -BeExactly ([string]$cosmosServiceFixture.RecoveryPointId)
                }
            }
            $job.Status | Should -BeExactly 'Completed'
        }
    }
} finally {
    $env:AzPSAutorestTestPlaybackMode = $cosmosServicePreviousPlayback
}
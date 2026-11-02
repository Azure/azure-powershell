# Copyright Microsoft Corporation. Licensed under the Apache License, Version 2.0.
#Requires -Version 7.0
Import-Module (Join-Path $PSScriptRoot '..' 'EdgeAction.TestRunner.psm1') -Force

Describe 'Runner cleanup result propagation' {
    It 'rejects failed cleanup XML even when the child exit code is <ExitCode>' -TestCases @(
        @{ ExitCode = 1 }, @{ ExitCode = 0 }
    ) {
        param($ExitCode)
        $xml = Join-Path $TestDrive 'cleanup.xml'
        @'
<test-results total="1" errors="0" failures="1" not-run="0" inconclusive="0" ignored="0" skipped="0" invalid="0">
  <test-suite name="CleanupLifecycleFixture" success="False">
    <results><test-case name="cleanup" success="False"><failure><message>fixture cleanup conflict</message></failure></test-case></results>
  </test-suite>
</test-results>
'@ | Set-Content $xml
        { & (Get-Module EdgeAction.TestRunner) { param($Path, $Code)
            Assert-EdgeActionResults $Path ([datetime]::MinValue) $Code
        } $xml $ExitCode } | Should -Throw

        $artifact = Join-Path $TestDrive 'artifact'
        $null = New-Item -ItemType Directory (Join-Path $artifact 'test') -Force
        & (Get-Module EdgeAction.TestRunner) {
            param($Root, $Results, $Code)
            $script:Artifact = $Root
            $script:fixtureResults = $Results
            $script:fixtureExitCode = $Code
        } $artifact $xml $ExitCode
        InModuleScope EdgeAction.TestRunner {
            Mock Get-EdgeActionTestConfig { @{} }
            Mock Assert-EdgeActionMutation {}
            Mock Update-EdgeActionArtifactTests { @{} }
            Mock Get-EdgeActionRecordingState { @{} }
            Mock Invoke-EdgeActionTestChild {
                $destination = Join-Path $script:Artifact 'test' 'Az.EdgeAction-TestResults.xml'
                Copy-Item $script:fixtureResults $destination
                (Get-Item $destination).LastWriteTimeUtc = [datetime]::UtcNow
                return $script:fixtureExitCode
            }
            Mock Copy-EdgeActionRecordingsForReview {}
            # Fail closed before real bootstrap if a mock is bypassed.
            { Invoke-EdgeActionTests @{
                Mode = 'Record'; AllowResourceChanges = $false
                ConfigPath = (Join-Path $script:Artifact 'nonexistent-fixture-settings.psd1')
            } } | Should -Throw
            Assert-MockCalled Invoke-EdgeActionTestChild -Times 1 -Exactly -Scope It
            Assert-MockCalled Copy-EdgeActionRecordingsForReview -Times 0 -Exactly -Scope It
        }
    }
}

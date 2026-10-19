# Test
This directory contains the [Pester](https://www.powershellgallery.com/packages/Pester) tests to run for the module. We use Pester as it is the unofficial standard for PowerShell unit testing. Test stubs for custom cmdlets (created in `..\custom`) will be generated into this folder when `build-module.ps1` is ran. These test stubs will fail automatically, to indicate that tests should be written for custom cmdlets.

## Info
- Modifiable: yes
- Generated: partial
- Committed: yes
- Packaged: no

## Details
We allow three testing modes: *live*, *record*, and *playback*. These can be selected using the `-Live`, `-Record`, and `-Playback` switches respectively on the `test-module.ps1` script. This script will run through any `.Tests.ps1` scripts in the `test` folder. If you choose the *record* mode, it will create a `.Recording.json` file of the REST calls between the client and server. Then, when you choose *playback* mode, it will use the `.Recording.json` file to mock the communication between server and client. The *live* mode runs the same as the *record* mode; however, it doesn't create the `.Recording.json` file.

## Purpose
Custom cmdlets generally encompass additional functionality not described in the REST specification, or combines functionality generated from the REST spec. To validate this functionality continues to operate as intended, creating tests that can be ran and re-ran against custom cmdlets is part of the framework.

## Cosmos restore test layers

The Cosmos restore work uses the same Pester 4.10.1 test directory and standard
module runner, with distinct execution layers:

| Tests | Purpose | Service recording |
| --- | --- | --- |
| [Configuration](CosmosRestoreConfiguration.Tests.ps1), [regression](CosmosRestoreRegression.Tests.ps1), [shared identity](CosmosRestoreSharedIdentity.Tests.ps1) | Local typed request construction, validation, generated JSON and existing-workload compatibility | No service HTTP to record |
| [Permissions](CosmosRestorePermission.Tests.ps1) | Native permission helper with role reads, writes and waits mocked | No live grants to record |
| [Transport](CosmosRestoreTransport.Tests.ps1) | Public commands through the actual generated serializer, captured by a terminating local HTTP interceptor | No live HTTP; exact body assertions supplement recording playback |
| [Scenario-tool contracts](CosmosRestoreHarness.Tests.ps1) | Isolated function/AST checks for ownership, state, identity, sanitization and no duplicate submissions | No live entrypoint execution |
| [Cosmos recorded service](CosmosRecordedService.Tests.ps1) | Actual full, single-container, database-only and mixed validation/restore/job responses | 55 genuine sanitized exchanges from four completed, independently data-verified SAMI restores |
| Existing recorded module scenarios | Native service operations captured through the standard recorder | Real record-mode capture followed by playback |

Use a fresh process after building the tracked DataProtection project. To select
only the six offline suites, import Pester 4.10.1 from an approved dependency
location on the process module path, import the built module, and invoke Pester
with those explicit artifact test files. Do not depend on the ignored source
generation cache or replace the loaded module with a Gallery copy. These suites
do not require an installed Az.Resources module to make their offline mocks work.

```powershell
$ErrorActionPreference = 'Stop'
$env:PSModulePath = (Join-Path $PWD 'artifacts/Debug') + [IO.Path]::PathSeparator + $env:PSModulePath
$artifact = Join-Path $PWD 'artifacts/Debug/Az.DataProtection/DataProtection.Autorest'
Import-Module Pester -RequiredVersion 4.10.1
Import-Module (Join-Path $artifact 'Az.DataProtection.psd1')
$files = @(Get-ChildItem (Join-Path $artifact 'test') -Filter 'CosmosRestore*.Tests.ps1' -File)
if ($files.Count -ne 6) { throw 'Expected all six Cosmos suites.' }
$result = Invoke-Pester -Script $files.FullName -PassThru
$result | Select-Object TotalCount, PassedCount, FailedCount, SkippedCount, PendingCount
if ($result.TotalCount -eq 0 -or $result.FailedCount -gt 0 -or
	$result.SkippedCount -gt 0 -or $result.PendingCount -gt 0) {
	throw 'The selected offline suites must all pass without skips.'
}
```

Complete module `-Playback` is a separate integration gate and includes existing
unrelated skipped placeholders. The standard runner imports dependencies and
sets up the recording mode before test discovery. Offline CI should use prepared
dependencies and fail-closed network isolation rather than assuming playback
alone prevents every possible outbound request.

### Recording is not the same as an offline test pass

`test-module.ps1 -Record` captures actual REST interactions; local configuration
tests and mocked calls do not produce service evidence. Do not create empty or
synthetic recording files merely for those suites. Existing native Cosmos restore
reports are not recording files and cannot retrospectively be presented as such.
Cosmos ILR now has separate genuine recorded service coverage, described below.

### Cosmos recorded service coverage

[CosmosRecordedService.Tests.ps1](CosmosRecordedService.Tests.ps1) replays the
[recording](CosmosRecordedService.Recording.json) using its own sanitized
[fixture](CosmosRecordedService.Fixture.json), never the shared environment or a
cached live context. Standard module Playback discovers its five cases. For an
exact-file run after importing the built module and Pester 4.10.1:

```powershell
$TestMode = 'playback'
$result = Invoke-Pester -Script (Join-Path $artifact 'test/CosmosRecordedService.Tests.ps1') -PassThru
if ($result.PassedCount -ne 5 -or $result.FailedCount -gt 0 -or
	$result.SkippedCount -gt 0 -or $result.PendingCount -gt 0) {
	throw 'All five recorded-service tests must pass.'
}
```

On 2026-10-19, an explicitly approved, exact-operation capture used the existing
test BI and original committed RP with four new owned, completely empty targets.
The native generated `PipelineMock.SetRecord()` captured validation, submission
and job snapshots in separate private fragments, without unfiltered test discovery,
recording bootstrap erasure or shared setup/cleanup. Each accepted submission was
checkpointed and never repeated. Only real responses were merged; terminal
`Completed` and job identity were checked against the captured bodies.

| Case | Selection | Independently verified databases / containers / documents |
| --- | --- | --- |
| Full | No ILR configuration | 3 / 7 / 14 |
| Single | `db1/cont1` | 1 / 1 / 2 |
| Database | `db2` | 1 / 2 / 4 |
| Mixed | `db1/col1`, `db1/col2`, `db2` | 2 / 4 / 8 |

Private native verification compared complete inventory, partition keys and exact
application documents with the frozen backup baseline, excluded post-backup data,
and confirmed the source remained unchanged. Data-plane documents are not published
in these management-plane recordings. Playback proves the captured native protocol,
not a fresh data comparison. UAMI and malformed-selector service cases are not part
of this new recording.

Identifiers are consistently pseudonymized across fixture inputs, recording keys,
URIs, headers and embedded bodies; methods, API versions, selectors and actual
response statuses remain intact. Tests additionally compare both captured POST
bodies against current generated JSON, because recorder matching alone ignores the
body. Credential-free, outbound-blocked replay passed on Core, Desktop and Linux.
All 18 pre-existing recording/environment files retained their original hashes.

The suite returns without work for absent, live or generic-record modes, and fails
closed for missing playback evidence. Re-recording requires a separately approved
fixture and exact-operation scope; do not remove the guard or interpret the public
sanitized fixture as a live resource configuration. No cleanup is automatic.

The current runner's `-TestName` filters Pester `Describe` blocks, not file
discovery. Other files can still execute top-level setup; in record mode the
recording bootstrap can erase recording files before any `Describe` filter applies.
`LiveOnly` suites are excluded from ordinary Playback and Record. Never run an
unfiltered Record/Live command against cached fixtures, combine modes to bypass
that exclusion, or execute legacy service files without their complete playback
setup. A new recording requires an explicitly approved fixture, exact test scope,
reviewed resource operations and a safe preservation/recording plan.

The module-local [opt-in Cosmos scenario tools](scenarios/CosmosRestore/README.md)
are not Pester test files and are never invoked by test setup. They require their
own explicit live opt-in. Moving them into this directory does not authorize a
cloud operation or make their native runs recording-backed tests.

## Usage
To execute tests, run the `test-module.ps1`. To write tests, [this example](https://github.com/pester/Pester/blob/8b9cf4248315e44f1ac6673be149f7e0d7f10466/Examples/Planets/Get-Planet.Tests.ps1#L1) from the Pester repository is very useful for getting started.
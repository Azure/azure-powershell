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

## Usage
To execute tests, run the `test-module.ps1`. To write tests, [this example](https://github.com/pester/Pester/blob/8b9cf4248315e44f1ac6673be149f7e0d7f10466/Examples/Planets/Get-Planet.Tests.ps1#L1) from the Pester repository is very useful for getting started.

## Offline module regressions

These suites validate module behavior without Azure authentication or resource operations. Use Pester 4.10.1 on Windows PowerShell 5.1 and PowerShell 7. The [module development guide](../how-to.md#offline-module-regressions) provides the repository-root command for the fixture and Update suites; the response-contract and recording-normalization suites can also run individually with `Invoke-Pester -Script <suite-path>`.

| Suite | Coverage | Module build required |
| --- | --- | --- |
| `FixtureOwnership.Tests.ps1` | Run-owned fixtures and resource groups, persisted cleanup state, and recorder round trips. | Yes, for the recorder round trip. |
| `ScenarioCleanup.Tests.ps1` | Cleanup ordering, HTTP errors, scenario wiring, and cleanup failures in Pester results. | No. |
| `RecordingLifecycle.Tests.ps1` | Setup/cleanup recording contexts and replay after skipped scenarios. | No. |
| `UpdateScenarios.Tests.ps1` | Maintained Update scenario bodies with offline command doubles. | No. |
| `UpdateSerialization.Tests.ps1` | Generated client request bodies through an in-memory transport. | Yes. |
| `LocationResponse.Tests.ps1` | Response-contract assertions using valid and invalid responses. | No. |
| `RecordingNormalization.Tests.ps1` | Record cleanup and normalization recovery, including case-sensitive lookup keys and collision detection. | No. |

### Isolation and fixture ownership

The fixture, cleanup, lifecycle, and Update suites isolate command doubles and helper state in temporary modules. Fixture persistence uses Pester's `TestDrive`, not the maintained environment files or recordings. Lifecycle fixtures run in child processes of the current PowerShell edition so nested Pester execution cannot contaminate the caller's results.

Scenario-wiring checks use `Get-EdgeActionTestFixturePrefixes` from `utils.ps1` to identify resource scenarios. Do not treat every `*.Tests.ps1` file as a resource scenario: this directory also contains offline regressions. Expected scenario files must exist and use the maintained fixture setup and cleanup helpers.

Module cleanup tests check that setup/scenario failures remain visible alongside teardown failures in both the process exit code and Pester XML results. Recording-lifecycle tests verify that setup and cleanup have separate recording contexts, including when a scenario ends with a skipped test.

### Binary resolution and discovery

The recorder and serialization tests use the already-loaded module runtime when available. Otherwise, tests running from an artifact module use its `bin` directory; tests running from source use `artifacts\Debug\Az.EdgeAction\EdgeAction.Autorest\bin`. These tests do not generate or build the module automatically.

The normal artifact harness discovers the offline suites alongside resource scenarios. Selecting a cmdlet with `-TestName` excludes unrelated offline groups. Offline regressions do not replace full scenario Playback against reviewed recordings. When changing recording normalization, run its regression suite on both PowerShell editions: Playback alone does not exercise Record cleanup and recovery.
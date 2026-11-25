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

DocumentDB user tests require a real Microsoft Entra principal object ID when running
in record or live mode. Set `DOCUMENTDB_TEST_USER_OBJECT_ID` before invoking
`test-module.ps1`; when it is not set, the test setup attempts to use the current
account's home object ID. Record cleanup replaces that ID with the playback placeholder
and removes administrator passwords from request bodies before recordings are committed.

## Offline request and output regression tests

`DocumentDB.StableApi.Request.Tests.ps1` and
`Switch-AzDocumentDBMongoCluster.Request.Tests.ps1` inspect the actual generated HTTP
request URI and serialized JSON body, not mocked cmdlet arguments or recording matches.
The stable-API suite also captures the real GET + PUT when a returned cluster is piped
into an update that adds or removes a user-assigned identity. It checks exact membership
and retained properties. A negative control rejects a PUT missing an identity even when
the synthetic response contains both identities; recorded responses alone cannot prove
the request was correct.
`Get-AzDocumentDBMongoClusterConnectionString.Request.Tests.ps1` verifies both returned
connection-string values through `ConnectionString1` under strict mode, using a synthetic
response and boolean assertions that do not expose credentials.

These suites require Pester 4.10.1 and a built candidate module. Run them in a fresh PowerShell
process after importing those dependencies; `$moduleRoot` below is the built candidate's
`DocumentDB.Autorest` directory:

```powershell
Import-Module (Join-Path $moduleRoot 'Az.DocumentDB.psd1') -ErrorAction Stop
$testRoot = Join-Path $moduleRoot 'test'
Invoke-Pester -Script @(
    (Join-Path $testRoot 'DocumentDB.StableApi.Request.Tests.ps1')
    (Join-Path $testRoot 'Switch-AzDocumentDBMongoCluster.Request.Tests.ps1')
    (Join-Path $testRoot 'Get-AzDocumentDBMongoClusterConnectionString.Request.Tests.ps1')
) -PassThru
```

These suites do not load `loadEnv.ps1`, require Azure credentials, or depend on
`TestMode`. They fail if the module is not already loaded rather than automatically
importing it. Use a network-denying runner when the import itself must also be offline.
Their shared `DocumentDB.RequestTestHelpers.ps1` explicitly selects playback,
captures requests in a terminal pipeline step, and returns bounded synthetic responses
without calling the network. A temporary module-level guard rejects requests that miss
the capture step; the saved request and telemetry callbacks are restored after each suite.

The stable-API suite uses `NoWait` to test create/update/reset serialization without
long-running-operation polling. This does not certify operation completion, polling, or
result objects. Normal integration tests remain necessary. The permanent assertions
require API `2026-09-01`; passing experiments with a June baseline does not validate the
September candidate or replace its build, offline, and service integration checks.
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
`ChangeSafety.Tests.ps1` adds creation, update and deletion `-AcquirePolicyToken`
cases with their own `ChangeSafety.Recording.json` and `ChangeSafety.env.json`.
They use a dedicated resource group owned by the module's scenario-based
setup/cleanup. Selecting this suite does not provision the migration fixtures.
The dedicated cache uses the generally available `eastus` location, independently
of the shared upstream scenarios' location.
Record/Live assert a nonempty policy header on outgoing writes; the existing
recorder blacklist filters its value. Playback does not acquire a token or run
that transport assertion. GET-header isolation is not asserted.

Record this suite with `-Record -TestName RedisEnterpriseCache-ChangeSafety`.
The suite keeps its own fixture metadata and recording normalization, separate
from the shared environment replacement used by the upstream scenarios.
After the recorded cases finish, test-level normalization replaces signed
polling URL query values (`t`, `c`, `s`, `h`) with `Sanitized` in request lookup
keys, request URIs and `Azure-AsyncOperation`/`Location` response headers.
It preserves API versions and response payloads, rejects lookup-key collisions,
and does not modify live requests or the recorder.
`RecordingNormalization.Tests.ps1` covers this normalization offline on
PowerShell Core and Windows PowerShell.
The existing harness can initialize recording files even for unselected scenarios,
so preserve unselected recordings before a focused Record run.

The Change Safety recording was regenerated with the original Record workflow
against the module's current `2026-09-01` API. When the API changes, regenerate
the recording and matching fixture metadata rather than rewriting API versions
in the recording.

To execute tests, run the `test-module.ps1`. To write tests, [this example](https://github.com/pester/Pester/blob/8b9cf4248315e44f1ac6673be149f7e0d7f10466/Examples/Planets/Get-Planet.Tests.ps1#L1) from the Pester repository is very useful for getting started.
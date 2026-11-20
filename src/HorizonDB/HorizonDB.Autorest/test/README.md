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

## Recording consistency
Playback recordings are keyed by exact request URLs, so the fixture names in
`env.json` must match all recordings that use them. When recording only selected
suites, pass `-UsePreviousConfigForRecord` to preserve the saved fixture names:

```powershell
pwsh -NoProfile -File .\src\HorizonDB\HorizonDB.Autorest\test-module.ps1 -Record -UsePreviousConfigForRecord -TestName Get-AzHorizonDbCluster,Get-AzHorizonDbNode,Get-AzHorizonDbPool,Update-AzHorizonDbCluster,Update-AzHorizonDbPool
```

If fixture names are intentionally regenerated, re-record every suite using
those fixtures before running full playback. Do not update recording keys alone;
recorded response bodies also contain the resource names and IDs.

## Shared HorizonDB fixture
In record and live modes, `setupEnv` creates a dedicated resource group and deploys
`prereqs.json` through `New-AzDeployment`. The deployment waits for a PostgreSQL 17
cluster and its pool to finish provisioning before tests start. The location is
`indiasouthcentral`, with geo-redundancy and public access disabled. The pool uses
two provisioned Intel generation 1 vCores, one node, and no high availability.

The cluster update test changes backup retention to 9 days. The pool update test
scales the shared pool to 4 vCores. Both tests read the resource back to verify
the update. Run Get tests before Update tests when sharing one fixture.

After deployment, setup discovers the pool's generated node name and resource ID.
Tests can use `$env.sharedResourceGroup`, `$env.sharedClusterName`,
`$env.sharedPoolName`, `$env.sharedNodeName`, and `$env.sharedNodeId`. These values
are saved in `env.json` for recording or `localEnv.json` for live runs, so node
List and Get tests do not depend on one another.

When parameter-group Get or Update tests are selected, setup also creates
`sharedParameterGroupName` in `sharedResourceGroup`, with PostgreSQL 17 and the
four supported production parameter overrides from the API example. The service
does not recognize `wal_receiver_timeout` in `indiasouthcentral`, so it is omitted.
Get tests verify the
initial values, including `work_mem` set to `8192`. Update sets only `work_mem`
to `16384` and reads it back. Run parameter-group Get tests before Update tests.

When New-cluster, New-pool, New-firewall-rule, New-Microsoft-Entra-authentication,
New-password-authentication, or New-parameter-group
is selected, setup also creates the separate `clusterResourceGroup`.
The New-cluster test creates a completely
new `clusterName`, which is not used by any other creation test.
The same test file has an independent `Delete` case that creates a separate
cluster named `clusterName` plus `-delete`, removes it with
`Remove-AzHorizonDbCluster`, and verifies it is absent from the resource group's
cluster list. It does not reuse the cluster from `CreateExpanded` or any other
fixture.

New-parameter-group creates `newParameterGroupName` in `clusterResourceGroup`
with the production tag, description, PostgreSQL 17, and all four overrides.
Its independent `Delete` case creates a separate name with the `-delete` suffix,
removes it, and verifies it is absent from the resource group's parameter-group
list. Neither case uses the shared parameter group.

For New-pool, setup creates the distinct `newClusterPoolName` without a pool.
The test creates `newPoolName` in that cluster with two Intel generation 1 vCores
through the JSON parameter set, which includes the required compute-model type.
For New-firewall-rule, setup deploys `newClusterName` and `newPoolName` using
`prereqs.json`. The test creates a rule for `10.0.0.1` through `10.0.0.254`, with
the description `Allow access from the corporate network`. The same test file
includes an independent `Delete` case that creates its own rule, removes it with
`Remove-AzHorizonDbFirewallRule`, and verifies it is absent from the pool's rule
list. It does not depend on `CreateExpanded` running first. These tests can run
independently and never use the `shared` resources reserved for Get and Update
tests. Both authentication tests enable authentication on `newClusterName`.
The Microsoft Entra test verifies the `microsoftEntra` resource. The password
test verifies the `passwordMethod` resource and administrator login `adminlogin1`.
Its password is generated at runtime, passed as a SecureString, and redacted
from the recording even when creation fails. When authentication tests run
without New-firewall-rule, setup creates only that cluster, without an unused
pool. All three tests use the same prerequisite cluster. None uses the
standalone `clusterName`. All creation resources remain available until suite cleanup.

`cleanupEnv` deletes the shared and creation resource groups after testing,
including after failures. Cleanup only targets groups successfully created by
this run and does not retry groups whose deletion has already succeeded.
Playback skips provisioning and cleanup and uses saved environment values and
recordings. Shared fixture provisioning is outside individual test recordings.
New-test prerequisite provisioning is also outside individual test recordings.
Recordings are saved for the New-cluster, New-pool, New-firewall-rule,
New-Microsoft-Entra-authentication, and New-password-authentication tests.
The New-cluster and New-firewall-rule recordings include their `Delete`
scenarios. The standalone Remove-cluster and Remove-firewall-rule tests are
skipped and do not produce separate recordings.
Parameter-group recordings are saved for New, Get, and Update; the New recording
also includes its independent `Delete` scenario.
Record and live runs create billable Azure resources.
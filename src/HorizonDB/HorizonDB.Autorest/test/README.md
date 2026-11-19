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
List and Get tests do not depend on one another. The New-cluster test retains its separate
`clusterResourceGroup` and `clusterName` values so it cannot delete this fixture.

`cleanupEnv` deletes the shared resource group after testing, including after a
failed deployment. Cleanup only targets a group successfully created by this run.
Playback skips provisioning and cleanup and uses saved environment values and
recordings. Shared fixture provisioning is outside individual test recordings.
Record and live runs create billable Azure resources.
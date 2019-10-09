## CI Filter

### What is the CI Filter?

The CI filter is a set of tooling that looks at the files changed in a pull request and makes decisions about what processes should occurr during the pull request's CI. These decisions include the following:

- Which projects to build
- Which tests to run
- Which modules to generate help for
- Which modules to run static analysis on

This filtering allows for faster build times as we are no longer building _every_ project, running _every_ test, generating _all_ help and running static analysis on _everything_, but rather only on the services that are being updated in the pull request and the services that depend on them.

### `CreateFilterMappings.ps1`

The [`CreateFilterMappings.ps1`](https://github.com/Azure/azure-powershell/blob/2d66db5b781f6b1bffe5ff6ff6825c69c8af5848/tools/CreateFilterMappings.ps1) script is responsible for creating the `.json` files that will later be used to determine what modules and `.csproj` files should be used based on the files changed in the pull request. This script currently creates two `.json` files:

- `ModuleMappings.json`
    - This file is a mapping between paths in the repository and the corresponding module found in that path
        - _e.g._, the path `src/KeyVault` is be mapped to `Az.KeyVault`
    - This file is used with the static analysis filter
- `CsprojMappings.json`
    - This file is a mapping between paths in the repository and the corresponding `.csproj` projects that should be built and used later for testing
        - _e.g._, `src/ApplicationInsights` is mapped to the projects in the `ApplicationInsights` folder (`ApplicationInsights.csproj` and `ApplicationInsights.Test.csproj`), the projects in the `Monitor` folder (`Monitor.csproj` and `Monitor.Test.csproj`) since the `Monitor` tests have a dependency on the `ApplicationInsights` cmdlets, and the `Accounts.csproj` (this needs to be built for any module)
    - This file is used with the build and test filters

The script also excludes certain paths from being processed, which the [`FilterTask`](#filtertask) will interpret as "include everything" (_e.g._, any changes inside of the `tools` folder will cause everything to be built and tested).

### Build Tasks

The [`Microsoft.Azure.Build.Tasks`](https://github.com/Azure/azure-powershell/tree/2d66db5b781f6b1bffe5ff6ff6825c69c8af5848/tools/BuildPackagesTask/Microsoft.Azure.Build.Tasks) folder contains the project that's built and exports tasks that are used during our build. The two tasks that are leveraged by the CI filter are the `FilesChangedTask` and the `FilterTask`.

#### `FilesChangedTask`

The [`FilesChangedTask`](https://github.com/Azure/azure-powershell/blob/2d66db5b781f6b1bffe5ff6ff6825c69c8af5848/tools/BuildPackagesTask/Microsoft.Azure.Build.Tasks/FilesChangedTask.cs) is used to determine the list of files that were changed in a given pull request. The task requires that the user provides the following parameters:

- `RepositoryOwner`
    - The fork of the repository (`Azure`)
- `RepositoryName`
    - The name of the repository (`azure-powershell`)
- `PullRequestNumber`
    - The number of the pull request to get the files changed from (provided by ADO)

The task uses the [`Octokit`](https://www.nuget.org/packages/Octokit/) package to make calls to GitHub, specifically in this case to retrieve the files changed in the given pull request. These files, which are all relative paths in the repository, are returned with the `FilesChanged` output property.

#### `FilterTask`

The [`FilterTask`](https://github.com/Azure/azure-powershell/blob/2d66db5b781f6b1bffe5ff6ff6825c69c8af5848/tools/BuildPackagesTask/Microsoft.Azure.Build.Tasks/FilterTask.cs) takes the files changed in a pull request and determines whichs items to return from the given `.json` file. The task requires that the user provides the following parameters:

- `FilesChanged`
    - The list of files changed in the pull request, passed from the `FilesChangedTask`
- `MapFilePath`
    - The path to the `.json` mappings file that will be used for this task (either `ModuleMappings.json` or `CsprojMappings.json`)

The task then determines which items from the `.json` file should be returned based on the files changed, returning all items defined in the `.json` file if a path can't be mapped to any of the given keys. These items are returned with the `Output` output property.

### `FilterBuild` Target

The [`FilterBuild`](https://github.com/Azure/azure-powershell/blob/2d66db5b781f6b1bffe5ff6ff6825c69c8af5848/build.proj#L98-L127) target in the `build.proj` uses the above tasks to determine which modules and `.csproj` files should be processed during the build. The [`Build`](https://github.com/Azure/azure-powershell/blob/2d66db5b781f6b1bffe5ff6ff6825c69c8af5848/build.proj#L130-L177) target depends on the completion of the `FilterBuild` target, so it's guaranteed that all builds can be filtered over a given pull request, if it is provided as a part of the `msbuild` command that was run.

The result of the `FilesChangedTask` is assigned to a property called `FilesChanged`; this property is then used with two calls to `FilterTask`:

- Using the `ModuleMappings.json` file, the result of the `FilterTask` is assigned to a property called `ModulesChanged`
- Using the `CsprojMappings.json` file, the result of the `FilterTask` is assigned to a property called `ProjectsToBuild`

### Build and Test Filter

Inside of the `Build` target, the `Azure.PowerShell.sln` file that we create for the build is populated with `.csproj` files that should be built and tested later on. When the `PullRequestNumber` property is providied as a part of the `msbuild` command, the `ProjectsToBuild` property from the previous `FilterTask` is used to [populate the solution with the filtered `.csproj` files](https://github.com/Azure/azure-powershell/blob/2d66db5b781f6b1bffe5ff6ff6825c69c8af5848/build.proj#L151). If `PullRequestNumber` wasn't provided as a part of the `msbuild` command, then [all of the `.csproj` files are included](https://github.com/Azure/azure-powershell/blob/2d66db5b781f6b1bffe5ff6ff6825c69c8af5848/build.proj#L141-L147).

When [`dotnet build`](https://github.com/Azure/azure-powershell/blob/2d66db5b781f6b1bffe5ff6ff6825c69c8af5848/build.proj#L160) is then run on this solution, only the projects specific to the files changed will be built and tested. For each service, `A` (_e.g._, `src/A/`), that's updated in the pull request, the following are checked:

- If service `A` is referenced in the tests for service `B`, then we add service `B`'s cmdlet and test projects to the solution so that we can ensure that changes to service `A` don't break the tests of service `B`
- If service `A` references service `C` in its tests, then we add service `C`'s cmdlet proejct to the solution so we can ensure that service `C` is available to use in service `A`'s tests

### Static Analysis Filter

When calling [`StaticAnalysis.Netcore.dll`](https://github.com/Azure/azure-powershell/blob/2d66db5b781f6b1bffe5ff6ff6825c69c8af5848/build.proj#L205), we provide an argument for the `-m` (or `--modules-to-analyze`) parameter that is `ModulesChanged`. This list of modules changed is passed through to static analysis and used to determine which modules we should run the various analyzers against.

### Help Generation Filter

Although it doesn't directly use the result of one of the filters, when we call [`GenerateHelp.ps1`](https://github.com/Azure/azure-powershell/blob/2d66db5b781f6b1bffe5ff6ff6825c69c8af5848/build.proj#L194) during the build to generate the MAML help that is shipped with our modules, the output folders from the build are used to determine which modules to generate help for. If a module wasn't built as a part of the build, then its folder would not be located in the `artifacts/Debug` output folder, and it will not have any help generated.

# Batch Powershell Data Model Generator

This executable automatically generates the PowerShell data model classes used by the Azure Batch PowerShell cmdlets.

## Usage

```shell
dotnet run <The file path to the Microsoft.Azure.Batch.dll to operate on>
```

The path must be absolute.

The project targets .NET 5, which is out of support. If the .NET 5 runtime is not installed, set `DOTNET_ROLL_FORWARD` to `LatestMajor` to run it on the newest installed runtime:

```powershell
$env:DOTNET_ROLL_FORWARD = 'LatestMajor'
dotnet run <The file path to the Microsoft.Azure.Batch.dll to operate on>
```

The models are written to the `GeneratedFiles` directory under the current directory.

## Updating with new models

Once generation succeeds, you may delete the old models inside `azure-powershell\src\Batch\Batch\Models.Generated` and replace them with the new models from the `GeneratedFiles` directory.

Models and properties that were removed from the module are listed in `OmittedTypes` and `OmittedProperties` in `Program.cs`. To remove a model or a property, add it there rather than editing the generated files, so the next run doesn't bring it back.

Every generated file records the .NET runtime version in its header (`Runtime Version:`). To see only the real changes, compare with:

```shell
git diff --no-index -I "Runtime Version:" -- src/Batch/Batch/Models.Generated <path to GeneratedFiles>
```

# A package dependency comparing cmdlet

The goal of this cmdlet is to compare two versions of a nuget package and report the differences about dependencies between them.

Note the cmdlet not only reports added/removed dependencies, but also reports dependencies that changed their version between the two package versions. For changed dependencies, it compares the old and new versions recursively to report all changes in the dependency tree.

## Example usage

```powershell
Compare-DevPackageDep -PackageName "Azure.Core" -OldVersion "1.47.3" -NewVersion "1.50.0" -TargetFramework "netstandard2.0"

# Output:
DepName            OldVersion NewVersion ParentDep
-----------        ---------- ---------- -------------
System.ClientModel 1.6.1      1.8.0      Azure.Core
```

## Cmdlet design considerations

- `TargetFramework` is optional and defaults to `netstandard2.0` if not specified. Add argument completer (not validate set) for it. Possible values: `netstandard2.0`, `net45`, `net46`, `net47`, `net461`, `net462`.
- In debug mode, list all dependencies with their versions for both old and new package versions.

## Implementation details

- Leverage `INugetService` to get dependencies of a package version. Do not re-implement nuget package reading logic.
- Mock `INugetService` in tests to avoid downloading packages from nuget.org.

## Static Analysis

### What is the purpose of Static Analysis?

Static analysis is a tool that runs during each CI build to ensure that the changes being introduced in a pull request follow PowerShell standards and patterns, don't make any breaking changes, contain the appropriate markdown help files for cmdlets, and don't introduce any mismatching package dependencies. Each of these tasks are contained within their own analyzer, as described in the sections down below.

### Analyzers

Each analyzer implements the [`IStaticAnalyzer`](https://github.com/Azure/azure-powershell/blob/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/StaticAnalysis/IStaticAnalyzer.cs) interface, which describes how to analyze and validate the given modules. The `IStaticAnalyzer` interface defines overloads of the `Analyze` method that each analyzer needs to implement.

#### Breaking Change Analyzer

The breaking change analyzer can be found in the [`BreakingChangeAnalyzer`](https://github.com/Azure/azure-powershell/tree/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/StaticAnalysis/BreakingChangeAnalyzer) folder. In this folder, you will find the following classes:

- `BreakingChangeAnalyzer`
    - The implementation of the `IStaticAnalyzer` interface; determines which modules to analyze, deserializes the modules' `.json` file from the `SerializedCmdlets` folder, and runs breaking change checks between the old (serialized) `ModuleMetadata` object and the new `ModuleMetadata` object constructed from the `CmdletLoader` in the `Tools.Common` project
- `BreakingChangeIssue`
    - The implementation of the `IReportRecord` interface; defines what a breaking change exception looks like when it's reported in the `BreakingChangeIssues.csv` file that is found in the build artifacts of a CI run, as well as how to compare a new record to a record found in the existing `BreakingChangeIssues.csv` file used for exception suppressions
- `CmdletMetadataHelper`
    - This class contains methods used to find breaking changes between one set of `CmdletMetadata` objects and another. The following methods are defined in this class:
        - `CompareCmdletMetadata()`
            - Compares two sets of `CmdletMetadata` objects. Each old cmdlet is mapped to a new cmdlet and the different breaking change checks are performed. If an old cmdlet cannot be mapped, a breaking change is logged.
        - `CheckForRemovedCmdletAlias()`
            - Checks to see if all of the previous aliases remain in the new cmdlet
        - `CheckForRemovedSupportsShouldProcess()`
            - Checks to see if the new cmdlet continues to implement `SupportsShouldProcess` if it previously did
        - `CheckForRemovedSupportsPaging()`
            - Checks to see if the new cmdlet continues to implement `SupportsPaging` if it previously did
        - `CheckForChangedOutputType()`
            - Checks to make sure there was no breaking change in the output type using the `TypeMetadataHelper` class
        - `CheckDefaultParameterName()`
            - Checks to make sure there was no breaking change in the default parameter set using the `ParameterSetMetadataHelper` class
- `ParameterMetadataHelper`
    - This class contains methods used to find breaking changes between the global properties of a `ParameterMetadata` object and another. The following methods are defined in this class:
        - `CompareParameterMetadata()`
            - Compares two sets of `ParameterMetadata` objects. Each old parameter is mapped to a new parameter and the different breaking change checks are performed. If an old parameter cannot be mapped a breaking change is logged.
        - `CheckForChangedParameterType()`
            - Checks to make sure there was no breaking change in the type of the parameter using the `TypeMetadataHelper` class
        - `CheckForRemovedParameterAlias()`
            - Checks to see if all of the previous aliases remain in the new parameter
        - `CheckParameterValidateSets()`
            - Checks to see if all of the previous values defined in the parameter's `ValidateSet` attribute remain in the new parameter
        - `CheckParameterValidateRange()`
            - Checks to make sure the new `ValidateRange` interval includes the previous parameter's `ValidateRange` interval
        - `CheckForValidateNotNullOrEmpty()`
            - Checks to see if the new parameter now disallows null or empty values for the parameter
- `ParameterSetMetadataHelper`
    - This class contains methods used to find breaking changes between one set of `ParameterSetMetadata` and another. The following method is defined in this class:
        - `CompareParameterSetMetadata()`
            - Compares two sets of `ParameterSetMetadata` objects. Iterating over the old set of parameter sets, the method attempts to map each one to a parameter set in the new parameter sets. To be successfully mapped to a set, each previous parameter must exist in the new set, as well as have the same properties (must continue to be optional if previously, position remains the same, piping scenario remains the same, etc.)
- `TypeMetadataHelper`
    - This class contains methods used to find breaking changes between `TypeMetadata` objects. The following methods are defined in this class:
        - `CompareTypeMetadata()`
            - Checks to make sure no breaking changes were introduced between two types by recursively checking the properties of the given types and those properties' types
        - `CompareMethodSignatures()`
            - Checks to make sure no breaking changes were introduced in the method signature of two types
        - `CheckParameterType()`
            - Checks to make sure no breaking changes were introduced in the type of a parameter (by recursively calling `CompareTypeMetadata()`)
        - `CheckOutputType()`
            - Checks to make sure no breaking changes were introduced in the output type of a cmdlet (by recursively calling `CompareTypeMetadata()`)
        - `IsElementType()`
            - Checks to make sure no breaking changes were introduced between two element types (by recursively calling `CompareTypeMetadata()`)
        - `IsGenericType()`
            - Checks to make sure no breaking changes were introduced from one generic type to another, as well as checks for breaking changes in the arguments of the generic types (by recursively calling `CompareTypeMetadata()`)
        - `HasSameGenericType()`
            - Checks to make sure that the type of the generic remains the same between two generic types
        - `HasSameGenericArgumentSize()`
            - Checks to make sure that the number of arguments remain the same between two generic types

#### Dependency Analyzer

The dependency analyzer can be found in the [`DependencyAnalyzer`](https://github.com/Azure/azure-powershell/tree/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/StaticAnalysis/DependencyAnalyzer) folder. In this folder, you will find the following classes:

- `AssemblyVersionConflict`
    - The implementation of the `IReportRecord` interface; defines what a assembly version conflict exception looks like when it's reported in the `AssemblyVersionConflict.csv` file that is found in the build artifacts of a CI run, as well as how to compare a new record to a record found in the existing `AssemblyVersionConflict.csv` file used for exception suppressions
- `DependencyAnalyzer`
    - The implementation of the `IStaticAnalyzer` interface; determines which modules to analyze and then checks the following:
        - If an assembly is found to be referenced by the cmdlet assembly, but it's not copied over to the output directory of the module, then a `MissingAssembly` record is written
        - If an assembly is found to be referenced by multiple projects, but the assembly file version is different between the projects, then a `SharedAssemblyConflict` record is written
- `DependencyMap`
    - The implementation of the `IReportRecord` interface; defines what a dependency map exception looks like when it's reported in the `DependencyMap.csv` file that is found in the build artifacts of a CI run, as well as how to compare a new record to a record found in the existing `DependencyMap.csv` file used for exception suppressions
- `ExtraAssembly`
    - The implementation of the `IReportRecord` interface; defines what an extra assembly exception looks like when it's reported in the `ExtraAssembly.csv` file that is found in the build artifacts of a CI run, as well as how to compare a new record to a record found in the existing `ExtraAssembly.csv` file used for exception suppressions
- `MissingAssembly`
    - The implementation of the `IReportRecord` interface; defines what a missing assembly exception looks like when it's reported in the `MissingAssembly.csv` file that is found in the build artifacts of a CI run, as well as how to compare a new record to a record found in the existing `MissingAssembly.csv` file used for exception suppressions
- `SharedAssemblyConflict`
    - The implementation of the `IReportRecord` interface; defines what a shared conflict exception looks like when it's reported in the `SharedAssemblyConflict.csv` file that is found in the build artifacts of a CI run, as well as how to compare a new record to a record found in the existing `SharedAssemblyConflict.csv` file used for exception suppressions
- `ExampleIssue`
    - The implementation of the `IReportRecord` interface; defines what an example issue exception looks like when it's reported in the `ExampleIssues.csv` file that is found in the build artifacts of a CI run, as well as how to compare a new record to a record found in the existing `ExampleIssues.csv` file used for exception suppressions    

#### Help Analyzer

The help analyzer can be found in the [`HelpAnalyzer`](https://github.com/Azure/azure-powershell/tree/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/StaticAnalysis/HelpAnalyzer) folder. In this folder, you will find the following classes:

- `HelpAnalyzer`
    - The implementation of the `IStaticAnalyzer` interface; determines which modules to analyze and checks to see which cmdlets within those modules don't have a corresponding markdown help file. It also checks the content structure of markdown help conforms to [PlatyPS Schema](https://github.com/PowerShell/platyPS/blob/master/platyPS.schema.md)
- `HelpIssues`
    - The implementation of the `IReportRecord` interface; defines what a help exception looks like when it's reported in the `HelpIssues.csv` file that is found in the build artifacts of a CI run, as well as how to compare a new record to a record found in the existing `HelpIssues.csv` file used for exception suppressions

#### Signature Verifier

The signature verifier can be found in the [`SignatureVerifier`](https://github.com/Azure/azure-powershell/tree/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/StaticAnalysis/SignatureVerifier) folder. In this folder, you will find the following classes:

- `SignatureIssues`
    - The implementation of the `IReportRecord` interface; defines what a signature exception looks like when it's reported in the `SignatureIssues.csv` file that is found in the build artifacts of a CI run, as well as how to compare a new record to a record found in the existing `SignatureIssues.csv` file used for exception suppressions
- `SignatureVerifier`
    - The implementation of the `IStaticAnalyzer` interface; determines which modules to analyze and runs the signature verifier on the `ModuleMetadata` object constructed from the `CmdletLoader` in the `Toools.Common` project. The following checks are made by the signature verifier:
        - If the cmdlet has a `-Force` parameter, the cmdlet should implement `SupportsShouldProcess`
        - If the cmdlet has a `ConfirmImpact` level that's not `Medium`, the cmdlet should implement `SupportsShouldProcess`
        - If the cmdlet has a verb that signals it would make a change on the server, the cmdlet should implement `SupportsShouldProcess`
        - Verify that the cmdlet has an approved PowerShell verb
        - Verify that the cmdlet is using a singular noun
        - Verify that the cmdlet has an output type
        - Verify that all parameters are singular
        - Verify that no parameter has a position greater than 4
        - If the cmdlet has more than one parameter, the cmdlet should have a default parameter set defined

### Static Analysis on CI

Static analysis is run as a part of the Azure DevOps CI for every pull request opened in the `azure-powershell` repository; it is run with the `Analyze {OS}` jobs in the pipeline. In this job, all of the modules that were built as a part of the `Build {OS}` job will have static analysis run on them, and any exceptions will can be found in the artifacts that are published once the job has completed.

To see the failures in static analysis, click on any of the failed `analyze-{OS}` artifact folders, and expand the `StaticAnalysisResults` folder. In this folder, you will want to search through the resulting `.csv` files for any exceptions with severity 0 or 1 (anything other than these severities are warnings and will not cause build failures).

_Note_: The `DependencyMap.csv` file only have severity 3 records and the `ExtraAssemblies.csv` file almost always has severity 2 records, so you can typically ignore these files.

#### Suppressing exceptions

If an exception is found in one of the resulting `.csv` files that should be ignored (false-positive or should be ignored), then the following steps should be taken:

- Open the `.csv` file with the exception(s) to suppress in a text editor (such as VS Code)
- Copy the lines that need to be suppressed
    - Copying these lines using Excel rather than a text editor will cause parsing issues
- Open the corresponding `.csv` file in the `tools/StaticAnalysis/Exceptions` folder in a text editor
    - Find the module that these exceptions are being suppressed for
    - If a folder for the module does not exist, or a file for the corresponding `.csv` file doesn't exist, create it
- Paste the lines that were previously copied to the end of the file

The `.csv` files found in `tools/StaticAnalysis/Exceptions` are used by the `IReportRecord` implementations mentioned previously to check if an exception thrown during static analysis already exists in the suppressed file, and ignoring it if it does.
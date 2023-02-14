# `Tools.Common`

## What is the `Tools.Common` project?

The `Tools.Common` project is a collection of classes that are used by other tooling applications in the Azure PowerShell repository, such as static analysis and the versioning tool.

## What is found in the `Tools.Common` project?

### `Models`

The `Models` folder contains classes representing the metadata for different pieces of a module that are used by static analysis and the versioning tool.

#### `ModuleMetadata`

The [`ModuleMetadata`](https://github.com/Azure/azure-powershell/blob/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/Tools.Common/Models/ModuleMetadata.cs) class contains information about the content exposed by a module.

The following public serializable properties are found in this class:

- `Cmdlets`
    - This is the list of cmdlets exposed by the module, represented as [`CmdletMetadata`](#cmdletmetadata) objects
- `TypeDictionary`
    - This is a dictionary of types exposed by the module, mapping the fully name of the type to its [`TypeMetadata`](#typemetadata) object representation

#### `TypeMetadata`

The [`TypeMetadata`](https://github.com/Azure/azure-powershell/blob/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/Tools.Common/Models/TypeMetadata.cs) class contains information about the content of a .NET type.

The following public serializable properties are found in this class:

- `Namespace`
    - This is the namespace of the type (_e.g._, `System` is the namespace for `System.DateTime`)
- `Name`
    - This is the full name of the type (_e.g._, `System.DateTime`)
- `AssemblyQualifiedName`
    - This is the assembly qualified name of the type (_e.g._, `System.DateTime, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e` is the assembly qualified name for `System.DateTime`)
- `Properties`
    - This is a dictionary that maps the type's property names' to their corresponding full type name (_e.g._, `Name` --> `System.String`, `Enabled` --> `System.Boolean`)
- `ElementType`
    - If the type is a collection of elements (_e.g._, array), then this is the type of the element (_e.g._, `System.Byte` is the element type for the type `System.Byte[]`)
- `GenericTypeArguments`
    - If the type is a generic (_e.g._, list, dictionary), then this is the type of the arguments of the generic (_e.g._, `System.String` is the generic type argument for `IList<System.String>`)
- `Methods`
    - This is the [`MethodSignature`](https://github.com/Azure/azure-powershell/blob/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/Tools.Common/Models/TypeMetadata.cs#L333-L343) representation of the public methods exposed by this type (_e.g._, `ToString()`, `Equals()`, `GetHashCode()`)
- `Constructors`
    - This is the [`MethodSignature`](https://github.com/Azure/azure-powershell/blob/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/Tools.Common/Models/TypeMetadata.cs#L333-L343) representation of the public constructors exposed by this type

#### `CmdletMetadata`

The [`CmdletMetadata`](https://github.com/Azure/azure-powershell/blob/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/Tools.Common/Models/CmdletMetadata.cs) class contains information about the content of a cmdlet.

The following public serializable properties are found in this class:

- `VerbName`
    - This is the verb component of the cmdlet name
- `NounName`
    - This is the noun component of the cmdlet name
- `Name`
    - This is the name of the cmdlet
- `ClassName`
    - This is the name of the class that the cmdlet is defined in
- `SupportsShouldProcess`
    - This signals whether or not the cmdlet implements `SupportsShouldProcess`
- `ConfirmImpact`
    - This is impact level of the operation
- `SupportsPaging`
    - This signals whether or not the cmdlet implements `SupportsPaging`
- `DefaultParameterSetName`
    - The name of the default parameter set of the cmdlet
- `OutputTypes`
    - A list of the output types of the cmdlet, represented as [`OutputMetadata`](#outputmetadata) objects
- `Parameters`
    - A list of parameters found in the cmdlet, represented as [`ParameterMetadata`](#parametermetadata) objects
- `ParameterSets`
    - A list of parameter sets found in the cmdlet, represented as [`ParameterSetMetadata`](#parametersetmetadata) objects
- `AliasList`
    - A list of aliases that the cmdlet has

#### `OutputMetadata`

The [`OutputMetadata`](https://github.com/Azure/azure-powershell/blob/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/Tools.Common/Models/OutputMetadata.cs) class contains information about the output type of a cmdlet.

The following public serializable properties are found in this class:

- `Type`
    - The type of the output, represented as a [`TypeMetadata`](#typemetadata) object
- `ParameterSets`
    - The list of parameter sets that the output type is returned in

#### `ParameterMetadata`

The [`ParameterMetadata`](https://github.com/Azure/azure-powershell/blob/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/Tools.Common/Models/ParameterMetadata.cs) class contains information about the content of a parameter.

The following public serializable properties are found in this class:

- `Name`
    - The name of the parameter
- `AliasList`
    - The list of aliases that the parameter has
- `Type`
    - The type of the parameter, represented as a [`TypeMetadata`](#typemetadata) object
- `ValidateSet`
    - The list of values that are defined in the `ValidateSet` attribute for the parameter
- `ValidateRangeMin`
    - The minimum value specified in the `ValidateRange` attribute for the parameter
- `ValidateRangeMax`
    - The maximum value specified in the `ValidateRange` attribute for the parameter
- `ValidateNotNullOrEmpty`
    - This signals whether or not the parameter has the `ValidateNotNullOrEmpty` attribute

#### `ParameterSetMetadata`

The [`ParameterSetMetadata`](https://github.com/Azure/azure-powershell/blob/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/Tools.Common/Models/ParameterSetMetadata.cs) class contains information about the content of a parameter set.

The following public serializable properties are found in this class:

- `Name`
    - The name of the parameter set
- `Parameters`
    - The list of parameters found in the parameter set, represented as [`Parameter`](https://github.com/Azure/azure-powershell/blob/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/Tools.Common/Models/ParameterSetMetadata.cs#L78) objects

The following public serializable properties are found in the `Parameter` class:

- `ParameterMetadata`
    - The global information about a parameter, represented as a `ParameterMetadata` object
- `Mandatory`
    - This signals whether or not the parameter is mandatory in the given parameter set
- `Position`
    - The position of the parameter in the given parameter set
- `ValueFromPipeline`
    - This signals whether or not the parameter has `ValueFromPipeline = true` in the given parameter set
- `ValueFromPipelineByPropertyName`
    - This signals whether or not the parameter has `ValueFromPipelineByPropertyName = true` in the given parameter set

#### `AssemblyMetadata`

The [`AssemblyMetadata`](https://github.com/Azure/azure-powershell/blob/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/Tools.Common/Models/AssemblyMetadata.cs) class contains information about the content of an assembly. The constructor for this class takes a [`System.Reflection.Assembly`](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.assembly) object.

The following public serializable properties are found in this class:

- `Location`
    - The path to the assembly on disk

The following methods are used as well:

- `GetName()`
    - Returns the name of the assembly
- `GetReferencedAssemblies()`
    - Returns the list of assemblies that are referenced by the assembly

### `Extensions`

This folder contains classes that introduce various extension methods used to help inside of the `Tools.Common` project.

#### `ReflectionExtensions`

The [`ReflectionExtensions`](https://github.com/Azure/azure-powershell/blob/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/Tools.Common/Extensions/ReflectionExtensions.cs) class contains extension methods used to help reflect over attributes in a given assembly.

The following extension methods are found in this class:

- `GetAttribute<T>(this Type type)`
    - Returns the attribute of type `T` found in the `type` object
- `GetAttribute<T>(this PropertyInfo propertyInfo)`
    - Returns the attribute of type `T` found in the `propertyInfo` object
- `GetAttributes<T>(this Type type)`
    - Returns a list of attributes of type `T` found in the `type` object
- `GetAttributes<T>(this PropertyInfo propertyInfo)`
    - Returns a list of attributes of type `T` found in the `propertyInfo` object
- `HasAttribute<T>(this Type type)`
    - Returns whether or not the `type` object contains an attribute of type `T`
- `HasAttribute<T>(this PropertyInfo propertyInfo)`
    - Returns whether or not the `propertyInfo` object contains an attribute of type `T`
- `GetParameters(this Type type)`
    - Using a call to `HasAttribute<ParameterAttribute>()`, returns the list of `PropertyInfo` objects with a `ParameterAttribute`
- `GetCmdletTypes(this Assembly assembly)`
    - Using a call to `HasAttribute<CmdletAttribute>()`, returns the list of `Type` objects with the `CmdletAttribute`

### `Loaders`

This folder contains classes that load assemblies into the current session and reflect over them to create various metadata objects found in the [`Models`](#models) folder.

#### `AssemblyLoader`

The [`AssemblyLoader`](https://github.com/Azure/azure-powershell/blob/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/Tools.Common/Loaders/AssemblyLoader.cs) class contains the logic to load assemblies, reflect over them and convert them to [`AssemblyMetadata`](#assemblymetadata) objects.

This class is used by the dependency analyzer that runs as a part of static analysis.

#### `CmdletLoader`

The [`CmdletLoader`](https://github.com/Azure/azure-powershell/blob/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/Tools.Common/Loaders/CmdletLoader.cs) class contains the logic to load assemblies, reflect over them and convert them to [`ModuleMetadata`](#modulemetadata) objects.

This class is used by the breaking change analyzer, help analyzer and signature verifier, which all run as a part of static analysis, as well as the version controller.

### `SerializedCmdlets`

This folder contains `.json` files that are the serialization of the [`ModuleMetadata`](#modulemetadata) object constructed for each module. During each release, if a module has been updated, its `.json` file will be re-serialized using the latest `ModuleMetadata` object constructed. As a result, a module's `.json` file should be viewed as a snapshot of the module the last time that it was released.

#### Breaking change analyzer

The breaking change analyzer that runs as a part of static analysis uses the `.json` files to check for any breaking changes from the last release to the changes being made in a user's pull request.

#### Versioning tool

The versioning tool that runs as a part of each release uses the `.json` files to check for any public API changes from the last release to the current release, and decides what type of bump to make to the module's version:

| Bump | Description | Example |
| ----------- | ---- | ------- |
| Major | A breaking change was introduced into the module | `1.2.3` --> `2.0.0` |
| Minor | Additions were made to the module (_e.g._, new cmdlets, new parameters) | `1.2.3` --> `1.3.0` |
| Patch | Bug fixes in the backend of a module or documentation updates | `1.2.3` --> `1.2.4` |

Version bumping bases on installed version and changes of APIs. But it cannot handle below scenarios:
* Module will be GAed from `0.n.n` --> `1.0.0`. The tool cannot detect this change because preview release module doesn't has `.json` file, or there is no breaking changes in current release.
* Module has a preview release but new bumped version has the same semantic version just without `preview` label. This new version cannot be published to PSGallery. The tool needs a patch version increase.  

Above scenarios can be supported by configurations `MinimalVersion.csv`. Each line contains module name and expected minimal version. If bumped version is lower than expected minital version, the tool will use minimal version for new release.

### `Issues`

The `Issues` folder contains classes that represent the records that are created by the different analyzers found in static analysis. Each analyzer is responsible for implement a specific record for their analyzer that defines the following methods:

- `PrintHeaders()`
    - Returns the string representation of the headers found in the resulting `.csv` record file
- `FormatRecord()`
    - Returns the string representationg of a single record (or row) found in the resulting `.csv` record file
- `Match(IReportRecord other)`
    - Defines how to compare two records, specifically to see if the incoming record is already found in the existing `.csv` containing the suppressed records
- `Parse(string line)`
    - Defines how to parse a line in the `.csv` file and assign the values to properties of the record

### `Loggers`

#### `AnalysisLogger`

The [`AnalysisLogger`](https://github.com/Azure/azure-powershell/blob/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/Tools.Common/Loggers/AnalysisLogger.cs) classes contains methods to create new loggers, retrieve existing loggers, write reports, check for issues within a certain severity threshold and log errors, warnings and messages using the `Log4Net` package.

#### `ConsoleLogger`

The [`ConsoleLogger`](https://github.com/Azure/azure-powershell/blob/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/Tools.Common/Loggers/ConsoleLogger.cs) class contains methods used for logging errors and warnings to the console and writing reports to the file system.

#### `ReportLogger`

The [`ReportLogger`](https://github.com/Azure/azure-powershell/blob/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/Tools.Common/Loggers/ReportLogger.cs) abstract class that acts as an abstraction over typed loggers, deferring to the parent logger to define how to log errors, warnings and messages.

An implementation of the `ReportLogger` abstraction can be found in this class as well, [`ReportLogger<T>`](https://github.com/Azure/azure-powershell/blob/01a81fbb7ea6c086fff2bc137053168c0fc7728a/tools/Tools.Common/Loggers/ReportLogger.cs#L68), which knows how to use the exceptions files for the different analyzers in static analysis and log records against them.

For example, if a new breaking change exception is found in its analyzer, the `ReportLogger` knows to how to compare the new breaking change record created and compare it to the existing breaking change exceptions that are found in the `Exceptions` folder of `Tools.Common` to see if the new record can be ignored.

# Contribute Code or Provide Feedback

If you would like to become an active contributor to this project please follow the instructions provided in [Microsoft Azure Projects Contribution Guidelines](http://azure.github.io/guidelines/).

If you encounter any bugs with Microsoft Azure PowerShell please file an issue in the [Issues](https://github.com/Azure/azure-powershell/issues) section of the project.

## Best Practices

The following is a list of guidelines that pull requests opened in the Azure PowerShell repository must adhere to. You can find a more complete discussion of PowerShell cmdlet best practices [here](https://msdn.microsoft.com/en-us/library/dd878270(v=vs.85).aspx).

### Cleaning up Commits

Often when a pull request is created with a large number of files changed and/or a large number of lines of code added and/or removed, GitHub will have a difficult time opening up the changes on their site. This forces the Azure PowerShell team to uses separate software, such as CodeFlow or Beyond Compare, to do a code review on the pull request.

If you find yourself creating a pull request and are unable to see all the changes on GitHub, we recommend **splitting the pull request into multiple pull requests that are able to be reviewed on GitHub**.

If splitting up the pull request is not an option, we recommend **creating individual commits for different parts of the pull request, which can be reviewed individually on GitHub**.

For more information on cleaning up the commits in a pull request, such as how to rebase, squash, and cherry-pick, click [here](../documentation/cleaning-up-commits.md).

### General

The following guidelines must be followed in **EVERY** pull request that is opened.

- Title of the pull request is clear and informative
- There are a small number of commits that each have an informative message
- A description of the changes the pull request makes is included, and a reference to the bug/issue the pull request fixes is included, if applicable
- All files have the Microsoft copyright header
- Cmdlets refer to the management libraries through NuGet references - no dlls are checked in
- The pull request does not introduce [breaking changes](https://github.com/markcowl/azure-powershell/blob/doc1/documentation/changes.md#breaking-change-definition) (unless a major version change occurs in the assembly and module)

### Tests

The following guidelines must be followed in **EVERY** pull request that is opened.

- Pull request includes test coverage for the included changes
- Tests must use xunit, and should either use Moq to mock management client calls, or use the scenario test framework
- PowerShell scripts used in tests must not use hard-coded values for location
- PowerShell scripts used in tests should not do any necessary setup as part of the test or suite setup, and should not use hard-coded values for existing resources
- Test should not use App.config files for settings
- Tests should use the built-in PowerShell functions for generating random names when unique names are necessary - this will store names in the test recording
- Tests should use `Start-Sleep` to pause rather than `Thread.Sleep`

### Cmdlet Signature

The following guidelines must be followed in pull requests that add, edit, or remove a cmdlet.

- Cmdlet name uses an approved PowerShell verb - use enums for `VerbsCommon`, `VerbsCommunication`, `VerbLifecycle`, `VerbsOther` whenever possible
- Cmdlet noun name uses the AzureRm prefix for management cmdlets, and the Azure prefix for data plane cmdlets
- Cmdlet specifies the `OutputType` attribute if any output is produced; if the cmdlet produces no output, it should implement a `PassThrough` parameter
- If the cmdlet makes changes or has side effects, it should implement `ShouldProcess` and have `SupportsShouldProcess = true` specified in the cmdlet attribute. See a discussion about correct `ShouldProcess` implementation [here](https://gist.github.com/markcowl/338e16fe5c8bbf195aff9f8af0db585d#what-is-the-change).
- Cmdlets should derive from AzureRmCmdlet for management cmdlets, and AzureDataCmdlet for data cmdlets
- If multiple parameter sets are implemented, the cmdlet should specify a `DefaultParameterSetName` in its cmdlet attribute

### Parameters

The following guidelines must be followed in pull requests that add, edit, or remove a parameter.

- Cmdlets should have no more than four positional parameters
- Cmdlet parameter sets should be mutually exclusive - each parameter set must have at least one mandatory parameter not in other parameter sets
- Parameter types should not expose types from the management library - complex parameter types should be defined in the module
- Complex parameter types are discouraged - a parameter type should be simple types as often as possible. If complex types are used, they should be shallow and easily creatable from a constructor or another cmdlet
- Parameters should be explicitly marked as `Mandatory` or not, and should contain a `HelpMessage`
- No parameter is of type `object`
    - Management cmdlets should have the following parameters and aliases:
        - `ResourceGroupName` with (optional) alias to `ResourceGroupName` type `string` marked as `[ValueFromPipelineByPropertyName]`
        - `Name` with alias to `ResourceName` type `string` marked as `[ValueFromPipelineByPropertyName]`
        - `Location` (if appropriate) type `string`
        - `Tag` type `HashTable`

### Parameters and the Pipeline

The following guidelines must be followed in pull requests that make changes to pipeline parameters.

- Complex parameters should take values from the pipeline when possible, and certainly when they match the output type of another cmdlets
- Only one parameter should use `ValueFromPipeline` per parameter set; parameters from different parameter sets may have this attribute, but should not be convertible
- No parameter is of type `object`
- Each management cmdlet should have a parameter set that takes `ResourceGroupName` and `Name` from the pipeline by property value
- For a given resource type, it should be possible to pipe the output of `Get` and `New` cmdlets to the input of `Set`, `Update`, `Remove` and other action cmdlets for that resource
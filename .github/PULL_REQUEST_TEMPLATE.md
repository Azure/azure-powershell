## Comments

---

This checklist is used to make sure that common issues in a pull request are covered by the creator. You can find a more complete discussion of PowerShell cmdlet best practices [here](https://msdn.microsoft.com/en-us/library/dd878270(v=vs.85).aspx).

Below in **Overall Changes**, check off the boxes that apply to your PR. For the categories that you did not check off, you can remove them from this body. Within each of the categories that you did select, make sure that you can check off **all** of the boxes. 

For information on cleaning up the commits in your pull request, click [here](../documentation/cleaning-up-commits.md).

## Overall Changes 
- [ ] [**MANDATORY** - General changes](#general)
- [ ] [**MANDATORY** - Add/remove/edit test(s)](#tests)
- [ ] [Add/remove/edit cmdlet(s)](#cmdlet-signature)
- [ ] [Add/remove/edit parameter(s)](#parameters)
- [ ] [Edit pipeline parameters](#parameters-and-the-pipeline)

### General
- [ ] Title of the PR is clear and informative
- [ ] There are a small number of commits that each have an informative message
- [ ] If it applies, references the bug/issue that the PR fixes
- [ ] All files have the Microsoft copyright header
- [ ] Cmdlets refer to management libraries through nuget references - no dlls are checked in
- [ ] The PR does not introduce breaking changes (unless a major version change occurs in the assembly and module)

### Tests
- [ ] PR includes test coverage for the included changes
- [ ] Tests must use xunit, and should either use Moq to mock management client calls, or use the scenario test framework
- [ ] PowerShell scripts used in tests must not use hard-coded values for location
- [ ] PowerShell scripts used in tests should do any necessary setup as part of the test or suite setup, and should not use hard-coded values for existing resources
- [ ] Tests should not use App.config files for settings
- [ ] Tests should use the built-in PowerShell functions for generating random names when unique names are necessary - this will store names in the test recording
- [ ] Tests should use Start-Sleep to pause rather than Thread.Sleep

### Cmdlet Signature
- [ ] Cmdlet name uses an approved PowerShell verb - use the enums for `VerbsCommon`, `VerbsCommunication`, `VerbsLifecycle`, `VerbsOther` whenever possible
- [ ] Cmdlet noun name uses the AzureRm prefix for management cmdlets, and the Azure prefix for data plane cmdlets
- [ ] Cmdlet specifies the `OutputType` attribute if any output is produced; if the cmdlet produces no output, it should implement a `PassThrough` parameter
- [ ] If the cmdlet makes changes or has side effects, it should implement `ShouldProcess` and have `SupportShouldProcess = true` specified in the cmdlet attribute. See a discussion about correct `ShouldProcess` implementation [here](https://gist.github.com/markcowl/338e16fe5c8bbf195aff9f8af0db585d#what-is-the-change)
- [ ] Cmdlets should derive from AzureRmCmdlet for management cmdlets, and AzureDataCmdlet for data cmdlets
- [ ] If multiple parameter sets are implemented, the cmdlet should specify a `DefaultParameterSetName` in its cmdlet attribute

### Parameters
- [ ] Cmdlets should have no more than four positional parameters
- [ ] Cmdlet parameter sets should be mutually exclusive - each parameter set must have at least one mandatory parameter not in other parameter sets
- [ ] Parameter types should not expose types from the management library - complex parameter types should be defined in the module
- [ ] Complex parameter types are discouraged - a parameter type should be simple types as often as possible. If complex types are used, they should be shallow and easily creatable from a constructor or another cmdlet
- [ ] Parameters should be explicitly marked as Mandatory or not, and should contain a HelpMessage
- [ ] No parameter is of type `object`.
    - Management cmdlets should have the following parameters and aliases:
        - ResourceGroupName with (optional) alias to `ResourceGroup` type string marked as [ValueFromPipelineByPropertyName]
        - Name with alias to `ResourceName` type string marked as [ValueFromPipelineByPropertyName]
        - Location (if appropriate) type string
        - Tag, type `HashTable`

### Parameters and the Pipeline
- [ ] Complex parameters should take values from the pipeline when possible, and certainly when they match the output type of another cmdlet
- [ ] Only one parameter should use ValueFromPipeline per parameter set; parameters from different parameter sets may have this attribute, but should not be convertible
- [ ] No parameter is of type `object`
- [ ] Each management cmdlet should have a parameter set that takes `ResourceGroupName` and `Name` from the pipeline by property value
- [ ] For a given resource type, it should be possible to pipe the output of `Get` and `New` cmdlets to the input of `Set`, `Update`, `Remove` and other action cmdlets for that resource

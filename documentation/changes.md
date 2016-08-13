# Breaking Change Policy

Customers and MVPs have told us many times in emphatic terms that breaking changes are a continuing problem in Azure PowerShell releases.  These changes cause an undue burden on users maintaining scripts to manage their Azure assets, and that this causes reluctance in picking up the later versions os Azure PowerShell. It is clear that continuing, unmanaged breaking changes are unnacceptable to customers. 
**To address customer concerns, Azure PowerShell is committing to limit breaking changes to one release per year and to treat any unplanned breaking change that ships as 
a showstopper bug requiring a hotfix**.
This proposed policy is meant to apply to all Azure modules, starting with the 2.0 release. Details of the policy are as follows.
1. Each module in Azure PowerShell is versioned using [semantic versioning](http://semver.org).
2. Non-breaking changes and associated version updates are handled independently by module owners.  [Breaking changes](#Breaking-Change-Definition) are scheduled for once a year and coordinated with the Azure SDK Team.
3. Each breaking change release will be preceded by 3-months notice of the break to customers.  The SDK Team will coordinate the notice of breaking changes.
4. It is the responsibility of the service teams to introduce no breaking changes in their cmdlet external interfaces.  A definition of breaking changes is provided [here](#Breaking-Change-Definition).  It is the responsibility of the SDK Team to introduce no breaking changes in SDK cmdlets, and in the public types in common code used as parameters or returned by cmdlets.
  - The SDK Team will provide tools in the October release to automatically detect and prevent breaking changes
  - Until breaking change detection tools are available, the feature teams and SDK team will use code reviews to prevent breaking changes
5. In the event that a breaking change is released outside of a planned breaking change release, the cmdlet owner must coordinate with the SDK team to create a hotfix that mitigates the impact of the breaking changes on existing scripts.
6. The release notes for any breaking change version will contain a complete description of the changes and a migration guide, explaining how scripts should be updated to accomodate the breaking changes.
  - Service Teams must provide a list of breaking changes and the migration guide at the start of the sprint containing the breaking changes
  - The SDK Team will coordinate the breaking change documentation and assemble a migration guide from the feature team submissions
  - A sample migration guide for the 2.0 release is provided [here](https://github.com/Azure/azure-powershell/blob/dev/documentation/release-notes/migration-guide.2.0.0.md)

# Breaking Change Definition

Breaking changes in cmdlets are defined as follows:

  - Cmdlets: 
    - Removing a cmdlet
    - Changing a cmdlet name without an alias to the original name
    - Removing or changing a cmdlet alias
    - Removing a Cmdlet attribute option (SupportShouldProcess, SupportsPaging)
    - Breaking change in OutputType or removal of OutputType attribute
  - Parameters
    - Removing a parameter
    - Changing the name of a parameter without an alias to the original parameter name
    - Breaking change in parameter type
    - Adding a required parameter to an existing parameter set (adding new parameter sets, or adding additional optional prameters is not breaking)
    - Changing parameter order for parameter sets with ordered parameters
    - Removing or changing a parameter alias
    - Removing or changing existing parameter attribute values
    - Making parameter validation more exclusive (for example: removing values from a ValidateSet)
  - Output and Parameter Types
    - Changing property names without an accompanying alias to the original name
    - Removing properties
    - Adding additional required properties
    - Adding required parameters, changing parameter names, or parameter types for methods or constructors
    - Changing return types of methods



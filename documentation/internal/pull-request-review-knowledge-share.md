## PR Review Knowledge Share

### Dependency Assemlby Version Confliction
If one assembly has been referenced by more than one module, we should let Az.Accounts to handle the dependency.

**RED** flag
- Update assembly version for common Microsoft.Extensions.*
- Add new dependency assemlby for one module, the assembly may be referenced by other module already.
- Contains version update for dependency assembly in module other than Az.Accounts

### Resource ID **MUST** start with a slash 
*Correct*: "/subscriptions/18bxxxxxx-4d70-8b1e-937660bde798/resourceGroups/MNC-PowerShell/providers/Microsoft.Network/virtualnetworks/Mesh1"

*Wrong*: "subscriptions/18bxxxxxx-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-PowerShell/providers/Microsoft.Network/virtualnetworks/Mesh1"


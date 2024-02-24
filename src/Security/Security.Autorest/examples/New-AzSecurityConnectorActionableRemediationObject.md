### Example 1: Create new ActionableRemediation object
```powershell
New-AzSecurityConnectorActionableRemediationObject -State Enabled -InheritFromParentState Disabled `
            -BranchConfiguration @{AnnotateDefaultBranch="Enabled"; branchName=@("main", "hotfix")} -CategoryConfiguration @( @{category="First"; minimumSeverityLevel="High"}, @{category="Second"; minimumSeverityLevel="Low"})
```

```output
BranchConfiguration    : {
                           "branchNames": [ "main", "hotfix" ],
                           "annotateDefaultBranch": "Enabled"
                         }
CategoryConfiguration  : {{
                           "minimumSeverityLevel": "High",
                           "category": "First"
                         }, {
                           "minimumSeverityLevel": "Low",
                           "category": "Second"
                         }}
InheritFromParentState : Disabled
State                  : Enabled
```



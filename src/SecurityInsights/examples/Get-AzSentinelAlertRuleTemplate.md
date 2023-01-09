### Example 1: List all Alert Rule Templates
```powershell
 Get-AzSentinelAlertRuleTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```
```output
DisplayName        : TI map IP entity to GitHub_CL
Description        : Identifies a match in GitHub_CL table from any IP IOC from TI
CreatedDateUtc     : 8/27/2019 12:00:00 AM
LastUpdatedDateUtc : 10/19/2021 12:00:00 AM
Kind               : Scheduled
Severity           : Medium
Name               : aac495a9-feb1-446d-b08e-a1164a539452

DisplayName        : Accessed files shared by temporary external user
Description        : This detection identifies an external user is added to a Team or Teams chat
                     and shares a files which is accessed by many users (>10) and the users is removed within short period of time. This might be
                     an indicator of suspicious activity.
CreatedDateUtc     : 8/18/2020 12:00:00 AM
LastUpdatedDateUtc : 1/3/2022 12:00:00 AM
Kind               : Scheduled
Severity           : Low
Name               : bff058b2-500e-4ae5-bb49-a5b1423cbd5b
```

This command lists all Alert Rule Templates under a Microsoft Sentinel workspace.

### Example 2: Get an Alert Rule Template
```powershell
 Get-AzSentinelAlertRuleTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "myRuaac495a9-feb1-446d-b08e-a1164a539452leTemplateId"
```
```output
DisplayName        : TI map IP entity to GitHub_CL
Description        : Identifies a match in GitHub_CL table from any IP IOC from TI
CreatedDateUtc     : 8/27/2019 12:00:00 AM
LastUpdatedDateUtc : 10/19/2021 12:00:00 AM
Kind               : Scheduled
Severity           : Medium
Name               : aac495a9-feb1-446d-b08e-a1164a539452
```

This command gets an Alert Rule Template.
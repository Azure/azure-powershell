### Example 1: List all Entity Query Templates
```powershell
 Get-AzSentinelEntityQueryTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```
```output
Title           : The user has created an account
Description     : This activity displays account creation events performed by the user
InputEntityType : Account
Kind            : Activity
Name            : d6d08c94-455f-4ea5-8f76-fc6c0c442cfa

Title           : The user has deleted an account
Description     : This activity displays account deletion events performed by the user
InputEntityType : Account
Kind            : Activity
Name            : e0459780-ac9d-4b72-8bd4-fecf6b46a0a1
```

This command lists all Entity Query Templates under a Microsoft Sentinel workspace.

### Example 2: Get an Entity Query Template
```powershell
 Get-AzSentinelEntityQueryTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "d6d08c94-455f-4ea5-8f76-fc6c0c442cfa"
```
```output
Description     : This activity displays account creation events performed by the user
InputEntityType : Account
Kind            : Activity
Name            : d6d08c94-455f-4ea5-8f76-fc6c0c442cfa
```

This command gets an Entity Query Template.

### Example 3: Get an Entity Query Template by object Id
```powershell
 $EntityQueryTemplates = Get-AzSentinelEntityQueryTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
 $EntityQueryTemplates[0] | Get-AzSentinelEntityQueryTemplate
```
```output
Description     : This activity displays account creation events performed by the user
InputEntityType : Account
Kind            : Activity
Name            : d6d08c94-455f-4ea5-8f76-fc6c0c442cfa
```

This command gets a Entity Query Template by object.
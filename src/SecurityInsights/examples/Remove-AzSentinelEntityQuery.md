### Example 1: Remove Entity Query
```powershell
 Remove-AzSentinelEntityQuery -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "myEntityQueryTemplateId"
```

This command removes a specific entity query based on the entity query Id

### Example 2: Remove an Entity Query based on the title
```powershell
 $queryTemplateId = Get-AzSentinelEntityQueryTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" | Where-Object {$_.Title -eq "The user has created an account"}
Remove-AzSentinelEntityQuery -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id $queryTemplateId.Name
```

This command removes a specific entity query based on the title


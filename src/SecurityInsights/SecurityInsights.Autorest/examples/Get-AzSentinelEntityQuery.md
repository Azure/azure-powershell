### Example 1: List all Entity Queries
```powershell
 Get-AzSentinelEntityQuery -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```
```output
DisplayName     : Related entities
DataSource      : {SecurityAlert}
Name            : 98b974fd-cc64-48b8-9bd0-3a209f5b944b
InputEntityType : SecurityAlert

DisplayName     : Related alerts
DataSource      : {SecurityAlert}
Name            : 055a5692-555f-42bd-ac17-923a5a9994ed
InputEntityType : Host
```

This command lists all Entity Queries under a Microsoft Sentinel workspace.

### Example 2: Get an Entity Query
```powershell
 Get-AzSentinelEntityQuery -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "myEntityQueryId"
```
```output
DisplayName     : Related entities
DataSource      : {SecurityAlert}
Name            : 98b974fd-cc64-48b8-9bd0-3a209f5b944b
InputEntityType : SecurityAlert
QueryTemplate   : let GetAlertRelatedEntities = (v_SecurityAlert_SystemAlertId:string){
                                              SecurityAlert
                                              | where SystemAlertId == v_SecurityAlert_SystemAlertId
                                              | project entities = todynamic(Entities)
                                              | mv-expand entities
                                              | project-rename entity=entities};
                                              GetAlertRelatedEntities('<systemAlertId>')
```

This command gets an Entity Query.

### Example 3: Get an Entity Query by object Id
```powershell
 $EntityQueries = Get-AzSentinelEntityQuery -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
 $EntityQueries[0] | Get-AzSentinelEntityQuery
```
```output
DisplayName     : Related entities
DataSource      : {SecurityAlert}
Name            : 98b974fd-cc64-48b8-9bd0-3a209f5b944b
InputEntityType : SecurityAlert
QueryTemplate   : let GetAlertRelatedEntities = (v_SecurityAlert_SystemAlertId:string){
                                              SecurityAlert
                                              | where SystemAlertId == v_SecurityAlert_SystemAlertId
                                              | project entities = todynamic(Entities)
                                              | mv-expand entities
                                              | project-rename entity=entities};
                                              GetAlertRelatedEntities('<systemAlertId>')
```

This command gets a Entity Query by object.
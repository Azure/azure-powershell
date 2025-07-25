### Example 1: Lists all datastore under a workspace
```powershell
Get-AzMLWorkspaceDatastore  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01
```

```output
Name                      SystemDataCreatedAt SystemDataCreatedBy                  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
----                      ------------------- -------------------                  ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
workspaceartifactstore    5/5/2022 1:27:41 AM 779301c0-18b2-4cdc-801b-a0a3368fee0a Application             5/5/2022 1:27:42 AM      779301c0-18b2-4cdc-801b-a0a3368fee0a Application                  ml-rg-test
workspaceworkingdirectory 5/5/2022 1:27:41 AM 779301c0-18b2-4cdc-801b-a0a3368fee0a Application             5/5/2022 1:27:42 AM      779301c0-18b2-4cdc-801b-a0a3368fee0a Application                  ml-rg-test
workspaceblobstore        5/5/2022 1:27:41 AM 779301c0-18b2-4cdc-801b-a0a3368fee0a Application             5/5/2022 1:27:42 AM      779301c0-18b2-4cdc-801b-a0a3368fee0a Application                  ml-rg-test
workspacefilestore        5/5/2022 1:27:41 AM 779301c0-18b2-4cdc-801b-a0a3368fee0a Application             5/5/2022 1:27:42 AM      779301c0-18b2-4cdc-801b-a0a3368fee0a Application                  ml-rg-test
```

Lists all datastore under a workspace

### Example 2: Get a datastore by name
```powershell
Get-AzMLWorkspaceDatastore  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01 -Name workspaceartifactstore
```

```output
Name                   SystemDataCreatedAt SystemDataCreatedBy                  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
----                   ------------------- -------------------                  ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
workspaceartifactstore 5/5/2022 1:27:41 AM 779301c0-18b2-4cdc-801b-a0a3368fee0a Application             5/5/2022 1:27:42 AM      779301c0-18b2-4cdc-801b-a0a3368fee0a Application                  ml-rg-test
```

Get a datastore by name


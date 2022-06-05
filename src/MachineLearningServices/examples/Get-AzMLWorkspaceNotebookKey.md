### Example 1: List keys of a notebook
```powershell
Get-AzMLWorkspaceNotebookKey  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01
```

```output
PrimaryAccessKey                                                 SecondaryAccessKey
----------------                                                 ------------------
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
```

List keys of a notebook.

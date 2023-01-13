### Example 1: Regenerate EndpointAuthKeys for an Endpoint using Key-based authentication (asynchronous)
```powershell
New-AzMLWorkspaceOnlineEndpointKey -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name online-pwsh02 -KeyType 'Primary'
```

```output
PrimaryKey                       SecondaryKey
----------                       ------------
xxxxxxxxxxxxxxxxxxxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxx
```

Regenerate EndpointAuthKeys for an Endpoint using Key-based authentication (asynchronous)


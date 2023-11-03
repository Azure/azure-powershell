### Example 1: List EndpointAuthKeys for an Endpoint using Key-based authentication
```powershell
Get-AzMLWorkspaceOnlineEndpointKey -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name online-cli01
```

```output
PrimaryKey                       SecondaryKey
----------                       ------------
xxxxxxxxxxxxxxxxxxxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxx
```

List EndpointAuthKeys for an Endpoint using Key-based authentication


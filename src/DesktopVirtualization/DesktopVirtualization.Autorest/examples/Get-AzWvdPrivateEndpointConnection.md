### Example 1: Get a PrivateEndpointConnection by Workspace
```powershell
Get-AzWvdPrivateEndpointConnection -ResourceGroupName ResourceGroupName -workspaceName WorkspaceName -privateEndpointConnectionName privateName
```

```output
Name                                         PrivateEndpointId                                                                                                                           PrivateLinkServiceConnectionStateActionsRequired PrivateLinkServiceConnectionStateDescription PrivateLinkServiceConnectionStateStatus ProvisioningState
----                                         -----------------                                                                                                                           ------------------------------------------------ -------------------------------------------- --------------------------------------- -----------------
privateName1                                  /subscriptions/00000000-0000-0000-000000000000/resourceGroups/ResourceGroupName/providers/microsoft.network/privateendpoints/WorkspaceName  None                                             Auto-approved                                Approved                                Succeeded
```

Gets a private endpoint connection from a Workspace.

### Example 1: List PrivateEndpointConnections by Workspace 
```powershell
Get-AzWvdPrivateEndpointConnection -ResourceGroupName ResourceGroupName -workspaceName WorkspaceName
```

```output
Name                                         PrivateEndpointId                                                                                                                           PrivateLinkServiceConnectionStateActionsRequired PrivateLinkServiceConnectionStateDescription PrivateLinkServiceConnectionStateStatus ProvisioningState
----                                         -----------------                                                                                                                           ------------------------------------------------ -------------------------------------------- --------------------------------------- -----------------
privateName1                                  /subscriptions/00000000-0000-0000-000000000000/resourceGroups/ResourceGroupName/providers/microsoft.network/privateendpoints/WorkspaceName None                                             Auto-approved                                Approved                                Succeeded
privateName2                                  /subscriptions/00000000-0000-0000-000000000000/resourceGroups/ResourceGroupName/providers/microsoft.network/privateendpoints/WorkspaceName None                                             Auto-approved                                Approved                                Succeeded
```

Lists private endpoint connections from a Workspace.

### Example 3: Get a PrivateEndpointConnection by HostPool
```powershell
Get-AzWvdPrivateEndpointConnection -ResourceGroupName ResourceGroupName -HostPoolName hpName -privateEndpointConnectionName privateName
```

```output
Name                                         PrivateEndpointId                                                                                                                     PrivateLinkServiceConnectionStateActionsRequired PrivateLinkServiceConnectionStateDescription PrivateLinkServiceConnectionStateStatus ProvisioningState
----                                         -----------------                                                                                                                     ------------------------------------------------ -------------------------------------------- --------------------------------------- -----------------
privateName1                                  /subscriptions/00000000-0000-0000-000000000000/resourceGroups/ResourceGroupName/providers/microsoft.network/privateendpoints/hpName  None                                             Auto-approved                                Approved                                Succeeded
```

Gets a private endpoint connection from a HostPool.

### Example 1: List PrivateEndpointConnections by HostPool 
```powershell
Get-AzWvdPrivateEndpointConnection -ResourceGroupName ResourceGroupName -HostPoolName hpName
```

```output
Name                                         PrivateEndpointId                                                                                                                    PrivateLinkServiceConnectionStateActionsRequired PrivateLinkServiceConnectionStateDescription PrivateLinkServiceConnectionStateStatus ProvisioningState
----                                         -----------------                                                                                                                    ------------------------------------------------ -------------------------------------------- --------------------------------------- -----------------
privateName1                                  /subscriptions/00000000-0000-0000-000000000000/resourceGroups/ResourceGroupName/providers/microsoft.network/privateendpoints/hpName None                                             Auto-approved                                Approved                                Succeeded
privateName2                                  /subscriptions/00000000-0000-0000-000000000000/resourceGroups/ResourceGroupName/providers/microsoft.network/privateendpoints/hpName None                                             Auto-approved                                Approved                                Succeeded
```

Lists private endpoint connections from a Hostpool.

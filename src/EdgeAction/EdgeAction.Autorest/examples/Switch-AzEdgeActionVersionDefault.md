### Example 1: Switch the default version of an edge action

```powershell
Switch-AzEdgeActionVersionDefault -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v2"
```

```output
Name Location ProvisioningState
---- -------- -----------------
v2   global   Succeeded
```

Switches the default version of the edge action to v2. All traffic will now be routed to this version.


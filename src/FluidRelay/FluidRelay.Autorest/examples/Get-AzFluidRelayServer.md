### Example 1: List Fluid Relay server.
```powershell
Get-AzFluidRelayServer
```

```output
Location Name            ResourceGroupName
-------- ----            -----------------
westus2  azps-fluidrelay azpstest-gp
```

List Fluid Relay server.

### Example 2: List Fluid Relay server by ResourceGroup.
```powershell
Get-AzFluidRelayServer -ResourceGroup azpstest-gp
```

```output
Location Name            ResourceGroupName
-------- ----            -----------------
westus2  azps-fluidrelay azpstest-gp
```

List Fluid Relay server.

### Example 3: Get a Fluid Relay server by ResourceGroup.
```powershell
Get-AzFluidRelayServer -Name azps-fluidrelay -ResourceGroup azpstest-gp
```

```output
Location Name            ResourceGroupName
-------- ----            -----------------
westus2  azps-fluidrelay azpstest-gp
```

Get a Fluid Relay server.
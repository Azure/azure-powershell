### Example 1: Get a Fluid Relay container.
```powershell
Get-AzFluidRelayContainer -FluidRelayServerName azps-fluidrelay -ResourceGroup azpstest-gp
```

```output
Name                                 ResourceGroupName
----                                 -----------------
6c0389c1-b0e9-45c8-b60d-cd4e9c318b9a azpstest-gp
```

Get a Fluid Relay container.
Read and execute this document [Quickstart: Dice roller](https://docs.microsoft.com/en-us/azure/azure-fluid-relay/quickstarts/quickstart-dice-roll) to complete setup of the environment.

### Example 2:Get a Fluid Relay container.
```powershell
Get-AzFluidRelayContainer -FluidRelayServerName azps-fluidrelay -ResourceGroup azpstest-gp -Name 6c0389c1-b0e9-45c8-b60d-cd4e9c318b9a
```

```output
Name                                 ResourceGroupName
----                                 -----------------
6c0389c1-b0e9-45c8-b60d-cd4e9c318b9a azpstest-gp
```

Get a Fluid Relay container.
Read and execute this document [Quickstart: Dice roller](https://docs.microsoft.com/en-us/azure/azure-fluid-relay/quickstarts/quickstart-dice-roll) to complete setup of the environment.
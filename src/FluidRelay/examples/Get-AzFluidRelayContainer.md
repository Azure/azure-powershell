### Example 1: List Fluid Relay container.
```powershell
Get-AzFluidRelayContainer -FluidRelayServerName azps-fluidrelay -ResourceGroup azpstest-gp
```

```output
Name                                 CreationTime           LastAccessTime         ResourceGroupName
----                                 ------------           --------------         -----------------
eb4dd5f6-531f-44e1-86e3-759d39d1010c 2022-06-16 02:35:16 AM 2022-06-16 02:58:55 AM azpstest-gp
5affba7d-d288-42c9-9ed2-6d50fbf7ec98 2022-06-16 03:22:45 AM                        azpstest-gp
```

List Fluid Relay container.
Read and execute this document [Quickstart: Dice roller](https://learn.microsoft.com/en-us/azure/azure-fluid-relay/quickstarts/quickstart-dice-roll) to complete setup of the environment.

### Example 2:Get a Fluid Relay container.
```powershell
Get-AzFluidRelayContainer -FluidRelayServerName azps-fluidrelay -ResourceGroup azpstest-gp -Name eb4dd5f6-531f-44e1-86e3-759d39d1010c
```

```output
Name                                 CreationTime           LastAccessTime         ResourceGroupName
----                                 ------------           --------------         -----------------
eb4dd5f6-531f-44e1-86e3-759d39d1010c 2022-06-16 02:35:16 AM 2022-06-16 02:58:55 AM azpstest-gp
```

Get a Fluid Relay container.
Read and execute this document [Quickstart: Dice roller](https://learn.microsoft.com/en-us/azure/azure-fluid-relay/quickstarts/quickstart-dice-roll) to complete setup of the environment.
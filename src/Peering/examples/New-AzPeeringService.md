### Example 1: Create a new peering service
```powershell
New-AzPeeringService -Name TestPeeringService -ResourceGroupName DemoRG -Location "East US 2" -PeeringServiceLocation Georgia -PeeringServiceProvider MicrosoftEdge -ProviderPrimaryPeeringLocation Atlanta
```

```output
Name               ResourceGroupName PeeringServiceLocation Provider      ProvisioningState   Location
----               ----------------- ---------------------- --------      -----------------   --------
TestPeeringService DemoRG            Georgia                MicrosoftEdge ProvisioningStarted East US 2
```

Create a new peering service in the resource group
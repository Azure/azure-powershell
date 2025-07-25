### Example 1: List all peering services under subscription
```powershell
Get-AzPeeringService
```

```output
Name                               ResourceGroupName PeeringServiceLocation Provider      ProvisioningState Location
----                               ----------------- ---------------------- --------      ----------------- --------
TestPrefixForAtlanta               DemoRG            Georgia                MicrosoftEdge Succeeded         East US 2
TestExtension                      DemoRG            Virginia               MicrosoftEdge Succeeded         East US
TestExtension2                     DemoRG            Virginia               MicrosoftEdge Succeeded         East US
DemoPeeringServiceInterCloudLondon DemoRG            London                 InterCloud    Succeeded         UK South
DRTestInterCloud                   DemoRG            Ile-de-France          InterCloud    Succeeded         UK South
Gaurav Thareja                     DemoRG            Ile-de-France          InterCloud    Succeeded         UK South
TestDRInterCloudZurich             DemoRG            Zurich                 InterCloud    Succeeded         France Central
DRTest                             DemoRG            Ile-de-France          InterCloud    Succeeded         France Central
```

Lists all peering services under default subscription

### Example 2: List all peering services under a specific resource group
```powershell
Get-AzPeeringService -ResourceGroupName DemoRG
```

```output
Name                               ResourceGroupName PeeringServiceLocation Provider      ProvisioningState Location
----                               ----------------- ---------------------- --------      ----------------- --------
TestPrefixForAtlanta               DemoRG            Georgia                MicrosoftEdge Succeeded         East US 2
TestExtension                      DemoRG            Virginia               MicrosoftEdge Succeeded         East US
TestExtension2                     DemoRG            Virginia               MicrosoftEdge Succeeded         East US
DemoPeeringServiceInterCloudLondon DemoRG            London                 InterCloud    Succeeded         UK South
DRTestInterCloud                   DemoRG            Ile-de-France          InterCloud    Succeeded         UK South
Gaurav Thareja                     DemoRG            Ile-de-France          InterCloud    Succeeded         UK South
TestDRInterCloudZurich             DemoRG            Zurich                 InterCloud    Succeeded         France Central
DRTest                             DemoRG            Ile-de-France          InterCloud    Succeeded         France Central
```

Lists all the peering services under a resource group


### Example 3: List all peering services under a specific resource group
```powershell
Get-AzPeeringService -ResourceGroupName DemoRG -Name TestExtension
```

```output
Name                               ResourceGroupName PeeringServiceLocation Provider      ProvisioningState Location
----                               ----------------- ---------------------- --------      ----------------- --------
TestExtension                      DemoRG            Virginia               MicrosoftEdge Succeeded         East US
```

Gets a peering service with matching name and resource group
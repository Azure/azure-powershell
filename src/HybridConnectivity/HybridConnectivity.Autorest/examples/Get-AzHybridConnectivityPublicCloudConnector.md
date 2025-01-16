### Example 1: {{ Retrieve Details of a Public Cloud Connector }}
```powershell
Get-AzHybridConnectivityPublicCloudConnector `
    -PublicCloudConnector "MyTestConnector" `
    -ResourceGroupName "MyResourceGroup"
```

```output
Name                 : MyTestConnector
Id                   : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/MyResourceGroup/providers/Microsoft.HybridConnectivity/publicCloudConnectors/MyTestConnector
Location             : eastus
ProvisioningState    : Succeeded
AwsCloudProfile      : @{accountId=123456789012; isOrganizationalAccount=False}
```

This command retrieves details of the Public Cloud Connector named MyTestConnector in the MyResourceGroup.

### Example 2: {{ List All Public Cloud Connectors in a Resource Group }}
```powershell
Get-AzHybridConnectivityPublicCloudConnector -ResourceGroupName "MyResourceGroup"
```

```output
Name                 : MyTestConnector
Location             : eastus
ProvisioningState    : Succeeded
Name                 : MyTaggedConnector
Location             : eastus
ProvisioningState    : Succeeded
```

This command lists all Public Cloud Connectors in the MyResourceGroup.


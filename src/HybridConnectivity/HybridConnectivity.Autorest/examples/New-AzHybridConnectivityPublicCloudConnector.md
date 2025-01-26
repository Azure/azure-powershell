### Example 1: {{ Creating a PublicCloudConnector Resource }}
```powershell
New-AzHybridConnectivityPublicCloudConnector `
    -PublicCloudConnector "MyTestConnector" `
    -ResourceGroupName "MyResourceGroup" `
    -Location "eastus" `
    -AwCloudProfileAccountId "123456789012"
```

```output
AwCloudProfileAccountId               : 123456789012
AwCloudProfileExcludedAccount         :
AwCloudProfileIsOrganizationalAccount : False
ConnectorPrimaryIdentifier            : c3387367-40f1-43a1-ad10-9666b6029c04
HostType                              : AWS
Id                                    : /subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/MyResourceGroup/providers/Microsoft.HybridConnectivity
                                        /publicCloudConnectors/MyTestConnector
Location                              : eastus
Name                                  : MyTestConnector
ProvisioningState                     : Succeeded
ResourceGroupName                     : MyResourceGroup
SystemDataCreatedAt                   : 16/1/2025 1:53:07 pm
SystemDataCreatedBy                   : user@microsoft.com
SystemDataCreatedByType               : User
SystemDataLastModifiedAt              : 16/1/2025 1:53:07 pm
SystemDataLastModifiedBy              : user@microsoft.com
SystemDataLastModifiedByType          : User
Tag                                   : {
                                        }
Type                                  : microsoft.hybridconnectivity/publiccloudconnectors
```

This command creates a Public Cloud Connector named MyTestConnector in the MyResourceGroup located in the eastus region. It uses a dummy AWS Cloud Profile Account ID 123456789012.

### Example 2: {{ Creating a PublicCloudConnector Resource with Tags }}
```powershell
New-AzHybridConnectivityPublicCloudConnector `
    -PublicCloudConnector "MyTaggedConnector" `
    -ResourceGroupName "MyResourceGroup" `
    -Location "eastus" `
    -AwCloudProfileAccountId "760981343774" `
    -Tag @{ "Environment" = "Production"; "Purpose" = "Testing" }
```

```output
Name                 : MyTaggedConnector
Id                   : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/MyResourceGroup/providers/Microsoft.HybridConnectivity/publicCloudConnectors/MyTaggedConnector
Location             : eastus
ProvisioningState    : Succeeded
Tags                 : @{Environment=Production; Purpose=Testing}
AwsCloudProfile      : @{accountId=760981343774; isOrganizationalAccount=False}
```

This command creates a Public Cloud Connector named MyTaggedConnector in the MyResourceGroup with Production and Testing tags.


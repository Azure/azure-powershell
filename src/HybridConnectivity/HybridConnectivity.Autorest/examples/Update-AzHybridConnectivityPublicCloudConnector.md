### Example 1: {{ Update Tags for a Public Cloud Connector }}
```powershell
Update-AzHybridConnectivityPublicCloudConnector `
    -PublicCloudConnector "MyTestConnector" `
    -ResourceGroupName "MyResourceGroup" `
    -Tag @{ "Environment" = "Staging"; "Updated" = "True" }
```

```output
Name                 : MyTestConnector
Tags                 : @{Environment=Staging; Updated=True}
ProvisioningState    : Succeeded
```

This command updates the tags for the MyTestConnector to include Staging and Updated.

### Example 2: {{ Update a Public Cloud Connector’s Organizational Account }}
```powershell
Update-AzHybridConnectivityPublicCloudConnector `
    -PublicCloudConnector "MyTestConnector" `
    -ResourceGroupName "MyResourceGroup" `
    -AwCloudProfileIsOrganizationalAccount $true
```

```output
Name                 : MyTestConnector
AwsCloudProfile      : @{accountId=123456789012; isOrganizationalAccount=True}
ProvisioningState    : Succeeded
```

This command updates the MyTestConnector to set the AWS Cloud Profile as an organizational account.


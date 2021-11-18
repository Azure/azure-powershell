### Example 1: Check requirements for a Data Connector
```powershell
PS C:\> Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Kind Office365 -TenantId (Get-AzContext).Tenant.Id

{{ Add output here }}
```

Check the Data Connector Requirements for the Office 365 data connector.

### Example 2: {{ Add title here }}
```powershell
PS C:\> Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Kind 'AzureSecurityCenter' -ASCSubscriptionId (Get-AzContext).Subscription.Id

{{ Add output here }}
```

Check the Data Connector Requirements for the Microsoft Defender for Cloud data connector.



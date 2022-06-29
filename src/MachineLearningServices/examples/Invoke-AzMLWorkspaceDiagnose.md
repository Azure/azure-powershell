### Example 1: Diagnose workspace setup issue
```powershell
Invoke-AzMLWorkspaceDiagnose -ResourceGroupName ml-rg-test -Name mlworkspace-cli01 -ApplicationInsightId @{'key1'="/subscriptions/xxxx-xxxxx-xxxxxxxxx-xxxx/resourceGroups/ml-rg-test/providers/Microsoft.insights/components/xxxxxxxxxxx"}
```

```output
ValueApplicationInsightsResult : {}
ValueContainerRegistryResult   :
ValueDnsResolutionResult       :
ValueKeyVaultResult            :
ValueNetworkSecurityRuleResult :
ValueOtherResult               :
ValueResourceLockResult        :
ValueStorageAccountResult      :
ValueUserDefinedRouteResult    :
```

Diagnose workspace setup issue

### Example 2: Diagnose workspace setup issue by workspace object
```powershell
$workspace = Get-AzMLWorkspace -ResourceGroupName ml-rg-test -Name mlworkspace-cli01
Invoke-AzMLWorkspaceDiagnose -InputObject $workspace -ApplicationInsightId @{'key1'="/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ml-rg-test/providers/Microsoft.insights/components/xxxxxxxxxxxx"}
```

```output
ValueApplicationInsightsResult : {}
ValueContainerRegistryResult   :
ValueDnsResolutionResult       :
ValueKeyVaultResult            :
ValueNetworkSecurityRuleResult :
ValueOtherResult               :
ValueResourceLockResult        :
ValueStorageAccountResult      :
ValueUserDefinedRouteResult    :
```

Diagnose workspace setup issue by workspace object


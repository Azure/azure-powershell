### Example 1: List properties of CA certificate.
```powershell
Get-AzEventGridCaCertificate -ResourceGroupName azps_test_group_eventgrid -NamespaceName azps-eventgridnamespace
```

```output
Name        ResourceGroupName
----        -----------------
azps-cacert AZPS_TEST_GROUP_EVENTGRID
```

List properties of CA certificate.

### Example 2: Get properties of a CA certificate.
```powershell
Get-AzEventGridCaCertificate -ResourceGroupName azps_test_group_eventgrid -NamespaceName azps-eventgridnamespace -Name azps-cacert
```

```output
Name        ResourceGroupName
----        -----------------
azps-cacert AZPS_TEST_GROUP_EVENTGRID
```

Get properties of a CA certificate.

### Example 3: Get properties of a CA certificate.
```powershell
$namespace = Get-AzEventGridNamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-eventgridnamespace
Get-AzEventGridCaCertificate -NamespaceInputObject $namespace -Name azps-cacert
```

```output
Name        ResourceGroupName
----        -----------------
azps-cacert AZPS_TEST_GROUP_EVENTGRID
```

Get properties of a CA certificate.
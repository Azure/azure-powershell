### Example 1: Create a client with the specified parameters.
```powershell
New-AzEventGridClient -Name azps-client -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -Attribute $attribute -State Enabled -ClientCertificateAuthenticationValidationScheme "SubjectMatchesAuthenticationName"
```

```output
Name        ResourceGroupName
----        -----------------
azps-client azps_test_group_eventgrid
```

Create a client with the specified parameters.
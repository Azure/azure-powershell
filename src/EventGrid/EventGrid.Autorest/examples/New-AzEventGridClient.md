### Example 1: Create a client with the specified parameters.
```powershell
$attribute = @{"room"="345";"floor"="3";"deviceTypes"="Fan"}
New-AzEventGridClient -Name azps-client -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -Attribute $attribute -State Enabled -ClientCertificateAuthenticationValidationScheme "SubjectMatchesAuthenticationName"
```

```output
Name        ResourceGroupName
----        -----------------
azps-client azps_test_group_eventgrid
```

Create a client with the specified parameters.
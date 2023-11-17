### Example 1: Create a CA certificate with the specified parameters.
```powershell
New-AzEventGridCaCertificate -Name azps-cacert -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -EncodedCertificate "-----BEGIN CERTIFICATE-----
>> ****************
>> ****************
>> ****************
>> -----END CERTIFICATE-----"
```

```output
Name        ResourceGroupName
----        -----------------
azps-cacert AZPS_TEST_GROUP_EVENTGRID
```

Create a CA certificate with the specified parameters.
A usable EncodedCertificate file can be created from this link: https://learn.microsoft.com/en-us/azure/event-grid/mqtt-publish-and-subscribe-cli#generate-sample-client-certificate-and-thumbprint

### Example 2: Create a CA certificate with the specified parameters.
```powershell
$crtData = Get-Content -Path "C:\intermediate_ca.crt" -Raw
New-AzEventGridCaCertificate -Name azps-cacert -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -EncodedCertificate $crtData.Trim("`n")
```

```output
Name        ResourceGroupName
----        -----------------
azps-cacert AZPS_TEST_GROUP_EVENTGRID
```

Create a CA certificate with the specified parameters.
A usable EncodedCertificate file can be created from this link: https://learn.microsoft.com/en-us/azure/event-grid/mqtt-publish-and-subscribe-cli#generate-sample-client-certificate-and-thumbprint
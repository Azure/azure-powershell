### Example 1: List streaming endpoint by Media Name.
```powershell
Get-AzMediaStreamingEndpoint -AccountName azpsms -ResourceGroupName azps_test_group
```

```output
Location Name      ResourceGroupName
-------- ----      -----------------
East US  azpsms-se azps_test_group
East US  default   azps_test_group
```

List streaming endpoint by Media Name.

### Example 2: Get a streaming endpoint by Streaming Endpoint Name.
```powershell
Get-AzMediaStreamingEndpoint -AccountName azpsms -ResourceGroupName azps_test_group -Name azpsms-se
```

```output
Location Name      ResourceGroupName
-------- ----      -----------------
East US  azpsms-se azps_test_group
```

Get a streaming endpoint by Streaming Endpoint Name.
### Example 1: Creates a streaming endpoint.
```powershell
$akamai = New-AzMediaAkamaiSignatureHeaderAuthenticationKeyObject -Base64Key "dGVzdGlkMQ==" -Expiration "2029-12-31T16:00:00-08:00" -Identifier "id1"
$ipRange = New-AzMediaIPRangeObject -Address "192.168.1.1" -Name AllowedIp

New-AzMediaStreamingEndpoint -AccountName azpsms -Name azpsms-se -ResourceGroupName azps_test_group -Location eastus -AkamaiSignatureHeaderAuthenticationKeyList $akamai -AvailabilitySetName "availableset" -CdnEnabled:$False -IPAllow $ipRange -ScaleUnit 1
```

```output
Location Name      ResourceGroupName
-------- ----      -----------------
East US  azpsms-se azps_test_group
```

Creates a streaming endpoint.
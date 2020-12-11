### Example 1: Delete the azDigitalTwinsEndPoint by EndPointName
```powershell
PS C:\> Remove-AzDigitalTwinsEndpoint -ResourceGroupName youritemp -EndpointName youriEHEndpoint -ResourceName youriDigitalTwinsTest

```

Delete the azDigitalTwinsEndPoint by EndPointName ResourceGroupName and ResourceName

### Example 2: Delete the azDigitalTwinsEndPoint by Object
```powershell
PS C:\> $GetAzdigitalTwinsEndpoint = Get-AzDigitalTwinsEndpoint -EndpointName youriEHEndpoint -ResourceGroupName youritemp -ResourceName youriDigitalTwinsTest
Remove-AzDigitalTwinsEndpoint -InputObject $GetAzdigitalTwinsEndpoint

```

Delete the azDigitalTwinsEndPoint by Object


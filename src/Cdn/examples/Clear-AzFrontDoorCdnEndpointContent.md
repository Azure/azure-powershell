### Example 1: Clear the content of an AzureFrontDoor endpoint
```powershell
Clear-AzFrontDoorCdnEndpointContent -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001 -ContentPath /a
```

```output
```

Clear the content of an AzureFrontDoor endpoint using Parameter "ContentPath"


### Example 2: Clear the content of an AzureFrontDoor endpoint
```powershell
Clear-AzCdnEndpointContent -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Content /a
```

```output
```

Clear the content of an AzureFrontDoor endpoint using Parameter "Content"


### Example 3: Clear the content of an AzureFrontDoor endpoint via identity
```powershell
Clear-AzCdnEndpointContent -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -ContentPath /a
```

```output
```

Clear the content of an AzureFrontDoor endpoint using Parameter "ContentPath" via identity


### Example 4: Clear the content of an AzureFrontDoor endpoint via identity
```powershell
Clear-AzCdnEndpointContent -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Content /a
```

```output
```

Clear the content of an AzureFrontDoor endpoint using Parameter "Content" via identity
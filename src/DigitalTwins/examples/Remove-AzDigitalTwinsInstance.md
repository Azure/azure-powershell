### Example 1: Remove an AzDigitalTwinsInstance by name
```powershell
PS C:\> Remove-AzDigitalTwinsInstance -ResourceGroupName youritemp -ResourceName youriDigitalTwin


```

This command removes an AzDigitalTwinsInstance by name

### Example 2: Remove an AzDigitalTwinsInstance by InputObject
```powershell
PS C:\> $GetAzDigitalTwins =  Get-AzDigitalTwinsInstance -ResourceGroupName youritemp -ResourceName youriDigitalTwinsTest
Remove-AzDigitalTwinsInstance -InputObject $GetAzDigitalTwins


```

This command removes an AzDigitalTwinsInstance by name


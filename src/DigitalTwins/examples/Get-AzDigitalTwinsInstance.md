### Example 1: List (Default)
```powershell
Get-AzDigitalTwinsInstance
```

```output
Location Name                    Type
-------- ----                    ----
eastus   youriDigitalTwinsTest   Microsoft.DigitalTwins/digitalTwinsInstances
eastus   youriDigitalTwin        Microsoft.DigitalTwins/digitalTwinsInstances
```

Get all the DigitalTwinsInstance by default

### Example 2: Get
```powershell
Get-AzDigitalTwinsInstance -ResourceGroupName youritemp -ResourceName youriDigitalTwin
```

```output
Location Name             Type
-------- ----             ----
eastus   youriDigitalTwin Microsoft.DigitalTwins/digitalTwinsInstances
```

Get the specified AzDigitalTwinsInstance by ResourceName

### Example 3: GetViaIdentity
```powershell
$NewAzDigital = New-AzDigitalTwinsInstance -ResourceGroupName youritemp -ResourceName youriDigitalTwin -Location eastus
Get-AzDigitalTwinsInstance -inputObject $NewAzDigital
```

```output
Location Name             Type
-------- ----             ----
eastus   youriDigitalTwin Microsoft.DigitalTwins/digitalTwinsInstances
```

Get the specified AzDigitalTwinsInstance by Object

### Example 4: List1
```powershell
Get-AzDigitalTwinsInstance -ResourceGroupName youritemp
```

```output
Location Name                    Type
-------- ----                    ----
eastus   youriDigitalTwinsTest   Microsoft.DigitalTwins/digitalTwinsInstances
eastus   youriDigitalTwin        Microsoft.DigitalTwins/digitalTwinsInstances
```

Get all the DigitalTwinsInstance by ResourceGroupName
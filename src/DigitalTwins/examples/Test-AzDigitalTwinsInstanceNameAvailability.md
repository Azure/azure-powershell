### Example 1: Check the name by location and name.
```powershell
Test-AzDigitalTwinsInstanceNameAvailability -Location eastus -name youriTestName
```

```output
Message                       NameAvailable Reason
-------                       ------------- ------
'youriTestName' is available. True
```

Check the availability of the name by location and name.

### Example 2: Check the name by DigitalTwinsObject and CheckNameObject.
```powershell
$getAzDT =Get-AzDigitalTwinsInstance -ResourceGroupName youritemp -ResourceName youriDigitalTwinsTest 
$checkName = New-AzDigitalTwinsCheckNameRequestObject -name youriTestName
Test-AzDigitalTwinsInstanceNameAvailability -InputObject $getAzDT -DigitalTwinsInstanceCheckName $checkName
```

```output
Message                     NameAvailable Reason
-------                     ------------- ------
'youriTestName' is available. True
```

Get A DigitalTwinsInstance and create a Requset Object to Test the availability of the name.


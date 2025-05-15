### Example 1: Check if a DigitalTwinsInstance name is available.
```powershell
Test-AzDigitalTwinsInstanceNameAvailability -Location westus2 -Name testName
```

```output
Message                  NameAvailable Reason
-------                  ------------- ------
'testName' is available. True
```

Check if a DigitalTwinsInstance name is available.

### Example 2: Check if a DigitalTwinsInstance name is not available.
```powershell
Test-AzDigitalTwinsInstanceNameAvailability -Location westus2 -Name !testName
```

```output
Message                                                                                                                                NameAvailable Reason
-------                                                                                                                                ------------- ------
'!testName' must be between 3 and 63 characters. Alphanumerics and hyphens are allowed. Value must start and end with an alphanumeric. False         Invalid
```

Check if a DigitalTwinsInstance name is not available.
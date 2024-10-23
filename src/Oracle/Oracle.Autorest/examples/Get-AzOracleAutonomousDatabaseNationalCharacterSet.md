### Example 1: Get a list of the Autonomous Database National Character Sets by location
```powershell
(Get-AzOracleAutonomousDatabaseNationalCharacterSet -Location "eastus").CharacterSet
```

```output
AL16UTF16
UTF8
```

Get a list of the Autonomous Database National Character Sets by location.
For more information, execute `Get-Help Get-AzOracleAutonomousDatabaseNationalCharacterSet`.
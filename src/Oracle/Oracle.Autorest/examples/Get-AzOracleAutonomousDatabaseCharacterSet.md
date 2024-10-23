### Example 1: Get a list of the Autonomous Database Character Sets by location
```powershell
(Get-AzOracleAutonomousDatabaseCharacterSet -Location "eastus").CharacterSet
```

```output
AL32UTF8
AR8ADOS710
AR8ADOS720
```

Get a list of the Autonomous Database Character Sets by location.
For more information, execute `Get-Help Get-AzOracleAutonomousDatabaseCharacterSet`.
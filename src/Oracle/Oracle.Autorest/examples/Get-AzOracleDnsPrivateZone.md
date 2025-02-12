### Example 1: Get a list of the DNS Private Zones by location
```powershell
Get-AzOracleDnsPrivateZone -Location "eastus"
```

```output
Name                                                                      SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                                                                      ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
byui3zo3.ocidelegated.ocipstestvnet.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                       
byui3zo3.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                                                  
byui3zo3.adbapps.us-ashburn-1.oraclevcn.com
```

Get a list of the DNS Private Zones by location.
For more information, execute `Get-Help Get-AzOracleDnsPrivateZone`.
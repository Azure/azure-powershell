### Example 1: get the detail of an ESU license
```powershell
New-AzConnectedLicenseDetail -State 'Activated' -Target 'Windows Server 2012' -Edition 'Datacenter' -Type 'pCore' -Processor 16
```

```output
AssignedLicense     :
Edition             : Datacenter
ImmutableId         :
Processor           : 16
State               : Activated
Target              : Windows Server 2012
Type                : pCore
VolumeLicenseDetail :
```

get the detail of an ESU license
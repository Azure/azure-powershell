### Example 1: Create a library object for pypi.
```powershell
New-AzHdInsightOnAksClusterPyPiLibraryObject -Name pandas -Version 2.2.2 -Remark "Pandas Lib."
```

```output
PropertiesType               : pypi
Property                     : {
                                 "type": "pypi",
                                 "remarks": "test add pandas",
                                 "name": "pandas",
                                 "version": "2.2.2"
                               }
Remark                       : test add pandas
```

Create a library object for pypi.

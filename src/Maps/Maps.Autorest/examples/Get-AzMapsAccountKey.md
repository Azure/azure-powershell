### Example 1: Get the keys to use with the Maps APIs
```powershell
Get-AzMapsAccountKey -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount02
```

```output
PrimaryKey                                  PrimaryKeyLastUpdated        SecondaryKey                                SecondaryKeyLastUpdated
----------                                  ---------------------        ------------                                -----------------------
AZPcJC8OCNCpqRsnj1NB3Ngl-qQncBP5IT21jts_2b0 2021-05-20T05:59:16.2028276Z 3l_cups4uVp7LB90G861PB_ddEFJFOdt0beX1U8ROO4 2021-05-20T05:59:16.2028276Z
```

This command get the keys to use with the Maps APIs.
A key is used to authenticate and authorize access to the Maps REST APIs.
Only one key is needed at a time; two are given to provide seamless key regeneration.

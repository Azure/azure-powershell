### Example 1: Check if the probe path is a valid path and the file can be accessed
```powershell
Test-AzCdnProbe -ProbeUrl "https://azurecdn-files.azureedge.net/dsa-test/probe-v.txt"
```

```output
ErrorCode IsValid Message
--------- ------- -------
None      True
```

Check if the probe path is a valid path and the file can be accessed

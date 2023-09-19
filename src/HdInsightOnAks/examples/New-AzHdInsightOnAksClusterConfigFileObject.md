### Example 1: Create cluster config file
```powershell
$coreSiteConfigFile=New-AzHdInsightOnAksClusterConfigFileObject -FileName "core-site.xml" -Value @{"fs.defaultFS"="abfs://testcontainer@$teststorage.dfs.core.windows.net"}
```

This cmdlet create the config file "core-site.xml" and set the key "fs.defaultFS" with the value "abfs://testcontainer@$teststorage.dfs.core.windows.net" in this file.
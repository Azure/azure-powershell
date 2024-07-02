### Example 1: Create a component config.
```powershell
$coreSiteConfigFile=New-AzHdInsightOnAksClusterConfigFileObject -FileName "core-site.xml" -Value @{"fs.defaultFS"="abfs://testcontainer@$teststorage.dfs.core.windows.net"}
New-AzHdInsightOnAksClusterServiceConfigObject -ComponentName "yarn-config" -File $coreSiteConfigFile
```

```output
Component   File
---------   ----
yarn-config {{…
```

This cmdlet create the component config of "yarn-config" based the existing config file $coreSiteConfigFile.
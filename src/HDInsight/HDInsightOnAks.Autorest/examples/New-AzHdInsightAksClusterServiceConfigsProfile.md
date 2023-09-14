### Example 1: Create a service config profile
```powershell
$coreSiteConfigFile=New-AzHDInsightAksClusterConfigFile -FileName "core-site.xml" -Value @{"fs.defaultFS"="abfs://testcontainer@$teststorage.dfs.core.windows.net"}
$yarnComponentConfig= New-AzHDInsightAksClusterServiceConfig -ComponentName "yarn-config" -File $coreSiteConfigFile
$yarnServiceConfigProfile=New-AzHDInsightAksClusterServiceConfigsProfile -ServiceName "yarn-service" -Config $yarnComponentConfig
`````

This cmdlet creates the service config profile of "yarn-service" with the component service config.
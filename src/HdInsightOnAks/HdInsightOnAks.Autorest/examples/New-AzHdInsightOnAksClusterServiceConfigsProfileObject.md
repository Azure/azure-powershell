### Example 1: Create a service config profile
```powershell
$coreSiteConfigFile=New-AzHdInsightOnAksClusterConfigFileObject -FileName "core-site.xml" -Value @{"fs.defaultFS"="abfs://testcontainer@$teststorage.dfs.core.windows.net"}
$yarnComponentConfig= New-AzHdInsightOnAksClusterServiceConfigObject -ComponentName "yarn-config" -File $coreSiteConfigFile
$yarnServiceConfigProfile=New-AzHdInsightOnAksClusterServiceConfigsProfileObject -ServiceName "yarn-service" -Config $yarnComponentConfig
`````

This cmdlet creates the service config profile of "yarn-service" with the ComponentName service config.
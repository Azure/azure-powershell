### Example 1: Deploy the build file to an standard spring app
```powershell
$jarObj = New-AzSpringCloudAppDeploymentJarUploadedObject -RuntimeVersion "Java_8"
New-AzSpringCloudAppDeployment -ResourceGroupName springcloud-rg-0zquav -ServiceName spring-va4fsz -AppName account -Name green -Source $jarObj
Get-AzSpringCloudApp -ResourceGroupName springcloud-rg-0zquav -ServiceName spring-va4fsz -Name account | Update-AzSpringCloudAppActiveDeployment -DeploymentName 'green'
Deploy-AzSpringCloudApp -ResourceGroupName springcloud-rg-0zquav -ServiceName spring-va4fsz -Name account -FilePath "C:\Users\v-diya\Downloads\hellospring\target\hellospring-0.0.1-SNAPSHOT.jar"
```

```output
[1/3] Requesting for upload URL
[2/3] Uploading package to blob
[3/3] Updating deployment in app demo (this operation can take a while to complete)

Name  SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----  -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
green 6/24/2022 6:50:58 AM v-test@microsoft.com User                    7/19/2022 7:06:08 AM     v-test@microsoft.com     User                         spring-rg-test
```

This command deploy the build file to an standard spring app.

### Example 2: Deploy the build file to an enterprise spring app
```powershell
$source = New-AzSpringCloudAppDeploymentBuildResultObject
New-AzSpringCloudAppDeployment -ResourceGroupName springcloud-rg-0zquav -ServiceName spring-f7lz2n -AppName account -Name green -Source $source
Get-AzSpringCloudApp -ResourceGroupName springcloud-rg-0zquav -ServiceName spring-f7lz2n -Name account | Update-AzSpringCloudAppActiveDeployment -DeploymentName 'green'
$builder = Get-AzSpringCloudBuildServiceBuilder -ResourceGroupName springcloud-rg-0zquav -ServiceName spring-f7lz2n -Name default
$agentPool = Get-AzSpringCloudBuildServiceAgentPool -ResourceGroupName springcloud-rg-0zquav -ServiceName spring-f7lz2n
Deploy-AzSpringCloudApp -ResourceGroupName springcloud-rg-0zquav -ServiceName spring-f7lz2n -Name account -AgentPoolId $agentPool.Id -BuilderId $builder.Id -FilePath "C:\Users\v-diya\Downloads\hellospring\target\hellospring-0.0.1-SNAPSHOT.jar"
```

```output
[1/3] Requesting for upload URL
[2/3] Uploading package to blob
[3/3] Updating deployment in app demo (this operation can take a while to complete)

Name  SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----  -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
green 6/24/2022 6:50:58 AM v-test@microsoft.com User                    7/19/2022 7:06:08 AM     v-test@microsoft.com     User                         spring-rg-test
```

This command deploy the build file to an enterprise spring app.
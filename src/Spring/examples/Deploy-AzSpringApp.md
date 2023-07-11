### Example 1: Deploy the build file to an standard spring app
```powershell
$jarObj = New-AzSpringAppDeploymentJarUploadedObject -RuntimeVersion "Java_8"
New-AzSpringAppDeployment -ResourceGroupName Spring-rg-0zquav -ServiceName spring-va4fsz -AppName account -Name green -Source $jarObj
Get-AzSpringApp -ResourceGroupName Spring-rg-0zquav -ServiceName spring-va4fsz -Name account | Update-AzSpringAppActiveDeployment -DeploymentName 'green'
Deploy-AzSpringApp -ResourceGroupName Spring-rg-0zquav -ServiceName spring-va4fsz -Name account -FilePath "C:\Users\v-diya\Downloads\hellospring\target\hellospring-0.0.1-SNAPSHOT.jar"
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
$source = New-AzSpringAppDeploymentBuildResultObject
New-AzSpringAppDeployment -ResourceGroupName Spring-rg-0zquav -ServiceName spring-f7lz2n -AppName account -Name green -Source $source
Get-AzSpringApp -ResourceGroupName Spring-rg-0zquav -ServiceName spring-f7lz2n -Name account | Update-AzSpringAppActiveDeployment -DeploymentName 'green'
$builder = Get-AzSpringBuildServiceBuilder -ResourceGroupName Spring-rg-0zquav -ServiceName spring-f7lz2n -Name default
$agentPool = Get-AzSpringBuildServiceAgentPool -ResourceGroupName Spring-rg-0zquav -ServiceName spring-f7lz2n
Deploy-AzSpringApp -ResourceGroupName Spring-rg-0zquav -ServiceName spring-f7lz2n -Name account -AgentPoolId $agentPool.Id -BuilderId $builder.Id -FilePath "C:\Users\v-diya\Downloads\hellospring\target\hellospring-0.0.1-SNAPSHOT.jar"
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
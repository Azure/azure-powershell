### Example 1: Deploy the build file to an existing deployment
```powershell
 Deploy-AzSpringCloudApp -ResourceGroupName spring-rg-test -ServiceName spring-cli01 -Name demo -DeploymentName green -FilePath "C:\Users\Downloads\hellospring\target\hellospring-0.0.1-SNAPSHOT.jar"
```

```output
[1/3] Requesting for upload URL
[2/3] Uploading package to blob
[3/3] Updating deployment in app demo (this operation can take a while to complete)

Name  SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----  -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
green 6/24/2022 6:50:58 AM v-test@microsoft.com User                    7/19/2022 7:06:08 AM     v-test@microsoft.com     User                         spring-rg-test
```

This command deploys the build file to an existing deployment.
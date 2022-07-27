---
Module Name: Az.Websites
Module Guid: cc69c625-e961-43f4-8b50-0061eba6e4b6
Download Help Link: https://docs.microsoft.com/powershell/module/az.websites
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Websites Module
## Description
ARM (Azure Resource Manager) Web App and App Service Plan commands.

## Az.Websites Cmdlets
### [Add-AzWebAppAccessRestrictionRule](Add-AzWebAppAccessRestrictionRule.md)
Adds an Access Restiction rule to an Azure Web App.

### [Add-AzWebAppTrafficRouting](Add-AzWebAppTrafficRouting.md)
Add a routing Rule to the Slot.

### [Edit-AzWebAppBackupConfiguration](Edit-AzWebAppBackupConfiguration.md)


### [Enter-AzWebAppContainerPSSession](Enter-AzWebAppContainerPSSession.md)
Opens a remote PowerShell session into the windows container specified in a given site or slot and given resource group

### [Get-AzAppServiceEnvironment](Get-AzAppServiceEnvironment.md)
Gets App Service Environment. If only Resource Group is specified, it will return a list of ASE in the Resource Group.

### [Get-AzAppServicePlan](Get-AzAppServicePlan.md)
Gets an Azure App Service plan in the specified resource group.

### [Get-AzDeletedWebApp](Get-AzDeletedWebApp.md)
Gets deleted web apps in the subscription.

### [Get-AzStaticWebApp](Get-AzStaticWebApp.md)
Description for Gets the details of a static site.

### [Get-AzStaticWebAppBuild](Get-AzStaticWebAppBuild.md)
Description for Gets the details of a static site build.

### [Get-AzStaticWebAppBuildAppSetting](Get-AzStaticWebAppBuildAppSetting.md)
Description for Gets the application settings of a static site build.

### [Get-AzStaticWebAppBuildFunction](Get-AzStaticWebAppBuildFunction.md)
Description for Gets the functions of a particular static site build.

### [Get-AzStaticWebAppBuildFunctionAppSetting](Get-AzStaticWebAppBuildFunctionAppSetting.md)
Description for Gets the application settings of a static site build.

### [Get-AzStaticWebAppConfiguredRole](Get-AzStaticWebAppConfiguredRole.md)
Description for Lists the roles configured for the static site.

### [Get-AzStaticWebAppCustomDomain](Get-AzStaticWebAppCustomDomain.md)
Description for Gets an existing custom domain for a particular static site.

### [Get-AzStaticWebAppFunction](Get-AzStaticWebAppFunction.md)
Description for Gets the functions of a static site.

### [Get-AzStaticWebAppFunctionAppSetting](Get-AzStaticWebAppFunctionAppSetting.md)
Description for Gets the application settings of a static site.

### [Get-AzStaticWebAppSecret](Get-AzStaticWebAppSecret.md)
Description for Lists the secrets for an existing static site.

### [Get-AzStaticWebAppSetting](Get-AzStaticWebAppSetting.md)
Description for Gets the application settings of a static site.

### [Get-AzStaticWebAppUser](Get-AzStaticWebAppUser.md)
Description for Gets the list of users of a static site.

### [Get-AzStaticWebAppUserProvidedFunctionApp](Get-AzStaticWebAppUserProvidedFunctionApp.md)
Description for Gets the details of the user provided function app registered with a static site build

### [Get-AzWebApp](Get-AzWebApp.md)
Gets Azure Web Apps in the specified resource group.

### [Get-AzWebAppAccessRestrictionConfig](Get-AzWebAppAccessRestrictionConfig.md)
Gets Access Restiction configuration for an Azure Web App.

### [Get-AzWebAppBackup](Get-AzWebAppBackup.md)


### [Get-AzWebAppBackupConfiguration](Get-AzWebAppBackupConfiguration.md)


### [Get-AzWebAppBackupList](Get-AzWebAppBackupList.md)


### [Get-AzWebAppCertificate](Get-AzWebAppCertificate.md)
Gets an Azure Web App certificate.

### [Get-AzWebAppContainerContinuousDeploymentUrl](Get-AzWebAppContainerContinuousDeploymentUrl.md)
Get-AzWebAppContainerContinuousDeploymentUrl will return container continuous deployment url

### [Get-AzWebAppContinuousWebJob](Get-AzWebAppContinuousWebJob.md)
Get or list continuous web for an app.

### [Get-AzWebAppPublishingProfile](Get-AzWebAppPublishingProfile.md)
Gets an Azure Web App publishing profile.

### [Get-AzWebAppSlot](Get-AzWebAppSlot.md)
Gets an Azure Web App slot.

### [Get-AzWebAppSlotConfigName](Get-AzWebAppSlotConfigName.md)
Get the list of Web App Slot Config names

### [Get-AzWebAppSlotContinuousWebJob](Get-AzWebAppSlotContinuousWebJob.md)
Get or list continuous web for a deployment slot.

### [Get-AzWebAppSlotPublishingProfile](Get-AzWebAppSlotPublishingProfile.md)
Gets an Azure Web App slot publishing profile.

### [Get-AzWebAppSlotTriggeredWebJob](Get-AzWebAppSlotTriggeredWebJob.md)
Get or list triggered web for a deployment slot.

### [Get-AzWebAppSlotTriggeredWebJobHistory](Get-AzWebAppSlotTriggeredWebJobHistory.md)
Get or list triggered web job's history for a deployment slot.

### [Get-AzWebAppSlotWebJob](Get-AzWebAppSlotWebJob.md)
List webjobs for a deployment slot.

### [Get-AzWebAppSnapshot](Get-AzWebAppSnapshot.md)
Gets the snapshots available for a web app.

### [Get-AzWebAppSSLBinding](Get-AzWebAppSSLBinding.md)
Gets an Azure Web App certificate SSL binding.

### [Get-AzWebAppTrafficRouting](Get-AzWebAppTrafficRouting.md)
Get a routing Rule for the given Slot name.

### [Get-AzWebAppTriggeredWebJob](Get-AzWebAppTriggeredWebJob.md)
Get or list triggered web for an app.

### [Get-AzWebAppTriggeredWebJobHistory](Get-AzWebAppTriggeredWebJobHistory.md)
Get or list triggered web job's history for an app.

### [Get-AzWebAppWebJob](Get-AzWebAppWebJob.md)
List webjobs for an app.

### [Import-AzWebAppKeyVaultCertificate](Import-AzWebAppKeyVaultCertificate.md)
Import an SSL certificate to a web app from Key Vault.

### [New-AzAppServiceEnvironment](New-AzAppServiceEnvironment.md)
Creates an App Service Environment including the recommended Route Table and Network Security Group

### [New-AzAppServiceEnvironmentInboundServices](New-AzAppServiceEnvironmentInboundServices.md)
Creates inbound services for App Service Environment. For ASEv2 ILB, this will create an Azure Private DNS Zone and records to map to the internal IP. For ASEv3 it will in addition ensure subnet has Network Policy disabled and will create a private endpoint.

### [New-AzAppServicePlan](New-AzAppServicePlan.md)
Creates an Azure App Service plan in a given Geo location.

### [New-AzStaticWebApp](New-AzStaticWebApp.md)
Description for Creates a new static site in an existing resource group, or updates an existing static site.

### [New-AzStaticWebAppBuildAppSetting](New-AzStaticWebAppBuildAppSetting.md)
Description for Creates or updates the app settings of a static site build.

### [New-AzStaticWebAppBuildFunctionAppSetting](New-AzStaticWebAppBuildFunctionAppSetting.md)
Description for Creates or updates the function app settings of a static site build.

### [New-AzStaticWebAppCustomDomain](New-AzStaticWebAppCustomDomain.md)
Description for Creates a new static site custom domain in an existing resource group and static site.

### [New-AzStaticWebAppFunctionAppSetting](New-AzStaticWebAppFunctionAppSetting.md)
Description for Creates or updates the function app settings of a static site.

### [New-AzStaticWebAppSetting](New-AzStaticWebAppSetting.md)
Description for Creates or updates the app settings of a static site.

### [New-AzStaticWebAppUserRoleInvitationLink](New-AzStaticWebAppUserRoleInvitationLink.md)
Description for Creates an invitation link for a user with the role

### [New-AzWebApp](New-AzWebApp.md)
Creates an Azure Web App.

### [New-AzWebAppAzureStoragePath](New-AzWebAppAzureStoragePath.md)
Creates an object that represents an Azure Storage path to be mounted in a Web App. It is meant to be used as a parameter (-AzureStoragePath) to Set-AzWebApp and Set-AzWebAppSlot

### [New-AzWebAppBackup](New-AzWebAppBackup.md)


### [New-AzWebAppCertificate](New-AzWebAppCertificate.md)
Creates an App service managed certificate for an Azure Web App. 

### [New-AzWebAppContainerPSSession](New-AzWebAppContainerPSSession.md)
New-AzWebAppContainerPSSession will create new remote PowerShell Session into the windows container specified in a given site or slot and given resource group

### [New-AzWebAppDatabaseBackupSetting](New-AzWebAppDatabaseBackupSetting.md)


### [New-AzWebAppSlot](New-AzWebAppSlot.md)
Creates an Azure Web App slot.

### [New-AzWebAppSSLBinding](New-AzWebAppSSLBinding.md)
Creates an SSL certificate binding for an Azure Web App.

### [Publish-AzWebApp](Publish-AzWebApp.md)
Deploys an Azure Web App from a ZIP, JAR, or WAR file using zipdeploy. 

### [Register-AzStaticWebAppUserProvidedFunctionApp](Register-AzStaticWebAppUserProvidedFunctionApp.md)
Description for Register a user provided function app with a static site build

### [Remove-AzAppServiceEnvironment](Remove-AzAppServiceEnvironment.md)
Remove App Service Environment.

### [Remove-AzAppServicePlan](Remove-AzAppServicePlan.md)
Removes an Azure App Service plan.

### [Remove-AzStaticWebApp](Remove-AzStaticWebApp.md)
Description for Deletes a static site.

### [Remove-AzStaticWebAppAttachedRepository](Remove-AzStaticWebAppAttachedRepository.md)
Description for Detaches a static site.

### [Remove-AzStaticWebAppBuild](Remove-AzStaticWebAppBuild.md)
Description for Deletes a static site build.

### [Remove-AzStaticWebAppCustomDomain](Remove-AzStaticWebAppCustomDomain.md)
Description for Deletes a custom domain.

### [Remove-AzStaticWebAppUser](Remove-AzStaticWebAppUser.md)
Description for Deletes the user entry from the static site.

### [Remove-AzWebApp](Remove-AzWebApp.md)
Removes an Azure Web App.

### [Remove-AzWebAppAccessRestrictionRule](Remove-AzWebAppAccessRestrictionRule.md)
Removes an Access Restriction rule from an Azure Web App.

### [Remove-AzWebAppBackup](Remove-AzWebAppBackup.md)


### [Remove-AzWebAppCertificate](Remove-AzWebAppCertificate.md)
Removes an App service managed certificate for an Azure Web App. 

### [Remove-AzWebAppContinuousWebJob](Remove-AzWebAppContinuousWebJob.md)
Delete a continuous web job for an app.

### [Remove-AzWebAppSlot](Remove-AzWebAppSlot.md)


### [Remove-AzWebAppSlotContinuousWebJob](Remove-AzWebAppSlotContinuousWebJob.md)
Delete a continuous web job for a deployment slot.

### [Remove-AzWebAppSlotTriggeredWebJob](Remove-AzWebAppSlotTriggeredWebJob.md)
Delete a triggered web job for a deployment slot.

### [Remove-AzWebAppSSLBinding](Remove-AzWebAppSSLBinding.md)
Removes an SSL binding from an uploaded certificate.

### [Remove-AzWebAppTrafficRouting](Remove-AzWebAppTrafficRouting.md)
Remove a routing Rule from the Slot.

### [Remove-AzWebAppTriggeredWebJob](Remove-AzWebAppTriggeredWebJob.md)
Delete a triggered web job for an app.

### [Reset-AzStaticWebAppApiKey](Reset-AzStaticWebAppApiKey.md)
Description for Resets the api key for an existing static site.

### [Reset-AzWebAppPublishingProfile](Reset-AzWebAppPublishingProfile.md)


### [Reset-AzWebAppSlotPublishingProfile](Reset-AzWebAppSlotPublishingProfile.md)


### [Restart-AzWebApp](Restart-AzWebApp.md)
Restarts an Azure Web App.

### [Restart-AzWebAppSlot](Restart-AzWebAppSlot.md)


### [Restore-AzDeletedWebApp](Restore-AzDeletedWebApp.md)
Restores a deleted web app to a new or existing web app.

### [Restore-AzWebAppBackup](Restore-AzWebAppBackup.md)


### [Restore-AzWebAppSnapshot](Restore-AzWebAppSnapshot.md)
Restores a web app snapshot.

### [Set-AzAppServicePlan](Set-AzAppServicePlan.md)
Sets an Azure App Service plan.

### [Set-AzWebApp](Set-AzWebApp.md)
Modifies an Azure Web App.

### [Set-AzWebAppSlot](Set-AzWebAppSlot.md)
Modifies an Azure Web App slot.

### [Set-AzWebAppSlotConfigName](Set-AzWebAppSlotConfigName.md)
Set Web App Slot Config names

### [Start-AzWebApp](Start-AzWebApp.md)
Starts an Azure Web App.

### [Start-AzWebAppContinuousWebJob](Start-AzWebAppContinuousWebJob.md)
Start a continuous web job for an app.

### [Start-AzWebAppSlot](Start-AzWebAppSlot.md)
Starts an Azure Web App slot.

### [Start-AzWebAppSlotContinuousWebJob](Start-AzWebAppSlotContinuousWebJob.md)
Start a continuous web job for a deployment slot.

### [Start-AzWebAppSlotTriggeredWebJob](Start-AzWebAppSlotTriggeredWebJob.md)
Run a triggered web job for a deployment slot.

### [Start-AzWebAppTriggeredWebJob](Start-AzWebAppTriggeredWebJob.md)
Run a triggered web job for an app.

### [Stop-AzWebApp](Stop-AzWebApp.md)
Stops an Azure Web App.

### [Stop-AzWebAppContinuousWebJob](Stop-AzWebAppContinuousWebJob.md)
Stop a continuous web job for an app.

### [Stop-AzWebAppSlot](Stop-AzWebAppSlot.md)
Stops an Azure Web App slot.

### [Stop-AzWebAppSlotContinuousWebJob](Stop-AzWebAppSlotContinuousWebJob.md)
Stop a continuous web job for a deployment slot.

### [Switch-AzWebAppSlot](Switch-AzWebAppSlot.md)
Swap two slots within a Web App

### [Test-AzStaticWebAppCustomDomain](Test-AzStaticWebAppCustomDomain.md)
Description for Validates a particular custom domain can be added to a static site.

### [Unregister-AzStaticWebAppBuildUserProvidedFunctionApp](Unregister-AzStaticWebAppBuildUserProvidedFunctionApp.md)
Description for Detach the user provided function app from the static site build

### [Unregister-AzStaticWebAppUserProvidedFunctionApp](Unregister-AzStaticWebAppUserProvidedFunctionApp.md)
Description for Detach the user provided function app from the static site

### [Update-AzStaticWebApp](Update-AzStaticWebApp.md)
Description for Creates a new static site in an existing resource group, or updates an existing static site.

### [Update-AzStaticWebAppUser](Update-AzStaticWebAppUser.md)
Description for Updates a user entry with the listed roles

### [Update-AzWebAppAccessRestrictionConfig](Update-AzWebAppAccessRestrictionConfig.md)
Updates the inheritance of Main site Access Restiction config to SCM Site for an Azure Web App.

### [Update-AzWebAppTrafficRouting](Update-AzWebAppTrafficRouting.md)
Update a routing Rule to the Slot.


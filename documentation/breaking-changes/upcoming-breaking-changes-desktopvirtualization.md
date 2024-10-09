# Upcoming breaking changes in Azure PowerShell

## Az.DesktopVirtualization

The following cmdlets were affected this release:
- **Get-AzWvdApplication**
- **Get-AzWvdApplicationGroup**
- **Get-AzWvdDesktop**
- **Get-AzWvdHostPool**
- **Get-AzWvdHostPoolRegistrationInfo**
- **Get-AzWvdMsixPackage**
- **Get-AzWvdPrivateEndpointConnection**
- **Get-AzWvdRegistrationInfo**
- **Get-AzWvdScalingPlan**
- **Get-AzWvdScalingPlanPersonalSchedule**
- **Get-AzWvdScalingPlanPooledSchedule**
- **Get-AzWvdSessionHost**
- **Get-AzWvdUserSession**
- **Get-AzWvdWorkspace**
- **New-AzWvdApplication**
- **New-AzWvdApplicationGroup**
- **New-AzWvdHostPool**
- **New-AzWvdMsixPackage**
- **New-AzWvdRegistraionInfo**
- **New-AzWvdScalingPlan**
- **New-AzWvdScalingPlanPersonalSchedule**
- **New-AzWvdScalingPlanPooledSchedule**
- **New-AzWvdWorkspace**
- **Register-AzWvdApplicationGroup**
- **Send-AzWvdUserSessionMessage**
- **Unregister-AzWvdApplicationGroup**
- **Update-AzWvdApplication**
- **Update-AzWvdApplicationGroup**
- **Update-AzWvdDesktop**
- **Update-AzWvdHostpool**
- **Update-AzWvdMsixPackage**
- **Update-AzWvdScalingPlan**
- **Update-AzWvdScalingPlanPersonalSchedule**
- **Update-AzWvdScalingPlanPooledSchedule**
- **Update-AzWvdSessionHost**
- **Update-AzWvdWorkspace**
### The following enums have been converted to strings:
- CommandLineSetting
- ApplicationType
- ApplicationGroupType
- IdentityType
- HostPoolType
- LoadBalancerType
- PreferredAppGroupType
- AgentUpdateType
- IdentityType
- PersonalDesktopAssignmentType
- PublicNetworkAccess
- RegistrationTokenOperation
- SkuTier
- SsoSecretType
- ScalingHostPoolType
- ResourceIdentityType
- SessionHandlingOperation
- SetStartVmOnConnect
- StartupBehavior
- SessionHostLoadBalancingAlogrithm
- StopHostsWhen
- RemoteApplicationType
- SessionHostComponentUpdateType
- LoadBalancerType
- PersonalDesktopAssignmentType
- PreferredAppGroupType
- DaysOfWeek
### The following properties have changed from struct to string:
- SystemDataLastModifiedByType
- SystemDataCreatedByType
- SystemDataCreatedAt
- SystemDataLastModifiedAt
- SystemDataLastModifiedBy
- SystemDataCreatedBy
### Array replaced by List due to the generated tool (autorest.powershell) upgrading
- Details can be found [Breaking Changes in Generated Modules Due to AutoRest.PowerShell Upgrade from v3 to v4](https://github.com/Azure/azure-powershell/blob/main/documentation/breaking-changes/breaking-changes-in-generated-modules-due-to-codegen-tool-upgrade-from-v3-to-v4.md#list-replaces-array-in-generated-c-classes)

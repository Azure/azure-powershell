# Upcoming breaking changes in Az.DesktopVirtualization module

The following breaking changes are caused by upgrading the generation tool (autorest.powershell). The affected cmdlets are listed below:
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

## The breaking changes in details

### Use primitive types for enum instead of struct

Details can be found [here](https://learn.microsoft.com/powershell/azure/breaking-changes-generated-modules?#use-primitive-types-for-enum-instead-of-struct)

The following enums have been converted to strings:
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

The following properties have changed from struct to string:
- SystemDataLastModifiedByType
- SystemDataCreatedByType
- SystemDataCreatedAt
- SystemDataLastModifiedAt
- SystemDataLastModifiedBy
- SystemDataCreatedBy

### Array replaced by List

Details can be found [here](https://learn.microsoft.com/powershell/azure/breaking-changes-generated-modules?#list-replaces-array-in-generated-c-classes)

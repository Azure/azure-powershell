<!--
    Please leave this section at the top of the breaking change documentation.

    New breaking changes should go under the section titled "Upcoming Breaking Changes", and should adhere to the following format:

    # Upcoming Breaking Changes

    ## Release X.0.0 - January 2017

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    Note: the above section follows the template found in the link below: 

    https://github.com/Azure/azure-powershell/blob/dev/documentation/breaking-changes/breaking-change-template.md
-->

# Upcoming Breaking Changes of Az.DesktopVirtualization

    ## Release Az 13.0.0 - November 2024

    The following cmdlets were affected this release:

    **Get-AzWvdApplication**
    **Get-AzWvdApplicationGroup**
    **Get-AzWvdDesktop**
    **Get-AzWvdHostPool**
    **Get-AzWvdHostPoolRegistrationInfo**
    **Get-AzWvdMsixPackage**
    **Get-AzWvdPrivateEndpointConnection**
    **Get-AzWvdRegistrationInfo**
    **Get-AzWvdScalingPlan**
    **Get-AzWvdScalingPlanPersonalSchedule**
    **Get-AzWvdScalingPlanPooledSchedule**
    **Get-AzWvdSessionHost**
    **Get-AzWvdUserSession**
    **Get-AzWvdWorkspace**
    **New-AzWvdApplication**
    **New-AzWvdApplicationGroup**
    **New-AzWvdHostPool**
    **New-AzWvdMsixPackage**
    **New-AzWvdRegistraionInfo**
    **New-AzWvdScalingPlan**
    **New-AzWvdScalingPlanPersonalSchedule**
    **New-AzWvdScalingPlanPooledSchedule**
    **New-AzWvdWorkspace**
    **Register-AzWvdApplicationGroup**
    **Send-AzWvdUserSessionMessage**
    **Unregister-AzWvdApplicationGroup**
    **Update-AzWvdApplication**
    **Update-AzWvdApplicationGroup**
    **Update-AzWvdDesktop**
    **Update-AzWvdHostpool**
    **Update-AzWvdMsixPackage**
    **Update-AzWvdScalingPlan**
    **Update-AzWvdScalingPlanPersonalSchedule**
    **Update-AzWvdScalingPlanPooledSchedule**
    **Update-AzWvdSessionHost**
    **Update-AzWvdWorkspace**

    - The parameter set '__AllParameterSets' has been removed.
    - The following enums have been converted to strings:
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
    - The following properties have changed from struct to string:
        - SystemDataLastModifiedByType
        - SystemDataCreatedByType
        - SystemDataCreatedAt
        - SystemDataLastModifiedAt
        - SystemDataLastModifiedBy
        - SystemDataCreatedBy

    - Internal autorest versioning was upgraded for v3 to v4, details can be found here: https://github.com/Azure/azure-powershell/blob/main/documentation/breaking-changes/breaking-changes-in-generated-modules-due-to-codegen-tool-upgrade-from-v3-to-v4.md#list-replaces-array-in-generated-c-classes

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called
    New-AzWvdWorkspace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
     [-ApplicationGroupReference <String[]>] [-Description <String>] [-FriendlyName <String>]
     [-IdentityType <ResourceIdentityType>] [-Kind <String>] [-Location <String>] [-ManagedBy <String>]
     [-PlanName <String>] [-PlanProduct <String>] [-PlanPromotionCode <String>] [-PlanPublisher <String>]
     [-PlanVersion <String>] [-PublicNetworkAccess <PublicNetworkAccess>] [-SkuCapacity <Int32>]
     [-SkuFamily <String>] [-SkuName <String>] [-SkuSize <String>] [-SkuTier <SkuTier>] [-Tag <Hashtable>]
     [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]

    # New
    # Sample of how the cmdlet should now be called
    New-AzWvdWorkspace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
     [-ApplicationGroupReference <String[]>] [-Description <String>] [-FriendlyName <String>]
     [-IdentityType <String>] [-Kind <String>] [-Location <String>] [-ManagedBy <String>]
     [-PlanName <String>] [-PlanProduct <String>] [-PlanPromotionCode <String>] [-PlanPublisher <String>]
     [-PlanVersion <String>] [-PublicNetworkAccess <String>] [-SkuCapacity <Int32>]
     [-SkuFamily <String>] [-SkuName <String>] [-SkuSize <String>] [-SkuTier <String>] [-Tag <Hashtable>]
     [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
    ```
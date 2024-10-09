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

# Upcoming Breaking Changes

    ## Release Az 13.0.0 - November 2024

    The following cmdlets were affected this release:

    **All Cmdlets**
    - All cmdlets with SystemData properties have their property-type switched from struct to string.
    - All cmdlets using enums have switched from property-type enum to string.
    - All cmdlets using DaysOfWeek enum have switched from property-type DaysOfWeek to string.

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
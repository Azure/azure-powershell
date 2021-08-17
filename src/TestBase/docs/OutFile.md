#### Name :Get-AzTestBaseAccount

#### Syntax:

- List (Default)
```Powershell
Get-AzTestBaseAccount [-SubscriptionId <String[]>] [-GetDeleted] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

- Get
```Powershell
Get-AzTestBaseAccount -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- GetViaIdentity
```Powershell
Get-AzTestBaseAccount -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- List1
```Powershell
Get-AzTestBaseAccount -ResourceGroupName <String> [-SubscriptionId <String[]>] [-GetDeleted]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### Name :Get-AzTestBaseAccountFileUploadUrl

#### Syntax:

- GetExpanded (Default)
```Powershell
Get-AzTestBaseAccountFileUploadUrl -ResourceGroupName <String> -TestBaseAccountName <String>
 [-SubscriptionId <String[]>] [-BlobName <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

- Get
```Powershell
Get-AzTestBaseAccountFileUploadUrl -ResourceGroupName <String> -TestBaseAccountName <String>
 -Parameter <IGetFileUploadUrlParameters> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

- GetViaIdentity
```Powershell
Get-AzTestBaseAccountFileUploadUrl -InputObject <ITestBaseIdentity> -Parameter <IGetFileUploadUrlParameters>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

- GetViaIdentityExpanded
```Powershell
Get-AzTestBaseAccountFileUploadUrl -InputObject <ITestBaseIdentity> [-BlobName <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### Name :Get-AzTestBaseAnalysisResult

#### Syntax:

- Get (Default)
```Powershell
Get-AzTestBaseAnalysisResult -Name <AnalysisResultName> -PackageName <String> -ResourceGroupName <String>
 -TestBaseAccountName <String> -TestResultName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- GetViaIdentity
```Powershell
Get-AzTestBaseAnalysisResult -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

- List
```Powershell
Get-AzTestBaseAnalysisResult -PackageName <String> -ResourceGroupName <String> -TestBaseAccountName <String>
 -TestResultName <String> -AnalysisResultType <AnalysisResultType> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### Name :Get-AzTestBaseAvailableOS

#### Syntax:

- Get (Default)
```Powershell
Get-AzTestBaseAvailableOS -ResourceGroupName <String> -ResourceName <String> -TestBaseAccountName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- GetViaIdentity
```Powershell
Get-AzTestBaseAvailableOS -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- List
```Powershell
Get-AzTestBaseAvailableOS -ResourceGroupName <String> -TestBaseAccountName <String>
 -OSUpdateType <OSUpdateType> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### Name :Get-AzTestBaseCustomerEvent

#### Syntax:

- List (Default)
```Powershell
Get-AzTestBaseCustomerEvent -ResourceGroupName <String> -TestBaseAccountName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- Get
```Powershell
Get-AzTestBaseCustomerEvent -Name <String> -ResourceGroupName <String> -TestBaseAccountName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- GetViaIdentity
```Powershell
Get-AzTestBaseCustomerEvent -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### Name :Get-AzTestBaseEmailEvent

#### Syntax:

- List (Default)
```Powershell
Get-AzTestBaseEmailEvent -ResourceGroupName <String> -TestBaseAccountName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- Get
```Powershell
Get-AzTestBaseEmailEvent -ResourceGroupName <String> -ResourceName <String> -TestBaseAccountName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- GetViaIdentity
```Powershell
Get-AzTestBaseEmailEvent -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### Name :Get-AzTestBaseFavoriteProcess

#### Syntax:

- List (Default)
```Powershell
Get-AzTestBaseFavoriteProcess -PackageName <String> -ResourceGroupName <String> -TestBaseAccountName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- Get
```Powershell
Get-AzTestBaseFavoriteProcess -PackageName <String> -ResourceGroupName <String> -ResourceName <String>
 -TestBaseAccountName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- GetViaIdentity
```Powershell
Get-AzTestBaseFavoriteProcess -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

#### Name :Get-AzTestBaseFlightingRing

#### Syntax:

- List (Default)
```Powershell
Get-AzTestBaseFlightingRing -ResourceGroupName <String> -TestBaseAccountName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- Get
```Powershell
Get-AzTestBaseFlightingRing -ResourceGroupName <String> -ResourceName <String> -TestBaseAccountName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- GetViaIdentity
```Powershell
Get-AzTestBaseFlightingRing -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### Name :Get-AzTestBaseOSUpdate

#### Syntax:

- Get (Default)
```Powershell
Get-AzTestBaseOSUpdate -PackageName <String> -ResourceGroupName <String> -ResourceName <String>
 -TestBaseAccountName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- GetViaIdentity
```Powershell
Get-AzTestBaseOSUpdate -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- List
```Powershell
Get-AzTestBaseOSUpdate -PackageName <String> -ResourceGroupName <String> -TestBaseAccountName <String>
 -OSUpdateType <OSUpdateType> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### Name :Get-AzTestBasePackage

#### Syntax:

- List (Default)
```Powershell
Get-AzTestBasePackage -ResourceGroupName <String> -TestBaseAccountName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- Get
```Powershell
Get-AzTestBasePackage -Name <String> -ResourceGroupName <String> -TestBaseAccountName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- GetViaIdentity
```Powershell
Get-AzTestBasePackage -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### Name :Get-AzTestBasePackageDownloadUrl

#### Syntax:

- Get (Default)
```Powershell
Get-AzTestBasePackageDownloadUrl -PackageName <String> -ResourceGroupName <String>
 -TestBaseAccountName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

- GetViaIdentity
```Powershell
Get-AzTestBasePackageDownloadUrl -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

#### Name :Get-AzTestBaseSku

#### Syntax:

```Powershell
Get-AzTestBaseSku [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### Name :Get-AzTestBaseTestResult

#### Syntax:

- Get (Default)
```Powershell
Get-AzTestBaseTestResult -Name <String> -PackageName <String> -ResourceGroupName <String>
 -TestBaseAccountName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- GetViaIdentity
```Powershell
Get-AzTestBaseTestResult -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- List
```Powershell
Get-AzTestBaseTestResult -PackageName <String> -ResourceGroupName <String> -TestBaseAccountName <String>
 -OSUpdateType <OSUpdateType> [-SubscriptionId <String[]>] [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

#### Name :Get-AzTestBaseTestResultDownloadUrl

#### Syntax:

- Get (Default)
```Powershell
Get-AzTestBaseTestResultDownloadUrl -PackageName <String> -ResourceGroupName <String>
 -TestBaseAccountName <String> -TestResultName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

- GetViaIdentity
```Powershell
Get-AzTestBaseTestResultDownloadUrl -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

#### Name :Get-AzTestBaseTestResultVideoDownloadUrl

#### Syntax:

- Get (Default)
```Powershell
Get-AzTestBaseTestResultVideoDownloadUrl -PackageName <String> -ResourceGroupName <String>
 -TestBaseAccountName <String> -TestResultName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

- GetViaIdentity
```Powershell
Get-AzTestBaseTestResultVideoDownloadUrl -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### Name :Get-AzTestBaseTestSummary

#### Syntax:

- List (Default)
```Powershell
Get-AzTestBaseTestSummary -ResourceGroupName <String> -TestBaseAccountName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- Get
```Powershell
Get-AzTestBaseTestSummary -Name <String> -ResourceGroupName <String> -TestBaseAccountName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- GetViaIdentity
```Powershell
Get-AzTestBaseTestSummary -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### Name :Get-AzTestBaseTestType

#### Syntax:

- List (Default)
```Powershell
Get-AzTestBaseTestType -ResourceGroupName <String> -TestBaseAccountName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- Get
```Powershell
Get-AzTestBaseTestType -ResourceGroupName <String> -ResourceName <String> -TestBaseAccountName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- GetViaIdentity
```Powershell
Get-AzTestBaseTestType -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### Name :Get-AzTestBaseUsage

#### Syntax:

```Powershell
Get-AzTestBaseUsage -ResourceGroupName <String> -TestBaseAccountName <String> [-SubscriptionId <String[]>]
 [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### Name :Invoke-AzTestBaseOffboardTestBaseAccount

#### Syntax:

- Offboard (Default)
```Powershell
Invoke-AzTestBaseOffboardTestBaseAccount -ResourceGroupName <String> -TestBaseAccountName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

- OffboardViaIdentity
```Powershell
Invoke-AzTestBaseOffboardTestBaseAccount -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### Name :New-AzTestBaseAccount

#### Syntax:

```Powershell
New-AzTestBaseAccount -Name <String> -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-Restore] [-SkuLocation <String[]>] [-SkuName <String>] [-SkuResourceType <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### Name :New-AzTestBaseCustomerEvent

#### Syntax:

```Powershell
New-AzTestBaseCustomerEvent -Name <String> -ResourceGroupName <String> -TestBaseAccountName <String>
 [-SubscriptionId <String>] [-EventName <String>] [-Receiver <INotificationEventReceiver[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### Name :New-AzTestBaseFavoriteProcess

#### Syntax:

```Powershell
New-AzTestBaseFavoriteProcess -PackageName <String> -ResourceGroupName <String> -ResourceName <String>
 -TestBaseAccountName <String> [-SubscriptionId <String>] [-ActualProcessName <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### Name :New-AzTestBasePackage

#### Syntax:

```Powershell
New-AzTestBasePackage -Name <String> -ResourceGroupName <String> -TestBaseAccountName <String>
 -Location <String> [-SubscriptionId <String>] [-ApplicationName <String>] [-BlobPath <String>]
 [-FlightingRing <String>] [-Tag <Hashtable>] [-TargetOSList <ITargetOSInfo[]>] [-Test <ITest[]>]
 [-Version <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### Name :Remove-AzTestBaseAccount

#### Syntax:

- Delete (Default)
```Powershell
Remove-AzTestBaseAccount -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

- DeleteViaIdentity
```Powershell
Remove-AzTestBaseAccount -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### Name :Remove-AzTestBaseCustomerEvent

#### Syntax:

- Delete (Default)
```Powershell
Remove-AzTestBaseCustomerEvent -Name <String> -ResourceGroupName <String> -TestBaseAccountName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

- DeleteViaIdentity
```Powershell
Remove-AzTestBaseCustomerEvent -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### Name :Remove-AzTestBaseFavoriteProcess

#### Syntax:

- Delete (Default)
```Powershell
Remove-AzTestBaseFavoriteProcess -PackageName <String> -ResourceGroupName <String> -ResourceName <String>
 -TestBaseAccountName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

- DeleteViaIdentity
```Powershell
Remove-AzTestBaseFavoriteProcess -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### Name :Remove-AzTestBasePackage

#### Syntax:

- Delete (Default)
```Powershell
Remove-AzTestBasePackage -Name <String> -ResourceGroupName <String> -TestBaseAccountName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

- DeleteViaIdentity
```Powershell
Remove-AzTestBasePackage -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### Name :Remove-AzTestBasePackageHard

#### Syntax:

- Delete (Default)
```Powershell
Remove-AzTestBasePackageHard -PackageName <String> -ResourceGroupName <String> -TestBaseAccountName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

- DeleteViaIdentity
```Powershell
Remove-AzTestBasePackageHard -InputObject <ITestBaseIdentity> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### Name :Test-AzTestBaseAccountPackageNameAvailability

#### Syntax:

- CheckExpanded (Default)
```Powershell
Test-AzTestBaseAccountPackageNameAvailability -ResourceGroupName <String> -TestBaseAccountName <String>
 -ApplicationName <String> -Name <String> -Type <String> -Version <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

- Check
```Powershell
Test-AzTestBaseAccountPackageNameAvailability -ResourceGroupName <String> -TestBaseAccountName <String>
 -Parameter <IPackageCheckNameAvailabilityParameters> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

- CheckViaIdentity
```Powershell
Test-AzTestBaseAccountPackageNameAvailability -InputObject <ITestBaseIdentity>
 -Parameter <IPackageCheckNameAvailabilityParameters> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

- CheckViaIdentityExpanded
```Powershell
Test-AzTestBaseAccountPackageNameAvailability -InputObject <ITestBaseIdentity> -ApplicationName <String>
 -Name <String> -Type <String> -Version <String> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

#### Name :Update-AzTestBaseAccount

#### Syntax:

- UpdateExpanded (Default)
```Powershell
Update-AzTestBaseAccount -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-SkuLocation <String[]>] [-SkuName <String>] [-SkuResourceType <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

- UpdateViaIdentityExpanded
```Powershell
Update-AzTestBaseAccount -InputObject <ITestBaseIdentity> [-SkuLocation <String[]>] [-SkuName <String>]
 [-SkuResourceType <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

#### Name :Update-AzTestBasePackage

#### Syntax:

- UpdateExpanded (Default)
```Powershell
Update-AzTestBasePackage -Name <String> -ResourceGroupName <String> -TestBaseAccountName <String>
 [-SubscriptionId <String>] [-BlobPath <String>] [-FlightingRing <String>] [-IsEnabled] [-Tag <Hashtable>]
 [-TargetOSList <ITargetOSInfo[]>] [-Test <ITest[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

- UpdateViaIdentityExpanded
```Powershell
Update-AzTestBasePackage -InputObject <ITestBaseIdentity> [-BlobPath <String>] [-FlightingRing <String>]
 [-IsEnabled] [-Tag <Hashtable>] [-TargetOSList <ITargetOSInfo[]>] [-Test <ITest[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```



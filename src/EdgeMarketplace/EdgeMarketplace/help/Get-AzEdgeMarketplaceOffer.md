---
external help file: Az.EdgeMarketplace-help.xml
Module Name: Az.EdgeMarketplace
online version: https://learn.microsoft.com/powershell/module/az.edgemarketplace/get-azedgemarketplaceoffer
schema: 2.0.0
---

# Get-AzEdgeMarketplaceOffer

## SYNOPSIS
Get a Offer

## SYNTAX

### List (Default)
```
Get-AzEdgeMarketplaceOffer -ResourceUri <String> [-Filter <String>] [-Maxpagesize <Int32>] [-Skip <Int32>]
 [-SkipToken <String>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzEdgeMarketplaceOffer -Id <String> -ResourceUri <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzEdgeMarketplaceOffer -InputObject <IEdgeMarketplaceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Offer

## EXAMPLES

### Example 1: List all offers under the given resource URI.
```powershell
Get-AzEdgeMarketplaceOffer -ResourceUri /subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation
```

```output
Content                      : {
                                 "offerPublisher": {
                                   "publisherId": "microsoftwindowsserver",
                                   "publisherDisplayName": "Microsoft"
                                 },
                                 "iconFileUris": {
                                   "small": "https://store-images.s-microsoft.com/image/apps.38260.91bddb44-7584-4c5b-993c-af2186e9addd.209044b8-3f3d-4c05-950c-a3
                               d8aa3a4cff.69731a5c-7576-4805-a9c3-d983471152e4",
                                   "medium": "https://store-images.s-microsoft.com/image/apps.42195.91bddb44-7584-4c5b-993c-af2186e9addd.209044b8-3f3d-4c05-950c-a
                               3d8aa3a4cff.7a7dab03-8089-41bf-b53f-db78c1b29dbb",
                                   "wide": "https://store-images.s-microsoft.com/image/apps.29381.91bddb44-7584-4c5b-993c-af2186e9addd.209044b8-3f3d-4c05-950c-a3d
                               8aa3a4cff.2e5f8945-20fd-41a7-8aa6-9e9e631ef68b",
                                   "large": "https://store-images.s-microsoft.com/image/apps.11142.91bddb44-7584-4c5b-993c-af2186e9addd.209044b8-3f3d-4c05-950c-a3
                               d8aa3a4cff.b86f7502-02d4-405e-b186-86af8bb64418"
                                 },
                                 "termsAndConditions": {
                                   "legalTermsUri": "https://go.microsoft.com/fwlink/?linkid=2014360",
                                   "legalTermsType": "None",
                                   "privacyPolicyUri": "https://go.microsoft.com/fwlink/?LinkId=521839"
                                 },
                                 "displayName": "Windows Server",
                                 "summary": "Windows Server Virtual Machine Images",
                                 "longSummary": "Windows Server Virtual Machine Images",
                                 "description": "\u003cp\u003eWindows Server is the operating system that bridges on-premises environments with Azure services ena
                               bling hybrid scenarios and maximizing existing investments, including:\u003cul\u003e\u003cli\u003eThe latest is security innovation
                                including Secured-core to minimize risk from firmware vulnerabilities and advanced malware.\u003c/li\u003e\u003cli\u003eUnique hyb
                               rid capabilities with Azure to extend your datacenter and maximize investments.\u003c/li\u003e\u003cli\u003eFile server security an
                               d performance increased with SMB AES-256 encryption and SMB on-the-fly compression.\u003c/li\u003e\u003cli\u003eAzure Edition image
                               s with additional functionality optimized to run in Azure.\u003c/li\u003e\u003cli\u003eImprovements to Windows container runtime su
                               ch as cross-version compatibility and containerization tools for .NET, ASP.NET and IIS applications.\u003c/li\u003e\u003c/ul\u003e\
                               u003c/p\u003e\u003cp\u003eAvailable Images\u003c/p\u003e\u003cp\u003e\u003cb\u003eWindows Server 2022\u003c/b\u003e is the previous
                                Long-Term Servicing Channel (LTSC) release with five years of mainstream support + five years of extended support. Choose the imag
                               e that is right for your application needs.\u003cul\u003e\u003cli\u003eServer with Desktop Experience includes all roles and a grap
                               hical user interface (GUI).\u003c/li\u003e\u003cli\u003e\u003ca href=\u0027https://docs.microsoft.com/en-us/windows-server/get-star
                               ted/getting-started-with-server-core\u0027\u003eServer Core\u003c/a\u003e omits the GUI for a smaller OS footprint.\u003c/li\u003e\
                               u003cli\u003eAzure Edition with Desktop Experience- includes additional new functionality such as Hotpatch, SMB over QUIC, extended
                                network for Azure, and is optimized to run in Azure.\u003c/li\u003e\u003cli\u003eAzure Edition Core - includes additional new func
                               tionality such as Hotpatch, SMB over QUIC, extended network for Azure, and is optimized to run in Azure.\u003c/li\u003e\u003c/ul\u0
                               03e\u003c/p\u003e\u003cp\u003eTerms of use\u003c/p\u003e\u003cp\u003eYour use of the Windows Server images from Azure Marketplace V
                               irtual Machine Gallery are provided to you for use with virtual machine instances under your Azure subscription which are governed
                               by the \u003ca href=\u0027https://go.microsoft.com/fwlink/?linkid=2014360\u0027\u003eOnline Services Terms\u003c/a\u003e. Windows S
                               erver Azure edition can only be used on Azure. All Server images may be used under the \u003ca href=\u0027https://docs.microsoft.co
                               m/en-us/azure/virtual-machines/windows/hybrid-use-benefit-licensing\u0027\u003eAzure Hybrid Benefit for Windows Server\u003c/a\u003
                               e.\u003c/p\u003e\u003cp\u003eLearn more\u003c/p\u003e\u003ca href=\u0027https://docs.microsoft.com/en-us/azure/virtual-machines/\u0
                               027\u003eWindows Server Virtual Machine Documentation\u003c/a\u003e\u003cbr\u003e\u003ca href=\u0027https://docs.microsoft.com/en-u
                               s/windows-server/\u0027\u003eWindows Server Documentation\u003c/a\u003e\u003cbr\u003e\u003ca href=\u0027https://aka.ms/server-whats
                               new\u0027\u003eWhat\u0027s New in Windows Server\u003c/a\u003e",
                                 "offerId": "windowsserver",
                                 "offerType": "VirtualMachine",
                                 "popularity": 1,
                                 "availability": "Preview",
                                 "releaseType": "Preview",
                                 "categoryIds": [ "operating-systems", "compute", "virtualMachine", "virtualMachine-Arm", "microsoft-azure-corevm", "Hidden_Gen1",
                                "Hidden_Gen2" ],
                                 "operatingSystems": [ "windows.others", "windows.windowsserver2019", "windows.windowsserver2016", "windows.windowsserver2022" ]
                               }
ContentUrl                   :
ContentVersion               : 951efed5-6128-4b95-862b-431e98958202
Id                           : /subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperati
                               ons/test-automation/providers/Microsoft.EdgeMarketPlace/offers/microsoftwindowsserver:windowsserver
MarketplaceSku               : {{
                                 "operatingSystem": {
                                   "family": "Windows",
                                   "type": "Windows Server 2019",
                                   "name": ""
                                 },
                                 "catalogPlanId": "microsoft.windowsserver2019datacenter-arm",
                                 "marketplaceSkuId": "2019-datacenter-ARM",
                                 "displayName": "Windows Server 2019 Datacenter",
                                 "generation": "1",
                                 "displayRank": 13,
                                 "marketplaceSkuVersions": [
                                   {
                                     "name": "17763.8276.260109",
                                     "minimumDownloadSizeInMb": 11831,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.8146.251205",
                                     "minimumDownloadSizeInMb": 11751,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.8027.251112",
                                     "minimumDownloadSizeInMb": 11867,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7922.251021",
                                     "minimumDownloadSizeInMb": 11907,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7919.251009",
                                     "minimumDownloadSizeInMb": 11919,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7792.250903",
                                     "minimumDownloadSizeInMb": 11735,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7678.250808",
                                     "minimumDownloadSizeInMb": 12023,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7558.250705",
                                     "minimumDownloadSizeInMb": 11927,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7434.250605",
                                     "minimumDownloadSizeInMb": 11735,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7322.250524",
                                     "minimumDownloadSizeInMb": 11731,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7314.250509",
                                     "minimumDownloadSizeInMb": 11783,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7240.250409",
                                     "minimumDownloadSizeInMb": 11783,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7009.250306",
                                     "minimumDownloadSizeInMb": 11507,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6893.250210",
                                     "minimumDownloadSizeInMb": 11575,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6775.250109",
                                     "minimumDownloadSizeInMb": 11639,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6659.241205",
                                     "minimumDownloadSizeInMb": 11119,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6532.241101",
                                     "minimumDownloadSizeInMb": 11499,
                                     "launchType": "Unknown"
                                   }
                                 ]
                               }, {
                                 "operatingSystem": {
                                   "family": "Windows",
                                   "type": "Windows Server 2019",
                                   "name": ""
                                 },
                                 "catalogPlanId": "microsoft.windowsserver2019datacenter2019-datacenter-gensecond",
                                 "marketplaceSkuId": "2019-datacenter-gensecond",
                                 "displayName": "Windows Server 2019 Datacenter",
                                 "generation": "2",
                                 "displayRank": 13,
                                 "marketplaceSkuVersions": [
                                   {
                                     "name": "17763.8276.260109",
                                     "minimumDownloadSizeInMb": 11879,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.8146.251205",
                                     "minimumDownloadSizeInMb": 11883,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.8027.251112",
                                     "minimumDownloadSizeInMb": 11963,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7922.251021",
                                     "minimumDownloadSizeInMb": 12071,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7919.251009",
                                     "minimumDownloadSizeInMb": 11807,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7792.250903",
                                     "minimumDownloadSizeInMb": 11771,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7678.250808",
                                     "minimumDownloadSizeInMb": 11915,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7558.250705",
                                     "minimumDownloadSizeInMb": 12063,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7434.250605",
                                     "minimumDownloadSizeInMb": 11935,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7322.250524",
                                     "minimumDownloadSizeInMb": 11835,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7314.250509",
                                     "minimumDownloadSizeInMb": 12067,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7240.250409",
                                     "minimumDownloadSizeInMb": 11343,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7009.250306",
                                     "minimumDownloadSizeInMb": 11239,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6893.250210",
                                     "minimumDownloadSizeInMb": 11719,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6775.250109",
                                     "minimumDownloadSizeInMb": 11459,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6659.241205",
                                     "minimumDownloadSizeInMb": 11163,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6532.241101",
                                     "minimumDownloadSizeInMb": 11487,
                                     "launchType": "Unknown"
                                   }
                                 ]
                               }, {
                                 "operatingSystem": {
                                   "family": "Windows",
                                   "type": "Windows Server 2022 Datacenter: Azure Edition",
                                   "name": ""
                                 },
                                 "catalogPlanId": "microsoftwindowsserver.windowsserver2022-datacenter-azure-edition-hotpatch",
                                 "marketplaceSkuId": "2022-datacenter-azure-edition-hotpatch",
                                 "displayName": "Windows Server 2022 Datacenter: Azure Edition Hotpatch",
                                 "generation": "2",
                                 "displayRank": 1,
                                 "marketplaceSkuVersions": [
                                   {
                                     "name": "20348.4648.260108",
                                     "minimumDownloadSizeInMb": 12171,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4529.251206",
                                     "minimumDownloadSizeInMb": 12143,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4346.251112",
                                     "minimumDownloadSizeInMb": 12035,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4297.251024",
                                     "minimumDownloadSizeInMb": 12055,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4294.251009",
                                     "minimumDownloadSizeInMb": 12015,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3932.250903",
                                     "minimumDownloadSizeInMb": 12203,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3932.250808",
                                     "minimumDownloadSizeInMb": 12191,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3932.250706",
                                     "minimumDownloadSizeInMb": 11943,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3562.250605",
                                     "minimumDownloadSizeInMb": 12131,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3562.250509",
                                     "minimumDownloadSizeInMb": 12083,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3562.250404",
                                     "minimumDownloadSizeInMb": 11855,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3561.250409",
                                     "minimumDownloadSizeInMb": 11895,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3091.250305",
                                     "minimumDownloadSizeInMb": 11975,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3091.250210",
                                     "minimumDownloadSizeInMb": 12011,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3091.250112",
                                     "minimumDownloadSizeInMb": 11839,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.2762.241204",
                                     "minimumDownloadSizeInMb": 11959,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.2762.241102",
                                     "minimumDownloadSizeInMb": 11707,
                                     "launchType": "Unknown"
                                   }
                                 ]
                               }, {
                                 "operatingSystem": {
                                   "family": "Windows",
                                   "type": "Windows Server 2022 Datacenter: Azure Edition",
                                   "name": ""
                                 },
                                 "catalogPlanId": "microsoftwindowsserver.windowsserver2022-datacenter-azure-edition-core",
                                 "marketplaceSkuId": "2022-datacenter-azure-edition-core",
                                 "displayName": "Windows Server 2022 Datacenter: Azure Edition Core",
                                 "generation": "2",
                                 "displayRank": 3,
                                 "marketplaceSkuVersions": [
                                   {
                                     "name": "20348.4648.260108",
                                     "minimumDownloadSizeInMb": 8087,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4529.251206",
                                     "minimumDownloadSizeInMb": 8195,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4346.251112",
                                     "minimumDownloadSizeInMb": 8099,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4297.251024",
                                     "minimumDownloadSizeInMb": 8043,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4294.251009",
                                     "minimumDownloadSizeInMb": 8107,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3932.250903",
                                     "minimumDownloadSizeInMb": 8287,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3932.250808",
                                     "minimumDownloadSizeInMb": 8195,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3932.250706",
                                     "minimumDownloadSizeInMb": 7995,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3562.250605",
                                     "minimumDownloadSizeInMb": 8091,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3562.250509",
                                     "minimumDownloadSizeInMb": 8115,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3562.250404",
                                     "minimumDownloadSizeInMb": 7547,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3561.250409",
                                     "minimumDownloadSizeInMb": 7619,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3091.250305",
                                     "minimumDownloadSizeInMb": 7783,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3091.250210",
                                     "minimumDownloadSizeInMb": 7703,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3091.250112",
                                     "minimumDownloadSizeInMb": 7635,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.2762.241204",
                                     "minimumDownloadSizeInMb": 7787,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.2762.241102",
                                     "minimumDownloadSizeInMb": 7675,
                                     "launchType": "Unknown"
                                   }
                                 ]
                               }}
Name                         : microsoftwindowsserver:windowsserver
ProvisioningState            : Succeeded
ResourceGroupName            : bvt-test-automation
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.EdgeMarketPlace/offers
```

List all offers under the given resource URI.

### Example 2: Get a specific offer by its offerId under the given resource URI.
```powershell
Get-AzEdgeMarketplaceOffer -ResourceUri /subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation -Id microsoftwindowsserver:windowsserver
```

```output
Content                      : {
                                 "offerPublisher": {
                                   "publisherId": "microsoftwindowsserver",
                                   "publisherDisplayName": "Microsoft"
                                 },
                                 "iconFileUris": {
                                   "small": "https://store-images.s-microsoft.com/image/apps.38260.91bddb44-7584-4c5b-993c-af2186e9addd.209044b8-3f3d-4c05-950c-a3
                               d8aa3a4cff.69731a5c-7576-4805-a9c3-d983471152e4",
                                   "medium": "https://store-images.s-microsoft.com/image/apps.42195.91bddb44-7584-4c5b-993c-af2186e9addd.209044b8-3f3d-4c05-950c-a
                               3d8aa3a4cff.7a7dab03-8089-41bf-b53f-db78c1b29dbb",
                                   "wide": "https://store-images.s-microsoft.com/image/apps.29381.91bddb44-7584-4c5b-993c-af2186e9addd.209044b8-3f3d-4c05-950c-a3d
                               8aa3a4cff.2e5f8945-20fd-41a7-8aa6-9e9e631ef68b",
                                   "large": "https://store-images.s-microsoft.com/image/apps.11142.91bddb44-7584-4c5b-993c-af2186e9addd.209044b8-3f3d-4c05-950c-a3
                               d8aa3a4cff.b86f7502-02d4-405e-b186-86af8bb64418"
                                 },
                                 "termsAndConditions": {
                                   "legalTermsUri": "https://go.microsoft.com/fwlink/?linkid=2014360",
                                   "legalTermsType": "None",
                                   "privacyPolicyUri": "https://go.microsoft.com/fwlink/?LinkId=521839"
                                 },
                                 "displayName": "Windows Server",
                                 "summary": "Windows Server Virtual Machine Images",
                                 "longSummary": "Windows Server Virtual Machine Images",
                                 "description": "\u003cp\u003eWindows Server is the operating system that bridges on-premises environments with Azure services ena
                               bling hybrid scenarios and maximizing existing investments, including:\u003cul\u003e\u003cli\u003eThe latest is security innovation
                                including Secured-core to minimize risk from firmware vulnerabilities and advanced malware.\u003c/li\u003e\u003cli\u003eUnique hyb
                               rid capabilities with Azure to extend your datacenter and maximize investments.\u003c/li\u003e\u003cli\u003eFile server security an
                               d performance increased with SMB AES-256 encryption and SMB on-the-fly compression.\u003c/li\u003e\u003cli\u003eAzure Edition image
                               s with additional functionality optimized to run in Azure.\u003c/li\u003e\u003cli\u003eImprovements to Windows container runtime su
                               ch as cross-version compatibility and containerization tools for .NET, ASP.NET and IIS applications.\u003c/li\u003e\u003c/ul\u003e\
                               u003c/p\u003e\u003cp\u003eAvailable Images\u003c/p\u003e\u003cp\u003e\u003cb\u003eWindows Server 2022\u003c/b\u003e is the previous
                                Long-Term Servicing Channel (LTSC) release with five years of mainstream support + five years of extended support. Choose the imag
                               e that is right for your application needs.\u003cul\u003e\u003cli\u003eServer with Desktop Experience includes all roles and a grap
                               hical user interface (GUI).\u003c/li\u003e\u003cli\u003e\u003ca href=\u0027https://docs.microsoft.com/en-us/windows-server/get-star
                               ted/getting-started-with-server-core\u0027\u003eServer Core\u003c/a\u003e omits the GUI for a smaller OS footprint.\u003c/li\u003e\
                               u003cli\u003eAzure Edition with Desktop Experience- includes additional new functionality such as Hotpatch, SMB over QUIC, extended
                                network for Azure, and is optimized to run in Azure.\u003c/li\u003e\u003cli\u003eAzure Edition Core - includes additional new func
                               tionality such as Hotpatch, SMB over QUIC, extended network for Azure, and is optimized to run in Azure.\u003c/li\u003e\u003c/ul\u0
                               03e\u003c/p\u003e\u003cp\u003eTerms of use\u003c/p\u003e\u003cp\u003eYour use of the Windows Server images from Azure Marketplace V
                               irtual Machine Gallery are provided to you for use with virtual machine instances under your Azure subscription which are governed
                               by the \u003ca href=\u0027https://go.microsoft.com/fwlink/?linkid=2014360\u0027\u003eOnline Services Terms\u003c/a\u003e. Windows S
                               erver Azure edition can only be used on Azure. All Server images may be used under the \u003ca href=\u0027https://docs.microsoft.co
                               m/en-us/azure/virtual-machines/windows/hybrid-use-benefit-licensing\u0027\u003eAzure Hybrid Benefit for Windows Server\u003c/a\u003
                               e.\u003c/p\u003e\u003cp\u003eLearn more\u003c/p\u003e\u003ca href=\u0027https://docs.microsoft.com/en-us/azure/virtual-machines/\u0
                               027\u003eWindows Server Virtual Machine Documentation\u003c/a\u003e\u003cbr\u003e\u003ca href=\u0027https://docs.microsoft.com/en-u
                               s/windows-server/\u0027\u003eWindows Server Documentation\u003c/a\u003e\u003cbr\u003e\u003ca href=\u0027https://aka.ms/server-whats
                               new\u0027\u003eWhat\u0027s New in Windows Server\u003c/a\u003e",
                                 "offerId": "windowsserver",
                                 "offerType": "VirtualMachine",
                                 "popularity": 1,
                                 "availability": "Preview",
                                 "releaseType": "Preview",
                                 "categoryIds": [ "operating-systems", "compute", "virtualMachine", "virtualMachine-Arm", "microsoft-azure-corevm", "Hidden_Gen1",
                                "Hidden_Gen2" ],
                                 "operatingSystems": [ "windows.others", "windows.windowsserver2019", "windows.windowsserver2016", "windows.windowsserver2022" ]
                               }
ContentUrl                   :
ContentVersion               : 951efed5-6128-4b95-862b-431e98958202
Id                           : /subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperati
                               ons/test-automation/providers/Microsoft.EdgeMarketPlace/offers/microsoftwindowsserver:windowsserver
MarketplaceSku               : {{
                                 "operatingSystem": {
                                   "family": "Windows",
                                   "type": "Windows Server 2019",
                                   "name": ""
                                 },
                                 "catalogPlanId": "microsoft.windowsserver2019datacenter-arm",
                                 "marketplaceSkuId": "2019-datacenter-ARM",
                                 "displayName": "Windows Server 2019 Datacenter",
                                 "generation": "1",
                                 "displayRank": 13,
                                 "marketplaceSkuVersions": [
                                   {
                                     "name": "17763.8276.260109",
                                     "minimumDownloadSizeInMb": 11831,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.8146.251205",
                                     "minimumDownloadSizeInMb": 11751,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.8027.251112",
                                     "minimumDownloadSizeInMb": 11867,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7922.251021",
                                     "minimumDownloadSizeInMb": 11907,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7919.251009",
                                     "minimumDownloadSizeInMb": 11919,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7792.250903",
                                     "minimumDownloadSizeInMb": 11735,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7678.250808",
                                     "minimumDownloadSizeInMb": 12023,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7558.250705",
                                     "minimumDownloadSizeInMb": 11927,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7434.250605",
                                     "minimumDownloadSizeInMb": 11735,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7322.250524",
                                     "minimumDownloadSizeInMb": 11731,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7314.250509",
                                     "minimumDownloadSizeInMb": 11783,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7240.250409",
                                     "minimumDownloadSizeInMb": 11783,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7009.250306",
                                     "minimumDownloadSizeInMb": 11507,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6893.250210",
                                     "minimumDownloadSizeInMb": 11575,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6775.250109",
                                     "minimumDownloadSizeInMb": 11639,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6659.241205",
                                     "minimumDownloadSizeInMb": 11119,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6532.241101",
                                     "minimumDownloadSizeInMb": 11499,
                                     "launchType": "Unknown"
                                   }
                                 ]
                               }, {
                                 "operatingSystem": {
                                   "family": "Windows",
                                   "type": "Windows Server 2019",
                                   "name": ""
                                 },
                                 "catalogPlanId": "microsoft.windowsserver2019datacenter2019-datacenter-gensecond",
                                 "marketplaceSkuId": "2019-datacenter-gensecond",
                                 "displayName": "Windows Server 2019 Datacenter",
                                 "generation": "2",
                                 "displayRank": 13,
                                 "marketplaceSkuVersions": [
                                   {
                                     "name": "17763.8276.260109",
                                     "minimumDownloadSizeInMb": 11879,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.8146.251205",
                                     "minimumDownloadSizeInMb": 11883,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.8027.251112",
                                     "minimumDownloadSizeInMb": 11963,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7922.251021",
                                     "minimumDownloadSizeInMb": 12071,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7919.251009",
                                     "minimumDownloadSizeInMb": 11807,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7792.250903",
                                     "minimumDownloadSizeInMb": 11771,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7678.250808",
                                     "minimumDownloadSizeInMb": 11915,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7558.250705",
                                     "minimumDownloadSizeInMb": 12063,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7434.250605",
                                     "minimumDownloadSizeInMb": 11935,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7322.250524",
                                     "minimumDownloadSizeInMb": 11835,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7314.250509",
                                     "minimumDownloadSizeInMb": 12067,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7240.250409",
                                     "minimumDownloadSizeInMb": 11343,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7009.250306",
                                     "minimumDownloadSizeInMb": 11239,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6893.250210",
                                     "minimumDownloadSizeInMb": 11719,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6775.250109",
                                     "minimumDownloadSizeInMb": 11459,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6659.241205",
                                     "minimumDownloadSizeInMb": 11163,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6532.241101",
                                     "minimumDownloadSizeInMb": 11487,
                                     "launchType": "Unknown"
                                   }
                                 ]
                               }, {
                                 "operatingSystem": {
                                   "family": "Windows",
                                   "type": "Windows Server 2022 Datacenter: Azure Edition",
                                   "name": ""
                                 },
                                 "catalogPlanId": "microsoftwindowsserver.windowsserver2022-datacenter-azure-edition-hotpatch",
                                 "marketplaceSkuId": "2022-datacenter-azure-edition-hotpatch",
                                 "displayName": "Windows Server 2022 Datacenter: Azure Edition Hotpatch",
                                 "generation": "2",
                                 "displayRank": 1,
                                 "marketplaceSkuVersions": [
                                   {
                                     "name": "20348.4648.260108",
                                     "minimumDownloadSizeInMb": 12171,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4529.251206",
                                     "minimumDownloadSizeInMb": 12143,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4346.251112",
                                     "minimumDownloadSizeInMb": 12035,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4297.251024",
                                     "minimumDownloadSizeInMb": 12055,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4294.251009",
                                     "minimumDownloadSizeInMb": 12015,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3932.250903",
                                     "minimumDownloadSizeInMb": 12203,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3932.250808",
                                     "minimumDownloadSizeInMb": 12191,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3932.250706",
                                     "minimumDownloadSizeInMb": 11943,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3562.250605",
                                     "minimumDownloadSizeInMb": 12131,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3562.250509",
                                     "minimumDownloadSizeInMb": 12083,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3562.250404",
                                     "minimumDownloadSizeInMb": 11855,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3561.250409",
                                     "minimumDownloadSizeInMb": 11895,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3091.250305",
                                     "minimumDownloadSizeInMb": 11975,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3091.250210",
                                     "minimumDownloadSizeInMb": 12011,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3091.250112",
                                     "minimumDownloadSizeInMb": 11839,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.2762.241204",
                                     "minimumDownloadSizeInMb": 11959,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.2762.241102",
                                     "minimumDownloadSizeInMb": 11707,
                                     "launchType": "Unknown"
                                   }
                                 ]
                               }, {
                                 "operatingSystem": {
                                   "family": "Windows",
                                   "type": "Windows Server 2022 Datacenter: Azure Edition",
                                   "name": ""
                                 },
                                 "catalogPlanId": "microsoftwindowsserver.windowsserver2022-datacenter-azure-edition-core",
                                 "marketplaceSkuId": "2022-datacenter-azure-edition-core",
                                 "displayName": "Windows Server 2022 Datacenter: Azure Edition Core",
                                 "generation": "2",
                                 "displayRank": 3,
                                 "marketplaceSkuVersions": [
                                   {
                                     "name": "20348.4648.260108",
                                     "minimumDownloadSizeInMb": 8087,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4529.251206",
                                     "minimumDownloadSizeInMb": 8195,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4346.251112",
                                     "minimumDownloadSizeInMb": 8099,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4297.251024",
                                     "minimumDownloadSizeInMb": 8043,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4294.251009",
                                     "minimumDownloadSizeInMb": 8107,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3932.250903",
                                     "minimumDownloadSizeInMb": 8287,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3932.250808",
                                     "minimumDownloadSizeInMb": 8195,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3932.250706",
                                     "minimumDownloadSizeInMb": 7995,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3562.250605",
                                     "minimumDownloadSizeInMb": 8091,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3562.250509",
                                     "minimumDownloadSizeInMb": 8115,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3562.250404",
                                     "minimumDownloadSizeInMb": 7547,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3561.250409",
                                     "minimumDownloadSizeInMb": 7619,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3091.250305",
                                     "minimumDownloadSizeInMb": 7783,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3091.250210",
                                     "minimumDownloadSizeInMb": 7703,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3091.250112",
                                     "minimumDownloadSizeInMb": 7635,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.2762.241204",
                                     "minimumDownloadSizeInMb": 7787,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.2762.241102",
                                     "minimumDownloadSizeInMb": 7675,
                                     "launchType": "Unknown"
                                   }
                                 ]
                               }}
Name                         : microsoftwindowsserver:windowsserver
ProvisioningState            : Succeeded
ResourceGroupName            : bvt-test-automation
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.EdgeMarketPlace/offers
```

Get a specific offer by its offerId under the given resource URI.

### Example 3: GetViaIdentity example
```powershell
$offerIdentity = @{
    "ResourceUri" = "/subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation"
    "OfferId" = "microsoftwindowsserver:windowsserver"
}

Get-AzEdgeMarketplaceOffer -InputObject @offerIdentity
```

```output
Content                      : {
                                 "offerPublisher": {
                                   "publisherId": "microsoftwindowsserver",
                                   "publisherDisplayName": "Microsoft"
                                 },
                                 "iconFileUris": {
                                   "small": "https://store-images.s-microsoft.com/image/apps.38260.91bddb44-7584-4c5b-993c-af2186e9addd.209044b8-3f3d-4c05-950c-a3
                               d8aa3a4cff.69731a5c-7576-4805-a9c3-d983471152e4",
                                   "medium": "https://store-images.s-microsoft.com/image/apps.42195.91bddb44-7584-4c5b-993c-af2186e9addd.209044b8-3f3d-4c05-950c-a
                               3d8aa3a4cff.7a7dab03-8089-41bf-b53f-db78c1b29dbb",
                                   "wide": "https://store-images.s-microsoft.com/image/apps.29381.91bddb44-7584-4c5b-993c-af2186e9addd.209044b8-3f3d-4c05-950c-a3d
                               8aa3a4cff.2e5f8945-20fd-41a7-8aa6-9e9e631ef68b",
                                   "large": "https://store-images.s-microsoft.com/image/apps.11142.91bddb44-7584-4c5b-993c-af2186e9addd.209044b8-3f3d-4c05-950c-a3
                               d8aa3a4cff.b86f7502-02d4-405e-b186-86af8bb64418"
                                 },
                                 "termsAndConditions": {
                                   "legalTermsUri": "https://go.microsoft.com/fwlink/?linkid=2014360",
                                   "legalTermsType": "None",
                                   "privacyPolicyUri": "https://go.microsoft.com/fwlink/?LinkId=521839"
                                 },
                                 "displayName": "Windows Server",
                                 "summary": "Windows Server Virtual Machine Images",
                                 "longSummary": "Windows Server Virtual Machine Images",
                                 "description": "\u003cp\u003eWindows Server is the operating system that bridges on-premises environments with Azure services ena
                               bling hybrid scenarios and maximizing existing investments, including:\u003cul\u003e\u003cli\u003eThe latest is security innovation
                                including Secured-core to minimize risk from firmware vulnerabilities and advanced malware.\u003c/li\u003e\u003cli\u003eUnique hyb
                               rid capabilities with Azure to extend your datacenter and maximize investments.\u003c/li\u003e\u003cli\u003eFile server security an
                               d performance increased with SMB AES-256 encryption and SMB on-the-fly compression.\u003c/li\u003e\u003cli\u003eAzure Edition image
                               s with additional functionality optimized to run in Azure.\u003c/li\u003e\u003cli\u003eImprovements to Windows container runtime su
                               ch as cross-version compatibility and containerization tools for .NET, ASP.NET and IIS applications.\u003c/li\u003e\u003c/ul\u003e\
                               u003c/p\u003e\u003cp\u003eAvailable Images\u003c/p\u003e\u003cp\u003e\u003cb\u003eWindows Server 2022\u003c/b\u003e is the previous
                                Long-Term Servicing Channel (LTSC) release with five years of mainstream support + five years of extended support. Choose the imag
                               e that is right for your application needs.\u003cul\u003e\u003cli\u003eServer with Desktop Experience includes all roles and a grap
                               hical user interface (GUI).\u003c/li\u003e\u003cli\u003e\u003ca href=\u0027https://docs.microsoft.com/en-us/windows-server/get-star
                               ted/getting-started-with-server-core\u0027\u003eServer Core\u003c/a\u003e omits the GUI for a smaller OS footprint.\u003c/li\u003e\
                               u003cli\u003eAzure Edition with Desktop Experience- includes additional new functionality such as Hotpatch, SMB over QUIC, extended
                                network for Azure, and is optimized to run in Azure.\u003c/li\u003e\u003cli\u003eAzure Edition Core - includes additional new func
                               tionality such as Hotpatch, SMB over QUIC, extended network for Azure, and is optimized to run in Azure.\u003c/li\u003e\u003c/ul\u0
                               03e\u003c/p\u003e\u003cp\u003eTerms of use\u003c/p\u003e\u003cp\u003eYour use of the Windows Server images from Azure Marketplace V
                               irtual Machine Gallery are provided to you for use with virtual machine instances under your Azure subscription which are governed
                               by the \u003ca href=\u0027https://go.microsoft.com/fwlink/?linkid=2014360\u0027\u003eOnline Services Terms\u003c/a\u003e. Windows S
                               erver Azure edition can only be used on Azure. All Server images may be used under the \u003ca href=\u0027https://docs.microsoft.co
                               m/en-us/azure/virtual-machines/windows/hybrid-use-benefit-licensing\u0027\u003eAzure Hybrid Benefit for Windows Server\u003c/a\u003
                               e.\u003c/p\u003e\u003cp\u003eLearn more\u003c/p\u003e\u003ca href=\u0027https://docs.microsoft.com/en-us/azure/virtual-machines/\u0
                               027\u003eWindows Server Virtual Machine Documentation\u003c/a\u003e\u003cbr\u003e\u003ca href=\u0027https://docs.microsoft.com/en-u
                               s/windows-server/\u0027\u003eWindows Server Documentation\u003c/a\u003e\u003cbr\u003e\u003ca href=\u0027https://aka.ms/server-whats
                               new\u0027\u003eWhat\u0027s New in Windows Server\u003c/a\u003e",
                                 "offerId": "windowsserver",
                                 "offerType": "VirtualMachine",
                                 "popularity": 1,
                                 "availability": "Preview",
                                 "releaseType": "Preview",
                                 "categoryIds": [ "operating-systems", "compute", "virtualMachine", "virtualMachine-Arm", "microsoft-azure-corevm", "Hidden_Gen1",
                                "Hidden_Gen2" ],
                                 "operatingSystems": [ "windows.others", "windows.windowsserver2019", "windows.windowsserver2016", "windows.windowsserver2022" ]
                               }
ContentUrl                   :
ContentVersion               : 951efed5-6128-4b95-862b-431e98958202
Id                           : /subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperati
                               ons/test-automation/providers/Microsoft.EdgeMarketPlace/offers/microsoftwindowsserver:windowsserver
MarketplaceSku               : {{
                                 "operatingSystem": {
                                   "family": "Windows",
                                   "type": "Windows Server 2019",
                                   "name": ""
                                 },
                                 "catalogPlanId": "microsoft.windowsserver2019datacenter-arm",
                                 "marketplaceSkuId": "2019-datacenter-ARM",
                                 "displayName": "Windows Server 2019 Datacenter",
                                 "generation": "1",
                                 "displayRank": 13,
                                 "marketplaceSkuVersions": [
                                   {
                                     "name": "17763.8276.260109",
                                     "minimumDownloadSizeInMb": 11831,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.8146.251205",
                                     "minimumDownloadSizeInMb": 11751,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.8027.251112",
                                     "minimumDownloadSizeInMb": 11867,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7922.251021",
                                     "minimumDownloadSizeInMb": 11907,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7919.251009",
                                     "minimumDownloadSizeInMb": 11919,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7792.250903",
                                     "minimumDownloadSizeInMb": 11735,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7678.250808",
                                     "minimumDownloadSizeInMb": 12023,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7558.250705",
                                     "minimumDownloadSizeInMb": 11927,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7434.250605",
                                     "minimumDownloadSizeInMb": 11735,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7322.250524",
                                     "minimumDownloadSizeInMb": 11731,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7314.250509",
                                     "minimumDownloadSizeInMb": 11783,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7240.250409",
                                     "minimumDownloadSizeInMb": 11783,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7009.250306",
                                     "minimumDownloadSizeInMb": 11507,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6893.250210",
                                     "minimumDownloadSizeInMb": 11575,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6775.250109",
                                     "minimumDownloadSizeInMb": 11639,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6659.241205",
                                     "minimumDownloadSizeInMb": 11119,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6532.241101",
                                     "minimumDownloadSizeInMb": 11499,
                                     "launchType": "Unknown"
                                   }
                                 ]
                               }, {
                                 "operatingSystem": {
                                   "family": "Windows",
                                   "type": "Windows Server 2019",
                                   "name": ""
                                 },
                                 "catalogPlanId": "microsoft.windowsserver2019datacenter2019-datacenter-gensecond",
                                 "marketplaceSkuId": "2019-datacenter-gensecond",
                                 "displayName": "Windows Server 2019 Datacenter",
                                 "generation": "2",
                                 "displayRank": 13,
                                 "marketplaceSkuVersions": [
                                   {
                                     "name": "17763.8276.260109",
                                     "minimumDownloadSizeInMb": 11879,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.8146.251205",
                                     "minimumDownloadSizeInMb": 11883,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.8027.251112",
                                     "minimumDownloadSizeInMb": 11963,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7922.251021",
                                     "minimumDownloadSizeInMb": 12071,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7919.251009",
                                     "minimumDownloadSizeInMb": 11807,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7792.250903",
                                     "minimumDownloadSizeInMb": 11771,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7678.250808",
                                     "minimumDownloadSizeInMb": 11915,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7558.250705",
                                     "minimumDownloadSizeInMb": 12063,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7434.250605",
                                     "minimumDownloadSizeInMb": 11935,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7322.250524",
                                     "minimumDownloadSizeInMb": 11835,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7314.250509",
                                     "minimumDownloadSizeInMb": 12067,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7240.250409",
                                     "minimumDownloadSizeInMb": 11343,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.7009.250306",
                                     "minimumDownloadSizeInMb": 11239,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6893.250210",
                                     "minimumDownloadSizeInMb": 11719,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6775.250109",
                                     "minimumDownloadSizeInMb": 11459,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6659.241205",
                                     "minimumDownloadSizeInMb": 11163,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "17763.6532.241101",
                                     "minimumDownloadSizeInMb": 11487,
                                     "launchType": "Unknown"
                                   }
                                 ]
                               }, {
                                 "operatingSystem": {
                                   "family": "Windows",
                                   "type": "Windows Server 2022 Datacenter: Azure Edition",
                                   "name": ""
                                 },
                                 "catalogPlanId": "microsoftwindowsserver.windowsserver2022-datacenter-azure-edition-hotpatch",
                                 "marketplaceSkuId": "2022-datacenter-azure-edition-hotpatch",
                                 "displayName": "Windows Server 2022 Datacenter: Azure Edition Hotpatch",
                                 "generation": "2",
                                 "displayRank": 1,
                                 "marketplaceSkuVersions": [
                                   {
                                     "name": "20348.4648.260108",
                                     "minimumDownloadSizeInMb": 12171,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4529.251206",
                                     "minimumDownloadSizeInMb": 12143,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4346.251112",
                                     "minimumDownloadSizeInMb": 12035,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4297.251024",
                                     "minimumDownloadSizeInMb": 12055,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4294.251009",
                                     "minimumDownloadSizeInMb": 12015,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3932.250903",
                                     "minimumDownloadSizeInMb": 12203,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3932.250808",
                                     "minimumDownloadSizeInMb": 12191,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3932.250706",
                                     "minimumDownloadSizeInMb": 11943,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3562.250605",
                                     "minimumDownloadSizeInMb": 12131,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3562.250509",
                                     "minimumDownloadSizeInMb": 12083,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3562.250404",
                                     "minimumDownloadSizeInMb": 11855,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3561.250409",
                                     "minimumDownloadSizeInMb": 11895,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3091.250305",
                                     "minimumDownloadSizeInMb": 11975,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3091.250210",
                                     "minimumDownloadSizeInMb": 12011,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3091.250112",
                                     "minimumDownloadSizeInMb": 11839,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.2762.241204",
                                     "minimumDownloadSizeInMb": 11959,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.2762.241102",
                                     "minimumDownloadSizeInMb": 11707,
                                     "launchType": "Unknown"
                                   }
                                 ]
                               }, {
                                 "operatingSystem": {
                                   "family": "Windows",
                                   "type": "Windows Server 2022 Datacenter: Azure Edition",
                                   "name": ""
                                 },
                                 "catalogPlanId": "microsoftwindowsserver.windowsserver2022-datacenter-azure-edition-core",
                                 "marketplaceSkuId": "2022-datacenter-azure-edition-core",
                                 "displayName": "Windows Server 2022 Datacenter: Azure Edition Core",
                                 "generation": "2",
                                 "displayRank": 3,
                                 "marketplaceSkuVersions": [
                                   {
                                     "name": "20348.4648.260108",
                                     "minimumDownloadSizeInMb": 8087,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4529.251206",
                                     "minimumDownloadSizeInMb": 8195,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4346.251112",
                                     "minimumDownloadSizeInMb": 8099,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4297.251024",
                                     "minimumDownloadSizeInMb": 8043,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.4294.251009",
                                     "minimumDownloadSizeInMb": 8107,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3932.250903",
                                     "minimumDownloadSizeInMb": 8287,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3932.250808",
                                     "minimumDownloadSizeInMb": 8195,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3932.250706",
                                     "minimumDownloadSizeInMb": 7995,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3562.250605",
                                     "minimumDownloadSizeInMb": 8091,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3562.250509",
                                     "minimumDownloadSizeInMb": 8115,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3562.250404",
                                     "minimumDownloadSizeInMb": 7547,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3561.250409",
                                     "minimumDownloadSizeInMb": 7619,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3091.250305",
                                     "minimumDownloadSizeInMb": 7783,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3091.250210",
                                     "minimumDownloadSizeInMb": 7703,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.3091.250112",
                                     "minimumDownloadSizeInMb": 7635,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.2762.241204",
                                     "minimumDownloadSizeInMb": 7787,
                                     "launchType": "Unknown"
                                   },
                                   {
                                     "name": "20348.2762.241102",
                                     "minimumDownloadSizeInMb": 7675,
                                     "launchType": "Unknown"
                                   }
                                 ]
                               }}
Name                         : microsoftwindowsserver:windowsserver
ProvisioningState            : Succeeded
ResourceGroupName            : bvt-test-automation
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.EdgeMarketPlace/offers
```

This command get the offer using `offerIdentity`.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
Filter the result list using the given expression.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Id of the offer

```yaml
Type: System.String
Parameter Sets: Get
Aliases: OfferId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IEdgeMarketplaceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Maxpagesize
The maximum number of result items per page.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUri
The fully qualified Azure Resource manager identifier of the resource.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
The number of result items to skip.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipToken
Skip over when retrieving results.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
The number of result items to return.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IEdgeMarketplaceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOffer

## NOTES

## RELATED LINKS

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
Filter the result list using the given expression.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Id of the offer

```yaml
Type: System.String
Parameter Sets: Get
Aliases: OfferId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IEdgeMarketplaceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Maxpagesize
The maximum number of result items per page.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUri
The fully qualified Azure Resource manager identifier of the resource.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipToken
Skip over when retrieving results.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
The number of result items to return.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
The number of result items to skip.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

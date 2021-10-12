### Example 1: Update a Web PubSub resource
```powershell
PS C:\> $wps = Update-AzWebPubSub -ResourceGroupName psdemo -ResourceName psdemo-wps `
-IdentityType SystemAssigned -LiveTraceEnabled true `
-LiveTraceCategory @{ Name='ConnectivityLogs' ; Enabled = 'true' }, @{ Name='MessageLogs' ; Enabled = 'true' } `
-PrivateEndpoint @{ Name = 'privateEndpointConnection1' ; Allow = 'RESTAPI' }

PS C:\> $wps | format-list

DisableAadAuth               : False
DisableLocalAuth             : False
EnableTlClientCert           : False
ExternalIP                   : 20.62.134.186
HostName                     : psdemo-wps.webpubsub.azure.com
Id                           : /subscriptions/9caf2a1e-9c49-49b6-89a2-56bdec7e3f97/resourceGroups/psdemo/providers/Micr
                               osoft.SignalRService/WebPubSub/psdemo-wps
IdentityPrincipalId          : 330ad5ec-15b8-495c-9827-0a4bc93ff631
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
LiveTraceCategory            : {ConnectivityLogs, MessageLogs}
LiveTraceEnabled             : true
Location                     : eastus
Name                         : psdemo-wps
NetworkAcLDefaultAction      : Deny
PrivateEndpoint              : {}
PrivateEndpointConnection    : {}
ProvisioningState            : Succeeded
PublicNetworkAccess          : Enabled
PublicNetworkAllow           : {ServerConnection, ClientConnection, RESTAPI, Trace}
PublicNetworkDeny            :
PublicPort                   : 443
ResourceLogCategory          :
ServerPort                   : 443
SharedPrivateLinkResource    : {}
SkuCapacity                  : 1
SkuFamily                    :
SkuName                      : Standard_S1
SkuSize                      : S1
SkuTier                      : Standard
SystemDataCreatedAt          : 2021-10-11 9:02:37 AM
SystemDataCreatedBy          : testuser@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2021-10-12 6:34:47 AM
SystemDataLastModifiedBy     : testuser@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.TrackedResourceTags
Type                         : Microsoft.SignalRService/WebPubSub
UserAssignedIdentity         : Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.ManagedIdentityUserAssig
                               nedIdentities
Version                      : 1.0
```



---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ApiManagement.dll-Help.xml
Module Name: Az.ApiManagement
online version: https://docs.microsoft.com/powershell/module/az.apimanagement/set-azapimanagement
schema: 2.0.0
---

# Set-AzApiManagement

## SYNOPSIS

Updates an Azure Api Management service

## SYNTAX

```
Set-AzApiManagement -InputObject <PsApiManagement> [-SystemAssignedIdentity] [-UserAssignedIdentity <String[]>]
 [-AsJob] [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION

The **Set-AzApiManagement** cmdlet updates an Azure API Management service.

## EXAMPLES

### Example 1: Get an API Management service and scale it to Premium and Add a region

```powershell
$apim = Get-AzApiManagement -ResourceGroupName "ContosoGroup" -Name "ContosoApi"
$apim.Sku = "Premium"
$apim.Capacity = 5
$apim.AddRegion("Central US", "Premium", 3)
Set-AzApiManagement -InputObject $apim
```

This example gets an Api Management instance, scales it to five premium units and then adds an additional three units to the premium region.

### Example 2: Update deployment (external VNET)

```powershell
$virtualNetwork = New-AzApiManagementVirtualNetwork -SubnetResourceId "/subscriptions/a8ff56dc-3bc7-4174-a1e8-3726ab15d0e2/resourceGroups/Api-Default-WestUS/providers/Microsoft.Network/virtualNetworks/dfVirtualNetwork/subnets/backendSubnet"
$apim = Get-AzApiManagement -ResourceGroupName "ContosoGroup" -Name "ContosoApi"
$apim.VpnType = "External"
$apim.VirtualNetwork = $virtualNetwork
Set-AzApiManagement -InputObject $apim
```

This command updates an existing API Management deployment and joins to an external *VpnType*.

### Example 3: Create and initialize an instance of PsApiManagementCustomHostNameConfiguration using an Secret from KeyVault Resource

```powershell
$portal = New-AzApiManagementCustomHostnameConfiguration -Hostname "portal.contoso.com" -HostnameType Portal -KeyVaultId "https://apim-test-keyvault.vault.azure.net/secrets/api-portal-custom-ssl.pfx"
$proxy1 = New-AzApiManagementCustomHostnameConfiguration -Hostname "gatewayl.contoso.com" -HostnameType Proxy -KeyVaultId "https://apim-test-keyvault.vault.azure.net/secrets/contoso-proxy-custom-ssl.pfx"
$proxy2 = New-AzApiManagementCustomHostnameConfiguration -Hostname "gatewayl.foobar.com" -HostnameType Proxy -KeyVaultId "https://apim-test-keyvault.vault.azure.net/secrets/foobar-proxy-custom-ssl.pfx"
$proxyCustomConfig = @($proxy1,$proxy2)
$apim = Get-AzApiManagement -ResourceGroupName "ContosoGroup" -Name "ContosoApi"
$apim.PortalCustomHostnameConfiguration = $portal
$apim.ProxyCustomHostnameConfiguration = $proxyCustomConfig 
Set-AzApiManagement -InputObject $apim -SystemAssignedIdentity
```

### Example 4: Update Publisher Email, NotificationSender Email and Organization Name

```powershell
$apim = Get-AzApiManagement -ResourceGroupName "api-Default-West-US" -Name "Contoso"
$apim.PublisherEmail = "foobar@contoso.com"
$apim.NotificationSenderEmail = "notification@contoso.com"
$apim.OrganizationName = "Contoso"
Set-AzApiManagement -InputObject $apim -PassThru
```

### Example 5: Add Managed Certificate to an APIM Service

```powershell
$gateway=New-AzApiManagementCustomHostnameConfiguration -Hostname freecertCanary.contoso.api -HostnameType Proxy -ManagedCertificate
$customConfig= @($gateway)
$apim=Get-AzApiManagement -ResourceGroupName contosogroup -Name contosoapim
$apim.ProxyCustomHostnameConfiguration = $customConfig
Set-AzApiManagement -InputObject $apim -PassThru


PublicIPAddresses                     : {20.45.236.81}
PrivateIPAddresses                    :
Id                                    : /subscriptions/a200340d-6b82-494d-9dbf-687ba6e33f9e/resourceGroups/Api-Default-
                                        Central-US-EUAP/providers/Microsoft.ApiManagement/service/contosoapim
Name                                  : contosoapim
Location                              : Central US EUAP
Sku                                   : Developer
Capacity                              : 1
CreatedTimeUtc                        : 8/24/2021 10:40:21 PM
ProvisioningState                     : Succeeded
RuntimeUrl                            : https://contosoapim.azure-api.net
RuntimeRegionalUrl                    : https://contosoapim-centraluseuap-01.regional.azure-api.net
PortalUrl                             : https://contosoapim.portal.azure-api.net
DeveloperPortalUrl                    : https://contosoapim.developer.azure-api.net
ManagementApiUrl                      : https://contosoapim.management.azure-api.net
ScmUrl                                : https://contosoapim.scm.azure-api.net
PublisherEmail                        : zhonren@microsoft.com
OrganizationName                      : Microsoft
NotificationSenderEmail               : apimgmt-noreply@mail.windowsazure.com
VirtualNetwork                        :
VpnType                               : None
PortalCustomHostnameConfiguration     :
ProxyCustomHostnameConfiguration      : {contosoapim.azure-api.net, freecertCanary..contoso.api}
ManagementCustomHostnameConfiguration :
ScmCustomHostnameConfiguration        :
DeveloperPortalHostnameConfiguration  :
SystemCertificates                    :
Tags                                  : {}
AdditionalRegions                     : {}
SslSetting                            : Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSslSetting
Identity                              : Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementServiceIdentity
EnableClientCertificate               :
Zone                                  :
DisableGateway                        : False
MinimalControlPlaneApiVersion         :
PublicIpAddressId                     :
PlatformVersion                       : stv2
PublicNetworkAccess                   : Enabled
PrivateEndpointConnections            :
ResourceGroupName                     : contosogroup

$apim.ProxyCustomHostnameConfiguration

CertificateInformation     :
EncodedCertificate         :
HostnameType               : Proxy
CertificatePassword        :
Hostname                   : contosoapim.azure-api.net
KeyVaultId                 :
DefaultSslBinding          : False
NegotiateClientCertificate : False
IdentityClientId           :
CertificateStatus          :
CertificateSource          : BuiltIn

CertificateInformation     : Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementCertificateInformation
EncodedCertificate         :
HostnameType               : Proxy
CertificatePassword        :
Hostname                   : freecertCanary.contoso.api
KeyVaultId                 :
DefaultSslBinding          : True
NegotiateClientCertificate : False
IdentityClientId           :
CertificateStatus          :
CertificateSource          : Managed

```

This sample adds a Managed Certificates to an API Management service.

## PARAMETERS

### -AsJob

Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile

The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject

The ApiManagement instance.

```yaml
Type: Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagement
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru

Sends updated PsApiManagement to pipeline if operation succeeds.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SystemAssignedIdentity

Generate and assign an Azure Active Directory Identity for this server for use with key management services like Azure KeyVault.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity

Assign User Identities to this server for use with key management services like Azure KeyVault.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm

Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf

Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagement

## OUTPUTS

### Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagement

## NOTES

## RELATED LINKS

[Get-AzApiManagement](./Get-AzApiManagement.md)

[New-AzApiManagement](./New-AzApiManagement.md)

[Remove-AzApiManagement](./Remove-AzApiManagement.md)

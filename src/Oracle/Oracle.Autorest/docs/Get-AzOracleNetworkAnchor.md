---
external help file:
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/get-azoraclenetworkanchor
schema: 2.0.0
---

# Get-AzOracleNetworkAnchor

## SYNOPSIS
Get a NetworkAnchor

## SYNTAX

### List (Default)
```
Get-AzOracleNetworkAnchor [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzOracleNetworkAnchor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOracleNetworkAnchor -InputObject <IOracleIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzOracleNetworkAnchor -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a NetworkAnchor

## EXAMPLES

### Example 1: Get a list of the Network Anchor resources
```powershell
Get-AzOracleNetworkAnchor
```

```output
...
Name                                          : OFake_owerShellTestNetworkAnchor
Id                                            : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/networkAnchors/OFake_owerShellTestNetworkAnchor
Type                                          : oracle.database/networkanchors
Location                                      : eastus2
ResourceGroupName                             : PowerShellTestRg
OciUrl                                        : https://cloud.oracle.com/network-anchors/ocid1.networkanchor.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuvm62example?region=us-ashbur
                                                n-1&tenant=orpsandbox3
Ocid                                          : ocid1.networkanchor.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuvm62example
LinkedResourceId                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet
ProvisioningState                             : Succeeded
Property                                      : {
                                                  ...
                                                }
SystemDataCreatedAt                           : 05/07/2024 13:40:35
SystemDataCreatedBy                           : example@oracle.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 06/07/2024 09:19:26
SystemDataLastModifiedBy                      : 857ad006-4380-4712-ba4c-22f7c64d84e7
SystemDataLastModifiedByType                  : Application
Tag                                           : {
                                                }
TimeCreated                                   : 05/07/2024 13:44:18
```

Get a Network Anchor resource by name and resource group name.
For more information, execute `Get-Help Get-AzOracleNetworkAnchor`.

### Example 2: Get a Network Anchor by name and resource group name
```powershell
Get-AzOracleNetworkAnchor -ResourceGroupName PowerShellTestRg -Name OFake_owerShellTestNetworkAnchor
```

```output
Name                                          : OFake_owerShellTestNetworkAnchor
Id                                            : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/networkAnchors/OFake_owerShellTestNetworkAnchor
Type                                          : oracle.database/networkanchors
Location                                      : eastus2
ResourceGroupName                             : PowerShellTestRg
OciUrl                                        : https://cloud.oracle.com/network-anchors/ocid1.networkanchor.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuvm62example?region=us-ashbur
                                                n-1&tenant=orpsandbox3
Ocid                                          : ocid1.networkanchor.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuvm62example
LinkedResourceId                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet
ProvisioningState                             : Succeeded
Property                                      : {
                                                  ...
                                                }
SystemDataCreatedAt                           : 05/07/2024 13:40:35
SystemDataCreatedBy                           : example@oracle.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 06/07/2024 09:19:26
SystemDataLastModifiedBy                      : 857ad006-4380-4712-ba4c-22f7c64d84e7
SystemDataLastModifiedByType                  : Application
Tag                                           : {
                                                }
TimeCreated                                   : 05/07/2024 13:44:18
```

Gets a specific Network Anchor resource by name and resource group name.
For more information, execute `Get-Help Get-AzOracleNetworkAnchor`.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the NetworkAnchor

```yaml
Type: System.String
Parameter Sets: Get
Aliases: NetworkAnchorName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.INetworkAnchor

## NOTES

## RELATED LINKS


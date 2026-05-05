---
external help file: Az.Oracle-help.xml
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/update-azoracleresourceanchor
schema: 2.0.0
---

# Update-AzOracleResourceAnchor

## SYNOPSIS
Update a ResourceAnchor

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzOracleResourceAnchor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzOracleResourceAnchor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzOracleResourceAnchor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzOracleResourceAnchor -InputObject <IOracleIdentity> [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a ResourceAnchor

## EXAMPLES

### Example 1: Update tags on a Resource Anchor
```powershell
Update-AzOracleResourceAnchor -ResourceGroupName PowerShellTestRg -Name OFake_PowerShellTestResourceAnchor -Tag @{ env="test"; owner="example@oracle.com" }
```

```output
Name                                          : OFake_PowerShellTestResourceAnchor
Id                                            : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/resourceAnchors/OFake_PowerShellTestResourceAnchor
Type                                          : oracle.database/resourceanchors
Location                                      : eastus2
ResourceGroupName                             : PowerShellTestRg
OciUrl                                        : https://cloud.oracle.com/resource-anchors/ocid1.resourceanchor.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuvm62example?region=us-ashbur
                                                n-1&tenant=orpsandbox3
Ocid                                          : ocid1.resourceanchor.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuvm62example
LinkedResourceId                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/autonomousDatabases/OFakePowerShellTestAdbs
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
                                                  env=test
                                                  owner=example@oracle.com
                                                }
TimeCreated                                   : 05/07/2024 13:44:18
```

Updates the **tags** on an existing Resource Anchor.
For more information, execute `Get-Help Update-AzOracleResourceAnchor`.

### Example 2: Partially update a Resource Anchor property
```powershell
Update-AzOracleResourceAnchor -ResourceGroupName PowerShellTestRg -Name OFake_PowerShellTestResourceAnchor
```

```output
Name                                          : OFake_PowerShellTestResourceAnchor
Id                                            : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/resourceAnchors/OFake_PowerShellTestResourceAnchor
Type                                          : oracle.database/resourceanchors
Location                                      : eastus2
ResourceGroupName                             : PowerShellTestRg
OciUrl                                        : https://cloud.oracle.com/resource-anchors/ocid1.resourceanchor.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuvm62example?region=us-ashbur
                                                n-1&tenant=orpsandbox3
Ocid                                          : ocid1.resourceanchor.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuvm62example
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
                                                  env=test
                                                  owner=example@oracle.com
                                                }
TimeCreated                                   : 05/07/2024 13:44:18
```

Performs a **partial update** of a Resource Anchor (PATCH) to modify a property-in this case, `LinkedResourceId`.
For more information, execute `Get-Help Update-AzOracleResourceAnchor`.

## PARAMETERS

### -AsJob
Run the command as a job

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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the ResourceAnchor

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases: ResourceAnchorName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IResourceAnchor

## NOTES

## RELATED LINKS

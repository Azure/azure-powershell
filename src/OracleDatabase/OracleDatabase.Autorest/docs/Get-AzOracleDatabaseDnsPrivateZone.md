---
external help file:
Module Name: Az.OracleDatabase
online version: https://learn.microsoft.com/powershell/module/az.oracledatabase/get-azoracledatabasednsprivatezone
schema: 2.0.0
---

# Get-AzOracleDatabaseDnsPrivateZone

## SYNOPSIS
Get a DnsPrivateZone

## SYNTAX

### List (Default)
```
Get-AzOracleDatabaseDnsPrivateZone -Location <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzOracleDatabaseDnsPrivateZone -Location <String> -Name <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOracleDatabaseDnsPrivateZone -InputObject <IOracleDatabaseIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityLocation
```
Get-AzOracleDatabaseDnsPrivateZone -LocationInputObject <IOracleDatabaseIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a DnsPrivateZone

## EXAMPLES

### Example 1: Gets a list of the DNS Private Zones by location
```powershell
Get-AzOracleDatabaseDnsPrivateZone -Location "eastus"
```

```output
Name                                                                      SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                                                                      ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
byui3zo3.ocidelegated.ocipstestvnet.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                       
byui3zo3.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                                                  
byui3zo3.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                                              
byui3zo3.ocidelegated.ocipstestvnet.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                   
byui3zo3.adb.us-ashburn-1.oraclecloudapps.com                                                                                                                                                                            
byui3zo3.adb.us-ashburn-1.oraclecloud.com                                                                                                                                                                                
ocibackupdeleg.ocipstestvnet.oraclevcn.com                                                                                                                                                                               
ocidelegated.ocipstestvnet.oraclevcn.com                                                                                                                                                                                 
oui8ipy0.ocidelegated.ocidarenvnet.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                        
oui8ipy0.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                                                  
oui8ipy0.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                                              
oui8ipy0.ocidelegated.ocidarenvnet.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                    
oui8ipy0.adb.us-ashburn-1.oraclecloudapps.com                                                                                                                                                                            
oui8ipy0.adb.us-ashburn-1.oraclecloud.com                                                                                                                                                                                
ocidelegated.ocidarenvnet.oraclevcn.com                                                                                                                                                                                  
haisu723.ocidefault2.ocidbqavnetjun.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                       
haisu723.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                                                  
haisu723.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                                              
haisu723.ocidefault2.ocidbqavnetjun.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                   
haisu723.adb.us-ashburn-1.oraclecloudapps.com                                                                                                                                                                            
haisu723.adb.us-ashburn-1.oraclecloud.com                                                                                                                                                                                
wvrdwnp0.ocidefault2.ocidbqavnetjun.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                       
wvrdwnp0.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                                                  
wvrdwnp0.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                                              
wvrdwnp0.ocidefault2.ocidbqavnetjun.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                   
wvrdwnp0.adb.us-ashburn-1.oraclecloudapps.com                                                                                                                                                                            
wvrdwnp0.adb.us-ashburn-1.oraclecloud.com                                                                                                                                                                                
pfwukijt.ocidefault2.ocidbqavnetjun.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                       
pfwukijt.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                                                  
pfwukijt.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                                              
pfwukijt.ocidefault2.ocidbqavnetjun.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                   
pfwukijt.adb.us-ashburn-1.oraclecloudapps.com                                                                                                                                                                            
pfwukijt.adb.us-ashburn-1.oraclecloud.com                                                                                                                                                                                
y7sttfq6.ocidefault2.ocidbqavnetjun.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                       
y7sttfq6.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                                                  
y7sttfq6.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                                              
y7sttfq6.ocidefault2.ocidbqavnetjun.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                   
y7sttfq6.adb.us-ashburn-1.oraclecloudapps.com                                                                                                                                                                            
y7sttfq6.adb.us-ashburn-1.oraclecloud.com                                                                                                                                                                                
ocibackupdg1.oci0409vn.oraclevcn.com                                                                                                                                                                                     
vifnfx8g.ocidefault2.ocidbqavnetjun.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                       
vifnfx8g.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                                                  
vifnfx8g.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                                              
vifnfx8g.ocidefault2.ocidbqavnetjun.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                   
vifnfx8g.adb.us-ashburn-1.oraclecloudapps.com                                                                                                                                                                            
vifnfx8g.adb.us-ashburn-1.oraclecloud.com                                                                                                                                     

spalimpa.new.com                                                                                                                                                                                                         
wk2pxbuc.ocidefault2.ocidbqavnetjun.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                       
wk2pxbuc.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                                                  
wk2pxbuc.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                                              
wk2pxbuc.ocidefault2.ocidbqavnetjun.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                   
wk2pxbuc.adb.us-ashburn-1.oraclecloudapps.com                                                                                                                                                                            
wk2pxbuc.adb.us-ashburn-1.oraclecloud.com                                                                                                                                                                                
ocidefault2.ocidbqavnetjun.oraclevcn.com                                                                                                                                                                                 
ocidg2.ocicomichaevn.oraclevcn.com                                                                                                                                                                                       
hhbrpiy9.ocidefault.ocidrtestvnet0.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                        
hhbrpiy9.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                                                  
hhbrpiy9.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                                              
hhbrpiy9.ocidefault.ocidrtestvnet0.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                    
hhbrpiy9.adb.us-ashburn-1.oraclecloudapps.com                                                                                                                                                                            
hhbrpiy9.adb.us-ashburn-1.oraclecloud.com                                                                                                                                                                                
spalimpa.testPZ.com                                                                                                                                                                                                      
max.test.zone.oracle.com                                                                                                                                                                                                 
max.test.oracle.com                                                                                                                                                                                                      
dfadf.adfdf.sdfd.dadf.dfadf.com                                                                                                                                                                                          
rctjwxmm.ocisyde2etests.ocisyde2etestv.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                    
rctjwxmm.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                                                  
rctjwxmm.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                                              
rctjwxmm.ocisyde2etests.ocisyde2etestv.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                
rctjwxmm.adb.us-ashburn-1.oraclecloudapps.com                                                                                                                                                                            
rctjwxmm.adb.us-ashburn-1.oraclecloud.com                                                                                                                                                                                
ocisyde2etests.ocisyde2etestv.oraclevcn.com                                                                                                                                                                              
ocidelegated.ocisysvereastu.oraclevcn.com                                                                                                                                                                                
ypieowfk.ocidefault.ocidrtestvnet0.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                        
ypieowfk.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                                                  
ypieowfk.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                                              
ypieowfk.ocidefault.ocidrtestvnet0.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                    
ypieowfk.adb.us-ashburn-1.oraclecloudapps.com                                                                                                                                                                            
ypieowfk.adb.us-ashburn-1.oraclecloud.com                                                                                                                                                                                
ocidelegated.ociperfttestvn.oraclevcn.com                                                                                                                                                                                
jfz7y85f.ocidefault.ocidrtestvnet0.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                        
jfz7y85f.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                                                  
jfz7y85f.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                                              
jfz7y85f.ocidefault.ocidrtestvnet0.adbapps.us-ashburn-1.oraclevcn.com                                                                                                                                                    
jfz7y85f.adb.us-ashburn-1.oraclecloudapps.com                                                                                                                                                                            
jfz7y85f.adb.us-ashburn-1.oraclecloud.com                                                                                                                                                                                
ocisubnetaccte.ocivnetacctest.oraclevcn.com                                                                                                                                                                              
ocidefault.ocidrtestvnet0.oraclevcn.com                                                                                                                                                                                  
ocidelegatedsu.ocidbqaociuivn.oraclevcn.com                                                                                                                                                                              
ocidelegated.ocidnsfwdvn.oraclevcn.com
```

Gets a list of the DNS Private Zones by location.
For more information, execute `Get-Help Get-AzOracleDatabaseDnsPrivateZone`

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
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The name of the Azure region.

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

### -LocationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity
Parameter Sets: GetViaIdentityLocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
DnsPrivateZone name

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityLocation
Aliases: Dnsprivatezonename

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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IDnsPrivateZone

## NOTES

## RELATED LINKS


### Example 1: Get databoxHeavy job credential
```powershell
<<<<<<< HEAD
Get-AzDataBoxJobCredential -Name "DtbxPowershell" -ResourceGroupName "resourceGroupName"

$obj = Get-AzDataBoxJobCredential -Name TJy-637522091284252285 -ResourceGroupName bvttoolrg12-Wednesday
$obj | Format-List
=======
PS C:\> Get-AzDataBoxJobCredential -Name "DtbxPowershell" -ResourceGroupName "resourceGroupName"

PS C:\> $obj = Get-AzDataBoxJobCredential -Name TJy-637522091284252285 -ResourceGroupName bvttoolrg12-Wednesday
PS C:\> $obj | Format-List
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91

AdditionalInfo                          :
Code                                    :
DcAccessSecurityCodeForwardDcAccessCode :
DcAccessSecurityCodeReverseDcAccessCode :
Detail                                  :
JobName                                 : DtbxPowershell
JobSecret                               : Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxHeavyJobSecrets
JobSecretJobSecretsType                 : DataBoxHeavy
Message                                 :
Target                                  :


<<<<<<< HEAD
$obj.JobSecret | Format-List
=======
PS C:\> $obj.JobSecret | Format-List
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91

AdditionalInfo                          :
CabinetPodSecret                        : {, }
Code                                    :
DcAccessSecurityCode                    : Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DcAccessSecurityCode
DcAccessSecurityCodeForwardDcAccessCode :
DcAccessSecurityCodeReverseDcAccessCode :
Detail                                  :
Error                                   : Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.CloudError
Message                                 :
Target                                  :
Type                                    : DataBoxHeavy

<<<<<<< HEAD
$cabinetJobSecret = $obj.JobSecret.CabinetPodSecret | Format-List
=======
PS C:\> $cabinetJobSecret = $obj.JobSecret.CabinetPodSecret | Format-List
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Get databoxHeavy job credential 
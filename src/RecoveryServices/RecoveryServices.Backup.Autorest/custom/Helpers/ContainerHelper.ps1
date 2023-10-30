
# Summary: get BackupManagementType from ContainerType
function GetBackupManagementTypeFromContainerType {
    [OutputType('string')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

    param(
        [Parameter(Mandatory=$true)]
        [System.String]
        $ContainerType
    )

    process {
        
        #AzureVM, Windows, AzureStorage, AzureVMAppContainer
        if($ContainerType -eq "AzureVM"){
            return "AzureIaasVM"
        }
        elseif($ContainerType -eq "AzureVMAppContainer"){
            return "AzureWorkload"
        }
        elseif($ContainerType -eq "AzureStorage"){
            return "AzureStorage"
        }
        elseif($ContainerType -eq "Windows"){
            return "MAB"
        }
        
        # Return null if no match found
        return $null
    }    
}


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

# Summary: Invokes the refresh operation on protection container
# can be exposed as a command
function Invoke-AzRecoveryServicesRefreshContainer {
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

    param(
        [Parameter(Mandatory=$false)]
        [System.String]
        $SubscriptionId,

        [Parameter(Mandatory=$true)]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory=$true)]
        [System.String]
        $VaultName,

        [Parameter(Mandatory=$true)]
        [System.String]
        $Filter
    )

    process {
        $PSBoundParameters.Add('FabricName', 'Azure')
        $PSBoundParameters.Add('NoWait', $true)
        $refreshOperationResponse = Az.RecoveryServices.Internal\Update-AzRecoveryServicesProtectionContainer @PSBoundParameters
        
        $null = $PSBoundParameters.Remove('NoWait')
        $null = $PSBoundParameters.Remove('FabricName')
        $null = $PSBoundParameters.Remove('Filter')
        $null = $PSBoundParameters.Remove('VaultName')
        $null = $PSBoundParameters.Remove('ResourceGroupName')
        $null = $PSBoundParameters.Remove('SubscriptionId')
        $PSBoundParameters.Add('Target', $refreshOperationResponse.Target)
        $operationStatus = GetOperationStatus @PSBoundParameters
        if($operationStatus -ne "Succeeded"){
            $errormsg= "Refresh container operation failed with operationStatus: $operationStatus"
            throw $errormsg
        }

        return $operationStatus
    }
}

# trigger inquiry for protectable items
function Invoke-AzRecoveryServicesInquireContainer {
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

    param(
        [Parameter(Mandatory=$false, HelpMessage='Subscription Id')]
        [System.String]
        $SubscriptionId,

        [Parameter(Mandatory=$true)]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory=$true)]
        [System.String]
        $VaultName,

        [Parameter(Mandatory=$true)]
        [System.String]
        $Filter,

        [Parameter(Mandatory=$true)]
        [System.String]
        [string]$ContainerName
    )

    process {
        $PSBoundParameters.Add('FabricName', 'Azure')
        $PSBoundParameters.Add('NoWait', $true)

        # TODO: uncomment
        $refreshOperationResponse = <#Az.RecoveryServices.Internal\#>Invoke-AzRecoveryServicesInquireProtectionContainer @PSBoundParameters
        
        $null = $PSBoundParameters.Remove('NoWait')
        $null = $PSBoundParameters.Remove('FabricName')
        $null = $PSBoundParameters.Remove('Filter')
        $null = $PSBoundParameters.Remove('ContainerName')
        $null = $PSBoundParameters.Remove('VaultName')
        $null = $PSBoundParameters.Remove('ResourceGroupName')
        $null = $PSBoundParameters.Remove('SubscriptionId')
        $PSBoundParameters.Add('Target', $refreshOperationResponse.Target)
        $operationStatus = GetOperationStatus @PSBoundParameters
        if($operationStatus -ne "Succeeded"){
            $errormsg= "Inquire container operation failed with operationStatus: $operationStatus"
            throw $errormsg
        }

        return $operationStatus
    }
}

# Summary: Register protection container
function Register-Container {
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

    param(
        [Parameter(Mandatory=$false)]
        [System.String]
        $SubscriptionId,

        [Parameter(Mandatory=$true)]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory=$true)]
        [System.String]
        $VaultName,

        [Parameter(Mandatory=$true)]
        [System.String]
        $ContainerName,
        
        [Parameter(Mandatory=$true)]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ProtectionContainerResource]
        $Parameter
    )

    process {
        $PSBoundParameters.Add('FabricName', 'Azure')
        $PSBoundParameters.Add('NoWait', $true)

        $registerOperationResponse = Az.RecoveryServices.Internal\Register-AzRecoveryServicesProtectionContainer @PSBoundParameters
        
        $null = $PSBoundParameters.Remove('NoWait')
        $null = $PSBoundParameters.Remove('FabricName')
        $null = $PSBoundParameters.Remove('ContainerName')
        $null = $PSBoundParameters.Remove('Parameter')

        $null = $PSBoundParameters.Remove('VaultName')
        $null = $PSBoundParameters.Remove('ResourceGroupName')
        $null = $PSBoundParameters.Remove('SubscriptionId')

        $PSBoundParameters.Add('Target', $registerOperationResponse.Target)
        $PSBoundParameters.Add('RefreshAfter', 30)

        $operationStatus = GetOperationStatus @PSBoundParameters
        if($operationStatus -ne "Succeeded"){
            $errormsg= "Register container operation failed with operationStatus: $operationStatus"
            throw $errormsg
        }

        return $operationStatus
    }
}

function AddFilterToQuery {
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Query,

        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $FilterKey,

        [Parameter(Mandatory = $true)]
        [System.String[]]
        $FilterValues
    )
	
    process {

        if (($FilterValues -ne $null) -and ($FilterValues.Length -ne 0)) {
            $updatedQuery = $Query
            $filterValueJoin = [System.String]::Join("','", $FilterValues)
            $updatedQuery += " | where " + $FilterKey + " in~ ('" + $filterValueJoin + "')"
            return $updatedQuery
        }

        return $Query
    }
}

function GetResourceGroupIdFromArmId {
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Id
    )
	
    process {

        $ResourceArray = $Id.Split("/")
        $ResourceRG = "/subscriptions/" + $ResourceArray[2] + "/resourceGroups/" + $ResourceArray[4]

        return $ResourceRG
    }
}

function GetSubscriptionNameFromArmId {
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Id
    )
	
    process {

        $ResourceArray = $Id.Split("/")
        $SubscriptionName = "/subscriptions/" + $ResourceArray[2]
        
        return $SubscriptionName
    }
}


function GetResourceNameFromArmId {
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Id
    )
	
    process {

        $ResourceArray = $Id.Split("/")
        $ResourceName = $ResourceArray[8]
        
        return $ResourceName
    }
}

function GetResourceGroupNameFromArmId {
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Id
    )
	
    process {

        $ResourceArray = $Id.Split("/")
        $ResourceRG = $ResourceArray[4]
        
        return $ResourceRG
    }
}

function CheckResourceGraphModuleDependency {
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
    param() 

    process {
        $module = Get-Module -ListAvailable | Where-Object { $_.Name -eq "Az.ResourceGraph" }
        if ($module -eq $null) {
            $message = "Az.ResourceGraph Module must be installed to run this command. Please run 'Install-Module -Name Az.ResourceGraph' to install and continue."
            throw $message
        }
    }
}

function CheckResourcesModuleDependency {
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
    param() 

    process {
        $module = Get-Module -ListAvailable | Where-Object { $_.Name -eq "Az.Resources" }
        if ($module -eq $null) {
            $message = "Az.Resources Module must be installed to run this command. Please run 'Install-Module -Name Az.Resources' to install and continue."
            throw $message
        }
    }
}

function CheckPostgreSqlModuleDependency {
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
    param() 

    process {
        $module = Get-Module -ListAvailable | Where-Object { $_.Name -eq "Az.PostgreSql" }
        if ($module -eq $null) {
            $message = "Az.PostgreSql Module must be installed to run this command. Please run 'Install-Module -Name Az.PostgreSql' to install and continue."
            throw $message
        }
    }
}

function CheckKeyVaultModuleDependency {
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
    param() 

    process {
        $module = Get-Module -ListAvailable | Where-Object { $_.Name -eq "Az.KeyVault" }
        if ($module -eq $null) {
            $message = "Az.KeyVault Module must be installed to run this command. Please run 'Install-Module -Name Az.KeyVault' to install and continue."
            throw $message
        }
    }
}

function CheckAksModuleDependency {
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
    param() 

    process {
        $module = Get-Module -ListAvailable | Where-Object { $_.Name -eq "Az.Aks" }
        if ($module -eq $null) {
            $message = "Az.Aks Module must be installed to run this command. Please run 'Install-Module -Name Az.Aks' to install and continue."
            throw $message
        }
    }
}

function AssignMissingRolesHelper {
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        [System.String]
        ${ObjectId},

        [Parameter(Mandatory)]
        [System.String]
        ${Permission},

        [Parameter(Mandatory)]
        [System.String]
        ${ResourceScope}
    )

    process {
        Write-Debug "Assigning new role for ObjectId, RoleDefinitionName, Scope: "
        Write-Debug $ObjectId
        Write-Debug $Permission
        Write-Debug $ResourceGroup        

        try { 
            New-AzRoleAssignment -ObjectId $ObjectId -RoleDefinitionName $Permission -Scope $ResourceScope | Out-Null 
        }
         
        catch {
            $err = $_
            if ($err.Exception.Message -eq "Operation returned an invalid status code 'Forbidden'") {
                $err = "User doesn't have sufficient privileges for performing Grant permissions."
            }
            throw $err 
        }
    }
}

function AssignMissingRoles {
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        [System.String]
        ${ObjectId},

        [Parameter(Mandatory)]
        [System.String]
        ${Permission},

        [Parameter(Mandatory)]
        [System.String]
        ${PermissionsScope},

        [Parameter(Mandatory)]
        [System.String]
        ${Resource},

        [Parameter(Mandatory)]
        [System.String]
        ${ResourceGroup},

        [Parameter(Mandatory)]
        [System.String]
        ${Subscription}
    )

    process {

        if ($PermissionsScope -eq "Resource") {
            AssignMissingRolesHelper -ObjectId $ObjectId -Permission $Permission -ResourceScope $Resource
        }

        elseif ($PermissionsScope -eq "ResourceGroup") {
            AssignMissingRolesHelper -ObjectId $ObjectId -Permission $Permission -ResourceScope $ResourceGroup
        }

        else {
            AssignMissingRolesHelper -ObjectId $ObjectId -Permission $Permission -ResourceScope $Subscription
        }
    }
}

function GetBackupInstanceARGQuery {
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
    param()

    process {
        $query = "RecoveryServicesResources | where type =~ 'microsoft.dataprotection/backupvaults/backupinstances'"
        $query += "| extend vaultName = split(split(id, '/Microsoft.DataProtection/backupVaults/')[1],'/')[0]"
        $query += "| extend protectionState = properties.currentProtectionState"

        return $query
    }
}

function GetBackupJobARGQuery {
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
    param()

    process {
        $query = "RecoveryServicesResources | where type =~ 'microsoft.dataprotection/backupvaults/backupjobs'"
        $query += "| extend vaultName = properties.vaultName"
        $query += "| extend status = properties.status"
        $query += "| extend operation = case( tolower(properties.operationCategory) startswith 'backup' and properties.isUserTriggered == 'true', strcat('OnDemand',properties.operationCategory)"
        $query += ", tolower(properties.operationCategory) startswith 'backup' and properties.isUserTriggered == 'false', strcat('Scheduled', properties.operationCategory)"
        $query += ", type =~ 'microsoft.dataprotection/backupVaults/backupJobs', properties.operationCategory, 'Invalid')"

        return $query
    }
}
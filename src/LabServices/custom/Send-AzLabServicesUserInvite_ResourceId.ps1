function Send-AzLabServicesUserInvite_ResourceId {
    [OutputType([System.Boolean])]
    [CmdletBinding(PositionalBinding=$false)]
    param(
        [Parameter(Mandatory)]
        [System.String]
        ${ResourceId},

        [Parameter()]
        [System.String]
        ${Text},

        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob}
    )
    
    process {
        $resourceHash = & $PSScriptRoot\Utilities\HandleUserResourceId.ps1 -ResourceId $ResourceId
        if ($resourceHash) {
            $resourceHash.Keys | ForEach-Object {
                $PSBoundParameters.Add($_, $($resourceHash[$_]))
            }
            $PSBoundParameters.Remove("ResourceId") > $null
        
            return Az.LabServices\Send-AzLabServicesUserInvite @PSBoundParameters
        } else {
            Write-Error -Message "Error: Invalid User Resource Id." -ErrorAction Stop
        }

    }
    
    }
    
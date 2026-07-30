function Get-AzChangeSafetyStageMap_GetByNameFallback {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IStageMap])]
    [CmdletBinding(PositionalBinding = $false)]
    param(
        [Parameter(Mandatory)]
        [Alias('StageMapName')]
        [string]
        $Name,

        [Parameter()]
        [string[]]
        $SubscriptionId,

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [System.Management.Automation.PSObject]
        $DefaultProfile,

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        $Break,

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Runtime.SendAsyncStep[]]
        $HttpPipelineAppend,

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Runtime.SendAsyncStep[]]
        $HttpPipelinePrepend,

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Category('Runtime')]
        [System.Uri]
        $Proxy,

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        $ProxyCredential,

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        $ProxyUseDefaultCredentials
    )

    process {
        $params = @{}
        foreach ($parameterName in @('Name', 'SubscriptionId', 'DefaultProfile', 'Break', 'HttpPipelineAppend', 'HttpPipelinePrepend', 'Proxy', 'ProxyCredential', 'ProxyUseDefaultCredentials')) {
            if ($PSBoundParameters.ContainsKey($parameterName)) {
                $params[$parameterName] = $PSBoundParameters[$parameterName]
            }
        }

        $getError = $null
        try {
            $result = Az.ChangeSafety.private\Get-AzChangeSafetyStageMap_Get1 @params -ErrorAction Stop
            if ($null -ne $result) {
                $result
                return
            }
        } catch {
            $getError = $_
            if ($getError.Exception.Message -notmatch 'could not be found|NotFound|404') {
                throw
            }
        }

        $listParams = @{}
        foreach ($parameterName in @('SubscriptionId', 'DefaultProfile', 'Break', 'HttpPipelineAppend', 'HttpPipelinePrepend', 'Proxy', 'ProxyCredential', 'ProxyUseDefaultCredentials')) {
            if ($PSBoundParameters.ContainsKey($parameterName)) {
                $listParams[$parameterName] = $PSBoundParameters[$parameterName]
            }
        }

        $matchingStageMap = Az.ChangeSafety.private\Get-AzChangeSafetyStageMap_List1 @listParams -ErrorAction Stop |
            Where-Object { $_.Name -eq $Name }

        if ($null -eq $matchingStageMap) {
            if ($null -eq $getError) {
                throw "The StageMap '$Name' could not be found."
            }

            throw $getError
        }

        $matchingStageMap
    }
}

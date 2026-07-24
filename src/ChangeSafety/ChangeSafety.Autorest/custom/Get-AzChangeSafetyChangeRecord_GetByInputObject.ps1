function Get-AzChangeSafetyChangeRecord_GetByInputObject {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeRecord])]
    [CmdletBinding(PositionalBinding = $false)]
    param(
        [Parameter(Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeRecord]
        $ChangeRecordInputObject,

        [Parameter()]
        [string[]]
        $SubscriptionId,

        [Parameter()]
        [string]
        $ResourceGroupName,

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
        $name = [string]$ChangeRecordInputObject.Name
        if ([string]::IsNullOrWhiteSpace($name)) {
            throw "The ChangeRecord input object must contain a Name value."
        }

        $resourceId = [string]$ChangeRecordInputObject.Id
        if (-not $PSBoundParameters.ContainsKey('ResourceGroupName') -and $resourceId -match '/resourceGroups/([^/]+)/') {
            $ResourceGroupName = [System.Uri]::UnescapeDataString($Matches[1])
        }

        $params = @{ Name = $name }
        foreach ($parameterName in @('SubscriptionId', 'DefaultProfile', 'Break', 'HttpPipelineAppend', 'HttpPipelinePrepend', 'Proxy', 'ProxyCredential', 'ProxyUseDefaultCredentials')) {
            if ($PSBoundParameters.ContainsKey($parameterName)) {
                $params[$parameterName] = $PSBoundParameters[$parameterName]
            }
        }

        if (-not $params.ContainsKey('SubscriptionId') -and $resourceId -match '/subscriptions/([^/]+)/') {
            $params['SubscriptionId'] = @([System.Uri]::UnescapeDataString($Matches[1]))
        }

        if ([string]::IsNullOrWhiteSpace($ResourceGroupName)) {
            Az.ChangeSafety.private\Get-AzChangeSafetyChangeRecord_Get @params
            return
        }

        $params['ResourceGroupName'] = $ResourceGroupName
        Az.ChangeSafety.private\Get-AzChangeSafetyChangeRecord_Get1 @params
    }
}

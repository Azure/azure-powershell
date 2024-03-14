function Get-ResourceId-Array {
    [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IResourceMetadata[]]
        $Resources
    )
    $Result = [System.Collections.Generic.List[object]]::new()
    foreach ($Resource in $Resources) {
        $Result.Add($Resource.ResourceId)
    }
    return $Result.ToArray()
}

function Get-Resource-Subscriptions {
    [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        [string[]]
        $Resources
    )
    $SubscriptionSet = [Collections.Generic.HashSet[string]]@()
    foreach ($Resource in $Resources) {
        try {
            $Strs = $Resource.Split("/")
            if ($Strs.Count -lt 3) {
                Write-Error "Please input valid resource ids"
            }
            $null = $SubscriptionSet.Add($Strs[2])
        }
        catch {
            Write-Error "Please input valid resource ids"
        }
    }
    $Result = New-Object string[] $SubscriptionSet.Count
    $null = $SubscriptionSet.CopyTo($Result)
    return $Result
}

function Get-Nearest-Time {
    [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.DoNotExportAttribute()]
    param()
    $RoundedDate = Get-Date -Minute 0 -Second 0 -Millisecond 0
    return $RoundedDate.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffK")
}

function Get-Token {
    [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.DoNotExportAttribute()]
    param()
    return "Bearer " + (Get-AzAccessToken).Token
}

function Add-Custom-Header {
    [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        $PSBoundParameters
    )
    if (-Not $PSBoundParameters.ContainsKey('XmsAadUserToken')) {
        $PSBoundParameters['XmsAadUserToken'] = Get-Token
    }
    return $PSBoundParameters
}

function Get-Runtime-Parameters {
    [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        $PSBoundParameters
    )
    $Object = @{}
    if ($PSBoundParameters.ContainsKey('XmsAadUserToken')) {
        $Object['Break'] = $PSBoundParameters.Break
    }
    if ($PSBoundParameters.ContainsKey('HttpPipelineAppend')) {
        $Object['HttpPipelineAppend'] = $PSBoundParameters.HttpPipelineAppend
    }
    if ($PSBoundParameters.ContainsKey('HttpPipelinePrepend')) {
        $Object['HttpPipelinePrepend'] = $PSBoundParameters.HttpPipelinePrepend
    }
    if ($PSBoundParameters.ContainsKey('Proxy')) {
        $Object['Proxy'] = $PSBoundParameters.Proxy
    }
    if ($PSBoundParameters.ContainsKey('ProxyCredential')) {
        $Object['ProxyCredential'] = $PSBoundParameters.ProxyCredential
    }
    if ($PSBoundParameters.ContainsKey('ProxyUseDefaultCredentials')) {
        $Object['ProxyUseDefaultCredentials'] = $PSBoundParameters.ProxyUseDefaultCredentials
    }
    return $Object
}

function Get-FilteredControlAssessments {
    [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.ICategory[]]
        $Categories,

        [Parameter(Mandatory)]
        $ComplianceStatus
    )

    $Results = [System.Collections.Generic.List[object]]::new()
    foreach ($Category in $Categories) {

        $FilteredFamilies = [System.Collections.Generic.List[object]]::new()
        foreach ($Family in $Category.ControlFamily) {

            $FilteredControls = [System.Collections.Generic.List[object]]::new()
            foreach ($Control in $Family.Control) {

                if ($Control.Status -eq $ComplianceStatus) {
                    $FilteredControls.Add($Control)
                }
            }

            $NewFamily = @{
                Name    = $Family.Name
                Status  = $Family.Status
                Control = $FilteredControls
            }
            $NewFamily.Control = $FilteredControls.ToArray()
            if ($FilteredControls.Count) {
                $FilteredFamilies.Add($NewFamily)
            }
        }

        $NewCategory = @{
            Name          = $Category.Name
            Status        = $Category.Status
            ControlFamily = $FilteredFamilies
        }
        $NewCategory.ControlFamily = $FilteredFamilies.ToArray()
        if ($FilteredFamilies.Count) {
            $DeserializedCategory = [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.Category]::DeserializeFromDictionary($NewCategory)
            $Results.Add($DeserializedCategory)
        }
    }
    $Results.ToArray()
}

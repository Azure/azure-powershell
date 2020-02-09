$AllParameterSets = '__AllParameterSets'
$CommonParameterList = @('Verbose', 'Debug', 'ErrorAction', 'WarningAction', 'InformationAction', 'ErrorVariable', 'WarningVariable', 'InformationVariable', 'OutVariable', 'OutBuffer', 'PipelineVariable', 'WhatIf', 'Confirm')

function Get-CmdletBindingPropertyValue
{
    [CmdletBinding()]
    param (
        [Parameter()]
        [System.Management.Automation.CommandInfo]
        $Cmdlet,
        [Parameter()]
        [string]
        $PropertyName
    )
    if ($Cmdlet.CommandType -eq 'Function')
    {
        foreach ($Attribute in $Cmdlet.ScriptBlock.Attributes)
        {
            if ($Attribute.TypeId.FullName -eq 'System.Management.Automation.CmdletBindingAttribute')
            {
                if ($PropertyName -in $Attribute.PSobject.Properties.Name)
                {
                    return Select-Object -InputObject $Attribute -ExpandProperty $PropertyName
                }
                return $null
            }
            return $null
        }
    }
    elseif ($Cmdlet.CommandType -eq 'Cmdlet')
    {
        foreach ($Attribute in $Cmdlet.ImplementingType.CustomAttributes)
        {
            if ($Attribute.AttributeType.FullName -eq 'System.Management.Automation.CmdletAttribute')
            {
                foreach ($Property in $Attribute.NamedArguments)
                {
                    if ($Property.MemberName -eq $PropertyName)
                    {
                        return $Property.TypedValue.Value
                    }
                }
                return $null
            }
        }
    }
    return $null
}

function Get-CmdletConfirmImpact
{
    [CmdletBinding()]
    param (
        [Parameter()]
        [System.Management.Automation.CommandInfo]
        $Cmdlet
    )

    $ConfirmImpact = Get-CmdletBindingPropertyValue $Cmdlet "ConfirmImpact"
    # Enum is here: https://docs.microsoft.com/en-us/dotnet/api/system.management.automation.confirmimpact?view=pscore-6.2.0
    switch ($ConfirmImpact)
    {
        'None' {return 0}
        'Low' {return 1}
        'Medium' {return 2}
        'High' {return 3}
    }
    return 2 # Default is Medium
}

function Get-CmdletSupportsShouldProcess
{
    [CmdletBinding()]
    param (
        [Parameter()]
        [System.Management.Automation.CommandInfo]
        $Cmdlet
    )
    return Get-CmdletBindingPropertyValue $Cmdlet "SupportsShouldProcess"
}

function Get-CmdletSupportsPaging
{
    [CmdletBinding()]
    param (
        [Parameter()]
        [System.Management.Automation.CommandInfo]
        $Cmdlet
    )
    return Get-CmdletBindingPropertyValue $Cmdlet "SupportsPaging"
}

function Get-OutputTypeMetadata
{
    [CmdletBinding()]
    param (
        [Parameter()]
        [System.Management.Automation.CommandInfo]
        $Cmdlet
    )
    $OutputMetadataList = New-Object System.Collections.Generic.List[Tools.Common.Models.OutputMetadata]
    
    foreach ($Output in $Cmdlet.OutputType)
    {
        $OutputMetadata = [Tools.Common.Models.OutputMetadata]::new()
        $OutputMetadata.Type = [Tools.Common.Models.TypeMetadata]::New($Output.Type)
        $OutputMetadataList.Add($OutputMetadata)
    }

    return $OutputMetadataList
}

function Get-ParameterMetadata
{
    [CmdletBinding()]
    param (
        [Parameter()]
        [System.Management.Automation.CommandInfo]
        $Cmdlet,
        [Parameter()]
        [Tools.Common.Models.CmdletMetadata]
        $CmdletMetadata
    )
    $ParameterMetadataList = New-Object System.Collections.Generic.List[Tools.Common.Models.ParameterMetadata]

    $GlobalParameters = New-Object System.Collections.Generic.List[Tools.Common.Models.Parameter]
    foreach ($Parameter in $Cmdlet.Parameters.Values)
    {
        if ($Parameter.Name -in $CommonParameterList)
        {
            continue
        }
        if ($Parameter.Name -eq "Force" -or $Parameter.SwitchParameter -eq $true)
        {
            $CmdletMetadata.HasForceSwitch = $true
        }
        $ParameterMetadata = New-Object Tools.Common.Models.ParameterMetadata
        $ParameterMetadata.Name = $Parameter.Name
        $ParameterMetadata.Type = [Tools.Common.Models.TypeMetadata]::New($Parameter.ParameterType)
        $ParameterMetadata.AliasList.AddRange($Parameter.Aliases)
        $ParameterMetadata.ValidateNotNullOrEmpty = $false
        foreach ($Attribute in $Parameter.Attributes)
        {
            if ($Attribute.TypeId.FullName -eq 'System.Management.Automation.ValidateSetAttribute')
            {
                $ParameterMetadata.ValidateSet.AddRange($Attribute.ValidValues)
            }
            elseif ($Attribute.TypeId.FullName -eq 'System.Management.Automation.ValidateRangeAttribute')
            {
                $ParameterMetadata.ValidateRangeMin = $Attribute.MinRange
                $ParameterMetadata.ValidateRangeMax = $Attribute.MaxRange
            }
            elseif ($Attribute.TypeId.FullName -eq 'System.Management.Automation.ValidateNotNullOrEmptyAttribute')
            {
                $ParameterMetadata.ValidateNotNullOrEmpty = $true
            }
            elseif ($Attribute.TypeId.FullName -eq 'System.Management.Automation.ParameterAttribute')
            {
                $ParameterSetName = $AllParameterSets
                if ($null -ne $Attribute.ParameterSetName)
                {
                    $ParameterSetName = $Attribute.ParameterSetName
                }
                $ParameterSetMetadata = [Tools.Common.Models.ParameterSetMetadata]::New()
                $ParameterSetMetadata.Name = $ParameterSetName
                foreach ($PSM in $CmdletMetadata.ParameterSets)
                {
                    if ($PSM.Name -eq $ParameterSetName)
                    {
                        $ParameterSetMetadata = $PSM
                        break
                    }
                }
                $Param = [Tools.Common.Models.Parameter]::New()
                $Param.ParameterMetadata = $ParameterMetadata
                $Param.Mandatory = $Attribute.Mandatory
                $Param.Position = $Attribute.Position
                $Param.ValueFromPipeline = $Attribute.ValueFromPipeline
                $Param.ValueFromPipelineByPropertyName = $Attribute.ValueFromPipelineByPropertyName
                $ParameterSetMetadata.Parameters.Add($Param)
                if ($ParameterSetMetadata.Parameters.Count -eq 1)
                {
                    $CmdletMetadata.ParameterSets.Add($ParameterSetMetadata)
                }
                if ($ParameterSetName -eq $AllParameterSets)
                {
                    $GlobalParameters.Add($Param)
                }
            }
        }
        $ParameterMetadataList.Add($ParameterMetadata)
    }

    foreach ($ParameterSetMetadata in $CmdletMetadata.ParameterSets)
    {
        if ($ParameterSetMetadata.Name -ne $AllParameterSets)
        {
            foreach ($Param in $GlobalParameters)
            {
                $InsertFlag = $true
                foreach ($P in $ParameterSetMetadata.Parameters)
                {
                    if ($P.ParameterMetadata.Name -eq $Param.ParameterMetadata.Name)
                    {
                        $InsertFlag = $false
                    }
                }
                if ($InsertFlag)
                {
                    $ParameterSetMetadata.Parameters.Add($Param)
                }
            }
        }
    }

    return $ParameterMetadataList
}

function Get-AliasList
{
    [CmdletBinding()]
    param (
        [Parameter()]
        [System.Management.Automation.CommandInfo]
        $Cmdlet,
        [Parameter()]
        [System.Management.Automation.AliasInfo[]]
        $AliasList
    )
    $AliasNameList = New-Object System.Collections.Generic.List[string]
    foreach ($Alias in $AliasList)
    {
        $ReferencedCommand = $Alias.ReferencedCommand
        if ($ReferencedCommand.Name -eq $Cmdlet.Name)
        {
            $AliasNameList.Add($Alias.Name)
        }
    }
    return $AliasNameList
}

function Get-ModuleMetadata
{
    [CmdletBinding()]
    param (
        [Parameter()]
        [PsModuleInfo]
        $ModuleInfo
    )

    $CurrentPath = Get-Location
    $Assembly = [Reflection.Assembly]::LoadFile($CurrentPath.Path + "\Tools.Common\bin\Debug\netstandard2.0\Tools.Common.dll")
    $ModuleMetadata = [Tools.Common.Loaders.CmdletLoader]::GetModuleMetadata()
    foreach ($Cmdlet in $ModuleInfo.ExportedCmdlets.Values + $ModuleInfo.ExportedFunctions.Values)
    {
        Write-Host $cmdlet -ForegroundColor Green
        $CmdletMetadata = New-Object Tools.Common.Models.CmdletMetadata
        $CmdletMetadata.VerbName = $Cmdlet.Verb
        $CmdletMetadata.NounName = $Cmdlet.Noun

        $CmdletMetadata.SupportsShouldProcess = Get-CmdletSupportsShouldProcess $Cmdlet
        $CmdletMetadata.ConfirmImpact = Get-CmdletConfirmImpact $Cmdlet
        $CmdletMetadata.SupportsPaging = Get-CmdletSupportsPaging $Cmdlet
        if ($null -ne $Cmdlet.DefaultParameterSet -and $Cmdlet.DefaultParameterSet -ne "")
        {
            $CmdletMetadata.DefaultParameterSetName = $Cmdlet.DefaultParameterSet
        }
        else
        {
            $CmdletMetadata.DefaultParameterSetName = $AllParameterSets
        }
        if ($null -ne $Cmdlet.ImplementingType)
        {
            $CmdletMetadata.ClassName = $Cmdlet.ImplementingType.FullName
        }

        [System.Collections.Generic.List[Tools.Common.Models.OutputMetadata]]$OutputMetadataList = Get-OutputTypeMetadata $Cmdlet
        if ($OutputMetadataList.Count -ne 0)
        {
            $CmdletMetadata.OutputTypes.AddRange($OutputMetadataList)
        }
        [System.Collections.Generic.List[Tools.Common.Models.ParameterMetadata]]$ParameterMetadataList = Get-ParameterMetadata $Cmdlet $CmdletMetadata
        if ($ParameterMetadataList.Count -ne 0)
        {
            $CmdletMetadata.Parameters.AddRange($ParameterMetadataList)
        }
        [System.Collections.Generic.List[string]]$AliasList = Get-AliasList $Cmdlet $ModuleInfo.ExportedAliases.Values
        if ($AliasList.Count -ne 0)
        {
            $CmdletMetadata.AliasList.AddRange($AliasList)
        }

        $ModuleMetadata.Cmdlets.Add($CmdletMetadata)
    }
    return $ModuleMetadata
}

function Get-ModuleMetadataFromDotNet
{
    [CmdletBinding()]
    param (
        [Parameter()]
        [string]
        $DllPath
    )
    $proxy = [Tools.Common.Loaders.CmdletLoader]::new()
    return $proxy.GetModuleMetadata($DllPath)
}


# Import-Module C:\Users\yunwang\source\repos\wyunchi-ms\azure-powershell\artifacts\Debug\Az.Accounts\Az.Accounts.psd1
# $ModuleInfo = Get-Module Az.Accounts
# $ModuleMetadata = Get-ModuleMetadata $ModuleInfo
# ConvertTo-Json -InputObject $ModuleMetadata -depth 100 | Out-File "b.json"

# Import-Module C:\Users\yunwang\source\repos\wyunchi-ms\azure-powershell-generation\src\Dns\bin\Az.Dns.4.0.2-preview\Az.Dns.psd1

# Select-AzProfile -Name 'hybrid-2019-03-01'
# $ModuleInfo = Get-Module Az.Dns
# $ModuleMetadata = Get-ModuleMetadata $ModuleInfo
# ConvertTo-Json -InputObject $ModuleMetadata -depth 100 | Out-File "a.json"

# Select-AzProfile -Name 'latest-2019-04-30'
# $ModuleInfo = Get-Module Az.Dns
# $ModuleMetadata = Get-ModuleMetadata $ModuleInfo
# ConvertTo-Json -InputObject $ModuleMetadata -depth 100 | Out-File "c.json"

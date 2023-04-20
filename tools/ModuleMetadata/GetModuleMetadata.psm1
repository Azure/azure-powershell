# ----------------------------------------------------------------------------------
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

Using Module 'Models/Class.psm1'
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
        $Cmdlet,
        [Parameter()]
        [ModuleMetadata]
        $ModuleMetadata
    )
    $OutputMetadataList = [System.Collections.Generic.List[OutputMetadata]]::New()
    
    if ('Function' -eq $Cmdlet.CommandType)
    {
        foreach ($OutputType in $Cmdlet.OutputType)
        {
            $OutputMetadata = [OutputMetadata]::new()
            $OutputMetadata.Type = [TypeMetadata]::New($OutputType.Type, $ModuleMetadata)
            if ($Null -eq $OutputType.ParameterSetName)
            {
                $OutputMetadata.ParameterSets = @('__AllParameterSets')
            }
            else
            {
                $OutputMetadata.ParameterSets = $OutputType.ParameterSetName
            }
            $OutputMetadataList.Add($OutputMetadata)
        }
    }
    else
    {
        $OutputAttributeList = $Cmdlet.ImplementingType.GetTypeInfo().GetCustomAttributes([System.Management.Automation.OutputTypeAttribute], $true)
        foreach ($OutputAttribute in $OutputAttributeList)
        {
            foreach ($OutputType in $OutputAttribute.Type)
            {
                $OutputMetadata = [OutputMetadata]::new()
                $OutputMetadata.Type = [TypeMetadata]::New($OutputType.Type, $ModuleMetadata)
                if ($Null -eq $OutputType.ParameterSetName)
                {
                    $OutputMetadata.ParameterSets = @('__AllParameterSets')
                }
                else
                {
                    $OutputMetadata.ParameterSets = $OutputType.ParameterSetName
                }
                $OutputMetadataList.Add($OutputMetadata)
            }
        }
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
        [CmdletMetadata]
        $CmdletMetadata,
        [Parameter()]
        [ModuleMetadata]
        $ModuleMetadata
    )
    $ParameterMetadataList = [System.Collections.Generic.List[ParameterMetadata]]::New()

    $GlobalParameters = [System.Collections.Generic.List[ParameterMetadataInParameterSet]]::New()
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
        $ParameterMetadata = [ParameterMetadata]::New()
        $ParameterMetadata.Name = $Parameter.Name
        $ParameterMetadata.Type = [TypeMetadata]::New($Parameter.ParameterType, $ModuleMetadata, $true)
        $ParameterMetadata.AliasList.AddRange($Parameter.Aliases)
        $ParameterMetadata.ValidateNotNullOrEmpty = $false
        foreach ($Attribute in $Parameter.Attributes)
        {
            if ($Attribute.TypeId.FullName -eq 'System.Management.Automation.ValidateSetAttribute')
            {
                if (-not $Parameter.IsDynamic)
                {
                    $ParameterMetadata.ValidateSet.AddRange($Attribute.ValidValues)
                }
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
                $ParameterSetMetadata = [ParameterSetMetadata]::New()
                $ParameterSetMetadata.Name = $ParameterSetName
                foreach ($PSM in $CmdletMetadata.ParameterSets)
                {
                    if ($PSM.Name -eq $ParameterSetName)
                    {
                        $ParameterSetMetadata = $PSM
                        break
                    }
                }
                $Param = [ParameterMetadataInParameterSet]::New()
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
    $AliasNameList = [System.Collections.Generic.List[string]]::New()
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
        [String]
        $Psd1Path,
        [Parameter()]
        [String]
        $ModuleName
    )

    Write-Host $Psd1Path
    Import-Module $Psd1Path -Force
    $ModuleInfo = Get-Module $ModuleName
    $ModuleMetadata = [ModuleMetadata]::New()
    foreach ($Cmdlet in $ModuleInfo.ExportedCmdlets.Values + $ModuleInfo.ExportedFunctions.Values)
    {
        $CmdletMetadata = [CmdletMetadata]::New()
        $CmdletMetadata.VerbName = $Cmdlet.Verb
        $CmdletMetadata.NounName = $Cmdlet.Noun
        $CmdletMetadata.Name = "$($Cmdlet.Verb)-$($Cmdlet.Noun)"

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
        else
        {
            $CmdletMetadata.ClassName = $CmdletMetadata.Name
        }

        [System.Collections.Generic.List[OutputMetadata]]$OutputMetadataList = Get-OutputTypeMetadata -Cmdlet $Cmdlet -ModuleMetadata $ModuleMetadata
        if ($OutputMetadataList.Count -ne 0)
        {
            $CmdletMetadata.OutputTypes.AddRange($OutputMetadataList)
        }
        [System.Collections.Generic.List[ParameterMetadata]]$ParameterMetadataList = Get-ParameterMetadata -Cmdlet $Cmdlet -CmdletMetadata $CmdletMetadata -ModuleMetadata $ModuleMetadata
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

function Export-ModuleMetadata
{
    [CmdletBinding()]
    param (
        [Parameter()]
        [String[]]
        $ModuleList,
        [Parameter()]
        [String]
        $Configuration
    )
    Write-Host "=============================="
    Write-Host $ModuleList
    Write-Host "=============================="
    $ArtifactsPath = [System.IO.Path]::Combine($PSScriptRoot, "..", "..", "artifacts", $Configuration)
    foreach ($Module in $ModuleList.Split(";"))
    {
        $Path = [System.IO.Path]::Combine($ArtifactsPath, "Az.$Module")
        
        if (!(Test-Path -Path $Path))
        {
            Write-Error "Fail to find path: $Path"
        }
        $Psd1Path = (Get-ChildItem -Path $Path -Filter *.psd1)[0].FullName
        $ModuleName = $Psd1Path.replace('\', '/').Split('/')[-1].replace('.psd1', '')

        $ModuleMetadata = Get-ModuleMetadata -Psd1Path $Psd1Path -ModuleName $ModuleName
        
        $DumpJsonPath = [System.IO.Path]::Combine($Path, "$ModuleName.json")
        $ModuleMetadata.ToJsonString() | Out-File $DumpJsonPath
    }
}

Export-ModuleMember -Function Export-ModuleMetadata
Export-ModuleMember -Function Get-ModuleMetadata

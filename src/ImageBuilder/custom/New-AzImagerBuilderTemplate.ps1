
# ----------------------------------------------------------------------------------
#
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

<#
.Synopsis
Create a virtual machine image template
.Description
Create a virtual machine image template

.Link
https://docs.microsoft.com/powershell/module/az.imagebuilder/New-AzImageBuilderTemplate
#>
function New-AzImageBuilderTemplate {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplate])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium', DefaultParameterSetName="FlattenParameterSet")]
    param(
        [Parameter(Mandatory, HelpMessage="The name of the image Template.")]
        [Alias('Name')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Path')]
        [System.String]
        # The name of the image Template
        ${ImageTemplateName},
    
        [Parameter(Mandatory, HelpMessage="The name of the resource group.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Path')]
        [System.String]
        # The name of the resource group.
        ${ResourceGroupName},
    
        [Parameter(HelpMessage="Subscription credentials which uniquely identify Microsoft Azure subscription.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription Id forms part of the URI for every service call.
        ${SubscriptionId},
    
        [Parameter(ParameterSetName='JsonTemplate', HelpMessage="Path of json formated image template file.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [System.String]
        ${JsonTemplatePath},
    
        [Parameter(ParameterSetName='FlattenParameterSet', HelpMessage="Resource location.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [System.String]
        # Resource location
        ${Location},
    
        [Parameter(ParameterSetName='FlattenParameterSet', HelpMessage="Maximum duration to wait while building the image template. Omit or specify 0 to use the default (4 hours).")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [System.Int32]
        # Maximum duration to wait while building the image template.
        # Omit or specify 0 to use the default (4 hours).
        ${BuildTimeoutInMinute},
    
        [Parameter(ParameterSetName='FlattenParameterSet', HelpMessage="Specifies the properties used to describe the customization steps of the image, like Image source etc.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer[]]
        # Specifies the properties used to describe the customization steps of the image, like Image source etc
        # To construct, see NOTES section for CUSTOMIZE properties and create a hash table.
        ${Customize},
    
        [Parameter(Mandatory, ParameterSetName='FlattenParameterSet', HelpMessage="The distribution targets where the image output needs to go to.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributor[]]
        # The distribution targets where the image output needs to go to.
        # To construct, see NOTES section for DISTRIBUTE properties and create a hash table.
        ${Distribute},

        [Parameter(Mandatory, ParameterSetName='FlattenParameterSet', HelpMessage="Describes a virtual machine image source for building, customizing and distributing.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSource]
        ${Source},
    
        [Parameter(Mandatory, ParameterSetName='FlattenParameterSet', HelpMessage="The id of user assigned identity.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateIdentityUserAssignedIdentities]))]
        [System.String]
        # The id of user assigned identity.
        # The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        ${UserAssignedIdentityId},
    
        [Parameter(ParameterSetName='FlattenParameterSet', HelpMessage="Resource tags.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceTags]))]
        [System.Collections.Hashtable]
        # Resource tags
        ${Tag},
    
        [Parameter(ParameterSetName='FlattenParameterSet', HelpMessage="Size of the OS disk in GB. Omit or specify 0 to use Azure's default OS disk size.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [System.Int32]
        # Size of the OS disk in GB.
        # Omit or specify 0 to use Azure's default OS disk size.
        ${VMProfileOsdiskSizeInGb},
    
        [Parameter(ParameterSetName='FlattenParameterSet', HelpMessage="Size of the virtual machine used to build, customize and capture images. Omit or specify empty string to use the default (Standard_D1_v2).")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [System.String]
        # Size of the virtual machine used to build, customize and capture images.
        # Omit or specify empty string to use the default (Standard_D1_v2).
        ${VMProfileVmSize},
    
        [Parameter(ParameterSetName='FlattenParameterSet', HelpMessage="Resource id of a pre-existing subnet.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [System.String]
        # Resource id of a pre-existing subnet.
        ${VnetConfigSubnetId},
    
        #region HideParameter
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
        #endregion HideParameter
    )
    
    process {
        try {
            $Parameter = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplate]::New()

            if ($PSBoundParameters.ContainsKey('JsonTemplatePath'))
            {
                if (-not (Test-Path $JsonTemplatePath))
                {
                    Write-Error "Cannot find file $JsonTemplatePath. Please make sure it exists!"
                    exit 1
                }
                $TemplateContent = Get-Content $JsonTemplatePath | ConvertFrom-Json
                $Parameter.Location = $TemplateContent.Location
                $Parameter.BuildTimeoutInMinute = $TemplateContent.properties.buildTimeoutInMinutes
                $Parameter.Source = New-SourceObjectFromJson $TemplateContent.properties.source
                $Parameter.Customize = New-CustomizeArrayFromJson $TemplateContent.properties.customize
                $Parameter.Distribute = New-DistributeArrayFromJson $TemplateContent.properties.distribute
                $Parameter.Identity = New-IdentityObjectFromJson $TemplateContent.identity
                $Parameter.VMProfile = New-VMProfileObjectFromJson $TemplateContent.properties.vmProfile
                $Null = $PSBoundParameters.Remove('JsonTemplatePath')
                $Tag = @{}
                foreach ($property in $TemplateContent.tags.PSObject.Properties) {
                    $Tag[$property.Name] = $property.Value
                }
                $Parameter.Tag = $Tag
            }
            else
            {
                $Parameter.Source = $Source
                $Null = $PSBoundParameters.Remove('Source')
    
                if ($PSBoundParameters.ContainsKey('Location')) {
                    $Parameter.Location = $Location
                    $Null = $PSBoundParameters.Remove('Location')
                }
                if ($PSBoundParameters.ContainsKey('Tag')) {
                    $Parameter.Tag = $Tag
                    $Null = $PSBoundParameters.Remove('Tag')
                }
                if ($PSBoundParameters.ContainsKey('BuildTimeoutInMinute')) {
                    $Parameter.BuildTimeoutInMinute = $BuildTimeoutInMinute
                    $Null = $PSBoundParameters.Remove('BuildTimeoutInMinute')
                }
                if ($PSBoundParameters.ContainsKey('Customize')) {
                    $Parameter.Customize = $Customize
                    $Null = $PSBoundParameters.Remove('Customize')
                }
                if ($PSBoundParameters.ContainsKey('Distribute')) {
                    $Parameter.Distribute = $Distribute
                    $Null = $PSBoundParameters.Remove('Distribute')
                }
                $Parameter.IdentityType = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ResourceIdentityType]::UserAssigned
                $UserAssignedIdentities = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateIdentityUserAssignedIdentities]::new()
                $UserassignedidentitiesAdditionalproperties = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ComponentsVrq145SchemasImagetemplateidentityPropertiesUserassignedidentitiesAdditionalproperties](@{})
                $UserAssignedIdentities.Add($UserAssignedIdentityId, $UserassignedidentitiesAdditionalproperties)
                $Parameter.IdentityUserAssignedIdentity = $UserAssignedIdentities
                $Null = $PSBoundParameters.Remove('UserAssignedIdentityId')

                if ($PSBoundParameters.ContainsKey('VMProfileOsdiskSizeInGb')) {
                    $Parameter.VMProfileOsdiskSizeGb = $VMProfileOsdiskSizeInGb
                    $null = $PSBoundParameters.Remove('VMProfileOsdiskSizeInGb')
                }
                if ($PSBoundParameters.ContainsKey('VMProfileVmSize')) {
                    $Parameter.VMProfileVmsize = $VMProfileVmSize
                    $Null = $PSBoundParameters.Remove('VMProfileVmSize')
                }
                if ($PSBoundParameters.ContainsKey('VnetConfigSubnetId')) {
                    $Parameter.VnetConfigSubnetId = $VnetConfigSubnetId
                    $Null = $PSBoundParameters.Remove('VnetConfigSubnetId')
                }
            }

            $PSBoundParameters.Add("Parameter", $Parameter)
            Az.ImageBuilder.internal\New-AzImageBuilderTemplate @PSBoundParameters
        } catch {
            throw
        }
    }
}

function New-SourceObjectFromJson
{
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSource])]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.DoNotExportAttribute()]
    param(
        [Parameter()]
        [object]
        ${Source}
    )
    if ($Source.type -eq 'PlatformImage')
    {
        return [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplatePlatformImageSource]::DeserializeFromPSObject($Source)
    }
    elseif ($Source.type -eq 'ManagedImage')
    {
        return [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateManagedImageSource]::DeserializeFromPSObject($Source)
    }
    elseif ($Source.type -eq 'SharedImageVersion')
    {
        return [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateSharedImageVersionSource]::DeserializeFromPSObject($Source)
    }
    $ErrorMessage = "Unkown type: " + $Source.type + " for source!"
    Write-Error $ErrorMessage
}

function New-CustomizeArrayFromJson
{
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer[]])]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.DoNotExportAttribute()]
    param(
        [Parameter()]
        [object]
        ${Customize}
    )
    $result = @()

    foreach ($item in $Customize)
    {
        if ($item.type -eq 'PowerShell')
        {
            $result += [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplatePowerShellCustomizer]::DeserializeFromPSObject($item)
        }
        elseif ($item.type -eq 'WindowsRestart')
        {
            $result += [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateRestartCustomizer]::DeserializeFromPSObject($item)
        }
        elseif ($item.type -eq 'WindowsUpdate')
        {
            $result += [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateWindowsUpdateCustomizer]::DeserializeFromPSObject($item)
        }
        elseif ($item.type -eq 'Shell')
        {
            $result += [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateShellCustomizer]::DeserializeFromPSObject($item)
        }
        elseif ($item.type -eq 'File')
        {
            $result += [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateFileCustomizer]::DeserializeFromPSObject($item)
        }
        else
        {
            $ErrorMessage = "Unkown type: " + $item.type + " for customizer!"
            Write-Error $ErrorMessage
        }
    }

    return $result
}

function New-DistributeArrayFromJson
{
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributor[]])]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.DoNotExportAttribute()]
    param(
        [Parameter()]
        [object]
        ${DistributerList}
    )
    $result = @()

    foreach ($Distributer in $DistributerList)
    {
        if ($Distributer.type -eq 'VHD')
        {
            $item = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateVhdDistributor]::DeserializeFromPSObject($Distributer)
        }
        elseif ($Distributer.type -eq 'ManagedImage')
        {
            $item = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateManagedImageDistributor]::DeserializeFromPSObject($Distributer)
        }
        elseif ($Distributer.type -eq 'SharedImage')
        {
            $item = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateSharedImageDistributor]::DeserializeFromPSObject($Distributer)
        }
        else
        {
            $ErrorMessage = "Unkown type: " + $item.type + " for distributer!"
            Write-Error $ErrorMessage
        }
        $item.ArtifactTag = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateDistributorArtifactTags]::new()
        $item.ArtifactTag.CopyFrom($Distributer.artifactTags)
        $result += $item
    }

    return $result
}

function New-IdentityObjectFromJson
{
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateIdentity])]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.DoNotExportAttribute()]
    param(
        [Parameter()]
        [object]
        ${Identity}
    )
    $Result = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateIdentity]::DeserializeFromPSObject($Identity)
    
    foreach ($property in $Identity.userAssignedIdentities.PSObject.Properties) {
        $obj = @{
            ClientId = $property.Value.ClientId;
            PrincipalId = $property.Value.PrincipalId
        }
        $Result.UserAssignedIdentity.Add($property.Name, $obj)
    }
    return $Result
}

function New-VMProfileObjectFromJson
{
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateVMProfile])]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.DoNotExportAttribute()]
    param(
        [Parameter()]
        [object]
        ${VMProfile}
    )
    $Result = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateVMProfile]::DeserializeFromPSObject($VMProfile)
    
    return $Result
}
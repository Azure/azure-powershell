
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
Creates key credentials or password credentials for an service principal.
.Description
Creates key credentials or password credentials for an service principal.
.Link
https://docs.microsoft.com/powershell/module/az.resources/new-azadspcredential
#>

function New-AzADSpCredential {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphKeyCredential], [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphPasswordCredential])]
    [CmdletBinding(DefaultParameterSetName='SpObjectIdWithPasswordParameterSet', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Alias("New-AzADServicePrincipalCredential")]
    param(
        [Parameter(ParameterSetName='SpObjectIdWithPasswordParameterSet', Mandatory, HelpMessage = "The object Id of application.")]
        [Parameter(ParameterSetName='SpObjectIdWithCertValueParameterSet', Mandatory, HelpMessage = "The object Id of application.")]
        [Parameter(ParameterSetName='SpObjectIdWithKeyCredentialParameterSet', Mandatory, HelpMessage = "The object Id of application.")]
        [Parameter(ParameterSetName='SpObjectIdWithPasswordCredentialParameterSet', Mandatory, HelpMessage = "The object Id of application.")]
        [Alias('Id', 'ServicePrincipalObjectId')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.String]
        ${ObjectId},

        [Parameter(ParameterSetName='SPNWithCertValueParameterSet', Mandatory, HelpMessage = "The service principal name.")]
        [Parameter(ParameterSetName='SPNWithPasswordParameterSet', Mandatory, HelpMessage = "The service principal name.")]
        [Parameter(ParameterSetName='SPNWithKeyCredentialParameterSet', Mandatory, HelpMessage = "The service principal name.")]
        [Parameter(ParameterSetName='SPNWithPasswordCredentialParameterSet', Mandatory, HelpMessage = "The service principal name.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.String]
        [Alias('SPN')]
        ${ServicePrincipalName},

        [Parameter(ParameterSetName='ServicePrincipalObjectWithCertValueParameterSet', Mandatory, ValueFromPipeline, HelpMessage = "The service principal object, could be used as pipeline input.")]
        [Parameter(ParameterSetName='ServicePrincipalObjectWithPasswordParameterSet', Mandatory, ValueFromPipeline, HelpMessage = "The service principal object, could be used as pipeline input.")]
        [Parameter(ParameterSetName='ServicePrincipalObjectWithKeyCredentialParameterSet', Mandatory, ValueFromPipeline, HelpMessage = "The service principal object, could be used as pipeline input.")]
        [Parameter(ParameterSetName='ServicePrincipalObjectWithPasswordCredentialParameterSet', Mandatory, ValueFromPipeline, HelpMessage = "The service principal object, could be used as pipeline input.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphServicePrincipal]
        ${ServicePrincipalObject},

        [Parameter(ParameterSetName='SpObjectIdWithCertValueParameterSet', Mandatory, HelpMessage = "The value of the 'asymmetric' credential type. It represents the base 64 encoded certificate.")]
        [Parameter(ParameterSetName='SPNWithCertValueParameterSet', Mandatory, HelpMessage = "The value of the 'asymmetric' credential type. It represents the base 64 encoded certificate.")]
        [Parameter(ParameterSetName='ServicePrincipalObjectWithCertValueParameterSet', Mandatory, HelpMessage = "The value of the 'asymmetric' credential type. It represents the base 64 encoded certificate.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.String]
        ${CertValue},

        [Parameter(ParameterSetName='SpObjectIdWithKeyCredentialParameterSet', Mandatory, HelpMessage = "key credentials associated with the service principal.")]
        [Parameter(ParameterSetName='SPNWithKeyCredentialParameterSet', Mandatory, HelpMessage = "key credentials associated with the service principal.")]
        [Parameter(ParameterSetName='ServicePrincipalObjectWithKeyCredentialParameterSet', Mandatory, HelpMessage = "key credentials associated with the service principal.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphKeyCredential[]]
        ${KeyCredentials},

        [Parameter(ParameterSetName='SpObjectIdWithPasswordCredentialParameterSet', Mandatory, HelpMessage = "Password credentials associated with the service principal.")]
        [Parameter(ParameterSetName='SPNWithPasswordCredentialParameterSet', Mandatory, HelpMessage = "Password credentials associated with the service principal.")]
        [Parameter(ParameterSetName='ServicePrincipalObjectWithPasswordCredentialParameterSet', Mandatory, HelpMessage = "Password credentials associated with the service principal.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphPasswordCredential[]]
        ${PasswordCredentials},

        [Parameter(ParameterSetName='SpObjectIdWithCertValueParameterSet', HelpMessage = "The effective start date of the credential usage. The default start date value is today. For an 'asymmetric' type credential, this must be set to on or after the date that the X509 certificate is valid from.")]
        [Parameter(ParameterSetName='SPNWithCertValueParameterSet', HelpMessage = "The effective start date of the credential usage. The default start date value is today. For an 'asymmetric' type credential, this must be set to on or after the date that the X509 certificate is valid from.")]
        [Parameter(ParameterSetName='ServicePrincipalObjectWithCertValueParameterSet', HelpMessage = "The effective start date of the credential usage. The default start date value is today. For an 'asymmetric' type credential, this must be set to on or after the date that the X509 certificate is valid from.")]
        [Parameter(ParameterSetName='SpObjectIdWithPasswordParameterSet', HelpMessage = "The effective start date of the credential usage. The default start date value is today. For an 'asymmetric' type credential, this must be set to on or after the date that the X509 certificate is valid from.")]
        [Parameter(ParameterSetName='SPNWithPasswordParameterSet', HelpMessage = "The effective start date of the credential usage. The default start date value is today. For an 'asymmetric' type credential, this must be set to on or after the date that the X509 certificate is valid from.")]
        [Parameter(ParameterSetName='ServicePrincipalObjectWithPasswordParameterSet', HelpMessage = "The effective start date of the credential usage. The default start date value is today. For an 'asymmetric' type credential, this must be set to on or after the date that the X509 certificate is valid from.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.DateTime]
        ${StartDate},

        [Parameter(ParameterSetName='SpObjectIdWithCertValueParameterSet', HelpMessage = "The effective end date of the credential usage. The default end date value is one year from today. For an 'asymmetric' type credential, this must be set to on or before the date that the X509 certificate is valid.")]
        [Parameter(ParameterSetName='SPNWithCertValueParameterSet', HelpMessage = "The effective end date of the credential usage. The default end date value is one year from today. For an 'asymmetric' type credential, this must be set to on or before the date that the X509 certificate is valid.")]
        [Parameter(ParameterSetName='ServicePrincipalObjectWithCertValueParameterSet', HelpMessage = "The effective end date of the credential usage. The default end date value is one year from today. For an 'asymmetric' type credential, this must be set to on or before the date that the X509 certificate is valid.")]
        [Parameter(ParameterSetName='SpObjectIdWithPasswordParameterSet', HelpMessage = "The effective end date of the credential usage. The default end date value is one year from today. For an 'asymmetric' type credential, this must be set to on or before the date that the X509 certificate is valid.")]
        [Parameter(ParameterSetName='SPNWithPasswordParameterSet', HelpMessage = "The effective end date of the credential usage. The default end date value is one year from today. For an 'asymmetric' type credential, this must be set to on or before the date that the X509 certificate is valid.")]
        [Parameter(ParameterSetName='ServicePrincipalObjectWithPasswordParameterSet', HelpMessage = "The effective end date of the credential usage. The default end date value is one year from today. For an 'asymmetric' type credential, this must be set to on or before the date that the X509 certificate is valid.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.DateTime]
        ${EndDate},

        [Parameter()]
        [Alias("AzContext", "AzureRmContext", "AzureCredential")]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
      )
    
    process {
        if (!$PSBoundParameters['PasswordCredentials'] -and !$PSBoundParameters['KeyCredentials']) {
            if ($PSBoundParameters['CertValue']) {
                $credential = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphKeyCredential" `
                                         -Property @{'Key'=([System.Convert]::FromBase64String($PSBoundParameters['CertValue']));
                                                     'Usage'='Verify'; 
                                                     'Type'='AsymmetricX509Cert'}
            } else {
                $credential = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphPasswordCredential"
            }
            if ($PSBoundParameters['StartDate']) {
                $credential.StartDateTime = $PSBoundParameters['StartDate']
                $null = $PSBoundParameters.Remove('StartDate')
            }
            if ($PSBoundParameters['EndDate']) {
                $credential.EndDateTime = $PSBoundParameters['EndDate']
                $null = $PSBoundParameters.Remove('EndDate')

            }
            $credential.KeyId = (New-Guid).ToString()
            if ($PSBoundParameters['CertValue']) {
                $kc = $credential
                $null = $PSBoundParameters.Remove('CertValue')
            } else {
                $pc = $credential
            }
        } elseif ($PSBoundParameters['PasswordCredentials']) {
            $pc = $PSBoundParameters['PasswordCredentials']
            $null = $PSBoundParameters.Remove('PasswordCredentials')
        } else {
            $kc = $PSBoundParameters['KeyCredentials']
            $null = $PSBoundParameters.Remove('PasswordCredentials')
        }
        
        $param = @{}
        switch ($PSCmdlet.ParameterSetName) {
            {$_ -in 'SpObjectIdWithPasswordParameterSet', 'SpObjectIdWithKeyCredentialParameterSet', 'SpObjectIdWithPasswordCredentialParameterSet', 'SpObjectIdWithCertValueParameterSet'} {
                $id = $PSBoundParameters['ObjectId']
                if ($kc) {
                    $sp = Get-AzADServicePrincipal -ObjectId $id
                }
                $null = $PSBoundParameters.Remove('ObjectId')
                break
            }
            {$_ -in 'SPNWithPasswordParameterSet', 'SPNWithKeyCredentialParameterSet', 'SPNWithPasswordCredentialParameterSet', 'SPNWithCertValueParameterSet'} {
                $param['ServicePrincipalName'] = $PSBoundParameters['ServicePrincipalName']
                $sp = Get-AzADServicePrincipal @param
                if($sp) {
                    $id = $sp.Id
                    $null = $PSBoundParameters.Remove('ServicePrincipalName')
                } else {
                    Write-Error "service principal with name '$($PSBoundParameters['ServicePrincipalName'])' does not exist."
                    return
                }
                break
            }
            {$_ -in 'ServicePrincipalObjectWithPasswordParameterSet', 'ServicePrincipalObjectWithKeyCredentialParameterSet', 'ServicePrincipalObjectWithPasswordCredentialParameterSet', 'ServicePrincipalObjectWithCertValueParameterSet'} {
                $id = $PSBoundParameters['ServicePrincipalObject'].Id
                if ($kc) {
                    $sp = Get-AzADServicePrincipal -ObjectId $id
                }
                $null = $PSBoundParameters.Remove('ServicePrincipalObject')
                break
            }
            default {
                break
            }
        } 
        if ($pc) {
            $PSBoundParameters['ServicePrincipalId'] = $id
            foreach ($credential in $pc) {
                $PSBoundParameters['PasswordCredential'] = $credential
                Az.MSGraph.internal\Add-AzADServicePrincipalPassword @PSBoundParameters
            }
            $null = $PSBoundParameters.Remove('ServicePrincipalId')
            if ($PSBoundParameters['PasswordCredential']) {
                $null = $PSBoundParameters.Remove('PasswordCredential')
            }
        }
        if ($kc) {
            [System.Array]$kcList = $sp.KeyCredentials
            $PSBoundParameters['Id'] = $id
            foreach ($k in $kc) {
                $kcList += $k
            }
            $PSBoundParameters['KeyCredentials'] = $kcList
            Az.MSGraph.internal\Update-AzADServicePrincipal @PSBoundParameters
        }  
    }
}
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

function Get-AzPostgreSqlConnectionString {
    [OutputType([System.String])]
    [CmdletBinding(DefaultParameterSetName='Get', PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Description('Get the connection string according to client connection provider.')]
    param(
        [Parameter(ParameterSetName='Get', Mandatory, HelpMessage = 'The name of the server.')]
        [Alias('ServerName')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Path')]
        [System.String]
        ${Name},

        [Parameter(ParameterSetName='Get', Mandatory,  HelpMessage = 'The name of the resource group that contains the resource, You can obtain this value from the Azure Resource Manager API or the portal.')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Path')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(ParameterSetName='Get', HelpMessage='The subscription ID that identifies an Azure subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        ${SubscriptionId},

        [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline, HelpMessage = 'The server for the connection string')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServer]
        ${InputObject},

        [Parameter(Mandatory, HelpMessage = 'Client connection provider.')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Path')]
        [Validateset('ADO.NET', 'C++', 'JDBC', 'Node.js', 'PHP', 'psql', 'Python', 'Ruby', 'WebApp')]
        [System.String]
        ${Client},

        [Parameter(HelpMessage = 'The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Azure')]
        [System.Management.Automation.PSObject]
        ${DefaultProfile},

        [Parameter(DontShow, HelpMessage = 'Wait for .NET debugger to attach.')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline.
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline.
        ${HttpPipelinePrepend},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use.
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call.
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy.
        ${ProxyUseDefaultCredentials}
    )

    process {
        function GetConnectionStringSslPart {
            param(
                [Parameter()]
                [string]
                ${Client},
                [Parameter()]
                [string]
                ${SslEnforcement}
            )
            $SslEnforcementTemplateMap = @{
            'ADO.NET' = 'Ssl Mode=Require;'
            'C++' = 'sslmode=require'
            'JDBC' = 'sslmode=require'
            'Node.js' = 'sslmode=require'
            'PHP' = 'sslmode=require'
            'psql' = 'sslmode=require'
            'Python' = "sslmode='true'"
            'Ruby' = 'sslmode=require'
            'WebApp' = ''
           }
           if ($SslEnforcement -eq 'Enabled') {
               return $SslEnforcementTemplateMap[$Client]
           }
           return ''
        }

        $clientConnection = $PSBoundParameters['Client']
        $null = $PSBoundParameters.Remove('Client')
        $postgreSql = Az.PostgreSql\Get-AzPostgreSqlServer @PSBoundParameters
        $DBHost = $postgreSql.FullyQualifiedDomainName
        $DBPort = 5432
        $adminName = $postgreSql.AdministratorLogin
        $serverName = $postgreSql.Name
        $SslConnectionString = GetConnectionStringSslPart -Client $clientConnection -SslEnforcement $postgreSql.SslEnforcement
        $ConnectionStringMap = @{
            'ADO.NET' = "Server=${DBHost};Database={your_database};Port=${DBPort};User Id=${adminName}@${serverName};Password={your_password};$SslConnectionString"
            'C++' = "host=${DBHost} port=${DBPort} dbname={your_database} user=${adminName}@${serverName} password={your_password} $SslConnectionString"
            'JDBC' = "jdbc:postgresql://${DBHost}:${DBPort}/{your_database}?user=${adminName}@${serverName}&password={your_password}&$SslConnectionString"
            'Node.js' = "host=${DBHost} port=${DBPort} dbname={your_database} user=${adminName}@${serverName} password={your_password} $SslConnectionString"
            'PHP' = "host=${DBHost} port=${DBPort} dbname={your_database} user=${adminName}@${serverName} password={your_password} $SslConnectionString"
            'psql' = "psql ""host=${DBHost} port=${DBPort} dbname={your_database} user=${adminName}@${serverName} password={your_password} $SslConnectionString"""
            'Python' = "dbname='{your_database}' user='${adminName}@${serverName}' host='${DBHost}' password='{your_password}' port='${DBPort}' $SslConnectionString"
            'Ruby' = "host=${DBHost}; dbname={your_database} user=${adminName}@${serverName} password={your_password} port=${DBPort} $SslConnectionString"
            'WebApp' = "Database={your_database}; Data Source=${DBHost}; User Id=${adminName}@${serverName}; Password={your_password}$SslConnectionString"
        }
        return $ConnectionStringMap[$Client]
    }
}


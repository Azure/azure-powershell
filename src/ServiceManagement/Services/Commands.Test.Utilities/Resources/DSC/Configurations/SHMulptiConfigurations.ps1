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

Configuration FileServerConfiguration
{
    Import-DscResource -Name MSFT_xComputer, MSFT_xFirewall

    Node $AllNodes.Where{$_.MachineName -eq "SHFileServer"}.NodeName
    {
        xComputer NameAndDomain
        {
            Name     = $Node.MachineName
            DomainName = $Node.DomainName
            Credential = (Import-CliXML $Node.DomainCredFile)
        }

        # Remove all built-in firewall rules
        foreach ($rule in $Node.AbsentInRules)
        {
            xFirewall $rule.Name
            {
                Ensure      = "Present";
                Access      = "NotConfigured"
                Name = $rule.Name;
                Direction   = "Inbound";
                State       = "Disabled";
                Protocol    = $rule.Protocol;
                DependsOn   = "[xComputer]NameAndDomain"
            }
        }
        #comments
        xFirewall HttpsForPullServer
        {
            Ensure        = "Present"
            Access        = "Allow"
		    Name   = "DSC HTTPS"
            RemotePort    = "8080";
            Protocol      = "TCP";
            Direction     = "Outbound";
            State         = "Enabled";
            DependsOn   = "[xComputer]NameAndDomain"
        }

        WindowsFeature FileServer
        {
            Ensure     = "Present"
            Name       = "File-Services"
            DependsOn  = "[xComputer]NameAndDomain"
        }

        WindowsFeature WebServer
        {
            Ensure     = "Absent"
            Name       = "Web-Server"
            DependsOn  = "[xComputer]NameAndDomain"
        }

        # Remove all built-in File firewall rules
        foreach ($rule in $Node.AbsentInFileRules)
        {
            xFirewall $rule.Name
            {
                Ensure      = "Present";
                Access      = "NotConfigured"
                Name = $rule.Name;
                Direction   = "Inbound";
                State       = "Disabled";
                Protocol    = $rule.Protocol;
                DependsOn   = "[WindowsFeature]FileServer"
            }
        }
                        
        # Open selective ports & protocols# more comments a lot of rules are created removing them
        foreach ($rule in $Node.AllowedInRules)
        {
            xFirewall $rule.Name
            {
                Ensure      = "Present";
                Access      = "Allow";
                Name = $rule.Name;
                LocalPort   = $rule.Port;
                Protocol    = $rule.Protocol;
                State       = "Enabled";
                Direction   = "Inbound";
                DependsOn   = "[WindowsFeature]FileServer" 
            }
        }
       # hard coded
       Group MATA
       {
            GroupName        = "Administrators"
            Ensure           = "Present"
            MembersToInclude = @("safeharbor\MATA")
            Credential       = (Import-Clixml $Node.DomainCredFile)
            DependsOn        = "[xComputer]NameAndDomain"
       }

       User Administrator
       {
            Ensure     = "Present" 
            UserName   = "Administrator"
            Disabled   = $true
       }
    }
}

$scriptLocation = $PSScriptRoot
Import-Module "$PSScriptRoot\CommonHelpers.psm1" -Force

Configuration MgmtSrv
{   
    Import-DscResource -Name MSFT_xComputer, MSFT_xPSSessionConfiguration

    Node $AllNodes.Where{$_.Role -eq "DelegatedAdmin"}.NodeName
    {
        xComputer NameAndDomain
        {
            Name     = $Node.MachineName
            DomainName = $Node.DomainName
            Credential = (Import-CliXML $Node.DomainCredFile)
        }

        xPSEndpoint Secure
        {
            Ensure            = "Present"
            Name              = $Node.EPName
            RunAsCredential   = (Import-CliXml $Node.RunAsCredFile)
            SecurityDescriptorSDDL = $Node.SDDL
            StartupScript     = $Node.StartupScript
            DependsOn         = "[xComputer]NameAndDomain" 
        }
    }
}

Configuration SHPullServerConfiguration
{ 
    Import-DscResource -Name MSFT_xComputer, MSFT_xDSCWebService

    Node $AllNodes.Where{$_.Role -eq "SHPullServer"}.NodeName
    {             

        WindowsFeature DSCServiceBin
        {
            Ensure    = "Present"
            Name      = "DSC-Service"
        }

        xDSCWebService ODataEP
        {
            Ensure                = "Present" 
            EndpointName          = "PSDSCPullServer"
            CertificateThumbPrint = $Node.PullCert
            ModulePath            = "$env:PROGRAMFILES\WindowsPowerShell\DscService\Modules"
            ConfigurationPath     = "$env:PROGRAMFILES\WindowsPowerShell\DscService\Configuration"            
            State                 = "Started"
            DependsOn             = "[WindowsFeature]DSCServiceBin"
        }

        xComputer NameAndDomain
        {
            Name     = $Node.MachineName
            DomainName = $Node.DomainName
            Credential = (Import-CliXML $Node.DomainCredFile)
            DependsOn = "[xDSCWebService]ODataEP"
        }
    }
}


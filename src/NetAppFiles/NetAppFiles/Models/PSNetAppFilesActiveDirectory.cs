// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Management.NetApp.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    /// <summary>
    /// ARM tracked resource
    /// </summary>
    public class PSNetAppFilesActiveDirectory
    {
        /// <summary>
        /// Gets or sets the Resource group name
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the Account name
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Id of the active drectory.
        /// Value of this property can not be set by user.
        /// </summary>
        /// <value>Id of the Active Directory.</value>
        public string ActiveDirectoryId { get; set; }

        /// <summary>
        /// Username of a Active Directory domain administrator
        /// </summary>
        /// <value>Username of a Active Directory domain administrator</value>
        public string Username { get; set; }

        /// <summary>
        /// Password of a Active Directory domain administrator
        /// </summary>
        /// <value>Password of a Active Directory domain administrator</value>
        public string Password { get; set; }

        /// <summary>
        /// Name of the Active Directory domain
        /// </summary>
        /// <value>Name of the Active Directory domain</value>
        public string Domain { get; set; }

        /// <summary>
        /// Comma separated list of DNS server IP addresses for the Active Directory domain
        /// </summary>
        /// <value>Comma separated list of DNS server IP addresses for the Active Directory domain</value>
        public string Dns { get; set; }

        /// <summary>
        /// Status of the Active Directory.
        /// Value of this property can not be set by user.
        /// </summary>
        /// <value>Status of the active directory on the storage server.</value>
        public string Status { get; set; }

        /// <summary>
        /// StatusDetails of the Active Directory.
        /// Value of this property can not be set by user.
        /// </summary>
        /// <value>Any details in regards to the Status of the Active Directory</value>
        public string StatusDetails { get; set; }

        /// <summary>
        /// NetBIOS name of the SMB server.
        /// This name will be registered as a computer account in the AD.
        /// This name will be used to mount the volumes.
        /// </summary>
        /// <value>NetBIOS name of the SMB server</value>
        public string SmbServerName { get; set; }

        /// <summary>
        /// The Organizational Unit (OU) within the Windows Active Directory.
        /// </summary>
        public string OrganizationalUnit { get; set; }

        /// <summary>
        /// The Active Directory site the service will limit Domain Controller discovery to
        /// </summary>
        public string Site { get; set; }

        /// <summary>
        /// Users to be added to the Built-in Backup Operator Active Directory group. A list of unique usernames without domain specifier
        /// </summary>
        public IList<string> BackupOperators { get; set; }

        /// <summary>
        /// Gets or sets kdcID
        /// </summary>
        /// <value>Kdc server IP addresses for the Active Directory machine. This optional
        /// parameter is used only while creating kerberos volume.
        /// </value>
        public string KdcIP { get; set; }

        /// <summary>
        /// Gets or sets AdName
        /// </summary>
        /// <value>Name of the Active Directory machine. This optional parameter is
        /// parameter is used only while creating kerberos volume.
        /// </value>
        public string AdName { get; set; }

        /// <summary>
        /// Gets or sets ServerRootCACertificate
        /// </summary>
        /// <value>when LDAP over SSL/TLS is enabled, the LDAP client is required to
        /// have base64 encoded Active Directory Certificate Service's self-signed root CA
        /// certificate, this optional parameter is used only for dual protocol with LDAP
        /// user-mapping volumes.
        /// </value>
        public string ServerRootCACertificate { get; set; }

        /// <summary>
        /// Gets or sets AesEncryption
        /// </summary>
        /// <value>If enabled, AES encryption will be enabled for SMB communication
        /// </value>
        public bool? AesEncryption { get; set; }

        /// <summary>
        /// Gets or sets LdapSigning
        /// </summary>
        /// <value>Specifies whether or not the LDAP traffic needs to be signed
        /// </value>
        public bool? LdapSigning { get; set; }

        /// <summary>
        /// Gets or sets SecurityOperators
        /// </summary>
        /// <value>
        /// Domain Users in the Active Directory to be given Security Privilege (Needed for SMB Continuously available shares for SQL). A list of unique usernames without domain specifier
        /// </value>
        public IList<string> SecurityOperators { get; set; }

        /// <summary>
        /// Gets or sets LdapOverTLS
        /// </summary>
        /// <value>Specifies whether or not the LDAP specifies whether or not the LDAP traffic needs to be
        /// secured via TLS.
        /// </value>
        public bool? LdapOverTLS { get; set; }

        /// <summary>
        /// Gets or sets AllowLocalNfsUsersWithLdap
        /// </summary>
        /// <value>If enabled, NFS client local users can also (in addition to LDAP users) access the NFS volumes.
        /// </value>
        public bool? AllowLocalNfsUsersWithLdap { get; set; }

        /// <summary>
        /// Gets or sets Administrators
        /// </summary>
        /// <value>
        /// Domain Users to be added to the Built-in Administrators Active Directory group. A list of unique usernames without domain specifier
        /// </value>
        public IList<string> Administrators { get; set; }

        /// <summary>
        /// Gets or sets EncryptDCConnections
        /// </summary>
        /// <value>If enabled, Traffic between the SMB server to Domain Controller (DC) will be encrypted
        /// </value>
        public bool? EncryptDCConnections { get; set; }

        /// <summary>
        /// Gets or sets LdapSearchScope
        /// </summary>
        /// <value>LDAP Search scope options
        /// </value>
        public PSNetAppFilesLdapSearchScopeOpt LdapSearchScope { get; set; }


    }
}
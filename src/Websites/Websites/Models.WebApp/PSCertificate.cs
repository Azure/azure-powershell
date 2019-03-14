using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.WebApps.Models.WebApp
{
    class PSCertificate: Certificate
    {
        public PSCertificate(Certificate other)
            :base(
                 location: other.Location, 
                 password: other.Password, 
                 id: other.Id,
                 name: other.Name,
                 kind: other.Kind,
                 type: other.Type,
                 tags: other.Tags,
                 friendlyName: other.FriendlyName,
                 subjectName: other.SubjectName,
                 hostNames: other.HostNames,
                 pfxBlob: other.PfxBlob,
                 siteName: other.SiteName,
                 selfLink: other.SelfLink,
                 issuer: other.Issuer,
                 issueDate: other.IssueDate,
                 expirationDate: other.ExpirationDate,
                 thumbprint: other.Thumbprint,
                 valid: other.Valid,
                 cerBlob: other.CerBlob,
                 publicKeyHash: other.PublicKeyHash,
                 hostingEnvironmentProfile: other.HostingEnvironmentProfile,
                 keyVaultId: other.KeyVaultId,
                 keyVaultSecretName: other.KeyVaultSecretName,
                 keyVaultSecretStatus: other.KeyVaultSecretStatus,
                 serverFarmId: other.ServerFarmId
                 )
        {

        }
    }
}

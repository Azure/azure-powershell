using Microsoft.Azure.Management.WebSites.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.WebApps.Models
{
    public class PSAccessRestrictionSettings
    {
        internal PSAccessRestrictionSettings(SiteConfig siteConfig)
        {
            ScmSiteUseMainSiteRestrictions = siteConfig.ScmIpSecurityRestrictionsUseMain ?? false;

            MainSiteAccessRestrictions = new List<PSAccessRestriction>();
            if (siteConfig.IpSecurityRestrictions != null)
            {
                foreach (var accessRestriction in siteConfig.IpSecurityRestrictions)
                {
                    var psAccessRestiction = new PSAccessRestriction();
                    psAccessRestiction.RuleName = accessRestriction.Name;
                    psAccessRestiction.Action = accessRestriction.Action;
                    psAccessRestiction.Priority = accessRestriction.Priority ?? 0;
                    psAccessRestiction.Description = accessRestriction.Description;
                    if (accessRestriction.IpAddress != null)
                        psAccessRestiction.IpAddress = accessRestriction.IpAddress;
                    else
                        psAccessRestiction.SubnetId = accessRestriction.VnetSubnetResourceId;
                    MainSiteAccessRestrictions.Add(psAccessRestiction);
                }
            }

            ScmSiteAccessRestrictions = new List<PSAccessRestriction>();
            if (siteConfig.ScmIpSecurityRestrictions != null)
            {
                foreach (var accessRestriction in siteConfig.ScmIpSecurityRestrictions)
                {
                    var psAccessRestiction = new PSAccessRestriction();
                    psAccessRestiction.RuleName = accessRestriction.Name;
                    psAccessRestiction.Action = accessRestriction.Action;
                    psAccessRestiction.Priority = accessRestriction.Priority ?? 0;
                    psAccessRestiction.Description = accessRestriction.Description;
                    if (accessRestriction.IpAddress != null)
                        psAccessRestiction.IpAddress = accessRestriction.IpAddress;
                    else
                        psAccessRestiction.SubnetId = accessRestriction.VnetSubnetResourceId;
                    ScmSiteAccessRestrictions.Add(psAccessRestiction);
                }
            }
        }
        public List<PSAccessRestriction> MainSiteAccessRestrictions { get; set; }

        public List<PSAccessRestriction> ScmSiteAccessRestrictions { get; set; }

        public bool ScmSiteUseMainSiteRestrictions { get; set; }
    }
}

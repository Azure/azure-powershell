using Microsoft.Azure.Management.WebSites.Models;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.WebApps.Models
{
    public class PSAccessRestrictionConfig
    {
        internal PSAccessRestrictionConfig(string resourceGroupName, string webAppName, SiteConfig siteConfig, string slotName = null)
        {
            ResourceGroupName = resourceGroupName;
            WebAppName = webAppName;
            SlotName = slotName;
            ScmSiteUseMainSiteRestrictionConfig = siteConfig.ScmIpSecurityRestrictionsUseMain ?? false;

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
                    psAccessRestiction.Tag = accessRestriction.Tag;
                    psAccessRestiction.HttpHeader = accessRestriction.Headers != null ? ConvertHeaders(accessRestriction.Headers) : null;
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
                    psAccessRestiction.Tag = accessRestriction.Tag;
                    psAccessRestiction.HttpHeader = accessRestriction.Headers != null ? ConvertHeaders(accessRestriction.Headers) : null;
                    if (accessRestriction.IpAddress != null)
                        psAccessRestiction.IpAddress = accessRestriction.IpAddress;
                    else
                        psAccessRestiction.SubnetId = accessRestriction.VnetSubnetResourceId;
                    ScmSiteAccessRestrictions.Add(psAccessRestiction);
                }
            }
        }

        private Hashtable ConvertHeaders(IDictionary<string, IList<string>> headers)
        {            
            Hashtable returnHeaders = new Hashtable();
            foreach (var key in headers.Keys)
            {
                returnHeaders.Add(key, new List<string>(headers[key]));
            }

            return returnHeaders;
        }
        public string ResourceGroupName { get; set; }
        
        public string WebAppName { get; set; }
        
        public string SlotName { get; set; }

        public List<PSAccessRestriction> MainSiteAccessRestrictions { get; set; }

        public List<PSAccessRestriction> ScmSiteAccessRestrictions { get; set; }

        public bool ScmSiteUseMainSiteRestrictionConfig { get; set; }
    }
}

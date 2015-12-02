using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Resources.Models.Authorization
{
    public class FilterRoleDefinitionOptions
    {
        public bool CustomOnly { get; set; }

        public bool ScopeAndBelow { get; set; }

        public string RoleDefinitionName { get; set; }

        // Guid Id
        public Guid RoleDefinitionId { get; set; }

        private string scope;

        public string Scope
        {
            get
            {
                string result;
                string resourceIdentifier = ResourceIdentifier.ToString();

                if (!string.IsNullOrEmpty(scope))
                {
                    result = scope;
                }
                else if (!string.IsNullOrEmpty(resourceIdentifier))
                {
                    result = resourceIdentifier;
                }
                else
                {
                    result = null;
                }

                return result;
            }
            set
            {
                scope = value;
            }
        }

        public ResourceIdentifier ResourceIdentifier { get; set; }
    }
}

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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    public class ExtensionConfigurationBuilder
    {
        private ExtensionManager extensionManager;
        private HashSet<string> allRoles;
        private Dictionary<string, HashSet<string>> namedRoles;

        public ExtensionConfigurationBuilder(ExtensionManager extensionManager)
        {
            if (extensionManager == null)
            {
                throw new ArgumentNullException("extensionManager");
            }

            this.extensionManager = extensionManager;
            allRoles = new HashSet<string>();
            namedRoles = new Dictionary<string, HashSet<string>>();
        }

        public ExtensionConfigurationBuilder(ExtensionManager extensionManager, ExtensionConfiguration config)
            : this(extensionManager)
        {
            Add(config);
        }

        public bool ExistDefault(string nameSpace, string type)
        {
            return allRoles.Any(id =>
            {
                var e = extensionManager.GetExtension(id);
                return e != null && e.ProviderNamespace == nameSpace && e.Type == type;
            });
        }

        public bool ExistAny(string nameSpace, string type)
        {
            return ExistDefault(nameSpace, type)
                || namedRoles.Any(r => Exist(new string[] { r.Key }, nameSpace, type));
        }

        public bool Exist(string[] roles, string nameSpace, string type)
        {
            if (roles != null && roles.Any())
            {
                return (from r in namedRoles
                        where roles.Contains(r.Key)
                        from id in r.Value
                        select extensionManager.GetExtension(id)).Any(e => e != null && e.ProviderNamespace == nameSpace && e.Type == type);
            }
            else
            {
                return ExistDefault(nameSpace, type);
            }
        }

        public bool ExistDefault(string extensionId)
        {
            return allRoles.Any(id => id == extensionId);
        }

        public bool ExistAny(string extensionId)
        {
            return allRoles.Any(id => id == extensionId)
                || namedRoles.Any(r => Exist(r.Key, extensionId));
        }

        public bool Exist(string roleName, string extensionId)
        {
            return string.IsNullOrWhiteSpace(roleName) ? ExistDefault(extensionId)
                                                       : namedRoles.Any(r => r.Key == roleName
                                                                          && r.Value.Any(id => id == extensionId));
        }

        public bool Exist(ExtensionRole role, string extensionId)
        {
            return role.Default ? ExistDefault(extensionId)
                                : Exist(role.RoleName, extensionId);
        }

        public ExtensionConfigurationBuilder RemoveDefault(string extensionId)
        {
            allRoles.Remove(extensionId);
            return this;
        }

        public ExtensionConfigurationBuilder Remove(string roleName, string extensionId)
        {
            return Remove(new string[] { roleName }, extensionId);
        }

        public ExtensionConfigurationBuilder Remove(string[] roleNames, string extensionId)
        {
            if (roleNames != null && roleNames.Any())
            {
                foreach (var r in roleNames.Intersect(namedRoles.Keys))
                {
                    namedRoles[r].Remove(extensionId);
                }
                return this;
            }
            else
            {
                return RemoveDefault(extensionId);
            }
        }

        public ExtensionConfigurationBuilder RemoveDefault(string nameSpace, string type)
        {
            allRoles.RemoveWhere(e => ExistDefault(nameSpace, type));
            return this;
        }

        public ExtensionConfigurationBuilder RemoveAny(string nameSpace, string type)
        {
            RemoveDefault(nameSpace, type);
            foreach (var r in namedRoles)
            {
                r.Value.RemoveWhere(id => Exist(r.Key, id));
            }
            return this;
        }

        public ExtensionConfigurationBuilder Remove(string roleName, string nameSpace, string type)
        {
            return Remove(new string[] { roleName }, nameSpace, type);
        }

        public ExtensionConfigurationBuilder Remove(string[] roles, string nameSpace, string type)
        {
            if (roles != null && roles.Any())
            {
                foreach (var r in roles.Intersect(namedRoles.Keys))
                {
                    namedRoles[r].RemoveWhere(id =>
                    {
                        var e = extensionManager.GetExtension(id);
                        return e != null && e.ProviderNamespace == nameSpace && e.Type == type;
                    });
                }
                return this;
            }
            else
            {
                return RemoveDefault(nameSpace, type);
            }
        }

        public ExtensionConfigurationBuilder AddDefault(string extensionId)
        {
            if (!ExistDefault(extensionId))
            {
                allRoles.Add(extensionId);
            }
            return this;
        }

        public ExtensionConfigurationBuilder Add(string roleName, string extensionId)
        {
            return Add(new string[] { roleName }, extensionId);
        }

        public ExtensionConfigurationBuilder Add(string[] roleNames, string extensionId)
        {
            if (roleNames != null && roleNames.Any())
            {
                foreach (var r in roleNames)
                {
                    if (namedRoles.ContainsKey(r))
                    {
                        namedRoles[r].Add(extensionId);
                    }
                    else
                    {
                        namedRoles.Add(r, new HashSet<string>(new string[] { extensionId }));
                    }
                }
                return this;
            }
            else
            {
                return AddDefault(extensionId);
            }
        }

        public ExtensionConfigurationBuilder Add(ExtensionRole role, string extensionId)
        {
            if (role != null)
            {
                if (!role.Default)
                {
                    Add(role.RoleName, extensionId);
                }
                else
                {
                    AddDefault(extensionId);
                }
            }
            return this;
        }

        public ExtensionConfigurationBuilder Add(ExtensionConfigurationInput context, string extensionId)
        {
            if (context != null && context.Roles != null)
            {
                context.Roles.ForEach(r => Add(r, extensionId));
            }
            return this;
        }

        public ExtensionConfigurationBuilder Add(ExtensionConfiguration config)
        {
            if (config != null)
            {
                if (config.AllRoles != null)
                {
                    foreach (var e in config.AllRoles)
                    {
                        AddDefault(e.Id);
                    }
                }

                if (config.NamedRoles != null)
                {
                    foreach (var r in config.NamedRoles)
                    {
                        foreach (var e in r.Extensions)
                        {
                            if (namedRoles.ContainsKey(r.RoleName))
                            {
                                namedRoles[r.RoleName].Add(e.Id);
                            }
                            else
                            {
                                namedRoles.Add(r.RoleName, new HashSet<string>(new string[] { e.Id }));
                            }
                        }
                    }
                }
            }
            return this;
        }

        public ExtensionConfiguration ToConfiguration()
        {
            ExtensionConfiguration config = new ExtensionConfiguration();
            foreach (var id in allRoles)
            {
                config.AllRoles.Add(new ExtensionConfiguration.Extension
                {
                    Id = id
                });
            }

            foreach (var r in namedRoles)
            {
                if (r.Value.Any())
                {
                    var nr = new ExtensionConfiguration.NamedRole
                    {
                        RoleName = r.Key
                    };

                    foreach (var v in r.Value)
                    {
                        nr.Extensions.Add(new ExtensionConfiguration.Extension
                        {
                            Id = v
                        });
                    }

                    config.NamedRoles.Add(nr);
                }
            }

            return config;
        }
    }
}

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
using System.Reflection;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation
{
    internal class ServiceLocationAssemblySweep : IServiceLocationAssemblySweep
    {
        private readonly List<KeyValuePair<Type, IServiceLocationRegistrarProxyFactory>> knownRegistrars =
            new List<KeyValuePair<Type, IServiceLocationRegistrarProxyFactory>>();

        private readonly Dictionary<Type, IServiceLocationRegistrarProxyFactory> proxies =
            new Dictionary<Type, IServiceLocationRegistrarProxyFactory>();

        public IEnumerable<IServiceLocationRegistrar> GetRegistrars()
        {
            List<KeyValuePair<Type, IServiceLocationRegistrarProxyFactory>> registrars = this.GetRegistrarTypes().ToList();
            this.knownRegistrars.All(registrars.Remove);
            this.knownRegistrars.AddRange(registrars);

            List<IServiceLocationRegistrar> objects = (from t in registrars select t.Value.Create(t.Key)).ToList();
            return objects;
        }

        public bool NewAssembliesPresent()
        {
            List<KeyValuePair<Type, IServiceLocationRegistrarProxyFactory>> registrars = this.GetRegistrarTypes().ToList();
            this.knownRegistrars.All(r => registrars.Remove(r));
            return registrars.Any();
        }

        public void RegisterRegistrarProxy<T>(IServiceLocationRegistrarProxyFactory proxy)
        {
            this.proxies.Add(typeof(T), proxy);
        }

        internal IEnumerable<KeyValuePair<Type, IServiceLocationRegistrarProxyFactory>> GetRegistrarTypes()
        {
            var comparer = new AssemblyNameEqualityComparer();
            var types = new List<Type>();
            Assembly[] scansedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            List<AssemblyName> proxyAssemblies = (from p in this.proxies select p.Value.GetType().Assembly.GetName()).ToList();
            List<Assembly> workingAssemblies =
                (from s in scansedAssemblies from r in proxyAssemblies where s.GetReferencedAssemblies().Contains(r, comparer) select s).ToList();
            workingAssemblies.Add(this.GetType().Assembly);
            foreach (Assembly assembly in workingAssemblies)
            {
                try
                {
                    types.AddRange(assembly.GetTypes());
                }
                catch (ReflectionTypeLoadException loadEx)
                {
                    List<Type> foundTypes = (from t in loadEx.Types where t.IsNotNull() select t).ToList();
                    types.AddRange(foundTypes);
                }
            }
            var preOrdered = new Queue<KeyValuePair<Type, IServiceLocationRegistrarProxyFactory>>();
            foreach (Type type in types)
            {
                if (type.IsInterface)
                {
                    continue;
                }
                foreach (var proxy in this.proxies)
                {
                    if (proxy.Key.IsAssignableFrom(type) && !ReferenceEquals(type.GetConstructor(new Type[0]), null))
                    {
                        preOrdered.Add(new KeyValuePair<Type, IServiceLocationRegistrarProxyFactory>(type, proxy.Value));
                    }
                }
            }

            var orderedList = new List<KeyValuePair<Type, IServiceLocationRegistrarProxyFactory>>();
            while (preOrdered.Count > 0)
            {
                KeyValuePair<Type, IServiceLocationRegistrarProxyFactory> type = preOrdered.Remove();
                bool addToList = true;
                foreach (var stackType in preOrdered)
                {
                    if (type.Key.Assembly.GetReferencedAssemblies().Contains(stackType.Key.Assembly.GetName(), comparer))
                    {
                        addToList = false;
                        preOrdered.Add(type);
                        break;
                    }
                }
                if (addToList)
                {
                    orderedList.Add(type);
                }
            }

            return orderedList;
        }

        private class AssemblyNameEqualityComparer : IEqualityComparer<AssemblyName>
        {
            public bool Equals(AssemblyName x, AssemblyName y)
            {
                if (x.IsNull() && y.IsNull())
                {
                    return true;
                }
                if (x.IsNull() || y.IsNull())
                {
                    return false;
                }
                if (x.Name.Equals(y.Name, StringComparison.Ordinal) && x.Version.Equals(y.Version) && x.CultureInfo.Equals(y.CultureInfo) &&
                    (ReferenceEquals(x.KeyPair, y.KeyPair) ||
                     (x.KeyPair.IsNotNull() && y.KeyPair.IsNotNull() && x.KeyPair.PublicKey.SequenceEqual(y.KeyPair.PublicKey))))
                {
                    return true;
                }
                return false;
            }

            public int GetHashCode(AssemblyName obj)
            {
                if (obj.IsNotNull())
                {
                    return obj.GetHashCode();
                }
                return 0;
            }
        }
    }
}

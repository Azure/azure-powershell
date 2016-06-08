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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.Utilities.CloudService
{
    public class CloudRuntimeCollection : Collection<CloudRuntimePackage>, IDisposable
    {
        Dictionary<RuntimeType, List<CloudRuntimePackage>> packages = new Dictionary<RuntimeType, List<CloudRuntimePackage>>();
        Dictionary<RuntimeType, CloudRuntimePackage> defaults = new Dictionary<RuntimeType, CloudRuntimePackage>();
        private XmlReader documentReader;
        private MemoryStream documentStream;
        private bool disposed;

        private CloudRuntimeCollection()
        {
            foreach (RuntimeType runtime in Enum.GetValues(typeof(RuntimeType)))
            {
                packages[runtime] = new List<CloudRuntimePackage>();
            }
        }

        public static bool CreateCloudRuntimeCollection(out CloudRuntimeCollection runtimes, string manifestFile = null)
        {
            runtimes = new CloudRuntimeCollection();
            XmlDocument manifest = runtimes.GetManifest(manifestFile);
            string baseUri;
            Collection<CloudRuntimePackage> runtimePackages;
            bool success = TryGetBlobUriFromManifest(manifest, out baseUri);
            success &= TryGetRuntimePackages(manifest, baseUri, out runtimePackages);
            foreach (CloudRuntimePackage package in runtimePackages)
            {
                runtimes.Add(package);
            }

            return success;
        }

        public bool TryFindMatch(CloudRuntime runtime, out CloudRuntimePackage matchingPackage)
        {
            matchingPackage = packages[runtime.Runtime].OrderByDescending<CloudRuntimePackage, string>(p => p.Version, new VersionComparer()).FirstOrDefault<CloudRuntimePackage>(crp => runtime.Match(crp));
            if (matchingPackage != null)
            {
                return true;
            }

            if (defaults.ContainsKey(runtime.Runtime))
            {
                matchingPackage = defaults[runtime.Runtime];
            }

            return false;
        }

        protected override void ClearItems()
        {
            foreach (RuntimeType runtime in this.packages.Keys)
            {
                this.packages[runtime].Clear();
            }

            foreach (RuntimeType runtime in this.defaults.Keys)
            {
                this.defaults.Remove(runtime);
            }

            base.ClearItems();
        }

        protected override void InsertItem(int index, CloudRuntimePackage item)
        {
            base.InsertItem(index, item);
            this.AddPackage(item);
        }

        protected override void RemoveItem(int index)
        {
            this.RemovePackage(base[index]);
            base.RemoveItem(index);
        }

        protected override void SetItem(int index, CloudRuntimePackage item)
        {
            if (index < this.Count)
            {
                this.RemovePackage(base[index]);
            }

            this.AddPackage(item);
            base.SetItem(index, item);
        }

        private static bool TryGetBlobUriFromManifest(XmlDocument manifest, out string baseUri)
        {
            Debug.Assert(manifest != null);
            bool found = false;
            baseUri = null;
            XmlNode node = manifest.SelectSingleNode(Resources.ManifestBaseUriQuery);
            if (node != null)
            {
                found = true;
                XmlAttribute blobUriAttribute = node.Attributes[Resources.ManifestBlobUriKey];
                if (null == blobUriAttribute || null == blobUriAttribute.Value)
                {
                    throw new ArgumentException(Resources.InvalidManifestError);
                }

                baseUri = blobUriAttribute.Value;
            }

            return found;
        }

        private XmlDocument GetManifest(string filePath = null)
        {
            if (filePath != null)
            {
                byte[] buffer = File.ReadAllBytes(filePath);
                this.documentStream = new MemoryStream(buffer);
                this.documentReader = XmlReader.Create(documentStream);
            }
            else
            {
                this.documentReader = XmlReader.Create(Resources.ManifestUri);
            }

            XmlDocument document = new XmlDocument();
            document.Load(documentReader);
            return document;
        }

        private static bool TryGetRuntimePackages(XmlDocument manifest, string baseUri, 
            out Collection<CloudRuntimePackage> packages)
        {
            bool retrieved = false;
            packages = new Collection<CloudRuntimePackage>();
            XmlNodeList nodes = manifest.SelectNodes(Resources.RuntimeQuery);
            if (nodes != null)
            {
                retrieved = true;
                foreach (XmlNode node in nodes)
                {
                    packages.Add(new CloudRuntimePackage(node, baseUri));
                }
            }

            return retrieved;
        }

        private void AddPackage(CloudRuntimePackage package)
        {
            if (package.IsDefault)
            {
                this.defaults[package.Runtime] = package;
            }

            this.packages[package.Runtime].Add(package);
        }

        private void RemovePackage(CloudRuntimePackage package)
        {
            if (package.IsDefault)
            {
                this.defaults.Remove(package.Runtime);
            }

            this.packages[package.Runtime].Remove(package);
        }


        public void Dispose()
        {
            this.Dispose(!this.disposed);
            this.disposed = true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.documentReader != null)
                {
                    this.documentReader.Close();
                }
                if (this.documentStream != null)
                {
                    this.documentStream.Close();
                }
            }
        }
    }

    class VersionComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            string[] xVersions = x.Split('.');
            string[] yVersions = y.Split('.');
            if (xVersions == null || xVersions.Length == 0)
            {
                return -1;
            }
            if (yVersions == null || yVersions.Length == 0)
            {
                return 1;
            }
            int limit = Math.Min(xVersions.Length, yVersions.Length);

            for (int i = 0; i < limit; ++i)
            {
                int xVersion = 0;
                int yVersion = 0;
                if (!int.TryParse(xVersions[i], out xVersion))
                {
                    return -1;
                }

                if (!int.TryParse(yVersions[i], out yVersion))
                {
                    return 1;
                }

                if (xVersion < yVersion)
                {
                    return -1;
                }

                if (xVersion > yVersion)
                {
                    return 1;
                }
            }

            if (xVersions.Length > limit)
            {
                return 1;
            }

            if (yVersions.Length > limit)
            {
                return -1;
            }

            return 0;
        }
    }
}
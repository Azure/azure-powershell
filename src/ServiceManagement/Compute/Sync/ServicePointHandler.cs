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
using System.Net;
using System.Reflection;

namespace Microsoft.WindowsAzure.Commands.Sync
{
    internal class ServicePointHandler : IDisposable
    {
        private bool disposed;
        private ServicePoint servicePoint;
        private int originalConnectionLimit;

        public ServicePointHandler(Uri uri, int connectionLimit)
        {
            this.servicePoint = ServicePointManager.FindServicePoint(uri, GetWebProxy());
            this.originalConnectionLimit = servicePoint.ConnectionLimit;
            servicePoint.ConnectionLimit = connectionLimit;
        }

        private static IWebProxy GetWebProxy()
        {
            Type webRequestType = typeof(WebRequest);
            PropertyInfo propertyInfo = webRequestType.GetProperty("InternalDefaultWebProxy", BindingFlags.Static | BindingFlags.NonPublic);
            return (IWebProxy)propertyInfo.GetValue(null, null);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this.servicePoint.ConnectionLimit = originalConnectionLimit;
                }
                disposed = true;
            }
        }
    }
}
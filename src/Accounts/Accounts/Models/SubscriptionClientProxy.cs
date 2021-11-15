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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using SubscriptionClientVersion2016 = Microsoft.Azure.Commands.ResourceManager.Common.Utilities.SubscriptionClientWrapper;
using SubscriptionClientVersion2021 = Microsoft.Azure.Commands.ResourceManager.Common.Utilities.Version2021_01_01.SubscriptionClientWrapper;

namespace Microsoft.Azure.Commands.Profile.Models
{
    //Use queue to handle the subscription clients priority
    internal class SubscritpionClientCandidates : ConcurrentQueue<ISubscriptionClientWrapper>
    {
        static private ReaderWriterLockSlim instanceLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        static private SubscritpionClientCandidates _instance = null;
        static public SubscritpionClientCandidates Instance
        {
            get
            {
                try
                {
                    instanceLock.EnterWriteLock();
                    try
                    {
                        if (_instance == null)
                        {
                            _instance = new SubscritpionClientCandidates();
                        }
                        return _instance;
                    }
                    finally
                    {
                        instanceLock.ExitWriteLock();
                    }

                }
                catch (LockRecursionException lockException)
                {
                    throw new InvalidOperationException("Exception in locking SubscritpionClientCandidates", lockException);
                }
                catch (ObjectDisposedException disposeExcetion)
                {
                    throw new InvalidOperationException("Exception in disposing", disposeExcetion);
                }
            }
        }

        private SubscritpionClientCandidates()
        {
            Enqueue(new SubscriptionClientVersion2021());
            Enqueue(new SubscriptionClientVersion2016());
        }

        static public void Reset()
        {
            try
            {
                instanceLock.EnterWriteLock();
                _instance = null;
                instanceLock.ExitWriteLock();
            }
            catch (LockRecursionException lockException)
            {
                throw new InvalidOperationException("Exception in locking SubscritpionClientCandidates", lockException);
            }
            catch (ObjectDisposedException disposeExcetion)
            {
                throw new InvalidOperationException("Exception in disposing", disposeExcetion);
            }
        }
    }

    internal class SubscriptionClientProxy : ISubscriptionClientWrapper
    {
        public delegate void LoggerWriter(string message);

        private LoggerWriter WriteWarningMessage = null;

        public SubscriptionClientProxy(LoggerWriter logWriter)
        {
            WriteWarningMessage = logWriter;
        }

        Action<Action<ISubscriptionClientWrapper>, LoggerWriter> SubscriptionClientFallBack = (Action<ISubscriptionClientWrapper> subscriptionClientAction, LoggerWriter warning) =>
        {
            ISubscriptionClientWrapper subscriptionclient = null;
            bool popQueueSuccess = true;
            int retryCount = 3;
            while (SubscritpionClientCandidates.Instance.Count > 0)
            {
                try
                {
                    retryCount = 3;
                    do
                    {
                        popQueueSuccess = SubscritpionClientCandidates.Instance.TryPeek(out subscriptionclient);
                        if (!popQueueSuccess)
                        {
                            Thread.Sleep(1);
                        }
                    } while (!popQueueSuccess && retryCount-- > 0);
                    if (!popQueueSuccess)
                    {
                        throw new Exception("Conncrrent issue. Please try again.");
                    }
                    subscriptionClientAction(subscriptionclient);
                    return;
                }
                catch (CloudException e)
                {
                    if (e.Body == null || string.IsNullOrEmpty(e.Body.Code) || !e.Body.Code.Equals("InvalidApiVersionParameter"))
                    {
                        throw e;
                    }
                    warning($"Failed to use the latest Api of subscription client: {e.Message}");
                    retryCount = 3;
                    do
                    {
                        popQueueSuccess = SubscritpionClientCandidates.Instance.TryDequeue(out subscriptionclient);
                        if (!popQueueSuccess)
                        {
                            Thread.Sleep(1);
                        }
                    } while (!popQueueSuccess && retryCount-- > 0);
                    if (!popQueueSuccess)
                    {
                        throw new Exception("Conncrrent issue. Please try again.");
                    }
                }
            }
            throw new CloudException("Your Api version is not supported by Azure server.");
        };

        public IList<AzureTenant> ListAccountTenants(IAccessToken accessToken, IAzureEnvironment environment)
        {
            IList<AzureTenant> result = null;
            SubscriptionClientFallBack((client) => result = client?.ListAccountTenants(accessToken, environment),
                WriteWarningMessage);
            return result;
        }

        public IList<AzureSubscription> ListAllSubscriptionsForTenant(IAccessToken accessToken, IAzureAccount account, IAzureEnvironment environment)
        {
            IList<AzureSubscription> result = null;
            SubscriptionClientFallBack((client) => result = client?.ListAllSubscriptionsForTenant(accessToken, account, environment),
                WriteWarningMessage);
            return result;
        }

        public AzureSubscription GetSubscriptionById(string subscriptionId, IAccessToken accessToken, IAzureAccount account, IAzureEnvironment environment)
        {
            AzureSubscription result = null;
            SubscriptionClientFallBack((client) => result = client?.GetSubscriptionById(subscriptionId, accessToken, account, environment),
                WriteWarningMessage);
            return result;
        }

        public string ApiVersion
        {
            get
            {
                if (0 < SubscritpionClientCandidates.Instance.Count)
                {
                    ISubscriptionClientWrapper subscriptionclient = null;
                    if (SubscritpionClientCandidates.Instance.TryPeek(out subscriptionclient))
                    {
                        return subscriptionclient.ApiVersion;
                    }
                }
                return string.Empty;
            }
        }
    }
}

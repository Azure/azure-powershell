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

using Microsoft.VisualStudio.EtwListener.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Threading;

namespace Microsoft.VisualStudio.EtwListener.Common
{
    // Allowed state transitions are
    // 
    // Disconnected(start) <----> Connecting ----> Listening
    //   ^                                            |
    //   |____________________________________________|
    //
    internal enum ListenerClientState
    {
        Disconnected = 0,
        Connecting = 1,
        Listening = 2
    }

    /// <summary>
    /// Simple etw listener client which exports start/stop funtions.
    /// </summary>
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    internal class EtwListenerClient : IEtwListenerClient, IDisposable
    {
        private const string RemoteAddressFormat = "net.tcp://{0}:{1}/VsEtwMonListener/Pipe";
        private static readonly TimeSpan HeartbeatPeriod = TimeSpan.FromSeconds(10);

        public ListenerConnectionInfo ConnectionInfo { get; private set; }

        public ListenerSessionConfiguration SessionConfiguration { get; private set; }

        private ListenerClientState state = ListenerClientState.Disconnected;

        public ListenerClientState State
        {
            get { return state; }
            private set
            {
                state = value;

                if (StateChanged != null)
                {
                    StateChanged(this, EventArgs.Empty);
                }
            }
        }

        private object stateLock = new object();

        public event EventHandler<EventsCapturedEventArgs> EtwEventsCaptured;

        public event EventHandler StateChanged;

        private Timer heartbeatTimer;

        private EtwListenerServiceProxy serviceProxy;

        public EtwListenerClient(ListenerConnectionInfo connectionInfo, ListenerSessionConfiguration sessionConfiguration)
        {
            this.ConnectionInfo = connectionInfo;
            this.SessionConfiguration = sessionConfiguration;
        }

        /// <summary>
        /// Implements IEtwListenerClient (callback client)
        /// </summary>
        /// <param name="eventData">Captured event data</param>
        /// <param name="throttled">Throttled</param>
        void IEtwListenerClient.EtwEventsCaptured(IEnumerable<EtwEventData> eventData, bool throttled)
        {
            if (this.state == ListenerClientState.Disconnected)
            {
                // We might get a few residual event notifications after we were closed, 
                // but we should not notify the clients anymore.
                return;
            }

            if (this.EtwEventsCaptured != null)
            {
                this.EtwEventsCaptured(this, new EventsCapturedEventArgs
                {
                    Events = eventData,
                    ListenerThrottling = throttled
                });
            }
        }

        /// <summary>
        /// Start a listener session
        /// </summary>
        public void Start()
        {
            lock (this.stateLock)
            {
                if (this.State != ListenerClientState.Disconnected || this.serviceProxy != null)
                {
                    throw new InvalidOperationException();
                }

                this.State = ListenerClientState.Connecting;

                var listenerProxy = CreateEtwListenerProxy();
                listenerProxy.StartSession(this.SessionConfiguration);

                this.State = ListenerClientState.Listening;

                this.serviceProxy = listenerProxy;
                this.heartbeatTimer = new Timer(CheckHeartbeat, null, HeartbeatPeriod, HeartbeatPeriod);
            }
        }

        /// <summary>
        /// Stop current listener session
        /// </summary>
        public void Stop()
        {
            lock (this.stateLock)
            {
                this.State = ListenerClientState.Disconnected;

                if (this.serviceProxy != null)
                {
                    try
                    {
                        this.serviceProxy.EndSession();
                    }
                    catch (CommunicationException)
                    {
                        // ignore
                    }

                    this.serviceProxy = null;
                }

                if (this.heartbeatTimer != null)
                {
                    this.heartbeatTimer.Dispose();
                    this.heartbeatTimer = null;
                }
            }
        }

        /// <summary>
        /// Implements IDisposable
        /// </summary>
        public void Dispose()
        {
            Stop();
        }

        private EtwListenerServiceProxy CreateEtwListenerProxy()
        {
            var binding = new NetTcpBinding(SecurityMode.Transport);
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;

            binding.MaxReceivedMessageSize = 5 * 1024 * 1024; // important because the default is quite small, and this must be at least as big as the biggest chunk of events we send.

            string remoteServiceFullAddress = string.Format(CultureInfo.InvariantCulture, RemoteAddressFormat, this.ConnectionInfo.IpAddress, this.ConnectionInfo.Port);

            // Need to specify dns identity, otherwise it uses ip address as dns identity which fails the verification. 
            var factory = new DuplexChannelFactory<IEtwListenerService>(this, binding, new EndpointAddress(new Uri(remoteServiceFullAddress), EndpointIdentity.CreateDnsIdentity(this.ConnectionInfo.DnsName)));
            factory.Credentials.ClientCertificate.Certificate = CertificateHelper.FindCertificate(this.ConnectionInfo.ClientCertificateThumbprint);
            factory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom;
            factory.Credentials.ServiceCertificate.Authentication.CustomCertificateValidator = new CertificateValidator(this.ConnectionInfo.ServerCertificateThumbprint);

            IEtwListenerService proxy = factory.CreateChannel();

            IClientChannel channel = (IClientChannel)proxy;
            channel.OperationTimeout = TimeSpan.FromSeconds(15);

            string sessionToken = proxy.GetSessionToken();
            return new EtwListenerServiceProxy(proxy, sessionToken);
        }

        private void CheckHeartbeat(object state)
        {
            try
            {
                this.serviceProxy.HeartBeat();
            }
            catch (Exception)
            {
                Stop();
                throw;
            }
        }
    }
}

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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo
{
    public class AzureEndPointConfigInfo
    {        
        public enum ParameterSet { NoLB, LoadBalancedNoProbe, CustomProbe, DefaultProbe };

        public ProtocolInfo EndpointProtocol { get; set; }
        public int EndpointLocalPort { get; set; }
        public int? EndpointPublicPort { get; set; }
        public string EndpointName { get; set; }
        public string LBSetName { get; set; }
        public int ProbePort { get; set; }
        public ProtocolInfo ProbeProtocol { get; set; }
        public string ProbePath { get; set; }
        public int? ProbeInterval { get; set; }
        public int? ProbeTimeout { get; set; }
        public PersistentVM  Vm { get; set; }
        public ParameterSet ParamSet { get; set; }
        public NetworkAclObject Acl { get; set; }
        public bool DirectServerReturn { get; set; }
        public string ServiceName { get; set; }
        public string InternalLoadBalancerName { get; set; }

        public string LoadBalancerDistribution { get; set; }
        public string VirtualIPName { get; set; }

        public AzureEndPointConfigInfo()
        {
        }

        // NoLB parameter set
        public AzureEndPointConfigInfo(ParameterSet paramset,
            ProtocolInfo endpointProtocol,
            int endpointLocalPort,
            int endpointPublicPort,
            string endpointName,
            NetworkAclObject aclObj = null,
            bool directServerReturn = false,
            string internalLoadBalancer = null,
            string serviceName = null,
            string loadBalancerDistribution = null,
            string VirtualIPName = null)
        {
            this.Initialize(
                endpointProtocol,
                endpointLocalPort,
                endpointPublicPort,
                endpointName, 
                string.Empty, 
                0, 
                ProtocolInfo.tcp, 
                string.Empty, 
                null, 
                null,
                paramset,
                aclObj,
                directServerReturn,
                internalLoadBalancer,
                serviceName,
                loadBalancerDistribution,
                VirtualIPName);
        }

        // LoadBalancedNoProbe/DefaultProbe parameter set
        public AzureEndPointConfigInfo(
            ParameterSet paramset,
            ProtocolInfo endpointProtocol,
            int endpointLocalPort,
            int endpointPublicPort,
            string endpointName,
            string lBSetName,
            NetworkAclObject aclObj = null,
            bool directServerReturn = false,
            string internalLoadBalancer = null,
            string serviceName = null,
            string loadBalancerDistribution = null,
            string VirtualIPName = null)
        {
            if ( (paramset == ParameterSet.LoadBalancedNoProbe) || (paramset == ParameterSet.DefaultProbe) )
            {
                this.Initialize(
                    endpointProtocol,
                    endpointLocalPort,
                    endpointPublicPort,
                    endpointName,
                    lBSetName,
                    0,
                    ProtocolInfo.tcp,
                    string.Empty,
                    null,
                    null,
                    paramset,
                    aclObj,
                    directServerReturn,
                    internalLoadBalancer,
                    serviceName,
                    loadBalancerDistribution,
                    VirtualIPName);
            }
        }

        // CustomProbe parameter set
        public AzureEndPointConfigInfo(
            ParameterSet paramset,
            ProtocolInfo endpointProtocol,
            int endpointLocalPort,
            int endpointPublicPort,
            string endpointName,
            string lBSetName,
            int probePort,
            ProtocolInfo probeProtocol,
            string probePath,
            int? probeInterval,
            int? probeTimeout,
            NetworkAclObject aclObj = null,
            bool directServerReturn = false,
            string internalLoadBalancer= null,
            string serviceName = null,
            string loadBalancerDistribution = null,
            string VirtualIPName = null)
        {
                this.Initialize(
                    endpointProtocol,
                    endpointLocalPort,
                    endpointPublicPort,
                    endpointName,
                    lBSetName,
                    probePort,
                    probeProtocol,
                    probePath,
                    probeInterval,
                    probeTimeout,
                    paramset,
                    aclObj,
                    directServerReturn,
                    internalLoadBalancer,
                    serviceName,
                    loadBalancerDistribution,
                    VirtualIPName);
        }

        public AzureEndPointConfigInfo(AzureEndPointConfigInfo other)
        {
            this.Initialize(
                other.EndpointProtocol,
                other.EndpointLocalPort,
                other.EndpointPublicPort,
                other.EndpointName,
                other.LBSetName,
                other.ProbePort,
                other.ProbeProtocol,
                other.ProbePath,
                other.ProbeInterval,
                other.ProbeTimeout,
                other.ParamSet,
                other.Acl,
                other.DirectServerReturn,
                other.InternalLoadBalancerName,
                other.ServiceName,
                other.LoadBalancerDistribution,
                other.VirtualIPName);
        }

        private void Initialize(
            ProtocolInfo protocol,
            int internalPort,
            int? externalPort,
            string endpointName,
            string lBSetName,
            int probePort,
            ProtocolInfo probeProtocol,
            string probePath,
            int? probeInterval,
            int? probeTimeout,
            ParameterSet paramSet,
            NetworkAclObject aclObj,
            bool directServerReturn,
            string internalLoadBalancer,
            string serviceName,
            string loadBalancerDistribution,
            string VirtualIPName)
        {
            this.EndpointLocalPort = internalPort;
            this.EndpointProtocol = protocol;
            this.EndpointPublicPort = externalPort;
            this.EndpointName = endpointName;
            this.LBSetName = lBSetName;
            this.ProbePort = probePort;
            this.ProbeProtocol = probeProtocol;
            this.ProbeInterval = probeInterval;
            this.ProbeTimeout = probeTimeout;
            this.ParamSet = paramSet;
            this.Acl = aclObj;
            this.DirectServerReturn = directServerReturn;
            if (this.ProbeProtocol.ToString().Equals("http"))
                this.ProbePath = probePath;
            this.InternalLoadBalancerName = internalLoadBalancer;
            this.ServiceName = serviceName;
            this.LoadBalancerDistribution = loadBalancerDistribution;
            this.VirtualIPName = VirtualIPName;
        }

        public bool CheckInputEndpointContext(InputEndpointContext context)
        {
            bool ret = false;

            if (ParamSet == ParameterSet.NoLB)
            {
                ret = (context.Name == this.EndpointName);
            }
            else 
            {
                ret = (context.LBSetName == this.LBSetName);
            }

            ret = ret && context.Protocol == this.EndpointProtocol.ToString()
                && context.LocalPort == this.EndpointLocalPort
                && context.Port == this.EndpointPublicPort             
                && context.EnableDirectServerReturn == this.DirectServerReturn;

            if(context.Acl == null)
            {
                if(this.Acl != null
                    && this.Acl != new NetworkAclObject())
                {
                    ret = false;
                }
            }
            else if (this.Acl != null)
            {
                foreach (var rule in this.Acl)
                {
                    if(!context.Acl.Rules.Contains(rule))
                    {
                        ret = false;
                    }
                }
            }
            else
            {
                ret = false;
            }


            if (ParamSet == ParameterSet.CustomProbe)
            {
                ret = ret && context.LBSetName == this.LBSetName
                    && context.ProbePort == this.ProbePort
                    && context.ProbeProtocol == this.ProbeProtocol.ToString();

                ret = ret && ( this.ProbeInterval.HasValue 
                                ? context.ProbeIntervalInSeconds == this.ProbeInterval 
                                : context.ProbeIntervalInSeconds == 15 );

                ret = ret && ( this.ProbeTimeout.HasValue
                                ? context.ProbeTimeoutInSeconds == this.ProbeTimeout
                                : context.ProbeTimeoutInSeconds == 31 );
            }

            return ret;
        }
        
    }
}

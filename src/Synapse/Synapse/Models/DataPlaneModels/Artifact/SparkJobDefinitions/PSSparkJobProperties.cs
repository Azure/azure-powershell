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

using Azure.Analytics.Synapse.Artifacts.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSparkJobProperties
    {
        public PSSparkJobProperties(SparkJobProperties sparkJobProperties)
        {
            this.Name = sparkJobProperties.Name;
            this.File = sparkJobProperties.File;
            this.ClassName = sparkJobProperties.ClassName;
            this.Configuration = sparkJobProperties.Conf;
            this.Arguments = sparkJobProperties.Args;
            this.Jars = sparkJobProperties.Files;
            this.Archives = sparkJobProperties.Archives;
            this.DriverMemory = sparkJobProperties.DriverMemory;
            this.DriverCores = sparkJobProperties.DriverCores;
            this.ExecutorMemory = sparkJobProperties.ExecutorMemory;
            this.ExecutorCores = sparkJobProperties.ExecutorCores;
            this.NumberOfExecutors = sparkJobProperties.NumExecutors;
        }

        /// <summary> The name of the job. </summary>
        public string Name { get; set; }

        /// <summary> File containing the application to execute. </summary>
        public string File { get; set; }

        /// <summary> Main class for Java/Scala application. </summary>
        public string ClassName { get; set; }

        /// <summary> Spark configuration properties. </summary>
        public object Configuration { get; set; }

        /// <summary> Command line arguments for the application. </summary>
        public IList<string> Arguments { get; }

        /// <summary> Jars to be used in this job. </summary>
        public IList<string> Jars { get; }

        /// <summary> files to be used in this job. </summary>
        public IList<string> Files { get; }

        /// <summary> Archives to be used in this job. </summary>
        public IList<string> Archives { get; }

        /// <summary> Amount of memory to use for the driver process. </summary>
        public string DriverMemory { get; set; }

        /// <summary> Number of cores to use for the driver. </summary>
        public int DriverCores { get; set; }

        /// <summary> Amount of memory to use per executor process. </summary>
        public string ExecutorMemory { get; set; }

        /// <summary> Number of cores to use for each executor. </summary>
        public int ExecutorCores { get; set; }

        /// <summary> Number of executors to launch for this job. </summary>
        public int NumberOfExecutors { get; set; }
    }
}
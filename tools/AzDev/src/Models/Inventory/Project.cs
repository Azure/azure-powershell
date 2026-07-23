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

using System.IO.Abstractions;
using AzDev.Services;

namespace AzDev.Models.Inventory
{
    internal abstract class Project : IFileSystemBasedModel
    {
        public string Name { get; internal set; }
        public string Path { get; internal set; }
        public ProjectType Type { get; internal set; }
        public string TypeDeductionReason { get; internal set; }
        public string SubType { get; internal set; }

        protected IFileSystem FileSystem { get; }

        public override string ToString() => Name;

        protected Project(IFileSystem fs, string path)
        {
            FileSystem = fs;
            Path = path;
        }
        internal Project() { }

        public static Project FromFileSystem(IFileSystem fs, string path)
        {
            Project project;
            string typeDeductionReason;
            if (Conventions.IsLegacyHelperProject(path, out typeDeductionReason))
            {
                project = LegacyHelperProject.FromFileSystem(fs, path);
                project.TypeDeductionReason = typeDeductionReason;
            }
            else if (Conventions.IsTrack1SdkProject(path, out typeDeductionReason))
            {
                project = Track1SdkProject.FromFileSystem(fs, path);
                project.TypeDeductionReason = typeDeductionReason;
            }
            else if (Conventions.IsTestProject(path, out typeDeductionReason))
            {
                project = TestProject.FromFileSystem(fs, path);
                project.TypeDeductionReason = typeDeductionReason;
            }
            else if (Conventions.IsAutorestBasedProject(path, out typeDeductionReason))
            {
                project = AutoRestProject.FromFileSystem(fs, path);
                project.TypeDeductionReason = typeDeductionReason;
            }
            else if (Conventions.IsWrapperProject(fs, path, out typeDeductionReason))
            {
                project = WrapperProject.FromFileSystem(fs, path);
                project.TypeDeductionReason = typeDeductionReason;
            }
            else if (Conventions.IsSdkBasedProject(fs, path, out typeDeductionReason))
            {
                project = SdkBasedProject.FromFileSystem(fs, path);
                project.TypeDeductionReason = typeDeductionReason;
            }
            else
            {
                project = OtherProject.FromFileSystem(fs, path);
                project.TypeDeductionReason = $"[{path}] failed to be identified as any types.";
            }
            return project;
        }
    }

    internal class TestProject : Project
    {
        public TestProject(IFileSystem fs, string path) : base(fs, path)
        {
        }

        public new static TestProject FromFileSystem(IFileSystem fs, string path)
        {
            return new TestProject(fs, path)
            {
                Type = ProjectType.Test,
                Name = fs.Path.GetFileName(path)
            };
        }
    }

    internal class LegacyHelperProject : Project
    {
        public LegacyHelperProject(IFileSystem fs, string path) : base(fs, path)
        {
        }

        public new static LegacyHelperProject FromFileSystem(IFileSystem fs, string path)
        {
            return new LegacyHelperProject(fs, path)
            {
                Type = ProjectType.LegacyHelper,
                Name = fs.Path.GetFileName(path)
            };
        }
    }

    internal class Track1SdkProject : Project
    {
        public Track1SdkProject(IFileSystem fs, string path) : base(fs, path)
        {
        }

        public new static Track1SdkProject FromFileSystem(IFileSystem fs, string path)
        {
            return new Track1SdkProject(fs, path)
            {
                Type = ProjectType.Track1Sdk,
                Name = fs.Path.GetFileName(path)
            };
        }
    }
}

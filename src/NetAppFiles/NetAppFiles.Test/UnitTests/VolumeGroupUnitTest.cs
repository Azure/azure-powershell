using Microsoft.Azure.Commands.NetAppFiles.VolumeGroup;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
//using Microsoft.Azure.Commands.NetAppFiles.VolumeGroup;

namespace Microsoft.Azure.Commands.NetAppFiles.UnitTest
{    
    public class VolumeGroupUnitTest
    {
        [Fact]
        public void DataThroughputCalculation1024ShouldReturn400()
        {
            int expectedThroughput = 400;
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateThroughput(1024, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data);
            Assert.Equal(expectedThroughput, throughput);
        }

        [Fact]
        public void DataThroughputCalculation2048ShouldReturn600()
        {
            int expectedThroughput = 600;
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateThroughput(2048, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data);
            Assert.Equal(expectedThroughput, throughput);
        }

        [Fact]
        public void DataThroughputCalculation3063ShouldReturn800()
        {
            int expectedThroughput = 800;
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateThroughput(3063, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data);
            Assert.Equal(expectedThroughput, throughput);
        }

        [Fact]
        public void DataThroughputCalculation5120ShouldReturn1000()
        {
            int expectedThroughput = 1000;
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateThroughput(5120, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data);
            Assert.Equal(expectedThroughput, throughput);
        }

        [Fact]
        public void DataThroughputCalculation7168ShouldReturn1200()
        {
            int expectedThroughput = 1200;
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateThroughput(7168, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data);
            Assert.Equal(expectedThroughput, throughput);
        }

        [Fact]
        public void DataThroughputCalculation6216ShouldReturn1400()
        {
            int expectedThroughput = 1400;
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateThroughput(9216, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data);
            Assert.Equal(expectedThroughput, throughput);
        }

        [Fact]
        public void DataThroughputCalculation10240ShouldReturn1400()
        {
            int expectedThroughput = 1400;
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateThroughput(10240, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data);
            Assert.Equal(expectedThroughput, throughput);
        }

        [Fact]
        public void DataThroughputCalculation11264ShouldReturn1500()
        {
            int expectedThroughput = 1500;
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateThroughput(11264, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data);
            Assert.Equal(expectedThroughput, throughput);
        }

        [Fact]
        public void LogThroughputCalculation4096ShouldReturn250()
        {
            int expectedThroughput = 250;
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateThroughput(4096, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Log);
            Assert.Equal(expectedThroughput, throughput);
        }

        [Fact]
        public void LogThroughputCalculation5120ShouldReturn500()
        {
            int expectedThroughput = 500;
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateThroughput(5120, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Log);
            Assert.Equal(expectedThroughput, throughput);
        }

        [Fact]
        public void DataVolumeNameScaleup()
        {
            string expectedVolumeName = "SH1-data-mnt00001";
            var volumeName = NewAzureRmNetAppFilesVolumeGroup.GenerateVolumeName(NewAzureRmNetAppFilesVolumeGroup.DefaultSapSystemId, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data, 1, NewAzureRmNetAppFilesVolumeGroup.SystemRoles.PRIMARY, null);
            Assert.Equal(expectedVolumeName, volumeName);
        }

        [Fact]
        public void DataVolumeNameScaleoutHost1()
        {
            string expectedVolumeName = "SH1-data-mnt00001";
            var volumeName = NewAzureRmNetAppFilesVolumeGroup.GenerateVolumeName(NewAzureRmNetAppFilesVolumeGroup.DefaultSapSystemId, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data, 1, NewAzureRmNetAppFilesVolumeGroup.SystemRoles.PRIMARY, null);
            Assert.Equal(expectedVolumeName, volumeName);
        }

        [Fact]
        public void DataVolumeNameScaleoutHost2()
        {
            string expectedVolumeName = "SH1-data-mnt00002";
            var volumeName = NewAzureRmNetAppFilesVolumeGroup.GenerateVolumeName(NewAzureRmNetAppFilesVolumeGroup.DefaultSapSystemId, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data, 2, NewAzureRmNetAppFilesVolumeGroup.SystemRoles.PRIMARY, null);
            Assert.Equal(expectedVolumeName, volumeName);
        }

        [Fact]
        public void LogVolumeNameScaleup()
        {
            string expectedVolumeName = "SH1-log-mnt00001";
            var volumeName = NewAzureRmNetAppFilesVolumeGroup.GenerateVolumeName(NewAzureRmNetAppFilesVolumeGroup.DefaultSapSystemId, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Log, 1, NewAzureRmNetAppFilesVolumeGroup.SystemRoles.PRIMARY, null);
            Assert.Equal(expectedVolumeName, volumeName);
        }

        [Fact]
        public void SharedVolumeNameScaleup()
        {
            string expectedVolumeName = "SH1-shared";
            var volumeName = NewAzureRmNetAppFilesVolumeGroup.GenerateVolumeName(NewAzureRmNetAppFilesVolumeGroup.DefaultSapSystemId, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Shared, 1, NewAzureRmNetAppFilesVolumeGroup.SystemRoles.PRIMARY, null);
            Assert.Equal(expectedVolumeName, volumeName);
        }
    }
}

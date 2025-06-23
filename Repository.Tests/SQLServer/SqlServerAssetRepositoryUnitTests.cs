using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repository.Implementations.SQLServer;
using Repository.Interfaces;

namespace Repository.Tests.SQLServer
{
    [TestClass]
    public class SqlServerAssetRepositoryTests
    {
        private Mock<IDatabaseProvider> _dbMock;
        private SqlServerAssetRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            _dbMock = new Mock<IDatabaseProvider>();
            _repository = new SqlServerAssetRepository(_dbMock.Object);
        }

        [TestMethod]
        public void GetByGuid_Returns_Expected_Asset()
        {
            // Arrange
            var expectedGuid = Guid.NewGuid();
            var expectedAsset = new Asset
            {
               
            };

            _dbMock.Setup(db => db.QuerySingle<Asset>(
                It.IsAny<string>(),
                It.Is<object>(p => ((dynamic)p).Guid == expectedGuid)))
                .Returns(expectedAsset);

            // Act
            var result = _repository.GetByGuid(expectedGuid);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAsset_Returns_Expected_Asset()
        {
            // Arrange
            int assetId = 10;
            AssetType assetType = AssetType.MH;

            var expectedAsset = new Asset();

            _dbMock.Setup(db => db.QuerySingle<Asset>(
                It.IsAny<string>(),
                It.Is<object>(p => ((dynamic)p).Id == assetId && ((dynamic)p).AssetType == (int)assetType)))
                .Returns(expectedAsset);

            // Act
            var result = _repository.GetAsset(assetType, assetId, loadInspections: false);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAsset_Returns_Null_When_Not_Found()
        {
            // Arrange
            _dbMock.Setup(db => db.QuerySingle<Asset>(
                It.IsAny<string>(),
                It.IsAny<object>()))
                .Returns((Asset)null); // simulate not found

            // Act
            var result = _repository.GetAsset(AssetType.MH, 9999, loadInspections: false);

            // Assert
            Assert.IsNull(result);
        }
    }
}

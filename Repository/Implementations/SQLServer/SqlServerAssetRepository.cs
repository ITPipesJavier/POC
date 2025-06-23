using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Repository.Interfaces;

namespace Repository.Implementations.SQLServer
{
    public class SqlServerAssetRepository : IAssetRepository
    {
        private readonly IDatabaseProvider _db;

        public SqlServerAssetRepository(IDatabaseProvider db) 
        {
            _db = db;
        }

        public Asset GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public Asset GetAsset(AssetType assetType, int assetId, bool loadInspections)
        {
            string sql = @"SELECT Id, Guid, Name, AssetType, CreatedAt, UpdatedAt
                       FROM Assets
                       WHERE Id = @Id AND AssetType = @AssetType";

            var asset = _db.QuerySingle<Asset>(sql, new { Id = assetId, AssetType = (int)assetType });

            if (loadInspections && asset != null)
            {
                // Example: Load inspections manually if needed
                // var inspections = _db.Query<Inspection>("SELECT * FROM Inspections WHERE AssetId = @Id", new { Id = assetId });
                // asset.Inspections = inspections.ToList();
            }

            return asset;
        }
    }
}

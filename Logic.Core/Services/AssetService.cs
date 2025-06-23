using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Logic.Core.Interfaces;
using Repository.Interfaces;

namespace Logic.Core.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _repo;

        public AssetService(IAssetRepository repo)
        {
            _repo = repo;
        }

        public Asset GetByGuid(Guid id)
        {
            return _repo.GetByGuid(id);
        }

        public int GetNewPipeNumber(int inspId)
        {
            throw new NotImplementedException();
        }

        public Asset GetAsset(AssetType assetType, int assetID, bool loadInspections = false)
        {
            return _repo.GetAsset(assetType, assetID, loadInspections);
        }

        public List<Asset> GetAssets(AssetType assetType, List<int> assetIDs, bool loadInspections = false,
            bool mediaFilePathExistenceCheck = true)
        {
            throw new NotImplementedException();
        }

        public List<Asset> GetAssetsByInspectionIds(AssetType assetType, List<int> inspIDs, bool loadInspections = false)
        {
            throw new NotImplementedException();
        }

        public List<Asset> GetAssets(AssetType assetType)
        {
            throw new NotImplementedException();
        }

        public List<Asset> GetAssetsByCriterias(string clientId, SyncTransferSettings settings)
        {
            throw new NotImplementedException();
        }

        public List<Asset> GetAssetsByCriterias(List<SyncCriteria> syncCriterias)
        {
            throw new NotImplementedException();
        }

        public Asset GetPipeHeightAssetUseFromObsId(AssetType assetType, int obsID)
        {
            throw new NotImplementedException();
        }

        public Asset GetPipeHeightAssetUseFromInspectionId(AssetType assetType, int inspID)
        {
            throw new NotImplementedException();
        }

        public DataTable GetITAssetRowTable(AssetType assetType, int assetID)
        {
            throw new NotImplementedException();
        }

        public Asset GetAsset(AssetType assetType, List<TField> assetFields, int assetID)
        {
            throw new NotImplementedException();
        }

        public List<int> GetAllAssetIDs(AssetType assetType)
        {
            throw new NotImplementedException();
        }

        public int GetAssetIDFromInspID(AssetType assetType, int inspID)
        {
            throw new NotImplementedException();
        }

        public List<int> GetPKIDs(string TableName, List<List<QueryParamItem>> queryParams)
        {
            throw new NotImplementedException();
        }

        public int GetPKFromGUID(AssetType assetType, TableType tableType, string mergeGuid)
        {
            throw new NotImplementedException();
        }

        public string GetGUIDFromPK(AssetType assetType, TableType tableType, int pk)
        {
            throw new NotImplementedException();
        }

        public string GetAssetNameFromInspID(AssetType assetType, int inspID)
        {
            throw new NotImplementedException();
        }

        public string GetAssetNameFromID(AssetType assetType, int assetID)
        {
            throw new NotImplementedException();
        }

        public void UpdateDigitalTime(AssetType assetType)
        {
            throw new NotImplementedException();
        }
    }
}

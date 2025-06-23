using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using System.Data;

namespace Logic.Core.Interfaces
{
    public interface IAssetService
    {
        int GetNewPipeNumber(int inspId);
        Asset GetAsset(AssetType assetType, int assetID, bool loadInspections = false);
        List<Asset> GetAssets(AssetType assetType, List<int> assetIDs, bool loadInspections = false,
            bool mediaFilePathExistenceCheck = true);
        List<Asset> GetAssetsByInspectionIds(AssetType assetType, List<int> inspIDs, bool loadInspections = false);
        List<Asset> GetAssets(AssetType assetType);
        List<Asset> GetAssetsByCriterias(string clientId, SyncTransferSettings settings);
        List<Asset> GetAssetsByCriterias(List<SyncCriteria> syncCriterias);
        Asset GetPipeHeightAssetUseFromObsId(AssetType assetType, int obsID);
        Asset GetPipeHeightAssetUseFromInspectionId(AssetType assetType, int inspID);
        DataTable GetITAssetRowTable(AssetType assetType, int assetID);
        Asset GetAsset(AssetType assetType, List<TField> assetFields, int assetID);
        List<int> GetAllAssetIDs(AssetType assetType);
        int GetAssetIDFromInspID(AssetType assetType, int inspID);
        List<int> GetPKIDs(String TableName, List<List<QueryParamItem>> queryParams);
        int GetPKFromGUID(AssetType assetType, TableType tableType, string mergeGuid);
        string GetGUIDFromPK(AssetType assetType, TableType tableType, int pk);
        string GetAssetNameFromInspID(AssetType assetType, int inspID);
        string GetAssetNameFromID(AssetType assetType, int assetID);
        void UpdateDigitalTime(AssetType assetType);
    }
}

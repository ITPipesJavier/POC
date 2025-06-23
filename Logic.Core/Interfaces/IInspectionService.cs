using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Data;
using System.Threading;
using System.Collections.Concurrent;
using Domain.Entities.Inspections;

namespace Logic.Core.Interfaces
{
    public interface IInspectionService
    {
        Inspection GetInspection(AssetType assetType, List<TField> inspFields, int inspID, bool checkFileExists = true);
        DataTable GetITInspectionRowTable(AssetType assetType, int inspID);
        List<InspDate> GetInspectionDates(AssetType assetType, int assetID, bool isRestritedToReviewedByOnly = false);
        DateTime GetInspectionDate(AssetType assetType, int inspID);
        bool GetIsImperial(AssetType assetType, int inspID);
        int GetInspIDFromObsID(AssetType assetType, int obsID);
        List<int> GetAllInspIDs(AssetType assetType);

        List<int> GetInspIDsFromAssetIDs(AssetType assetType, List<int> assetIDs,
            ReportInspections reportInspections = ReportInspections.All);
        List<int> GetInspIDsFromAssetID(AssetType assetType, int assetID);

        List<Inspection> GetInspectionsFromAssetID(AssetType assetType, int assetID,
            bool mediaFilePathExistenceCheck = true);
        List<int> GetLatInspIDsFromMlInspIDs(List<int> assetInspIDs);
        List<SubmitHyperlinkViewModel> GetInspectionsForAcceptReject(ITAssetType assetType, List<int> ids);
        int GetNewestCompleteInspID(AssetType assetType, int assetID);
        List<CustomFieldModel> GetUpdatedScoringFields(AssetType assetType, int inspID);
        void UpdateAIProcessingStatus(AssetType assetType, List<int> inspIDs, AIProcessingStatus status);
        void UpdateInspectionTime(AssetType assetType, int inspID, int minutes);

        void UpdateInspectionSubmitCommentStatus(AssetType assetType, int inspID, string status,
            string submitComment);

        List<string> InspectionBeginValidation(AssetType assetType, int inspID);

        List<string> InspectionValidation(AssetType assetType, int inspID, Asset itAsset = null,
            Inspection itInspection = null);

        Task<List<string>> InspectionExportValidation(AssetType assetType, List<int> inspIDs, CancellationToken cts,
            string signalRConnectionId = null);

        Task<ConcurrentDictionary<int, List<string>>>
            InspectionExportValidation(AssetType assetType, List<int> inspIDs);
    }
}

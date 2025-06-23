using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Domain.Entities.Inspections;

namespace Logic.Core.Interfaces
{
    public interface IObservationService
    {
        List<Observation> GetObservations(AssetType assetType, int inspID, bool checkFileExists = true);
        Observation GetObservation(AssetType assetType, int obsID, bool checkFileExists = true);

        List<Observation> GetObservationsSimplified(AssetType assetType, List<TField> obsFields, int inspID,
            bool checkFileExists = true, bool loadMedia = true);

        List<Observation> GetObsFilterPlotResults(AssetListRequestModel assetReq, TabHeaderModel tab,
            FilterModel filter);

        List<Observation> LoadObservationMedia(AssetType assetType, List<Observation> obs,
            bool checkFileExists = false);

        List<Observation> GetObservations(AssetType assetType, List<TField> obsFields, int inspID,
            bool checkFileExists = true);

        Observation GetObservation(AssetType assetType, List<TField> obsFields, int obsID, bool checkFileExists = true);
        void ResolveTCodes(AssetType assetType, List<Observation> obsList);
        DataTable GetITObservationRowsTable(AssetType assetType, int inspID);
        List<int> GetObsIDsFromInspID(AssetType assetType, int inspID);
    }
}

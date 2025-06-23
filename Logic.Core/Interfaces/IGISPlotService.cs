using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.GISPlot;

namespace Logic.Core.Interfaces
{
    public interface IGISPlotService
    {
        List<GISPlot> GISPlotResults(AssetType assetType, List<GISPlotRequest> assets, TabHeaderModel tab,
            FilterModel filter, QuickSearchModel quickSearch = null, bool loadMedia = false,
            bool reviewOnlyInspections = false);

        GISPlot GISPlotGetAssetInfo(AssetType assetType, GISPlotRequest assetReq,
            bool restrictedToReviewedOnlyInspections = false);
    }
}

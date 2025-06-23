using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Repository.Interfaces
{
    public interface IAssetRepository
    {
        Asset GetByGuid(Guid id);
        Asset GetAsset(AssetType assetType, int assetId, bool loadInspections);
    }
}

using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Core.Interfaces
{
    public interface IWorkOrderService
    {
        int GetPKFromWOID(AssetType assetType, string workorderID);
    }
}

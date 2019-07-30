using AssetManagement.Models;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Repositories.Interfaces
{
    public interface IAssetRepository
    {
        List<Asset> Get();
        Asset Get(int id);
        List<Asset> Get(string value);
        bool Insert(AssetVM assetVM);
        bool Update(int Id, AssetVM assetVMM);
        bool Delete(int Id);
    }
}

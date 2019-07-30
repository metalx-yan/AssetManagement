using AssetManagement.Models;
using AssetManagement.Repositories;
using AssetManagement.Repositories.Interfaces;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Controllers
{
    public class AssetsController
    {
        IAssetRepository iAssetRepository = new AssetRepository();
        public List<Asset> Get()
        {
            return iAssetRepository.Get();
        }
        public Asset Get(int id)
        {
            return iAssetRepository.Get(id);
        }
        public List<Asset> Get(string value)
        {
            return iAssetRepository.Get(value);
        }
        public bool Insert(AssetVM assetVM)
        {
            return iAssetRepository.Insert(assetVM);
        }
        public bool Update(int Id, AssetVM assetVM)
        {
            return iAssetRepository.Update(Id, assetVM);
        }
        public bool Delete(int Id)
        {
            return iAssetRepository.Delete(Id);
        }
    }
}

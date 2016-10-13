using STDShop.Common;
using STDShop.Data.Infrastructure;
using STDShop.Data.Repositories;
using STDShop.Model.Models;
using System.Collections.Generic;

namespace STDShop.Service
{
    public interface ICommonService
    {
        Footer GetFooter();
        IEnumerable<Slide> GetSlides();
        SystemConfig GetSystemConfig(string code);
    }

    public class CommonService : ICommonService
    {
        private IFooterRepository _footerRepository;
        private IUnitOfWork _unitOfWork;
        ISlideRepository _slideRepository;
        ISystemConfigRepository _systemConfigRepository;

        public CommonService(IFooterRepository footerRepository, ISystemConfigRepository systemConfigRepository, IUnitOfWork unitOfWork, ISlideRepository slideRepository)
        {
            _footerRepository = footerRepository;
            _systemConfigRepository = systemConfigRepository;
            _slideRepository = slideRepository;
        }

        public Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(x => x.ID == CommonConstants.DefaultFooterId);
        }
        public IEnumerable<Slide> GetSlides()
        {
            return _slideRepository.GetMulti(x => x.Status);
        }
        public SystemConfig GetSystemConfig(string code)
        {
            return _systemConfigRepository.GetSingleByCondition(x => x.Code == code);
        }
    }
}
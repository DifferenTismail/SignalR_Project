using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class SocialMeadiaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMeadiaDal;

        public SocialMeadiaManager(ISocialMediaDal socialMeadiaDal)
        {
            _socialMeadiaDal = socialMeadiaDal;
        }

        public void TAdd(SocialMedia entity)
        {
            _socialMeadiaDal.Add(entity);
        }

        public void TDelete(SocialMedia entity)
        {
            _socialMeadiaDal.Delete(entity);
        }

        public SocialMedia TGetById(int id)
        {
            return _socialMeadiaDal.GetById(id);
        }

        public List<SocialMedia> TGetListAll()
        {
            return _socialMeadiaDal.GetListAll();
        }

        public void TUpdate(SocialMedia entity)
        {
            _socialMeadiaDal.Update(entity);
        }
    }
}

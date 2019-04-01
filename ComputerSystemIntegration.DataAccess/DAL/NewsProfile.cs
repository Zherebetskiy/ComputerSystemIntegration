using AutoMapper;
using ComputerSystemIntegration.Domain.Models;

namespace ComputerSystemIntegration.DataAccess.DAL
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<NewsEntity, News>();
            CreateMap<News, NewsEntity>();
        }
    }
}

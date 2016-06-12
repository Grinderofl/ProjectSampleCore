using AutoMapper;
using ProjectSampleCore.Areas.Basket.Models;
using ProjectSampleCore.Core.Domain;
using ProjectSampleCore.Infrastructure.AutoMapper;

namespace ProjectSampleCore.Areas.Basket.Mapping
{
    public class BasketProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<BasketItem, BasketListItem>();
        }
    }
}
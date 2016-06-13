using AutoMapper;
using ProjectSampleCore.Core.Domain;
using ProjectSampleCore.Features.Basket.Models;

namespace ProjectSampleCore.Features.Basket.Mapping
{
    public class BasketProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<BasketItem, BasketListItem>();
        }
    }
}
using AutoMapper;
using Menofia_Portal.Core.Entities;
using Monofia_Portal.Services.DTOs;

namespace Monofia_Portal.Services.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PortalNews, NewsDto>()
                .ForMember(
                    dest => dest.Header,
                    opt => opt.MapFrom(N => N.Translations.Select(T => T.Header)))
                .ForMember(
                    dest => dest.Abbreviation,
                    opt => opt.MapFrom(N => N.Translations.Select(T => T.Abbreviation)))
                .ForMember(
                    dest => dest.NewsId,
                    opt => opt.MapFrom(N => N.News_Id))
                .ForMember(
                    dest => dest.Body,
                    opt => opt.MapFrom(N => N.Translations.Select(T => T.Body)))
                .ForMember(
                    dest => dest.Images,
                    opt => opt.MapFrom(N => N.Images.Select(i => i.NewsUrl)))
                .ForMember(
                    dest => dest.langId,
                    opt => opt.MapFrom(N => N.Translations.Select(i => i.LangId)))
                .ForMember(
                    dest => dest.isFeatured,
                    opt => opt.MapFrom(N => N.IsFeature));
        }
    }
}

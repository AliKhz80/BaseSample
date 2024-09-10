using Application.Features.SampleModel.Commands.CreateSampleModel;
using Application.Features.SampleModel.Commands.UpdateSampleModel;
using Application.Features.SampleModel.ViewModels;
using AutoMapper;

namespace Application.Features.SampleModel
{
    public static class SampleModelMapper
    {
        public static SampleModelViewModel ToViewModel(this Domain.Models.SampleModel input)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Domain.Models.SampleModel, SampleModelViewModel>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(
                           src => src.Gender)));

            var mapper = new Mapper(config);

            return mapper.Map<SampleModelViewModel>(input);
        }

        public static IReadOnlyList<SampleModelViewModel> ToViewModel(this IReadOnlyList<Domain.Models.SampleModel> input)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Domain.Models.SampleModel, SampleModelViewModel>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(
                           src => src.Gender)));

            var mapper = new Mapper(config);

            return mapper.Map<IReadOnlyList<SampleModelViewModel>>(input);
        }

        public static Domain.Models.SampleModel ToEntity(this CreateSampleModelCommand input)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<CreateSampleModelCommand, Domain.Models.SampleModel>());

          


            var mapper = new Mapper(config);

            return mapper.Map<Domain.Models.SampleModel>(input);
        }

        public static Domain.Models.SampleModel ToEntity(this UpdateSampleModelCommand input, Domain.Models.SampleModel entity)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<UpdateSampleModelCommand, Domain.Models.SampleModel>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)));
            var mapper = new Mapper(config);
            return mapper.Map(input, entity);
        }
    }
}

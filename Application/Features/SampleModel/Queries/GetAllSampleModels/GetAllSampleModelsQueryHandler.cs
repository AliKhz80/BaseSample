using Application.Features;
using Application.Features.SampleModel.ViewModels;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.SampleModel.Queries.GetAllSampleModels;

public class GetAllSampleModelsQueryHandler(IBaseSampleUnitOfWork unitOfWork) : IRequestHandler<GetAllSampleModelsQuery, IReadOnlyList<SampleModelViewModel>>
{
    public async Task<IReadOnlyList<SampleModelViewModel>> Handle(GetAllSampleModelsQuery request, CancellationToken cancellationToken)
    {
        var entities = await unitOfWork.SampleModelRepository.GetAllAsync(cancellationToken);
        var viewModels = entities.ToViewModel();
        return viewModels;
    }
}
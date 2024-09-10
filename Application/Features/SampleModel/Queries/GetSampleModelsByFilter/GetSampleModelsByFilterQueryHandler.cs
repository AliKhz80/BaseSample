using Application.Extentions;
using Application.Features.SampleModel.Specifications.SampleModel;
using Application.Features.SampleModel.ViewModels;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.SampleModel.Queries.GetSampleModelsByFilter;

public class GetSampleModelsByFilterQueryHandler(IBaseSampleUnitOfWork unitOfWork) : IRequestHandler<GetSampleModelsByFilterQuery, Paging<SampleModelViewModel>>
{
    public async Task<Paging<SampleModelViewModel>> Handle(GetSampleModelsByFilterQuery request, CancellationToken cancellationToken)
    {
        var specification = new GetSampleModelsByFilterSpecification(request);
        var (totalCount, data) = await unitOfWork.SampleModelRepository.ListAsync(specification, cancellationToken);

        var viewModel = data.ToViewModel();
        var pagedList = Paging<SampleModelViewModel>.Create(request.PageSize, request.PageNumber, totalCount, viewModel);

        return pagedList;
    }
}
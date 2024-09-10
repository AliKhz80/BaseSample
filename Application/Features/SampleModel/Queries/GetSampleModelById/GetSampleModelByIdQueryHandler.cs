using Application.Extentions.LogicException;
using Application.Features.SampleModel.ViewModels;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.SampleModel.Queries.GetSampleModelById;

public class GetSampleModelByIdQueryHandler(IBaseSampleUnitOfWork unitOfWork) : IRequestHandler<GetSampleModelByIdQuery, SampleModelViewModel>
{
    public async Task<SampleModelViewModel> Handle(GetSampleModelByIdQuery request, CancellationToken cancellationToken)
    {
        var existEntity = await unitOfWork.SampleModelRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new LogicException(Resources.ErrorMassages.NotFoundData);

        var viewModel = existEntity.ToViewModel();


        return viewModel;
    }
}
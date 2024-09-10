using Application.Features.SampleModel.ViewModels;
using MediatR;

namespace Application.Features.SampleModel.Queries.GetAllSampleModels;

public record GetAllSampleModelsQuery(
    ) : IRequest<IReadOnlyList<SampleModelViewModel>>;

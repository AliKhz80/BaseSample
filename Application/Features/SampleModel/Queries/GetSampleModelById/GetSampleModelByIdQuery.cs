using Application.Features.SampleModel.ViewModels;
using MediatR;

namespace Application.Features.SampleModel.Queries.GetSampleModelById;

public record GetSampleModelByIdQuery(
    int Id
    ) : IRequest<SampleModelViewModel>;

using MediatR;

namespace Application.Features.SampleModel.Commands.DeleteSampleModel;

public record DeleteSampleModelCommand(
    int Id
    ) : IRequest<bool>;
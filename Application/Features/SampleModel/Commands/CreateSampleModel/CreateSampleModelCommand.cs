using Domain.Enums;
using MediatR;

namespace Application.Features.SampleModel.Commands.CreateSampleModel;

public record CreateSampleModelCommand(
    string FirstName,
    string LastName,
    int Age,
    GenderEnum Gender,
    string Address
    ) : IRequest<CreateSampleModelCommandResponse>;
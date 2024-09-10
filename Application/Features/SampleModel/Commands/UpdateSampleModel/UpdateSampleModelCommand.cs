using Domain.Enums;
using MediatR;

namespace Application.Features.SampleModel.Commands.UpdateSampleModel;

public record UpdateSampleModelCommand(
    int Id,
    string FirstName,
    string LastName,
    int Age,
    GenderEnum Gender,
    string Address
    ) : IRequest<UpdateSampleModelCommandResponse>;
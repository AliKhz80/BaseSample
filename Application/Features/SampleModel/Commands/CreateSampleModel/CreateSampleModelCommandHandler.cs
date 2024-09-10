using Domain.Interfaces;
using MediatR;

namespace Application.Features.SampleModel.Commands.CreateSampleModel;

public class CreateSampleModelCommandHandler(
    IBaseSampleUnitOfWork unitOfWork
    ) : IRequestHandler<CreateSampleModelCommand, CreateSampleModelCommandResponse>
{

    public async Task<CreateSampleModelCommandResponse> Handle(CreateSampleModelCommand request, CancellationToken cancellationToken)
    {
        
        var entity = request.ToEntity();
        await unitOfWork.SampleModelRepository.AddAsync(entity);
        await unitOfWork.CommitAsync();


        var result = new CreateSampleModelCommandResponse(entity.Id);
        return result;
    }
}

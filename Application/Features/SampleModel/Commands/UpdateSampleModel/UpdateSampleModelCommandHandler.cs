
using Application.Extentions.LogicException;
using Application.Features.SampleModel;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.SampleModel.Commands.UpdateSampleModel;

public class UpdateSampleModelCommandHandler(IBaseSampleUnitOfWork unitOfWork) : IRequestHandler<UpdateSampleModelCommand, UpdateSampleModelCommandResponse>
{
    public async Task<UpdateSampleModelCommandResponse> Handle(UpdateSampleModelCommand request, CancellationToken cancellationToken)
    {
        var entities = await unitOfWork.SampleModelRepository.GetAllAsync(cancellationToken);
        if (entities.Any(x =>
                x.Id != request.Id &&
                x.Address.Equals(request.Address, StringComparison.OrdinalIgnoreCase)))
        {
            throw new LogicException(Resources.ErrorMassages.DataExisted);
        }

        var existEntity = await unitOfWork.SampleModelRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new LogicException(Resources.ErrorMassages.NotFoundData);

        var entity = request.ToEntity(existEntity);
        await unitOfWork.SampleModelRepository.UpdateAsync(entity, cancellationToken);
        await unitOfWork.CommitAsync();

        UpdateSampleModelCommandResponse updateSampleModelCommandResponse = new(entity.Id);


        return updateSampleModelCommandResponse;
    }
}
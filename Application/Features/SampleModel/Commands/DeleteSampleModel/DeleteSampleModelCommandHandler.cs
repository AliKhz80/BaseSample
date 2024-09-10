

using Application.Extentions.LogicException;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.SampleModel.Commands.DeleteSampleModel;

public class DeleteSampleModelCommandHandler(
    IBaseSampleUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteSampleModelCommand, bool>
{

    public async Task<bool> Handle(DeleteSampleModelCommand request, CancellationToken cancellationToken)
    {
        var existEntity = await unitOfWork.SampleModelRepository.GetByIdAsync(request.Id)
            ?? throw new LogicException(Resources.ErrorMassages.NotFoundData);

        await unitOfWork.SampleModelRepository.DeleteAsync(existEntity);
        await unitOfWork.CommitAsync();



        return true;
    }
}
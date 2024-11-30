using examen_final.Domain.Abstractions;
using MediatR;

namespace examen_final.Application.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand
{

}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
{

}
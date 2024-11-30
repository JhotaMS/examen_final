using examen_final.Domain.Abstractions;
using MediatR;

namespace examen_final.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{

}
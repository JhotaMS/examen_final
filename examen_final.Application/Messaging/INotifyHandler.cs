using MediatR;

namespace examen_final.Application.Messaging;

public interface INotifyHandler<TCommand> : INotificationHandler<TCommand>
where TCommand : INotify {

}

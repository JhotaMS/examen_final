namespace examen_final.Domain.Abstractions;
public interface IEntityBase<T> {
    T Id { get; init; }
}

namespace examen_final.Application.Exceptions;

public class BadRequestApplicationException : ApplicationException {
    public BadRequestApplicationException( string? message ) : base( message ) {

    }
}

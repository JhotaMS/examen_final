namespace examen_final.Domain.Vegetables.Exceptions;
public class MaximumLimitException : ApplicationException {
    public MaximumLimitException() 
        : base( "Ha superado el límite máximos a adición a la suscripción" ) {

    }
}

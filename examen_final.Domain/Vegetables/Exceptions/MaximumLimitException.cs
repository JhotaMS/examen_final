namespace examen_final.Domain.Vegetables.Exceptions;
public class MaximumLimitException : ApplicationException {
    public MaximumLimitException() 
        : base( "Ha superado el límite máximos de adición a la suscripción" ) {

    }
}

namespace examen_final.Domain.Vegetables.Exceptions;
internal class PackageNotFoundException : ApplicationException {
    public PackageNotFoundException()
        : base( "El tipo de paquete no fue encontrado" ) {

    }
}
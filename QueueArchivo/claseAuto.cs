public class Auto
{
    public string Patente { get; set; }
    public string TipoCombustible { get; set; }

    public Auto(string patente, string tipoCombustible)
    {
        Patente = patente;
        TipoCombustible = tipoCombustible;
    }

    // Sobrescribimos ToString para facilitar el mostrado en lista
    public override string ToString()
    {
        return $"Patente: {Patente} | Combustible: {TipoCombustible}";
    }
}
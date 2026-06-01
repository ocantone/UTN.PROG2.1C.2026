using System;
using System.Collections.Generic;

public class CRevista
{
//********************************************
//1) Variables miembro
    private string codigo;
    private string titulo;
    private float costoBase;
    private static float descuentoAnual;

//********************************************
// 2) Getter y Setter para costoBase
    public void SetCostoBase(float costoBase)
    {
        this.costoBase = costoBase;
    }
    public float GetCostoBase()
    {
        return this.costoBase;
    }
    /* Esto no porque produce recursividad infinta.
    public float costoBase
    {
        get { return costoBase; }
        set { costoBase = value; }
    }
    */

    //********************************************
    // 3) Propiedad de lectura y escritura para descuentoAnual
    public float DescuentoAnual
    {
        get { return descuentoAnual; }
        set { descuentoAnual = value; }
    }

    //********************************************
    // 4) Constructor parametrizado
    public CRevista(string codigo, string titulo)
    {
        this.codigo = codigo;
        this.titulo = titulo;
    }  

    //********************************************
    // 5) Método CalcularCostoTotal
    public float CalcularCostoTotal()
    {
        float costo = GetCostoBase() / 12;
        return costo;
    }
    // O tambien
    public float CalcularCosto()
    {
        return this.costoBase / 12f;
    }
    // La primera recurre siempre a "la ventanilla" geter, tiene ventaja si hay cambios a futuro. La segunda es más limpia, pero no escalable a futuro. Tambien funciona sin el this.


    //********************************************
    // 6) Método sobrecargado CalcularCostoTotal
    public float CalcularCostoTotal(bool anual)
    {
        float costoTotal;
        if (anual)
        {
            costoTotal = this.costoBase * (1 - descuentoAnual / 100);
            return costoTotal;
        }
        else
        {
            costoTotal = CalcularCostoTotal() * 12;
            return costoTotal;
        }
    }

    //********************************************
    // 7) Método DarDatos
    public string DarDatos()
    {
        string datos;
        datos = $"Código: {codigo}, Título: {titulo}," +
                $"\nCosto Base: {costoBase}, Costo Total Mensual: {CalcularCostoTotal()}";
        return datos;
    }

    //********************************************
    // 8) Método Sobrecargado DarDatos
    public string DarDatos(bool anual)
    {
        string datos;
        datos = DarDatos() +  
                $"\nDescuento Anual: {descuentoAnual}," +
                $"\n Costo Total Anual: {CalcularCostoTotal(anual)}";
        return datos;
    }

    //********************************************
    // 9) Método MasBarata
    public bool MasBarata(CRevista otraRevista)
    {
        bool masBarata = CalcularCostoTotal() < otraRevista.CalcularCostoTotal();
        return masBarata;
    }

    //********************************************
    // 10) Método de clase TotalRecaudado
    public static float TotalRecaudado(List<CRevista> lista)
    {
        float total = 0;
        foreach (CRevista revista in lista)
        {
            total += revista.GetCostoBase();
        }
        return total;
    }
}

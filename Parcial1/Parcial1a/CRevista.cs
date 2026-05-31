

using System;
using System.Collections.Generic;

public class CRevista
{
    // 1. Adecuada declaración de las variables miembro
    private string codigo;
    private string titulo;
    private float costoBase; // Representa el valor TOTAL de 12 meses según enunciado
    private static float descuentoAnual;
    
    // 2) Getter y Setter para .costoBase
    public void SetCostoBase(float costoBase)
    {
        this.costoBase = costoBase;
    }

    public float GetCostoBase()
    {
        return this.costoBase;
    }
    /*Como costoBase es privado, la ejecutora necesita interactuar con él. En la hoja vemos que la ejecutora hace "revista.SetCostoBase(costoBase);". Implementamos este método tradicional para asignarle el valor, y el GetCostoBase() para poder leerlo más adelante al comparar o calcular totales. */

    // 3) Propiedad de lectura y escritura DescuentoAnual (Static)
    public static float DescuentoAnual
    {
        get { return descuentoAnual; }
        set { descuentoAnual = value; }
    }
    /* Al pedir que opere "aún antes de crear cualquier Revista", debe ser estática. En C#, las propiedades combinan un campo privado con métodos get y set de forma más limpia. Al ser estática, permite que la ejecutora asigne el valor global (aunque en la ejecutora del papel vemos que usan una variable suelta y omitieron el prefijo CRevista., la propiedad queda disponible para la configuración del descuento).*/

    // 4. Método constructor parametrizado con los argumentos código y título.
    public CRevista(string codigo, string titulo)
    {
        this.codigo = codigo;
        this.titulo = titulo;
    }
    /* El enunciado pide explícitamente que el constructor reciba sólo el código y el título. 
    Esto coincide con la línea de la ejecutora: CRevista revista = new CRevista(codigo, titulo);. 
    El costo base se asigna después mediante el setter, no al momento de nacer el objeto.*/
    
    // 5. CalcularCosto() (Mensual sin descuento)
    public float CalcularCosto()
    {
        return this.costoBase / 12f;
    }
    /*La consigna aclara que el costo mensual es "sin descuento". Como la variable miembro costoBase
    almacena el equivalente a 12 meses, la cuenta matemática lógica para obtener el valor de
    un único mes es dividir ese costo base por 12 (costoBase / 12f). */

    /* 6. CalcularCosto(bool anual): 
    Devuelve el costo de la suscripción de 12 meses
    Aplicando el descuento por pago anual si corresponde. Acá aplicamos sobrecarga de métodos
    (mismo nombre, distintos parámetros). 
    Si el booleano anual es true, calculamos el valor de los 12 meses restándole el porcentaje
    de descuento (restando descuentoAnual / 100f a la unidad). Si es false, devuelve el costoBase
    original sin tocar.*/
    public float CalcularCosto(bool anual)
    {
        if (anual)
        {
            // descuentoAnual viene como porcentaje (ej: 15,25)
            return this.costoBase * (1f - (descuentoAnual / 100f));
        }
        return this.costoBase;
    }

    /* 7. DarDatos(): Concatenar variables miembro más el costo mensual calculado. Devuelve una cadena con
    los datos básicos y el costo mensual calculado en el punto 5.
    */
    public string DarDatos()
    {
        return $"Código: {codigo} | Título: {titulo} | Costo Base Anual: ${costoBase} | Costo Mensual: ${CalcularCosto()}";
    }

    // 8) DarDatos(bool anual)
    public string DarDatos(bool anual)
    {
        string tipoPago = anual ? "Anual con Descuento" : "Anual Completo sin Descuento";
        return $"Código: {codigo} | Título: {titulo} | Modo: {tipoPago} | Total: ${CalcularCosto(anual)}";
    }
    /* Otra sobrecarga. DarDatos(anual) se adapta para mostrar el total de la suscripción de 12 meses aplicando (o no) el descuento anual según el parámetro. */

    
    // 9) Comparación de costo (Equivalente al MasEconómico pedido, renombrado a MasBarata por la ejecutora)
    public bool MasBarata(CRevista otraRevista)
    {
        if (otraRevista == null) return true;
        return this.costoBase < otraRevista.GetCostoBase();
    }
    /*Devuelve true si la instancia actual es más barata que la pasada por parámetro (sin descuentos).
    El enunciado lo llamaba MasEconómico, pero en el papel de la ejecutora escribieron 
    if (revista.MasBarata(revistaMasEconomica)). Para que el código compile sin modificar la hoja de 
    la ejecutora, nombramos al método MasBarata. Recibe otra instancia de CRevista y compara los 
    costoBase directamente para saber cuál es menor.
    */


    // 10. Método de clase (static) TotalRecaudado
    public static float TotalRecaudado(List<CRevista> lista)
    {
        float total = 0f;
        foreach (CRevista revista in lista)
        {
            total += revista.GetCostoBase();
        }
        return total;
    }
    /*Calcula el total recaudado por la lista de revistas (sin descuentos). Es un método static de clase, es decir se invoca como CRevista.TotalRecaudado(revistas).
    Recibe la lista completa de los objetos cargados, la recorre con un bucle foreach, va sumando los costos base de cada revista y devuelve el importe final acumulado.
    */


}






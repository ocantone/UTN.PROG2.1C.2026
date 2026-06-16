using System;
using ListaBDAlumnos.Models;
using ListaBDAlumnos.Views;

namespace ListaBDAlumnos.Controllers
{
    public class AlumnoController
    {
        private AlumnoModel _model;
        private AlumnoView _view;

        public AlumnoController(AlumnoModel model, AlumnoView view)
        {
            _model = model;
            _view = view;
        }

        public void EjecutarListado()
        {
            try
            {
                // 1. El controlador solicita la información limpia al modelo
                var lista = _model.ObtenerTodos();

                // 2. El controlador le entrega los objetos a la vista para que los renderice
                _view.MostrarListado(lista);
            }
            catch (Exception ex)
            {
                // Si el modelo falla por problemas de BD, el controlador le ordena a la vista mostrar el error
                _view.MostrarError(ex.Message);
            }
        }
    }
}
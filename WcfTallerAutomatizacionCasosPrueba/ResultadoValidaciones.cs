using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfTallerAutomatizacionCasosPrueba
{

    public enum ResultadoValidacionEnum
    {
        OK,
        FALLO
    }

    public class EventoValidacion
    {
        public string error { get; set; }
        public string accion { get; set; }
    }

    public class ResultadoProceso {

        public int numeroAutorizacion { get; set; }
        public ResultadoValidaciones resultadoValidaciones{ get; set; }

        public void SetNumeroAutorizacion(ResultadoValidaciones resultadoValidaciones){
            this.resultadoValidaciones = resultadoValidaciones;
            if (this.resultadoValidaciones.resultadoValidacion == ResultadoValidacionEnum.OK)
            {
               numeroAutorizacion = 100+ new Random().Next(10000);
            }     
        }



    }

    
    public class ResultadoValidaciones
    {
        //public string Cufe { get; set; }
        public ResultadoValidacionEnum resultadoValidacion { get; set; }
        public List<EventoValidacion> eventosValidacion { get; set; }

        public ResultadoValidaciones() { }
        public ResultadoValidaciones(string mensaje)
        {
            this.resultadoValidacion = ResultadoValidacionEnum.OK;
            this.eventosValidacion = new List<EventoValidacion>();

        }

        public void agregarEvento(EventoValidacion eventoValidacion)
        {
            if (this.eventosValidacion == null)
                this.eventosValidacion = new List<EventoValidacion>();
            eventosValidacion.Add(eventoValidacion);
            if (this.eventosValidacion.Count() > 0) this.resultadoValidacion = ResultadoValidacionEnum.FALLO;
        }
        public string ToXmlString() {
            return XmlHelper.SerializeToXmlString<ResultadoValidaciones>(this);
        }

      }
}
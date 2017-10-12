using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfTallerAutomatizacionCasosPrueba
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IvalidaNotaVenta" in both code and config file together.
    [ServiceContract]
    public interface IvalidaNotaVenta
    {
        [OperationContract]
        MensajeRespuesta validarNotaVenta(MensajeEntrada mensajeEntrada);
    }

    [DataContract]
    public class MensajeEntrada
    {
        [DataMember]
        public string mensaje {get;set;}
    }

    [DataContract]
    public class MensajeRespuesta
    {
        private ResultadoProceso _resultadoProceso = null;
        [DataMember]
        public ResultadoProceso resultado  {
            get {return _resultadoProceso;}
            set { _resultadoProceso = value; }
        }

    }

}

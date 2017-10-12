using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfTallerAutomatizacionCasosPrueba
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "validaNotaVenta" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select validaNotaVenta.svc or validaNotaVenta.svc.cs at the Solution Explorer and start debugging.
    public class validaNotaVenta : IvalidaNotaVenta
    {
        private string validarEsquemaFlag = System.Configuration.ConfigurationManager.AppSettings["validarEsquemaFlag"];
        private string validarCalculosFlag = System.Configuration.ConfigurationManager.AppSettings["validarCalculosFlag"];
        public MensajeRespuesta validarNotaVenta(MensajeEntrada mensajeEntrada) {

            return validarNV(mensajeEntrada);
        }

        private  MensajeRespuesta validarNV(MensajeEntrada mensajeEntrada){
             
            ResultadoValidaciones resultadoValidaciones = new ResultadoValidaciones();
            if (validarEsquemaFlag == "1")
            {
                ValidarSchema validarEsquema = new ValidarSchema();
                validarEsquema.validar(mensajeEntrada.mensaje, resultadoValidaciones);
            }
            if (validarCalculosFlag == "1")
            {
                ValidarCalculos validarCalculos = new ValidarCalculos();
                validarCalculos.validar(mensajeEntrada.mensaje, resultadoValidaciones);
            }
            ResultadoProceso resultadoProceso = new ResultadoProceso();
            resultadoProceso.SetNumeroAutorizacion(resultadoValidaciones);
            MensajeRespuesta mensajeRespuesta = new MensajeRespuesta();
            mensajeRespuesta.resultado = resultadoProceso;
            return mensajeRespuesta;
        }
    }
}

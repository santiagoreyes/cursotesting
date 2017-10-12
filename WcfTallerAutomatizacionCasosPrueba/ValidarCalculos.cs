using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace WcfTallerAutomatizacionCasosPrueba
{
    public class ValidarCalculos
    {
        public ResultadoValidaciones validar(string mensajeXml, ResultadoValidaciones resultadoValidaciones)
        {
            XPathDocument document = new XPathDocument(XmlReader.Create(new StringReader(mensajeXml)));

            XPathNavigator navigator = document.CreateNavigator();
            try
            {
                Double monto = Double.Parse(navigator.SelectSingleNode("/notaVenta/monto").Value);
                Double porcentajeImpuesto = Double.Parse(navigator.SelectSingleNode("/notaVenta/porcentajeImpuesto").Value);
                Double total = Double.Parse(navigator.SelectSingleNode("/notaVenta/total").Value);
                if (monto * porcentajeImpuesto != total) { 
                    resultadoValidaciones.agregarEvento( new EventoValidacion { error = "Total no cuadra con monto por impuesto", accion = "Corregir total" });
                }
            }
            catch (Exception ex) {
                resultadoValidaciones.agregarEvento(new EventoValidacion { error = "No se pudo evaluar los calculos", accion = "Revisar" });
            }
            return resultadoValidaciones;
        }
    }
}

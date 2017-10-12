using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Schema;

namespace WcfTallerAutomatizacionCasosPrueba
{
    public class ValidarSchema
    {
        private string feNameSpace = "";
        private string xsdFile = "notaVenta.xsd";
        private ResultadoValidaciones resultadoValidaciones;

        public ValidarSchema() {
            this.xsdFile = System.Configuration.ConfigurationManager.AppSettings["xsdFile"];
        }

        // TODO: REVISAR PARA CAMBIAR A XmlSchemaValidator Push-Based Validation

        public ResultadoValidaciones validar(string mensajeXml, ResultadoValidaciones resultadoValidaciones)
        {
            this.resultadoValidaciones = resultadoValidaciones;
            XmlReaderSettings feSettings = new XmlReaderSettings();
            feSettings.Schemas.Add(feNameSpace, new XmlTextReader(HostingEnvironment.MapPath(xsdFile)));
            feSettings.ValidationType = ValidationType.Schema;
            feSettings.ValidationEventHandler += new ValidationEventHandler(feSettingsValidationEventHandler);

            XmlReader deXml = XmlReader.Create(new StringReader(mensajeXml), feSettings);

            while (deXml.Read()) { }

            return this.resultadoValidaciones;

        }

        private void feSettingsValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {

                resultadoValidaciones.agregarEvento(new EventoValidacion { error = e.Message, accion = "WARNING" });
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                resultadoValidaciones.agregarEvento(new EventoValidacion { error = e.Message, accion = "ERROR" });
            }
        }


    }
}
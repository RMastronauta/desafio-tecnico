using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesafioTecnicoUnicont.Domain.Dto
{
    [XmlRoot("NotaFiscal")]
    public class NotaFiscalXmlDto
    {
        [XmlElement("Numero")]
        public string Numero { get; set; } = string.Empty;

        [XmlElement("Prestador")]
        public PrestadorXmlDto Prestador { get; set; } = new();

        [XmlElement("Tomador")]
        public TomadorXmlDto Tomador { get; set; } = new();

        [XmlElement("DataEmissao")]
        public DateTime DataEmissao { get; set; }

        [XmlElement("Servico")]
        public ServicoXmlDto Servico { get; set; } = new();
    }

    public class PrestadorXmlDto
    {
        [XmlElement("CNPJ")]
        public string CNPJ { get; set; } = string.Empty;
    }

    public class TomadorXmlDto
    {
        [XmlElement("CNPJ")]
        public string CNPJ { get; set; } = string.Empty;
    }

    public class ServicoXmlDto
    {
        [XmlElement("Descricao")]
        public string Descricao { get; set; } = string.Empty;

        [XmlElement("Valor")]
        public decimal Valor { get; set; }
    }
}

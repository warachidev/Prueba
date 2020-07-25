using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class MarcaData
    {
        [DataType(DataType.Text)]
        [DisplayName("marca")]
        [UIHint("List")]
        public List<SelectListItem> marcaLista { get; set; }

        public int id_marca {get; set;}

        public MarcaData() {
            BDAutosEntities data = new BDAutosEntities();
            marcaLista = new List<SelectListItem>();
            var query = from u in data.marca select u;
            var listData = query.ToList();
            foreach (var Data in listData) {
                marcaLista.Add(new SelectListItem()
                {
                    Value = Data.id_marca.ToString(),
                    Text = Data.nombre
                });
            }
        }
    }
}
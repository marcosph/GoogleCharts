using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleCharts.Web.Models
{
    public class ViewGoogleDataTable
    {
        public IList<Col> Cols { get; } = new List<Col>();
        public IList<Row> Rows { get; } = new List<Row>();

        private P _p;
        public P P_
        {
            get
            {
                if (_p != null) return _p;
                return _p = new P();
            }
            set
            {
                _p = value;
            }
        }
        public class P
        {
            public List<string> Colors { get; set; }
            public string Titulo { get; set; }
        }
        public void AddP(string codigoCor)
        {
            P_.Colors.Add(codigoCor);
        }


        public void AddColumn(string label, string type)
        {
            Cols.Add(new Col() { Label = label, Type = type });
        }

        public void AddRow(IList<object> values)
        {
            Rows.Add(new Row() { C = values.Select(x => new Row.RowValue() { v = x }) });
        }

        public class Col
        {
            public string Label { get; set; }
            public string Type { get; set; }
        }

        public class Row
        {
            public IEnumerable<RowValue> C { get; set; }
            public class RowValue
            {
                public object v;
            }
        }
    }
}

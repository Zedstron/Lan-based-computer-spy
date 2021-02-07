using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class DataObject
{
    public string CommandName { get; set; }
    public string CommandType { get; set; }
    public object CommandData { get; set; }
}

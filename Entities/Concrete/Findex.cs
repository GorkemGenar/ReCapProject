using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Findex:IEntity
    {
        public int FindexId { get; set; }
        public int UserId { get; set; }
        public int FindexRate { get; set; }
    }
}

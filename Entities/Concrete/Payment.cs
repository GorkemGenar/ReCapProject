using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CardId { get; set; }
        public DateTime Date { get; set; }
    }
}

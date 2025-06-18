using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault.Models
{
    internal class KeyValue
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("key"), Required]
        public string? Key { get; set; }

        [Column("value"), Required]
        public string? Value { get; set; }
    }
}

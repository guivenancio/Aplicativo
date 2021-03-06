﻿using Aplicativo.Utils.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicativo.Utils.Models
{

    [Serializable()]
    [Table("CFOP")]
    public partial class CFOP : _Extends
    {

        [Key]
        [StringLength(5)]
        public string Codigo { get; set; }

        public string Descricao { get; set; }

    }
}